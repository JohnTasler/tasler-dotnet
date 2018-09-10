using System;

namespace Tasler.Interop.Shell
{
    public static partial class PropertyKeys
    {
        public static class GPS
        {
            /// <summary>
            /// Indicates the altitude based on the reference in PKEY_AltitudeRef.
            /// Calculated from PKEY_AltitudeNumerator and PKEY_AltitudeDenominator</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.Altitude -- PKEY_Altitude</description></item>
            ///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
            ///   <item><term><b>Format ID:</b></term><description>827EDB4F-5B73-44A7-891D-FDFFABEA35CA, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey Altitude { get { return new PropertyKey(0x827EDB4F, 0x5B73, 0x44A7, 0x89, 0x1D, 0xFD, 0xFF, 0xAB, 0xEA, 0x35, 0xCA, 100); } }

            /// <summary>
            /// Denominator of PKEY_Altitude</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.AltitudeDenominator -- PKEY_AltitudeDenominator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>78342DCB-E358-4145-AE9A-6BFE4E0F9F51, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey AltitudeDenominator { get { return new PropertyKey(0x78342DCB, 0xE358, 0x4145, 0xAE, 0x9A, 0x6B, 0xFE, 0x4E, 0x0F, 0x9F, 0x51, 100); } }

            /// <summary>
            /// Numerator of PKEY_Altitude</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.AltitudeNumerator -- PKEY_AltitudeNumerator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>2DAD1EB7-816D-40D3-9EC3-C9773BE2AADE, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey AltitudeNumerator { get { return new PropertyKey(0x2DAD1EB7, 0x816D, 0x40D3, 0x9E, 0xC3, 0xC9, 0x77, 0x3B, 0xE2, 0xAA, 0xDE, 100); } }

            /// <summary>
            /// Indicates the reference for the altitude property. (eg: above sea level, below sea level, absolute value)</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.AltitudeRef -- PKEY_AltitudeRef</description></item>
            ///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
            ///   <item><term><b>Format ID:</b></term><description>46AC629D-75EA-4515-867F-6DC4321C5844, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey AltitudeRef { get { return new PropertyKey(0x46AC629D, 0x75EA, 0x4515, 0x86, 0x7F, 0x6D, 0xC4, 0x32, 0x1C, 0x58, 0x44, 100); } }

            /// <summary>
            /// Represents the name of the GPS area</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.AreaInformation -- PKEY_AreaInformation</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>972E333E-AC7E-49F1-8ADF-A70D07A9BCAB, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey AreaInformation { get { return new PropertyKey(0x972E333E, 0xAC7E, 0x49F1, 0x8A, 0xDF, 0xA7, 0x0D, 0x07, 0xA9, 0xBC, 0xAB, 100); } }

            /// <summary>
            /// Date and time of the GPS record</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.Date -- PKEY_Date</description></item>
            ///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>3602C812-0F3B-45F0-85AD-603468D69423, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey Date { get { return new PropertyKey(0x3602C812, 0x0F3B, 0x45F0, 0x85, 0xAD, 0x60, 0x34, 0x68, 0xD6, 0x94, 0x23, 100); } }

            /// <summary>
            /// Indicates the bearing to the destination point.
            /// Calculated from PKEY_DestBearingNumerator and PKEY_DestBearingDenominator.
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestBearing -- PKEY_DestBearing</description></item>
            ///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
            ///   <item><term><b>Format ID:</b></term><description>C66D4B3C-E888-47CC-B99F-9DCA3EE34DEA, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestBearing { get { return new PropertyKey(0xC66D4B3C, 0xE888, 0x47CC, 0xB9, 0x9F, 0x9D, 0xCA, 0x3E, 0xE3, 0x4D, 0xEA, 100); } }

