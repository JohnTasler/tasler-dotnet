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
///	  Encapsulates a method that selects the parent of the specified <paramref cref="node"/>
///	  and returns an <see cref="IEnumerable{TTreeNode}"/>
/// </summary>
///   <typeparam name="TTreeNode">The type of tha tree node.</typeparam>
///   <param name="node">The node for which to return the single parent node.</param>
/// <returns>
///   An <see cref="IEnumerable{TTreeNode}"/> that will produce the single parent of the specified <paramref cref="node"/>.
/// </returns>
public delegate TTreeNode? SingleParentSelector<TTreeNode>(TTreeNode? node)
	where TTreeNode : class;

/// <summary>
/// Provides a set of static (Shared in Visual Basic) methods for traversing a generic tree structure.
/// </summary>
public static class TreeTraversalExtensions
{
	/// <summary>
	/// Gets an enumeration of the ancestors of the specified <typeparamref name="TTreeNode"/> .
	/// </summary>
	/// <param name="this">The <see cref="DependencyObject"/> from which to begin the enumeration of visual ancestors.</param>
	/// <param name="selector">A method that selects the parent of the specified node.</param>
	/// <typeparam name="TTreeNode">The type of the tree nodes.</typeparam>
	/// <returns>An <see cref="IEnumerable{TTreeNode}"/> of the ancestors of <paramref name="this"/>.</returns>
	/// <remarks>
	/// To get an ancestor of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/> and
	/// <see cref="System.Linq.Enumerable.FirstOrDefault()"/> extension methods on the return value.
	/// <summary>
	/// Enumerates the ancestors of the specified node by repeatedly applying the parent selector.
	/// </summary>
	/// <param name="this">The starting node whose ancestors will be enumerated.</param>
	/// <param name="selector">A delegate that returns the parent of a given node.</param>
	/// <returns>An enumerable sequence of ancestor nodes, starting from the immediate parent and proceeding up the tree.</returns>
	public static IEnumerable<TTreeNode> GetAncestors<TTreeNode>(this TTreeNode? @this, SingleParentSelector<TTreeNode> selector)
		where TTreeNode : class
	{
		while (@this is not null)
		{
			@this = selector(@this);
			if (@this is not null)
				yield return @this;
		}
	}

	/// <summary>
	/// Gets an enumeration of the specified <typeparamref name="TTreeNode"/> and its ancestors.
	/// </summary>
	/// <param name="this">The <typeparamref name="TTreeNode"/> from which to begin the enumeration of ancestors.</param>
	/// <param name="selector">A method that selects the parent of each node.</param>
	/// <typeparam name="TTreeNode">The type of the tree nodes.</typeparam>
	/// <returns>An <see cref="IEnumerable{DependencyObject}"/> of <paramref name="this"/> and its ancestors.</returns>
	/// <remarks>
	/// To get an ancestor of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/> and
	/// <see cref="System.Linq.Enumerable.FirstOrDefault()"/> extension methods on the return value.
	/// <summary>
	/// Enumerates the specified node and its ancestors, starting with the node itself and proceeding up the tree.
	/// </summary>
	/// <param name="this">The starting node for ancestor traversal.</param>
	/// <param name="selector">A delegate that returns the parent of a given node.</param>
	/// <returns>An <see cref="IEnumerable{TTreeNode}"/> containing the node and its ancestors in order from self to root.</returns>
	public static IEnumerable<TTreeNode> GetSelfAndAncestors<TTreeNode>(this TTreeNode? @this, SingleParentSelector<TTreeNode> selector)
		where TTreeNode : class
	{
		while (@this is not null)
		{
			yield return @this;
			@this = selector(@this);
		}
	}

