#if WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Documents;
using Tasler.UI.Xaml.Extensions;
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters;

#elif WINDOWS_WPF
using System.Globalization;
using System.Windows;
using System.Windows.Documents;
using ConverterBase = Tasler.Windows.Converters.SingletonValueConverter<Tasler.Windows.Converters.RelativeFontSizeConverter>;
using Tasler.Windows.Extensions;
namespace Tasler.Windows.Converters;

#endif

public partial class RelativeFontSizeConverter : ConverterBase
{
	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is DependencyObject d)
		{
			if (new FontSizeConverter().ConvertFrom(null, GetCultureInfo(culture), parameter ?? double.NaN) is double convertedValue)
			{
				// Walk the visual tree from the specified Visual
				var textualElement = d.GetSelfAndVisualAncestors().FirstOrDefault(HasFontSizeProperty);
				if (textualElement is not null)
				{
					var originalFontSize = (double)textualElement.GetValue(TextElement.FontSizeProperty);
					var relativeFontSize = convertedValue;
					return originalFontSize + relativeFontSize;
				}
			}
		}

		return null;
	}

	private static bool HasFontSizeProperty(DependencyObject d)
	{
		return d.GetValue(TextElement.FontSizeProperty) is double;
	}
}