            /// <summary>
            /// Denominator of PKEY_DestBearing</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestBearingDenominator -- PKEY_DestBearingDenominator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>7ABCF4F8-7C3F-4988-AC91-8D2C2E97ECA5, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestBearingDenominator { get { return new PropertyKey(0x7ABCF4F8, 0x7C3F, 0x4988, 0xAC, 0x91, 0x8D, 0x2C, 0x2E, 0x97, 0xEC, 0xA5, 100); } }

            /// <summary>
            /// Numerator of PKEY_DestBearing</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestBearingNumerator -- PKEY_DestBearingNumerator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>BA3B1DA9-86EE-4B5D-A2A4-A271A429F0CF, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestBearingNumerator { get { return new PropertyKey(0xBA3B1DA9, 0x86EE, 0x4B5D, 0xA2, 0xA4, 0xA2, 0x71, 0xA4, 0x29, 0xF0, 0xCF, 100); } }

            /// <summary>
            /// Indicates the reference used for the giving the bearing to the destination point.  (eg: true direction, magnetic direction)</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestBearingRef -- PKEY_DestBearingRef</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>9AB84393-2A0F-4B75-BB22-7279786977CB, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestBearingRef { get { return new PropertyKey(0x9AB84393, 0x2A0F, 0x4B75, 0xBB, 0x22, 0x72, 0x79, 0x78, 0x69, 0x77, 0xCB, 100); } }

            /// <summary>
            /// Indicates the distance to the destination point.
            /// Calculated from PKEY_DestDistanceNumerator and PKEY_DestDistanceDenominator.
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestDistance -- PKEY_DestDistance</description></item>
            ///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
            ///   <item><term><b>Format ID:</b></term><description>A93EAE04-6804-4F24-AC81-09B266452118, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestDistance { get { return new PropertyKey(0xA93EAE04, 0x6804, 0x4F24, 0xAC, 0x81, 0x09, 0xB2, 0x66, 0x45, 0x21, 0x18, 100); } }

            /// <summary>
            /// Denominator of PKEY_DestDistance</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestDistanceDenominator -- PKEY_DestDistanceDenominator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>9BC2C99B-AC71-4127-9D1C-2596D0D7DCB7, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestDistanceDenominator { get { return new PropertyKey(0x9BC2C99B, 0xAC71, 0x4127, 0x9D, 0x1C, 0x25, 0x96, 0xD0, 0xD7, 0xDC, 0xB7, 100); } }

            /// <summary>
            /// Numerator of PKEY_DestDistance</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestDistanceNumerator -- PKEY_DestDistanceNumerator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>2BDA47DA-08C6-4FE1-80BC-A72FC517C5D0, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestDistanceNumerator { get { return new PropertyKey(0x2BDA47DA, 0x08C6, 0x4FE1, 0x80, 0xBC, 0xA7, 0x2F, 0xC5, 0x17, 0xC5, 0xD0, 100); } }

            /// <summary>
            /// Indicates the unit used to express the distance to the destination.  (eg: kilometers, miles, knots)</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestDistanceRef -- PKEY_DestDistanceRef</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>ED4DF2D3-8695-450B-856F-F5C1C53ACB66, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestDistanceRef { get { return new PropertyKey(0xED4DF2D3, 0x8695, 0x450B, 0x85, 0x6F, 0xF5, 0xC1, 0xC5, 0x3A, 0xCB, 0x66, 100); } }

            /// <summary>
            /// Indicates the latitude of the destination point.  This is an array of three values.
            /// Index 0 is the degrees, index 1 is the minutes, index 2 is the seconds.
            /// Each is calculated from the values in PKEY_DestLatitudeNumerator and PKEY_DestLatitudeDenominator.
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestLatitude -- PKEY_DestLatitude</description></item>
            ///   <item><term><b>Type:     </b></term><description>Multivalue Double -- VT_VECTOR | VT_R8  (For variants: VT_ARRAY | VT_R8)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>9D1D7CC5-5C39-451C-86B3-928E2D18CC47, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestLatitude { get { return new PropertyKey(0x9D1D7CC5, 0x5C39, 0x451C, 0x86, 0xB3, 0x92, 0x8E, 0x2D, 0x18, 0xCC, 0x47, 100); } }

