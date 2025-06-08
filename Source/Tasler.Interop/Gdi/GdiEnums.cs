using System.Runtime.InteropServices;
using CommunityToolkit.Diagnostics;

namespace Tasler.Interop.Gdi;

/// <summary>Background modes.</summary>
public enum BackgroundMode
{
	Transparent = 1,
	Opaque = 2,
}

/// <summary>Binary raster operations.</summary>
public enum ROP2
{
	/// <summary>0 </summary>
	Black           =  1,
	/// <summary>DP</summary>
	NotMergePen     =  2,
	/// <summary>DP</summary>
	MaskNotPen      =  3,
	/// <summary>PN</summary>
	NotCopyPen      =  4,
	/// <summary>PDna</summary>
	MaskPenNot      =  5,
	/// <summary>Dn</summary>
	Not             =  6,
	/// <summary>DPx</summary>
	XorPen          =  7,
	/// <summary>DPan</summary>
	NotMaskPen      =  8,
	/// <summary>DPa</summary>
	MaskPen         =  9,
	/// <summary>DPxn</summary>
	NotXorPen       = 10,
	/// <summary>D </summary>
	Nop             = 11,
	/// <summary>DPno</summary>
	MergeNotPen     = 12,
	/// <summary>P </summary>
	CopyPen         = 13,
	/// <summary>PDno</summary>
	MergePenNot     = 14,
	/// <summary>DPo</summary>
	MergePen        = 15,
	/// <summary>1</summary>
	White           = 16,
}

/// <summary>Ternary raster operations.</summary>
public enum ROP3 : uint
{
	/// <summary>dest = source</summary
	SrcCopy        = 0x00CC0020,
	/// <summary>dest = source OR dest</summary>
	SrcPaint       = 0x00EE0086,
	/// <summary>dest = source AND dest</summary>
	SrcAnd         = 0x008800C6,
	/// <summary>dest = source XOR dest</summary>
	SrcInvert      = 0x00660046,
	/// <summary>dest = source AND (NOT dest )</summary>
	SrcErase       = 0x00440328,
	/// <summary>dest = (NOT source)</summary>
	NotSrcCopy     = 0x00330008,
	/// <summary>dest = (NOT src) AND (NOT dest)</summary>
	NotSrcErase    = 0x001100A6,
	/// <summary>dest = (source AND pattern)</summary>
	MergeCopy      = 0x00C000CA,
	/// <summary>dest = (NOT source) OR dest</summary>
	MergePaint     = 0x00BB0226,
	/// <summary>dest = pattern</summary>
	PatCopy        = 0x00F00021,
	/// <summary>dest = DPSnoo</summary>
	PatPaint       = 0x00FB0A09,
	/// <summary>dest = pattern XOR dest</summary>
	PatInvert      = 0x005A0049,
	/// <summary>dest = (NOT dest)</summary>
	DstInvert      = 0x00550009,
	/// <summary>dest = BLACK</summary>
	Blackness      = 0x00000042,
	/// <summary>dest = WHITE</summary>
	Whiteness      = 0x00FF0062,
	/// <summary>Do not Mirror the bitmap in this call.</summary>
	NoMirrorBitmap = 0x80000000,
	/// <summary>Include layered windows.</summary>
	CaptureBlt     = 0x40000000,
}

/// <summary>StretchBltMode</summary>
public enum StretchBltMode
{
	/// <summary>
	/// Performs a Boolean AND operation using the color values for the eliminated and existing
	/// pixels. If the bitmap is a monochrome bitmap, this mode preserves black pixels at the
	/// expense of white pixels.
	/// </summary>
	BlackOnWhite = 1,

	/// <summary>
	/// Deletes the pixels. This mode deletes all eliminated lines of pixels without trying to
	/// preserve their information.
	/// </summary>
	ColorOnColor = 3,

	/// <summary>
	/// Maps pixels from the source rectangle into blocks of pixels in the destination rectangle.
	/// The average color over the destination block of pixels approximates the color of the source pixels.
	/// </summary>
	/// <remarks>
	/// After setting the <see cref="Halftone"/> stretching mode, an application must call the
	/// <c>SetBrushOrgEx</c> function to set the brush origin. If it fails to do so, brush misalignment occurs.
	/// </remarks>
	Halftone = 4,

	/// <summary>
	/// Performs a Boolean OR operation using the color values for the eliminated and existing pixels.
	/// If the bitmap is a monochrome bitmap, this mode preserves white pixels at the expense of black pixels.
	/// </summary>
	WhiteOnBlack = 2,

	/// <summary>Same as <see cref="BlackOnWhite"/>.</summary>
	AndScans = BlackOnWhite,

	/// <summary>Same as <see cref="ColorOnColor"/>.</summary>
	DeleteScans = ColorOnColor,

	/// <summary>Same as <see cref="WhiteOnBlack"/>.</summary>
	OrScans = WhiteOnBlack,
}

