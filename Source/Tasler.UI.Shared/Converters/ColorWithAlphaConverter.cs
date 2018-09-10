using System;
using System.Globalization;

#if WINDOWS_UWP
using Windows.UI;
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters
#elif WINDOWS_WPF
using System.Windows.Media;
using ConverterBase = Tasler.Windows.Converters.SingletonValueConverter<Tasler.Windows.Converters.ColorWithAlphaConverter>;
namespace Tasler.Windows.Converters
#endif
{
    public class ColorWithAlphaConverter : ConverterBase
    {
        #region IValueConverter Members

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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
}
