#if WINDOWS_UWP
using Windows.Foundation;
namespace Tasler.Foundation;
#elif WINDOWS_WPF
using System.Windows;
namespace Tasler.Windows;
#endif

// TODO: NEEDS_UNIT_TESTS

public static class PointExtensions
{
	public static Point Round(this Point @this)
	{
		var decimals = 0;
		var x = Math.Round(@this.X, decimals);
		var y = Math.Round(@this.Y, decimals);
		return new Point(x, y);
	}
}
