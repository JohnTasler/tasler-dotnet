using System.Text.RegularExpressions;

#if WINDOWS_UWP
using Windows.UI.Xaml;
using ConverterBase = Tasler.UI.Xaml.Converters.BaseValueConverter;
using CultureInfo = System.String;
namespace Tasler.UI.Xaml.Converters;
#elif WINDOWS_WPF
using System.Windows;
using System.Globalization;
using ConverterBase = Tasler.Windows.Converters.SingletonValueConverter<Tasler.Windows.Converters.BooleanToVisibilityConverter>;
namespace Tasler.Windows.Converters;
#endif

public partial class ThicknessModifierConverter : ConverterBase
{
	#region Overrides

	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is Thickness originalThickness && parameter is string modifierString)
		{
			var thicknessModifier = ThicknessModifier.Parse(culture, modifierString);
			return thicknessModifier.ModifyThickness(originalThickness);
		}

		return value;
	}

	#endregion Overrides

	public partial class ThicknessModifier
	{
		private static readonly Regex _whitespaceSequence = GetWhitespaceSequenceRegex();

		private ThicknessModifier() { }

		public Func<double, double>? ModifyLeft   { get; private set; }
		public Func<double, double>? ModifyTop    { get; private set; }
		public Func<double, double>? ModifyRight  { get; private set; }
		public Func<double, double>? ModifyBottom { get; private set; }

		public static ThicknessModifier Parse(CultureInfo culture, string modifierString)
		{
			// Remove all whitespace from the modifier string
			modifierString = _whitespaceSequence.Replace(modifierString, string.Empty);

			// Tokenize the modifier string
			var cultureInfo = GetCultureInfo(culture);
			var listSeparator = cultureInfo.TextInfo.ListSeparator;
			var tokens = modifierString.Split([listSeparator], StringSplitOptions.None);
			if (tokens.Length != 4)
				throw new FormatException("INVALID FORMAT");

			// Parse each token in the modifier string and return an instance of ThicknessModifier
			return new ThicknessModifier
			{
				ModifyLeft   = ParseToken(tokens[0]),
				ModifyTop    = ParseToken(tokens[1]),
				ModifyRight  = ParseToken(tokens[2]),
				ModifyBottom = ParseToken(tokens[3]),
			};
		}

		public Thickness ModifyThickness(Thickness thickness)
		{
			return new Thickness(
				this.ModifyLeft?.Invoke  (thickness.Left  ) ?? thickness.Left  ,
				this.ModifyTop?.Invoke   (thickness.Top   ) ?? thickness.Top   ,
				this.ModifyRight?.Invoke (thickness.Right ) ?? thickness.Right ,
				this.ModifyBottom?.Invoke(thickness.Bottom) ?? thickness.Bottom
				);
		}

		private static Func<double, double> ParseToken(string token)
		{
			if (string.IsNullOrEmpty(token) || token == "*" || token == "*1")
				return t => t;

			var value = default(double);
			if (double.TryParse(token, out value))
				return t => value;

			if (!double.TryParse(token.Substring(1), out value))
				throw new FormatException("INVALID FORMAT");

			return token[0] switch
			{
				'+' => t => t + value,
				'-' => t => t - value,
				'*' => t => t * value,
				'/' => t => t / value,
				'%' => t => t % value,
				_ => throw new FormatException("INVALID FORMAT"),
			};
		}

		[GeneratedRegex(@"\s+")]
		private static partial Regex GetWhitespaceSequenceRegex();
	}

	//public class ThicknessModifierTypeConverter : TypeConverter
	//{
	//	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	//	{
	//		var valueString = value as string;
	//		if (valueString == null)
	//			throw new NotSupportedException("INVALID SUPPORT");

	//		return ThicknessModifier.Parse(culture, valueString);
	//	}
	//}
}
