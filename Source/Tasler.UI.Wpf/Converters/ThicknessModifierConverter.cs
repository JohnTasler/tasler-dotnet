using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;

namespace Tasler.Windows.Converters
{
	public class ThicknessModifierConverter : SingletonValueConverter<ThicknessModifierConverter>
	{
		#region Overrides

		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var modifierString = parameter as string;
			if (value is Thickness && modifierString != null)
			{
				var originalThickness = (Thickness)value;
				var thicknessModifier = ThicknessModifier.Parse(culture, modifierString);
				return thicknessModifier.ModifyThickness(originalThickness);
			}

			return value;
		}

		#endregion Overrides

		public class ThicknessModifier
		{
			private static readonly Regex _whitespaceSequence = new Regex(@"\s+");

			private ThicknessModifier() { }

			public Func<double, double> ModifyLeft   { get; private set; }
			public Func<double, double> ModifyTop    { get; private set; }
			public Func<double, double> ModifyRight  { get; private set; }
			public Func<double, double> ModifyBottom { get; private set; }

			public static ThicknessModifier Parse(CultureInfo culture, string modifierString)
			{
				// Remove all whitespace from the modifier string
				modifierString = _whitespaceSequence.Replace(modifierString, string.Empty);

				// Tokenize the modifier string
				culture = culture ?? CultureInfo.CurrentCulture;
				var listSeparator = culture.TextInfo.ListSeparator;
				var tokens = modifierString.Split(new[] { listSeparator }, StringSplitOptions.None);
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
					this.ModifyLeft  (thickness.Left  ),
					this.ModifyTop   (thickness.Top   ),
					this.ModifyRight (thickness.Right ),
					this.ModifyBottom(thickness.Bottom)
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

				switch (token[0])
				{
					case '+':
						return t => t + value;
					case '-':
						return t => t - value;
					case '*':
						return t => t * value;
					case '/':
						return t => t / value;
					case '%':
						return t => t % value;
				}

				throw new FormatException("INVALID FORMAT");
			}
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
}
