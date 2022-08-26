using System.Windows;

#if !SILVERLIGHT
[assembly: ThemeInfo(
	// where theme specific resource dictionaries are located
	// (used if a resource is not found in the page, or application resource dictionaries)
	ResourceDictionaryLocation.None,

	// where the generic resource dictionary is located
	// (used if a resource is not found in the page, app, or any theme specific resource dictionaries)
	ResourceDictionaryLocation.SourceAssembly)
]
#endif // !SILVERLIGHT

internal static class XmlNamespace
{
	public const string Tasler = "urn:tasler-dot-net-framework";
}

internal static class XmlNamespacePrefix
{
	public const string Tasler = "taz";
}

