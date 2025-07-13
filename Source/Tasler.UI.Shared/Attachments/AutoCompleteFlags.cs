
namespace Tasler.Windows.Attachments;

[Flags]
public enum AutoCompleteFlags : uint
{
	Default             = 0x00000000,  // Currently (SHACF_FILESYSTEM | SHACF_URLALL)
	FileSystem          = 0x00000001,  // This includes the File System as well as the rest of the shell (Desktop\My Computer\Control Panel\)
	UrlAll              = (UrlHistory | UrlMru),
	UrlHistory          = 0x00000002,  // URLs in the User's History
	UrlMru              = 0x00000004,  // URLs in the User's Recently Used list.
	UseTab              = 0x00000008,  // Use the tab to move thru the autocomplete possibilities instead of to the next dialog/window control.
	FileSystemOnly      = 0x00000010,  // This includes the File System
	FileSystemDirs      = 0x00000020,  // Same as SHACF_FILESYS_ONLY except it only includes directories, UNC servers, and UNC server shares.
	VirtualNamespace    = 0x00000040,  // Also include the virtual namespace
//	AutoSuggestForceOn  = 0x10000000,  // Ignore the registry default and force the feature on.
//	AutoSuggestForceOff = 0x20000000,  // Ignore the registry default and force the feature off.
//	AutoAppendForceOn   = 0x40000000,  // Ignore the registry default and force the feature on. (Also know as AutoComplete)
//	AutoAppendForceOff  = 0x80000000,  // Ignore the registry default and force the feature off. (Also know as AutoComplete)
}
