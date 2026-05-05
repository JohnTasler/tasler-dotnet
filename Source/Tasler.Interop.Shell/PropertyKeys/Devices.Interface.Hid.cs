
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{
		public static partial class Interface
		{
			public static class Hid
			{
				/// <summary>
				/// Indicates if a HID device is a Read-Only device.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Hid.IsReadOnly -- PKEY_DeviceInterface_Hid_IsReadOnly</description></item>r
				///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
				///   <item><term><b>Format ID:</b></term><description>{CBF38310-4A17-4310-A1EB-247F0B67593B}, 4</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey IsReadOnly => new(0xCBF38310, 0x4A17, 0x4310, 0xA1, 0xEB, 0x24, 0x7F, 0x0B, 0x67, 0x59, 0x3B, 4);

				/// <summary>
				/// HID device Product Id.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Hid.ProductId -- PKEY_DeviceInterface_Hid_ProductId</description></item>r
				///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
				///   <item><term><b>Format ID:</b></term><description>{CBF38310-4A17-4310-A1EB-247F0B67593B}, 6</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey ProductId => new(0xCBF38310, 0x4A17, 0x4310, 0xA1, 0xEB, 0x24, 0x7F, 0x0B, 0x67, 0x59, 0x3B, 6);

				/// <summary>
				/// HID device Usage Id.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Hid.UsageId -- PKEY_DeviceInterface_Hid_UsageId</description></item>r
				///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
				///   <item><term><b>Format ID:</b></term><description>{CBF38310-4A17-4310-A1EB-247F0B67593B}, 3</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey UsageId => new(0xCBF38310, 0x4A17, 0x4310, 0xA1, 0xEB, 0x24, 0x7F, 0x0B, 0x67, 0x59, 0x3B, 3);

				/// <summary>
				/// HID device Usage Page.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Hid.UsagePage -- PKEY_DeviceInterface_Hid_UsagePage</description></item>r
				///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
				///   <item><term><b>Format ID:</b></term><description>{CBF38310-4A17-4310-A1EB-247F0B67593B}, 2</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey UsagePage => new(0xCBF38310, 0x4A17, 0x4310, 0xA1, 0xEB, 0x24, 0x7F, 0x0B, 0x67, 0x59, 0x3B, 2);

				/// <summary>
				/// HID device Vendor Id.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Hid.VendorId -- PKEY_DeviceInterface_Hid_VendorId</description></item>r
				///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
				///   <item><term><b>Format ID:</b></term><description>{CBF38310-4A17-4310-A1EB-247F0B67593B}, 5</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey VendorId => new(0xCBF38310, 0x4A17, 0x4310, 0xA1, 0xEB, 0x24, 0x7F, 0x0B, 0x67, 0x59, 0x3B, 5);

				/// <summary>
				/// HID device Version Number.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Hid.VersionNumber -- PKEY_DeviceInterface_Hid_VersionNumber</description></item>r
				///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
				///   <item><term><b>Format ID:</b></term><description>{CBF38310-4A17-4310-A1EB-247F0B67593B}, 7</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey VersionNumber => new(0xCBF38310, 0x4A17, 0x4310, 0xA1, 0xEB, 0x24, 0x7F, 0x0B, 0x67, 0x59, 0x3B, 7);
			}
		}
	}
