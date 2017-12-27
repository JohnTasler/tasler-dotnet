using System.Globalization;
using System.Runtime.InteropServices;

namespace Tasler.Interop
{
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct POINT
	{
		#region Instance Fields
		private int x;
		private int y;
		#endregion Instance Fields

		#region Constructors
		public POINT(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		#endregion Constructors

		#region Properties
		public int X
		{
			get { return this.x; }
			set { this.x = value; }
		}

		public int Y
		{
			get { return this.y; }
			set { this.y = value; }
		}
		#endregion Properties

		#region Overrides
		public override string ToString()
		{
			return "{X=" + this.x.ToString(CultureInfo.CurrentCulture)
					+ ", Y=" + this.y.ToString(CultureInfo.CurrentCulture) + "}";
		}
		#endregion Overrides
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RECTstruct
	{
		#region Instance Fields
		private int left;
		private int top;
		private int right;
		private int bottom;
		#endregion Instance Fields

		#region Properties
		public int Left
		{
			get { return this.left; }
			set { this.left = value; }
		}

		public int Top
		{
			get { return this.top; }
			set { this.top = value; }
		}

		public int Right
		{
			get { return this.right; }
			set { this.right = value; }
		}

		public int Bottom
		{
			get { return this.bottom; }
			set { this.bottom = value; }
		}

		public int Width
		{
			get { return this.right - this.left; }
		}

		public int Height
		{
			get { return this.bottom - this.top; }
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
		private int width;
		private int height;
		#endregion Instance Fields

		#region Construction
		public SIZE(int width, int height)
		{
			this.width = width;
			this.height = height;
		}
		#endregion Construction

		#region Properties
		public int Width
		{
			get { return this.width; }
			set { this.width = value; }
		}

		public int Height
		{
			get { return this.height; }
			set { this.height = value; }
		}
		#endregion Properties

		#region Overrides
		public override string ToString()
		{
			return "{Width=" + this.width.ToString(CultureInfo.CurrentCulture)
				+ ", Height=" + this.height.ToString(CultureInfo.CurrentCulture) + "}";
		}
		#endregion Overrides
	}

}
