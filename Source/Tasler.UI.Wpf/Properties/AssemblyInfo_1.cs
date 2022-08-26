using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Markup;

// Assembly-specific information about an assembly. Shared, assembly-neutral information
// is in the following files:
//     AssemblyInfoConfiguration.cs
//     AssemblyInfoCopyright.cs
//     AssemblyInfoVersion.cs
[assembly: AssemblyTitle("Tasler.Windows")]
[assembly: AssemblyDescription("Application-neutral .NET Windows Presentation Foundation framework.")]
[assembly: AssemblyProduct("Tasler .NET Framework")]
[assembly: Guid("A3F179FE-71EC-49BE-812D-6A03C63B17FF")]

// Declaration for the XAML parser. These allow multiple CLR namespaces defined in this assembly to
// be collapsed into a single XML namespace.
[assembly: XmlnsPrefix(XmlNamespace.Tasler, XmlNamespacePrefix.Tasler)]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows")]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Attachments")]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Behaviors")]
//[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Collections")]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Controls")]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Converters")]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Extensions")]
//[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Markup")]