	/// <summary>
	///   Gets an <see cref="IEnumerable{TTreeNode}" /> that will produce the nodes from the traversal of the
	///   tree  all the descendants of a tree node object, using the breadth-first algorithm. See remarks
	///   for details.
	/// </summary>
	/// <typeparam name="TTreeNode">The type of the nodes in the tree.</typeparam>
	/// <param name="rootNode">The top node from which the traversal will begin.</param>
	/// <param name="childrenSelector">
	///   A method that selects the direct children of the parent node specified by <paramref name="rootNode" />.
	/// </param>
	/// <param name="includeSelf">
	///   If set to <see langword="true"/>, the traversal will first produce the parent node
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
	public static IEnumerable<TTreeNode> GetDescendantsBreadthFirst<TTreeNode>(this TTreeNode rootNode, bool includeSelf, DirectChildrenSelector<TTreeNode> childrenSelector)
		where TTreeNode : class
	{
		return GetDescendants<TTreeNode, BreadthFirstTraversalStrategyCollection<TTreeNode>>(rootNode, includeSelf, childrenSelector);
	}

	/// <summary>Gets the descendants using the depth-first algorithm. See remarks for details.</summary>
	/// <typeparam name="TTreeNode">The type of the nodes in the tree.</typeparam>
	/// <param name="rootNode">The top node from which the traversal will begin.</param>
	/// <param name="includeSelf">
	///   If set to <see langword="true"/>, the traversal will first produce the parent node
	///   specified by <paramref name="rootNode" />.</param>
	/// <param name="childrenSelector">
	///   A method that selects the direct children of the parent node specified by <paramref name="rootNode" />.
	/// </param>
	/// <returns>
	///   An <see cref="IEnumerable{TTreeNode}" /> that will produce the nodes from the traversal of the tree.
	/// </returns>
	/// <seealso cref="GetDescendantsBreadthFirst"/>
	public static IEnumerable<TTreeNode> GetDescendantsDepthFirst<TTreeNode>(this TTreeNode rootNode, bool includeSelf, DirectChildrenSelector<TTreeNode> childrenSelector)
		where TTreeNode : class
	{
		return GetDescendants<TTreeNode, DepthFirstTraversalStrategyCollection<TTreeNode>>(rootNode, includeSelf, childrenSelector);
	}

	private static IEnumerable<TTreeNode>
	GetDescendants<TTreeNode, TTraversalStrategy>(TTreeNode rootNode, bool includeSelf, DirectChildrenSelector<TTreeNode> childrenSelector)
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

			PushChildren(node);
		}

		void PushChildren(TTreeNode node)
		{
			foreach (var child in strategyContainer.OrderChildren(childrenSelector(node)))
				strategyContainer.Push(child);
		}
	}

	private interface ITraversalStrategyCollection<TTreeNode>
		where TTreeNode : class
	{
		bool IsEmpty { get; }

		void Push(TTreeNode node);

		TTreeNode Pop();

		IEnumerable<TTreeNode> OrderChildren(IEnumerable<TTreeNode> children);
	}

	private sealed class BreadthFirstTraversalStrategyCollection<TTreeNode> : ITraversalStrategyCollection<TTreeNode>
		where TTreeNode : class
	{
		private Queue<TTreeNode> _queue = [];
		bool ITraversalStrategyCollection<TTreeNode>.IsEmpty => _queue.Count == 0;
		void ITraversalStrategyCollection<TTreeNode>.Push(TTreeNode node) => _queue.Enqueue(node);
		TTreeNode ITraversalStrategyCollection<TTreeNode>.Pop() => _queue.Dequeue();
		IEnumerable<TTreeNode> ITraversalStrategyCollection<TTreeNode>.OrderChildren(IEnumerable<TTreeNode> children) => children;
	}

	private sealed class DepthFirstTraversalStrategyCollection<TTreeNode> : ITraversalStrategyCollection<TTreeNode>
		where TTreeNode : class
	{
		private Stack<TTreeNode> _stack = [];
		bool ITraversalStrategyCollection<TTreeNode>.IsEmpty => _stack.Count == 0;
		void ITraversalStrategyCollection<TTreeNode>.Push(TTreeNode node) => _stack.Push(node);
		TTreeNode ITraversalStrategyCollection<TTreeNode>.Pop() => _stack.Pop();
		IEnumerable<TTreeNode> ITraversalStrategyCollection<TTreeNode>.OrderChildren(IEnumerable<TTreeNode> children) => children.Reverse();
	}
}
