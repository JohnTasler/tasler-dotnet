namespace Tasler;

// TODO: NEEDS_UNIT_TESTS

public static class ObjectExtensions
{
	/// <summary>
	/// Creates an array containing a single element - the specified object instance.
	/// </summary>
	/// <typeparam name="T">The type of the instance.</typeparam>
	/// <param name="@this">The <see cref="object"/> instance on which the extension method operates.
	/// As an extension method, this is typically not specified explicitly.</param>
	/// <returns>
	/// An <see cref="IEnumerable{TSource}"/> containing a single element - the specified object instance.
	/// </returns>
	public static IEnumerable<T> AsEnumerable<T>(this T @this)
			where T : class
	{
		return [@this];
	}

	public static bool Is<T>(this object @this) => @this is T;
}
