using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Shell.Interfaces;

[Guid("192B9D83-50FC-457B-90A0-2B82A8B5DAE1")]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IImageList2 : IImageList
{
	void Resize(int cxNewIconSize, int cyNewIconSize);

	void GetOriginalSize(int iImage, uint dwFlags, out int pcx, out int pcy);

	void SetOriginalSize(int iImage, int cx, int cy);

	void SetCallback(nint punk);

	nint GetCallback(ref Guid riid);

	void ForceImagePresent(int iImage, ImageListForceImagePresent dwFlags);

	void DiscardImages(int iFirstImage, int iLastImage, uint dwFlags);

	void PreloadImages(ref IMAGELISTDRAWPARAMS pimldp);

	void GetStatistics(ref IMAGELISTSTATS pils);

	/// <summary>
	///
	/// </summary>
	/// <param name="cx"></param>
	/// <param name="cy"></param>
	/// <param name="flags"></param>
	/// <param name="cInitial"></param>
	/// <param name="cGrow"></param>
	void Initialize(int cx, int cy, ImageListCreationFlags flags, int cInitial, int cGrow);

	void Replace2(int index, /*SafeGdiBitmap*/ nint hbmImage, /*SafeGdiBitmap*/ nint hbmMask, nint pUnknown, ImageListReplaceFlags flags);

	void ReplaceFromImageList(int i, IImageList pil, int iSrc, nint punk, uint dwFlags = 0);
}
