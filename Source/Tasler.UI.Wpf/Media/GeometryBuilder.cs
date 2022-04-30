using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;

namespace Tasler.Windows.Media
{
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

			// Build the Geometry
#if !SILVERLIGHT
			var geometry = new StreamGeometry();
			using (StreamGeometryContext sgc = geometry.Open())
			{
				sgc.BeginFigure(topLeftPointTop, true, false);
				sgc.LineTo(topRightPointTop, true, false);
				if (radii.TopRight != 0.0)
					sgc.ArcTo(topRightPointRight, topRightSize, 0, false, SweepDirection.Clockwise, true, false);
				sgc.LineTo(bottomRightPointRight, true, false);
				if (radii.BottomRight != 0.0)
					sgc.ArcTo(bottomRightPointBottom, bottomRightSize, 0, false, SweepDirection.Clockwise, true, false);
				sgc.LineTo(bottomLeftPointBottom, true, false);
				if (radii.BottomLeft != 0.0)
					sgc.ArcTo(bottomLeftPointLeft, bottomLeftSize, 0, false, SweepDirection.Clockwise, true, false);
				sgc.LineTo(topLeftPointLeft, true, false);
				if (radii.TopLeft != 0.0)
					sgc.ArcTo(topLeftPointTop, topLeftSize, 0, false, SweepDirection.Clockwise, true, false);
			}
#else
			var segments = new PathSegmentCollection();
			segments.Add(new LineSegment { Point = topRightPointTop });
			if (radii.TopRight != 0.0)
				segments.Add(new ArcSegment { Point = topRightPointRight, Size = topRightSize, SweepDirection = SweepDirection.Clockwise });
			segments.Add(new LineSegment { Point = bottomRightPointRight });

			if (radii.BottomRight != 0.0)
				segments.Add(new ArcSegment { Point = bottomRightPointBottom, Size = bottomRightSize, SweepDirection = SweepDirection.Clockwise });
			segments.Add(new LineSegment { Point = bottomLeftPointBottom });
			if (radii.BottomLeft != 0.0)
				segments.Add(new ArcSegment { Point = bottomLeftPointLeft, Size = bottomLeftSize, SweepDirection = SweepDirection.Clockwise });
			segments.Add(new LineSegment { Point = topLeftPointLeft });
			if (radii.TopLeft != 0.0)
				segments.Add(new ArcSegment { Point = topLeftPointTop, Size = topLeftSize, SweepDirection = SweepDirection.Clockwise });

			var figure = new PathFigure
			{
				StartPoint = topLeftPointTop,
				IsFilled = true,
				IsClosed = false,
				Segments = segments,
			};

			var geometry = new PathGeometry { Figures = new PathFigureCollection { figure } };
#endif // !SILVERLIGHT

			// Return the built Geometry
			return geometry;
		}

		public static Rect Deflate(this Rect rect, Thickness thick)
		{
			return new Rect(
				rect.Left + thick.Left,
				rect.Top + thick.Top,
				Math.Max((double)0.0, (double)((rect.Width - thick.Left) - thick.Right)),
				Math.Max((double)0.0, (double)((rect.Height - thick.Top) - thick.Bottom)));
		}

		[StructLayout(LayoutKind.Sequential)]
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
}