            /// <summary>
            /// Denominator of PKEY_DestLatitude</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestLatitudeDenominator -- PKEY_DestLatitudeDenominator</description></item>
            ///   <item><term><b>Type:     </b></term><description>Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>3A372292-7FCA-49A7-99D5-E47BB2D4E7AB, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestLatitudeDenominator { get { return new PropertyKey(0x3A372292, 0x7FCA, 0x49A7, 0x99, 0xD5, 0xE4, 0x7B, 0xB2, 0xD4, 0xE7, 0xAB, 100); } }

            /// <summary>
            /// Numerator of PKEY_DestLatitude</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestLatitudeNumerator -- PKEY_DestLatitudeNumerator</description></item>
            ///   <item><term><b>Type:     </b></term><description>Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>ECF4B6F6-D5A6-433C-BB92-4076650FC890, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestLatitudeNumerator { get { return new PropertyKey(0xECF4B6F6, 0xD5A6, 0x433C, 0xBB, 0x92, 0x40, 0x76, 0x65, 0x0F, 0xC8, 0x90, 100); } }

            /// <summary>
            /// Indicates whether the latitude destination point is north or south latitude</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestLatitudeRef -- PKEY_DestLatitudeRef</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>CEA820B9-CE61-4885-A128-005D9087C192, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestLatitudeRef { get { return new PropertyKey(0xCEA820B9, 0xCE61, 0x4885, 0xA1, 0x28, 0x00, 0x5D, 0x90, 0x87, 0xC1, 0x92, 100); } }

            /// <summary>
            /// Indicates the latitude of the destination point.  This is an array of three values.
            /// Index 0 is the degrees, index 1 is the minutes, index 2 is the seconds.
            /// Each is calculated from the values in PKEY_DestLongitudeNumerator and PKEY_DestLongitudeDenominator.
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestLongitude -- PKEY_DestLongitude</description></item>
            ///   <item><term><b>Type:     </b></term><description>Multivalue Double -- VT_VECTOR | VT_R8  (For variants: VT_ARRAY | VT_R8)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>47A96261-CB4C-4807-8AD3-40B9D9DBC6BC, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestLongitude { get { return new PropertyKey(0x47A96261, 0xCB4C, 0x4807, 0x8A, 0xD3, 0x40, 0xB9, 0xD9, 0xDB, 0xC6, 0xBC, 100); } }

            /// <summary>
            /// Denominator of PKEY_DestLongitude</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestLongitudeDenominator -- PKEY_DestLongitudeDenominator</description></item>
            ///   <item><term><b>Type:     </b></term><description>Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>425D69E5-48AD-4900-8D80-6EB6B8D0AC86, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestLongitudeDenominator { get { return new PropertyKey(0x425D69E5, 0x48AD, 0x4900, 0x8D, 0x80, 0x6E, 0xB6, 0xB8, 0xD0, 0xAC, 0x86, 100); } }

            /// <summary>
            /// Numerator of PKEY_DestLongitude</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestLongitudeNumerator -- PKEY_DestLongitudeNumerator</description></item>
            ///   <item><term><b>Type:     </b></term><description>Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>A3250282-FB6D-48D5-9A89-DBCACE75CCCF, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestLongitudeNumerator { get { return new PropertyKey(0xA3250282, 0xFB6D, 0x48D5, 0x9A, 0x89, 0xDB, 0xCA, 0xCE, 0x75, 0xCC, 0xCF, 100); } }

            /// <summary>
            /// Indicates whether the longitude destination point is east or west longitude</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DestLongitudeRef -- PKEY_DestLongitudeRef</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>182C1EA6-7C1C-4083-AB4B-AC6C9F4ED128, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DestLongitudeRef { get { return new PropertyKey(0x182C1EA6, 0x7C1C, 0x4083, 0xAB, 0x4B, 0xAC, 0x6C, 0x9F, 0x4E, 0xD1, 0x28, 100); } }

