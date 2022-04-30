using System;
using System.Globalization;

namespace Tasler.Windows.Converters
{
	public class AsTypeValueConverter : SingletonValueConverter<AsTypeValueConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
			{
				var valueType = value.GetType();

				var type = parameter as Type;
				if (type != null && type.IsAssignableFrom(valueType))
					return value;

				if (targetType.IsAssignableFrom(valueType))
					return value;
			}
			return null;
		}
	}
}
