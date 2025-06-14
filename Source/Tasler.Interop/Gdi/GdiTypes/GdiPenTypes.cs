using System.Runtime.InteropServices;
using CommunityToolkit.Diagnostics;

namespace Tasler.Interop.Gdi;

[StructLayout(LayoutKind.Sequential)]
public struct LOGPEN
{
	public PenStyle Style;
	public POINT    Width;
	public COLORREF Color;
}

public struct EXTLOGPEN
{
	public PenTypeStyle PenStyle;
	public uint         Width;
	public BrushStyle   BrushStyle;
	public COLORREF     Color;
	public nint         Hatch;
	public uint         StyleEntryCount;
	public uint         StyleEntry0;
}

public class ExtLogPen
{
	public PenTypeStyle PenStyle { get; init; }
	public uint         Width { get; init; }
	public BrushStyle   BrushStyle { get; init; }
	public COLORREF     Color { get; init; }
	public nint         Hatch { get; init; }
	public uint[] StyleEntries { get; init; }

	/// <summary>
	/// Initializes a new instance of the <see cref="ExtLogPen"/> class from an <see cref="EXTLOGPEN"/> struct, copying pen style, width, brush style, color, hatch, and up to one style entry.
	/// </summary>
	/// <param name="extLogPen">The <see cref="EXTLOGPEN"/> struct containing the extended pen properties.</param>
	public ExtLogPen(EXTLOGPEN extLogPen)
	{
		this.PenStyle = extLogPen.PenStyle;
		this.Width = extLogPen.Width;
		this.BrushStyle = extLogPen.BrushStyle;
		this.Color = extLogPen.Color;
		this.Hatch = extLogPen.Hatch;
		this.StyleEntries = new uint[Math.Min(extLogPen.StyleEntryCount, 1)];
		this.StyleEntries[0] = extLogPen.StyleEntry0;
	}

	/// <summary>
/// Creates an <see cref="ExtLogPen"/> instance from an <see cref="EXTLOGPEN"/> struct.
/// </summary>
/// <param name="extLogPen">The native extended logical pen structure to convert.</param>
/// <returns>An <see cref="ExtLogPen"/> representing the provided <see cref="EXTLOGPEN"/>.</returns>
public static ExtLogPen FromStruct(EXTLOGPEN extLogPen) => new ExtLogPen(extLogPen);

	//public EXTLOGPEN ToStruct() => new()
	//{
	//	PenStyle = this.PenStyle,
	//	Width = this.Width,
	//	BrushStyle = this.BrushStyle,
	//	Color = this.Color,
	//	Hatch = this.Hatch,
	//};
}

[Flags]
public enum PenType : uint
{
	Cosmetic  = 0x00000000,
	Geometric = 0x00010000,
	Mask      = 0x000F0000,
}

/// <summary>Pen styles.</summary>
public enum PenStyle : uint
{
	Solid        = 0,
	Dash         = 1, // -------
	Dot          = 2, // .......
	DashDot      = 3, // _._._._
	DashDotDot   = 4, // _.._.._
	Null         = 5,
	InsideFrame  = 6,
	UserStyle    = 7,
	Alternate    = 8,
	Mask         = 0x0000000F,
}

public enum PenEndCapStyle : uint
{
	Round  = 0x00000000, // Round end cap
	Square = 0x00000100, // Square end cap
	Flat   = 0x00000200, // Flat end cap
	Mask   = 0x00000F00, // Mask for end cap styles
}

public enum PenJoinStyle : uint
{
	Round = 0x00000000, // Round join style
	Bevel = 0x00001000, // Bevel join style
	Miter = 0x00002000, // Miter join style
	Mask  = 0x0000F000, // Mask for join styles
}

public interface IPenTypeStyle
{
	uint Value { get; init; }

	PenStyle Style => (PenStyle)(Value & (uint)PenStyle.Mask);

