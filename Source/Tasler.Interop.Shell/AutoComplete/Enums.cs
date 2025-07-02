
namespace Tasler.Interop.Shell.AutoComplete;

public enum AutoCompleteOption : uint
{
	None            = 0x0000, // No options
	MostRecentFirst = 0x0001, // Display most recently used items first
	FirstUnused     = 0x10000,// 0x00010000 through 0xffff0000 are for enumerator specific options (0x0002-0xffff are reserved)
}

[Flags]
public enum AutoCompleteOptions : uint
{
	/// <summary>No AutoComplete</summary>
	None               = 0x00,
	/// <summary>enable autosuggest dropdown</summary>
	AutoSuggest        = 0x01,
	/// <summary>enable autoappend</summary>
	AutoAppend         = 0x02,
	/// <summary>add search entry to completion list</summary>
	Search             = 0x04,
	/// <summary>don't match common prefixes (www., http://, etc)</summary>
	FilterPrefixes     = 0x08,
	/// <summary>use tab to select autosuggest entries</summary>
	UseTab             = 0x10,
	/// <summary>up/down arrow key invokes autosuggest dropdown (if enabled)</summary>
	UpdownKeyDropsList = 0x20,
	/// <summary>enable RTL reading order for dropdown</summary>
	RtlReading         = 0x40,
	/// <summary>Enable AND-ing of results for the search ux.</summary>
	WordFilter         = 0x80,
	/// <summary>Disable prefix filtering when displaying autosuggest dropdown.  Always display all suggestions.</summary>
	NoPrefixFiltering  = 0x100,
}

[Flags]
public enum AutoCompleteListOptions : uint
{
	/// <summary>Don't enumerate anything.</summary>
	None             = 0x00,
	/// <summary>Enumerate the current working directory</summary>
	CurrentDir       = 0x01,
	/// <summary>Enumerate My Computer</summary>
	MyComputer       = 0x02,
	/// <summary>Enumerate the Desktop folder</summary>
	Desktop          = 0x04,
	/// <summary>Enumerate the Favorites folder</summary>
	Favorites        = 0x08,
	/// <summary>Enumerate only those items that are part of the file system. Do not enumerate items contained by virtual folders.</summary>
	FileSysOnly      = 0x10,
	/// <summary>Enumerate only the file system directories, UNC shares, and UNC servers.</summary>
	FileSysDirs      = 0x20,
	/// <summary>Enumerate on the virual namespace</summary>
	VirtualNamespace = 0x40,
}
