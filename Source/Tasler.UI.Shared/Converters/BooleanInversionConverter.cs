using CommunityToolkit.Diagnostics;

#if WINDOWS_UWP
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters
#elif WINDOWS_WPF
using System.Globalization;
using ConverterBase = Tasler.Windows.Converters.SingletonValueConverter<Tasler.Windows.Converters.BooleanInversionConverter>;
namespace Tasler.Windows.Converters
#endif
{
	public partial class BooleanInversionConverter : ConverterBase
	{
		#region Overrides

		public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			Guard.IsOfType<bool>(targetType);

			bool boolValue = System.Convert.ToBoolean(value, GetCultureInfo(culture));
			return !boolValue;
		}

		public override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
			=> Convert(value, targetType, parameter, culture);

		#endregion Overrides
	}
}
