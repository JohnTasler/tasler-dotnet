using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Shell;

[System.Diagnostics.CodeAnalysis.SuppressMessage("ComInterfaceGenerator", "SYSLIB1051:Specified type is not supported by source-generated COM", Justification = "It works")]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("93F2F68C-1D1B-11d3-A30E-00C04F79ABD1")]
public partial interface IShellFolder2 : IShellFolder
{
	Guid GetDefaultSearchGUID();

	IEnumExtraSearch EnumSearches();

	uint GetDefaultColumn(uint dwRes, out uint pSort);

	SHCOLSTATEF GetDefaultColumnState(uint iColumn);

	nint GetDetailsEx(ChildItemIdList pidl, PropertyKey pscid);

	SHELLDETAILS GetDetailsOf(ChildItemIdList pidl, uint iColumn);

	PropertyKey MapColumnToSCID(uint iColumn);
}

/// <summary>
/// Structure for returning strings from <see cref="IShellFolder2.GetDetailsOf"/>.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SHELLDETAILS
{
	/// <summary>The alignment of the column heading and the subitem text in the column.</summary>
	/// <remarks>
	/// This can be one of the following values:
	/// <see cref="LVCFMT.Left"/>
	/// <see cref="LVCFMT.Right"/>
	/// <see cref="LVCFMT.Center"/>
	/// <see cref="LVCFMT.ColumnHasImages"/>
	/// </remarks>
	public LVCFMT Format;

	/// <summary>The number of average-sized characters in the header.</summary>
	public int CharacterCount;

	/// <summary>String information.</summary>
	public StrRet StringInfo;
}

[Flags]
public enum LVCFMT : uint
{
	/// <summary>Same as HDF_LEFT</summary>
	Left = 0x0000,
	/// <summary>Same as HDF_RIGHT</summary>
	Right = 0x0001,
	/// <summary>Same as HDF_CENTER</summary>
	Center = 0x0002,
	/// <summary>Same as HDF_JUSTIFYMASK</summary>
	JustifyMask = 0x0003,

	/// <summary>Same as HDF_IMAGE</summary>
	Image = 0x0800,
	/// <summary>Same as HDF_BITMAP_ON_RIGHT</summary>
	BitmapOnRight = 0x1000,
	/// <summary>Same as HDF_OWNERDRAW</summary>
	ColumnHasImages = 0x8000,

	/// <summary>Can't resize the column; same as HDF_FIXEDWIDTH</summary>
	FixedWidth = 0x00100,
	/// <summary>If not set, CCM_DPISCALE will govern scaling up fixed width</summary>
	NoDpiScale = 0x40000,
	/// <summary>Width will augment with the row height</summary>
	FixedRatio = 0x80000,

	/// <summary>Move to the top of the next list of columns</summary>
	LineBreak = 0x100000,
	/// <summary>Fill the remainder of the tile area. Might have a title.</summary>
	Fill = 0x200000,
	/// <summary>This sub-item can be wrapped.</summary>
	Wrap = 0x400000,
	/// <summary>This sub-item doesn't have an title.</summary>
	NoTitle = 0x800000,

	TilePlacementMask = (LVCFMT.LineBreak | LVCFMT.Fill),

	/// <summary>Column is a split button; same as HDF_SPLITBUTTON</summary>
	SplitButton = 0x1000000,
}

