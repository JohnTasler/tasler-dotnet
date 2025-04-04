#if WINDOWS_UWP
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters;
#elif WINDOWS_WPF
using System.Globalization;
using ConverterBase = Tasler.Windows.Converters.SingletonValueConverter<Tasler.Windows.Converters.NullWhenDateTimeMinimumConverter>;
namespace Tasler.Windows.Converters;
#endif


public class NullWhenDateTimeMinimumConverter : ConverterBase
{
	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		var result = value is DateTime && Equals(value, DateTime.MinValue) ? null : value;
		return result;
	}
}
