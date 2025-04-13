using System.Globalization;

#if WINDOWS_UWP
using Windows.UI;
using CultureInfo = string;

namespace Tasler.UI.Xaml.Converters;
using ConverterBase = BaseValueConverter;

#elif WINDOWS_WPF

using System.Windows.Media;

namespace Tasler.Windows.Converters;
using ConverterBase = SingletonValueConverter<ColorWithAlphaConverter>;

#endif

public partial class ColorWithAlphaConverter : ConverterBase
{
	public ColorWithAlphaConverter()
	{
	}

	#region IValueConverter Members

	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is Color color)
		{
			int alpha = 0xFF;
			if (parameter is string alphaString &&
				double.TryParse(alphaString, NumberStyles.Float, GetCultureInfo(culture), out var alphaDouble))
			{
				alphaDouble = Math.Min(Math.Max(alphaDouble, 0.0), 1.0);
				alpha = (int)(alpha * alphaDouble);
			}

			value = Color.FromArgb((byte)alpha, (byte)color.R, (byte)color.G, (byte)color.B);
		}

		return value;
	}

	#endregion IValueConverter Members
}
