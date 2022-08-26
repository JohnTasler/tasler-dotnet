using System;

#if WINDOWS_UWP
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters
#elif WINDOWS_WPF
using System.Globalization;
using ConverterBase = Tasler.Windows.Converters.SingletonValueConverter<Tasler.Windows.Converters.NullableValueConverter>;
namespace Tasler.Windows.Converters
#endif
{
    public class NullableValueConverter : ConverterBase
    {
        #region Overrides

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return value;

            var nullable = typeof(Nullable<>);
            var nullableType = nullable.MakeGenericType(value.GetType());
            var result = Activator.CreateInstance(nullableType, value);
            return result;
        }

        #endregion Overrides
    }
}
