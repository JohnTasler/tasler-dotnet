using System;
using System.Globalization;

namespace Tasler.Windows.Converters
{
	public class NullWhenDateTimeMinimumConverter : SingletonValueConverter<NullWhenDateTimeMinimumConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var result = value is DateTime && Equals(value, DateTime.MinValue) ? null : value;
			return result;
		}
	}
}