/// <summary>
/// The type option of the <see cref="PenTypeStyle"/> structure.
/// </summary>
/// <summary>Brush styles.</summary>
public enum BrushStyle
{
	Solid = 0,
	Null = 1,
	Hatched = 2,
	Pattern = 3,
	Indexed = 4,
	DibPattern = 5,
	DibPatternPt = 6,
	PatTern8x8 = 7,
	DibPattern8x8 = 8,
	MonoPattern = 9,
}

/// <summary>
/// Hatch	styles for brushes and pens.
/// </summary>
public enum HatchStyle
{
	/// <summary>Horizontal hatch.</summary>
	Horizontal       = 0,      // -----  Horizontal hatch
	/// <summary>Vertical hatch</summary>
	Vertical         = 1,      // |||||  Vertical hatch
	/// <summary>45-degree downward hatch (left to right)</summary>
	ForwardDiagonal  = 2,      // \\\\\  45-degree downward hatch (left to right)
	/// <summary>45-degree upward hatch (left to right)</summary>
	BackwardDiagonal = 3,      // /////  45-degree upward hatch (left to right)
	/// <summary>Horizontal and vertical crosshatch</summary>
	Cross            = 4,      // +++++  Horizontal and vertical crosshatch
	/// <summary>45-degree crosshatch</summary>
	DiagCross        = 5,      // xxxxx  45-degree crosshatch
}

#region Stock Objects

/// <summary>Stock objects.</summary>
public enum StockObject
{
	WhiteBrush = 0,
	LightGrayBrush = 1,
	GrayBrush = 2,
	DarkGrayBrush = 3,
	BlackBrush = 4,
	NullBrush = 5,
	WhitePen = 6,
	BlackPen = 7,
	NullPen = 8,
	OemFixedFont = 10,
	AnsiFixedFont = 11,
	AnsiVarFont = 12,
	SystemFont = 13,
	DeviceDefaultFont = 14,
	DefaultPalette = 15,
	SystemFixedFont = 16,
	DefaultGuiFont = 17,
	DcBrush = 18,
	DcPen = 19,
}

/// <summary>Stock brushes.</summary>
public enum StockBrush
{
	WhiteBrush = 0,
	LightGrayBrush = 1,
	GrayBrush = 2,
	DarkGrayBrush = 3,
	BlackBrush = 4,
	NullBrush = 5,
	DcBrush = 18,
}

/// <summary>Stock pens.</summary>
public enum StockPen
{
	WhitePen = 6,
	BlackPen = 7,
	NullPen = 8,
	DcPen = 19,
}

/// <summary>Stock fonts.</summary>
public enum StockFont
{
	OemFixedFont = 10,
	AnsiFixedFont = 11,
	AnsiVarFont = 12,
	SystemFont = 13,
	DeviceDefaultFont = 14,
	SystemFixedFont = 16,
	DefaultGuiFont = 17,
}

/// <summary>Stock palette.</summary>
public enum StockPalette
{
	DefaultPalette = 15,
}

#endregion Stock Objects

/// <summary>
/// Parameters for GetDeviceCaps.
/// </summary>
public enum DeviceCapability
{
	/// <summary>Device driver version.</summary>
	DriverVersion = 0,

	/// <summary>Device classification.</summary>
	Technology = 2,

	/// <summary>Horizontal size in millimeters.</summary>
	HorizontalSize = 4,

	/// <summary>Vertical size in millimeters.</summary>
	VerticalSize = 6,

	/// <summary>Horizontal width in pixels.</summary>
	HorizonalResolution = 8,

	/// <summary>Vertical height in pixels.</summary>
	VerticalResolution = 10,

	/// <summary>Number of bits per pixel.</summary>
	BitsPerPixel = 12,

	/// <summary>Number of planes.</summary>
	PlaneCount = 14,

	/// <summary>Number of brushes the device has.</summary>
	NumberOfBrushes = 16,

	/// <summary>Number of pens the device has.</summary>
	NumberOfPens = 18,

	/// <summary>Number of markers the device has.</summary>
	NumberOfMarkers = 20,

	/// <summary>Number of fonts the device has.</summary>
	NumberOfFonts = 22,

	/// <summary>Number of colors the device supports.</summary>
	NumberOfColors = 24,

	/// <summary>Size required for device descriptor.</summary>
	DeviceDescriptorSize = 26,

	/// <summary>Curve capabilities.</summary>
	CurveCapabilities = 28,

	/// <summary>Line capabilities.</summary>
	LineCapabilities = 30,

	/// <summary>Polygonal capabilities.</summary>
	PolygonalCapabilities = 32,

	/// <summary>Text capabilities.</summary>
	TextCapabilities = 34,

	/// <summary>Clipping capabilities.</summary>
	ClippingCapabilities = 36,

	/// <summary>Bitblt capabilities.</summary>
	RasterCapabilities = 38,

	/// <summary>Length of the X leg.</summary>
	AspectX = 40,

