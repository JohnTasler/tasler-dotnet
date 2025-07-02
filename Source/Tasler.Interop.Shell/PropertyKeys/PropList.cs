
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class PropList
	{
		/// <summary>
		/// The list of properties to show in the file operation conflict resolution dialog.
		/// Properties with empty values will not be displayed. Register under the regvalue of "ConflictPrompt".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.PropList.ConflictPrompt -- PKEY_ConflictPrompt</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>C9944A21-A406-48FE-8225-AEC7E24C211B, 11</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ConflictPrompt => new(0xC9944A21, 0xA406, 0x48FE, 0x82, 0x25, 0xAE, 0xC7, 0xE2, 0x4C, 0x21, 0x1B, 11);

		/// <summary>
		/// The list of properties to show in the listview on extended tiles.
		/// Register under the regvalue of "ExtendedTileInfo".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.PropList.ExtendedTileInfo -- PKEY_ExtendedTileInfo</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>C9944A21-A406-48FE-8225-AEC7E24C211B, 9</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ExtendedTileInfo => new(0xC9944A21, 0xA406, 0x48FE, 0x82, 0x25, 0xAE, 0xC7, 0xE2, 0x4C, 0x21, 0x1B, 9);

		/// <summary>
		/// The list of properties to show in the file operation confirmation dialog.
		/// Properties with empty values will not be displayed. If this list is not specified,
		/// then the InfoTip property list is used instead. Register under the regvalue of "FileOperationPrompt".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.PropList.FileOperationPrompt -- PKEY_FileOperationPrompt</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>C9944A21-A406-48FE-8225-AEC7E24C211B, 10</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FileOperationPrompt => new(0xC9944A21, 0xA406, 0x48FE, 0x82, 0x25, 0xAE, 0xC7, 0xE2, 0x4C, 0x21, 0x1B, 10);

		/// <summary>
		/// The list of all the properties to show in the details page.
		/// Property groups can be included in this list in order to more easily organize the UI.
		/// Register under the regvalue of "FullDetails".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.PropList.FullDetails -- PKEY_FullDetails</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>C9944A21-A406-48FE-8225-AEC7E24C211B, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FullDetails => new(0xC9944A21, 0xA406, 0x48FE, 0x82, 0x25, 0xAE, 0xC7, 0xE2, 0x4C, 0x21, 0x1B, 2);

		/// <summary>
		/// The list of properties to show in the infotip.
		/// Properties with empty values will not be displayed. Register under the regvalue of "InfoTip".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.PropList.InfoTip -- PKEY_InfoTip</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>C9944A21-A406-48FE-8225-AEC7E24C211B, 4 (PID_PROPLIST_INFOTIP)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey InfoTip => new(0xC9944A21, 0xA406, 0x48FE, 0x82, 0x25, 0xAE, 0xC7, 0xE2, 0x4C, 0x21, 0x1B, 4);

		/// <summary>
		/// The list of properties that are considered 'non-personal'. When told to remove all non-personal properties 
		/// from a given file, the system will leave these particular properties untouched.
		/// Register under the regvalue of "NonPersonal".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.PropList.NonPersonal -- PKEY_NonPersonal</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>49D1091F-082E-493F-B23F-D2308AA9668C, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey NonPersonal => new(0x49D1091F, 0x082E, 0x493F, 0xB2, 0x3F, 0xD2, 0x30, 0x8A, 0xA9, 0x66, 0x8C, 100);

		/// <summary>
		/// The list of properties to display in the preview pane.  Register under the regvalue of "PreviewDetails".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.PropList.PreviewDetails -- PKEY_PreviewDetails</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>C9944A21-A406-48FE-8225-AEC7E24C211B, 8</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PreviewDetails => new(0xC9944A21, 0xA406, 0x48FE, 0x82, 0x25, 0xAE, 0xC7, 0xE2, 0x4C, 0x21, 0x1B, 8);

		/// <summary>
		/// The one or two properties to display in the preview pane title section.
		/// The optional second property is displayed as a subtitle.  Register under the regvalue of "PreviewTitle".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.PropList.PreviewTitle -- PKEY_PreviewTitle</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>C9944A21-A406-48FE-8225-AEC7E24C211B, 6</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PreviewTitle => new(0xC9944A21, 0xA406, 0x48FE, 0x82, 0x25, 0xAE, 0xC7, 0xE2, 0x4C, 0x21, 0x1B, 6);

		/// <summary>
		/// The list of properties to show in the infotip when the item is on a slow network.
		/// Properties with empty values will not be displayed. Register under the regvalue of "QuickTip".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.PropList.QuickTip -- PKEY_QuickTip</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>C9944A21-A406-48FE-8225-AEC7E24C211B, 5 (PID_PROPLIST_QUICKTIP)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey QuickTip => new(0xC9944A21, 0xA406, 0x48FE, 0x82, 0x25, 0xAE, 0xC7, 0xE2, 0x4C, 0x21, 0x1B, 5);

		/// <summary>
		/// The list of properties to show in the listview on tiles. Register under the regvalue of "TileInfo".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.PropList.TileInfo -- PKEY_TileInfo</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>C9944A21-A406-48FE-8225-AEC7E24C211B, 3 (PID_PROPLIST_TILEINFO)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TileInfo => new(0xC9944A21, 0xA406, 0x48FE, 0x82, 0x25, 0xAE, 0xC7, 0xE2, 0x4C, 0x21, 0x1B, 3);

		/// <summary>
		/// The list of properties to display in the XP webview details panel. Obsolete.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.PropList.XPDetailsPanel -- PKEY_XPDetailsPanel</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_WebView) F2275480-F782-4291-BD94-F13693513AEC, 0 (PID_DISPLAY_PROPERTIES)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey XPDetailsPanel => new(0xF2275480, 0xF782, 0x4291, 0xBD, 0x94, 0xF1, 0x36, 0x93, 0x51, 0x3A, 0xEC, 0);
	}
}
