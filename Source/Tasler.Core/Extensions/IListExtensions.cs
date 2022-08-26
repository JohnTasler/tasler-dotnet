using System;
using System.Collections;
using System.Collections.Generic;

namespace Tasler.Extensions
{
	public static class IListExtensions
	{
		public static void Grow<T>(this IList<T> @this, int newSize, Func<T> instantiator)
		{
			if (@this == null)
				throw new ArgumentNullException("@this");

			var oldSize = @this.Count;
			if (newSize < oldSize)
				throw new ArgumentOutOfRangeException("newSize");

			for (var index = oldSize; index < newSize; ++index)
				@this.Add(instantiator());
		}

		public static void Shrink(this IList @this, int newSize)
		{
			if (@this == null)
				throw new ArgumentNullException("@this");

			var oldSize = @this.Count;
			if (newSize > oldSize)
				throw new ArgumentOutOfRangeException("newSize");

			for (var index = oldSize; index > newSize; --index)
				@this.RemoveAt(index - 1);
		}
	}
}
