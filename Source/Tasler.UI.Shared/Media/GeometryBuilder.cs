#if WINDOWS_UWP
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
namespace Tasler.UI.Xaml;
#elif WINDOWS_WPF
using System.Windows;
using System.Windows.Media;
namespace Tasler.Windows.Media;
#endif


public static class GeometryBuilder
{
	public static Geometry BuildRoundedRectangle(Rect bounds, CornerRadius cornerRadius, Thickness borderThickness, bool outer)
	{
		// Create a Radii structure from the specified parameters
		Radii radii = new Radii(cornerRadius, borderThickness, outer);

		// Define the points and sizes
		Point topLeftPointLeft = new Point(bounds.Left, bounds.Top + radii.TopLeft);
		Point topLeftPointTop = new Point(bounds.Left + radii.TopLeft, bounds.Top);
		Point topRightPointTop = new Point(bounds.Right - radii.TopRight, bounds.Top);
		Point topRightPointRight = new Point(bounds.Right, bounds.Top + radii.TopRight);
		Point bottomRightPointRight = new Point(bounds.Right, bounds.Bottom - radii.BottomRight);
		Point bottomRightPointBottom = new Point(bounds.Right - radii.TopRight, bounds.Bottom);
		Point bottomLeftPointBottom = new Point(bounds.Left + radii.BottomLeft, bounds.Bottom);
		Point bottomLeftPointLeft = new Point(bounds.Left, bounds.Bottom - radii.BottomLeft);
		Size topLeftSize = new Size(radii.TopLeft, radii.TopLeft);
		Size topRightSize = new Size(radii.TopRight, radii.TopRight);
		Size bottomRightSize = new Size(radii.BottomRight, radii.BottomRight);
		Size bottomLeftSize = new Size(radii.BottomLeft, radii.BottomLeft);

		// Build the geometry
		var figure = new PathFigure
		{
			StartPoint = topLeftPointTop,
			Segments =
			[
				CreateLineSegment(topRightPointTop),
				CreateArcSegmentIfNotZero(radii.TopRight, topRightPointRight, topRightSize),
				CreateLineSegment(bottomRightPointRight),
				CreateArcSegmentIfNotZero(radii.BottomRight, bottomRightPointBottom, bottomRightSize),
				CreateLineSegment(bottomLeftPointBottom),
				CreateArcSegmentIfNotZero(radii.BottomLeft, bottomLeftPointLeft, bottomLeftSize),
				CreateLineSegment(topLeftPointLeft),
				CreateArcSegmentIfNotZero(radii.TopLeft, topLeftPointTop, topLeftSize),
			],
			IsFilled = true,
		};

		// Remove null segment values
		while (figure.Segments.Remove(null))
		{
		}

		return new PathGeometry { Figures = [figure] };
	}

#if WINDOWS_UWP

	private static LineSegment CreateLineSegment(Point point) => new() { Point = point };

	private static ArcSegment? CreateArcSegmentIfNotZero(double conditionalValue, Point point, Size size)
	{
		if (conditionalValue == 0.0)
			return null;

		return new ArcSegment
		{
			Point = point,
			Size = size,
			RotationAngle = 0,
			IsLargeArc = false,
			SweepDirection = SweepDirection.Clockwise,
		};
	}

#elif WINDOWS_WPF

	private static LineSegment CreateLineSegment(Point point) => new(point, true);

	private static ArcSegment? CreateArcSegmentIfNotZero(double conditionalValue, Point point, Size size)
		=> conditionalValue == 0.0 ? null : new(point, size, 0, false, SweepDirection.Clockwise, false);

#endif

	public static Rect Deflate(this Rect rect, Thickness thick)
	{
		return new Rect(
			rect.Left + thick.Left,
			rect.Top + thick.Top,
			Math.Max((double)0.0, (double)((rect.Width - thick.Left) - thick.Right)),
			Math.Max((double)0.0, (double)((rect.Height - thick.Top) - thick.Bottom)));
	}

	private struct Radii
	{
		public double LeftTop;
		public double TopLeft;
		public double TopRight;
		public double RightTop;
		public double RightBottom;
		public double BottomRight;
		public double BottomLeft;
		public double LeftBottom;

		public Radii(CornerRadius cornerRadius, Thickness borders, bool outer)
		{
			double num = 0.5 * borders.Left;
			double num2 = 0.5 * borders.Top;
			double num3 = 0.5 * borders.Right;
			double num4 = 0.5 * borders.Bottom;
			if (outer)
			{
				if (cornerRadius.TopLeft == 0.0)
				{
					this.LeftTop = this.TopLeft = 0.0;
				}
				else
				{
					this.LeftTop = cornerRadius.TopLeft + num;
					this.TopLeft = cornerRadius.TopLeft + num2;
				}

				if (cornerRadius.TopRight == 0.0)
				{
					this.TopRight = this.RightTop = 0.0;
				}
				else
				{
					this.TopRight = cornerRadius.TopRight + num2;
					this.RightTop = cornerRadius.TopRight + num3;
				}

				if (cornerRadius.BottomRight == 0.0)
				{
					this.RightBottom = this.BottomRight = 0.0;
				}
				else
				{
					this.RightBottom = cornerRadius.BottomRight + num3;
					this.BottomRight = cornerRadius.BottomRight + num4;
				}

				if (cornerRadius.BottomLeft == 0.0)
				{
					this.BottomLeft = this.LeftBottom = 0.0;
				}
				else
				{
					this.BottomLeft = cornerRadius.BottomLeft + num4;
					this.LeftBottom = cornerRadius.BottomLeft + num;
				}
			}
			else
			{
				this.LeftTop = Math.Max((double)0.0, (double)(cornerRadius.TopLeft - num));
				this.TopLeft = Math.Max((double)0.0, (double)(cornerRadius.TopLeft - num2));
				this.TopRight = Math.Max((double)0.0, (double)(cornerRadius.TopRight - num2));
				this.RightTop = Math.Max((double)0.0, (double)(cornerRadius.TopRight - num3));
				this.RightBottom = Math.Max((double)0.0, (double)(cornerRadius.BottomRight - num3));
				this.BottomRight = Math.Max((double)0.0, (double)(cornerRadius.BottomRight - num4));
				this.BottomLeft = Math.Max((double)0.0, (double)(cornerRadius.BottomLeft - num4));
				this.LeftBottom = Math.Max((double)0.0, (double)(cornerRadius.BottomLeft - num));
			}
		}
	}
}
