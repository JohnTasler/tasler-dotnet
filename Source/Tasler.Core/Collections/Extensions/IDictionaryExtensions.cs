using System;
using CommunityToolkit.Diagnostics;

namespace Tasler;

// TODO: NEEDS_UNIT_TESTS

public static class IDictionaryExtensions
{
	public static T? GetValueAsType<T>(this IDictionary<string, object> @this, string key, T? defaultValue = default(T)) =>
		@this.GetValueAsType<T, string>(key, defaultValue!);

	public static T? GetValueAsType<T, TKey>(this IDictionary<TKey, object> @this, TKey key, T? defaultValue = default(T))
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(key);

		if (@this.TryGetValueAsType<T, TKey>(key, out T? result, out var exception))
			return result;

		if (exception is null)
			return defaultValue;

		throw exception;
	}

	public static bool TryGetValueAsType<T, TKey>(this IDictionary<TKey, object> @this, TKey key, out T? value) =>
		@this.TryGetValueAsType<T, TKey>(key, out value, out var exception);

	public static bool TryGetValueAsType<T, TKey>(this IDictionary<TKey, object> @this, TKey key, out T? value, out InvalidCastException? exception)
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(key);

		// Initialize out paramaters
		value = default(T);
		exception = null;

		if (!@this.TryGetValue(key, out var result))
		{
			return false;
		}

		// Validate the type conversion requested
		var createException = false;
		if (typeof(T).IsClass)
		{
			if (result is not null && !result.Is<T>())
				createException = true;
		}
		else if (typeof(T).IsValueType && typeof(T).Is<IConvertible>())
		{
			result = Convert.ChangeType(result, typeof(T));
			if (result is null)
				createException = true;
		}

		if (createException)
		{
			exception = new InvalidCastException(
				string.Format(Properties.Resources.InvalidCastExceptionFormat2,
					result?.GetType().FullName,
					typeof(T).FullName));
			return false;
		}

		value = (T?)result;
		return true;
	}
}
