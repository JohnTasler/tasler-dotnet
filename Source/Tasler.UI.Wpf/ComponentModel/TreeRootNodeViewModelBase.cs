using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Tasler.ComponentModel;

namespace Tasler.Windows.ComponentModel;

public abstract partial class TreeRootNodeViewModelBase<TChildCollection, TCollectionView>
	: ObservableObject
	, ITreeNodeViewModel
	, ISingleSelectionContainer
	where TChildCollection : class, IEnumerable, INotifyCollectionChanged
	where TCollectionView : class, ICollectionView
{
	#region Protected Properties

	protected TChildCollection? ChildCollection { get; private set; }

	protected TCollectionView? CollectionView { get; private set; }

	#endregion Protected Properties

	#region Overridables

	protected abstract TChildCollection CreateChildCollection();

	protected abstract TCollectionView CreateCollectionView(TChildCollection childCollection);

	#endregion Overridables

	#region ITreeNodeViewModel Members

	[ObservableProperty]
	private bool _isExpanded;

	public bool IsSelected
	{
		get { return this.SelectedItem == this; }
		set
		{
			if (value)
				this.SelectedItem = this;
			else if (this.SelectedItem == this)
				this.SelectedItem = null;
		}
	}

	public ICollectionView Children
	{
		get
		{
			var collectionView = this.CollectionView;
			if (collectionView is null)
			{
				var childCollection = (this.ChildCollection = this.CreateChildCollection())
					?? throw new InvalidOperationException(string.Format(
						Properties.Resources.MustCreateChildCollectionOfTypeFormat1,
						typeof(TChildCollection).Name));

				collectionView = (this.CollectionView = this.CreateCollectionView(childCollection))
					?? throw new InvalidOperationException(
						string.Format(Properties.Resources.MustCreateChildCollectionOfTypeFormat1,
						typeof(TChildCollection).Name));
			}

			return collectionView;
		}
	}

	#endregion ITreeNodeViewModel Members

	#region ISingleSelectionContainer Members

	[ObservableProperty]
	private object? _selectedItem;

	#endregion ISingleSelectionContainer Members
}
