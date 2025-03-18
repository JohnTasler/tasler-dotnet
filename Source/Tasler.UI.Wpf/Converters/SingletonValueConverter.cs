using System;
using System.Globalization;
using System.Windows.Data;

namespace Tasler.Windows.Converters
{
	public abstract class SingletonValueConverter<T> : IValueConverter
		where T : IValueConverter, new()
	{
		#region Static Properties
		public static IValueConverter Instance
		{
			get { return _instance; }
		}
		private static readonly IValueConverter _instance = new T();
		#endregion Static Properties

		#region Overridable IValueConverter Implementation
		public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

		public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
		#endregion Overridable IValueConverter Implementation
	}
}
