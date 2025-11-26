namespace Tasler.Extensions;

// TODO: NEEDS_UNIT_TESTS

/// <summary>
/// Extension method for the <see cref="object"/> class.
/// </summary>
public static class ObjectExtensions
{
	/// <summary>
	/// Creates an array containing a single element - the specified object instance.
	/// </summary>
	/// <typeparam name="T">The type of the instance.</typeparam>
	/// <param name="this">The <see cref="object"/> instance on which the extension method operates.
	/// As an extension method, this is typically not specified explicitly.</param>
	/// <returns>
	/// An <see cref="IEnumerable{TSource}"/> containing a single element - the specified object instance.
	/// <summary>
		/// Produces a sequence containing the instance as its single element.
		/// </summary>
		/// <param name="@this">The instance to wrap in an enumerable. May be <c>null</c>; the resulting sequence will contain a single <c>null</c> element in that case.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> that yields the provided instance exactly once.</returns>
	public static IEnumerable<T> AsSingleItemEnumerable<T>(this T @this)
		where T : class => [@this];

	/// <summary>
	/// Determines whether <paramref name="this"/> is or is derived from <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">The type to be tested.</typeparam>
	/// <param name="this">The <see cref="object"/> instance on which the extension method operates.
	/// As an extension method, this is typically not specified explicitly.</param>
	/// <returns>
	///   <see langword="true"/> if <paramref name="this"/> is, or is derived from
	///   <typeparamref name="T"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool Is<T>(this object @this) => @this is not null && @this is T;

	/// <summary>
	/// Determines whether <paramref name="this"/> is or is derived from <paramref name="type"/>.
	/// </summary>
	/// <param name="type">The type to be tested.</param>
	/// <param name="this">The object being tested.</param>
	/// <returns>
	///   <see langword="true"/> if <paramref name="this"/> is, or is derived from
	///   <paramref name="type"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool Is(this object @this, Type type) => @this is not null && @this.GetType().Is(type);
}