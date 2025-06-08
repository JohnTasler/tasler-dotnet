using System.Runtime.InteropServices;
using CommunityToolkit.Diagnostics;

namespace Tasler.Interop.Gdi;

[StructLayout(LayoutKind.Sequential)]
public struct LOGPEN : IProvideStructSize<LOGPEN>
{
	public PenStyle Style;
	public POINT    Width;
	public COLORREF Color;
}

public struct EXTLOGPEN : IProvideStructSize<EXTLOGPEN>
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

public interface IPenTypeStyle : IProvideStructSize<PenTypeStyle>
{
	uint Value { get; init; }

	PenStyle Style => (PenStyle)(Value & (uint)PenStyle.Mask);

	bool IsCosmetic => (this.Value & (uint)PenType.Mask) == (uint)PenType.Cosmetic;

	bool IsGeometric => (this.Value & (uint)PenType.Mask) == (uint)PenType.Geometric;

	PenGeometricTypeStyle? AsGeometric() => this.IsGeometric ? this.Value : null;

	PenCosmeticTypeStyle? AsCosmetic() => this.IsCosmetic ? this.Value : null;
}

[StructLayout(LayoutKind.Sequential)]
public struct PenTypeStyle : IPenTypeStyle, IProvideStructSize<PenTypeStyle>
{
	public readonly uint Value { get; init; }

	public PenTypeStyle(uint value) => Value = value;
}

[StructLayout(LayoutKind.Sequential)]
public struct PenCosmeticTypeStyle : IPenTypeStyle, IProvideStructSize<PenTypeStyle>
{
	public readonly uint Value { get; init; }

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
public struct PenGeometricTypeStyle : IPenTypeStyle, IProvideStructSize<PenTypeStyle>
{
	public readonly uint Value { get; init; }

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


