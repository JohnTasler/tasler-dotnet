namespace Tasler.ComponentModel.Extensions;

/// <summary>
///	  Encapsulates a method that selects the children of the specified <paramref cref="node"/>
///	  and returns an <see cref="IEnumerable{TTreeNode}"/>
/// </summary>
///   <typeparam name="TTreeNode">The type of tha tree node.</typeparam>
///   <param name="node">The node for which to return the direct child nodes.</param>
/// <returns>
///   An <see cref="IEnumerable{TTreeNode}"/> that will produce the direct children of the specified <paramref cref="node"/>.
/// </returns>
public delegate IEnumerable<TTreeNode> DirectChildrenSelector<TTreeNode>(TTreeNode node)
	where TTreeNode : class;

/// <summary>
/// Provides a set of static (Shared in Visual Basic) methods for traversing a generic tree structure.
/// </summary>
public static class TreeTraversalExtensions
{
	/// <summary>
	///   Gets an <see cref="IEnumerable{TTreeNode}" /> that will produce the nodes from the traversal of the
	///   tree  all the descendants of a tree node object, using the breadth-first algorithm. See remarks
	///   for details.
	/// </summary>
	/// <typeparam name="TTreeNode">The type of the nodes in the tree.</typeparam>
	/// <param name="rootNode">The top node from which the traversal will begin.</param>
	/// <param name="childrenSelector">
	///   A method that selects the direct children of the parent node specified by <paramref name="this" />.
	/// </param>
	/// <param name="includeSelf">
	///   If set to <c>true</c>, the traversal will first produce the parent node
	///   specified by <paramref name="rootNode" />.</param>
	/// <returns>
	///   An <see cref="IEnumerable{TTreeNode}" /> that will produce the nodes from the traversal of the tree.
	/// </returns>
	/// <remarks>
	/// When you know that the order of traversal is such that you want to find a node that is more closer to the
	/// sibling nodes than to the deeper ancestors, favor using this algorithm instead of the algorithm used in
	/// <see cref="GetDescendantsDepthFirst{TTreeNode}" />. This can allow your enumeration (traversal) loop to exit sooner.
	/// </remarks>
	/// <seealso cref="GetDescendantsDepthFirst"/> />
	public static IEnumerable<TTreeNode> GetDescendantsBreadthFirst<TTreeNode>(this TTreeNode rootNode, DirectChildrenSelector<TTreeNode> childrenSelector, bool includeSelf)
		where TTreeNode : class
	{
		return GetDescendants<TTreeNode, BreadthFirstTraversalStrategyCollection<TTreeNode>>(rootNode, childrenSelector, includeSelf);
	}

	/// <summary>Gets the descendants using the depth-first algorithm. See remarks for details.</summary>
	/// <typeparam name="TTreeNode">The type of the nodes in the tree.</typeparam>
	/// <param name="node">The top node from which the traversal will begin.</param>
	/// <param name="childrenSelector">
	///   A method that selects the direct children of the parent node specified by <paramref name="node" />.
	/// </param>
	/// <param name="includeSelf">
	///   If set to <c>true</c>, the traversal will first produce the parent node
	///   specified by <paramref name="node" />.</param>
	/// <returns>
	///   An <see cref="IEnumerable{TTreeNode}" /> that will produce the nodes from the traversal of the tree.
	/// </returns>
	/// <seealso cref="GetDescendantsBreadthFirst"/>
	public static IEnumerable<TTreeNode> GetDescendantsDepthFirst<TTreeNode>(this TTreeNode rootNode, DirectChildrenSelector<TTreeNode> childrenSelector, bool includeSelf)
		where TTreeNode : class
	{
		return GetDescendants<TTreeNode, DepthFirstTraversalStrategyCollection<TTreeNode>>(rootNode, childrenSelector, includeSelf);
	}

	private static IEnumerable<TTreeNode>
	GetDescendants<TTreeNode, TTraversalStrategy>(TTreeNode rootNode, DirectChildrenSelector<TTreeNode> childrenSelector, bool includeSelf)
		where TTreeNode : class
		where TTraversalStrategy : ITraversalStrategyCollection<TTreeNode>, new()
	{

		var strategyContainer = new TTraversalStrategy();

		if (includeSelf)
		{
			strategyContainer.Push(rootNode);
		}
		else
		{
			PushChildren(rootNode);
		}

		while (!strategyContainer.IsEmpty)
		{
			var node = strategyContainer.Pop();
			yield return node;

			PushChildren(rootNode);
		}

		void PushChildren(TTreeNode node)
		{
			foreach (var child in childrenSelector(node))
				strategyContainer.Push(child);
		}
	}

	private interface ITraversalStrategyCollection<TTreeNode>
		where TTreeNode : class
	{
		bool IsEmpty { get; }

		void Push(TTreeNode node);

		TTreeNode Pop();
	}

	private sealed class BreadthFirstTraversalStrategyCollection<TTreeNode> : ITraversalStrategyCollection<TTreeNode>
		where TTreeNode : class
	{
		private Queue<TTreeNode> _queue = [];
		bool ITraversalStrategyCollection<TTreeNode>.IsEmpty => _queue.Count > 0;
		void ITraversalStrategyCollection<TTreeNode>.Push(TTreeNode node) => _queue.Enqueue(node);
		TTreeNode ITraversalStrategyCollection<TTreeNode>.Pop() => _queue.Dequeue();
	}

	private sealed class DepthFirstTraversalStrategyCollection<TTreeNode> : ITraversalStrategyCollection<TTreeNode>
		where TTreeNode : class
	{
		private Stack<TTreeNode> _stack = [];
		bool ITraversalStrategyCollection<TTreeNode>.IsEmpty => _stack.Count > 0;
		void ITraversalStrategyCollection<TTreeNode>.Push(TTreeNode node) => _stack.Push(node);
		TTreeNode ITraversalStrategyCollection<TTreeNode>.Pop() => _stack.Pop();
	}
}
