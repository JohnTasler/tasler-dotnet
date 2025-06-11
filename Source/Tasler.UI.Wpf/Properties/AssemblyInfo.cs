using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Markup;

// Assembly-specific information about the assembly. Shared, assembly-neutral information
// is specified in the following files:
//     DirectoryBuild.props
//     AssemblyInfoVersion.cs
// Also, some assembly-specified information is specified in project file.

[assembly: Guid("CC6BE222-DE4B-412A-9743-80C187F43EE1")]
[assembly: DisableRuntimeMarshalling]

// Declaration for the XAML parser. These allow multiple CLR namespaces defined in this assembly to
// be collapsed into a single XML namespace.
[assembly: XmlnsPrefix(XmlNamespace.Tasler, XmlNamespacePrefix.Tasler)]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows")]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Attachments")]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Behaviors")]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Controls")]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Converters")]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Extensions")]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Markup")]

[assembly: InternalsVisibleTo("Tasler.Windows.Input")]
[assembly: InternalsVisibleTo("Tasler.Configuration")]

internal static class XmlNamespace
{
		public const string Tasler = "urn:tasler-dotnet-ui";
}

internal static class XmlNamespacePrefix
{
		public const string Tasler = "taz";
}
