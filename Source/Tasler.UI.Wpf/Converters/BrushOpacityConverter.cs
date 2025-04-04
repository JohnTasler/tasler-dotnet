using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Tasler.Windows.Converters;

/// <summary>
/// Represents an <see cref="IValueConverter"/> that converts an input <see cref="Brush"/> value to a similar
/// <see cref="Brush"/>, with its alpha value set to that specified in the converter parameter.
/// </summary>
public partial class BrushOpacityConverter : SingletonValueConverter<BrushOpacityConverter>
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
	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is not Brush brush)
			return value;

		double opacity = 1.0;
		if (parameter is not null)
		{
			if (parameter is string)
			{
				double.TryParse(parameter.ToString(), out opacity);
			}
			else if (parameter.GetType().Is<double>())
			{
				opacity = (double)parameter;
			}
		}

		var newBrush = brush.Clone();
		newBrush.Opacity *= Math.Clamp(opacity, 0.0, 1.0);
		return newBrush;
	}
	#endregion IValueConverter Members
}
