namespace Tasler;

// TODO: NEEDS_UNIT_TESTS

public static class IDictionaryExtensions
{
	public static T? GetValueAsType<T, TKey>(this IDictionary<TKey, object> source, TKey key, T? defaultValue)
	{
		var value = source.GetValueAsType<T, TKey>(key, out var exception);
		return exception is null ? value : defaultValue;
	}

	public static T? GetValueAsType<T, TKey>(this IDictionary<TKey, object> source, TKey key, out Exception? exception)
	{
		ValidateArgument.IsNotNull(source, nameof(source));
		if (!typeof(TKey).IsValueType && object.Equals(key, default(TKey)))
			throw new ArgumentNullException(nameof(key));

		if (!source.TryGetValue(key, out object? value))
		{
			exception = new KeyNotFoundException(
				string.Format(Properties.Resources.KeyNotFoundExceptionFormat2,
					typeof(TKey).FullName,
					key?.ToString()));
			return default;
		}

		if (typeof(T).IsClass && !(value is T) && object.Equals(value, default(T)))
		{
			exception = new InvalidCastException(
				string.Format(Properties.Resources.InvalidCastExceptionFormat2,
					value.GetType().FullName,
					typeof(T).FullName));
			return default;
		}

		exception = null;
		return (T)value;
	}

	public static T? GetValueAsType<T>(this IDictionary<string, object> source, string key, T? defaultValue)
	{
		return source.GetValueAsType<T, string>(key, defaultValue);
	}

	public static T? GetValueAsType<T>(this IDictionary<string, object> source, string key, out Exception? exception)
	{
		return source.GetValueAsType<T, string>(key, out exception);
	}
}
