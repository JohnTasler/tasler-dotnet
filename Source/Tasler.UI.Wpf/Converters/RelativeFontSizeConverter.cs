using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Converters
{
	public class RelativeFontSizeConverter : SingletonValueConverter<RelativeFontSizeConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var visual = value as Visual;
			if (visual != null)
			{
				var d = value as DependencyObject;
				if (d != null)
				{
					var convertedParameter = new FontSizeConverter().ConvertFrom(null, culture, parameter);
					if (convertedParameter is double)
					{
						// Walk the visual tree from the specified Visual
						d = d.GetSelfAndVisualAncestors().FirstOrDefault(v => v.GetValue(TextElement.FontSizeProperty) is double);
						if (d != null)
						{
							var fontSize = (double)d.GetValue(TextElement.FontSizeProperty);
							var relativeFontSize = (double)convertedParameter;
							return fontSize + relativeFontSize;
						}
					}
				}
			}

			return null;
		}
	}
}
