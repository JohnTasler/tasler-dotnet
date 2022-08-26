using System;

namespace Tasler.Interop.Shell
{
    public static partial class PropertyKeys
    {
        public static class Image
        {
            /// <summary>
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Image.BitDepth -- PKEY_BitDepth</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(PSGUID_IMAGESUMMARYINFORMATION) 6444048F-4C8B-11D1-8B70-080036B11A03, 7 (PIDISI_BITDEPTH)</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey BitDepth { get { return new PropertyKey(0x6444048F, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 7); } }

            /// <summary>
            /// PropertyTagExifColorSpace</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Image.ColorSpace -- PKEY_ColorSpace</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 40961</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey ColorSpace { get { return new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 40961); } }

            /// <summary>Possible discrete values for PKEY_ColorSpace.</summary>
            public enum ColorSpaceValues : ushort
            {
                SRGB = 1,
                Uncalibrated = 0xFFFF,
            }

            /// <summary>
            /// Calculated from PKEY_CompressedBitsPerPixelNumerator and PKEY_CompressedBitsPerPixelDenominator.</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Image.CompressedBitsPerPixel -- PKEY_CompressedBitsPerPixel</description></item>
            ///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
            ///   <item><term><b>Format ID:</b></term><description>364B6FA9-37AB-482A-BE2B-AE02F60D4318, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey CompressedBitsPerPixel { get { return new PropertyKey(0x364B6FA9, 0x37AB, 0x482A, 0xBE, 0x2B, 0xAE, 0x02, 0xF6, 0x0D, 0x43, 0x18, 100); } }

            /// <summary>
            /// Denominator of PKEY_CompressedBitsPerPixel.</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Image.CompressedBitsPerPixelDenominator -- PKEY_CompressedBitsPerPixelDenominator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>1F8844E1-24AD-4508-9DFD-5326A415CE02, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey CompressedBitsPerPixelDenominator { get { return new PropertyKey(0x1F8844E1, 0x24AD, 0x4508, 0x9D, 0xFD, 0x53, 0x26, 0xA4, 0x15, 0xCE, 0x02, 100); } }

            /// <summary>
            /// Numerator of PKEY_CompressedBitsPerPixel.</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Image.CompressedBitsPerPixelNumerator -- PKEY_CompressedBitsPerPixelNumerator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>D21A7148-D32C-4624-8900-277210F79C0F, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey CompressedBitsPerPixelNumerator { get { return new PropertyKey(0xD21A7148, 0xD32C, 0x4624, 0x89, 0x00, 0x27, 0x72, 0x10, 0xF7, 0x9C, 0x0F, 100); } }

            /// <summary>
            /// Indicates the image compression level.  PropertyTagCompression.</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Image.Compression -- PKEY_Compression</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 259</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey Compression { get { return new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 259); } }

            /// <summary>Possible discrete values for PKEY_Compression.</summary>
            public enum CompressionLevel : ushort
            {
                Uncompressed = 1,
                CcittT3 = 2,
                CcittT4 = 3,
                CcittT6 = 4,
                Lzw = 5,
                Jpeg = 6,
                Packbits = 32773,
            }

            /// <summary>
            /// This is the user-friendly form of System.Image.Compression.
            /// Not intended to be parsed programmatically.</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Image.CompressionText -- PKEY_CompressionText</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>3F08E66F-2F44-4BB9-A682-AC35D2562322, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey CompressionText { get { return new PropertyKey(0x3F08E66F, 0x2F44, 0x4BB9, 0xA6, 0x82, 0xAC, 0x35, 0xD2, 0x56, 0x23, 0x22, 100); } }

            /// <summary>
            /// Indicates the dimensions of the image.</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Image.Dimensions -- PKEY_Dimensions</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(PSGUID_IMAGESUMMARYINFORMATION) 6444048F-4C8B-11D1-8B70-080036B11A03, 13 (PIDISI_DIMENSIONS)</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey Dimensions { get { return new PropertyKey(0x6444048F, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 13); } }

            /// <summary>
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Image.HorizontalResolution -- PKEY_HorizontalResolution</description></item>
            ///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(PSGUID_IMAGESUMMARYINFORMATION) 6444048F-4C8B-11D1-8B70-080036B11A03, 5 (PIDISI_RESOLUTIONX)</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey HorizontalResolution { get { return new PropertyKey(0x6444048F, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 5); } }

            /// <summary>
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Image.HorizontalSize -- PKEY_HorizontalSize</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(PSGUID_IMAGESUMMARYINFORMATION) 6444048F-4C8B-11D1-8B70-080036B11A03, 3 (PIDISI_CX)</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey HorizontalSize { get { return new PropertyKey(0x6444048F, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 3); } }

            /// <summary></summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Image.ImageID -- PKEY_ImageID</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>10DABE05-32AA-4C29-BF1A-63E2D220587F, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey ImageID { get { return new PropertyKey(0x10DABE05, 0x32AA, 0x4C29, 0xBF, 0x1A, 0x63, 0xE2, 0xD2, 0x20, 0x58, 0x7F, 100); } }

            /// <summary></summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Image.ResolutionUnit -- PKEY_ResolutionUnit</description></item>
            ///   <item><term><b>Type:     </b></term><description>Int16 -- VT_I2</description></item>
            ///   <item><term><b>Format ID:</b></term><description>19B51FA6-1F92-4A5C-AB48-7DF0ABD67444, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey ResolutionUnit { get { return new PropertyKey(0x19B51FA6, 0x1F92, 0x4A5C, 0xAB, 0x48, 0x7D, 0xF0, 0xAB, 0xD6, 0x74, 0x44, 100); } }

            /// <summary>
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Image.VerticalResolution -- PKEY_VerticalResolution</description></item>
            ///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(PSGUID_IMAGESUMMARYINFORMATION) 6444048F-4C8B-11D1-8B70-080036B11A03, 6 (PIDISI_RESOLUTIONY)</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey VerticalResolution { get { return new PropertyKey(0x6444048F, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 6); } }

            /// <summary>
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Image.VerticalSize -- PKEY_VerticalSize</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(PSGUID_IMAGESUMMARYINFORMATION) 6444048F-4C8B-11D1-8B70-080036B11A03, 4 (PIDISI_CY)</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey VerticalSize { get { return new PropertyKey(0x6444048F, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 4); } }
        }
    }
}