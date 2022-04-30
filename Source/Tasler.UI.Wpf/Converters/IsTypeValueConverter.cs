using System;
using System.Globalization;

namespace Tasler.Windows.Converters
{
	public class IsTypeValueConverter : SingletonValueConverter<IsTypeValueConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
			{
				var type = parameter as Type;
				if (type != null)
					value = type.IsAssignableFrom(value.GetType());
			}

			return value;
		}
	}
}
