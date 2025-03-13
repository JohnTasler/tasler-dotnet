using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace Tasler.Windows.Data
{
  public class RelativeFontSizeConverter : IValueConverter
  {
    #region Singleton Implementation
    private static readonly IValueConverter instance = new RelativeFontSizeConverter();
    private RelativeFontSizeConverter()
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
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      Visual visual = value as Visual;
      if (visual != null)
      {
        DependencyObject d = value as DependencyObject;
        if (d != null)
        {
          object convertedParameter = new FontSizeConverter().ConvertFrom(null, culture, parameter);
          if (convertedParameter is double)
          {
            // Walk the visual tree from the specified Visual
            while (d != null && !(d.GetValue(TextElement.FontSizeProperty) is double))
              d = VisualTreeHelper.GetParent(d);

            if (d != null)
            {
              double fontSize = (double)d.GetValue(TextElement.FontSizeProperty);
              double relativeFontSize = (double)convertedParameter;
              return fontSize + relativeFontSize;
            }
          }
        }
      }

      return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    #endregion IValueConverter Members
  }
}
