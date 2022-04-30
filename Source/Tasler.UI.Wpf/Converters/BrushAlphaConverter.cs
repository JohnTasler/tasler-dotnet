using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Tasler.Windows.Converters
{
	/// <summary>
	/// Represents an <see cref="IValueConverter"/> that converts an input <see cref="Brush"/> value to a similar
	/// <see cref="Brush"/>, with its alpha value set to that specified in the converter parameter.
	/// </summary>
	public class BrushOpacityConverter : IValueConverter
	{
		#region IValueConverter Members

		/// <summary>
		/// Converts a value.
		/// </summary>
		/// <param name="value">The value produced by the binding source.</param>
		/// <param name="targetType">The type of the binding target property.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>
		/// A converted value. If the method returns null, the valid null value is used.
		/// </returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var brush = value as Brush;
			if (brush == null)
			{
				throw new ArgumentException("Unexpected type", "value");
			}

			var opacity = double.NaN;
			if (parameter is string && double.TryParse(parameter.ToString(), out opacity))
			{
				var newBrush = brush.Clone();
				newBrush.Opacity *= opacity;

				return newBrush;
			}

			return value;
		}

		/// <summary>
		/// Converts a value.
		/// </summary>
		/// <param name="value">The value that is produced by the binding target.</param>
		/// <param name="targetType">The type to convert to.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>
		/// A converted value. If the method returns null, the valid null value is used.
		/// </returns>
		/// <exception cref="NotImplementedException">This interface method is neither used nor implemented.</exception>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion IValueConverter Members
	}
}
