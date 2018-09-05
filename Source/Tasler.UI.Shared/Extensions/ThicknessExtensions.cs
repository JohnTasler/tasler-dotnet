using System;

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

		/// <summary>
		/// Determines if the specified <see cref="Thickness"/> is "empty", meaning all values are zero.
		/// </summary>
		/// <param name="@this">The <see cref="Thickness"/> to test. As an extension method, this is typically not
		/// specified explicitly.</param>
		/// <returns><code>true</code> if all values are zero; otherwise <code>false</code>.</returns>
		public static bool IsEmpty(this Thickness @this)
		{
			return 0.0 == @this.Left + @this.Top + @this.Right + @this.Bottom;
		}

		/// <summary>
		/// Determines if all values of the specified <see cref="Thickness"/> are <see cref="double.Nan"/>.
		/// </summary>
		/// <param name="@this">The <see cref="Thickness"/> to test. As an extension method, this is typically not
		/// specified explicitly.</param>
		/// <returns><code>true</code> if all values are <see cref="double.Nan"/>; otherwise <code>false</code>.</returns>
		public static bool IsNan(this Thickness @this)
		{
			return double.IsNaN(@this.Left) && double.IsNaN(@this.Top) && double.IsNaN(@this.Right) && double.IsNaN(@this.Bottom);
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
