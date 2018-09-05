using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Markup;

// Assembly-specific information about an assembly. Shared, assembly-neutral information
// is in the following files:
//     AssemblyInfoConfiguration.cs
//     AssemblyInfoCopyright.cs
//     AssemblyInfoVersion.cs

[assembly: AssemblyTitle("Tasler.UI.Wpf")]
[assembly: AssemblyProduct("Tasler .NET Framework")]
[assembly: Guid("4dd7ed0b-d1b6-4ecd-8028-71d13a3a4834")]

// Declaration for the XAML parser. These allow multiple CLR namespaces defined in this assembly to
// be collapsed into a single XML namespace.
[assembly: XmlnsPrefix(XmlNamespace.Tasler, XmlNamespacePrefix.Tasler)]
//[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Controls")]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Windows.Converters")]

internal static class XmlNamespace
{
	public const string Tasler = "urn:tasler-dot-net-framework";
}

internal static class XmlNamespacePrefix
{
	public const string Tasler = "taz";
}
