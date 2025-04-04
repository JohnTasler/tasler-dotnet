#if WINDOWS_UWP
using Windows.UI.Xaml;
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters;
#elif WINDOWS_WPF
using System.Globalization;
using System.Windows;
using ConverterBase = Tasler.Windows.Converters.SingletonValueConverter<Tasler.Windows.Converters.EnumValueToNameConverter>;
namespace Tasler.Windows.Converters;
#endif

public partial class EnumValueToNameConverter : ConverterBase
{
	#region Overrides

	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is null)
			return value;

		var enumType = parameter as Type;
		if (enumType is not null && enumType.IsEnum)
		{
			try
			{
				var underlyingValue = System.Convert.ChangeType(value, Enum.GetUnderlyingType(enumType), GetCultureInfo(culture));
				if (underlyingValue is not null && Enum.IsDefined(enumType, underlyingValue))
				{
					var name = Enum.GetName(enumType, value);
					if (name is not null)
						value = name;
				}
			}
			catch (InvalidCastException) { }
			catch (FormatException) { }
			catch (OverflowException) { }
		}

		return value;
	}

	#endregion Overrides
}
