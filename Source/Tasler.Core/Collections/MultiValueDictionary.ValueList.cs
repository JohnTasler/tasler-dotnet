using System;
using System.Collections;
using System.Collections.Generic;

namespace Tasler.Collections;

public partial class MultiValueDictionary<TKey, TValue> : IDictionary<TKey, TValue>
{
	#region Nested Types

	/// <summary>
	/// Represents a list of multiple values, used as the value of the object values in the inner dictionary of the
	/// <see cref="MultiValueDictionary{TKey, TValue}"/> class.
	/// </summary>
	/// <remarks>
	/// <para>The <see cref="MultiValueDictionary{TKey, TValue}"/> outer class maintains a dictionary of
	/// <typeparamref name="TKey"/> to <see cref="Object"/> key/value pairs. The object value will either be a
	/// single value of type <typeparamref name="TValue"/>, or an <see cref="IEnumerable{TValue}"/>, implemented by
	/// <see cref="ValueList"/>.</para>
	/// <para>Read-only access is provided via the <see cref="IEnumerable{TValue}"/> interface. Construction and
	/// manipulation of the object is done via two static methods: <see cref="AddValue"/> and
	/// <see cref="RemoveValue"/>. Each of these methods returns the result of the operation, so that the outer
	/// class's dictionary values will only ever be a single <typeparamref name="TValue"/> instance, or a
	/// <see cref="ValueList"/> containing no less than 2 items.</para>
	/// </remarks>
	private class ValueList : IEnumerable<TValue>
	{
		#region Instance Fields
		private List<TValue> _innerList;
		#endregion Instance Fields

		#region Constructors
		private ValueList(TValue firstValue)
		{
			_innerList = new List<TValue>(2) { firstValue };
		}
		#endregion Constructors

		#region Methods

		/// <summary>
		/// Combines the <paramref name="existingValue"/> with the <paramref name="newValue"/> such that the result
		/// will be either a single <typeparamref name="TValue"/> or a <see cref="ValueList"/> containing no less
		/// than 2 items.
		/// </summary>
		/// <param name="existingValue"></param>
		/// <param name="newValue"></param>
		/// <returns>TODO:
		/// </returns>
		/// <exception cref="InvalidCastException">The specified <paramref name="existingValue"/> is neither
		/// <c>null</c>, <c>default(<typeparamref name="TValue"/>)</c>, an instance of <see cref="ValueList"/>, nor
		/// an instance of <typeparamref name="TValue"/>.</exception>
		public static object AddValue(object existingValue, TValue newValue)
		{
			if (existingValue == null || existingValue.Equals(default(TValue)))
				return newValue;

			var valueList = existingValue as ValueList;
			if (valueList == null)
			{
				var firstValue = (TValue)existingValue;
				valueList = new ValueList(firstValue);
			}

			valueList._innerList.Add(newValue);
			return valueList;
		}

		/// <summary>
		/// Removes the <paramref name="newValue"/> from the <see cref="ValueList"/>
		/// when <paramref name="existingValue"/> specifies an instance of <see cref="ValueList"/>. When such list
		/// contains a single item, the list is removed and reduced to the remaining item in the list.
		/// </summary>
		/// <param name="existingValue">The existing value.</param>
		/// <param name="valueToRemove">The value to remove.</param>
		/// <returns>TODO:
		/// </returns>
		/// <exception cref="System.ArgumentException">The <paramref name="valueToRemove"/> is not <c>null</c>, is
		/// not <c>default(<typeparamref name="TValue"/>)</c>, and is a value not in the <see cref="ValueList"/>
		/// represented by <paramref name="existingValue"/>.</exception>
		public static object RemoveValue(object existingValue, TValue valueToRemove, out bool valueRemoved)
		{
			valueRemoved = false;

			if (existingValue == null || existingValue.Equals(default(TValue)))
				return null;

			if (existingValue is TValue && existingValue.Equals(valueToRemove))
			{
				valueRemoved = true;
				return null;
			}

			var valueList = (ValueList)existingValue;
			var index = valueList._innerList.LastIndexOf(valueToRemove);
			if (index < 0)
				return existingValue;
			else
				valueRemoved = true;

			valueList._innerList.RemoveAt(index);

			if (valueList._innerList.Count == 1)
			{
				var lastValue = valueList._innerList[0];
				valueList._innerList.Clear();
				return lastValue;
			}

			return valueList;
		}

		#endregion Methods

		#region IEnumerable<TValue> Members
		/// <summary>
		/// Returns a typed enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator{TValue}"/> object that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator<TValue> GetEnumerator()
		{
			return _innerList.GetEnumerator();
		}
		#endregion IEnumerable<TValue> Members

		#region IEnumerable Members
		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return _innerList.GetEnumerator();
		}
		#endregion IEnumerable Members
	}

	#endregion Nested Types
}
