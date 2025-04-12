#if WINDOWS_UWP
using Windows.UI.Xaml;
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters;
#elif WINDOWS_WPF
using System.Globalization;
using System.Windows;
using ConverterBase = Tasler.Windows.Converters.SingletonValueConverter<Tasler.Windows.Converters.IsTypeValueConverter>;
namespace Tasler.Windows.Converters;
#endif

public partial class IsTypeValueConverter : ConverterBase
{
	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is not null && parameter is Type type)
		{
			if (type is not null)
				value = type.IsAssignableFrom(value.GetType());
		}

		return value;
	}
}
