
using System;
namespace Tasler.Collections.Generic
{
	public partial class SequenceDictionary<TKeyItem, TValue>
	{
		private class LeafItemNode : RootItemNode
		{
			#region Constructors

			public LeafItemNode(TKeyItem item)
			{
				this.Item = item;
			}

			public static LeafItemNode FromNode(SequenceItemNode node, bool downgradeFromValue)
			{
				if (!(node is ValueItemNode || node is LeafItemNode))
					throw new ArgumentException("RESX: NODE IS NEITHER a ValueItemNode or LeafItemNode: node.GetType().Name", "node");

				var leafItemNode = node is ValueItemNode && downgradeFromValue
					? new LeafItemNode(node.Item) { Children = node.Children }
					: (LeafItemNode)node;

				return leafItemNode;
			}

			#endregion Constructors

			#region Properties

			public override TKeyItem Item { get; protected set; }

			public override bool HasItem
			{
				get { return true; }
			}

			protected override string DebugFormatString
			{
				get { return "LEAF : Item={0} [{2}]={{{3}{4}"; }
			}
			#endregion Properties
		}
	}
}
