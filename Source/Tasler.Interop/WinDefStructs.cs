using System.Globalization;
using System.Runtime.InteropServices;

namespace Tasler.Interop
{
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct POINT
	{
		#region Instance Fields
		private int _x;
		private int _y;
		#endregion Instance Fields

		#region Constructors
		public POINT(int x, int y)
		{
			_x = x;
			_y = y;
		}
		#endregion Constructors

		#region Properties
		public int X
		{
			get { return _x; }
			set { _x = value; }
		}

		public int Y
		{
			get { return _y; }
			set { _y = value; }
		}
		#endregion Properties

		#region Overrides
		public override string ToString()
		{
			return "{X=" + _x.ToString(CultureInfo.CurrentCulture)
					+ ", Y=" + _y.ToString(CultureInfo.CurrentCulture) + "}";
		}
		#endregion Overrides
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RECTstruct
	{
		#region Instance Fields
		private int _left;
		private int _top;
		private int _right;
		private int _bottom;
		#endregion Instance Fields

		#region Properties
		public int Left
		{
			get { return _left; }
			set { _left = value; }
		}

		public int Top
		{
			get { return _top; }
			set { _top = value; }
		}

		public int Right
		{
			get { return _right; }
			set { _right = value; }
		}

		public int Bottom
		{
			get { return _bottom; }
			set { _bottom = value; }
		}

		public int Width
		{
			get { return _right - _left; }
		}

		public int Height
		{
			get { return _bottom - _top; }
		}
		#endregion Properties

		#region Overrides
		public override string ToString()
		{
			return "{Left=" + this.Left.ToString(CultureInfo.CurrentCulture)
					+ ", Top=" + this.Top.ToString(CultureInfo.CurrentCulture)
					+ ", Right=" + this.Right.ToString(CultureInfo.CurrentCulture)
					+ ", Bottom=" + this.Bottom.ToString(CultureInfo.CurrentCulture)
					+ ", Size=(" + this.Width.ToString(CultureInfo.CurrentCulture)
					+ " x " + this.Height.ToString(CultureInfo.CurrentCulture) + ")}";
		}
		#endregion Overrides
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public class RECT
	{
		#region Instance Fields
		public RECTstruct rect;
		#endregion Instance Fields

		#region Properties
		public int Left
		{
			get { return this.rect.Left; }
			set { this.rect.Left = value; }
		}

		public int Top
		{
			get { return this.rect.Top; }
			set { this.rect.Top = value; }
		}

		public int Right
		{
			get { return this.rect.Right; }
			set { this.rect.Right = value; }
		}

		public int Bottom
		{
			get { return this.rect.Bottom; }
			set { this.rect.Bottom = value; }
		}

		public int Width
		{
			get { return this.rect.Width; }
		}

		public int Height
		{
			get { return this.rect.Height; }
		}
		#endregion Properties

		#region Overrides
		public override string ToString()
		{
			return this.rect.ToString();
		}
		#endregion Overrides
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct SIZE
	{
		#region Instance Fields
		private int _width;
		private int _height;
		#endregion Instance Fields

		#region Construction
		public SIZE(int width, int height)
		{
			_width = width;
			_height = height;
		}
		#endregion Construction

		#region Properties
		public int Width
		{
			get { return _width; }
			set { _width = value; }
		}

		public int Height
		{
			get { return _height; }
			set { _height = value; }
		}
		#endregion Properties

		#region Overrides
		public override string ToString()
		{
			return "{Width=" + _width.ToString(CultureInfo.CurrentCulture)
				+ ", Height=" + _height.ToString(CultureInfo.CurrentCulture) + "}";
		}
		#endregion Overrides
	}

}
