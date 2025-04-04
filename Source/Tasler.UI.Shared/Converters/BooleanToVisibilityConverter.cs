#if WINDOWS_UWP
using Windows.UI.Xaml;
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters;
#elif WINDOWS_WPF
using System.Globalization;
using System.Windows;
using ConverterBase = Tasler.Windows.Converters.SingletonValueConverter<Tasler.Windows.Converters.BooleanToVisibilityConverter>;
namespace Tasler.Windows.Converters;
#endif

/// <summary>
/// An imlementation of <see cref="IValueConverter"/> that converts a boolean value to one of two
/// <see cref="Visibility"/> values, specified by the <see cref="TrueValue"/> and <see cref="FalseValue"/>
/// properties.
/// </summary>
public partial class BooleanToVisibilityConverter : ConverterBase
{
	#region Constructors
	public BooleanToVisibilityConverter()
		: this(Visibility.Visible, Visibility.Collapsed)
	{
	}

	public BooleanToVisibilityConverter(Visibility trueValue, Visibility falseValue)
	{
		this.TrueValue = trueValue;
		this.FalseValue = falseValue;
	}
	#endregion Constructors

	#region Properties
	public Visibility TrueValue { get; set; }

	public Visibility FalseValue { get; set; }
	#endregion Properties

	#region IValueConverter Members

	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		bool boolValue = System.Convert.ToBoolean(value);
		return boolValue? this.TrueValue : this.FalseValue;
	}

	public override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is Visibility visibility)
		{
			if (visibility == this.TrueValue)
				return true;
			else if (visibility == this.FalseValue)
				return false;
		}

		return false;
	}

	#endregion IValueConverter Members
}
