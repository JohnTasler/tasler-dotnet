
namespace Tasler.Collections.Generic;

public partial class SequenceDictionary<TKeyItem, TValue>
{
	private sealed class ItemNode : LeafItemNode
	{
		#region Constructors

		public ItemNode()
			: base(default(TKeyItem))
		{
		}
		#endregion Constructors

		public ItemNode SetItem(TKeyItem item)
		{
			this.Item = item;
			return this;
		}

		#region Properties
		protected override string DebugFormatString
		{
			get { return "ITEM : Item={0}"; }
		}
		#endregion Properties
	}
}
