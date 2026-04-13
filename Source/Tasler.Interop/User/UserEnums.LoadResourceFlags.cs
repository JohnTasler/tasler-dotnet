namespace Tasler.Interop.User;

[Flags]
public enum LoadResourceFlags : uint
{
	/// <summary>
	/// When the uType parameter specifies IMAGE_BITMAP, causes the function to return a DIB section
	/// bitmap rather than a compatible bitmap. This flag is useful for loading a bitmap without
	/// mapping it to the colors of the display device.
	/// </summary>
	CreateDibSection = 0x00002000,

	/// <summary>The default flag; it does nothing. All it means is "not <see cref="Monochrome" />.
	DefaultColor = 0x00000000,

	/// <summary>
	/// Uses the width or height specified by the system metric values for cursors or icons, if the
	/// cxDesired or cyDesired values are set to zero. If this flag is not specified and cxDesired
	/// and cyDesired are set to zero, the function uses the actual resource size. If the resource
	/// contains multiple images, the function uses the size of the first image.
	/// </summary>
	DefaultSize = 0x00000040,

	/// <summary>
	/// Loads the standalone image from the file specified by name (icon, cursor, or bitmap file).
	/// </summary>
	LoadFromFile = 0x00000010,

	/// <summary>
	///   Searches the color table for the image and replaces the following shades of gray with the
	///   corresponding 3-D color.<br/>
	///   <list type="bullet">
	///     <item><term>Dk Gray,</term><description>RGB(128,128,128) with COLOR_3DSHADOW</description></item>
	///     <item><term>Gray,</term><description>RGB(192,192,192) with COLOR_3DFACE</description></item>
	///     <item><term>Lt Gray,</term><description>RGB(223,223,223) with COLOR_3DLIGHT</description></item>
	///   </list>
	///   <para>
	///     Do not use this option if you are loading a bitmap with a color depth greater than 8bpp.
	///   </para>
	/// </summary>
	LoadMap3dColors = 0x00001000,

	/// <summary>
	///   <para>
	///     Retrieves the color value of the first pixel in the image and replaces the corresponding
	///     entry in the color table with the default window color (COLOR_WINDOW). All pixels in the
	///     image that use that entry become the default window color. This value applies only to
	///     images that have corresponding color tables.
	///   </para>
	///   <para>
	///     Do not use this option if you are loading a bitmap with a color depth greater than 8bpp.
	///   </para>
	///   <para>
	///     If fuLoad includes both the <see cref="LoadTransparent" /> and
	///     <see cref="LoadMap3dColors" /> values, <see cref="LoadTransparent" /> takes precedence.
	///     However, the color table entry is replaced with COLOR_3DFACE rather than COLOR_WINDOW.
	///   </para>
	/// </summary>
	LoadTransparent = 0x00000020,

	/// <summary>Loads the image in black and white.</summary>
	Monochrome = 0x00000001,

	/// <summary>
	///   <para>
	///     Shares the image handle if the image is loaded multiple times. If <see cref="Shared" />
	///     is not set, a second call to LoadImage for the same resource will load the image again
	///     and return a different handle.
	///   </para>
	///   <para>
	///     When you use this flag, the system will destroy the resource when it is no longer needed.
	///   </para>
	///   <para>
	///     When loading a system icon or cursor, you must use <see cref="Shared" /> or the function
	///     will fail to load the resource.
	///   </para>
	///   <para>
	///     This function finds the first image in the cache with the requested resource name,
	///     regardless of the size requested.
	///   </para>
	///   <para>
	///     Do not use <see cref="Shared" /> for images that have non-standard sizes, that may
	///     change after loading, or that are loaded from a file.
	///   </para>
	/// </summary>
	Shared = 0x00008000,

	/// <summary>Uses true VGA colors.</summary>
	VgaColor = 0x00000080,
}
