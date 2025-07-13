using System.Collections;
using CommunityToolkit.Diagnostics;
using Tasler.Extensions;

namespace Tasler.Collections.Extensions;

// TODO: NEEDS_UNIT_TESTS

public static class IDictionaryExtensions
{
	#region IDictionary<TKey, TValue> Extensions

	public static TValue? GetValueAsType<TValue>(this IDictionary<string, object> @this, string key, TValue? defaultValue = default)
		=> @this.GetValueAsType<string, TValue>(key, defaultValue!);

	public static TValue? GetValueAsType<TKey, TValue>(this IDictionary<TKey, object> @this, TKey key, TValue? defaultValue = default)
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(key);

		if (@this.TryGetValueAsType<TKey, TValue>(key, out TValue? result, out var exception))
			return result;

		if (exception is null)
			return defaultValue;

		throw exception;
	}

	public static bool TryGetValueAsType<TKey, TValue>(this IDictionary<TKey, object> @this, TKey key, out TValue? value)
		=> @this.TryGetValueAsType<TKey, TValue>(key, out value, out var exception);

	public static bool TryGetValueAsType<TKey, TValue>(this IDictionary<TKey, object> @this, TKey key, out TValue? value, out Exception? exception)
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(key);

		// Initialize out paramaters
		value = default;
		exception = null;

		if (!@this.TryGetValue(key, out var result))
		{
			return false;
		}

		// Validate the type conversion requested
		var createException = false;
		if (typeof(TValue).IsClass)
		{
			if (result is not null && !result.Is<TValue>())
				createException = true;
		}
		else if (typeof(TValue).IsValueType && typeof(TValue).Is<IConvertible>())
		{
			result = Convert.ChangeType(result, typeof(TValue));
			if (result is null)
				createException = true;
		}

		if (createException)
		{
			exception = new InvalidCastException(
				string.Format(Properties.Resources.InvalidCastExceptionFormat2,
					result?.GetType().FullName,
					typeof(TValue).FullName));
			return false;
		}

		value = (TValue?)result;
		return true;
	}

	#endregion IDictionary<TKey, TValue> Extensions

	#region IDictionary (non-generic) Extensions

	public static bool TryGetValue(this IDictionary @this, object key, out object? value)
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(key);

		value = @this[key];
		if (value is not null)
			return true;

		if (@this.Contains(key))
			return true;

		return false;
	}

	public static TValue? GetValueAsType<TValue>(this IDictionary @this, string key, TValue? defaultValue = default)
		=> @this.GetValueAsType<string, TValue>(key, defaultValue!);

	public static TValue? GetValueAsType<TKey, TValue>(this IDictionary @this, TKey key, TValue? defaultValue = default)
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(key);

		if (@this.TryGetValueAsType(key, out TValue? result, out var exception))
			return result;

		if (exception is null)
			return defaultValue;

		throw exception;
	}

	public static bool TryGetValueAsType<TKey, TValue>(this IDictionary @this, TKey key, out TValue? value)
		=> @this.TryGetValueAsType<TKey, TValue>(key, out value, out var exception);

	public static bool TryGetValueAsType<TKey, TValue>(this IDictionary @this, TKey key, out TValue? value, out Exception? exception)
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(key);

		// Initialize out paramaters
		value = default;
		exception = null;

		if (!@this.TryGetValue(key, out var result))
		{
			return false;
		}

		// Validate the type conversion requested
		var createException = false;
		if (typeof(TValue).IsClass)
		{
			if (result is not null && !result.Is<TValue>())
				createException = true;
		}
		else if (typeof(TValue).IsValueType && typeof(TValue).Is<IConvertible>())
		{
			result = Convert.ChangeType(result, typeof(TValue));
			if (result is null)
				createException = true;
		}

		if (createException)
		{
			exception = new InvalidCastException(
				string.Format(Properties.Resources.InvalidCastExceptionFormat2,
					result?.GetType().FullName,
					typeof(TValue).FullName));
			return false;
		}

		value = (TValue?)result;
		return true;
	}

	#endregion IDictionary (non-generic) Extensions
}
