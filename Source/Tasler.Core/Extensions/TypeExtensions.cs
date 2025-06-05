namespace Tasler;

// TODO: NEEDS_UNIT_TESTS

/// <summary>
/// Extension method for the <see cref="Type"/> class.
/// </summary>
public static class TypeExtensions
{
	/// <summary>
	/// Determines whether <paramref name="this"/> is or is derived from <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">The type to be tested.</typeparam>
	/// <param name="this">The <see cref="Type"/> being tested.</param>
	/// <returns>
	///   <see langword="true"/> if <paramref name="this"/> is, or is derived from
	///   <typeparamref name="T"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool Is<T>(this Type @this) => @this is not null && typeof(T).IsAssignableFrom(@this);

	/// <summary>
	/// Determines whether <paramref name="this"/> is or is derived from <paramref name="type"/>.
	/// </summary>
	/// <param name="type">The type to be tested.</param>
	/// <param name="this">The <see cref="Type"/> being tested.</param>
	/// <returns>
	///   <see langword="true"/> if <paramref name="this"/> is, or is derived from
	///   <paramref name="type"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool Is(this Type @this, Type type)
		=> @this is not null && type is not null && type.IsAssignableFrom(@this);

	/// <summary>
	/// Determines whether the <see cref="Type"/> specified by <paramref name="this"/> has the
	/// custom attribute specified by <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">The type of custom attribute to test for.</typeparam>
	/// <param name="this">The <see cref="Type"/> to test for the custom attribute.</param>
	/// <param name="inherit"><see langword="true"/> to search <paramref name="this"/>'s inheritance
	/// chain to find the custom attribute; otherwise, <see langword="false"/>.</param>
	/// <returns>
	///   <see langword="true"/> if the <see cref="Type"/> specified by <paramref name="this"/>
	///   (or one of its base types when <paramref name="inherit"/> is <see langword="true"/>)
	///   has the custom attribute specified by <typeparamref name="T"/>; otherwise
	///   <see langword="false"/>.
	/// </returns>
	public static bool HasCustomAttribute<T>(this Type @this, bool inherit)
		=> @this.GetCustomAttributes(typeof(T), inherit).Length != 0;

	/// <summary>
	/// Gets the custom attributes of the <see cref="Type"/> specified by <paramref name="this"/>
	/// that are, or are derived from, <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">The type of custom attribute to test for.</typeparam>
	/// <param name="this">The <see cref="Type"/> to test for the custom attribute.</param>
	/// <param name="inherit"><see langword="true"/> to search <paramref name="this"/>'s inheritance
	/// chain to find the custom attributes; otherwise, <see langword="false"/>.</param>
	/// <returns>
	///		An array of <typeparamref name="T"/> of the custom attributes of the <see cref="Type"/>
	///		specified by <paramref name="this"/> that are, or are derived from, <typeparamref name="T"/>.
	/// </returns>
	public static T[] GetCustomAttributes<T>(this Type @this, bool inherit)
	{
		if (@this == null)
			return [];

		return [.. @this.GetCustomAttributes(typeof(T), inherit).OfType<T>()];
	}

	//public static IEnumerable<Type> GetFlattenedNestedTypes(this Type @this, BindingFlags bindingFlags)
	//{
	//	for (var type = @this; type is not null; type = type.BaseType)
	//		foreach (var nestedType in type.GetNestedTypes(bindingFlags))
	//			yield return nestedType;
	//}
}