	/// <summary>Length of the Y leg.</summary>
	AspectY = 42,

	/// <summary>Length of the hypotenuse.</summary>
	AspectXY = 44,

	/// <summary>Logical pixels/inch in X.</summary>
	LogicalPixelsX = 88,

	/// <summary>Logical pixels/inch in Y.</summary>
	LogicalPixelsY = 90,

	/// <summary>Number of entries in physical palette.</summary>
	PhysicalPaletteEntryCount = 104,

	/// <summary>Number of reserved entries in palette.</summary>
	ReservedPaletteEntriesCount = 106,

	/// <summary>Actual color resolution.</summary>
	ColorResolution = 108,

	/// <summary>Physical Width in device units.</summary>
	PhysicalWidth = 110,

	/// <summary>Physical Height in device units.</summary>
	PhysicalHeight = 111,

	/// <summary>Physical Printable Area x margin.</summary>
	PhysicalOffsetX = 112,

	/// <summary>Physical Printable Area y margin.</summary>
	PhysicalOffsetY = 113,

	/// <summary>Scaling factor x.</summary>
	ScalingFactorX = 114,

	/// <summary>Scaling factor y.</summary>
	ScalingFactorY = 115,

	/// <summary>Current vertical refresh rate of the display device (for displays only) in Hz.</summary>
	VerticalRefreshRate = 116,

	/// <summary>Horizontal width of entire desktop in pixels.</summary>
	DesktopHorizontalResolution = 117,

	/// <summary>Vertical height of entire desktop in pixels.</summary>
	DesktopVerticalResolution = 118,

	/// <summary>Preferred blt alignment.</summary>
	BltAlignment = 119,

	/// <summary>Shading and blending caps.</summary>
	ShadeBlendCapabilities = 120,

	/// <summary>Color Management caps.</summary>
	ColorManagementCapabilities = 121,
}

/// <summary>Region Combine Modes</summary>
public enum RGN
{
	Error = 0,
	And = 1,
	Or = 2,
	Xor = 3,
	Diff = 4,
	Copy = 5,
	Min = And,
	Max = Copy,
}

/// <summary>Region Types</summary>
public enum RegionTypes
{
	Error = 0,
	Null = 1,
	Simple = 2,
	Complex = 3,
}

/// <summary>Alpha Channel Blend Values</summary>
public enum AC : byte
{
	SrcOver = 0x00,
	SrcAlpha = 0x01,
}

public enum CharSet : byte
{
	Ansi = 0,
	Default = 1,
	Symbol = 2,
	Mac = 77,
	ShiftJIS = 128,
	Hangeul = 129,
	Hangul = 129,
	Johab = 130,
	Gb2312 = 134,
	ChineseBig5 = 136,
	Greek = 161,
	Turkish = 162,
	Vietnamese = 163,
	Hebrew = 177,
	Arabic = 178,
	Baltic = 186,
	Russian = 204,
	Thai = 222,
	EastEurope = 238,
	Oem = 255,
}

public enum OutputPrecision : byte
{
	Default = 0,
	String = 1,
	Stroke = 3,
	TrueType = 4,
	Device = 5,
	Raster = 6,
	TrueTypeOnly = 7,
	Outline = 8,
	Screen_outline = 9,
	PostScriptOnly = 10,
}

[Flags]
public enum ClipPrecision : byte
{
	Default                = 0x00,
	Character              = 0x01,
	Stroke                 = 0x02,
	Mask                   = 0x0F,
	LeftHandedAngles       = 0x10,
	FontAssociationDisable = 0x40,
	Embedded               = 0x80,
}

public enum FontQuality : byte
{
	Default          = 0,
	Draft            = 1,
	Proof            = 2,
	NonAntiAliased   = 3,
	AntiAliased      = 4,
	Cleartype        = 5,
	CleartypeNatural = 6,
}

public enum FontPitch : byte
{
	Default  = 0x00,
	Fixed    = 0x01, // Fixed-pitch font (also known as monospaced or non-proportional font).
	Variable = 0x02, // Variable-pitch font (also known as proportional font).
	Device   = 0x03, // Device-specific font.
	Mono     = 0x08, // Monospaced font.
}

public enum FontFamily : byte
{
	/// <summary>Use default font.</summary>
	DontCare = 0x00,
	/// <summary>Fonts with variable stroke width (proportional) and with serifs. MS Serif is an example.</summary>
	Roman = 0x10,
	/// <summary>Fonts with variable stroke width (proportional) and without serifs. MS Sans Serif is an example.</summary>
	Swiss = 0x20,
	/// <summary>Fonts with constant stroke width (monospace), with or without serifs. Monospace fonts are usually modern. Pica, Elite, and CourierNew are examples.</summary>
	Modern = 0x30,
	/// <summary>Fonts designed to look like handwriting. Script and Cursive are examples.</summary>
	Script = 0x40,
	/// <summary>Novelty fonts. Old English is an example.</summary>
	Decorative = 0x50,
}
