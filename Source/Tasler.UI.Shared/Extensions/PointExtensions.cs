using System;

#if WINDOWS_UWP
using Windows.Foundation;
namespace Tasler.Foundation
#elif WINDOWS_WPF
using System.Windows;
namespace Tasler.Windows
#endif
{
    // TODO: NEEDS_UNIT_TESTS

    public static class PointExtensions
    {
        public static Point Round(this Point target)
        {
            var decimals = 0;
            var x = Math.Round(target.X, decimals);
            var y = Math.Round(target.Y, decimals);
            return new Point(x, y);
        }
    }
}
