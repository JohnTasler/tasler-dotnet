using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Tasler.Windows.ComponentModel;

public abstract partial class TreeTerminalNodeViewModel<TParent> : ChildViewModelBase<TParent>, ITreeNodeViewModel
	where TParent : class, INotifyPropertyChanged
{
	#region Constructors
	protected TreeTerminalNodeViewModel(TParent parent)
		: base(parent)
	{
	}
	#endregion Constructors

	#region ITreeNodeViewModel Members

	[ObservableProperty]
	private bool _isExpanded;

	[ObservableProperty]
	private bool _isSelected;

	ICollectionView? ITreeNodeViewModel.Children
	{
		get { return null; }
	}

	#endregion ITreeNodeViewModel Members
}


public abstract class TreeNodeViewModel<TParent, TChildCollection, TCollectionView> : TreeTerminalNodeViewModel<TParent>
	where TParent : class, INotifyPropertyChanged
	where TChildCollection : class, IEnumerable, INotifyCollectionChanged
	where TCollectionView : class, ICollectionView
{
	#region Constructors
	protected TreeNodeViewModel(TParent parent)
		: base(parent)
	{
	}
	#endregion Constructors

	#region Protected Properties

	protected TChildCollection? ChildCollection { get; private set; }

	protected TCollectionView? CollectionView { get; private set; }

	#endregion Protected Properties

	#region Overridables

	protected abstract TChildCollection CreateChildCollection();

	protected abstract TCollectionView CreateCollectionView(TChildCollection childCollection);

	#endregion Overridables

	#region ITreeNodeViewModel Members

	public ICollectionView Children
	{
		get
		{
			var collectionView = this.CollectionView;
			if (collectionView is null)
			{
				var childCollection = (this.ChildCollection = this.CreateChildCollection()) ??
					throw new InvalidOperationException(
						string.Format(
							Properties.Resources.MustCreateChildCollectionOfTypeFormat1,
							typeof(TChildCollection).Name));

				collectionView = (this.CollectionView = this.CreateCollectionView(childCollection)) ??
					throw new InvalidOperationException(
						string.Format(
							Properties.Resources.MustCreateChildCollectionOfTypeFormat1,
							typeof(TChildCollection).Name));
			}

			return collectionView;
		}
	}

	#endregion ITreeNodeViewModel Members
}
