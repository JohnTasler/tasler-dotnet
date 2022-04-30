using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using Tasler.ComponentModel;


namespace Tasler.Windows.ComponentModel
{
	public abstract class TreeRootNodeViewModelBase<TChildCollection, TCollectionView>
		: ViewModelBase
		, ITreeNodeViewModel
		, ISingleSelectionContainer
		where TChildCollection : class, IEnumerable, INotifyCollectionChanged
		where TCollectionView : class, ICollectionView
	{
		#region Protected Properties

		protected TChildCollection ChildCollection { get; private set; }

		protected TCollectionView CollectionView { get; private set; }

		#endregion Protected Properties

		#region Overridables

		protected abstract TChildCollection CreateChildCollection();

		protected abstract TCollectionView CreateCollectionView(TChildCollection childCollection);

		#endregion Overridables

		#region ITreeNodeViewModel Members

		public bool IsExpanded
		{
			get { return this.isExpanded; }
			set { this.SetProperty(ref this.isExpanded, value, () => IsExpanded); }
		}
		private bool isExpanded;

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
				if (collectionView == null)
				{
					var childCollection = this.ChildCollection = this.CreateChildCollection();
					if (childCollection == null)
						throw new InvalidOperationException(
							string.Format(
								Properties.Resources.MustCreateChildCollectionOfTypeFormat1,
								typeof(TChildCollection).Name));

					collectionView = this.CollectionView = this.CreateCollectionView(childCollection);
					if (collectionView == null)
						throw new InvalidOperationException(
							string.Format(
								Properties.Resources.MustCreateChildCollectionOfTypeFormat1,
								typeof(TChildCollection).Name));
				}

				return collectionView;
			}
		}

		#endregion ITreeNodeViewModel Members

		#region ISingleSelectionContainer Members

		public object SelectedItem
		{
			get { return this.selectedItem; }
			set { this.SetProperty(ref this.selectedItem, value, () => SelectedItem); }
		}
		private object selectedItem;

		#endregion ISingleSelectionContainer Members
	}
}
