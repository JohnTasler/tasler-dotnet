using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Tasler.Extensions;

namespace Tasler;

public class EventSubscriberDictionary<TKey, TDelegate>
	: IDictionary<TKey, EventSubscriber<TDelegate>>
	, INotifyCollectionChanged
	, INotifyPropertyChanged
	where TDelegate : class
{
	#region Constants
	private const string CountPropertyName = "Count";
	#endregion Constants

	#region Instance Fields
	private IDictionary<TKey, EventSubscriber<TDelegate>> innerDictionary;
	#endregion Instance Fields

	#region Constructors
	/// <summary>
	/// Initializes the <see cref="EventSubscriberDictionary{TDelegate}" /> class.
	/// </summary>
	/// <exception cref="System.InvalidCastException">The <typeparamref name="TDelegate"/> is not a <see cref="Delegate"/> type.</exception>
	static EventSubscriberDictionary()
	{
		// Unfortunately, the C# compiler does not allow Delegate or MulticastDelegate as generic type constraints,
		// so we have to check at runtime.
		if (!typeof(TDelegate).Is<Delegate>())
			throw new InvalidCastException(Properties.Resources.TDelegateMustBeDelegate);
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="EventSubscriberDictionary{TDelegate}" /> class.
	/// </summary>
	/// <param name="innerDictionary">The inner dictionary on which this object implements its functionality.</param>
	public EventSubscriberDictionary(IDictionary<TKey, EventSubscriber<TDelegate>> innerDictionary)
	{
		if (innerDictionary == null)
			throw new ArgumentNullException("innerDictionary");

		this.innerDictionary = innerDictionary;
	}
	#endregion Constructors

	#region IDictionary<TKey, EventSubscriber<TDelegate>> Members

	public void Add(TKey key, EventSubscriber<TDelegate> value)
	{
		var existingValue = this[key];
		if (existingValue != null)
		{
			this.innerDictionary[key] = value;
		}
		else
		{
			this.innerDictionary.Add(key, value);
			this.CollectionChanged.RaiseAdd(this, key);

			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(CountPropertyName));
		}
	}

	public bool ContainsKey(TKey key)
	{
		return this.innerDictionary.ContainsKey(key);
	}

	public ICollection<TKey> Keys
	{
		get { return this.innerDictionary.Keys; }
	}

	public bool Remove(TKey key)
	{
		var result = this.innerDictionary.Remove(key);
		if (result)
		{
			this.CollectionChanged.RaiseRemove(this, key);

			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(CountPropertyName));
		}
		return result;
	}

	public bool TryGetValue(TKey key, out EventSubscriber<TDelegate> value)
	{
		return this.innerDictionary.TryGetValue(key, out value);
	}

	public ICollection<EventSubscriber<TDelegate>> Values
	{
		get { return this.innerDictionary.Values; }
	}

	public EventSubscriber<TDelegate> this[TKey key]
	{
		get
		{
			EventSubscriber<TDelegate> result = null;
			this.innerDictionary.TryGetValue(key, out result);
			return result;
		}
		set
		{
			if (value == null)
				this.Remove(key);
			else
				this.Add(key, value);
		}
	}

	#endregion IDictionary<TKey, EventSubscriber<TDelegate>> Members

	#region ICollection<KeyValuePair<TKey, EventSubscriber<TDelegate>>> Members

	void ICollection<KeyValuePair<TKey, EventSubscriber<TDelegate>>>.Add(KeyValuePair<TKey, EventSubscriber<TDelegate>> item)
	{
		this.Add(item.Key, item.Value);
	}

	public void Clear()
	{
		if (this.Count != 0)
		{
			var keys = this.Keys.ToList();
			this.innerDictionary.Clear();
			this.CollectionChanged.RaiseRemove(this, keys);

			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(CountPropertyName));
		}
	}

	bool ICollection<KeyValuePair<TKey, EventSubscriber<TDelegate>>>.Contains(KeyValuePair<TKey, EventSubscriber<TDelegate>> item)
	{
		return this.innerDictionary.Contains(item);
	}

	void ICollection<KeyValuePair<TKey, EventSubscriber<TDelegate>>>.CopyTo(KeyValuePair<TKey, EventSubscriber<TDelegate>>[] array, int arrayIndex)
	{
		this.innerDictionary.CopyTo(array, arrayIndex);
	}

	public int Count
	{
		get { return this.innerDictionary.Count; }
	}

	public bool IsReadOnly
	{
		get { return this.innerDictionary.IsReadOnly; }
	}

	bool ICollection<KeyValuePair<TKey, EventSubscriber<TDelegate>>>.Remove(KeyValuePair<TKey, EventSubscriber<TDelegate>> item)
	{
		return this.Remove(item.Key);
	}

	#endregion ICollection<KeyValuePair<TKey, EventSubscriber<TDelegate>>> Members

	#region IEnumerable<KeyValuePair<TKey, EventSubscriber<TDelegate>>> Members

	public IEnumerator<KeyValuePair<TKey, EventSubscriber<TDelegate>>> GetEnumerator()
	{
		return this.innerDictionary.GetEnumerator();
	}

	#endregion IEnumerable<KeyValuePair<TKey, EventSubscriber<TDelegate>>> Members

	#region IEnumerable Members

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	#endregion IEnumerable Members

	#region INotifyCollectionChanged Members

	public event NotifyCollectionChangedEventHandler CollectionChanged;

	#endregion INotifyCollectionChanged Members

	#region INotifyPropertyChanged Members

	public event PropertyChangedEventHandler PropertyChanged;

	#endregion INotifyPropertyChanged Members
}
