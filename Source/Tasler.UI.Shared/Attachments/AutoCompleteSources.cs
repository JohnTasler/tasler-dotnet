
namespace Tasler.Windows.Attachments;

[Flags]
public enum AutoCompleteSources : uint
{
	/// <summary>
	/// The default, which is <see cref="FileSystem"/> <c>|</c> <see cref="UrlAll"/>.
	/// This is effective if it's the only flag value specified.
	/// </summary>
	Default             = 0x00000000,

	/// <summary>
	/// This includes the File System as well as the rest of the shell (Desktop\My Computer\Control Panel\).
	/// </summary>
	FileSystem          = 0x00000001,

	/// <summary>
	/// Both URL sources, <see cref="UrlHistory"/> <c>|</c> <see cref="UrlMru"/>.
	/// </summary>
	UrlAll              = (UrlHistory | UrlMru),

	/// <summary>URLs in the User's History.</summary>
	UrlHistory          = 0x00000002,

	/// <summary>URLs in the User's Recently Used list.</summary>
	UrlMru              = 0x00000004,

	/// <summary>This includes the File System.</summary>
	FileSystemOnly      = 0x00000010,

	/// <summary>
	/// Same as <see cref="FileSystemOnly"/> except it only includes directories, UNC servers,
	/// and UNC server shares.
	/// </summary>
	FileSystemDirs      = 0x00000020,

	/// <summary>Also include the virtual namespace.</summary>
	VirtualNamespace    = 0x00000040,
}
