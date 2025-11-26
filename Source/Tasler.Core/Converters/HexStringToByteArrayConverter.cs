using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Tasler.Converters;

// TODO: NEEDS_UNIT_TESTS

public partial class HexStringToByteArrayConverter : TypeConverter
{
	private static readonly Regex _nonHexDigitRegex = NonHexDigitRegex();

	/// <summary>
	/// Determines whether this converter can convert an object of the specified source type to the converter's target type.
	/// </summary>
	/// <param name="sourceType">The type to evaluate for conversion support.</param>
	/// <returns>`true` if <paramref name="sourceType"/> is `string`; otherwise the result from the base converter.</returns>
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

	/// <summary>
	/// Converts a byte array to a space-separated string of two-digit uppercase hexadecimal values when the destination type is <see cref="string"/>.
	/// </summary>
	/// <returns>The space-separated uppercase hex string for the provided byte array, or the result returned by the base converter for other inputs.</returns>
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

	/// <summary>
	/// Creates a regular expression that matches any character that is not a hexadecimal digit (0-9, a-f, A-F).
	/// </summary>
	/// <returns>A <see cref="Regex"/> that matches characters other than 0-9, a-f, or A-F.</returns>
	[GeneratedRegex("[^0-9a-fA-F]")]
	private static partial Regex NonHexDigitRegex();
}