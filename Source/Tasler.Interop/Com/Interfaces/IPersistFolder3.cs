using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com;

namespace Tasler.Interop.Shell;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("CEF04FDF-FE72-11d2-87A5-00C04F6837CF")]
public partial interface IPersistFolder3 : IPersistFolder2
{
	void InitializeEx(IBindCtx pbc, nint pidlRoot, ref PERSIST_FOLDER_TARGET_INFO pfti);

	void GetFolderTargetInfo(out PERSIST_FOLDER_TARGET_INFO ppfti);
}

[StructLayout(LayoutKind.Sequential)]
public struct PERSIST_FOLDER_TARGET_INFO
{
	/// <summary>pidl for the folder we want to intiailize</summary>
	internal nint _pidlTargetFolder = nint.Zero;
	/// <summary>optional parsing name for the target</summary>
	internal unsafe fixed char _szTargetParsingName[260];
	/// <summary>optional network provider</summary>
	internal unsafe fixed char _szNetworkProvider[260];
	/// <summary>optional FILE_ATTRIBUTES_ flags (-1 if not used)</summary>
	public uint Attributes = 0xFFFFFFFF;
	/// <summary>optional folder index (SHGetFolderPath()) -1 if not used</summary>
	public int ConstantSpecialItem = -1;

	public PERSIST_FOLDER_TARGET_INFO() { }
}
