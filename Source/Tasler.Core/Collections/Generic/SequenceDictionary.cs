using System;

namespace Tasler.Collections.Generic;

public partial class SequenceDictionary<TKeyItem, TValue>
	where TKeyItem : IComparable<TKeyItem>
{
	private readonly object _lock = new object();
	private SequenceItemNode _rootNode = new RootItemNode();
}
