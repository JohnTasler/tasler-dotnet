using System;
using System.Globalization;
using System.Windows;

namespace Tasler.Windows.Converters
{
	public class BooleanToVisibilityConverter : SingletonValueConverter<BooleanToVisibilityConverter>
	{
		public BooleanToVisibilityConverter()
		{
			this.FalseValue = Visibility.Collapsed;
			this.TrueValue = Visibility.Visible;
		}

		public Visibility FalseValue { get; set; }

		public Visibility TrueValue { get; set; }

		#region Overrides

		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
		  if (value is bool)
		    value = (bool)value ? this.TrueValue : this.FalseValue;
		
			return value;
		}

		#endregion Overrides
	}
}
