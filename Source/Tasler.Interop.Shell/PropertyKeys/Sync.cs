
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Sync
	{
		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Sync.Comments -- PKEY_Comments</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>7BD5533E-AF15-44DB-B8C8-BD6624E1D032, 13</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Comments => new(0x7BD5533E, 0xAF15, 0x44DB, 0xB8, 0xC8, 0xBD, 0x66, 0x24, 0xE1, 0xD0, 0x32, 13);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Sync.ConflictDescription -- PKEY_ConflictDescription</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>CE50C159-2FB8-41FD-BE68-D3E042E274BC, 4</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ConflictDescription => new(0xCE50C159, 0x2FB8, 0x41FD, 0xBE, 0x68, 0xD3, 0xE0, 0x42, 0xE2, 0x74, 0xBC, 4);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Sync.ConflictFirstLocation -- PKEY_ConflictFirstLocation</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>CE50C159-2FB8-41FD-BE68-D3E042E274BC, 6</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ConflictFirstLocation => new(0xCE50C159, 0x2FB8, 0x41FD, 0xBE, 0x68, 0xD3, 0xE0, 0x42, 0xE2, 0x74, 0xBC, 6);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Sync.ConflictSecondLocation -- PKEY_ConflictSecondLocation</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>CE50C159-2FB8-41FD-BE68-D3E042E274BC, 7</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ConflictSecondLocation => new(0xCE50C159, 0x2FB8, 0x41FD, 0xBE, 0x68, 0xD3, 0xE0, 0x42, 0xE2, 0x74, 0xBC, 7);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Sync.HandlerCollectionID -- PKEY_HandlerCollectionID</description></item>
		///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
		///   <item><term><b>Format ID:</b></term><description>7BD5533E-AF15-44DB-B8C8-BD6624E1D032, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HandlerCollectionID => new(0x7BD5533E, 0xAF15, 0x44DB, 0xB8, 0xC8, 0xBD, 0x66, 0x24, 0xE1, 0xD0, 0x32, 2);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Sync.HandlerID -- PKEY_HandlerID</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>7BD5533E-AF15-44DB-B8C8-BD6624E1D032, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HandlerID => new(0x7BD5533E, 0xAF15, 0x44DB, 0xB8, 0xC8, 0xBD, 0x66, 0x24, 0xE1, 0xD0, 0x32, 3);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Sync.HandlerName -- PKEY_HandlerName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>CE50C159-2FB8-41FD-BE68-D3E042E274BC, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HandlerName => new(0xCE50C159, 0x2FB8, 0x41FD, 0xBE, 0x68, 0xD3, 0xE0, 0x42, 0xE2, 0x74, 0xBC, 2);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Sync.HandlerType -- PKEY_HandlerType</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>7BD5533E-AF15-44DB-B8C8-BD6624E1D032, 8</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HandlerType => new(0x7BD5533E, 0xAF15, 0x44DB, 0xB8, 0xC8, 0xBD, 0x66, 0x24, 0xE1, 0xD0, 0x32, 8);

		/// <summary>Possible discrete values for PKEY_HandlerType.</summary>
		public enum HandlerTypeValues : uint
		{
			Other = 0,
			Programs = 1,
			Devices = 2,
			Folders = 3,
			WebServices = 4,
			Computers = 5,
		}

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Sync.HandlerTypeLabel -- PKEY_HandlerTypeLabel</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>7BD5533E-AF15-44DB-B8C8-BD6624E1D032, 9</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HandlerTypeLabel => new(0x7BD5533E, 0xAF15, 0x44DB, 0xB8, 0xC8, 0xBD, 0x66, 0x24, 0xE1, 0xD0, 0x32, 9);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Sync.ItemID -- PKEY_ItemID</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>7BD5533E-AF15-44DB-B8C8-BD6624E1D032, 6</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ItemID => new(0x7BD5533E, 0xAF15, 0x44DB, 0xB8, 0xC8, 0xBD, 0x66, 0x24, 0xE1, 0xD0, 0x32, 6);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Sync.ItemName -- PKEY_ItemName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>CE50C159-2FB8-41FD-BE68-D3E042E274BC, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ItemName => new(0xCE50C159, 0x2FB8, 0x41FD, 0xBE, 0x68, 0xD3, 0xE0, 0x42, 0xE2, 0x74, 0xBC, 3);
	}
}
