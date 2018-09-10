using System;

#if WINDOWS_UWP
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters
#elif WINDOWS_WPF
using System.Globalization;
using ConverterBase = Tasler.Windows.Converters.SingletonValueConverter<Tasler.Windows.Converters.IsEqualConverter>;
namespace Tasler.Windows.Converters
#endif
{
    public class IsEqualConverter : ConverterBase
    {
        #region IValueConverter Members

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return parameter == null;

            var valueType = value.GetType();
            if (parameter != null && parameter?.GetType() != valueType)
                parameter = System.Convert.ChangeType(parameter, valueType, GetCultureInfo(culture));

            return object.Equals(value, parameter);
        }

        #endregion IValueConverter Members
    }
}
