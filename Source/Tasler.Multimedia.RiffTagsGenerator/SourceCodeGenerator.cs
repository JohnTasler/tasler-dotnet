using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;

namespace Tasler.Multimedia.RiffTagsGenerator
{
    // In order to be compatible with this single file generator, the input file has to
    // follow the schema in XMLClassGeneratorSchema.xsd

    /// <summary>
    /// Generates source code based on a XML document
    /// </summary>
    public static class SourceCodeGenerator
    {
        /// <summary>
        /// Creates a CodeCompileUnit based on the specified RiffTags.
        /// </summary>
        /// <param name="riffTags">A <see cref="RiffTags"/> that contains the description of the code to be generated/</param>
        /// <param name="namespaceName">The namesace in which to enclose the generated code.</param>
        /// <returns>The generated CodeCompileUnit</returns>
        public static CodeCompileUnit CreateCodeCompileUnit(RiffTags riffTags, string namespaceName) 
        {
            // Create the code compile unit
            CodeCompileUnit code = new CodeCompileUnit();
            
            // Just for VB.NET:
            // Option Strict On (controls whether implicit type conversions are allowed)
            code.UserData.Add("AllowLateBound", false);
            // Option Explicit On (controls whether variable declarations are required)
            code.UserData.Add("RequireVariableDeclaration", true);

            // Create the namespace
            CodeNamespace codeNamespace = new CodeNamespace(riffTags.Namespace);

            // Create the class
            CodeTypeDeclaration codeClass = CreateGroupClass(1, riffTags);

            // Add the class to the namespace
            codeNamespace.Types.Add(codeClass);

            // Add the namespace to the compile unit
            code.Namespaces.Add(codeNamespace);

            // Return the compile unit
            return code;
        }

        private static CodeTypeDeclaration CreateGroupClass(int indent, GroupBase group) 
        {
            // Create the class declaration
            CodeTypeDeclaration codeClass = new CodeTypeDeclaration(group.Name);
            codeClass.IsClass = true;
            codeClass.TypeAttributes = TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.Abstract;
            codeClass.TypeAttributes |= (group is RiffTags) ? TypeAttributes.Public : TypeAttributes.NestedPublic;

            // Create the summary code comment text
            string summary = group.Summary;
            if (string.IsNullOrEmpty(summary))
            {
                summary = group.Name;
            }

            // Add the summary code comment
            codeClass.Comments.Add(
                new CodeCommentStatement("<summary>" + summary + "</summary>", true));

            // Add the remarks code comment, if specified
            if (!string.IsNullOrEmpty(group.Remarks))
            {
                codeClass.Comments.Add(
                    new CodeCommentStatement("<remarks>" + group.Remarks + "</remarks>", true));
            }

            // If the group has a Tag collection, create and add a class for each
            if (group.Tag != null)
            {
                foreach (Tag tag in group.Tag)
                {
                    CodeTypeMember codeTagClass = CreateTagClass(indent + 1, tag);
                    codeClass.Members.Add(codeTagClass);
                }
            }

            // If the group has a TagGroup collection, create and add a class for each
            if (group.TagGroup != null)
            {
                foreach (TagGroup tagGroup in group.TagGroup)
                {
                    CodeTypeDeclaration codeGroupClass = CreateGroupClass(indent + 1, tagGroup);
                    codeGroupClass.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, tagGroup.Name));
                    codeGroupClass.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));
                    codeClass.Members.Add(codeGroupClass);
                }
            }

            // Return the resulting CodeTypeDeclaration
            return codeClass;
        }

        private static CodeTypeMember CreateTagClass(int indent, Tag tag) 
        {
            // Create the indentation string
            string indentation = new string(' ', indent * 4);

            // Determine the region text
            string region = "'" + tag.FourCC + "'";
            if (!string.IsNullOrEmpty(tag.Name))
            {
                region += " - " + tag.Name;
            }

            // Determine the summary code comment text
            string summary = region;
            if (!string.IsNullOrEmpty(tag.Summary))
            {
                summary += " - " + tag.Summary;
            }

            // Create the code as a string
            StringBuilder sb = new StringBuilder();

            // Append the region directive and summary code comment
            sb.AppendFormat(
                "{0}#region {1}\r\n" +
                "{0}/// <summary>{2}</summary>\r\n",
                indentation,
                region,
                summary
            );

            // Append the remarks code comment, if specified
            if (!string.IsNullOrEmpty(tag.Remarks))
            {
                sb.AppendFormat(
                    "{0}/// <remarks>{1}</remarks>\r\n",
                    indentation,
                    tag.Remarks);
            }

            // Append the entire rest of the class declaration
            sb.AppendFormat(
                "{0}public static class {1}\r\n" +
                "{0}{{\r\n" +
                "{0}    /// <summary>The integer value of the tag.</summary>\r\n" +
                "{0}    public const int Value = 0x{2:X8};\r\n" +
                "{0}\r\n" +
                "{0}    /// <summary>The string value of the tag.</summary>\r\n" +
                "{0}    public const string String = \"{1}\";\r\n" +
                "{0}\r\n" +
                "{0}    /// <summary>The tag as a <see cref=\"FourCC\"/> value.</summary>\r\n" +
                "{0}    public static readonly {3} FourCC = new FourCC(Value);\r\n" +
                "{0}}}\r\n" +
                "{0}#endregion\r\n",
                indentation,
                tag.FourCC.Trim(),
                new FourCC(tag.FourCC).Value,
                typeof(FourCC).FullName
            );

            // Return the code snippet
            return new CodeSnippetTypeMember(sb.ToString());
        }
   }
}