            /// <summary>
            /// Indicates whether differential correction was applied to the GPS receiver</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.Differential -- PKEY_Differential</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
            ///   <item><term><b>Format ID:</b></term><description>AAF4EE25-BD3B-4DD7-BFC4-47F77BB00F6D, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey Differential { get { return new PropertyKey(0xAAF4EE25, 0xBD3B, 0x4DD7, 0xBF, 0xC4, 0x47, 0xF7, 0x7B, 0xB0, 0x0F, 0x6D, 100); } }

            /// <summary>
            /// Indicates the GPS DOP (data degree of precision).  Calculated from PKEY_DOPNumerator and PKEY_DOPDenominator</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DOP -- PKEY_DOP</description></item>
            ///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
            ///   <item><term><b>Format ID:</b></term><description>0CF8FB02-1837-42F1-A697-A7017AA289B9, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DOP { get { return new PropertyKey(0x0CF8FB02, 0x1837, 0x42F1, 0xA6, 0x97, 0xA7, 0x01, 0x7A, 0xA2, 0x89, 0xB9, 100); } }

            /// <summary>
            /// Denominator of PKEY_DOP</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DOPDenominator -- PKEY_DOPDenominator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>A0BE94C5-50BA-487B-BD35-0654BE8881ED, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DOPDenominator { get { return new PropertyKey(0xA0BE94C5, 0x50BA, 0x487B, 0xBD, 0x35, 0x06, 0x54, 0xBE, 0x88, 0x81, 0xED, 100); } }

            /// <summary>
            /// Numerator of PKEY_DOP</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.DOPNumerator -- PKEY_DOPNumerator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>47166B16-364F-4AA0-9F31-E2AB3DF449C3, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey DOPNumerator { get { return new PropertyKey(0x47166B16, 0x364F, 0x4AA0, 0x9F, 0x31, 0xE2, 0xAB, 0x3D, 0xF4, 0x49, 0xC3, 100); } }

            /// <summary>
            /// Indicates direction of the image when it was captured.
            /// Calculated from PKEY_ImgDirectionNumerator and PKEY_ImgDirectionDenominator.
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.ImgDirection -- PKEY_ImgDirection</description></item>
            ///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
            ///   <item><term><b>Format ID:</b></term><description>16473C91-D017-4ED9-BA4D-B6BAA55DBCF8, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey ImgDirection { get { return new PropertyKey(0x16473C91, 0xD017, 0x4ED9, 0xBA, 0x4D, 0xB6, 0xBA, 0xA5, 0x5D, 0xBC, 0xF8, 100); } }

            /// <summary>
            /// Denominator of PKEY_ImgDirection</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.ImgDirectionDenominator -- PKEY_ImgDirectionDenominator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>10B24595-41A2-4E20-93C2-5761C1395F32, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey ImgDirectionDenominator { get { return new PropertyKey(0x10B24595, 0x41A2, 0x4E20, 0x93, 0xC2, 0x57, 0x61, 0xC1, 0x39, 0x5F, 0x32, 100); } }

            /// <summary>
            /// Numerator of PKEY_ImgDirection</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.ImgDirectionNumerator -- PKEY_ImgDirectionNumerator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>DC5877C7-225F-45F7-BAC7-E81334B6130A, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey ImgDirectionNumerator { get { return new PropertyKey(0xDC5877C7, 0x225F, 0x45F7, 0xBA, 0xC7, 0xE8, 0x13, 0x34, 0xB6, 0x13, 0x0A, 100); } }

