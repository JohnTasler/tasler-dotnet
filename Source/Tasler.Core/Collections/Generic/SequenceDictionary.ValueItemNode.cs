using System;

namespace Tasler.Collections.Generic;

public partial class SequenceDictionary<TKeyItem, TValue>
{
	private sealed class ValueItemNode : LeafItemNode
	{
		#region Constructors

		public ValueItemNode(TKeyItem item, TValue value)
			: base(item)
		{
			this.Value = value;
		}

		public static ValueItemNode FromNode(SequenceItemNode node, TValue value)
		{
			if (!(node is ValueItemNode || node is LeafItemNode))
				throw new ArgumentException("RESX: NODE IS NEITHER a ValueItemNode or LeafItemNode: node.GetType().Name", "node");

			var valueItemNode = node as ValueItemNode;
			if (valueItemNode != null)
				valueItemNode.Value = value;
			else
				valueItemNode = new ValueItemNode(node.Item, value) { Children = node.Children };

			return valueItemNode;
		}
		#endregion Constructors

		#region Properties

		public bool IsTerminal
		{
			get { return this.Children.Count == 0; }
		}

		public override TValue Value { get; protected set; }

		public override bool HasValue
		{
			get { return true; }
		}

		protected override string DebugFormatString
		{
			get
			{
				return this.IsTerminal
					? "TERM : Item={0} Value={1}"
					: "VALUE: Item={0} Value={1} [{2}]={{{3}{4}";
			}
		}

		#endregion Properties
	}
}
