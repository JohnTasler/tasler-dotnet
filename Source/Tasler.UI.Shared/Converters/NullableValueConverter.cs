using CommunityToolkit.Diagnostics;

#if WINDOWS_UWP
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters;
#elif WINDOWS_WPF
using System.Globalization;
using ConverterBase = Tasler.Windows.Converters.SingletonValueConverter<Tasler.Windows.Converters.NullableValueConverter>;
namespace Tasler.Windows.Converters;
#endif

public partial class NullableValueConverter : ConverterBase
{
	#region Overrides

	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is null)
			return value;

		Type? underlyingType = Nullable.GetUnderlyingType(value.GetType());
		Guard.IsNotNull(underlyingType);
		Guard.IsTrue(underlyingType == targetType);

		return System.Convert.ChangeType(value, underlyingType);
	}

	#endregion Overrides
}