            /// <summary>
            /// Indicates reference for giving the direction of the image when it was captured.  (eg: true direction, magnetic direction)</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.ImgDirectionRef -- PKEY_ImgDirectionRef</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>A4AAA5B7-1AD0-445F-811A-0F8F6E67F6B5, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey ImgDirectionRef { get { return new PropertyKey(0xA4AAA5B7, 0x1AD0, 0x445F, 0x81, 0x1A, 0x0F, 0x8F, 0x6E, 0x67, 0xF6, 0xB5, 100); } }

            /// <summary>
            /// Indicates the latitude.  This is an array of three values.
            /// Index 0 is the degrees, index 1 is the minutes, index 2 is the seconds.
            /// Each is calculated from the values in PKEY_LatitudeNumerator and PKEY_LatitudeDenominator.
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.Latitude -- PKEY_Latitude</description></item>
            ///   <item><term><b>Type:     </b></term><description>Multivalue Double -- VT_VECTOR | VT_R8  (For variants: VT_ARRAY | VT_R8)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>8727CFFF-4868-4EC6-AD5B-81B98521D1AB, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey Latitude { get { return new PropertyKey(0x8727CFFF, 0x4868, 0x4EC6, 0xAD, 0x5B, 0x81, 0xB9, 0x85, 0x21, 0xD1, 0xAB, 100); } }

            /// <summary>
            /// Denominator of PKEY_Latitude</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.LatitudeDenominator -- PKEY_LatitudeDenominator</description></item>
            ///   <item><term><b>Type:     </b></term><description>Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>16E634EE-2BFF-497B-BD8A-4341AD39EEB9, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey LatitudeDenominator { get { return new PropertyKey(0x16E634EE, 0x2BFF, 0x497B, 0xBD, 0x8A, 0x43, 0x41, 0xAD, 0x39, 0xEE, 0xB9, 100); } }

            /// <summary>
            /// Numerator of PKEY_Latitude</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.LatitudeNumerator -- PKEY_LatitudeNumerator</description></item>
            ///   <item><term><b>Type:     </b></term><description>Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>7DDAAAD1-CCC8-41AE-B750-B2CB8031AEA2, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey LatitudeNumerator { get { return new PropertyKey(0x7DDAAAD1, 0xCCC8, 0x41AE, 0xB7, 0x50, 0xB2, 0xCB, 0x80, 0x31, 0xAE, 0xA2, 100); } }

            /// <summary>
            /// Indicates whether latitude is north or south latitude </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.LatitudeRef -- PKEY_LatitudeRef</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>029C0252-5B86-46C7-ACA0-2769FFC8E3D4, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey LatitudeRef { get { return new PropertyKey(0x029C0252, 0x5B86, 0x46C7, 0xAC, 0xA0, 0x27, 0x69, 0xFF, 0xC8, 0xE3, 0xD4, 100); } }

            /// <summary>
            /// Indicates the longitude.  This is an array of three values.
            /// Index 0 is the degrees, index 1 is the minutes, index 2 is the seconds.
            /// Each is calculated from the values in PKEY_LongitudeNumerator and PKEY_LongitudeDenominator.
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.Longitude -- PKEY_Longitude</description></item>
            ///   <item><term><b>Type:     </b></term><description>Multivalue Double -- VT_VECTOR | VT_R8  (For variants: VT_ARRAY | VT_R8)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>C4C4DBB2-B593-466B-BBDA-D03D27D5E43A, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey Longitude { get { return new PropertyKey(0xC4C4DBB2, 0xB593, 0x466B, 0xBB, 0xDA, 0xD0, 0x3D, 0x27, 0xD5, 0xE4, 0x3A, 100); } }

            /// <summary>
            /// Denominator of PKEY_Longitude</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.LongitudeDenominator -- PKEY_LongitudeDenominator</description></item>
            ///   <item><term><b>Type:     </b></term><description>Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>BE6E176C-4534-4D2C-ACE5-31DEDAC1606B, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey LongitudeDenominator { get { return new PropertyKey(0xBE6E176C, 0x4534, 0x4D2C, 0xAC, 0xE5, 0x31, 0xDE, 0xDA, 0xC1, 0x60, 0x6B, 100); } }

