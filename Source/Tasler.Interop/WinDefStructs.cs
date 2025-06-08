using System.Runtime.InteropServices;

namespace Tasler.Interop;

/// <summary>
/// A structure that represents a 2-D point, binary compatible with the Win32 <c>POINT</c> structure.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct POINT: IProvideStructSize<POINT>
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
	public override string ToString()
	{
		return $"{{{X} x {Y}}} (0x{X:X8}, 0x{Y:X8})";
	}
	#endregion Overrides
}

/// <summary>
/// A structure that represents a 2-D size, binary compatible with the Win32 <c>SIZE</c> structure.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct SIZE : IProvideStructSize<SIZE>
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

/// <summary>
/// A structure that represents a 2-D rectangle, binary compatible with the Win32 <c>RECT</c> structure.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct RECT : IProvideStructSize<RECT>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="RECT"/> struct.
	/// </summary>
	/// <param name="left">The left coordinate.</param>
	/// <param name="top">The top coordinate.</param>
	/// <param name="right">The right coordinate.</param>
	/// <param name="bottom">The bottom coordinate.</param>
	public RECT(int left, int top, int right, int bottom)
	{
		Left = left;
		Top = top;
		Right = right;
		Bottom = bottom;
	}

	#region Instance Fields
	/// <summary>The left coordinate of the rectangle.</summary>
	public int Left;
	/// <summary>The top coordinate of the rectangle.</summary>
	public int Top;
	/// <summary>The right coordinate of the rectangle.</summary>
	public int Right;
	/// <summary>The bottom coordinate of the rectangle.</summary>
	public int Bottom;
	#endregion Instance Fields

	#region Properties

	/// <summary>Gets the width of the rectangle.</summary>
	/// <value>The width of the rectangle.</value>
	public int Width => Right - Left;

	/// <summary>Gets the height of the rectangle.</summary>
	/// <value>The height of the rectangle.</value>
	public int Height => Bottom - Top;

	/// <summary>Gets the top left coordinates of the rectangle as a <see cref="POINT"/>.</summary>
	/// <value>A <see cref="POINT"/> representing the top left corner of the rectangle.</value>
	public POINT TopLeft => new(Left, Top);

	/// <summary>Gets the bottom right coordinates of the rectange as a <see cref="POINT"/>.</summary>
	/// <value>A <see cref="POINT"/> representing the bottom right corner of the rectangle.</value>
	public POINT BottomRight => new(Right, Bottom);

	/// <summary>Gets the size of the rectangle.</summary>
	/// <value>A <see cref="SIZE"/> representing the size of the rectangle.</value>
	public SIZE Size => new(Width, Height);

	#endregion Properties

	#region Overrides
	public override string ToString() => $"Origin={TopLeft} Size={Size}";
	#endregion Overrides
}

public static class RECTExtensions
{
	/// <summary>Offsets the specified <see cref="RECT"/>.</summary>
	/// <param name="@this">A reference to the <see cref="RECT"/> to offset.</param>
	/// <param name="x">The horizontal offset amount.</param>
	/// <param name="y">The vertical offset amount.</param>
	/// <returns>
	/// A reference to the same <see cref="RECT"/> that was passed in, with the specified offset applied.
	/// </returns>
	public static ref RECT Offset(this ref RECT @this, int x, int y)
	{
		@this.Left += x;
		@this.Top += y;
		@this.Right += x;
		@this.Bottom += y;
		return ref @this;
	}

	public static ref RECT Inflate(this ref RECT @this, int left, int top, int right, int bottom)
	{
		@this.Left -= left;
		@this.Top -= top;
		@this.Right += right;
		@this.Bottom += bottom;
		return ref @this;
	}

	public static ref RECT Inflate(this ref RECT @this, int width, int height)
	{
		@this.Left -= width;
		@this.Top -= height;
		@this.Right += width;
		@this.Bottom += height;
		return ref @this;
	}

	public static ref RECT Deflate(this ref RECT @this, int left, int top, int right, int bottom)
	{
		@this.Left += left;
		@this.Top += top;
		@this.Right -= right;
		@this.Bottom -= bottom;
		return ref @this;
	}

	public static ref RECT Deflate(this ref RECT @this, int width, int height)
	{
		@this.Left += width;
		@this.Top += height;
		@this.Right -= width;
		@this.Bottom -= height;
		return ref @this;
	}
}
