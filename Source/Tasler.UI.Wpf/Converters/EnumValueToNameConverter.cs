using System;
using System.Globalization;

namespace Tasler.Windows.Converters
{
	public class EnumValueToNameConverter : SingletonValueConverter<EnumValueToNameConverter>
	{
		#region Overrides

		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var enumType = parameter as Type;
			if (enumType != null && enumType.IsEnum)
			{
				try
				{
					var underlyingValue = System.Convert.ChangeType(value, Enum.GetUnderlyingType(enumType), culture);
					if (Enum.IsDefined(enumType, underlyingValue))
					{
						var name = Enum.GetName(enumType, value);
						if (name != null)
							value = name;
					}
				}
				catch (InvalidCastException) { }
				catch (FormatException)      { }
				catch (OverflowException)    { }
			}

			return value;
		}

		#endregion Overrides
	}
}
