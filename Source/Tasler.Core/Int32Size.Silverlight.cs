using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using Tasler.Extensions;

namespace Tasler
{
	[StructLayout(LayoutKind.Sequential)]
	[TypeConverter(typeof(Int32SizeConverter))]
	public struct Int32Size : IFormattable
	{
		#region Static Fields
		public static readonly Int32Size Empty = new Int32Size(0, 0);
		#endregion Static Fields

		#region Instance Fields
		private int width;
		private int height;
		#endregion Instance Fields

		#region Construction
		public Int32Size(int width, int height)
		{
			this.width = width;
			this.height = height;
		}

		public Int32Size(Size size)
			: this((int)size.Width, (int)size.Height)
		{
		}

		#endregion Construction

		#region Properties
		public int Width
		{
			get { return this.width; }
			set { this.width = value; }
		}

		public int Height
		{
			get { return this.height; }
			set { this.height = value; }
		}

		public bool IsEmpty
		{
			get { return (this.width == 0) && (this.height == 0); }
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

		string IFormattable.ToString(string format, IFormatProvider provider)
		{
			if (this.IsEmpty)
				return "Empty";
			char numericListSeparator = (NumberFormatInfo.GetInstance(provider).CurrencyDecimalSeparator == ",") ? ';' : ',';
			return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}", numericListSeparator, this.width, this.height);
		}

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
		public override bool Equals(object o)
		{
			if ((o == null) || !(o is Int32Size))
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

		public override string ToString()
		{
			return ((IFormattable)this).ToString(null, null);
		}
		#endregion Overrides
	}

	public sealed class Int32SizeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return (destinationType == typeof(string)) || base.CanConvertTo(context, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value == null)
				throw this.GetConvertFromException(value);

			var source = value as string;
			if (source != null)
				return Int32Size.Parse(source);

			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if ((destinationType != null) && (value is Int32Size))
			{
				Int32Size size = (Int32Size)value;
				if (destinationType == typeof(string))
					return ((IFormattable)size).ToString(null, culture);
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
