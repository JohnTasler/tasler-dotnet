using System.Collections.ObjectModel;
using Tasler.ComponentModel;
using Tasler.ComponentModel.Extensions;

namespace Tests.Tasler.ComponentModel.Extensions;

public class TreeTraversalExtensionsTests
{
	[Fact]
	public void TraverseBreadthFirstIncludingSelf()
	{
		var rootNode = s_rootNode;
		var nodes = rootNode.GetDescendantsBreadthFirst(true, n => n.Children).ToList();
		Assert.Equal(10, nodes.Count);
		Assert.Equal("RootNode0"       , nodes[0].Name);
		Assert.Equal("ChildNode0-0"    , nodes[1].Name);
		Assert.Equal("ChildNode0-1"    , nodes[2].Name);
		Assert.Equal("ChildNode0-0-0"  , nodes[3].Name);
		Assert.Equal("ChildNode0-0-1"  , nodes[4].Name);
		Assert.Equal("ChildNode0-1-0"  , nodes[5].Name);
		Assert.Equal("ChildNode0-1-1"  , nodes[6].Name);
		Assert.Equal("ChildNode0-1-2"  , nodes[7].Name);
		Assert.Equal("ChildNode0-1-2-0", nodes[8].Name);
		Assert.Equal("ChildNode0-1-2-1", nodes[9].Name);
	}

	[Fact]
	public void TraverseDepthFirstIncludingSelf()
	{
		var rootNode = s_rootNode;
		var nodes = rootNode.GetDescendantsDepthFirst(true, n => n.Children).ToList();
		Assert.Equal(10, nodes.Count);
		Assert.Equal("RootNode0"       , nodes[0].Name);
		Assert.Equal("ChildNode0-0"    , nodes[1].Name);
		Assert.Equal("ChildNode0-0-0"  , nodes[2].Name);
		Assert.Equal("ChildNode0-0-1"  , nodes[3].Name);
		Assert.Equal("ChildNode0-1"    , nodes[4].Name);
		Assert.Equal("ChildNode0-1-0"  , nodes[5].Name);
		Assert.Equal("ChildNode0-1-1"  , nodes[6].Name);
		Assert.Equal("ChildNode0-1-2"  , nodes[7].Name);
		Assert.Equal("ChildNode0-1-2-0", nodes[8].Name);
		Assert.Equal("ChildNode0-1-2-1", nodes[9].Name);
	}

	[Fact]
	public void TraverseBreadthFirstExcludingSelf()
	{
		var rootNode = s_rootNode;
		var nodes = rootNode.GetDescendantsBreadthFirst(false, n => n.Children).ToList();
		Assert.Equal(9, nodes.Count);
		Assert.Equal("ChildNode0-0"    , nodes[0].Name);
		Assert.Equal("ChildNode0-1"    , nodes[1].Name);
		Assert.Equal("ChildNode0-0-0"  , nodes[2].Name);
		Assert.Equal("ChildNode0-0-1"  , nodes[3].Name);
		Assert.Equal("ChildNode0-1-0"  , nodes[4].Name);
		Assert.Equal("ChildNode0-1-1"  , nodes[5].Name);
		Assert.Equal("ChildNode0-1-2"  , nodes[6].Name);
		Assert.Equal("ChildNode0-1-2-0", nodes[7].Name);
		Assert.Equal("ChildNode0-1-2-1", nodes[8].Name);
	}

	[Fact]
	public void TraverseDepthFirstExcludingSelf()
	{
		var rootNode = s_rootNode;
		var nodes = rootNode.GetDescendantsDepthFirst(false, n => n.Children).ToList();
		Assert.Equal(9, nodes.Count);
		Assert.Equal("ChildNode0-0"    , nodes[0].Name);
		Assert.Equal("ChildNode0-0-0"  , nodes[1].Name);
		Assert.Equal("ChildNode0-0-1"  , nodes[2].Name);
		Assert.Equal("ChildNode0-1"    , nodes[3].Name);
		Assert.Equal("ChildNode0-1-0"  , nodes[4].Name);
		Assert.Equal("ChildNode0-1-1"  , nodes[5].Name);
		Assert.Equal("ChildNode0-1-2"  , nodes[6].Name);
		Assert.Equal("ChildNode0-1-2-0", nodes[7].Name);
		Assert.Equal("ChildNode0-1-2-1", nodes[8].Name);
	}

	[Fact]
	public void TraverseAncestorsIncludingSelf()
	{
		TreeNode? startNode = s_rootNode.GetDescendantsBreadthFirst(true, n => n.Children).LastOrDefault();
		var nodes = startNode.GetSelfAndAncestors(n => n?.Parent as TreeNode).ToList();
		Assert.Equal(4, nodes.Count);
		Assert.Equal("ChildNode0-1-2-1", nodes[0].Name);
		Assert.Equal("ChildNode0-1-2"  , nodes[1].Name);
		Assert.Equal("ChildNode0-1"    , nodes[2].Name);
		Assert.Equal("RootNode0"       , nodes[3].Name);
	}

	[Fact]
	public void TraverseAncestorsExcludingSelf()
	{
		TreeNode? startNode = s_rootNode.GetDescendantsBreadthFirst(false, n => n.Children).LastOrDefault();
		var nodes = startNode.GetAncestors(n => n?.Parent as TreeNode).ToList();
		Assert.Equal(3, nodes.Count);
		Assert.Equal("ChildNode0-1-2", nodes[0].Name);
		Assert.Equal("ChildNode0-1"  , nodes[1].Name);
		Assert.Equal("RootNode0"     , nodes[2].Name);
	}

	private static TreeNode s_rootNode =
		new()
		{
			Name = "RootNode0",
			Children =
			{
				new()
				{
					Name = "ChildNode0-0",
					Children =
					{
						new() { Name = "ChildNode0-0-0" },
						new() { Name = "ChildNode0-0-1" },
					}
				},

				new()
				{
					Name = "ChildNode0-1",
					Children =
					{
						new() { Name = "ChildNode0-1-0" },
						new() { Name = "ChildNode0-1-1" },
						new()
						{
							Name = "ChildNode0-1-2",
							Children =
							{
								new() { Name = "ChildNode0-1-2-0" },
								new() { Name = "ChildNode0-1-2-1" },
							}
						},

					}
				},
			}
		};
}

public interface ITreeNode<T>
	where T : ITreeNode<T>
{
	ITreeNode<T>? Parent { get; set; }

	ICollection<T> Children { get; }
}

public interface INodeData
{
	string Name { get; set; }
}

public class TreeNode : ITreeNode<TreeNode>, INodeData
{
	public TreeNode()
	{
		var children = new ObservableCollection<TreeNode>();
		this.Children = children;

		children.CollectionChanged += (sender, args) =>
		{
			if (args.NewItems is not null && args.NewItems.Count > 0)
			{
				foreach (ITreeNode<TreeNode> child in args.NewItems)
					child.Parent = this;
			}

			if (args.OldItems is not null && args.OldItems.Count > 0)
			{
				foreach (ITreeNode<TreeNode> child in args.OldItems)
					child.Parent = null;
			}
		};
	}

	public ITreeNode<TreeNode>? Parent { get; set; }

	public ICollection<TreeNode> Children { get; }

	public string Name { get; set; } = string.Empty;
}
