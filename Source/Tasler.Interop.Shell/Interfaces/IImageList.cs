using System.Runtime.InteropServices;
using Tasler.Interop.Gdi;

namespace Tasler.Interop.Shell.Interfaces;

[ComImport]
[Guid("46EB5926-582E-4017-9FDF-E8998DAA0950")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IImageList
{
	int Add(IntPtr hbmImage, IntPtr hbmMask);

	int ReplaceIcon(int i, SafeGdiIcon hIcon);

	void SetOverlayImage(int iImage, int iOverlay);

	void Replace(int i, IntPtr hbmImage, IntPtr hbmMask);

	int AddMasked(IntPtr hbmImage, COLORREF crMask);

	void Draw(ref IMAGELISTDRAWPARAMS imldp);

	void Remove(int i);

	SafeGdiIconOwned GetIcon(int i, uint flags);

	IMAGEINFO GetImageInfo(int i);

	void Copy(int iDst, [MarshalAs(UnmanagedType.IUnknown)] object punkSrc, int iSrc, uint uFlags);

	[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 5)]
	void Merge(int i1, [MarshalAs(UnmanagedType.IUnknown)] object punk2, int i2, int dx, int dy, ref Guid riid);

	[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)]

	object Clone(ref Guid riid);

	RECT GetImageRect(int i);

	int GetIconSize(out int cx);

	void SetIconSize(int cx, int cy);

	int GetImageCount();

	void SetImageCount(uint uNewCount);

	COLORREF SetBkColor(COLORREF clrBk);

	COLORREF GetBkColor();

	void BeginDrag(int iTrack, int dxHotspot, int dyHotspot);

	void EndDrag();

	void DragEnter(IntPtr IntPtrLock, int x, int y);

	void DragLeave(IntPtr IntPtrLock);

	void DragMove(int x, int y);

	void SetDragCursorImage([MarshalAs(UnmanagedType.IUnknown)] object punk, int iDrag, int dxHotspot, int dyHotspot);

	void DragShowNolock(bool fShow);

	[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)]
	object GetDragImage(out POINT ppt, out POINT pptHotspot, ref Guid riid);

	uint GetItemFlags(int i);

	int GetOverlayImage(int iOverlay);
}
