using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using Tasler.ComponentModel;

namespace Tasler.Windows.ComponentModel
{
	public abstract class TreeTerminalNodeViewModel<TParent> : ParentedViewModelBase<TParent>, ITreeNodeViewModel
		where TParent : class, INotifyPropertyChanged
	{
		#region ITreeNodeViewModel Members

		public bool IsExpanded
		{
			get { return this.isExpanded; }
			set { this.SetProperty(ref this.isExpanded, value, () => IsExpanded); }
		}
		private bool isExpanded;

		public bool IsSelected
		{
			get { return this.GetIsItemSelected(); }
			set { this.SetIsItemSelected(value); }
		}

		ICollectionView ITreeNodeViewModel.Children
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
		#region Protected Properties

		protected TChildCollection ChildCollection { get; private set; }

		protected TCollectionView CollectionView { get; private set; }

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
	}
}
