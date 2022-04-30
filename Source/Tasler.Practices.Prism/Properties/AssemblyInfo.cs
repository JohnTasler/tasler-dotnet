using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Markup;

// Assembly-specific information about an assembly. Shared, assembly-neutral information
// is in the following files:
//     AssemblyInfoConfiguration.cs
//     AssemblyInfoCopyright.cs
//     AssemblyInfoVersion.cs
[assembly: AssemblyTitle("Tasler.Practices.Prism")]
[assembly: AssemblyDescription("Application-neutral .NET Prism extensions.")]
[assembly: AssemblyProduct("Tasler .NET Framework")]
[assembly: Guid("373D9B17-77A9-429D-94CF-CB73A099CA28")]

// Declaration for the XAML parser. These allow multiple CLR namespaces defined in this assembly to
// be collapsed into a single XML namespace.
[assembly: XmlnsPrefix(XmlNamespace.Tasler, XmlNamespacePrefix.Tasler)]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Practices.Prism")]
