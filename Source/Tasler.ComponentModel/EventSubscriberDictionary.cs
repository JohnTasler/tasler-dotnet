using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Tasler.ComponentModel;

// TODO: NEEDS_UNIT_TESTS

public class EventSubscriberDictionary<TKey, TDelegate>
	: IDictionary<TKey, EventSubscriber<TDelegate>?>
	, INotifyCollectionChanged
	, INotifyPropertyChanged
	where TKey : notnull
	where TDelegate : notnull, System.Delegate
{
	#region Instance Fields
	private readonly IDictionary<TKey, EventSubscriber<TDelegate>?> _innerDictionary;
	#endregion Instance Fields

	#region Constructors

	/// <summary>
	/// Initializes a new instance of the <see cref="EventSubscriberDictionary{TKey, TDelegate}" /> class.
	/// </summary>
	/// <param name="innerDictionary">The inner dictionary on which this object implements its functionality.</param>
	public EventSubscriberDictionary(IDictionary<TKey, EventSubscriber<TDelegate>?> innerDictionary)
		=> _innerDictionary = innerDictionary;

	#endregion Constructors

	#region IDictionary<TKey, EventSubscriber<TDelegate>> Members

	public void Add(TKey key, EventSubscriber<TDelegate>? value)
	{
		if (this.TryGetValue(key, out var existingValue))
		{
			if (value != existingValue)
			{
				_innerDictionary.Add(key, value);
				this.CollectionChanged?.RaiseReplace(this, value!, existingValue!);
				this.PropertyChanged?.Raise(this, "Item[]");
			}
		}
		else
		{
			_innerDictionary.Add(key, value);
			this.CollectionChanged?.RaiseAdd(this, key!);
			this.PropertyChanged?.Raise(this, nameof(Count));
			this.PropertyChanged?.Raise(this, "Item[]");
		}
	}

	public bool ContainsKey(TKey key)
	{
		return _innerDictionary.ContainsKey(key);
	}

	public ICollection<TKey> Keys
	{
		get { return _innerDictionary.Keys; }
	}

	public bool Remove(TKey key)
	{
		var result = _innerDictionary.Remove(key);
		if (result)
		{
			this.CollectionChanged?.RaiseRemove(this, key!);
			if (this.PropertyChanged is not null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Count)));
				this.PropertyChanged(this, new PropertyChangedEventArgs("Item[]"));
			}
		}
		return result;
	}

	public bool TryGetValue(TKey key, out EventSubscriber<TDelegate>? value)
	{
		return _innerDictionary.TryGetValue(key, out value);
	}

	public ICollection<EventSubscriber<TDelegate>?> Values
	{
		get { return _innerDictionary.Values; }
	}

	public EventSubscriber<TDelegate>? this[TKey key]
	{
		get
		{
			_innerDictionary.TryGetValue(key, out EventSubscriber<TDelegate>? result);
			return result;
		}
		set
		{
			if (value is null)
			{
				this.Remove(key);
			}
			else
			{
				this.Add(key, value);
			}
		}
	}

	#endregion IDictionary<TKey, EventSubscriber<TDelegate>> Members

	#region ICollection<KeyValuePair<TKey, EventSubscriber<TDelegate>>> Members

	void ICollection<KeyValuePair<TKey, EventSubscriber<TDelegate>?>>.Add(KeyValuePair<TKey, EventSubscriber<TDelegate>?> item)
	{
		this.Add(item.Key, item.Value);
	}

	public void Clear()
	{
		if (this.Count != 0)
		{
			var keys = this.Keys.ToList();
			_innerDictionary.Clear();
			this.CollectionChanged?.RaiseRemove(this, keys);

			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
		}
	}

	bool ICollection<KeyValuePair<TKey, EventSubscriber<TDelegate>?>>.Contains(KeyValuePair<TKey, EventSubscriber<TDelegate>?> item)
	{
		return _innerDictionary.Contains(item);
	}

	void ICollection<KeyValuePair<TKey, EventSubscriber<TDelegate>?>>.CopyTo(KeyValuePair<TKey, EventSubscriber<TDelegate>?>[] array, int arrayIndex)
	{
		_innerDictionary.CopyTo(array, arrayIndex);
	}

	public int Count
	{
		get { return _innerDictionary.Count; }
	}

	public bool IsReadOnly
	{
		get { return _innerDictionary.IsReadOnly; }
	}

	bool ICollection<KeyValuePair<TKey, EventSubscriber<TDelegate>?>>.Remove(KeyValuePair<TKey, EventSubscriber<TDelegate>?> item)
	{
		return this.Remove(item.Key);
	}

	#endregion ICollection<KeyValuePair<TKey, EventSubscriber<TDelegate>>> Members

	#region IEnumerable<KeyValuePair<TKey, EventSubscriber<TDelegate>>> Members

	public IEnumerator<KeyValuePair<TKey, EventSubscriber<TDelegate>?>> GetEnumerator()
	{
		return _innerDictionary.GetEnumerator();
	}

	#endregion IEnumerable<KeyValuePair<TKey, EventSubscriber<TDelegate>>> Members

	#region IEnumerable Members

	IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

	#endregion IEnumerable Members

	#region INotifyCollectionChanged Members

	public event NotifyCollectionChangedEventHandler? CollectionChanged;

	#endregion INotifyCollectionChanged Members

	#region INotifyPropertyChanged Members

	public event PropertyChangedEventHandler? PropertyChanged;

	#endregion INotifyPropertyChanged Members
}
