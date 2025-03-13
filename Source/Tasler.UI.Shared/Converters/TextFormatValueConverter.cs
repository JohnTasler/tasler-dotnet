using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Tasler.Windows.Data
{
  /// <summary>
  /// Formats a value using a format string, specified as the converter parameter.
  /// </summary>
  /// <remarks>
  /// This class is a singleton. Use the <see cref="Instance"/> property to retrieve the singleton instance.
  /// </remarks>
  [Localizability(LocalizationCategory.NeverLocalize)]
  public class TextFormatValueConverter : IValueConverter
  {
    #region Singleton Implementation
    private static readonly IValueConverter instance = new TextFormatValueConverter();
    private TextFormatValueConverter()
    {
    }

    /// <summary>
    /// Gets the singleton instance of the <see cref="TextFormatValueConverter"/> class.
    /// </summary>
    public static IValueConverter Instance
    {
      get
      {
        return instance;
      }
    }
    #endregion Singleton Implementation

    #region IValueConverter Members
    object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (parameter is string)
        value = string.Format(culture, (string)parameter, value);
      return value;
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
    #endregion IValueConverter Members
  }

}
