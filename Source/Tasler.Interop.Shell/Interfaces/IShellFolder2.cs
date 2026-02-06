using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Shell;

//[System.Diagnostics.CodeAnalysis.SuppressMessage("ComInterfaceGenerator", "SYSLIB1051:Specified type is not supported by source-generated COM", Justification = "It works")]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("93F2F68C-1D1B-11d3-A30E-00C04F79ABD1")]
public partial interface IShellFolder2 : IShellFolder
{
	/// <summary>
	/// Retrieve the folder's default search identifier.
	/// </summary>
	/// <returns>A Guid representing the folder's default search.</returns>
	Guid GetDefaultSearchGUID();

	/// <summary>
	/// Enumerates extra searches registered for this folder.
	/// </summary>
	/// <returns>An <see cref="IEnumExtraSearch"/> that enumerates the folder's extra searches.</returns>
	IEnumExtraSearch EnumSearches();

	/// <summary>
	/// Gets the default column index for a specified resource set.
	/// </summary>
	/// <param name="dwRes">Resource flag that selects which set of column defaults to query.</param>
	/// <param name="pSort">Receives the index of the default column used for sorting.</param>
	/// <returns>The default column index for the specified resource set.</returns>
	uint GetDefaultColumn(uint dwRes, out uint pSort);

	/// <summary>
	/// Gets the default state flags for the specified column.
	/// </summary>
	/// <param name="iColumn">Zero-based index of the column.</param>
	/// <returns>A <see cref="SHCOLSTATEF"/> value describing the column's default state flags.</returns>
	SHCOLSTATEF GetDefaultColumnState(uint iColumn);

	/// <summary>
	/// Retrieves the extended property value for the item identified by the specified PIDL using the provided property key.
	/// </summary>
	/// <param name="pidl">A pointer to the item's PIDL (item identifier list) that is relative to the folder implementing this interface.</param>
	/// <param name="pscid">The property key that identifies which property to retrieve.</param>
	/// <returns>An IntPtr referencing the retrieved property value for the specified item and property key.</returns>
	nint GetDetailsEx(nint pidl, PropertyKey pscid);

	/// <summary>
	/// Retrieves column details for the specified item or for the folder itself.
	/// </summary>
	/// <param name="pidl">A pointer to the item's ITEMIDLIST that identifies the item; <c>0</c> (NULL) refers to the folder itself.</param>
	/// <param name="iColumn">The zero-based column index whose details are requested.</param>
	/// <returns>A <see cref="SHELLDETAILS"/> structure describing the column (format, average character count, and string information).</returns>
	SHELLDETAILS GetDetailsOf(nint pidl, uint iColumn);

	/// <summary>
	/// Maps a shell folder column index to its corresponding property key (SCID).
	/// </summary>
	/// <param name="iColumn">Zero-based column index.</param>
	/// <returns>The PropertyKey corresponding to the specified column.</returns>
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

