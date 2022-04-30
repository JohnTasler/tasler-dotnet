using System;
using System.Windows;

namespace Tasler.Windows.Extensions
{
	/// <summary>
	/// Provides extension methods for instances of the <see cref="Thickness"/> type.
	/// </summary>
	public static class ThicknessExtensions
	{
		public static double GetWidth(this Thickness source)
		{
			return source.Left + source.Right;
		}

		public static double GetHeight(this Thickness source)
		{
			return source.Top + source.Bottom;
		}

		public static Rect OffsetTopLeft(this Rect source, Thickness thickness)
		{
			return new Rect(
				source.X + thickness.Left,
				source.Y + thickness.Top,
				source.Width,
				source.Height);
		}

		public static Rect Inflate(this Rect source, Thickness thickness)
		{
			return new Rect(
				source.X - thickness.Left,
				source.Y - thickness.Top,
				source.Width + thickness.GetWidth(),
				source.Height + thickness.GetHeight());
		}

		public static Rect Deflate(this Rect source, Thickness thickness)
		{
			return new Rect(
				source.X + thickness.Left,
				source.Y + thickness.Top,
				Math.Max(0, source.Width - thickness.GetWidth()),
				Math.Max(0, source.Height - thickness.GetHeight()));
		}
	}
}
