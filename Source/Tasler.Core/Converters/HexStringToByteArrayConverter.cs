using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Tasler.Converters;

// TODO: NEEDS_UNIT_TESTS

public class HexStringToByteArrayConverter : TypeConverter
{
	private static readonly Regex _nonHexDigitRegex = new Regex("[^0-9a-fA-F]");

	public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
	{
		if (sourceType == typeof(string))
			return true;
		return base.CanConvertFrom(context, sourceType);
	}

	public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
	{
		if (destinationType == typeof(string))
			return true;
		return base.CanConvertTo(context, destinationType);
	}

	public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
	{
		if (value is string input)
		{
			input = _nonHexDigitRegex.Replace(input, "");
			if (input.Length % 2 != 0)
				return value;

			var bytes = new byte[input.Length / 2];
			for (var index = 0; index < bytes.Length; ++index)
			{
				var byteString = input.Substring(index * 2, 2);
				bytes[index] = Convert.ToByte(byteString, 16);
			}

			return bytes;
		}

		return base.ConvertFrom(context, culture, value);
	}

	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
	{
		if (destinationType == typeof(string) && value is byte[])
		{
			var bytes = (byte[])value;
			var byteStrings = new string[bytes.Length];
			for (var index = 0; index < bytes.Length; ++index)
				byteStrings[index] = bytes[index].ToString("X2");
			return string.Join(" ", byteStrings);
		}

		return base.ConvertTo(context, culture, value, destinationType);
	}
}
