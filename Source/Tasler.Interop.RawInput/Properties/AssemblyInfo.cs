using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Markup;

// Assembly-specific information about an assembly. Shared, assembly-neutral information
// is in the following files:
//     AssemblyInfoConfiguration.cs
//     AssemblyInfoCopyright.cs
//     AssemblyInfoVersion.cs

[assembly: AssemblyTitle("Application-neutral .NET core interop framework for raw (HID) input.")]
[assembly: AssemblyProduct("Tasler .NET Framework")]
[assembly: Guid("90E7B808-EA0E-431D-B61F-496BA8B117B9")]

// Declaration for the XAML parser. These allow multiple CLR namespaces defined in this assembly to
// be collapsed into a single XML namespace.
[assembly: XmlnsPrefix(XmlNamespace.Tasler, XmlNamespacePrefix.Tasler)]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Interop.RawInput")]
[assembly: XmlnsDefinition(XmlNamespace.Tasler, "Tasler.Interop.RawInput.User")]

internal static class XmlNamespace
{
    public const string Tasler = "urn:tasler-dotnet-framework";
}

internal static class XmlNamespacePrefix
{
    public const string Tasler = "taz";
}
