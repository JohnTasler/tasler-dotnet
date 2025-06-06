using CommunityToolkit.Diagnostics;

namespace Tasler;

// TODO: NEEDS_UNIT_TESTS

public static class ArrayExtensions
{
	/// <summary>
	/// Creates an <see cref="IEnumerable{T}"/> over the elements in a specified section of the array.
	/// </summary>
	/// <param name="array">The array on which to operate.</param>
	/// <param name="startIndex">The array startIndex from which to begin.</param>
	/// <param name="count">The number of array elements to include.</param>
	/// <returns>An <see cref="IEnumerable{T}"/> over the elements in a specified section of the array.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="array"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentOutOfRangeException">
	/// <paramref name="startIndex"/> is outside the range of valid indexes for <paramref name="array"/>
	/// -or- count is less than zero. -or- startIndex and count do not specify a valid section in
	/// <paramref name="array"/>.
	/// </exception>
	public static IEnumerable<T> AsEnumerable<T>(this T[] array, int startIndex, int count)
	{
		Guard.IsNotNull(array);
		var arrayLength = array.Length;
		Guard.IsInRange(startIndex, 0, arrayLength);
		Guard.IsInRange(count, 0, arrayLength);

		var endIndex = startIndex + count;
		Guard.IsInRange(endIndex, 0, arrayLength);

		for (var index = startIndex; index < endIndex; ++index)
			yield return array[index];
	}
}
