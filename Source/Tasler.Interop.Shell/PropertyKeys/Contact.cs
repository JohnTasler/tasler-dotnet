
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Contact
	{
		/// <summary>This is a stream containing the data necessary to render a contact's dynamic video account picture.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.AccountPictureDynamicVideo -- PKEY_Contact_AccountPictureDynamicVideo</description></item>
		///   <item><term><b>Type:     </b></term><description>Stream -- VT_STREAM</description></item>
		///   <item><term><b>Format ID:</b></term><description>{0B8BB018-2725-4B44-92BA-7933AEB2DDE7}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AccountPictureDynamicVideo => new(0x0B8BB018, 0x2725, 0x4B44, 0x92, 0xBA, 0x79, 0x33, 0xAE, 0xB2, 0xDD, 0xE7, 2);

		/// <summary>This is a stream containing the data necessary to render a contact's large account picture.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.AccountPictureLarge -- PKEY_Contact_AccountPictureLarge</description></item>
		///   <item><term><b>Type:     </b></term><description>Stream -- VT_STREAM</description></item>
		///   <item><term><b>Format ID:</b></term><description>{0B8BB018-2725-4B44-92BA-7933AEB2DDE7}, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AccountPictureLarge => new(0x0B8BB018, 0x2725, 0x4B44, 0x92, 0xBA, 0x79, 0x33, 0xAE, 0xB2, 0xDD, 0xE7, 3);

		/// <summary>This is a stream containing the data necessary to render a contact's small account picture.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.AccountPictureSmall -- PKEY_Contact_AccountPictureSmall</description></item>
		///   <item><term><b>Type:     </b></term><description>Stream -- VT_STREAM</description></item>
		///   <item><term><b>Format ID:</b></term><description>{0B8BB018-2725-4B44-92BA-7933AEB2DDE7}, 4</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AccountPictureSmall => new(0x0B8BB018, 0x2725, 0x4B44, 0x92, 0xBA, 0x79, 0x33, 0xAE, 0xB2, 0xDD, 0xE7, 4);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.Anniversary -- PKEY_Contact_Anniversary</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>9AD5BADB-CEA7-4470-A03D-B84E51B9949E, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Anniversary => new(0x9AD5BADB, 0xCEA7, 0x4470, 0xA0, 0x3D, 0xB8, 0x4E, 0x51, 0xB9, 0x94, 0x9E, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.AssistantName -- PKEY_Contact_AssistantName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>CD102C9C-5540-4A88-A6F6-64E4981C8CD1, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AssistantName => new(0xCD102C9C, 0x5540, 0x4A88, 0xA6, 0xF6, 0x64, 0xE4, 0x98, 0x1C, 0x8C, 0xD1, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.AssistantTelephone -- PKEY_Contact_AssistantTelephone</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>9A93244D-A7AD-4FF8-9B99-45EE4CC09AF6, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AssistantTelephone => new(0x9A93244D, 0xA7AD, 0x4FF8, 0x9B, 0x99, 0x45, 0xEE, 0x4C, 0xC0, 0x9A, 0xF6, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.Birthday -- PKEY_Contact_Birthday</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>176DC63C-2688-4E89-8143-A347800F25E9, 47</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Birthday => new(0x176DC63C, 0x2688, 0x4E89, 0x81, 0x43, 0xA3, 0x47, 0x80, 0x0F, 0x25, 0xE9, 47);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress -- PKEY_Contact_BusinessAddress</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>730FB6DD-CF7C-426B-A03F-BD166CC9EE24, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress => new(0x730FB6DD, 0xCF7C, 0x426B, 0xA0, 0x3F, 0xBD, 0x16, 0x6C, 0xC9, 0xEE, 0x24, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress1Country -- PKEY_Contact_BusinessAddress1Country</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 119</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress1Country => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 119);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress1Locality -- PKEY_Contact_BusinessAddress1Locality</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 117</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress1Locality => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 117);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress1PostalCode -- PKEY_Contact_BusinessAddress1PostalCode</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 120</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress1PostalCode => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 120);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress1Region -- PKEY_Contact_BusinessAddress1Region</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 118</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress1Region => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 118);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress1Street -- PKEY_Contact_BusinessAddress1Street</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 116</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress1Street => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 116);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress2Country -- PKEY_Contact_BusinessAddress2Country</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 124</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress2Country => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 124);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress2Locality -- PKEY_Contact_BusinessAddress2Locality</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 122</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress2Locality => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 122);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress2PostalCode -- PKEY_Contact_BusinessAddress2PostalCode</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 125</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress2PostalCode => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 125);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress2Region -- PKEY_Contact_BusinessAddress2Region</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 123</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress2Region => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 123);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress2Street -- PKEY_Contact_BusinessAddress2Street</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 121</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress2Street => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 121);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress3Country -- PKEY_Contact_BusinessAddress3Country</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 129</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress3Country => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 129);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress3Locality -- PKEY_Contact_BusinessAddress3Locality</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 127</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress3Locality => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 127);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress3PostalCode -- PKEY_Contact_BusinessAddress3PostalCode</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 130</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress3PostalCode => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 130);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress3Region -- PKEY_Contact_BusinessAddress3Region</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 128</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress3Region => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 128);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddress3Street -- PKEY_Contact_BusinessAddress3Street</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 126</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddress3Street => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 126);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddressCity -- PKEY_Contact_BusinessAddressCity</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>402B5934-EC5A-48C3-93E6-85E86A2D934E, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddressCity => new(0x402B5934, 0xEC5A, 0x48C3, 0x93, 0xE6, 0x85, 0xE8, 0x6A, 0x2D, 0x93, 0x4E, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddressCountry -- PKEY_Contact_BusinessAddressCountry</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>B0B87314-FCF6-4FEB-8DFF-A50DA6AF561C, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddressCountry => new(0xB0B87314, 0xFCF6, 0x4FEB, 0x8D, 0xFF, 0xA5, 0x0D, 0xA6, 0xAF, 0x56, 0x1C, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddressPostalCode -- PKEY_Contact_BusinessAddressPostalCode</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>E1D4A09E-D758-4CD1-B6EC-34A8B5A73F80, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddressPostalCode => new(0xE1D4A09E, 0xD758, 0x4CD1, 0xB6, 0xEC, 0x34, 0xA8, 0xB5, 0xA7, 0x3F, 0x80, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddressPostOfficeBox -- PKEY_Contact_BusinessAddressPostOfficeBox</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>BC4E71CE-17F9-48D5-BEE9-021DF0EA5409, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddressPostOfficeBox => new(0xBC4E71CE, 0x17F9, 0x48D5, 0xBE, 0xE9, 0x02, 0x1D, 0xF0, 0xEA, 0x54, 0x09, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddressState -- PKEY_Contact_BusinessAddressState</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>446F787F-10C4-41CB-A6C4-4D0343551597, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddressState => new(0x446F787F, 0x10C4, 0x41CB, 0xA6, 0xC4, 0x4D, 0x03, 0x43, 0x55, 0x15, 0x97, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessAddressStreet -- PKEY_Contact_BusinessAddressStreet</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>DDD1460F-C0BF-4553-8CE4-10433C908FB0, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessAddressStreet => new(0xDDD1460F, 0xC0BF, 0x4553, 0x8C, 0xE4, 0x10, 0x43, 0x3C, 0x90, 0x8F, 0xB0, 100);

		/// <summary>
		/// Business fax number of the contact.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessFaxNumber -- PKEY_Contact_BusinessFaxNumber</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>91EFF6F3-2E27-42CA-933E-7C999FBE310B, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessFaxNumber => new(0x91EFF6F3, 0x2E27, 0x42CA, 0x93, 0x3E, 0x7C, 0x99, 0x9F, 0xBE, 0x31, 0x0B, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessHomePage -- PKEY_Contact_BusinessHomePage</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>56310920-2491-4919-99CE-EADB06FAFDB2, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessHomePage => new(0x56310920, 0x2491, 0x4919, 0x99, 0xCE, 0xEA, 0xDB, 0x06, 0xFA, 0xFD, 0xB2, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.BusinessTelephone -- PKEY_Contact_BusinessTelephone</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>6A15E5A0-0A1E-4CD7-BB8C-D2F1B0C929BC, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BusinessTelephone => new(0x6A15E5A0, 0x0A1E, 0x4CD7, 0xBB, 0x8C, 0xD2, 0xF1, 0xB0, 0xC9, 0x29, 0xBC, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.CallbackTelephone -- PKEY_CallbackTelephone</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>BF53D1C3-49E0-4F7F-8567-5A821D8AC542, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey CallbackTelephone => new(0xBF53D1C3, 0x49E0, 0x4F7F, 0x85, 0x67, 0x5A, 0x82, 0x1D, 0x8A, 0xC5, 0x42, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.CarTelephone -- PKEY_CarTelephone</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>8FDC6DEA-B929-412B-BA90-397A257465FE, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey CarTelephone => new(0x8FDC6DEA, 0xB929, 0x412B, 0xBA, 0x90, 0x39, 0x7A, 0x25, 0x74, 0x65, 0xFE, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.Children -- PKEY_Children</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>D4729704-8EF1-43EF-9024-2BD381187FD5, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Children => new(0xD4729704, 0x8EF1, 0x43EF, 0x90, 0x24, 0x2B, 0xD3, 0x81, 0x18, 0x7F, 0xD5, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.CompanyMainTelephone -- PKEY_CompanyMainTelephone</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>8589E481-6040-473D-B171-7FA89C2708ED, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey CompanyMainTelephone => new(0x8589E481, 0x6040, 0x473D, 0xB1, 0x71, 0x7F, 0xA8, 0x9C, 0x27, 0x08, 0xED, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.ConnectedServiceDisplayName -- PKEY_Contact_ConnectedServiceDisplayName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{39B77F4F-A104-4863-B395-2DB2AD8F7BC1}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ConnectedServiceDisplayName => new(0x39B77F4F, 0xA104, 0x4863, 0xB3, 0x95, 0x2D, 0xB2, 0xAD, 0x8F, 0x7B, 0xC1, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.ConnectedServiceIdentities -- PKEY_Contact_ConnectedServiceIdentities</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{80F41EB8-AFC4-4208-AA5F-CCE21A627281}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ConnectedServiceIdentities => new(0x80F41EB8, 0xAFC4, 0x4208, 0xAA, 0x5F, 0xCC, 0xE2, 0x1A, 0x62, 0x72, 0x81, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.ConnectedServiceName -- PKEY_Contact_ConnectedServiceName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{B5C84C9E-5927-46B5-A3CC-933C21B78469}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ConnectedServiceName => new(0xB5C84C9E, 0x5927, 0x46B5, 0xA3, 0xCC, 0x93, 0x3C, 0x21, 0xB7, 0x84, 0x69, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.ConnectedServiceSupportedActions -- PKEY_Contact_ConnectedServiceSupportedActions</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A19FB7A9-024B-4371-A8BF-4D29C3E4E9C9}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ConnectedServiceSupportedActions => new(0xA19FB7A9, 0x024B, 0x4371, 0xA8, 0xBF, 0x4D, 0x29, 0xC3, 0xE4, 0xE9, 0xC9, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.DataSuppliers -- PKEY_Contact_DataSuppliers</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{9660C283-FC3A-4A08-A096-EED3AAC46DA2}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DataSuppliers => new(0x9660C283, 0xFC3A, 0x4A08, 0xA0, 0x96, 0xEE, 0xD3, 0xAA, 0xC4, 0x6D, 0xA2, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.Department -- PKEY_Contact_Department</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>FC9F7306-FF8F-4D49-9FB6-3FFE5C0951EC, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Department => new(0xFC9F7306, 0xFF8F, 0x4D49, 0x9F, 0xB6, 0x3F, 0xFE, 0x5C, 0x09, 0x51, 0xEC, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.DisplayBusinessPhoneNumbers -- PKEY_Contact_DisplayBusinessPhoneNumbers</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{364028DA-D895-41FE-A584-302B1BB70A76}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DisplayBusinessPhoneNumbers => new(0x364028DA, 0xD895, 0x41FE, 0xA5, 0x84, 0x30, 0x2B, 0x1B, 0xB7, 0x0A, 0x76, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.DisplayHomePhoneNumbers -- PKEY_Contact_DisplayHomePhoneNumbers</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{5068BCDF-D697-4D85-8C53-1F1CDAB01763}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DisplayHomePhoneNumbers => new(0x5068BCDF, 0xD697, 0x4D85, 0x8C, 0x53, 0x1F, 0x1C, 0xDA, 0xB0, 0x17, 0x63, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.DisplayMobilePhoneNumbers -- PKEY_Contact_DisplayMobilePhoneNumbers</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{9CB0C358-9D7A-46B1-B466-DCC6F1A3D93D}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DisplayMobilePhoneNumbers => new(0x9CB0C358, 0x9D7A, 0x46B1, 0xB4, 0x66, 0xDC, 0xC6, 0xF1, 0xA3, 0xD9, 0x3D, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.DisplayOtherPhoneNumbers -- PKEY_Contact_DisplayOtherPhoneNumbers</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{03089873-8EE8-4191-BD60-D31F72B7900B}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DisplayOtherPhoneNumbers => new(0x03089873, 0x8EE8, 0x4191, 0xBD, 0x60, 0xD3, 0x1F, 0x72, 0xB7, 0x90, 0x0B, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.EmailAddress -- PKEY_Contact_EmailAddress</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>F8FA7FA3-D12B-4785-8A4E-691A94F7A3E7, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey EmailAddress => new(0xF8FA7FA3, 0xD12B, 0x4785, 0x8A, 0x4E, 0x69, 0x1A, 0x94, 0xF7, 0xA3, 0xE7, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.EmailAddress2 -- PKEY_Contact_EmailAddress2</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>38965063-EDC8-4268-8491-B7723172CF29, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey EmailAddress2 => new(0x38965063, 0xEDC8, 0x4268, 0x84, 0x91, 0xB7, 0x72, 0x31, 0x72, 0xCF, 0x29, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.EmailAddress3 -- PKEY_Contact_EmailAddress3</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>644D37B4-E1B3-4BAD-B099-7E7C04966ACA, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey EmailAddress3 => new(0x644D37B4, 0xE1B3, 0x4BAD, 0xB0, 0x99, 0x7E, 0x7C, 0x04, 0x96, 0x6A, 0xCA, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.EmailAddresses -- PKEY_Contact_EmailAddresses</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>84D8F337-981D-44B3-9615-C7596DBA17E3, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey EmailAddresses => new(0x84D8F337, 0x981D, 0x44B3, 0x96, 0x15, 0xC7, 0x59, 0x6D, 0xBA, 0x17, 0xE3, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.EmailName -- PKEY_Contact_EmailName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>CC6F4F24-6083-4BD4-8754-674D0DE87AB8, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey EmailName => new(0xCC6F4F24, 0x6083, 0x4BD4, 0x87, 0x54, 0x67, 0x4D, 0x0D, 0xE8, 0x7A, 0xB8, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.FileAsName -- PKEY_Contact_FileAsName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>F1A24AA7-9CA7-40F6-89EC-97DEF9FFE8DB, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FileAsName => new(0xF1A24AA7, 0x9CA7, 0x40F6, 0x89, 0xEC, 0x97, 0xDE, 0xF9, 0xFF, 0xE8, 0xDB, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.FirstName -- PKEY_Contact_FirstName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>14977844-6B49-4AAD-A714-A4513BF60460, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FirstName => new(0x14977844, 0x6B49, 0x4AAD, 0xA7, 0x14, 0xA4, 0x51, 0x3B, 0xF6, 0x04, 0x60, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.FullName -- PKEY_Contact_FullName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>635E9051-50A5-4BA2-B9DB-4ED056C77296, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FullName => new(0x635E9051, 0x50A5, 0x4BA2, 0xB9, 0xDB, 0x4E, 0xD0, 0x56, 0xC7, 0x72, 0x96, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.Gender -- PKEY_Contact_Gender</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>3C8CEE58-D4F0-4CF9-B756-4E5D24447BCD, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Gender => new(0x3C8CEE58, 0xD4F0, 0x4CF9, 0xB7, 0x56, 0x4E, 0x5D, 0x24, 0x44, 0x7B, 0xCD, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.GenderValue -- PKEY_Contact_GenderValue</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
		///   <item><term><b>Format ID:</b></term><description>{3C8CEE58-D4F0-4CF9-B756-4E5D24447BCD}, 101</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey GenderValue => new(0x3C8CEE58, 0xD4F0, 0x4CF9, 0xB7, 0x56, 0x4E, 0x5D, 0x24, 0x44, 0x7B, 0xCD, 101);

		// Possible discrete values for PKEY_Contact_GenderValue are:
		public enum GenderValues : short
		{
			Unspecified = 0,
			Female      = 1,
			Male        = 2,
		}

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.Hobbies -- PKEY_Contact_$1obbies</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>5DC2253F-5E11-4ADF-9CFE-910DD01E3E70, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Hobbies => new(0x5DC2253F, 0x5E11, 0x4ADF, 0x9C, 0xFE, 0x91, 0x0D, 0xD0, 0x1E, 0x3E, 0x70, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress -- PKEY_Contact_$1omeAddress</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>98F98354-617A-46B8-8560-5B1B64BF1F89, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress => new(0x98F98354, 0x617A, 0x46B8, 0x85, 0x60, 0x5B, 0x1B, 0x64, 0xBF, 0x1F, 0x89, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress1Country -- PKEY_Contact_HomeAddress1Country</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 104</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress1Country => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 104);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress1Locality -- PKEY_Contact_HomeAddress1Locality</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 102</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress1Locality => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 102);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress1PostalCode -- PKEY_Contact_HomeAddress1PostalCode</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 105</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress1PostalCode => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 105);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress1Region -- PKEY_Contact_HomeAddress1Region</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 103</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress1Region => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 103);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress1Street -- PKEY_Contact_HomeAddress1Street</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 101</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress1Street => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 101);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress2Country -- PKEY_Contact_HomeAddress2Country</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 109</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress2Country => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 109);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress2Locality -- PKEY_Contact_HomeAddress2Locality</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 107</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress2Locality => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 107);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress2PostalCode -- PKEY_Contact_HomeAddress2PostalCode</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 110</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress2PostalCode => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 110);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress2Region -- PKEY_Contact_HomeAddress2Region</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 108</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress2Region => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 108);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress2Street -- PKEY_Contact_HomeAddress2Street</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 106</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress2Street => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 106);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress3Country -- PKEY_Contact_HomeAddress3Country</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 114</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress3Country => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 114);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress3Locality -- PKEY_Contact_HomeAddress3Locality</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 112</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress3Locality => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 112);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress3PostalCode -- PKEY_Contact_HomeAddress3PostalCode</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 115</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress3PostalCode => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 115);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress3Region -- PKEY_Contact_HomeAddress3Region</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 113</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress3Region => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 113);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddress3Street -- PKEY_Contact_HomeAddress3Street</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 111</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddress3Street => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 111);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddressCity -- PKEY_Contact_HomeAddressCity</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>176DC63C-2688-4E89-8143-A347800F25E9, 65</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddressCity => new(0x176DC63C, 0x2688, 0x4E89, 0x81, 0x43, 0xA3, 0x47, 0x80, 0x0F, 0x25, 0xE9, 65);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddressCountry -- PKEY_Contact_HomeAddressCountry</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>08A65AA1-F4C9-43DD-9DDF-A33D8E7EAD85, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddressCountry => new(0x08A65AA1, 0xF4C9, 0x43DD, 0x9D, 0xDF, 0xA3, 0x3D, 0x8E, 0x7E, 0xAD, 0x85, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddressPostalCode -- PKEY_Contact_HomeAddressPostalCode</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>8AFCC170-8A46-4B53-9EEE-90BAE7151E62, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddressPostalCode => new(0x8AFCC170, 0x8A46, 0x4B53, 0x9E, 0xEE, 0x90, 0xBA, 0xE7, 0x15, 0x1E, 0x62, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddressPostOfficeBox -- PKEY_Contact_HomeAddressPostOfficeBox</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>7B9F6399-0A3F-4B12-89BD-4ADC51C918AF, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddressPostOfficeBox => new(0x7B9F6399, 0x0A3F, 0x4B12, 0x89, 0xBD, 0x4A, 0xDC, 0x51, 0xC9, 0x18, 0xAF, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddressState -- PKEY_Contact_HomeAddressState</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>C89A23D0-7D6D-4EB8-87D4-776A82D493E5, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddressState => new(0xC89A23D0, 0x7D6D, 0x4EB8, 0x87, 0xD4, 0x77, 0x6A, 0x82, 0xD4, 0x93, 0xE5, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeAddressStreet -- PKEY_Contact_HomeAddressStreet</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>0ADEF160-DB3F-4308-9A21-06237B16FA2A, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeAddressStreet => new(0x0ADEF160, 0xDB3F, 0x4308, 0x9A, 0x21, 0x06, 0x23, 0x7B, 0x16, 0xFA, 0x2A, 100);


		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeEmailAddresses -- PKEY_Contact_HomeEmailAddresses</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{56C90E9D-9D46-4963-886F-2E1CD9A694EF}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeEmailAddresses => new(0x56C90E9D, 0x9D46, 0x4963, 0x88, 0x6F, 0x2E, 0x1C, 0xD9, 0xA6, 0x94, 0xEF, 100);


		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeFaxNumber -- PKEY_Contact_HomeFaxNumber</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>660E04D6-81AB-4977-A09F-82313113AB26, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeFaxNumber => new(0x660E04D6, 0x81AB, 0x4977, 0xA0, 0x9F, 0x82, 0x31, 0x31, 0x13, 0xAB, 0x26, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.HomeTelephone -- PKEY_Contact_HomeTelephone</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>176DC63C-2688-4E89-8143-A347800F25E9, 20</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HomeTelephone => new(0x176DC63C, 0x2688, 0x4E89, 0x81, 0x43, 0xA3, 0x47, 0x80, 0x0F, 0x25, 0xE9, 20);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.IMAddress -- PKEY_Contact_IMAddress</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>D68DBD8A-3374-4B81-9972-3EC30682DB3D, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IMAddress => new(0xD68DBD8A, 0x3374, 0x4B81, 0x99, 0x72, 0x3E, 0xC3, 0x06, 0x82, 0xDB, 0x3D, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.Initials -- PKEY_Contact_Initials</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>F3D8F40D-50CB-44A2-9718-40CB9119495D, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Initials => new(0xF3D8F40D, 0x50CB, 0x44A2, 0x97, 0x18, 0x40, 0xCB, 0x91, 0x19, 0x49, 0x5D, 100);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JA.CompanyNamePhonetic -- PKEY_Contact_JA_CompanyNamePhonetic</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>897B3694-FE9E-43E6-8066-260F590C0100, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JA_CompanyNamePhonetic => new(0x897B3694, 0xFE9E, 0x43E6, 0x80, 0x66, 0x26, 0x0F, 0x59, 0x0C, 0x01, 0x00, 2);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JA.FirstNamePhonetic -- PKEY_Contact_JA_FirstNamePhonetic</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>897B3694-FE9E-43E6-8066-260F590C0100, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JA_FirstNamePhonetic => new(0x897B3694, 0xFE9E, 0x43E6, 0x80, 0x66, 0x26, 0x0F, 0x59, 0x0C, 0x01, 0x00, 3);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JA.LastNamePhonetic -- PKEY_Contact_JA_LastNamePhonetic</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>897B3694-FE9E-43E6-8066-260F590C0100, 4</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JA_LastNamePhonetic => new(0x897B3694, 0xFE9E, 0x43E6, 0x80, 0x66, 0x26, 0x0F, 0x59, 0x0C, 0x01, 0x00, 4);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo1CompanyAddress -- PKEY_Contact_JobInfo1CompanyAddress</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 120</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo1CompanyAddress => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 120);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo1CompanyName -- PKEY_Contact_JobInfo1CompanyName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 102</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo1CompanyName => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 102);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo1Department -- PKEY_Contact_JobInfo1Department</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 106</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo1Department => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 106);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo1Manager -- PKEY_Contact_JobInfo1Manager</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 105</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo1Manager => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 105);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo1OfficeLocation -- PKEY_Contact_JobInfo1OfficeLocation</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 104</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo1OfficeLocation => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 104);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo1Title -- PKEY_Contact_JobInfo1Title</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 103</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo1Title => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 103);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo1YomiCompanyName -- PKEY_Contact_JobInfo1YomiCompanyName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 101</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo1YomiCompanyName => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 101);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo2CompanyAddress -- PKEY_Contact_JobInfo2CompanyAddress</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 121</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo2CompanyAddress => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 121);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo2CompanyName -- PKEY_Contact_JobInfo2CompanyName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 108</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo2CompanyName => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 108);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo2Department -- PKEY_Contact_JobInfo2Department</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 113</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo2Department => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 113);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo2Manager -- PKEY_Contact_JobInfo2Manager</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 112</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo2Manager => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 112);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo2OfficeLocation -- PKEY_Contact_JobInfo2OfficeLocation</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 110</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo2OfficeLocation => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 110);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo2Title -- PKEY_Contact_JobInfo2Title</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 109</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo2Title => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 109);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo2YomiCompanyName -- PKEY_Contact_JobInfo2YomiCompanyName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 107</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo2YomiCompanyName => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 107);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo3CompanyAddress -- PKEY_Contact_JobInfo3CompanyAddress</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 123</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo3CompanyAddress => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 123);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo3CompanyName -- PKEY_Contact_JobInfo3CompanyName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 115</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo3CompanyName => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 115);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo3Department -- PKEY_Contact_JobInfo3Department</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 119</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo3Department => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 119);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo3Manager -- PKEY_Contact_JobInfo3Manager</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 118</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo3Manager => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 118);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo3OfficeLocation -- PKEY_Contact_JobInfo3OfficeLocation</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 117</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo3OfficeLocation => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 117);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo3Title -- PKEY_Contact_JobInfo3Title</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 116</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo3Title => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 116);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.JobInfo3YomiCompanyName -- PKEY_Contact_JobInfo3YomiCompanyName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 114</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobInfo3YomiCompanyName => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 114);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:        </b></term><description>System.Contact.JobTitle -- PKEY_Contact_JobTitle</description></item>
		///   <item><term><b>Type:        </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>176DC63C-2688-4E89-8143-A347800F25E9, 6</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey JobTitle => new(0x176DC63C, 0x2688, 0x4E89, 0x81, 0x43, 0xA3, 0x47, 0x80, 0x0F, 0x25, 0xE9, 6);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:        </b></term><description>System.Contact.Label -- PKEY_Contact_Label</description></item>
		///   <item><term><b>Type:        </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>97B0AD89-DF49-49CC-834E-660974FD755B, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Label => new(0x97B0AD89, 0xDF49, 0x49CC, 0x83, 0x4E, 0x66, 0x09, 0x74, 0xFD, 0x75, 0x5B, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.LastName -- PKEY_Contact_LastName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>8F367200-C270-457C-B1D4-E07C5BCD90C7, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey LastName => new(0x8F367200, 0xC270, 0x457C, 0xB1, 0xD4, 0xE0, 0x7C, 0x5B, 0xCD, 0x90, 0xC7, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.MailingAddress -- PKEY_Contact_MailingAddress</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>C0AC206A-827E-4650-95AE-77E2BB74FCC9, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey MailingAddress => new(0xC0AC206A, 0x827E, 0x4650, 0x95, 0xAE, 0x77, 0xE2, 0xBB, 0x74, 0xFC, 0xC9, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.MiddleName -- PKEY_Contact_MiddleName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>176DC63C-2688-4E89-8143-A347800F25E9, 71</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey MiddleName => new(0x176DC63C, 0x2688, 0x4E89, 0x81, 0x43, 0xA3, 0x47, 0x80, 0x0F, 0x25, 0xE9, 71);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.MobileTelephone -- PKEY_Contact_MobileTelephone</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>176DC63C-2688-4E89-8143-A347800F25E9, 35</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey MobileTelephone => new(0x176DC63C, 0x2688, 0x4E89, 0x81, 0x43, 0xA3, 0x47, 0x80, 0x0F, 0x25, 0xE9, 35);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.NickName -- PKEY_Contact_NickName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>176DC63C-2688-4E89-8143-A347800F25E9, 74</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey NickName => new(0x176DC63C, 0x2688, 0x4E89, 0x81, 0x43, 0xA3, 0x47, 0x80, 0x0F, 0x25, 0xE9, 74);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OfficeLocation -- PKEY_Contact_OfficeLocation</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>176DC63C-2688-4E89-8143-A347800F25E9, 7</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OfficeLocation => new(0x176DC63C, 0x2688, 0x4E89, 0x81, 0x43, 0xA3, 0x47, 0x80, 0x0F, 0x25, 0xE9, 7);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress -- PKEY_Contact_OtherAddress</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>508161FA-313B-43D5-83A1-C1ACCF68622C, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress => new(0x508161FA, 0x313B, 0x43D5, 0x83, 0xA1, 0xC1, 0xAC, 0xCF, 0x68, 0x62, 0x2C, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress1Country -- PKEY_Contact_OtherAddress1Country</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 134</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress1Country => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 134);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress1Locality -- PKEY_Contact_OtherAddress1Locality</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 132</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress1Locality => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 132);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress1PostalCode -- PKEY_Contact_OtherAddress1PostalCode</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 135</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress1PostalCode => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 135);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress1Region -- PKEY_Contact_OtherAddress1Region</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 133</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress1Region => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 133);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress1Street -- PKEY_Contact_OtherAddress1Street</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 131</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress1Street => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 131);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress2Country -- PKEY_Contact_OtherAddress2Country</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 139</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress2Country => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 139);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress2Locality -- PKEY_Contact_OtherAddress2Locality</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 137</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress2Locality => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 137);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress2PostalCode -- PKEY_Contact_OtherAddress2PostalCode</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 140</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress2PostalCode => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 140);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress2Region -- PKEY_Contact_OtherAddress2Region</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 138</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress2Region => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 138);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress2Street -- PKEY_Contact_OtherAddress2Street</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 136</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress2Street => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 136);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress3Country -- PKEY_Contact_OtherAddress3Country</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 144</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress3Country => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 144);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress3Locality -- PKEY_Contact_OtherAddress3Locality</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 142</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress3Locality => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 142);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress3PostalCode -- PKEY_Contact_OtherAddress3PostalCode</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 145</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress3PostalCode => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 145);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress3Region -- PKEY_Contact_OtherAddress3Region</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 143</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress3Region => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 143);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddress3Street -- PKEY_Contact_OtherAddress3Street</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A7B6F596-D678-4BC1-B05F-0203D27E8AA1}, 141</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddress3Street => new(0xA7B6F596, 0xD678, 0x4BC1, 0xB0, 0x5F, 0x02, 0x03, 0xD2, 0x7E, 0x8A, 0xA1, 141);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddressCity -- PKEY_Contact_OtherAddressCity</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>6E682923-7F7B-4F0C-A337-CFCA296687BF, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddressCity => new(0x6E682923, 0x7F7B, 0x4F0C, 0xA3, 0x37, 0xCF, 0xCA, 0x29, 0x66, 0x87, 0xBF, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddressCountry -- PKEY_Contact_OtherAddressCountry</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>8F167568-0AAE-4322-8ED9-6055B7B0E398, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddressCountry => new(0x8F167568, 0x0AAE, 0x4322, 0x8E, 0xD9, 0x60, 0x55, 0xB7, 0xB0, 0xE3, 0x98, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddressPostalCode -- PKEY_Contact_OtherAddressPostalCode</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>95C656C1-2ABF-4148-9ED3-9EC602E3B7CD, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddressPostalCode => new(0x95C656C1, 0x2ABF, 0x4148, 0x9E, 0xD3, 0x9E, 0xC6, 0x02, 0xE3, 0xB7, 0xCD, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddressPostOfficeBox -- PKEY_Contact_OtherAddressPostOfficeBox</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>8B26EA41-058F-43F6-AECC-4035681CE977, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddressPostOfficeBox => new(0x8B26EA41, 0x058F, 0x43F6, 0xAE, 0xCC, 0x40, 0x35, 0x68, 0x1C, 0xE9, 0x77, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddressState -- PKEY_Contact_OtherAddressState</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>71B377D6-E570-425F-A170-809FAE73E54E, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddressState => new(0x71B377D6, 0xE570, 0x425F, 0xA1, 0x70, 0x80, 0x9F, 0xAE, 0x73, 0xE5, 0x4E, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherAddressStreet -- PKEY_Contact_OtherAddressStreet</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>FF962609-B7D6-4999-862D-95180D529AEA, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherAddressStreet => new(0xFF962609, 0xB7D6, 0x4999, 0x86, 0x2D, 0x95, 0x18, 0x0D, 0x52, 0x9A, 0xEA, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.OtherEmailAddresses -- PKEY_Contact_OtherEmailAddresses</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{11D6336B-38C4-4EC9-84D6-EB38D0B150AF}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OtherEmailAddresses => new(0x11D6336B, 0x38C4, 0x4EC9, 0x84, 0xD6, 0xEB, 0x38, 0xD0, 0xB1, 0x50, 0xAF, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.PagerTelephone -- PKEY_Contact_PagerTelephone</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>D6304E01-F8F5-4F45-8B15-D024A6296789, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PagerTelephone => new(0xD6304E01, 0xF8F5, 0x4F45, 0x8B, 0x15, 0xD0, 0x24, 0xA6, 0x29, 0x67, 0x89, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.PersonalTitle -- PKEY_Contact_PersonalTitle</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>176DC63C-2688-4E89-8143-A347800F25E9, 69</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PersonalTitle => new(0x176DC63C, 0x2688, 0x4E89, 0x81, 0x43, 0xA3, 0x47, 0x80, 0x0F, 0x25, 0xE9, 69);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.PhoneNumbersCanonical -- PKEY_Contact_PhoneNumbersCanonical</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{D042D2A1-927E-40B5-A503-6EDBD42A517E}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PhoneNumbersCanonical => new(0xD042D2A1, 0x927E, 0x40B5, 0xA5, 0x03, 0x6E, 0xDB, 0xD4, 0x2A, 0x51, 0x7E, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.Prefix -- PKEY_Contact_Prefix</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{176DC63C-2688-4E89-8143-A347800F25E9}, 75</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Prefix => new(0x176DC63C, 0x2688, 0x4E89, 0x81, 0x43, 0xA3, 0x47, 0x80, 0x0F, 0x25, 0xE9, 75);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.PrimaryAddressCity -- PKEY_Contact_PrimaryAddressCity</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>C8EA94F0-A9E3-4969-A94B-9C62A95324E0, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PrimaryAddressCity => new(0xC8EA94F0, 0xA9E3, 0x4969, 0xA9, 0x4B, 0x9C, 0x62, 0xA9, 0x53, 0x24, 0xE0, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.PrimaryAddressCountry -- PKEY_Contact_PrimaryAddressCountry</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>E53D799D-0F3F-466E-B2FF-74634A3CB7A4, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PrimaryAddressCountry => new(0xE53D799D, 0x0F3F, 0x466E, 0xB2, 0xFF, 0x74, 0x63, 0x4A, 0x3C, 0xB7, 0xA4, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.PrimaryAddressPostalCode -- PKEY_Contact_PrimaryAddressPostalCode</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>18BBD425-ECFD-46EF-B612-7B4A6034EDA0, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PrimaryAddressPostalCode => new(0x18BBD425, 0xECFD, 0x46EF, 0xB6, 0x12, 0x7B, 0x4A, 0x60, 0x34, 0xED, 0xA0, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.PrimaryAddressPostOfficeBox -- PKEY_Contact_PrimaryAddressPostOfficeBox</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>DE5EF3C7-46E1-484E-9999-62C5308394C1, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PrimaryAddressPostOfficeBox => new(0xDE5EF3C7, 0x46E1, 0x484E, 0x99, 0x99, 0x62, 0xC5, 0x30, 0x83, 0x94, 0xC1, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.PrimaryAddressState -- PKEY_Contact_PrimaryAddressState</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>F1176DFE-7138-4640-8B4C-AE375DC70A6D, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PrimaryAddressState => new(0xF1176DFE, 0x7138, 0x4640, 0x8B, 0x4C, 0xAE, 0x37, 0x5D, 0xC7, 0x0A, 0x6D, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.PrimaryAddressStreet -- PKEY_Contact_PrimaryAddressStreet</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>63C25B20-96BE-488F-8788-C09C407AD812, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PrimaryAddressStreet => new(0x63C25B20, 0x96BE, 0x488F, 0x87, 0x88, 0xC0, 0x9C, 0x40, 0x7A, 0xD8, 0x12, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.PrimaryEmailAddress -- PKEY_Contact_PrimaryEmailAddress</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>176DC63C-2688-4E89-8143-A347800F25E9, 48</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PrimaryEmailAddress => new(0x176DC63C, 0x2688, 0x4E89, 0x81, 0x43, 0xA3, 0x47, 0x80, 0x0F, 0x25, 0xE9, 48);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.PrimaryTelephone -- PKEY_Contact_PrimaryTelephone</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>176DC63C-2688-4E89-8143-A347800F25E9, 25</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PrimaryTelephone => new(0x176DC63C, 0x2688, 0x4E89, 0x81, 0x43, 0xA3, 0x47, 0x80, 0x0F, 0x25, 0xE9, 25);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.Profession -- PKEY_Contact_Profession</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>7268AF55-1CE4-4F6E-A41F-B6E4EF10E4A9, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Profession => new(0x7268AF55, 0x1CE4, 0x4F6E, 0xA4, 0x1F, 0xB6, 0xE4, 0xEF, 0x10, 0xE4, 0xA9, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.SpouseName -- PKEY_Contact_SpouseName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>9D2408B6-3167-422B-82B0-F583B7A7CFE3, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SpouseName => new(0x9D2408B6, 0x3167, 0x422B, 0x82, 0xB0, 0xF5, 0x83, 0xB7, 0xA7, 0xCF, 0xE3, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.Suffix -- PKEY_Contact_Suffix</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>176DC63C-2688-4E89-8143-A347800F25E9, 73</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Suffix => new(0x176DC63C, 0x2688, 0x4E89, 0x81, 0x43, 0xA3, 0x47, 0x80, 0x0F, 0x25, 0xE9, 73);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.TelexNumber -- PKEY_Contact_TelexNumber</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>C554493C-C1F7-40C1-A76C-EF8C0614003E, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TelexNumber => new(0xC554493C, 0xC1F7, 0x40C1, 0xA7, 0x6C, 0xEF, 0x8C, 0x06, 0x14, 0x00, 0x3E, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.TTYTDDTelephone -- PKEY_Contact_TTYTDDTelephone</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>AAF16BAC-2B55-45E6-9F6D-415EB94910DF, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TTYTDDTelephone => new(0xAAF16BAC, 0x2B55, 0x45E6, 0x9F, 0x6D, 0x41, 0x5E, 0xB9, 0x49, 0x10, 0xDF, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.WebPage -- PKEY_Contact_WebPage</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 18</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey WebPage => new(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 18);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.Webpage2 -- PKEY_Contact_Webpage2</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 124</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Webpage2 => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 124);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Contact.Webpage3 -- PKEY_Contact_Webpage3</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00F63DD8-22BD-4A5D-BA34-5CB0B9BDCB03}, 125</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Webpage3 => new(0x00F63DD8, 0x22BD, 0x4A5D, 0xBA, 0x34, 0x5C, 0xB0, 0xB9, 0xBD, 0xCB, 0x03, 125);
	}
}
