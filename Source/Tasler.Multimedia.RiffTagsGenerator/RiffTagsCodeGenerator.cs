using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Microsoft.VisualStudio.Shell;
using Microsoft.Win32;
using VSLangProj80;

namespace Tasler.Multimedia.RiffTagsGenerator
{
	/// <summary>
	/// This is the generator class. 
	/// When setting the 'Custom Tool' property of a C# project item to "RiffTagsCodeGenerator", 
	/// the GenerateCode function will get called and will return the contents of the generated file 
	/// to the project system.
	/// </summary>
	[ComVisible(true)]
	[Guid("9190F198-9D25-4AD2-BDF1-4DB37AB65571")]
	[CodeGeneratorRegistration(typeof(RiffTagsCodeGenerator), "C# Riff Tags Code Generator", vsContextGuids.vsContextGuidVCSProject, GeneratesDesignTimeSource = true)]
	[ProvideObject(typeof(RiffTagsCodeGenerator))]
	public class RiffTagsCodeGenerator : BaseCodeGeneratorWithSite
	{
		//The name of this generator (use for 'Custom Tool' property of project item)
//		internal static string name = "RiffTagsGenerator";

		internal static bool validXML;

		/// <summary>
		/// Function that builds the contents of the generated file based on the contents of the input file
		/// </summary>
		/// <param name="inputFileContent">Content of the input file</param>
		/// <returns>Generated file as a byte array</returns>
		protected override byte[] GenerateCode(string inputFileContent)
		{
			// Validate the XML file against the schema
			using (StringReader contentReader = new StringReader(inputFileContent))
			{
				this.VerifyDocumentSchema(contentReader);
			}

			if (!validXML)
			{
				// Returning null signifies that generation has failed
				return null;
			}

			// Report that we are 25% done
			if (this.CodeGeneratorProgress != null)
			{
				this.CodeGeneratorProgress.Progress(25, 100);
			}

			// Create the CodeDomProvider
			CodeDomProvider provider = base.GetCodeProvider();

			try
			{
				// Deserialize the specified content
				RiffTags riffTags = null;
				using (StringReader contentReader = new StringReader(inputFileContent))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(RiffTags));
					riffTags = (RiffTags)serializer.Deserialize(contentReader);
				}

				// Report that we are 50% done
				if (this.CodeGeneratorProgress != null)
				{
					this.CodeGeneratorProgress.Progress(50, 100);
				}

				// Create the CodeCompileUnit from the deserialized XML file
				CodeCompileUnit compileUnit =
					SourceCodeGenerator.CreateCodeCompileUnit(riffTags, FileNameSpace);

				// Report that we are 75% done
				if (this.CodeGeneratorProgress != null)
				{
					this.CodeGeneratorProgress.Progress(50, 100);
				}

				// Format the output
				using (StringWriter writer = new StringWriter(new StringBuilder()))
				{
					CodeGeneratorOptions options = new CodeGeneratorOptions();
					options.BlankLinesBetweenMembers = false;
					options.BracingStyle = "C";
					options.VerbatimOrder = true;

					// Generate the code
					provider.GenerateCodeFromCompileUnit(compileUnit, writer, options);
					writer.Flush();

					// Report that we are 95% done
					if (this.CodeGeneratorProgress != null)
					{
						this.CodeGeneratorProgress.Progress(95, 100);
					}

					// Get the Encoding used by the writer. We're getting the WindowsCodePage encoding, 
					// which may not work with all languages
					Encoding enc = Encoding.GetEncoding(writer.Encoding.WindowsCodePage);

					// Get the preamble (byte-order mark) for our encoding
					byte[] preamble = enc.GetPreamble();
					int preambleLength = preamble.Length;

					// Replace " sealed abstract class " with " static class "
					writer.GetStringBuilder().Replace(" sealed abstract class ", " static class ");

					// Convert the writer contents to a byte array
					byte[] body = enc.GetBytes(writer.ToString());

					// Prepend the preamble to body (store result in resized preamble array)
					Array.Resize<byte>(ref preamble, preambleLength + body.Length);
					Array.Copy(body, 0, preamble, preambleLength, body.Length);

					// Report that we are done
					if (this.CodeGeneratorProgress != null)
					{
						this.CodeGeneratorProgress.Progress(100, 100);
					}

					// Return the combined byte array
					return preamble;
				}
			}
			catch (Exception e)
			{
				this.GeneratorError(4, e.ToString(), 1, 1);

				//Returning null signifies that generation has failed
				return null;
			}
		}

		/// <summary>
		/// Verify the XML document in contentReader against the schema in XMLClassGeneratorSchema.xsd
		/// </summary>
		/// <param name="contentReader">TextReader for XML document</param>
		private void VerifyDocumentSchema(TextReader contentReader)
		{
			// Options for XmlReader object can be set only in constructor. After the object is created, 
			// they become read-only. Because of that we need to create XmlSettings structure, 
			// fill it in with correct parameters and pass into XmlReader constructor.
			XmlReaderSettings validatorSettings = new XmlReaderSettings();
			validatorSettings.ValidationType = ValidationType.Schema;
			validatorSettings.XmlResolver = null;
			validatorSettings.ValidationEventHandler += new ValidationEventHandler(this.OnSchemaValidationError);

			//Schema is embedded in this assembly. Get its stream
			Stream schema = this.GetType().Assembly.GetManifestResourceStream("Tasler.Multimedia.RiffTagsGenerator.RiffTagsGeneratorSchema.xsd");

			using (XmlTextReader schemaReader = new XmlTextReader(schema))
			{
				try
				{
					validatorSettings.Schemas.Add("uri:Tasler-Multimedia/RiffTagsGenerator.xsd", schemaReader);

					using (XmlReader validator = XmlReader.Create(contentReader, validatorSettings, InputFilePath))
					{
						validXML = true;

						while (validator.Read())
						{
							//empty body
						}
					}
				}
				// handle errors in the schema itself
				catch (XmlException e)
				{
					this.GeneratorError(4, "InvalidSchemaFileEmbeddedInGenerator " + e.ToString(), 1, 1);
					validXML = false;
					return;
				}
				// handle errors in the schema itself
				catch (XmlSchemaException e)
				{
					this.GeneratorError(4, "InvalidSchemaFileEmbeddedInGenerator " + e.ToString(), 1, 1);
					validXML = false;
					return;
				}
				catch (Exception e)
				{
					this.GeneratorError(4, "InvalidSchemaFileEmbeddedInGenerator " + e.ToString(), 1, 1);
					validXML = false;
					return;
				}
			}
		}

		/// <summary>
		/// Receives any errors that occur while validating the documents's schema.
		/// </summary>
		/// <param name="sender">Sender object</param>
		/// <param name="args">Details about the validation error that has occurred</param>
		private void OnSchemaValidationError(object sender, ValidationEventArgs args)
		{
			//signal that validation of document against schema has failed
			validXML = false;

			//Report the error (so that it is shown in the error list)
			this.GeneratorError(4, args.Exception.Message, (uint)args.Exception.LineNumber - 1, (uint)args.Exception.LinePosition - 1);
		}
	}
}