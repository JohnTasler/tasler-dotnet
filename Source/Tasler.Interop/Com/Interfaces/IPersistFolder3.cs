using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com;

namespace Tasler.Interop.Shell;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("CEF04FDF-FE72-11d2-87A5-00C04F6837CF")]
public partial interface IPersistFolder3 : IPersistFolder2
{
	/// <summary>
	/// Initializes the folder object using the provided binding context, root PIDL, and target information.
	/// </summary>
	/// <param name="pbc">The bind context used during initialization.</param>
	/// <param name="pidlRoot">A pointer to the root ITEMIDLIST (PIDL) for the folder; pass zero to indicate no root.</param>
	/// <param name="pfti">A reference to a PERSIST_FOLDER_TARGET_INFO structure that supplies target folder information.</param>
	void InitializeEx(IBindCtx pbc, nint pidlRoot, ref PERSIST_FOLDER_TARGET_INFO pfti);

	/// <summary>
	/// Retrieves the current PERSIST_FOLDER_TARGET_INFO describing the folder's target.
	/// </summary>
	/// <param name="ppfti">When this method returns, contains the target information. Fields may be set to their sentinel values (Attributes = 0xFFFFFFFF and ConstantSpecialItem = -1) to indicate "not used".</param>
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

	/// <summary>
	/// Initializes a new PERSIST_FOLDER_TARGET_INFO with default values.
	/// </summary>
	/// <remarks>
	/// Public fields default to <c>Attributes = 0xFFFFFFFF</c> and <c>ConstantSpecialItem = -1</c>. Internal storage (PIDL and fixed character buffers) is initialized to zero/empty.
	/// </remarks>
	public PERSIST_FOLDER_TARGET_INFO() { }
}
