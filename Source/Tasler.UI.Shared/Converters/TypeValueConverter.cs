using System;

#if WINDOWS_UWP
using Windows.Foundation;
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters
#elif WINDOWS_WPF
using System.Globalization;
using System.Windows;
using ConverterBase = Tasler.Windows.Converters.SingletonValueConverter<Tasler.Windows.Converters.TypeValueConverter>;
namespace Tasler.Windows.Converters
#endif
{
	public class TypeValueConverter : ConverterBase
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value?.GetType();
		}
	}
}
