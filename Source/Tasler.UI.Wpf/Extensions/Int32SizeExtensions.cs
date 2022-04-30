using System.Windows;

namespace Tasler.Windows.Extensions
{
	public static class Int32SizeExtensions
	{
		public static Size ToSize(this Int32Size source)
		{
			return new Size(source.Width, source.Height);
		}
	}
}
