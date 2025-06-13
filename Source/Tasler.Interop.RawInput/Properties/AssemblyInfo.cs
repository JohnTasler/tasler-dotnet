using System.Runtime.InteropServices;
using System.Windows.Markup;

// Assembly-specific information about the assembly. Shared, assembly-neutral information
// is specified in the following files:
//     DirectoryBuild.props
//     AssemblyInfoVersion.cs
// Also, some assembly-specified information is specified in project file.

[assembly: Guid("921D82F1-B7A8-47F9-83E0-B576441057F7")]

// Declaration for the XAML parser. These allow multiple CLR namespaces defined in this assembly to
// be collapsed into a single XML namespace.
[assembly: XmlnsPrefix(XmlNamespace.Tasler, XmlNamespacePrefix.Tasler)]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Interop.RawInput")]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Interop.RawInput.User")]

internal static class XmlNamespace
{
    public const string Tasler = "urn:tasler-dotnet-ui";
}

internal static class XmlNamespacePrefix
{
    public const string Tasler = "taz";
}