	bool IsCosmetic => (this.Value & (uint)PenType.Mask) == (uint)PenType.Cosmetic;

	bool IsGeometric => (this.Value & (uint)PenType.Mask) == (uint)PenType.Geometric;

	/// <summary>
/// Returns this instance as a <see cref="PenGeometricTypeStyle"/> if it represents a geometric pen; otherwise, returns null.
/// </summary>
/// <returns>
/// The current instance as <see cref="PenGeometricTypeStyle"/> if geometric; otherwise, null.
/// </returns>
PenGeometricTypeStyle? AsGeometric() => this.IsGeometric ? this.Value : null;

	/// <summary>
/// Returns this instance as a <see cref="PenCosmeticTypeStyle"/> if it represents a cosmetic pen; otherwise, returns null.
/// </summary>
/// <returns>
/// The current <see cref="PenCosmeticTypeStyle"/> if the pen is cosmetic; otherwise, null.
/// </returns>
PenCosmeticTypeStyle? AsCosmetic() => this.IsCosmetic ? this.Value : null;
}

[StructLayout(LayoutKind.Sequential)]
public struct PenTypeStyle
{
	public readonly uint Value { get; init; }

	/// <summary>
/// Initializes a new instance of <see cref="PenTypeStyle"/> with the specified combined pen type and style value.
/// </summary>
/// <param name="value">The combined pen type and style flags as a <see cref="uint"/>.</param>
public PenTypeStyle(uint value) => Value = value;
}

[StructLayout(LayoutKind.Sequential)]
public struct PenCosmeticTypeStyle
{
	public readonly uint Value { get; init; }

	/// <summary>
	/// Initializes a new cosmetic pen style with the specified pen style.
	/// </summary>
	/// <param name="style">The pen style to use for the cosmetic pen. Must not be <c>PenStyle.Mask</c>.</param>
	public PenCosmeticTypeStyle(PenStyle style)
	{
		Guard.IsNotEqualTo((uint)style, (uint)PenStyle.Mask, nameof(style));
		this.Value = (uint)PenType.Cosmetic | (uint)style;
	}

	public static implicit operator PenTypeStyle(PenCosmeticTypeStyle style) => new() { Value = style.Value };
	public static implicit operator PenCosmeticTypeStyle(PenTypeStyle style) => new() { Value = style.Value };
	public static implicit operator PenCosmeticTypeStyle(uint style) => new() { Value = style };
}

[StructLayout(LayoutKind.Sequential)]
public struct PenGeometricTypeStyle
{
	public readonly uint Value { get; init; }

	/// <summary>
	/// Initializes a geometric pen style by combining the specified pen style, end cap, and join style into a single value.
	/// </summary>
	/// <param name="style">The pen style to use. Must not be <c>Alternate</c> or <c>Mask</c>.</param>
	/// <param name="endCap">The end cap style for the pen.</param>
	/// <param name="join">The join style for the pen.</param>
	public PenGeometricTypeStyle(PenStyle style, PenEndCapStyle endCap, PenJoinStyle join)
	{
		style &= PenStyle.Mask;
		Guard.IsNotEqualTo((uint)style, (uint)PenStyle.Alternate, nameof(style));
		Guard.IsNotEqualTo((uint)style, (uint)PenStyle.Mask, nameof(style));
		this.Value = (uint)PenType.Geometric | (uint)style | (uint)endCap | (uint)join;
	}

	public readonly PenEndCapStyle EndCap => (PenEndCapStyle)(Value & (uint)PenEndCapStyle.Mask);

	public readonly PenJoinStyle Join => (PenJoinStyle)(Value & (uint)PenJoinStyle.Mask);

	public static implicit operator PenTypeStyle(PenGeometricTypeStyle style) => new PenTypeStyle(style.Value);
	public static implicit operator PenGeometricTypeStyle(PenTypeStyle style) => new() { Value = style.Value };
	public static implicit operator PenGeometricTypeStyle(uint style) => new() { Value = style };
}
