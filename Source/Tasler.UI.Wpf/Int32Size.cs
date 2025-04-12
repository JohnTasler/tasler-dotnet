using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Markup;
using Tasler.Interop;

namespace Tasler.Windows;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[TypeConverter(typeof(Int32SizeConverter))]
[ValueSerializer(typeof(Int32SizeValueSerializer))]
public struct Int32Size : IFormattable
{
	#region Static Fields
	public static readonly Int32Size Empty = new Int32Size(0, 0);
	#endregion Static Fields

	#region Instance Fields
	private int _width;
	private int _height;
	#endregion Instance Fields

	#region Construction
	public Int32Size(int width, int height)
	{
		_width = width;
		_height = height;
	}

	public Int32Size(Size size)
		: this((int)size.Width, (int)size.Height)
	{
	}

	public Int32Size(SIZE size)
		: this(size.Width, size.Height)
	{
	}
	#endregion Construction

	#region Properties
	public int Width
	{
		get { return _width; }
		set { _width = value; }
	}

	public int Height
	{
		get { return _height; }
		set { _height = value; }
	}

	public bool IsEmpty
	{
		get { return (_width == 0) && (_height == 0); }
	}
	#endregion Properties

	#region Methods
	public static Int32Size Parse(string source)
	{
		if (string.IsNullOrEmpty(source) || source == "Empty")
			return Int32Size.Empty;

		List<char> separators = new List<char>(3);
		separators.Add(' ');
		separators.Add(';');
		if (NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator != ",")
			separators.Add(',');

		string[] tokens = source.Split(separators.ToArray(), 2, StringSplitOptions.RemoveEmptyEntries);
		string width = tokens[0];
		string height = (tokens.Length == 2) ? tokens[1] : width;
		Int32Size size = new Int32Size(Int32.Parse(width), Int32.Parse(height));
		return size;
	}

	public string ToString(IFormatProvider provider)
	{
		return ((IFormattable)this).ToString(null, provider);
	}

	string IFormattable.ToString(string? format, IFormatProvider? provider)
	{
		if (this.IsEmpty)
			return "Empty";
		char numericListSeparator = (NumberFormatInfo.GetInstance(provider).CurrencyDecimalSeparator == ",") ? ';' : ',';
		return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}", numericListSeparator, _width, _height);
	}

	public readonly Size ToSize() => new(_width, _height);

	public readonly SIZE ToSIZE() => new(_width, _height);

	#endregion Methods

	#region Equality Comparisons
	public static bool operator ==(Int32Size size1, Int32Size size2)
	{
		return Int32Size.Equals(size1, size2);
	}

	public static bool operator !=(Int32Size size1, Int32Size size2)
	{
		return !Int32Size.Equals(size1, size2);
	}

	public static bool Equals(Int32Size size1, Int32Size size2)
	{
		return (size1.Width == size2.Width) && (size1.Height == size2.Height);
	}

	public bool Equals(Int32Size value)
	{
		return Equals(this, value);
	}
	#endregion Equality Comparisons

	#region Overrides
	public override readonly bool Equals(object? o)
	{
		if (o is null || o is not Int32Size)
			return false;

		Int32Size size = (Int32Size)o;
		return Equals(this, size);
	}

	public override int GetHashCode()
	{
		if (this.IsEmpty)
			return 0;
		return this.Width.GetHashCode() ^ this.Height.GetHashCode();
	}

	public override string ToString() => ((IFormattable)this).ToString(null, null);
	#endregion Overrides
}

public sealed class Int32SizeConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
	{
		return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
	}

	public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
	{
		return (destinationType == typeof(string)) || base.CanConvertTo(context, destinationType);
	}

	public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
	{
		if (value == null)
			throw base.GetConvertFromException(value);

		if (value is string source)
			return Int32Size.Parse(source);

		return base.ConvertFrom(context, culture, value);
	}

	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
	{
		if (value is Int32Size size)
		{
			if (destinationType == typeof(string))
				return ((IFormattable)size).ToString(null, culture);
		}

		return base.ConvertTo(context, culture, value, destinationType!);
	}
}

public class Int32SizeValueSerializer : ValueSerializer
{
	public override bool CanConvertFromString(string value, IValueSerializerContext context)
	{
		return true;
	}

	public override bool CanConvertToString(object value, IValueSerializerContext context)
	{
		return value is Int32Size;
	}

	public override object ConvertFromString(string value, IValueSerializerContext context)
	{
		if (value != null)
			return Int32Size.Parse(value);

		return base.ConvertFromString(value, context);
	}

	public override string ConvertToString(object value, IValueSerializerContext context)
	{
		if (value is Int32Size size)
			return ((IFormattable)size).ToString(null, CultureInfo.GetCultureInfo("en-us"));

		return base.ConvertToString(value, context);
	}
}
