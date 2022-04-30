using System;
using System.Globalization;

namespace Tasler.Windows.Converters
{
	public class BooleanInversionConverter : SingletonValueConverter<BooleanInversionConverter>
	{
		#region Overrides

		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
		  if (value is bool)
		    value = !(bool)value;
		
			return value;
		}

		#endregion Overrides
	}
}
