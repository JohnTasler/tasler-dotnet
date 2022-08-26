using System;
using System.Globalization;
using System.Windows.Input;

namespace Tasler.Windows.Converters
{
    public class KeyInteropConverter : SingletonValueConverter<KeyInteropConverter>
    {
        #region Overrides

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Key)
            {
                value = KeyInterop.VirtualKeyFromKey((Key)value);
            }
            else
            {
                try
                {
                    var intValue = System.Convert.ToInt32(value, culture);
                    value = KeyInterop.KeyFromVirtualKey(intValue);
                }
                catch (InvalidCastException) { }
                catch (FormatException)      { }
                catch (OverflowException)    { }
            }

            if (targetType.Is<string>())
                value = value.ToString();

            return value;
        }

        #endregion Overrides
    }
}
