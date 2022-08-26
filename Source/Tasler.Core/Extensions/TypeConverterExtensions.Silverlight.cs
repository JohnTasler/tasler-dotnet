using System;
using System.ComponentModel;

namespace Tasler.Extensions
{
	public static class TypeConverterExtensions
	{
		public static Exception GetConvertFromException(this TypeConverter source, object value)
		{
			var fullName = value == null
				? Properties.Resources.ToStringNull
				: value.GetType().FullName;

			return new NotSupportedException(
				string.Format(Properties.Resources.ConvertFromExceptionFormat2, source.GetType().Name, fullName));
		}
	}
}
