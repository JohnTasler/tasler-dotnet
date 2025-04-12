#if WINDOWS_UWP
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters;
#elif WINDOWS_WPF
using System.Globalization;
using ConverterBase = Tasler.Windows.Converters.SingletonValueConverter<Tasler.Windows.Converters.ToBooleanConverter>;
namespace Tasler.Windows.Converters;
#endif

public partial class SingleItemToCollectionConverter : ConverterBase
{
	#region Overrides

	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return value is not null
			? new object[] { value }
			: [];
	}

	#endregion Overrides
}
