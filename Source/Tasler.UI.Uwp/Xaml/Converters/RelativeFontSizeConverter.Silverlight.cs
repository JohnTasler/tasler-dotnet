using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Converters
{
	public class RelativeFontSizeConverter : SingletonValueConverter<RelativeFontSizeConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var d = value as DependencyObject;
			if (d != null)
			{
				d = d.GetSelfAndVisualAncestors().FirstOrDefault(v => v.GetValue(TextElement.FontSizeProperty) is double);
				if (d != null)
				{
					var fontSize = (double)d.GetValue(TextElement.FontSizeProperty);
					var relativeFontSize = System.Convert.ToDouble(parameter, culture);
					return fontSize + relativeFontSize;
				}
			}

			return null;
		}
	}
}
