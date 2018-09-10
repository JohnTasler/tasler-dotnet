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
    /// Extension methods for the <see cref="Rect"/> structure.
    /// </summary>
    public static class RectExtensions
    {
        public static Rect Inflate(this Rect @this, double left, double top, double right, double bottom)
        {
            @this.X -= left;
            @this.Y -= top;
            @this.Width += left + right;
            @this.Height += top + bottom;
            return @this;
        }

        public static Rect Deflate(this Rect @this, double left, double top, double right, double bottom)
        {
            return @this.Inflate(-left, -top, -right, -bottom);
        }

        public static Rect OffsetTopLeft(this Rect @this, Thickness thickness)
        {
            return new Rect(
                @this.X + thickness.Left,
                @this.Y + thickness.Top,
                @this.Width,
                @this.Height);
        }

        public static Rect Inflate(this Rect @this, Thickness thickness)
        {
            return new Rect(
                @this.X - thickness.Left,
                @this.Y - thickness.Top,
                @this.Width + thickness.GetWidth(),
                @this.Height + thickness.GetHeight());
        }

        public static Rect Deflate(this Rect @this, Thickness thickness)
        {
            return new Rect(
                @this.X + thickness.Left,
                @this.Y + thickness.Top,
                Math.Max(0, @this.Width - thickness.GetWidth()),
                Math.Max(0, @this.Height - thickness.GetHeight()));
        }

    }
}
