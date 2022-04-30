using System;
using System.Globalization;

namespace Tasler.Windows.Converters
{
	public class TypeValueConverter : SingletonValueConverter<TypeValueConverter>
	{
		#region Overrides

		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value != null
				? value.GetType()
				: null;
		}

		#endregion Overrides
	}
}
