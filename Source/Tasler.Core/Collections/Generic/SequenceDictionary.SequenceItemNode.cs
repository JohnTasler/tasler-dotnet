using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Tasler.Collections.Generic
{
	public partial class SequenceDictionary<TKeyItem, TValue>
	{
		private abstract class SequenceItemNode : ISequenceItemNode<TKeyItem, TValue>
		{
			#region Static Fields
			private static readonly DelegateComparer<SequenceItemNode> _itemComparer =
				new DelegateComparer<SequenceItemNode>((x, y) => x.Item.CompareTo(y.Item));

			protected static readonly List<SequenceItemNode> EmptyChildren = new List<SequenceItemNode>();
			#endregion Static Fields

			#region Constructors

			/// <summary>
			/// Initializes a new instance of the <see cref="SequenceDictionary{TKeyItem, TValue}.SequenceItemNode"/> class.
			/// </summary>
			protected SequenceItemNode()
			{
			}

			#endregion Constructors

			#region Properties

			public virtual TKeyItem Item
			{
				get { return default(TKeyItem); }
				protected set { ThrowReadOnlyPropertyException("Item"); }
			}

			public virtual List<SequenceItemNode> Children
			{
				get { return EmptyChildren; }
				protected set { ThrowReadOnlyPropertyException("Children"); }
			}

			public virtual TValue Value
			{
				get { return default(TValue); }
				protected set { ThrowReadOnlyPropertyException("Value"); }
			}

			[DebuggerHidden]
			protected abstract string DebugFormatString { get; }

			#endregion Properties

			#region Methods

			public static SequenceItemNode FindOrCreateSequenceItemNode(SequenceItemNode parent, IEnumerable<TKeyItem> sequence, TValue value)
			{
				if (parent == null)
					throw new ArgumentNullException("parent");
				if (sequence == null)
					throw new ArgumentNullException("sequence");

				var comparisonNode = new ItemNode();
				var previousParent = default(SequenceItemNode);
				var currentParent = parent;
				var enumerator = sequence.GetEnumerator();
				var hasNextItem = enumerator.MoveNext();
				while (hasNextItem)
				{
					var item = enumerator.Current;
					hasNextItem = enumerator.MoveNext();

					var itemNode = default(SequenceItemNode);
					var itemIndex = currentParent.Children.BinarySearch(comparisonNode.SetItem(item), _itemComparer);
					if (itemIndex < 0)
					{
						itemNode = hasNextItem ? new LeafItemNode(item) : new ValueItemNode(item, value);
						currentParent.Children.Insert(~itemIndex, itemNode);
					}
					else
					{
						itemNode = currentParent.Children[itemIndex];
						itemNode = hasNextItem ? LeafItemNode.FromNode(itemNode, false) : ValueItemNode.FromNode(itemNode, value);
						currentParent.Children[itemIndex] = itemNode;
					}

					previousParent = currentParent;
					currentParent = itemNode;
				}

				return currentParent;
			}

			public static ValueItemNode TryFindSequenceItemNode(SequenceItemNode parent, IEnumerable<TKeyItem> sequence)
			{
				if (parent == null)
					throw new ArgumentNullException("parent");
				if (sequence == null)
					throw new ArgumentNullException("sequence");

				var comparisonNode = new ItemNode();
				var previousParent = default(SequenceItemNode);
				var currentParent = parent;
				foreach (var item in sequence)
				{
					var itemIndex = currentParent.Children.BinarySearch(comparisonNode.SetItem(item), _itemComparer);
					if (itemIndex < 0)
						return null;

					previousParent = currentParent;
					currentParent = currentParent.Children[itemIndex];
				}

				return currentParent as ValueItemNode;
			}

			#endregion Methods

			#region Overrides

			public override string ToString()
			{
				return string.Format(this.DebugFormatString,
					this.Item,
					this.Value,
					this.Children.Count,
					string.Join(",", this.Children.Select(c => c.Item)),
					"}");
			}

			#endregion Overrides

			#region ISequenceItemNode<TKeyItem, TValue> Implementation

			IEnumerable<ISequenceItemNode<TKeyItem, TValue>> ISequenceItemNode<TKeyItem, TValue>.Children
			{
				get { return this.Children; }
			}

			public virtual bool HasItem     { get { return false; } }
			public virtual bool HasChildren { get { return this.Children.Count != 0; } }
			public virtual bool HasValue    { get { return false; } }

			#endregion ISequenceItemNode<TKeyItem, TValue> Implementation

			#region Private Implementation

			private void ThrowReadOnlyPropertyException(string propertyName)
			{
				var message = string.Format("The {0}.{1} property is read-only.", this.GetType().Name, propertyName);
				throw new InvalidOperationException(message);
			}

			#endregion Private Implementation
		}
	}
}
