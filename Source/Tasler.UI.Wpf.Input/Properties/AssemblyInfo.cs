using System.Runtime.InteropServices;
using System.Windows.Markup;
using Tasler.Windows;

// Assembly-specific information about the assembly. Shared, assembly-neutral information
// is specified in the following files:
//     DirectoryBuild.props
//     AssemblyInfoVersion.cs
// Also, some assembly-specified information is specified in project file.
[assembly: Guid("4D4B272C-D636-41A3-9726-5A442BDD0750")]

// Declaration for the XAML parser. These allow multiple CLR namespaces defined in this assembly to
// be collapsed into a single XML namespace.
[assembly: XmlnsPrefix( XmlNamespace.Tasler, XmlNamespacePrefix.Tasler)]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Input")]
