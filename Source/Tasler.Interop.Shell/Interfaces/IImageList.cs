using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Gdi;

namespace Tasler.Interop.Shell.Interfaces;

[Guid("46EB5926-582E-4017-9FDF-E8998DAA0950")]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IImageList
{
	void Add(/*SafeGdiBitmap*/ nint hbmImage, /*SafeGdiBitmap*/ nint hbmMask);

	void ReplaceIcon(int i, /*SafeGdiIcon*/ nint hIcon);

	void SetOverlayImage(int iImage, int iOverlay);

	void Replace(int i, nint hbmImage, nint hbmMask);

	void AddMasked(/*SafeGdiBitmap*/ nint hbmImage, COLORREF crMask);

	void Draw(ref IMAGELISTDRAWPARAMS imldp);

	void Remove(int i);

	nint GetIcon(int i, ImageListDrawFlags flags);  // SafeGdiIconOwned

	IMAGEINFO GetImageInfo(int i);

	void Copy(int iDst, nint punkSrc, int iSrc, ImageListCopyFlags uFlags);

	void Merge(int i1, nint punk2, int i2, int dx, int dy, ref Guid riid, out nint ppv);

	nint Clone(ref Guid riid);

	RECT GetImageRect(int i);

	void GetIconSize(out int cx, out int cy);

	void SetIconSize(int cx, int cy);

	int GetImageCount();

	void SetImageCount(uint uNewCount);

	COLORREF SetBkColor(COLORREF clrBk);

	COLORREF GetBkColor();

	void BeginDrag(int iTrack, int dxHotspot, int dyHotspot);

	void EndDrag();

	void DragEnter(nint nintLock, int x, int y);

	void DragLeave(nint nintLock);

	void DragMove(int x, int y);

	void SetDragCursorImage(nint punk, int iDrag, int dxHotspot, int dyHotspot);

	void DragShowNolock([MarshalAs(UnmanagedType.Bool)] bool fShow);

	nint GetDragImage(out POINT ppt, out POINT pptHotspot, out Guid riid);

	uint GetItemFlags(int i);

	void GetOverlayImage(int iOverlay, out int index);
}
