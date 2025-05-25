using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tasler.Collections;

public partial class MultiValueDictionary<TKey, TValue> : IDictionary<TKey, TValue>
{
	private static readonly Func<IEnumerable<TValue>, TValue> DefaultSingleValueSelector = Enumerable.Last;

	#region Instance Fields
	private Dictionary<TKey, object> _innerDictionary;
	#endregion Instance Fields

	#region Constructors

	public MultiValueDictionary()
			: this(0, null)
	{
	}

	public MultiValueDictionary(IDictionary<TKey, TValue> dictionary)
			: this(dictionary, null)
	{
	}

	public MultiValueDictionary(IEqualityComparer<TKey> comparer)
			: this(0, comparer)
	{
	}

	public MultiValueDictionary(int capacity)
			: this(capacity, null)
	{
	}

	public MultiValueDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
			: this((dictionary != null) ? dictionary.Count : 0, comparer)
	{
		if (dictionary == null)
			throw new ArgumentNullException("dictionary");

		foreach (var item in dictionary)
			this.Add(item.Key, item.Value);
	}

	public MultiValueDictionary(int capacity, IEqualityComparer<TKey> comparer)
	{
		if (capacity < 0)
			throw new ArgumentOutOfRangeException("capacity");

		this._innerDictionary = new Dictionary<TKey, object>(capacity, comparer);
	}

	#endregion Constructors

	public Func<IEnumerable<TValue>, TValue> SingleValueSelector { get; set; }

	#region IDictionary<TKey,TValue> Members

	public void Add(TKey key, TValue value)
	{
		var existingValue = default(object);
		_innerDictionary.TryGetValue(key, out existingValue);
		_innerDictionary[key] = ValueList.AddValue(existingValue, value);
	}

	public bool ContainsKey(TKey key)
	{
		return _innerDictionary.ContainsKey(key);
	}

	public ICollection<TKey> Keys
	{
		get { return _innerDictionary.Keys; }
	}

	public bool Remove(TKey key, TValue value)
	{
		var valueRemoved = default(bool);
		var existingValue = default(object);
		if (_innerDictionary.TryGetValue(key, out existingValue))
		{
			var newValue = ValueList.RemoveValue(existingValue, value, out valueRemoved);
			if (newValue == null)
				_innerDictionary.Remove(key);
			else if (newValue != existingValue)
				_innerDictionary[key] = newValue;
		}

		return valueRemoved;
	}

	public bool Remove(TKey key)
	{
		return _innerDictionary.Remove(key);
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		var existingValue = default(object);
		if (!_innerDictionary.TryGetValue(key, out existingValue))
		{
			value = default(TValue);
			return false;
		}

		if (existingValue == null || existingValue.Equals(default(TValue)))
		{
			value = default(TValue);
		}
		else if (existingValue is ValueList)
		{
			var valueList = (IEnumerable<TValue>)existingValue;
			var selector = this.SingleValueSelector ?? DefaultSingleValueSelector;
			value = selector(valueList);
		}
		else
		{
			value = (TValue)existingValue;
		}

		return true;
	}

	public ICollection<TValue> Values
	{
		get { throw new NotImplementedException(); }
	}

	public TValue this[TKey key]
	{
		get
		{
			var value = default(TValue);
			if (!this.TryGetValue(key, out value))
				return (TValue)_innerDictionary[key];    // Just letting the innerDictionary throw the KeyNotFoundException
			return value;
		}
		set
		{
			this.Add(key, value);
		}
	}

	#endregion IDictionary<TKey,TValue> Members

	#region ICollection<KeyValuePair<TKey,TValue>> Members

	void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
	{
		throw new NotImplementedException();
	}

	public void Clear()
	{
		_innerDictionary.Clear();
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
	{
		var existingValue = default(object);
		if (!_innerDictionary.TryGetValue(item.Key, out existingValue))
			return false;

		return existingValue != default(object) && existingValue.Equals(item.Value);
	}

	void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
	{
		throw new NotImplementedException();
	}

	public int Count
	{
		get { return _innerDictionary.Count; }
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
	{
		get { return false; }
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
	{
		return this.Remove(item.Key, item.Value);
	}

	#endregion ICollection<KeyValuePair<TKey,TValue>> Members

	#region IEnumerable<KeyValuePair<TKey,TValue>> Members

	IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
	{
		throw new NotImplementedException();
	}

	#endregion IEnumerable<KeyValuePair<TKey,TValue>> Members

	#region IEnumerable Members

	IEnumerator System.Collections.IEnumerable.GetEnumerator()
	{
		throw new NotImplementedException();
	}

	#endregion IEnumerable Members
}
