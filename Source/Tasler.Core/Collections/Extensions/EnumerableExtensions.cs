using System.Collections;
using CommunityToolkit.Diagnostics;

namespace Tasler.Collections;

// TODO: NEEDS_UNIT_TESTS

/// <summary>
/// Extension methods for the <see cref="IEnumerable"/> and <see cref="IEnumerable{T}"/> types.
/// </summary>
public static class EnumerableExtensions
{
	/// <summary>
	/// Filters the elements of an <see cref="IEnumerable"/> based on a specified type.
	/// </summary>
	/// <typeparam name="TResult">The type to filter the elements of the sequence on.</typeparam>
	/// <param name="this">The <see cref="IEnumerable"/> whose elements are to be filtered.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> that contains elements from the input sequence
	/// of type <typeparamref name="TResult"/>.</returns>
	/// <remarks>
	/// Similar to <see cref="Enumerable.OfType"/>, but only includes the elements of exactly the
	/// type specified, rather than elements that are assignable to that type.
	/// </remarks>
	public static IEnumerable<TResult> OfExactType<TResult>(this IEnumerable @this)
		where TResult : class
	{
		return @this.OfType<TResult>().Where(o => o.GetType() == typeof(TResult));
	}

	/// <summary>
	/// Returns the index of the first element of the sequence that satisfies a condition or -1 if no such element is found.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements in the sequence.</typeparam>
	/// <param name="this">An <see cref="IEnumerable{T}"/> in which to find the first element matching the condition.</param>
	/// <param name="predicate">A function to test each element for a condition.</param>
	/// <summary>
	/// Returns the zero-based index of the first element in the sequence that satisfies the specified predicate.
	/// </summary>
	/// <param name="this">The sequence to search.</param>
	/// <param name="predicate">A function to test each element for a condition.</param>
	/// <returns>The index of the first matching element; otherwise, -1 if no element satisfies the predicate.</returns>
	public static int FirstIndex<TSource>(this IEnumerable<TSource> @this, Func<TSource, bool> predicate)
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(predicate);

		var index = 0;
		foreach (var item in @this)
		{
			if (predicate(item))
				return index;
			++index;
		}

		return -1;
	}

	/// <summary>
	/// Returns the index of the first element of the sequence that satisfies a condition or -1 if no such element is found.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements in the sequence.</typeparam>
	/// <param name="this">An <see cref="IEnumerable{T}"/> in which to find the first element matching the condition.</param>
	/// <param name="element">When this method returns, the element of the sequence that satisfies the condition, if one is found;
	/// otherwise, the default value for the <typeparamref name="TSource"/>. This parameter is passed uninitialized. </param>
	/// <param name="predicate">A function to test each element for a condition.</param>
	/// <returns>The index of the first element if found in the sequence; otherwise, -1.</returns>
	public static int FirstIndex<TSource>(this IEnumerable<TSource> @this, out TSource? element, Func<TSource, bool> predicate)
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(predicate);

		var index = 0;
		foreach (var item in @this)
		{
			if (predicate(item))
			{
				element = item;
				return index;
			}
			++index;
		}

		element = default;
		return -1;
	}

	/// <summary>
	/// Returns the index of the last element of the sequence that satisfies a condition or -1 if no such element is found.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements of @this.</typeparam>
	/// <param name="this">An <see cref="IEnumerable{TSource}"/> in which to find the last element matching the condition.</param>
	/// <param name="predicate">A function to test each element for a condition.</param>
	/// <summary>
	/// Returns the zero-based index of the last element in the sequence that satisfies the specified predicate.
	/// </summary>
	/// <param name="this">The sequence to search.</param>
	/// <param name="predicate">A function to test each element for a condition.</param>
	/// <returns>The index of the last matching element; otherwise, -1 if no element matches.</returns>
	public static int LastIndex<TSource>(this IEnumerable<TSource> @this, Func<TSource, bool> predicate)
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(predicate);

		var matchIndex = -1;
		var index = 0;
		foreach (var item in @this)
		{
			if (predicate(item))
				matchIndex = index;
			++index;
		}

		return matchIndex;
	}

	/// <summary>
	/// Returns the index of the last element of the sequence that satisfies a condition or -1 if no such element is found.
	/// </summary>
	/// <typeparam name="TSource">The type of the elements in the sequence.</typeparam>
	/// <param name="this">An <see cref="IEnumerable{T}"/> in which to find the last element matching the condition.</param>
	/// <param name="element">When this method returns, the element of the sequence that satisfies the condition, if one is found;
	/// otherwise, the default value for the <typeparamref name="TSource"/>. This parameter is passed uninitialized. </param>
	/// <param name="predicate">A function to test each element for a condition.</param>
	/// <returns>The index of the last element if found in the sequence; otherwise, -1.</returns>
	public static int LastIndex<TSource>(this IEnumerable<TSource> @this, out TSource? element, Func<TSource, bool> predicate)
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(predicate);

		var matchIndex = -1;
		var matchElement = default(TSource);
		var index = 0;
		foreach (var item in @this)
		{
			if (predicate(item))
				matchIndex = index;
			++index;
		}

		element = matchElement;
		return matchIndex;
	}
}
