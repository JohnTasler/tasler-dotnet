using System;
#if WINDOWS_UWP
using ConverterBase = Windows.UI.Xaml.Data.IValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters
#elif WINDOWS_WPF
using System.Globalization;
using ConverterBase = System.Windows.Data.IValueConverter;
namespace Tasler.Windows.Converters
#endif
{
	public abstract class BaseValueConverter : ConverterBase
	{
		#region Overridable IValueConverter Implementation

		public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

		public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion Overridable IValueConverter Implementation
	}
}
