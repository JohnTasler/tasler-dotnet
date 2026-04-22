
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Address
	{
		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name</b></term>    <description>System.Address.Country -- PKEY_Address_Country</description></item>
		///   <item><term><b>Type</b></term>    <description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>FormatID</b></term><description>{C07B4199-E1DF-4493-B1E1-DE5946FB58F8}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Country => new(0xC07B4199, 0xE1DF, 0x4493, 0xB1, 0xE1, 0xDE, 0x59, 0x46, 0xFB, 0x58, 0xF8, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name</b></term>    <description>System.Address.CountryCode -- PKEY_Address_CountryCode</description></item>
		///   <item><term><b>Type</b></term>    <description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>FormatID</b></term><description>{C07B4199-E1DF-4493-B1E1-DE5946FB58F8}, 101</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey CountryCode => new(0xC07B4199, 0xE1DF, 0x4493, 0xB1, 0xE1, 0xDE, 0x59, 0x46, 0xFB, 0x58, 0xF8, 101);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name</b></term>    <description>System.Address.Region -- PKEY_Address_Region</description></item>
		///   <item><term><b>Type</b></term>    <description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>FormatID</b></term><description>{C07B4199-E1DF-4493-B1E1-DE5946FB58F8}, 102</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Region => new(0xC07B4199, 0xE1DF, 0x4493, 0xB1, 0xE1, 0xDE, 0x59, 0x46, 0xFB, 0x58, 0xF8, 102);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name</b></term>    <description>System.Address.RegionCode -- PKEY_Address_RegionCode</description></item>
		///   <item><term><b>Type</b></term>    <description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>FormatID</b></term><description>{C07B4199-E1DF-4493-B1E1-DE5946FB58F8}, 103</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey RegionCode => new(0xC07B4199, 0xE1DF, 0x4493, 0xB1, 0xE1, 0xDE, 0x59, 0x46, 0xFB, 0x58, 0xF8, 103);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name</b></term>    <description>System.Address.Town -- PKEY_Address_Town</description></item>
		///   <item><term><b>Type</b></term>    <description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>FormatID</b></term><description>{C07B4199-E1DF-4493-B1E1-DE5946FB58F8}, 104</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Town => new(0xC07B4199, 0xE1DF, 0x4493, 0xB1, 0xE1, 0xDE, 0x59, 0x46, 0xFB, 0x58, 0xF8, 104);
	}
}
