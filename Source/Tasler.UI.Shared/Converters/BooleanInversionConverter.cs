using System;

#if WINDOWS_UWP
using Windows.Foundation;
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters
#elif WINDOWS_WPF
using System.Globalization;
using ConverterBase = Tasler.Windows.Converters.SingletonValueConverter<Tasler.Windows.Converters.BooleanInversionConverter>;
namespace Tasler.Windows.Converters
#endif
{
	public class BooleanInversionConverter : ConverterBase
	{
		#region Overrides

		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
		  if (value is bool)
		    value = !(bool)value;

			return value;
		}

		#endregion Overrides
	}
}
