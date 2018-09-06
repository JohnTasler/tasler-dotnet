#if WINDOWS_UWP
using Windows.Foundation;
using Windows.UI.Xaml;
namespace Tasler.UI.Xaml
#elif WINDOWS_WPF
using System.Windows;
namespace Tasler.Windows
#endif
{
	// TODO: NEEDS_UNIT_TESTS

	/// <summary>
	/// Describes the width, height, and location of a rectangle. This type is similiar to the
	/// <see cref="System.Windows.Rect"/> structure. Unlike that system-provided type, however, the
	/// <see cref="ExtentRect"/> supports both positive and negative extents in its
	/// <see cref="Width"/> and <see cref="Height"/> properties.
	/// </summary>
	public struct ExtentRect
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ExtentRect"/> struct.
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		public ExtentRect(double x, double y, double width, double height)
			: this()
		{
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ExtentRect"/> struct.
		/// </summary>
		/// <param name="rect">The rect.</param>
		public ExtentRect(Rect rect)
			: this(rect.X, rect.Y, rect.Width, rect.Height)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ExtentRect"/> struct.
		/// </summary>
		/// <param name="topLeft">The top left.</param>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		public ExtentRect(Point topLeft, double width, double height)
			: this(topLeft.X, topLeft.Y, width, height)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ExtentRect"/> struct.
		/// </summary>
		/// <param name="topLeft">The top left.</param>
		/// <param name="size">The size.</param>
		public ExtentRect(Point topLeft, Size size)
			: this(topLeft.X, topLeft.Y, size.Width, size.Height)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ExtentRect"/> struct.
		/// </summary>
		/// <param name="topLeft">The top left.</param>
		/// <param name="bottomRight">The bottom right.</param>
		public ExtentRect(Point topLeft, Point bottomRight)
			: this(topLeft.X, topLeft.Y, bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y)
		{
		}
		#endregion Constructors

		#region Properties
		public double X { get; set; }
		public double Y { get; set; }
		public double Width { get; set; }
		public double Height { get; set; }

		public double Left { get { return this.X; } }
		public double Top { get { return this.Y; } }
		public double Right { get { return this.X + this.Width; } }
		public double Bottom { get { return this.Y + this.Height; } }

		public Point TopLeft { get { return new Point(this.Left, this.Top); } }
		public Point TopRight { get { return new Point(this.Right, this.Top); } }
		public Point BottomLeft { get { return new Point(this.Left, this.Bottom); } }
		public Point BottomRight { get { return new Point(this.Right, this.Bottom); } }
		#endregion Properties

		#region Methods

		public void Inflate(double left, double top, double right, double bottom)
		{
			this.X -= left;
			this.Y -= top;
			this.Width += left + right;
			this.Height += top + bottom;
		}

		public void Inflate(double width, double height)
		{
			this.Inflate(width, height, width, height);
		}

		public void Inflate(Thickness thickness)
		{
			this.Inflate(thickness.Left, thickness.Top, thickness.Right, thickness.Bottom);
		}

		public void Deflate(Thickness thickness)
		{
			this.Inflate(-thickness.Left, -thickness.Top, -thickness.Right, -thickness.Bottom);
		}

		#endregion Methods

		#region Implicit Conversion Operators
		/// <summary>
		/// Performs an implicit conversion from <see cref="PixelInspector.Utility.ExtentRect"/> to <see cref="System.Windows.Rect"/>.
		/// </summary>
		/// <param name="extentRect">The extent rect.</param>
		/// <returns>
		/// The result of the conversion.
		/// </returns>
		public static implicit operator Rect(ExtentRect extentRect)
		{
			bool flippedHorizontal;
			bool flippedVertical;
			return extentRect.ToRect(out flippedHorizontal, out flippedVertical);
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="System.Windows.Rect"/> to <see cref="PixelInspector.Utility.ExtentRect"/>.
		/// </summary>
		/// <param name="rect">The rect.</param>
		/// <returns>
		/// The result of the conversion.
		/// </returns>
		public static implicit operator ExtentRect(Rect rect)
		{
			return new ExtentRect(rect);
		}

		#endregion Implicit Conversion Operators

		#region Overrides

		public override bool Equals(object o)
		{
			if ((o == null) || !(o is ExtentRect))
				return false;

			var rect = (ExtentRect)o;
			return Equals(this, rect);
		}

		public bool Equals(ExtentRect value)
		{
			return Equals(this, value);
		}

		public static bool Equals(ExtentRect rect1, ExtentRect rect2)
		{
			return rect1.X == rect2.X
			    && rect1.Y == rect2.Y
			    && rect1.Width == rect2.Width
			    && rect1.Height == rect2.Height;
		}

		public override int GetHashCode()
		{
			return this.X.GetHashCode()
				^ this.Y.GetHashCode()
				^ this.Width.GetHashCode()
				^ this.Height.GetHashCode();
		}

		#endregion Overrides

		#region Private Implementation
		private Rect ToRect(out bool flippedHorizontal, out bool flippedVertical)
		{
			var width = this.Width;
			flippedHorizontal = width < 0;
			var x = flippedHorizontal ? this.X - (width = -width) : this.X;

			var height = this.Height;
			flippedVertical = height < 0;
			var y = flippedVertical ? this.Y - (height = -height) : this.Y;

			return new Rect(x, y, width, height);
		}
		#endregion Private Implementation
	}
}

#if false
/// <summary>Indicates whether the specified rectangles are equal. </summary>
/// <returns>true if the rectangles have the same <see cref="P:System.Windows.Rect.Location" /> and <see cref="P:System.Windows.Rect.Size" /> values; otherwise, false.</returns>
/// <param name="rect1">The first rectangle to compare.</param>
/// <param name="rect2">The second rectangle to compare.</param>
public static bool Equals(Rect rect1, Rect rect2);
/// <summary>Indicates whether the specified object is equal to the current rectangle.</summary>
/// <returns>true if <paramref name="o" /> is a <see cref="T:System.Windows.Rect" /> and has the same <see cref="P:System.Windows.Rect.Location" /> and <see cref="P:System.Windows.Rect.Size" /> values as the current rectangle; otherwise, false.</returns>
/// <param name="o">The object to compare to the current rectangle.</param>
public override bool Equals(object o);
/// <summary>Indicates whether the specified rectangle is equal to the current rectangle. </summary>
/// <returns>true if the specified rectangle has the same <see cref="P:System.Windows.Rect.Location" /> and <see cref="P:System.Windows.Rect.Size" /> values as the current rectangle; otherwise, false.</returns>
/// <param name="value">The rectangle to compare to the current rectangle.</param>
public bool Equals(Rect value);
/// <summary>Creates a hash code for the rectangle. </summary>
/// <returns>A hash code for the current <see cref="T:System.Windows.Rect" /> structure.</returns>
public override int GetHashCode();
/// <summary>Creates a new rectangle from the specified string representation. </summary>
/// <returns>The resulting rectangle.</returns>
/// <param name="source">The string representation of the rectangle, in the form "x, y, width, height".</param>
public static Rect Parse(string source);
/// <summary>Returns a string representation of the rectangle. </summary>
/// <returns>A string representation of the current rectangle. The string has the following form: "<see cref="P:System.Windows.Rect.X" />,<see cref="P:System.Windows.Rect.Y" />,<see cref="P:System.Windows.Rect.Width" />,<see cref="P:System.Windows.Rect.Height" />".</returns>
[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
public override string ToString();
/// <summary>Returns a string representation of the rectangle by using the specified format provider. </summary>
/// <returns>A string representation of the current rectangle that is determined by the specified format provider.</returns>
/// <param name="provider">Culture-specific formatting information.</param>
[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
public string ToString(IFormatProvider provider);
/// <summary>Formats the value of the current instance using the specified format.</summary>
/// <returns>A string representation of the rectangle.</returns>
/// <param name="format">The format to use.-or- A null reference (Nothing in Visual Basic) to use the default format defined for the type of the <see cref="T:System.IFormattable" /> implementation. </param>
/// <param name="provider">The provider to use to format the value.-or- A null reference (Nothing in Visual Basic) to obtain the numeric format information from the current locale setting of the operating system. </param>
[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
string IFormattable.ToString(string format, IFormatProvider provider);
internal string ConvertToString(string format, IFormatProvider provider);
/// <summary>Initializes a new instance of the <see cref="T:System.Windows.Rect" /> structure that has the specified top-left corner location and the specified width and height. </summary>
/// <param name="location">A point that specifies the location of the top-left corner of the rectangle.</param>
/// <param name="size">A <see cref="T:System.Windows.Size" /> structure that specifies the width and height of the rectangle.</param>
public Rect(Point location, Size size);
/// <summary>Initializes a new instance of the <see cref="T:System.Windows.Rect" /> structure that has the specified x-coordinate, y-coordinate, width, and height. </summary>
/// <param name="x">The x-coordinate of the top-left corner of the rectangle.</param>
/// <param name="y">The y-coordinate of the top-left corner of the rectangle.</param>
/// <param name="width">The width of the rectangle.</param>
/// <param name="height">The height of the rectangle.</param>
/// <exception cref="T:System.ArgumentException">
/// <paramref name="width" /> is a negative value.-or-<paramref name="height" /> is a negative value.</exception>
public Rect(double x, double y, double width, double height);
/// <summary>Initializes a new instance of the <see cref="T:System.Windows.Rect" /> structure that is exactly large enough to contain the two specified points. </summary>
/// <param name="point1">The first point that the new rectangle must contain.</param>
/// <param name="point2">The second point that the new rectangle must contain.</param>
public Rect(Point point1, Point point2);
/// <summary>Initializes a new instance of the <see cref="T:System.Windows.Rect" /> structure that is exactly large enough to contain the specified point and the sum of the specified point and the specified vector. </summary>
/// <param name="point">The first point the rectangle must contain.</param>
/// <param name="vector">The amount to offset the specified point. The resulting rectangle will be exactly large enough to contain both points.</param>
public Rect(Point point, Vector vector);
/// <summary>Initializes a new instance of the <see cref="T:System.Windows.Rect" /> structure that is of the specified size and is located at (0,0).  </summary>
/// <param name="size">A <see cref="T:System.Windows.Size" /> structure that specifies the width and height of the rectangle.</param>
public Rect(Size size);
/// <summary>Gets a special value that represents a rectangle with no position or area. </summary>
/// <returns>The empty rectangle, which has <see cref="P:System.Windows.Rect.X" /> and <see cref="P:System.Windows.Rect.Y" /> property values of <see cref="F:System.Double.PositiveInfinity" />, and has <see cref="P:System.Windows.Rect.Width" /> and <see cref="P:System.Windows.Rect.Height" /> property values of <see cref="F:System.Double.NegativeInfinity" />.</returns>
public static Rect Empty { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get; }
/// <summary>Gets a value that indicates whether the rectangle is the <see cref="P:System.Windows.Rect.Empty" /> rectangle.</summary>
/// <returns>true if the rectangle is the <see cref="P:System.Windows.Rect.Empty" /> rectangle; otherwise, false.</returns>
public bool IsEmpty { get; }
/// <summary>Gets or sets the position of the top-left corner of the rectangle.</summary>
/// <returns>The position of the top-left corner of the rectangle. The default is (0, 0). </returns>
/// <exception cref="T:System.InvalidOperationException">
/// <see cref="P:System.Windows.Rect.Location" /> is set on an <see cref="P:System.Windows.Rect.Empty" /> rectangle. </exception>
public Point Location { get; set; }
/// <summary>Gets or sets the width and height of the rectangle. </summary>
/// <returns>A <see cref="T:System.Windows.Size" /> structure that specifies the width and height of the rectangle.</returns>
/// <exception cref="T:System.InvalidOperationException">
/// <see cref="P:System.Windows.Rect.Size" /> is set on an <see cref="P:System.Windows.Rect.Empty" /> rectangle. </exception>
public Size Size { get; set; }
/// <summary>Gets or sets the x-axis value of the left side of the rectangle. </summary>
/// <returns>The x-axis value of the left side of the rectangle.</returns>
/// <exception cref="T:System.InvalidOperationException">
/// <see cref="P:System.Windows.Rect.X" /> is set on an <see cref="P:System.Windows.Rect.Empty" /> rectangle. </exception>
public double X { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get; set; }
/// <summary>Gets or sets the y-axis value of the top side of the rectangle. </summary>
/// <returns>The y-axis value of the top side of the rectangle.</returns>
/// <exception cref="T:System.InvalidOperationException">
/// <see cref="P:System.Windows.Rect.Y" /> is set on an <see cref="P:System.Windows.Rect.Empty" /> rectangle. </exception>
public double Y { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get; set; }
/// <summary>Gets or sets the width of the rectangle.  </summary>
/// <returns>A positive number that represents the width of the rectangle. The default is 0.</returns>
/// <exception cref="T:System.ArgumentException">
/// <see cref="P:System.Windows.Rect.Width" /> is set to a negative value.</exception>
/// <exception cref="T:System.InvalidOperationException">
/// <see cref="P:System.Windows.Rect.Width" /> is set on an <see cref="P:System.Windows.Rect.Empty" /> rectangle. </exception>
public double Width { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get; set; }
/// <summary>Gets or sets the height of the rectangle. </summary>
/// <returns>A positive number that represents the height of the rectangle. The default is 0.</returns>
/// <exception cref="T:System.ArgumentException">
/// <see cref="P:System.Windows.Rect.Height" /> is set to a negative value.</exception>
/// <exception cref="T:System.InvalidOperationException">
/// <see cref="P:System.Windows.Rect.Height" /> is set on an <see cref="P:System.Windows.Rect.Empty" /> rectangle. </exception>
public double Height { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get; set; }
/// <summary>Gets the x-axis value of the left side of the rectangle. </summary>
/// <returns>The x-axis value of the left side of the rectangle.</returns>
public double Left { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get; }
/// <summary>Gets the y-axis position of the top of the rectangle. </summary>
/// <returns>The y-axis position of the top of the rectangle.</returns>
public double Top { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get; }
/// <summary>Gets the x-axis value of the right side of the rectangle.  </summary>
/// <returns>The x-axis value of the right side of the rectangle.</returns>
public double Right { get; }
/// <summary>Gets the y-axis value of the bottom of the rectangle. </summary>
/// <returns>The y-axis value of the bottom of the rectangle. If the rectangle is empty, the value is <see cref="F:System.Double.NegativeInfinity" /> .</returns>
public double Bottom { get; }
/// <summary>Gets the position of the top-left corner of the rectangle. </summary>
/// <returns>The position of the top-left corner of the rectangle.</returns>
public Point TopLeft { get; }
/// <summary>Gets the position of the top-right corner of the rectangle. </summary>
/// <returns>The position of the top-right corner of the rectangle.</returns>
public Point TopRight { get; }
/// <summary>Gets the position of the bottom-left corner of the rectangle </summary>
/// <returns>The position of the bottom-left corner of the rectangle.</returns>
public Point BottomLeft { get; }
/// <summary>Gets the position of the bottom-right corner of the rectangle. </summary>
/// <returns>The position of the bottom-right corner of the rectangle.</returns>
public Point BottomRight { get; }
/// <summary>Indicates whether the rectangle contains the specified point.</summary>
/// <returns>true if the rectangle contains the specified point; otherwise, false.</returns>
/// <param name="point">The point to check.</param>
public bool Contains(Point point);
/// <summary>Indicates whether the rectangle contains the specified x-coordinate and y-coordinate. </summary>
/// <returns>true if (<paramref name="x" />, <paramref name="y" />) is contained by the rectangle; otherwise, false.</returns>
/// <param name="x">The x-coordinate of the point to check.</param>
/// <param name="y">The y-coordinate of the point to check.</param>
public bool Contains(double x, double y);
/// <summary>Indicates whether the rectangle contains the specified rectangle. </summary>
/// <returns>true if <paramref name="rect" /> is entirely contained by the rectangle; otherwise, false.</returns>
/// <param name="rect">The rectangle to check.</param>
public bool Contains(Rect rect);
/// <summary>Indicates whether the specified rectangle intersects with the current rectangle. </summary>
/// <returns>true if the specified rectangle intersects with the current rectangle; otherwise, false.</returns>
/// <param name="rect">The rectangle to check.</param>
public bool IntersectsWith(Rect rect);
/// <summary>Finds the intersection of the current rectangle and the specified rectangle, and stores the result as the current rectangle. </summary>
/// <param name="rect">The rectangle to intersect with the current rectangle.</param>
public void Intersect(Rect rect);
/// <summary>Returns the intersection of the specified rectangles. </summary>
/// <returns>The intersection of the two rectangles, or <see cref="P:System.Windows.Rect.Empty" /> if no intersection exists.</returns>
/// <param name="rect1">The first rectangle to compare.</param>
/// <param name="rect2">The second rectangle to compare.</param>
public static Rect Intersect(Rect rect1, Rect rect2);
/// <summary>Expands the current rectangle exactly enough to contain the specified rectangle. </summary>
/// <param name="rect">The rectangle to include.</param>
public void Union(Rect rect);
/// <summary>Creates a rectangle that is exactly large enough to contain the two specified rectangles. </summary>
/// <returns>The resulting rectangle.</returns>
/// <param name="rect1">The first rectangle to include.</param>
/// <param name="rect2">The second rectangle to include.</param>
public static Rect Union(Rect rect1, Rect rect2);
/// <summary>Expands the current rectangle exactly enough to contain the specified point. </summary>
/// <param name="point">The point to include.</param>
public void Union(Point point);
/// <summary>Creates a rectangle that is exactly large enough to include the specified rectangle and the specified point. </summary>
/// <returns>A rectangle that is exactly large enough to contain the specified rectangle and the specified point.</returns>
/// <param name="rect">The rectangle to include.</param>
/// <param name="point">The point to include.</param>
public static Rect Union(Rect rect, Point point);
/// <summary>Moves the rectangle by the specified vector. </summary>
/// <param name="offsetVector">A vector that specifies the horizontal and vertical amounts to move the rectangle.</param>
/// <exception cref="T:System.InvalidOperationException">This method is called on the <see cref="P:System.Windows.Rect.Empty" /> rectangle.</exception>
public void Offset(Vector offsetVector);
/// <summary>Moves the rectangle by the specified horizontal and vertical amounts. </summary>
/// <param name="offsetX">The amount to move the rectangle horizontally.</param>
/// <param name="offsetY">The amount to move the rectangle vertically.</param>
/// <exception cref="T:System.InvalidOperationException">This method is called on the <see cref="P:System.Windows.Rect.Empty" /> rectangle.</exception>
public void Offset(double offsetX, double offsetY);
/// <summary>Returns a rectangle that is offset from the specified rectangle by using the specified vector. </summary>
/// <returns>The resulting rectangle.</returns>
/// <param name="rect">The original rectangle.</param>
/// <param name="offsetVector">A vector that specifies the horizontal and vertical offsets for the new rectangle.</param>
/// <exception cref="T:System.InvalidOperationException">
/// <paramref name="rect" /> is <see cref="P:System.Windows.Rect.Empty" />.</exception>
public static Rect Offset(Rect rect, Vector offsetVector);
/// <summary>Returns a rectangle that is offset from the specified rectangle by using the specified horizontal and vertical amounts. </summary>
/// <returns>The resulting rectangle.</returns>
/// <param name="rect">The rectangle to move.</param>
/// <param name="offsetX">The horizontal offset for the new rectangle.</param>
/// <param name="offsetY">The vertical offset for the new rectangle.</param>
/// <exception cref="T:System.InvalidOperationException">
/// <paramref name="rect" /> is <see cref="P:System.Windows.Rect.Empty" />.</exception>
public static Rect Offset(Rect rect, double offsetX, double offsetY);
/// <summary>Expands the rectangle by using the specified <see cref="T:System.Windows.Size" />, in all directions. </summary>
/// <param name="size">Specifies the amount to expand the rectangle. The <see cref="T:System.Windows.Size" /> structure's <see cref="P:System.Windows.Size.Width" /> property specifies the amount to increase the rectangle's <see cref="P:System.Windows.Rect.Left" /> and <see cref="P:System.Windows.Rect.Right" /> properties. The <see cref="T:System.Windows.Size" /> structure's <see cref="P:System.Windows.Size.Height" /> property specifies the amount to increase the rectangle's <see cref="P:System.Windows.Rect.Top" /> and <see cref="P:System.Windows.Rect.Bottom" /> properties. </param>
/// <exception cref="T:System.InvalidOperationException">This method is called on the <see cref="P:System.Windows.Rect.Empty" /> rectangle.</exception>
public void Inflate(Size size);
/// <summary>Expands or shrinks the rectangle by using the specified width and height amounts, in all directions. </summary>
/// <param name="width">The amount by which to expand or shrink the left and right sides of the rectangle.</param>
/// <param name="height">The amount by which to expand or shrink the top and bottom sides of the rectangle.</param>
/// <exception cref="T:System.InvalidOperationException">This method is called on the <see cref="P:System.Windows.Rect.Empty" /> rectangle.</exception>
public void Inflate(double width, double height);
/// <summary>Returns the rectangle that results from expanding the specified rectangle by the specified <see cref="T:System.Windows.Size" />, in all directions. </summary>
/// <returns>The resulting rectangle.</returns>
/// <param name="rect">The <see cref="T:System.Windows.Rect" /> structure to modify.</param>
/// <param name="size">Specifies the amount to expand the rectangle. The <see cref="T:System.Windows.Size" /> structure's <see cref="P:System.Windows.Size.Width" /> property specifies the amount to increase the rectangle's <see cref="P:System.Windows.Rect.Left" /> and <see cref="P:System.Windows.Rect.Right" /> properties. The <see cref="T:System.Windows.Size" /> structure's <see cref="P:System.Windows.Size.Height" /> property specifies the amount to increase the rectangle's <see cref="P:System.Windows.Rect.Top" /> and <see cref="P:System.Windows.Rect.Bottom" /> properties.</param>
/// <exception cref="T:System.InvalidOperationException">
/// <paramref name="rect" /> is an <see cref="P:System.Windows.Rect.Empty" /> rectangle.</exception>
public static Rect Inflate(Rect rect, Size size);
/// <summary>Creates a rectangle that results from expanding or shrinking the specified rectangle by the specified width and height amounts, in all directions. </summary>
/// <returns>The resulting rectangle. </returns>
/// <param name="rect">The <see cref="T:System.Windows.Rect" /> structure to modify.</param>
/// <param name="width">The amount by which to expand or shrink the left and right sides of the rectangle.</param>
/// <param name="height">The amount by which to expand or shrink the top and bottom sides of the rectangle.</param>
/// <exception cref="T:System.InvalidOperationException">
/// <paramref name="rect" /> is an <see cref="P:System.Windows.Rect.Empty" /> rectangle.</exception>
public static Rect Inflate(Rect rect, double width, double height);
/// <summary>Returns the rectangle that results from applying the specified matrix to the specified rectangle. </summary>
/// <returns>The rectangle that results from the operation.</returns>
/// <param name="rect">A rectangle that is the basis for the transformation.</param>
/// <param name="matrix">A matrix that specifies the transformation to apply.</param>
public static Rect Transform(Rect rect, Matrix matrix);
/// <summary>Transforms the rectangle by applying the specified matrix. </summary>
/// <param name="matrix">A matrix that specifies the transformation to apply.</param>
public void Transform(Matrix matrix);
/// <summary>Multiplies the size of the current rectangle by the specified x and y values.</summary>
/// <param name="scaleX">The scale factor in the x-direction.</param>
/// <param name="scaleY">The scale factor in the y-direction.</param>
public void Scale(double scaleX, double scaleY);
static Rect();
#endif