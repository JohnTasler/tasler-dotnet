using System;
using System.Collections.Generic;

namespace Tasler.Extensions
{
	// TODO: NEEDS_UNIT_TESTS

	public static class IDictionaryExtensions
	{
		public static T GetValueAsType<T>(this IDictionary<string, object> @this, string key, T defaultValue = default(T)) =>
			@this.GetValueAsType<T, string>(key, defaultValue);

		public static T GetValueAsType<T, TKey>(this IDictionary<TKey, object> @this, TKey key, T defaultValue = default(T))
		{
			if (@this.TryGetValueAsType<T, TKey>(key, out T result, out var exception))
				return result;

			if (exception == null)
				return defaultValue;

			throw exception;
		}

		public static bool TryGetValueAsType<T, TKey>(this IDictionary<TKey, object> @this, TKey key, out T value) =>
			@this.TryGetValueAsType<T, TKey>(key, out value, out var exception);

		public static bool TryGetValueAsType<T, TKey>(this IDictionary<TKey, object> @this, TKey key, out T value, out InvalidCastException exception)
		{
			if (@this == null)
				throw new ArgumentNullException("@this");
			if (!typeof(TKey).IsValueType && object.Equals(key, default(TKey)))
				throw new ArgumentNullException("key");

			// Initialize out paramaters
			value = default(T);
			exception = null;

			var result = default(object);
			if (!@this.TryGetValue(key, out result))
			{
				return false;
			}

			// Validate the type conversion requested
			var createException = false;
			if (typeof(T).IsClass)
			{
				if (result != null && !result.Is<T>())
					createException = true;
			}
			else if (typeof(T).IsValueType && typeof(T).Is<IConvertible>())
			{
				result = Convert.ChangeType(result, typeof(T));
				if (result == null)
					createException = true;
			}
			if (createException)
			{
				exception = new InvalidCastException(
					string.Format(Properties.Resources.InvalidCastExceptionFormat2,
						result.GetType().FullName,
						typeof(T).FullName));
				return false;
			}

			value = (T)result;
			return true;
		}

	}
}
