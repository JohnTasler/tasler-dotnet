using System;
using System.Collections;
using System.Collections.Generic;

namespace Tasler.Collections.Generic
{
	public partial class SequenceDictionary<TKeyItem, TValue> : IDictionary<IEnumerable<TKeyItem>, TValue>, IDictionary
	{
		#region IDictionary<IEnumerable<TKeyItem>,TValue> Members

		public void Add(IEnumerable<TKeyItem> key, TValue value)
		{
			SequenceItemNode.FindOrCreateSequenceItemNode(_rootNode, key, value);
		}

		public bool ContainsKey(IEnumerable<TKeyItem> key)
		{
			var node = SequenceItemNode.TryFindSequenceItemNode(_rootNode, key);
			return node != null;
		}

		public ICollection<IEnumerable<TKeyItem>> Keys
		{
			get { throw new NotImplementedException(); }
		}

		public bool Remove(IEnumerable<TKeyItem> key)
		{
			throw new NotImplementedException();
		}

		public bool TryGetValue(IEnumerable<TKeyItem> key, out TValue value)
		{
			var node = SequenceItemNode.TryFindSequenceItemNode(_rootNode, key);
			var result = node != null;
			value = result ? node.Value : default(TValue);
			return result;
		}

		public ICollection<TValue> Values
		{
			get { throw new NotImplementedException(); }
		}

		public TValue this[IEnumerable<TKeyItem> key]
		{
			get
			{
				var node = SequenceItemNode.TryFindSequenceItemNode(_rootNode, key);
				if (node == null)
					throw new KeyNotFoundException();
				return node.Value;
			}
			set
			{
				SequenceItemNode.FindOrCreateSequenceItemNode(_rootNode, key, value);
			}
		}

		#endregion IDictionary<IEnumerable<TKeyItem>,TValue> Members

		#region ICollection<KeyValuePair<IEnumerable<TKeyItem>,TValue>> Members

		public void Add(KeyValuePair<IEnumerable<TKeyItem>, TValue> item)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			_rootNode = new RootItemNode();
		}

		public bool Contains(KeyValuePair<IEnumerable<TKeyItem>, TValue> item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(KeyValuePair<IEnumerable<TKeyItem>, TValue>[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public int Count
		{
			get { throw new NotImplementedException(); }
		}

		public bool IsReadOnly
		{
			get { throw new NotImplementedException(); }
		}

		public bool Remove(KeyValuePair<IEnumerable<TKeyItem>, TValue> item)
		{
			throw new NotImplementedException();
		}

		#endregion ICollection<KeyValuePair<IEnumerable<TKeyItem>,TValue>> Members

		#region IEnumerable<KeyValuePair<IEnumerable<TKeyItem>,TValue>> Members

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// An <see cref="IEnumerator{T}" /> that can be used to iterate through the collection.
		/// </returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public IEnumerator<KeyValuePair<IEnumerable<TKeyItem>, TValue>> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		#endregion IEnumerable<KeyValuePair<IEnumerable<TKeyItem>,TValue>> Members

		#region IDictionary Members

		void IDictionary.Add(object key, object value)
		{
			this.Add((IEnumerable<TKeyItem>)key, (TValue)value);
		}

		void IDictionary.Clear()
		{
			this.Clear();
		}

		bool IDictionary.Contains(object key)
		{
			return this.ContainsKey((IEnumerable<TKeyItem>)key);
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		bool IDictionary.IsFixedSize
		{
			get { return false; }
		}

		bool IDictionary.IsReadOnly
		{
			get { return this.IsReadOnly; }
		}

		ICollection IDictionary.Keys
		{
			get { throw new NotImplementedException(); }
		}

		void IDictionary.Remove(object key)
		{
			this.Remove((IEnumerable<TKeyItem>)key);
		}

		ICollection IDictionary.Values
		{
			get { throw new NotImplementedException(); }
		}

		object IDictionary.this[object key]
		{
			get { return ((IDictionary<IEnumerable<TKeyItem>, TValue>)this)[(IEnumerable<TKeyItem>)key]; }
			set { ((IDictionary<IEnumerable<TKeyItem>, TValue>)this)[(IEnumerable<TKeyItem>)key] = (TValue)value; }
		}

		#endregion

		#region ICollection Members

		void ICollection.CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}

		int ICollection.Count
		{
			get { throw new NotImplementedException(); }
		}

		bool ICollection.IsSynchronized
		{
			get { throw new NotImplementedException(); }
		}

		object ICollection.SyncRoot
		{
			get { throw new NotImplementedException(); }
		}

		#endregion

		#region IEnumerable Members

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// An <see cref="IEnumerator" /> object that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#endregion IEnumerable Members
	}
}
