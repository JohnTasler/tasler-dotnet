using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Tasler.Interop.Shell
{
    [ComImport]
    [Guid("BB2E617C-0920-11d1-9A0B-00C04FC2D6C1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IExtractImage
    {
        [PreserveSig]
        int GetLocation(
            [In][Out][MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 1)]
            StringBuilder pszPathBuffer,
            int cch,
            IntPtr pdwPriority,
            [In]
            ref Size prgSize,
            uint dwRecClrDepth,
            ref IEIFlags pdwFlags);

        [PreserveSig]
        int Extract(
            out IntPtr phBmpThumbnail);
    }

    [Flags]
    public enum IEIFlags : uint
    {
        /// <summary>(deprecated) ask the extractor if it supports ASYNC extract (free threaded)</summary>
        Async = 0x0001,
        /// <summary>returned from the extractor if it does NOT cache the thumbnail</summary>
        Cache = 0x0002,
        /// <summary>passed to the extractor to beg it to render to the aspect ratio of the supplied rect</summary>
        Aspect = 0x0004,
        /// <summary>if the extractor shouldn't hit the net to get any content neede for the rendering</summary>
        Offline = 0x0008,
        /// <summary>does the image have a gleam ? this will be returned if it does</summary>
        Gleam = 0x0010,
        /// <summary>render as if for the screen  (this is exlusive with IEIFLAG_ASPECT )</summary>
        Screen = 0x0020,
        /// <summary>render to the approx size passed, but crop if neccessary</summary>
        OrigSize = 0x0040,
        /// <summary>returned from the extractor if it does NOT want an icon stamp on the thumbnail</summary>
        NoStamp = 0x0080,
        /// <summary>returned from the extractor if it does NOT want an a border around the thumbnail</summary>
        NoBorder = 0x0100,
        /// <summary>passed to the Extract method to indicate that a slower, higher quality image is desired, re-compute the thumbnail</summary>
        Quality = 0x0200,
        /// <summary>returned from the extractor if it would like to have Refresh Thumbnail available</summary>
        Refresh = 0x0400,
    }
}
