using System;
using System.Windows;

namespace Tasler.Windows.Extensions
{
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
