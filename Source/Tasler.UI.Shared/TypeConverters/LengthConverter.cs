#if WINDOWS_UWP
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Runtime.CompilerServices;
using CommunityToolkit.Diagnostics;
// using Tasler.UI.Xaml.Properties;

namespace Tasler.UI.Xaml;

/// <summary>
/// Converter class for converting instances of other types to and from double representing length.
/// </summary>
public class LengthConverter : TypeConverter
{
	#region Public Methods

	/// <summary>
	/// Determines whether conversion is possible from a specified type to a <see cref="T:System.Double" />
	/// that represents an object's length.
	/// </summary>
	/// <param name="typeDescriptorContext">Provides contextual information about a component.</param>
	/// <param name="sourceType">Identifies the data type to evaluate for conversion.</param>
	/// <returns>
	/// <see langword="true" /> if conversion is possible; otherwise, <see langword="false" />.
	/// </returns>
	public override bool CanConvertFrom(ITypeDescriptorContext? typeDescriptorContext, Type sourceType)
	{
		// We can only handle strings, integral and floating types
		switch (Type.GetTypeCode(sourceType))
		{
			case TypeCode.String:
			case TypeCode.Decimal:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Int16:
			case TypeCode.Int32:
			case TypeCode.Int64:
			case TypeCode.UInt16:
			case TypeCode.UInt32:
			case TypeCode.UInt64:
				return true;
			default:
				return false;
		}
	}

	/// <summary>
	/// CanConvertTo - Returns whether or not this class can convert to a given type.
	/// </summary>
	/// <returns>
	/// bool - True if this converter can convert to the provided type, false if not.
	/// </returns>
	/// <param name="typeDescriptorContext"> The ITypeDescriptorContext for this call. </param>
	/// <param name="destinationType"> The Type being queried for support. </param>
	public override bool CanConvertTo(ITypeDescriptorContext? typeDescriptorContext, Type? destinationType)
	{
		// We can convert to an InstanceDescriptor or to a string.
		return destinationType == typeof(InstanceDescriptor) || destinationType == typeof(string);
	}

	/// <summary>Converts instances of other data types into instances of <see cref="T:System.Double" /> that represent an object's length. </summary>
	/// <param name="typeDescriptorContext">Provides contextual information about a component.</param>
	/// <param name="cultureInfo">Represents culture-specific information that is maintained during a conversion.</param>
	/// <param name="source">Identifies the object that is being converted to <see cref="T:System.Double" />.</param>
	/// <returns>An instance of <see cref="T:System.Double" /> that is the value of the conversion.</returns>
	/// <exception cref="T:System.ArgumentNullException">Occurs if the <paramref name="source" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">Occurs if the <paramref name="source" /> is not <see langword="null" /> and is not a valid type for conversion.</exception>
	public override object ConvertFrom(ITypeDescriptorContext? typeDescriptorContext, CultureInfo? cultureInfo, object source)
	{
		if (source is null)
			throw base.GetConvertFromException(source);

		if (source is string value)
			return LengthConverter.FromString(value, cultureInfo);

		return Convert.ToDouble(source, cultureInfo);
	}

	/// <summary>
	/// Converts other types into instances of <see cref="T:System.Double" /> that represent an
	/// object's length. </summary>
	/// <param name="typeDescriptorContext">
	///   Describes context information of a component, such as its container and
	/// <see cref="T:System.ComponentModel.PropertyDescriptor" />.
	/// </param>
	/// <param name="cultureInfo">
	///   Identifies culture-specific information, including the writing system and the calendar that is used.
	/// </param>
	/// <param name="value">Identifies the <see cref="T:System.Object" /> that is being converted.</param>
	/// <param name="destinationType">
	///   The data type that this instance of <see cref="T:System.Double" /> is being converted to.
	/// </param>
	/// <returns>A new <see cref="T:System.Object" /> that is the value of the conversion.</returns>
	/// <exception cref="T:System.ArgumentNullException">
	///   Occurs if the <paramref name="value" /> is <see langword="null" />.
	///   </exception>
	/// <exception cref="T:System.ArgumentException">
	///   Occurs if the <paramref name="value" /> is not <see langword="null" /> and is not a
	///   <see cref="T:System.Windows.Media.Brush" />, or the <paramref name="destinationType" /> is not valid.
	/// </exception>
	public override object ConvertTo(
		ITypeDescriptorContext? typeDescriptorContext,
		CultureInfo? cultureInfo,
		object? value,
		Type? destinationType)
	{
		Guard.IsNotNull(destinationType);

		if (value is not null && value is double num)
		{
			if (destinationType == typeof(string))
			{
				return double.IsNaN(num) ? "Auto" : Convert.ToString(num, cultureInfo);
			}
			else if (destinationType == typeof(InstanceDescriptor))
			{
				return new InstanceDescriptor(typeof(double).GetConstructor([typeof(double)]), new object[] { num });
			}
		}

		throw base.GetConvertToException(value, destinationType);
	}
	#endregion

	#region Internal Methods

	/// <summary>
	/// Format <see cref="double"/> into <see cref="string"/> using specified <see cref="CultureInfo"/>
	/// in <paramref name="handler"/>. <br /> <br />
	/// Special representation applies for <see cref="double.NaN"/> values, emitted as "Auto" string instead. </summary>
	/// <param name="value">The value to format as string.</param>
	/// <param name="handler">The handler specifying culture used for conversion.</param>
	internal static void FormatLengthAsString(double value, ref DefaultInterpolatedStringHandler handler)
	{
		if (double.IsNaN(value))
			handler.AppendLiteral("Auto");
		else
			handler.AppendFormatted(value);
	}

	// Parse a Length from a string given the CultureInfo.
	// Formats:
	//"[value][unit]"
	//   [value] is a double
	//   [unit] is a string specifying the unit, like 'in' or 'px', or nothing (means pixels)
	// NOTE - This code is called from FontSizeConverter, so changes will affect both.
	internal static double FromString(string s, CultureInfo? cultureInfo)
	{
		ReadOnlySpan<char> valueSpan = s.AsSpan().Trim();
		double unitFactor = 1.0;

		// Auto is represented and Double.NaN
		// properties that do not want Auto and NaN to be in their ligit values,
		// should disallow NaN in validation callbacks (same goes for negative values)
		if (valueSpan.Equals("auto", StringComparison.OrdinalIgnoreCase))
			return Double.NaN;

		for (int i = 0; i < PixelUnitStrings.Length; ++i)
		{
			if (valueSpan.EndsWith(PixelUnitStrings[i], StringComparison.OrdinalIgnoreCase))
			{
				valueSpan = valueSpan.Slice(0, valueSpan.Length - PixelUnitStrings[i].Length);
				unitFactor = PixelUnitFactors[i];
				break;
			}
		}

		if (valueSpan.IsEmpty)
			return 0;

		if (double.TryParse(valueSpan, cultureInfo, out double result))
			return result * unitFactor;

		throw new FormatException(string.Format("{0}" /*Resources.LengthFormatErrorFormat1*/, s));
	}

	internal static string ToString(double length, CultureInfo cultureInfo)
	{
		return double.IsNaN(length) ? "Auto" : Convert.ToString(length, cultureInfo);
	}
	#endregion Internal Methods

	private static readonly string[] PixelUnitStrings = ["px", "in", "cm", "pt"];
	private static readonly double[] PixelUnitFactors = [1.0, 96.0, 96.0 / 2.54, 96.0 / 72.0];
}

#elif WINDOWS_WPF

namespace Tasler.Windows;

public class LengthConverter : System.Windows.LengthConverter {}

#endif
