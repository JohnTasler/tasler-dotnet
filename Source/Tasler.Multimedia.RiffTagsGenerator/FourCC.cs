using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace Tasler.Multimedia
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct FourCC
		: IComparable
		, IComparable<int>
		, IComparable<FourCC>
		, IEquatable<int>
		, IEquatable<FourCC>
		, IFormattable
		, IConvertible
	{
		#region Constants
		public const int Size = sizeof(int);
		public const int MaxValue = int.MaxValue;
		public const int MinValue = int.MinValue;
		#endregion

		#region Static Fields
		public static readonly FourCC Empty = new FourCC();
		#endregion

		#region Instance Fields
		internal int m_value;
		#endregion

		#region Construction
		public FourCC(int value)
		{
			this.m_value = value;
		}

		public FourCC(string chunkId)
		{
			FormatException exception;
			if (!FourCC.TryParse(chunkId, out m_value, out exception))
			{
				throw exception;
			}
		}
		#endregion

		#region Comparison
		public int CompareTo(object value)
		{
			if (value == null)
			{
				return 1;
			}
			if (!(value is int) && !(value is FourCC))
			{
				throw new ArgumentException("Argument must be an int or FourCC");
			}
			int num = (int)value;
			if (this.m_value < num)
			{
				return -1;
			}
			if (this.m_value > num)
			{
				return 1;
			}
			return 0;
		}

		public int CompareTo(int value)
		{
			if (this.m_value < value)
			{
				return -1;
			}
			if (this.m_value > value)
			{
				return 1;
			}
			return 0;
		}

		public int CompareTo(FourCC value)
		{
			if (this.m_value < value.m_value)
			{
				return -1;
			}
			if (this.m_value > value.m_value)
			{
				return 1;
			}
			return 0;
		}
		#endregion

		#region Equality
		public override bool Equals(object obj)
		{
			if (obj is int)
			{
				return (this.m_value == ((int)obj));
			}
			else if (obj is FourCC)
			{
				return (this.m_value == ((FourCC)obj).m_value);
			}
			return false;
		}

		public bool Equals(int obj)
		{
			return (this.m_value == obj);
		}

		public bool Equals(FourCC obj)
		{
			return (this.m_value == obj.m_value);
		}

		public static bool operator ==(FourCC left, FourCC right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(FourCC left, FourCC right)
		{
			return !left.Equals(right);
		}

		public override int GetHashCode()
		{
			return this.m_value;
		}
		#endregion

		#region Formatting and Parsing
		public override string ToString()
		{
			char[] chars = new char[4];
			chars[0] = (char)(this.m_value & 0xFF);
			chars[1] = (char)((this.m_value >> 8) & 0xFF);
			chars[2] = (char)((this.m_value >> 16) & 0xFF);
			chars[3] = (char)((this.m_value >> 24) & 0xFF);

			return new string(chars);
		}

		public string ToString(string format)
		{
			return this.m_value.ToString(format);
		}

		public string ToString(IFormatProvider provider)
		{
			return this.m_value.ToString(provider);
		}

		public string ToString(string format, IFormatProvider provider)
		{
			return this.m_value.ToString(format, provider);
		}

		public static FourCC Parse(string s)
		{
			return new FourCC(s);
		}

		public static bool TryParse(string s, out int result, out FormatException exception)
		{
			result = 0;

			if (s.Length <= 4)
			{
				exception = null;
				for (int iByte = 0; iByte < s.Length; ++iByte)
				{
					if (s[iByte] <= byte.MaxValue)
					{
						result |= ((int)s[iByte]) << (iByte * 8);
					}
					else
					{
						result = 0;
						exception = new FormatException("FourCC strings must specify ANSI characters only.");
						break;
					}
				}
			}
			else
			{
				exception = new FormatException("FourCC strings must not be more than 4 characters in length.");
			}

			return exception == null;
		}

		public static bool TryParse(string s, out int result)
		{
			FormatException exception;
			return TryParse(s, out result, out exception);
		}

		public static bool TryParse(string s, out FourCC result)
		{
			int value;
			FormatException exception;
			bool valid = FourCC.TryParse(s, out value, out exception);

			if (!valid)
			{
				value = 0;
			}

			result = new FourCC(value);
			return valid;
		}
		#endregion

		#region IConvertible Implementation
		public TypeCode GetTypeCode()
		{
			return TypeCode.Int32;
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			return Convert.ToBoolean(this.m_value);
		}

		char IConvertible.ToChar(IFormatProvider provider)
		{
			return Convert.ToChar(this.m_value);
		}

		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			return Convert.ToSByte(this.m_value);
		}

		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return Convert.ToByte(this.m_value);
		}

		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return Convert.ToInt16(this.m_value);
		}

		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return Convert.ToUInt16(this.m_value);
		}

		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return this.m_value;
		}

		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return Convert.ToUInt32(this.m_value);
		}

		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return Convert.ToInt64(this.m_value);
		}

		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return Convert.ToUInt64(this.m_value);
		}

		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return Convert.ToSingle(this.m_value);
		}

		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return Convert.ToDouble(this.m_value);
		}

		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			return Convert.ToDecimal(this.m_value);
		}

		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			throw new InvalidCastException("Invalid cast from FourCC to DateTime");
		}

		object IConvertible.ToType(Type type, IFormatProvider provider)
		{
			return ((IConvertible)this.m_value).ToType(type, provider);
		}
		#endregion

		#region Explicit Operators
		public static explicit operator int(FourCC value)
		{
			return value.m_value;
		}
		#endregion

		#region Properties
		public int Value
		{
			get
			{
				return this.m_value;
			}
		}
		#endregion
	}
}
