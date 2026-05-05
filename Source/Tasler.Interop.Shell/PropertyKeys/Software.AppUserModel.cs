
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Software
	{
		public static class AppUserModel
		{
			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.AppUserModel.ExcludeFromShowInNewInstall -- PKEY_AppUserModel_ExcludeFromShowInNewInstall</description></item>
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 8</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ExcludeFromShowInNewInstall => new(0x9F4C2855, 0x9F79, 0x4B39, 0xA8, 0xD0, 0xE1, 0xD4, 0x2D, 0xE1, 0xD5, 0xF3, 8);

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.AppUserModel.ID -- PKEY_AppUserModel_ID</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 5</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ID => new(0x9F4C2855, 0x9F79, 0x4B39, 0xA8, 0xD0, 0xE1, 0xD4, 0x2D, 0xE1, 0xD5, 0xF3, 5);

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.AppUserModel.IsDestListSeparator -- PKEY_AppUserModel_IsDestListSeparator</description></item>
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 6</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey IsDestListSeparator => new(0x9F4C2855, 0x9F79, 0x4B39, 0xA8, 0xD0, 0xE1, 0xD4, 0x2D, 0xE1, 0xD5, 0xF3, 6);

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.AppUserModel.PreventPinning -- PKEY_AppUserModel_PreventPinning</description></item>
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 9</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey PreventPinning => new(0x9F4C2855, 0x9F79, 0x4B39, 0xA8, 0xD0, 0xE1, 0xD4, 0x2D, 0xE1, 0xD5, 0xF3, 9);

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.AppUserModel.RelaunchCommand -- PKEY_AppUserModel_RelaunchCommand</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey RelaunchCommand => new(0x9F4C2855, 0x9F79, 0x4B39, 0xA8, 0xD0, 0xE1, 0xD4, 0x2D, 0xE1, 0xD5, 0xF3, 2);

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.AppUserModel.RelaunchDisplayNameResource -- PKEY_AppUserModel_RelaunchDisplayNameResource</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 4</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey RelaunchDisplayNameResource => new(0x9F4C2855, 0x9F79, 0x4B39, 0xA8, 0xD0, 0xE1, 0xD4, 0x2D, 0xE1, 0xD5, 0xF3, 4);

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.AppUserModel.RelaunchIconResource -- PKEY_AppUserModel_RelaunchIconResource</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 3</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey RelaunchIconResource => new(0x9F4C2855, 0x9F79, 0x4B39, 0xA8, 0xD0, 0xE1, 0xD4, 0x2D, 0xE1, 0xD5, 0xF3, 3);

			/// <summary>
			/// A command line that includes a fully qualified file path, which can include environment variables
			/// and arguments, that will launch the settings application corresponding to the shortcut (.lnk file)
			/// this property is included in. This property may be used by components such as the Start Menu to
			/// provide a settings verb.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.AppUserModel.SettingsCommand -- PKEY_AppUserModel_SettingsCommand</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 38</description></item>
			/// </list>
			/// </remarks>
			/// <example>"%ProgramFiles%\My App\Settings.exe"</example>
			/// <example>"%ProgramFiles%\My App\My-app.exe" /settings</example>
			public static PropertyKey SettingsCommand => new(0x9F4C2855, 0x9F79, 0x4B39, 0xA8, 0xD0, 0xE1, 0xD4, 0x2D, 0xE1, 0xD5, 0xF3, 38);

			/// <summary>
			/// Set this property on a shortcut to (1) prevent an application from being automatically pinned to
			/// Start screen upon installation; or (2) indicate that an item is programmatically added to launcher
			/// via user action (which implies automatically pin to Start and delete on unpin).
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.AppUserModel.StartPinOption -- PKEY_AppUserModel_StartPinOption</description></item>r
			///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
			///   <item><term><b>Format ID:</b></term><description>{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 12</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey StartPinOption => new(0x9F4C2855, 0x9F79, 0x4B39, 0xA8, 0xD0, 0xE1, 0xD4, 0x2D, 0xE1, 0xD5, 0xF3, 12);

			/// <summary>Possible discrete values for PKEY_AppUserModel_StartPinOption.</summary>
			public enum StartPinOptions
			{
				Default = 0,
				NoPinInInstall = 1,
				UserPinned = 2,
			}

			/// <summary>
			/// Used to CoCreate an INotificationActivationCallback interface to notify about toast activations.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.AppUserModel.ToastActivatorCLSID -- PKEY_AppUserModel_ToastActivatorCLSID</description></item>r
			///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
			///   <item><term><b>Format ID:</b></term><description>{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 26</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ToastActivatorCLSID => new(0x9F4C2855, 0x9F79, 0x4B39, 0xA8, 0xD0, 0xE1, 0xD4, 0x2D, 0xE1, 0xD5, 0xF3, 26);

			/// <summary>
			/// A command line that includes a fully qualified file path, which can include environment variables
			/// and arguments, that when launched will uninstall the application corresponding to the shortcut
			/// (.lnk file) this property is included in. This property may be used by components such as the
			/// Start Menu to provide an uninstall verb. he command should execute without displaying UI, as this
			/// avoids dismissing the Start Menu, but it may show UI if needed.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.AppUserModel.UninstallCommand -- PKEY_AppUserModel_UninstallCommand</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 37</description></item>
			/// </list>
			/// </remarks>
			/// <example>%SystemRoot%\system32\msiexec.exe /x {A7654BA2-D4AB-4510-AADF-253EA74869C5} /q</example>
			/// <example>"%ProgramFiles%\My App\Uninstall.exe" /q /f</example>
			public static PropertyKey UninstallCommand => new(0x9F4C2855, 0x9F79, 0x4B39, 0xA8, 0xD0, 0xE1, 0xD4, 0x2D, 0xE1, 0xD5, 0xF3, 37);

			/// <summary>
			/// Suggests where to look for the VisualElementsManifest for a Win32 app.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.AppUserModel.VisualElementsManifestHintPath -- PKEY_AppUserModel_VisualElementsManifestHintPath</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}, 31</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey VisualElementsManifestHintPath => new(0x9F4C2855, 0x9F79, 0x4B39, 0xA8, 0xD0, 0xE1, 0xD4, 0x2D, 0xE1, 0xD5, 0xF3, 31);
		}
	}
}
