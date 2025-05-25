using System;
using System.Collections.Generic;

namespace Tasler.Collections.Generic;

/// <summary>
/// Implements <see cref="IComparer{T}"/> by wrapping a <see cref="Comparison{T}"/> delegate.
/// </summary>
/// <typeparam name="T">The type of objects to compare.</typeparam>
public class DelegateComparer<T> : IComparer<T>
{
	private Comparison<T> _comparison;

	/// <summary>
	/// Initializes a new instance of the <see cref="DelegateComparer{T}"/> class.
	/// </summary>
	/// <param name="comparison">The comparison delegate.</param>
	/// <exception cref="System.ArgumentNullException">comparison</exception>
	public DelegateComparer(Comparison<T> comparison)
	{
		if (comparison == null)
			throw new ArgumentNullException("comparison");

		_comparison = comparison;
	}

	#region IComparer<T> Members

	/// <summary>
	/// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
	/// </summary>
	/// <param name="x">The first object to compare.</param>
	/// <param name="y">The second object to compare.</param>
	/// <returns>
	/// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero<paramref name="x" /> is less than <paramref name="y" />.Zero<paramref name="x" /> equals <paramref name="y" />.Greater than zero<paramref name="x" /> is greater than <paramref name="y" />.
	/// </returns>
	public int Compare(T x, T y)
	{
		return _comparison(x, y);
	}

	#endregion IComparer<T> Members
}
