using System;

namespace Tasler
{
	// TODO: NEEDS_UNIT_TEST

	/// <summary>
	/// Provides extension methods for classes that implement the <see cref="IComparable{T}"/> interface.
	/// </summary>
	public static class ComparableExtensions
	{
		public static T Clamp<T>(this T @this, T minimum, T maximum)
			where T : IComparable<T>
		{
			// Normalize that minimum is <= maximum
			if (minimum.CompareTo(maximum) > 0)
			{
				var temp = minimum;
				minimum = maximum;
				maximum = temp;
			}

			return @this.CompareTo(minimum) < 0 ? minimum : (@this.CompareTo(maximum) > 0 ? maximum : @this);
		}
	}
}