            /// <summary>
            /// Numerator of PKEY_Longitude</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.LongitudeNumerator -- PKEY_LongitudeNumerator</description></item>
            ///   <item><term><b>Type:     </b></term><description>Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>02B0F689-A914-4E45-821D-1DDA452ED2C4, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey LongitudeNumerator { get { return new PropertyKey(0x02B0F689, 0xA914, 0x4E45, 0x82, 0x1D, 0x1D, 0xDA, 0x45, 0x2E, 0xD2, 0xC4, 100); } }

            /// <summary>
            /// Indicates whether longitude is east or west longitude</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.LongitudeRef -- PKEY_LongitudeRef</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>33DCF22B-28D5-464C-8035-1EE9EFD25278, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey LongitudeRef { get { return new PropertyKey(0x33DCF22B, 0x28D5, 0x464C, 0x80, 0x35, 0x1E, 0xE9, 0xEF, 0xD2, 0x52, 0x78, 100); } }

            /// <summary>
            /// Indicates the geodetic survey data used by the GPS receiver</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.MapDatum -- PKEY_MapDatum</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>2CA2DAE6-EDDC-407D-BEF1-773942ABFA95, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey MapDatum { get { return new PropertyKey(0x2CA2DAE6, 0xEDDC, 0x407D, 0xBE, 0xF1, 0x77, 0x39, 0x42, 0xAB, 0xFA, 0x95, 100); } }

            /// <summary>
            /// Indicates the GPS measurement mode.  (eg: 2-dimensional, 3-dimensional)</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.MeasureMode -- PKEY_MeasureMode</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>A015ED5D-AAEA-4D58-8A86-3C586920EA0B, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey MeasureMode { get { return new PropertyKey(0xA015ED5D, 0xAAEA, 0x4D58, 0x8A, 0x86, 0x3C, 0x58, 0x69, 0x20, 0xEA, 0x0B, 100); } }

            /// <summary>
            /// Indicates the name of the method used for location finding</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.ProcessingMethod -- PKEY_ProcessingMethod</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>59D49E61-840F-4AA9-A939-E2099B7F6399, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey ProcessingMethod { get { return new PropertyKey(0x59D49E61, 0x840F, 0x4AA9, 0xA9, 0x39, 0xE2, 0x09, 0x9B, 0x7F, 0x63, 0x99, 100); } }

            /// <summary>
            /// Indicates the GPS satellites used for measurements</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.Satellites -- PKEY_Satellites</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>467EE575-1F25-4557-AD4E-B8B58B0D9C15, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey Satellites { get { return new PropertyKey(0x467EE575, 0x1F25, 0x4557, 0xAD, 0x4E, 0xB8, 0xB5, 0x8B, 0x0D, 0x9C, 0x15, 100); } }

            /// <summary>
            /// Indicates the speed of the GPS receiver movement.  Calculated from PKEY_SpeedNumerator and PKEY_SpeedDenominator.
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.Speed -- PKEY_Speed</description></item>
            ///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
            ///   <item><term><b>Format ID:</b></term><description>DA5D0862-6E76-4E1B-BABD-70021BD25494, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey Speed { get { return new PropertyKey(0xDA5D0862, 0x6E76, 0x4E1B, 0xBA, 0xBD, 0x70, 0x02, 0x1B, 0xD2, 0x54, 0x94, 100); } }

            /// <summary>
            /// Denominator of PKEY_Speed</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.SpeedDenominator -- PKEY_SpeedDenominator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>7D122D5A-AE5E-4335-8841-D71E7CE72F53, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey SpeedDenominator { get { return new PropertyKey(0x7D122D5A, 0xAE5E, 0x4335, 0x88, 0x41, 0xD7, 0x1E, 0x7C, 0xE7, 0x2F, 0x53, 100); } }

