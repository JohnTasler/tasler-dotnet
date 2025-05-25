using System.Collections.Generic;

namespace Tasler.Collections.Generic;

public partial class SequenceDictionary<TKeyItem, TValue>
{
	private class RootItemNode : SequenceItemNode
	{
		#region Constructors

		/// <summary>
		/// Prevents a default instance of the <see cref="SequenceItemNode"/> class from being created.
		/// </summary>
		/// <param name="sequenceItem">The sequence item.</param>
		public RootItemNode()
		{
			Children = new List<SequenceItemNode>();
		}

		#endregion Constructors

		#region Properties

		public override List<SequenceItemNode> Children { get; protected set; }

		protected override string DebugFormatString
		{
			get { return "ROOT : [{2}]={{{3}{4}"; }
		}
		#endregion Properties
	}
}
