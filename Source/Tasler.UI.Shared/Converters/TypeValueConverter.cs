#if WINDOWS_UWP
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters;
#elif WINDOWS_WPF
using System.Globalization;
namespace Tasler.Windows.Converters;
using ConverterBase = SingletonValueConverter<TypeValueConverter>;
#endif

public partial class TypeValueConverter : ConverterBase
{
	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return value?.GetType();
	}
}
