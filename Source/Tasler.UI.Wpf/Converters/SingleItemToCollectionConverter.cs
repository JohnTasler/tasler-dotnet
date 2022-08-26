using System;
using System.Globalization;
using System.Linq;

namespace Tasler.Windows.Converters
{
	public class SingleItemToCollectionConverter : SingletonValueConverter<SingleItemToCollectionConverter>
	{
		#region Overrides

		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value != null
				? new object[] { value }
				: Enumerable.Empty<object>();
		}

		#endregion Overrides
	}
}
