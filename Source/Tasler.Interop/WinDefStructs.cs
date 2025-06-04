using System.Runtime.InteropServices;

namespace Tasler.Interop;

[StructLayout(LayoutKind.Sequential)]
public struct POINT
{
	#region Instance Fields
	public int X;
	public int Y;
	#endregion Instance Fields

	#region Constructors
	public POINT(int x, int y)
	{
		X = x;
		Y = y;
	}
	#endregion Constructors

	#region Overrides
	public readonly override string ToString()
	{
		return $"{{{X} x {Y}}} (0x{X:X8}, 0x{Y:X8})";
	}
	#endregion Overrides
}

[StructLayout(LayoutKind.Sequential)]
public struct SIZE
{
	#region Instance Fields
	public int Width;
	public int Height;
	#endregion Instance Fields

	#region Construction
	public SIZE(int width, int height)
	{
		Width = width;
		Height = height;
	}
	#endregion Construction

	#region Overrides
	public readonly override string ToString()
	{
		return $"{{{Width} x {Height}}} (0x{Width:X8}, 0x{Height:X8})";
	}
	#endregion Overrides
}

[StructLayout(LayoutKind.Sequential)]
public struct RECT
{
	public RECT(int left, int top, int right, int bottom)
	{
		Left = left;
		Top = top;
		Right = right;
		Bottom = bottom;
	}

	#region Instance Fields
	public int Left;
	public int Top;
	public int Right;
	public int Bottom;
	#endregion Instance Fields

	#region Properties

	public readonly int Width => Right - Left;

	public readonly int Height => Bottom - Top;

	public readonly POINT TopLeft => new(Left, Top);

	public readonly POINT BottomRight => new(Right, Bottom);

	public readonly SIZE Size => new(Width, Height);

	#endregion Properties

	#region Overrides
	public override readonly string ToString() => $"Origin={TopLeft} Size={Size}";
	#endregion Overrides
}

public static class RECTExtensions
{
	public static ref RECT Offset(this ref RECT @this, int x, int y)
	{
		@this.Left += x;
		@this.Top += y;
		@this.Right += x;
		@this.Bottom += y;
		return ref @this;
	}
}
