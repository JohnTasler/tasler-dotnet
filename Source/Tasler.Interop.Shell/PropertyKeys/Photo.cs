
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Photo
	{
		/// <summary>
		/// PropertyTagExifAperture.  Calculated from PKEY_ApertureNumerator and PKEY_ApertureDenominator</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.Aperture -- PKEY_Aperture</description></item>
		///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 37378</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Aperture => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 37378);

		/// <summary>
		/// Denominator of PKEY_Aperture</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ApertureDenominator -- PKEY_ApertureDenominator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>E1A9A38B-6685-46BD-875E-570DC7AD7320, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ApertureDenominator => new PropertyKey(0xE1A9A38B, 0x6685, 0x46BD, 0x87, 0x5E, 0x57, 0x0D, 0xC7, 0xAD, 0x73, 0x20, 100);

		/// <summary>
		/// Numerator of PKEY_Aperture</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ApertureNumerator -- PKEY_ApertureNumerator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>0337ECEC-39FB-4581-A0BD-4C4CC51E9914, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ApertureNumerator => new PropertyKey(0x0337ECEC, 0x39FB, 0x4581, 0xA0, 0xBD, 0x4C, 0x4C, 0xC5, 0x1E, 0x99, 0x14, 100);

		/// <summary>
		/// This is the brightness of the photo.
		/// Calculated from PKEY_BrightnessNumerator and PKEY_BrightnessDenominator.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.Brightness -- PKEY_Brightness</description></item>
		///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
		///   <item><term><b>Format ID:</b></term><description>1A701BF6-478C-4361-83AB-3701BB053C58, 100 (PropertyTagExifBrightness)</description></item>
		/// </list>
		/// The units are "APEX", normally in the range of -99.99 to 99.99. If the numerator of 
		/// the recorded value is FFFFFFFF.H, "Unknown" should be indicated.
		/// </remarks>
		public static PropertyKey Brightness => new PropertyKey(0x1A701BF6, 0x478C, 0x4361, 0x83, 0xAB, 0x37, 0x01, 0xBB, 0x05, 0x3C, 0x58, 100);

		/// <summary>
		/// Denominator of PKEY_Brightness</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.BrightnessDenominator -- PKEY_BrightnessDenominator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>6EBE6946-2321-440A-90F0-C043EFD32476, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BrightnessDenominator => new PropertyKey(0x6EBE6946, 0x2321, 0x440A, 0x90, 0xF0, 0xC0, 0x43, 0xEF, 0xD3, 0x24, 0x76, 100);

		/// <summary>
		/// Numerator of PKEY_Brightness</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.BrightnessNumerator -- PKEY_BrightnessNumerator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>9E7D118F-B314-45A0-8CFB-D654B917C9E9, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BrightnessNumerator => new PropertyKey(0x9E7D118F, 0xB314, 0x45A0, 0x8C, 0xFB, 0xD6, 0x54, 0xB9, 0x17, 0xC9, 0xE9, 100);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.CameraManufacturer -- PKEY_CameraManufacturer</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 271 (PropertyTagEquipMake)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey CameraManufacturer => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 271);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.CameraModel -- PKEY_CameraModel</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 272 (PropertyTagEquipModel)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey CameraModel => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 272);

		/// <summary>
		/// Serial number of camera that produced this photo</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.CameraSerialNumber -- PKEY_CameraSerialNumber</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 273</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey CameraSerialNumber => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 273);

		/// <summary>
		/// This indicates the direction of contrast processing applied by the camera when the image was shot.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.Contrast -- PKEY_Contrast</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>2A785BA9-8D23-4DED-82E6-60A350C86A10, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Contrast => new PropertyKey(0x2A785BA9, 0x8D23, 0x4DED, 0x82, 0xE6, 0x60, 0xA3, 0x50, 0xC8, 0x6A, 0x10, 100);

		/// <summary>Possible discrete values for PKEY_Contrast.</summary>
		public enum ContrastValues : uint
		{
			Normal = 0,
			Soft = 1,
			Hard = 2,
		}

		/// <summary>
		/// This is the user-friendly form of System.Photo.Contrast.
		/// Not intended to be parsed programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ContrastText -- PKEY_ContrastText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>59DDE9F2-5253-40EA-9A8B-479E96C6249A, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ContrastText => new PropertyKey(0x59DDE9F2, 0x5253, 0x40EA, 0x9A, 0x8B, 0x47, 0x9E, 0x96, 0xC6, 0x24, 0x9A, 100);

		/// <summary>
		/// PropertyTagExifDTOrig</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.DateTaken -- PKEY_DateTaken</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 36867</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DateTaken => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 36867);

		/// <summary>
		/// PropertyTagExifDigitalZoom.  Calculated from PKEY_DigitalZoomNumerator and PKEY_DigitalZoomDenominator</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.DigitalZoom -- PKEY_DigitalZoom</description></item>
		///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
		///   <item><term><b>Format ID:</b></term><description>F85BF840-A925-4BC2-B0C4-8E36B598679E, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DigitalZoom => new PropertyKey(0xF85BF840, 0xA925, 0x4BC2, 0xB0, 0xC4, 0x8E, 0x36, 0xB5, 0x98, 0x67, 0x9E, 100);

		/// <summary>
		/// Denominator of PKEY_DigitalZoom</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.DigitalZoomDenominator -- PKEY_DigitalZoomDenominator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>745BAF0E-E5C1-4CFB-8A1B-D031A0A52393, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DigitalZoomDenominator => new PropertyKey(0x745BAF0E, 0xE5C1, 0x4CFB, 0x8A, 0x1B, 0xD0, 0x31, 0xA0, 0xA5, 0x23, 0x93, 100);

		/// <summary>
		/// Numerator of PKEY_DigitalZoom</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.DigitalZoomNumerator -- PKEY_DigitalZoomNumerator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>16CBB924-6500-473B-A5BE-F1599BCBE413, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DigitalZoomNumerator => new PropertyKey(0x16CBB924, 0x6500, 0x473B, 0xA5, 0xBE, 0xF1, 0x59, 0x9B, 0xCB, 0xE4, 0x13, 100);

		/// <summary>
		/// The event at which the photo was taken</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.Event -- PKEY_Event</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 18248</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Event => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 18248);

		/// <summary>
		/// The EXIF version.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.EXIFVersion -- PKEY_EXIFVersion</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>D35F743A-EB2E-47F2-A286-844132CB1427, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey EXIFVersion => new PropertyKey(0xD35F743A, 0xEB2E, 0x47F2, 0xA2, 0x86, 0x84, 0x41, 0x32, 0xCB, 0x14, 0x27, 100);

		/// <summary>
		/// PropertyTagExifExposureBias.  Calculated from PKEY_ExposureBiasNumerator and PKEY_ExposureBiasDenominator</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ExposureBias -- PKEY_ExposureBias</description></item>
		///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 37380</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ExposureBias => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 37380);

		/// <summary>
		/// Denominator of PKEY_ExposureBias</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ExposureBiasDenominator -- PKEY_ExposureBiasDenominator</description></item>
		///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
		///   <item><term><b>Format ID:</b></term><description>AB205E50-04B7-461C-A18C-2F233836E627, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ExposureBiasDenominator => new PropertyKey(0xAB205E50, 0x04B7, 0x461C, 0xA1, 0x8C, 0x2F, 0x23, 0x38, 0x36, 0xE6, 0x27, 100);

		/// <summary>
		/// Numerator of PKEY_ExposureBias</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ExposureBiasNumerator -- PKEY_ExposureBiasNumerator</description></item>
		///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
		///   <item><term><b>Format ID:</b></term><description>738BF284-1D87-420B-92CF-5834BF6EF9ED, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ExposureBiasNumerator => new PropertyKey(0x738BF284, 0x1D87, 0x420B, 0x92, 0xCF, 0x58, 0x34, 0xBF, 0x6E, 0xF9, 0xED, 100);

		/// <summary>
		/// PropertyTagExifExposureIndex.  Calculated from PKEY_ExposureIndexNumerator and PKEY_ExposureIndexDenominator</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ExposureIndex -- PKEY_ExposureIndex</description></item>
		///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
		///   <item><term><b>Format ID:</b></term><description>967B5AF8-995A-46ED-9E11-35B3C5B9782D, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ExposureIndex => new PropertyKey(0x967B5AF8, 0x995A, 0x46ED, 0x9E, 0x11, 0x35, 0xB3, 0xC5, 0xB9, 0x78, 0x2D, 100);

		/// <summary>
		/// Denominator of PKEY_ExposureIndex</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ExposureIndexDenominator -- PKEY_ExposureIndexDenominator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>93112F89-C28B-492F-8A9D-4BE2062CEE8A, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ExposureIndexDenominator => new PropertyKey(0x93112F89, 0xC28B, 0x492F, 0x8A, 0x9D, 0x4B, 0xE2, 0x06, 0x2C, 0xEE, 0x8A, 100);

		/// <summary>
		/// Numerator of PKEY_ExposureIndex</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ExposureIndexNumerator -- PKEY_ExposureIndexNumerator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>CDEDCF30-8919-44DF-8F4C-4EB2FFDB8D89, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ExposureIndexNumerator => new PropertyKey(0xCDEDCF30, 0x8919, 0x44DF, 0x8F, 0x4C, 0x4E, 0xB2, 0xFF, 0xDB, 0x8D, 0x89, 100);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ExposureProgram -- PKEY_ExposureProgram</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 34850 (PropertyTagExifExposureProg)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ExposureProgram => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 34850);

		/// <summary>Possible discrete values for PKEY_ExposureProgram.</summary>
		public enum ExposureProgramValues : uint
		{
			Unknown = 0,
			Manual = 1,
			Normal = 2,
			Aperture = 3,
			Shutter = 4,
			Creative = 5,
			Action = 6,
			Portrait = 7,
			Landscape = 8,
		}

		/// <summary>
		/// This is the user-friendly form of System.Photo.ExposureProgram.
		/// Not intended to be parsed programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ExposureProgramText -- PKEY_ExposureProgramText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>FEC690B7-5F30-4646-AE47-4CAAFBA884A3, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ExposureProgramText => new PropertyKey(0xFEC690B7, 0x5F30, 0x4646, 0xAE, 0x47, 0x4C, 0xAA, 0xFB, 0xA8, 0x84, 0xA3, 100);

		/// <summary>
		/// PropertyTagExifExposureTime.  Calculated from  PKEY_ExposureTimeNumerator and PKEY_ExposureTimeDenominator</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ExposureTime -- PKEY_ExposureTime</description></item>
		///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 33434</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ExposureTime => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 33434);

		/// <summary>
		/// Denominator of PKEY_ExposureTime</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ExposureTimeDenominator -- PKEY_ExposureTimeDenominator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>55E98597-AD16-42E0-B624-21599A199838, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ExposureTimeDenominator => new PropertyKey(0x55E98597, 0xAD16, 0x42E0, 0xB6, 0x24, 0x21, 0x59, 0x9A, 0x19, 0x98, 0x38, 100);

		/// <summary>
		/// Numerator of PKEY_ExposureTime</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ExposureTimeNumerator -- PKEY_ExposureTimeNumerator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>257E44E2-9031-4323-AC38-85C552871B2E, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ExposureTimeNumerator => new PropertyKey(0x257E44E2, 0x9031, 0x4323, 0xAC, 0x38, 0x85, 0xC5, 0x52, 0x87, 0x1B, 0x2E, 100);

		/// <summary>
		/// PropertyTagExifFlash</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.Flash -- PKEY_Flash</description></item>
		///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 37385</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Flash => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 37385);

		/// <summary>Possible discrete values for PKEY_Flash.</summary>
		public enum FlashValues : byte
		{
			None = 0,
			Flash = 1,
			WithoutStrobe = 5,
			WithStrobe = 7,
		}

		/// <summary>
		/// PropertyTagExifFlashEnergy.  Calculated from PKEY_FlashEnergyNumerator and PKEY_FlashEnergyDenominator</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FlashEnergy -- PKEY_FlashEnergy</description></item>
		///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 41483</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FlashEnergy => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 41483);

		/// <summary>
		/// Denominator of PKEY_FlashEnergy</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FlashEnergyDenominator -- PKEY_FlashEnergyDenominator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>D7B61C70-6323-49CD-A5FC-C84277162C97, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FlashEnergyDenominator => new PropertyKey(0xD7B61C70, 0x6323, 0x49CD, 0xA5, 0xFC, 0xC8, 0x42, 0x77, 0x16, 0x2C, 0x97, 100);

		/// <summary>
		/// Numerator of PKEY_FlashEnergy</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FlashEnergyNumerator -- PKEY_FlashEnergyNumerator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>FCAD3D3D-0858-400F-AAA3-2F66CCE2A6BC, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FlashEnergyNumerator => new PropertyKey(0xFCAD3D3D, 0x0858, 0x400F, 0xAA, 0xA3, 0x2F, 0x66, 0xCC, 0xE2, 0xA6, 0xBC, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FlashManufacturer -- PKEY_FlashManufacturer</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>AABAF6C9-E0C5-4719-8585-57B103E584FE, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FlashManufacturer => new PropertyKey(0xAABAF6C9, 0xE0C5, 0x4719, 0x85, 0x85, 0x57, 0xB1, 0x03, 0xE5, 0x84, 0xFE, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FlashModel -- PKEY_FlashModel</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>FE83BB35-4D1A-42E2-916B-06F3E1AF719E, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FlashModel => new PropertyKey(0xFE83BB35, 0x4D1A, 0x42E2, 0x91, 0x6B, 0x06, 0xF3, 0xE1, 0xAF, 0x71, 0x9E, 100);

		/// <summary>
		/// This is the user-friendly form of System.Photo.Flash.
		/// Not intended to be parsed programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FlashText -- PKEY_FlashText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>6B8B68F6-200B-47EA-8D25-D8050F57339F, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FlashText => new PropertyKey(0x6B8B68F6, 0x200B, 0x47EA, 0x8D, 0x25, 0xD8, 0x05, 0x0F, 0x57, 0x33, 0x9F, 100);

		/// <summary>
		/// PropertyTagExifFNumber.  Calculated from PKEY_FNumberNumerator and PKEY_FNumberDenominator</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FNumber -- PKEY_FNumber</description></item>
		///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 33437</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FNumber => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 33437);

		/// <summary>
		/// Denominator of PKEY_FNumber</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FNumberDenominator -- PKEY_FNumberDenominator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>E92A2496-223B-4463-A4E3-30EABBA79D80, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FNumberDenominator => new PropertyKey(0xE92A2496, 0x223B, 0x4463, 0xA4, 0xE3, 0x30, 0xEA, 0xBB, 0xA7, 0x9D, 0x80, 100);

		/// <summary>
		/// Numerator of PKEY_FNumber</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FNumberNumerator -- PKEY_FNumberNumerator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>1B97738A-FDFC-462F-9D93-1957E08BE90C, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FNumberNumerator => new PropertyKey(0x1B97738A, 0xFDFC, 0x462F, 0x9D, 0x93, 0x19, 0x57, 0xE0, 0x8B, 0xE9, 0x0C, 100);

		/// <summary>
		/// PropertyTagExifFocalLength.  Calculated from PKEY_FocalLengthNumerator and PKEY_FocalLengthDenominator</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FocalLength -- PKEY_FocalLength</description></item>
		///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 37386</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FocalLength => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 37386);

		/// <summary>
		/// Denominator of PKEY_FocalLength</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FocalLengthDenominator -- PKEY_FocalLengthDenominator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>305BC615-DCA1-44A5-9FD4-10C0BA79412E, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FocalLengthDenominator => new PropertyKey(0x305BC615, 0xDCA1, 0x44A5, 0x9F, 0xD4, 0x10, 0xC0, 0xBA, 0x79, 0x41, 0x2E, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FocalLengthInFilm -- PKEY_FocalLengthInFilm</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
		///   <item><term><b>Format ID:</b></term><description>A0E74609-B84D-4F49-B860-462BD9971F98, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FocalLengthInFilm => new PropertyKey(0xA0E74609, 0xB84D, 0x4F49, 0xB8, 0x60, 0x46, 0x2B, 0xD9, 0x97, 0x1F, 0x98, 100);

		/// <summary>
		/// Numerator of PKEY_FocalLength</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FocalLengthNumerator -- PKEY_FocalLengthNumerator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>776B6B3B-1E3D-4B0C-9A0E-8FBAF2A8492A, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FocalLengthNumerator => new PropertyKey(0x776B6B3B, 0x1E3D, 0x4B0C, 0x9A, 0x0E, 0x8F, 0xBA, 0xF2, 0xA8, 0x49, 0x2A, 100);

		/// <summary>
		/// PropertyTagExifFocalXRes.
		/// Calculated from PKEY_FocalPlaneXResolutionNumerator and PKEY_FocalPlaneXResolutionDenominator.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FocalPlaneXResolution -- PKEY_FocalPlaneXResolution</description></item>
		///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
		///   <item><term><b>Format ID:</b></term><description>CFC08D97-C6F7-4484-89DD-EBEF4356FE76, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FocalPlaneXResolution => new PropertyKey(0xCFC08D97, 0xC6F7, 0x4484, 0x89, 0xDD, 0xEB, 0xEF, 0x43, 0x56, 0xFE, 0x76, 100);

		/// <summary>
		/// Denominator of PKEY_FocalPlaneXResolution</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FocalPlaneXResolutionDenominator -- PKEY_FocalPlaneXResolutionDenominator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>0933F3F5-4786-4F46-A8E8-D64DD37FA521, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FocalPlaneXResolutionDenominator => new PropertyKey(0x0933F3F5, 0x4786, 0x4F46, 0xA8, 0xE8, 0xD6, 0x4D, 0xD3, 0x7F, 0xA5, 0x21, 100);

		/// <summary>
		/// Numerator of PKEY_FocalPlaneXResolution</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FocalPlaneXResolutionNumerator -- PKEY_FocalPlaneXResolutionNumerator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>DCCB10AF-B4E2-4B88-95F9-031B4D5AB490, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FocalPlaneXResolutionNumerator => new PropertyKey(0xDCCB10AF, 0xB4E2, 0x4B88, 0x95, 0xF9, 0x03, 0x1B, 0x4D, 0x5A, 0xB4, 0x90, 100);

		/// <summary>
		/// PropertyTagExifFocalYRes.
		/// Calculated from PKEY_FocalPlaneYResolutionNumerator and PKEY_FocalPlaneYResolutionDenominator.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FocalPlaneYResolution -- PKEY_FocalPlaneYResolution</description></item>
		///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
		///   <item><term><b>Format ID:</b></term><description>4FFFE4D0-914F-4AC4-8D6F-C9C61DE169B1, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FocalPlaneYResolution => new PropertyKey(0x4FFFE4D0, 0x914F, 0x4AC4, 0x8D, 0x6F, 0xC9, 0xC6, 0x1D, 0xE1, 0x69, 0xB1, 100);

		/// <summary>
		/// Denominator of PKEY_FocalPlaneYResolution</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FocalPlaneYResolutionDenominator -- PKEY_FocalPlaneYResolutionDenominator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>1D6179A6-A876-4031-B013-3347B2B64DC8, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FocalPlaneYResolutionDenominator => new PropertyKey(0x1D6179A6, 0xA876, 0x4031, 0xB0, 0x13, 0x33, 0x47, 0xB2, 0xB6, 0x4D, 0xC8, 100);

		/// <summary>
		/// Numerator of PKEY_FocalPlaneYResolution</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.FocalPlaneYResolutionNumerator -- PKEY_FocalPlaneYResolutionNumerator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>A2E541C5-4440-4BA8-867E-75CFC06828CD, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FocalPlaneYResolutionNumerator => new PropertyKey(0xA2E541C5, 0x4440, 0x4BA8, 0x86, 0x7E, 0x75, 0xCF, 0xC0, 0x68, 0x28, 0xCD, 100);

		/// <summary>
		/// This indicates the degree of overall image gain adjustment.
		/// Calculated from PKEY_GainControlNumerator and PKEY_GainControlDenominator.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.GainControl -- PKEY_GainControl</description></item>
		///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
		///   <item><term><b>Format ID:</b></term><description>FA304789-00C7-4D80-904A-1E4DCC7265AA, 100 (PropertyTagExifGainControl)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey GainControl => new PropertyKey(0xFA304789, 0x00C7, 0x4D80, 0x90, 0x4A, 0x1E, 0x4D, 0xCC, 0x72, 0x65, 0xAA, 100);

		/// <summary>Possible discrete values for PKEY_GainControl.</summary>
		public static class GainControlValues
		{
			public const double None = 0.0;
			public const double LowGainUp = 1.0;
			public const double HighGainUp = 2.0;
			public const double LowGainDown = 3.0;
			public const double HighGainDown = 4.0;
		}

		/// <summary>
		/// Denominator of PKEY_GainControl</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.GainControlDenominator -- PKEY_GainControlDenominator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>42864DFD-9DA4-4F77-BDED-4AAD7B256735, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey GainControlDenominator => new PropertyKey(0x42864DFD, 0x9DA4, 0x4F77, 0xBD, 0xED, 0x4A, 0xAD, 0x7B, 0x25, 0x67, 0x35, 100);

		/// <summary>
		/// Numerator of PKEY_GainControl</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.GainControlNumerator -- PKEY_GainControlNumerator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>8E8ECF7C-B7B8-4EB8-A63F-0EE715C96F9E, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey GainControlNumerator => new PropertyKey(0x8E8ECF7C, 0xB7B8, 0x4EB8, 0xA6, 0x3F, 0x0E, 0xE7, 0x15, 0xC9, 0x6F, 0x9E, 100);

		/// <summary>
		/// This is the user-friendly form of System.Photo.GainControl.
		/// Not intended to be parsed programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.GainControlText -- PKEY_GainControlText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>C06238B2-0BF9-4279-A723-25856715CB9D, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey GainControlText => new PropertyKey(0xC06238B2, 0x0BF9, 0x4279, 0xA7, 0x23, 0x25, 0x85, 0x67, 0x15, 0xCB, 0x9D, 100);

		/// <summary>
		/// PropertyTagExifISOSpeed</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ISOSpeed -- PKEY_ISOSpeed</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 34855</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ISOSpeed => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 34855);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.LensManufacturer -- PKEY_LensManufacturer</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>E6DDCAF7-29C5-4F0A-9A68-D19412EC7090, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey LensManufacturer => new PropertyKey(0xE6DDCAF7, 0x29C5, 0x4F0A, 0x9A, 0x68, 0xD1, 0x94, 0x12, 0xEC, 0x70, 0x90, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.LensModel -- PKEY_LensModel</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>E1277516-2B5F-4869-89B1-2E585BD38B7A, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey LensModel => new PropertyKey(0xE1277516, 0x2B5F, 0x4869, 0x89, 0xB1, 0x2E, 0x58, 0x5B, 0xD3, 0x8B, 0x7A, 100);

		/// <summary>
		/// PropertyTagExifLightSource</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.LightSource -- PKEY_LightSource</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 37384</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey LightSource => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 37384);

		/// <summary>Possible discrete values for PKEY_LightSource.</summary>
		public enum LightSourceValues : uint
		{
			Unknown = 0,
			Daylight = 1,
			Fluorescent = 2,
			Tungsten = 3,
			StandardA = 17,
			StandardB = 18,
			StandardC = 19,
			D55 = 20,
			D65 = 21,
			D75 = 22,
		}

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.MakerNote -- PKEY_MakerNote</description></item>
		///   <item><term><b>Type:     </b></term><description>Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</description></item>
		///   <item><term><b>Format ID:</b></term><description>FA303353-B659-4052-85E9-BCAC79549B84, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey MakerNote => new PropertyKey(0xFA303353, 0xB659, 0x4052, 0x85, 0xE9, 0xBC, 0xAC, 0x79, 0x54, 0x9B, 0x84, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.MakerNoteOffset -- PKEY_MakerNoteOffset</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
		///   <item><term><b>Format ID:</b></term><description>813F4124-34E6-4D17-AB3E-6B1F3C2247A1, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey MakerNoteOffset => new PropertyKey(0x813F4124, 0x34E6, 0x4D17, 0xAB, 0x3E, 0x6B, 0x1F, 0x3C, 0x22, 0x47, 0xA1, 100);

		/// <summary>
		/// Calculated from PKEY_MaxApertureNumerator and PKEY_MaxApertureDenominator</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.MaxAperture -- PKEY_MaxAperture</description></item>
		///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
		///   <item><term><b>Format ID:</b></term><description>08F6D7C2-E3F2-44FC-AF1E-5AA5C81A2D3E, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey MaxAperture => new PropertyKey(0x08F6D7C2, 0xE3F2, 0x44FC, 0xAF, 0x1E, 0x5A, 0xA5, 0xC8, 0x1A, 0x2D, 0x3E, 100);

		/// <summary>
		/// Denominator of PKEY_MaxAperture</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.MaxApertureDenominator -- PKEY_MaxApertureDenominator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>C77724D4-601F-46C5-9B89-C53F93BCEB77, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey MaxApertureDenominator => new PropertyKey(0xC77724D4, 0x601F, 0x46C5, 0x9B, 0x89, 0xC5, 0x3F, 0x93, 0xBC, 0xEB, 0x77, 100);

		/// <summary>
		/// Numerator of PKEY_MaxAperture</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.MaxApertureNumerator -- PKEY_MaxApertureNumerator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>C107E191-A459-44C5-9AE6-B952AD4B906D, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey MaxApertureNumerator => new PropertyKey(0xC107E191, 0xA459, 0x44C5, 0x9A, 0xE6, 0xB9, 0x52, 0xAD, 0x4B, 0x90, 0x6D, 100);

		/// <summary>
		/// PropertyTagExifMeteringMode</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.MeteringMode -- PKEY_MeteringMode</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 37383</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey MeteringMode => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 37383);

		/// <summary>Possible discrete values for PKEY_MeteringMode.</summary>
		public enum MeteringModeValues : ushort
		{
			Unknown = 0,
			Average = 1,
			Center = 2,
			Spot = 3,
			MultiSpot = 4,
			Pattern = 5,
			Partial = 6,
		}

		/// <summary>
		/// This is the user-friendly form of System.Photo.MeteringMode.
		/// Not intended to be parsed programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.MeteringModeText -- PKEY_MeteringModeText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>F628FD8C-7BA8-465A-A65B-C5AA79263A9E, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey MeteringModeText => new PropertyKey(0xF628FD8C, 0x7BA8, 0x465A, 0xA6, 0x5B, 0xC5, 0xAA, 0x79, 0x26, 0x3A, 0x9E, 100);

		/// <summary>
		/// This is the image orientation viewed in terms of rows and columns.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.Orientation -- PKEY_Orientation</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 274 (PropertyTagOrientation)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Orientation => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 274);

		/// <summary>Possible discrete values for PKEY_Orientation.</summary>
		public enum OrientationValues : ushort
		{
			Normal = 1,
			FlipHorizontal = 2,
			Rotate180 = 3,
			FlipVertical = 4,
			Transpose = 5,
			Rotate270 = 6,
			Transverse = 7,
			Rotate90 = 8,
		}

		/// <summary>
		/// This is the user-friendly form of System.Photo.Orientation.
		/// Not intended to be parsed programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.OrientationText -- PKEY_OrientationText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>A9EA193C-C511-498A-A06B-58E2776DCC28, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OrientationText => new PropertyKey(0xA9EA193C, 0xC511, 0x498A, 0xA0, 0x6B, 0x58, 0xE2, 0x77, 0x6D, 0xCC, 0x28, 100);

		/// <summary>
		/// This is the pixel composition. In JPEG compressed data, a JPEG marker is used instead of this property.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.PhotometricInterpretation -- PKEY_PhotometricInterpretation</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
		///   <item><term><b>Format ID:</b></term><description>341796F1-1DF9-4B1C-A564-91BDEFA43877, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PhotometricInterpretation => new PropertyKey(0x341796F1, 0x1DF9, 0x4B1C, 0xA5, 0x64, 0x91, 0xBD, 0xEF, 0xA4, 0x38, 0x77, 100);

		/// <summary>Possible discrete values for PKEY_PhotometricInterpretation.</summary>
		public enum PhotoMetric : ushort
		{
			RGB = 2,
			YCBCR = 6,
		}

		/// <summary>
		/// This is the user-friendly form of System.Photo.PhotometricInterpretation.
		/// Not intended to be parsed programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.PhotometricInterpretationText -- PKEY_PhotometricInterpretationText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>821437D6-9EAB-4765-A589-3B1CBBD22A61, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PhotometricInterpretationText => new PropertyKey(0x821437D6, 0x9EAB, 0x4765, 0xA5, 0x89, 0x3B, 0x1C, 0xBB, 0xD2, 0x2A, 0x61, 100);

		/// <summary>
		/// This is the class of the program used by the camera to set exposure when the picture is taken.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ProgramMode -- PKEY_ProgramMode</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>6D217F6D-3F6A-4825-B470-5F03CA2FBE9B, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ProgramMode => new PropertyKey(0x6D217F6D, 0x3F6A, 0x4825, 0xB4, 0x70, 0x5F, 0x03, 0xCA, 0x2F, 0xBE, 0x9B, 100);

		/// <summary>Possible discrete values for PKEY_ProgramMode.</summary>
		public enum ProgramModeValues : uint
		{
			NotDefined = 0,
			Manual = 1,
			Normal = 2,
			Aperture = 3,
			Shutter = 4,
			Creative = 5,
			Action = 6,
			Portrait = 7,
			Landscape = 8,
		}

		/// <summary>
		/// This is the user-friendly form of System.Photo.ProgramMode.
		/// Not intended to be parsed programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ProgramModeText -- PKEY_ProgramModeText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>7FE3AA27-2648-42F3-89B0-454E5CB150C3, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ProgramModeText => new PropertyKey(0x7FE3AA27, 0x2648, 0x42F3, 0x89, 0xB0, 0x45, 0x4E, 0x5C, 0xB1, 0x50, 0xC3, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.RelatedSoundFile -- PKEY_RelatedSoundFile</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>318A6B45-087F-4DC2-B8CC-05359551FC9E, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey RelatedSoundFile => new PropertyKey(0x318A6B45, 0x087F, 0x4DC2, 0xB8, 0xCC, 0x05, 0x35, 0x95, 0x51, 0xFC, 0x9E, 100);

		/// <summary>
		/// This indicates the direction of saturation processing applied by the camera when the image was shot.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.Saturation -- PKEY_Saturation</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>49237325-A95A-4F67-B211-816B2D45D2E0, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Saturation => new PropertyKey(0x49237325, 0xA95A, 0x4F67, 0xB2, 0x11, 0x81, 0x6B, 0x2D, 0x45, 0xD2, 0xE0, 100);

		/// <summary>Possible discrete values for PKEY_Saturation.</summary>
		public enum SaturationValues : uint
		{
			Normal = 0,
			Low = 1,
			High = 2,
		}

		/// <summary>
		/// This is the user-friendly form of System.Photo.Saturation.
		/// Not intended to be parsed programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.SaturationText -- PKEY_SaturationText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>61478C08-B600-4A84-BBE4-E99C45F0A072, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SaturationText => new PropertyKey(0x61478C08, 0xB600, 0x4A84, 0xBB, 0xE4, 0xE9, 0x9C, 0x45, 0xF0, 0xA0, 0x72, 100);

		/// <summary>
		/// This indicates the direction of sharpness processing applied by the camera when the image was shot.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.Sharpness -- PKEY_Sharpness</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>FC6976DB-8349-4970-AE97-B3C5316A08F0, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Sharpness => new PropertyKey(0xFC6976DB, 0x8349, 0x4970, 0xAE, 0x97, 0xB3, 0xC5, 0x31, 0x6A, 0x08, 0xF0, 100);

		/// <summary>Possible discrete values for PKEY_Sharpness.</summary>
		/// 
		public enum SharpnessValues : uint
		{
			Normal = 0,
			Soft = 1,
			Hard = 2,
		}

		/// <summary>
		/// This is the user-friendly form of System.Photo.Sharpness.
		/// Not intended to be parsed programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.SharpnessText -- PKEY_SharpnessText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>51EC3F47-DD50-421D-8769-334F50424B1E, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SharpnessText => new PropertyKey(0x51EC3F47, 0xDD50, 0x421D, 0x87, 0x69, 0x33, 0x4F, 0x50, 0x42, 0x4B, 0x1E, 100);

		/// <summary>
		/// PropertyTagExifShutterSpeed.  Calculated from PKEY_ShutterSpeedNumerator and PKEY_ShutterSpeedDenominator</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ShutterSpeed -- PKEY_ShutterSpeed</description></item>
		///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 37377</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ShutterSpeed => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 37377);

		/// <summary>
		/// Denominator of PKEY_ShutterSpeed</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ShutterSpeedDenominator -- PKEY_ShutterSpeedDenominator</description></item>
		///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
		///   <item><term><b>Format ID:</b></term><description>E13D8975-81C7-4948-AE3F-37CAE11E8FF7, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ShutterSpeedDenominator => new PropertyKey(0xE13D8975, 0x81C7, 0x4948, 0xAE, 0x3F, 0x37, 0xCA, 0xE1, 0x1E, 0x8F, 0xF7, 100);

		/// <summary>
		/// Numerator of PKEY_ShutterSpeed</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.ShutterSpeedNumerator -- PKEY_ShutterSpeedNumerator</description></item>
		///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
		///   <item><term><b>Format ID:</b></term><description>16EA4042-D6F4-4BCA-8349-7C78D30FB333, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ShutterSpeedNumerator => new PropertyKey(0x16EA4042, 0xD6F4, 0x4BCA, 0x83, 0x49, 0x7C, 0x78, 0xD3, 0x0F, 0xB3, 0x33, 100);

		/// <summary>
		/// PropertyTagExifSubjectDist.  Calculated from PKEY_SubjectDistanceNumerator and PKEY_SubjectDistanceDenominator</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.SubjectDistance -- PKEY_SubjectDistance</description></item>
		///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 37382</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SubjectDistance => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 37382);

		/// <summary>
		/// Denominator of PKEY_SubjectDistance</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.SubjectDistanceDenominator -- PKEY_SubjectDistanceDenominator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>0C840A88-B043-466D-9766-D4B26DA3FA77, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SubjectDistanceDenominator => new PropertyKey(0x0C840A88, 0xB043, 0x466D, 0x97, 0x66, 0xD4, 0xB2, 0x6D, 0xA3, 0xFA, 0x77, 100);

		/// <summary>
		/// Numerator of PKEY_SubjectDistance</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.SubjectDistanceNumerator -- PKEY_SubjectDistanceNumerator</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>8AF4961C-F526-43E5-AA81-DB768219178D, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SubjectDistanceNumerator => new PropertyKey(0x8AF4961C, 0xF526, 0x43E5, 0xAA, 0x81, 0xDB, 0x76, 0x82, 0x19, 0x17, 0x8D, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.TranscodedForSync -- PKEY_TranscodedForSync</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>9A8EBB75-6458-4E82-BACB-35C0095B03BB, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TranscodedForSync => new PropertyKey(0x9A8EBB75, 0x6458, 0x4E82, 0xBA, 0xCB, 0x35, 0xC0, 0x09, 0x5B, 0x03, 0xBB, 100);

		/// <summary>
		/// This indicates the white balance mode set when the image was shot.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.WhiteBalance -- PKEY_WhiteBalance</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>EE3D3D8A-5381-4CFA-B13B-AAF66B5F4EC9, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey WhiteBalance => new PropertyKey(0xEE3D3D8A, 0x5381, 0x4CFA, 0xB1, 0x3B, 0xAA, 0xF6, 0x6B, 0x5F, 0x4E, 0xC9, 100);

		/// <summary>Possible discrete values for PKEY_WhiteBalance.</summary>
		public enum WhiteBalanceMode : uint
		{
			Auto = 0,
			Manual = 1,
		}

		/// <summary>
		/// This is the user-friendly form of System.Photo.WhiteBalance.
		/// Not intended to be parsed programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Photo.WhiteBalanceText -- PKEY_WhiteBalanceText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>6336B95E-C7A7-426D-86FD-7AE3D39C84B4, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey WhiteBalanceText => new PropertyKey(0x6336B95E, 0xC7A7, 0x426D, 0x86, 0xFD, 0x7A, 0xE3, 0xD3, 0x9C, 0x84, 0xB4, 100);
	}
}