            /// <summary>
            /// Numerator of PKEY_Speed</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.SpeedNumerator -- PKEY_SpeedNumerator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>ACC9CE3D-C213-4942-8B48-6D0820F21C6D, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey SpeedNumerator { get { return new PropertyKey(0xACC9CE3D, 0xC213, 0x4942, 0x8B, 0x48, 0x6D, 0x08, 0x20, 0xF2, 0x1C, 0x6D, 100); } }

            /// <summary>
            /// Indicates the unit used to express the speed of the GPS receiver movement.
            /// (eg: kilometers per hour, miles per hour, knots).</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.SpeedRef -- PKEY_SpeedRef</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>ECF7F4C9-544F-4D6D-9D98-8AD79ADAF453, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey SpeedRef { get { return new PropertyKey(0xECF7F4C9, 0x544F, 0x4D6D, 0x9D, 0x98, 0x8A, 0xD7, 0x9A, 0xDA, 0xF4, 0x53, 100); } }

            /// <summary>
            /// Indicates the status of the GPS receiver when the image was recorded.
            /// (eg: measurement in progress, measurement interoperability).</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.Status -- PKEY_Status</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>125491F4-818F-46B2-91B5-D537753617B2, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey Status { get { return new PropertyKey(0x125491F4, 0x818F, 0x46B2, 0x91, 0xB5, 0xD5, 0x37, 0x75, 0x36, 0x17, 0xB2, 100); } }

            /// <summary>
            /// Indicates the direction of the GPS receiver movement.
            /// Calculated from PKEY_TrackNumerator and PKEY_TrackDenominator.</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.Track -- PKEY_Track</description></item>
            ///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
            ///   <item><term><b>Format ID:</b></term><description>76C09943-7C33-49E3-9E7E-CDBA872CFADA, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey Track { get { return new PropertyKey(0x76C09943, 0x7C33, 0x49E3, 0x9E, 0x7E, 0xCD, 0xBA, 0x87, 0x2C, 0xFA, 0xDA, 100); } }

            /// <summary>
            /// Denominator of PKEY_Track</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.TrackDenominator -- PKEY_TrackDenominator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>C8D1920C-01F6-40C0-AC86-2F3A4AD00770, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey TrackDenominator { get { return new PropertyKey(0xC8D1920C, 0x01F6, 0x40C0, 0xAC, 0x86, 0x2F, 0x3A, 0x4A, 0xD0, 0x07, 0x70, 100); } }

            /// <summary>
            /// Numerator of PKEY_Track</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.TrackNumerator -- PKEY_TrackNumerator</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>702926F4-44A6-43E1-AE71-45627116893B, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey TrackNumerator { get { return new PropertyKey(0x702926F4, 0x44A6, 0x43E1, 0xAE, 0x71, 0x45, 0x62, 0x71, 0x16, 0x89, 0x3B, 100); } }

            /// <summary>
            /// Indicates reference for the direction of the GPS receiver movement.  (eg: true direction, magnetic direction)</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.TrackRef -- PKEY_TrackRef</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>35DBE6FE-44C3-4400-AAAE-D2C799C407E8, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey TrackRef { get { return new PropertyKey(0x35DBE6FE, 0x44C3, 0x4400, 0xAA, 0xAE, 0xD2, 0xC7, 0x99, 0xC4, 0x07, 0xE8, 100); } }

            /// <summary>
            /// Indicates the version of the GPS information</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.GPS.VersionID -- PKEY_VersionID</description></item>
            ///   <item><term><b>Type:     </b></term><description>Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>22704DA4-C6B2-4A99-8E56-F16DF8C92599, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey VersionID { get { return new PropertyKey(0x22704DA4, 0xC6B2, 0x4A99, 0x8E, 0x56, 0xF1, 0x6D, 0xF8, 0xC9, 0x25, 0x99, 100); } }
        }
    }
}