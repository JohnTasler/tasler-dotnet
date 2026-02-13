using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using CommunityToolkit.Diagnostics;

namespace Tasler;

public class EventSubscriberDictionary<TKey, TDelegate>
	: IDictionary<TKey, EventSubscriber<TDelegate>?>
	, INotifyCollectionChanged
	, INotifyPropertyChanged
	where TDelegate : Delegate
{
	#region Instance Fields
	private IDictionary<TKey, EventSubscriber<TDelegate>?> _innerDictionary;
	#endregion Instance Fields

	#region Constructors
	/// <summary>
	/// Initializes a new instance of the <see cref="EventSubscriberDictionary{TDelegate}" /> class.
	/// </summary>
	/// <param name="innerDictionary">The inner dictionary on which this object implements its functionality.</param>
	public EventSubscriberDictionary(IDictionary<TKey, EventSubscriber<TDelegate>?> innerDictionary)
	{
		Guard.IsNotNull(innerDictionary);
		_innerDictionary = innerDictionary;
	}
	#endregion Constructors

	#region IDictionary<TKey, EventSubscriber<TDelegate>> Members

	public void Add(TKey key, EventSubscriber<TDelegate>? value)
	{
		var existingValue = this[key];
		if (existingValue is not null)
		{
			_innerDictionary[key] = value;
		}
		else
		{
			_innerDictionary.Add(key, value);
			this.CollectionChanged?.RaiseAdd(this, key!);

			if (this.PropertyChanged is not null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Count)));
		}
	}

	public bool ContainsKey(TKey key) => _innerDictionary.ContainsKey(key);

	public ICollection<TKey> Keys =>_innerDictionary.Keys;

	public bool Remove(TKey key)
	{
		var result = _innerDictionary.Remove(key);
		if (result)
		{
			this.CollectionChanged?.RaiseRemove(this, key!);

			if (this.PropertyChanged is not null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Count)));
		}
		return result;
	}

	public bool TryGetValue(TKey key, out EventSubscriber<TDelegate>? value) => _innerDictionary.TryGetValue(key, out value);

	public ICollection<EventSubscriber<TDelegate>?> Values => _innerDictionary.Values;

	public EventSubscriber<TDelegate>? this[TKey key]
	{
		get
		{
			EventSubscriber<TDelegate>? result = null;
			_innerDictionary.TryGetValue(key, out result);
			return result;
		}
		set
		{
			if (value is null)
				this.Remove(key);
			else
				this.Add(key, value);
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

			if (this.PropertyChanged is not null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Count)));
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

	public int Count => _innerDictionary.Count;

	public bool IsReadOnly => _innerDictionary.IsReadOnly;

	bool ICollection<KeyValuePair<TKey, EventSubscriber<TDelegate>?>>.Remove(KeyValuePair<TKey, EventSubscriber<TDelegate>?> item)
	{
		return this.Remove(item.Key);
	}

	#endregion ICollection<KeyValuePair<TKey, EventSubscriber<TDelegate>?>> Members

	#region IEnumerable<KeyValuePair<TKey, EventSubscriber<TDelegate>?>> Members

	public IEnumerator<KeyValuePair<TKey, EventSubscriber<TDelegate>?>> GetEnumerator() => _innerDictionary.GetEnumerator();

	#endregion IEnumerable<KeyValuePair<TKey, EventSubscriber<TDelegate>?>> Members

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
