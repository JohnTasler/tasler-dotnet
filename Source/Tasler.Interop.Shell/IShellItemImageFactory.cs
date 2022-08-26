using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Tasler.Interop.Shell
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("bcc18b79-ba16-442f-80c4-8a59c30c463b")]
    public interface IShellItemImageFactory
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        int GetImage(
            SIZE size,
            SIIGB flags,
            out IntPtr hBitmap);
    }

    [Flags]
    public enum SIIGB
    {
        /// <summary>
        /// Resizes the thumbnail to the specified size.
        /// </summary>
        ResizeToFit = 0x00,

        /// <summary>
        /// Passed by callers if they wish to stretch the returned image themselves (For example, if the caller
        /// passes in 80x80 a 96x96 thumbnail could be returned). This could be used as a performance optimization
        /// if the caller will need to stretch the image themselves anyway. Note that Shells implementation of
        /// <see cref="IShellItemImageFactory"/> performs a GDI stretch blit. If the caller wants a higher quality
        /// image stretch they should pass this flag and do it themselves.
        /// </summary>
        BiggerSizeOk = 0x01,

        /// <summary>
        /// Return the item only if it is in memory. Do not access the disk even if the item is cached. Note that
        /// this only returns an already-cached icon and can fall back to a per-class icon if an item has a
        /// per-instance icon that has not been cached yet. Retrieving a thumbnail, even if it is cached, always
        /// requires the disk to be accessed, so this method should not be called from the user interface (UI)
        /// thread without passing SIIGBF_MEMORYONLY.
        /// </summary>
        MemoryOnly = 0x02,

        /// <summary>
        /// Return only the icon, never the thumbnail.
        /// </summary>
        IconOnly = 0x04,

        /// <summary>
        /// Return only the thumbnail, never the icon. Note that not all items have thumbnails so
        /// <see cref="ThumbnailOnly"/> can fail in these cases.
        /// </summary>
        ThumbnailOnly = 0x08,

        /// <summary>
        /// Allows access to the disk, but only to retrieve a cached item. This returns a cached thumbnail if it
        /// is available. If no cached thumbnail is available, it returns a cached per-instance icon but does not
        /// extract a thumbnail or icon.
        /// </summary>
        InCacheOnly = 0x10
    }






}
