namespace Tasler.Interop.Kernel;

/// <summary>
/// Flags used with <see cref="KernelApi.LoadLibraryEx"/>.
/// </summary>
[Flags]
public enum LoadLibraryFlags : uint
{
	/// <summary>
	/// <para></para>If this value is used, and the executable module is a DLL, the system does not
	/// call DllMain for process and thread initialization and termination. Also, the system does not
	/// load additional executable modules that are referenced by the specified module.</para>
	/// <para>Note Do not use this value; it is provided only for backward compatibility. If you are
	/// planning to access only data or resources in the DLL, use LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE
	/// or LOAD_LIBRARY_AS_IMAGE_RESOURCE or both. Otherwise, load the library as a DLL or executable
	/// module using the LoadLibrary function.</para>
	/// </summary>
	[Obsolete("Note Do not use this value; it is provided only for backward compatibility.")]
	NoResolveDllReferences = 0x00000001,

	/// <summary>
	/// <para>If this value is used, the system does not check AppLocker rules or apply Software
	/// Restriction Policies for the DLL. This action applies only to the DLL being loaded and not to
	/// its dependencies. This value is recommended for use in setup programs that must run extracted
	/// DLLs during installation.</para>
	/// <para>The caller must be running as "LocalSystem" or "TrustedInstaller"; otherwise the system
	/// ignores this flag. For more information, see "You can circumvent AppLocker rules by using an
	/// Office macro on a computer that is running Windows 7 or Windows Server 2008 R2" in the Help
	/// and Support Knowledge Base at https://support.microsoft.com/kb/2532445.</para>
	/// </summary>
	IgnoreCodeAuthzLevel = 0x00000010,

	/// <summary>
	/// <para>If this value is used, the system maps the file into the calling process's virtual
	/// address space as if it were a data file. Nothing is done to execute or prepare to execute the
	/// mapped file. Therefore, you cannot call functions like GetModuleFileName, GetModuleHandle or
	/// GetProcAddress with this DLL. Using this value causes writes to read-only memory to raise an
	/// access violation. Use this flag when you want to load a DLL only to extract messages or
	/// resources from it.</para>
	/// <para>This value can be used with <see cref="AsImageResource"/>. For more information, see
	/// Remarks.</para>
	/// </summary>
	AsDatafile = 0x00000002,

	/// <summary>
	/// <para>Similar to <see cref="AsDatafile"/>, except that the DLL file is opened with exclusive
	/// write access for the calling process.Other processes cannot open the DLL file for write
	/// access while it is in use.However, the DLL can still be opened by other processes.</para>
	/// <para>This value can be used with <see cref="AsImageResource"/>.For more information, see
	/// Remarks.</para>
	/// </summary>
	AsDatafileExclusive = 0x00000040,

	/// <summary>
	/// <para>If this value is used, the system maps the file into the process's virtual address
	/// space as an image file. However, the loader does not load the static imports or perform the
	/// other usual initialization steps. Use this flag when you want to load a DLL only to extract
	/// messages or resources from it.</para>
	/// <para>Unless the application depends on the file having the in-memory layout of an image,
	/// this value should be used with either <see cref="AsDatafileExclusive"/> or
	/// <see cref="AsDatafile"/>.For more information, see the Remarks section.</para>
	/// </summary>
	AsImageResource = 0x00000020,

	/// <summary>
	/// If this value is used, the application's installation directory is searched for the DLL and
	/// its dependencies. Directories in the standard search path are not searched. This value cannot
	/// be combined with <see cref="AlteredSearchPath"/>.
	/// </summary>
	SearchApplicationDir = 0x00000200,

	/// <summary>
	/// <para>This value is a combination of <see cref="SearchApplicationDir"/>,
	/// <see cref="SearchSystem32"/, and <see cref="SearchUserDirs"/>. Directories in the standard
	/// search path are not searched. This value cannot be combined with
	/// <see cref="AlteredSearchPath"/>.</para>
	/// <para>This value represents the recommended maximum number of directories an application
	/// should include in its DLL search path.</para>
	/// </summary>
	SearchDefaultDirs = 0x00001000,

	/// <summary>
	/// <para>If this value is used, the directory that contains the DLL is temporarily added to the
	/// beginning of the list of directories that are searched for the DLL's dependencies.
	/// Directories in the standard search path are not searched.</para>
	/// <para>The lpFileName parameter must specify a fully qualified path.This value cannot be
	/// combined with <see cref="AlteredSearchPath"/>.</para>
	/// </para>For example, if Lib2.dll is a dependency of C:\Dir1\Lib1.dll, loading Lib1.dll with
	/// this value causes the system to search for Lib2.dll only in C:\Dir1.To search for Lib2.dll in
	/// C:\Dir1 and all of the directories in the DLL search path, combine this value with
	/// <see cref="SearchDefaultDirs"/>.
	/// </summary>
	SearchDllLoadDir = 0x00000100,

	/// <summary>
	/// If this value is used, %windows%\system32 is searched for the DLL and its dependencies.
	/// Directories in the standard search path are not searched.This value cannot be combined with
	/// <see cref="AlteredSearchPath"/>.
	/// </summary>
	SearchSystem32 = 0x00000800,

	/// <summary>
	/// If this value is used, directories added using the AddDllDirectory or the SetDllDirectory
	/// function are searched for the DLL and its dependencies. If more than one directory has been
	/// added, the order in which the directories are searched is unspecified. Directories in the
	/// standard search path are not searched. This value cannot be combined with
	/// <see cref="AlteredSearchPath"/>.
	/// </summary>
	SearchUserDirs = 0x00000400,

	/// <summary>
	/// <para>If this value is used and the file name specifies an absolute path, the system uses the
	/// alternate file search strategy discussed in the Remarks section to find associated executable
	/// modules that the specified module causes to be loaded. If this value is used and lpFileName
	/// specifies a relative path, the behavior is undefined.</para>
	/// <para>If this value is not used, or if lpFileName does not specify a path, the system uses
	/// the standard search strategy discussed in the Remarks section to find associated executable
	/// modules that the specified module causes to be loaded.</para>
	/// <para>This value cannot be combined with any of the <see cref="LoadLibraryFlags"/>
	/// search flags.</para>
	/// </summary>
	AlteredSearchPath = 0x00000008,

	/// <summary>
	/// Specifies that the digital signature of the binary image must be checked at load time.
	/// </summary>
	RequireSignedTarget = 0x00000080,

	/// <summary>
	/// If this value is used, loading a DLL for execution from the current directory is only allowed
	/// if it is under a directory in the Safe load list.
	/// </summary>
	SafeCurrentDirs = 0x00002000,
}
