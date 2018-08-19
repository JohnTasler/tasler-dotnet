using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace Tasler.ComponentModel
{
	public static class NotifyCollectionChangedExtensions
	{
		#region Event Raising Extension Methods

		public static bool RaiseReset(this NotifyCollectionChangedEventHandler handler, object sender)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			return true;
		}

		public static bool RaiseReset(this NotifyCollectionChangedEventHandler handler, object sender, object changedItem)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, changedItem));
			return true;
		}

		public static bool RaiseReset(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, changedItems));
			return true;
		}

		public static bool RaiseReset(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems, int startingIndex)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, changedItems, startingIndex));
			return true;
		}

		public static bool RaiseAdd(this NotifyCollectionChangedEventHandler handler, object sender, object changedItem)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItem));
			return true;
		}

		public static bool RaiseAdd(this NotifyCollectionChangedEventHandler handler, object sender, object changedItem, int index)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItem, index));
			return true;
		}

		public static bool RaiseAdd(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItems));
			return true;
		}

		public static bool RaiseAdd(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems, int startingIndex)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItems, startingIndex));
			return true;
		}

		public static bool RaiseRemove(this NotifyCollectionChangedEventHandler handler, object sender, object changedItem)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, changedItem));
			return true;
		}

		public static bool RaiseRemove(this NotifyCollectionChangedEventHandler handler, object sender, object changedItem, int index)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, changedItem, index));
			return true;
		}

		public static bool RaiseRemove(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, changedItems));
			return true;
		}

		public static bool RaiseRemove(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems, int startingIndex)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, changedItems, startingIndex));
			return true;
		}

		public static bool RaiseReplace(this NotifyCollectionChangedEventHandler handler, object sender, object newItem, object oldItem)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItem, oldItem));
			return true;
		}

		public static bool RaiseReplace(this NotifyCollectionChangedEventHandler handler, object sender, object newItem, object oldItem, int index)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItem, oldItem, index));
			return true;
		}

		public static bool RaiseReplace(this NotifyCollectionChangedEventHandler handler, object sender, IList newItems, IList oldItems)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItems, oldItems));
			return true;
		}

		public static bool RaiseReplace(this NotifyCollectionChangedEventHandler handler, object sender, IList newItems, IList oldItems, int startingIndex)
		{
			if (handler == null)
				return false;

			handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItems, oldItems, startingIndex));
			return true;
		}

		#endregion Event Raising Extension Methods

		#region Translating Collection Creation

		public static ObservableCollection<TResultItem>
		CreateTranslatingCollection<TSourceCollection, TSourceItem, TResultItem>(
			this INotifyCollectionChanged sourceCollection,
			Func<TSourceItem, TResultItem> translationSelector
			)
			where TSourceCollection : class, INotifyCollectionChanged, IEnumerable
			where TSourceItem : class
			where TResultItem : class
		{
			if (sourceCollection == null)
				return null;

			ValidateArgument.IsNotNull(translationSelector, nameof(translationSelector));

			// Strong-type and count the sourceCollection items
			var translatedItemsMap = new Dictionary<WeakReference<TSourceItem>, WeakReference<TResultItem>>();
			var sourceEnumerable = (sourceCollection as IEnumerable).OfType<TSourceItem>();
			var sourceItemCount = sourceEnumerable.Count();

			// Translate each source item and maintain a map of source items to result items
			var index = 0;
			var translatedItems = new TResultItem[sourceItemCount];
			foreach (var sourceItem in sourceEnumerable)
			{
				var translatedItem = translationSelector(sourceItem);
				translatedItemsMap[new WeakReference<TSourceItem>(sourceItem)] = new WeakReference<TResultItem>(translatedItem);
				translatedItems[index++] = translatedItem;
			}

			// Create the result collection and monitor the source collection for changes
			var resultCollection = new ObservableCollection<TResultItem>(translatedItems);
			sourceCollection.CollectionChanged += (s, e) =>
			{
				// Add translations of the new items
				foreach (var sourceItem in e.NewItems.OfType<TSourceItem>())
				{
					var sourceItemRef = new WeakReference<TSourceItem>(sourceItem);
					if (!translatedItemsMap.TryGetValue(sourceItemRef, out var translatedItemRef) ||
						!translatedItemRef.TryGetTarget(out var translatedItem) ||
						translatedItem == null)
					{
						translatedItem = translationSelector(sourceItem);
						translatedItemRef = new WeakReference<TResultItem>(translatedItem);
						translatedItemsMap[new WeakReference<TSourceItem>(sourceItem)] = translatedItemRef;
					}

					if (e.Action == NotifyCollectionChangedAction.Add)
					{
						resultCollection.Add(translatedItem);
					}
					else if (e.Action == NotifyCollectionChangedAction.Replace)
					{
						resultCollection[e.NewStartingIndex] = translatedItem;
					}
					else if (e.Action == NotifyCollectionChangedAction.Move)
					{
						resultCollection.RemoveAt(e.OldStartingIndex);
						resultCollection.Insert(e.NewStartingIndex, translatedItem);
					}
				}

				// Remove translations of the new items
				foreach (var sourceItem in e.OldItems.OfType<TSourceItem>())
				{
					var sourceItemRef = new WeakReference<TSourceItem>(sourceItem);
					if (translatedItemsMap.TryGetValue(sourceItemRef, out var translatedItemRef) &&
						translatedItemRef.TryGetTarget(out var translatedItem) &&
						translatedItem != default(TResultItem))
					{
						resultCollection.Remove(translatedItem);
					}
				}

				// Handle the Reset action
				if (e.Action == NotifyCollectionChangedAction.Reset)
				{
					// Strong-type and count the sourceCollection items
					var newSourceEnumerable = (sourceCollection as IEnumerable).OfType<TSourceItem>();
					var newSourceItemCount = newSourceEnumerable.Count();

					// Rebuild the resultCollection
					var resultIndex = 0;
					var resultItems = new TResultItem[newSourceItemCount];
					foreach (var sourceItem in newSourceEnumerable)
					{
						var sourceItemRef = new WeakReference<TSourceItem>(sourceItem);
						if (!translatedItemsMap.TryGetValue(sourceItemRef, out var translatedItemRef) ||
							!translatedItemRef.TryGetTarget(out var translatedItem) ||
							translatedItem == default(TResultItem))
						{
							translatedItem = translationSelector(sourceItem);
							translatedItemRef = new WeakReference<TResultItem>(translatedItem);
							translatedItemsMap[new WeakReference<TSourceItem>(sourceItem)] = translatedItemRef;
						}
						translatedItems[index++] = translatedItem;
					}

					// Clear the resultCollection and add the new result items
					resultCollection.Clear();
					for (resultIndex = 0; resultIndex < translatedItems.Length; ++resultIndex)
						resultCollection[resultIndex] = translatedItems[resultIndex];
				}
			};

			return resultCollection;
		}

		#region Private Implementation

		private static ICollectionTranslator<TResultItem>
		CreateCollectionTranslator<TSourceObject, TSourceCollection, TSourceItem, TResultItem>(
			this INotifyPropertyChanged sourceObject,
			Expression<Func<TSourceObject, TSourceCollection>> sourcePropertySelectorExpression,
			Func<TSourceItem, TResultItem> translationSelector
			)
			where TSourceObject : class, INotifyPropertyChanged
			where TSourceCollection : class, INotifyCollectionChanged, IEnumerable
			where TSourceItem : class
			where TResultItem : class
		{
			var collectionTranslator =
				new CollectionTranslator<TSourceObject, TSourceCollection, TSourceItem, TResultItem>(
					sourceObject, sourcePropertySelectorExpression, translationSelector);

			return collectionTranslator;
		}

		#region Nested Types

		private interface ICollectionTranslator<TResultItem>
		{
			ObservableCollection<TResultItem> Collection { get; }
		}

		private class CollectionTranslator<TSourceObject, TSourceCollection, TSourceItem, TResultItem>
			: ICollectionTranslator<TResultItem>
			where TSourceObject : class, INotifyPropertyChanged
			where TSourceCollection : class, INotifyCollectionChanged, IEnumerable
			where TSourceItem : class
			where TResultItem : class
		{
			private IPropertyObserverItem _collectionPropertyObserverItem;

			public CollectionTranslator(
				INotifyPropertyChanged sourceObject,
				Expression<Func<TSourceObject, TSourceCollection>> sourcePropertySelectorExpression,
				Func<TSourceItem, TResultItem> translationSelector
				)
			{
				ValidateArgument.IsNotNull(sourceObject, nameof(sourceObject));
				ValidateArgument.IsNotNull(sourcePropertySelectorExpression, nameof(sourcePropertySelectorExpression));
				ValidateArgument.IsNotNull(translationSelector, nameof(translationSelector));

				var propertyName = PropertySupport.ExtractPropertyName(sourcePropertySelectorExpression);
				_collectionPropertyObserverItem = ((TSourceObject)sourceObject).Subscribe(propertyName, source =>
				{
					// Compile the expression to a delegate and evaluate it
					var func = sourcePropertySelectorExpression.Compile();
					var sourceCollection = func((TSourceObject)sourceObject);

					// Create the translating collection from the changed sourceCollection value
					this.Collection = sourceCollection.CreateTranslatingCollection<TSourceCollection, TSourceItem, TResultItem>(translationSelector);
				});

				_collectionPropertyObserverItem.Refresh();
			}

			public ObservableCollection<TResultItem> Collection { get; private set; }
		}

		#endregion Nested Types

		#endregion Private Implementation

		#endregion Translating Collection Creation
	}
}
