using System;
using System.Collections.Generic;

namespace Tasler.Collections.Generic
{
	public interface ISequenceItemNode<TKeyItem, TValue>
		where TKeyItem : IComparable<TKeyItem>
	{
		#region Properties

		TKeyItem Item { get; }

		IEnumerable<ISequenceItemNode<TKeyItem, TValue>> Children { get; }

		TValue Value { get; }

		bool HasItem { get; }

		bool HasChildren { get; }

		bool HasValue { get; }

		#endregion Properties
	}
}
