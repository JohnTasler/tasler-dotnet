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
	/// <summary>
	/// Provides a set of extension methods for objects implementing the <see cref="IParentedObject"/> interface.
	/// </summary>
	public static class NotifyCollectionChangedExtensions
	{
		public static ObservableCollection<TResultItem>
		CreateTranslatingCollection<TSourceCollection, TSourceItem, TResultItem>(
			this INotifyCollectionChanged sourceCollection,
			Func<TSourceItem, TResultItem> translationSelector
			)
			where TSourceCollection : class, INotifyCollectionChanged, IEnumerable
			where TResultItem : class
		{
			if (sourceCollection == null)
				return null;

			if (translationSelector == null)
				throw new ArgumentNullException("translationSelector");

			// Strong-type and count the sourceCollection items
			var translatedItemsMap = new Dictionary<WeakReference, WeakReference>();
			var sourceEnumerable = (sourceCollection as IEnumerable).OfType<TSourceItem>();
			var sourceItemCount = sourceEnumerable.Count();

			// Translate each source item and maintain a map of source items to result items
			var index = 0;
			var translatedItems = new TResultItem[sourceItemCount];
			foreach (var sourceItem in sourceEnumerable)
			{
				var translatedItem = translationSelector(sourceItem);
				translatedItemsMap[new WeakReference(sourceItem)] = new WeakReference(translatedItem);
				translatedItems[index++] = translatedItem;
			}

			// Create the result collection and monitor the source collection for changes
			var resultCollection = new ObservableCollection<TResultItem>(translatedItems);
			sourceCollection.CollectionChanged += (s, e) =>
			{
				// Add translations of the new items
				foreach (var sourceItem in e.NewItems.OfType<TSourceItem>())
				{
					var sourceItemRef = new WeakReference(sourceItem);
					var translatedItem = default(TResultItem);
					var translatedItemRef = (WeakReference)null;
					if (!translatedItemsMap.TryGetValue(sourceItemRef, out translatedItemRef) || (translatedItem = (TResultItem)translatedItemRef.Target) == null)
					{
						translatedItem = translationSelector(sourceItem);
						translatedItemRef = new WeakReference(translatedItem);
						translatedItemsMap[new WeakReference(sourceItem)] = new WeakReference(translatedItem);
					}

					if (e.Action == NotifyCollectionChangedAction.Add)
					{
						resultCollection.Add(translatedItem);
					}
					else if (e.Action == NotifyCollectionChangedAction.Replace)
					{
						resultCollection[e.NewStartingIndex] = translatedItem;
					}
#if !SILVERLIGHT
					else if (e.Action == NotifyCollectionChangedAction.Move)
					{
						resultCollection.RemoveAt(e.OldStartingIndex);
						resultCollection.Insert(e.NewStartingIndex, translatedItem);
					}
#endif // !SILVERLIGHT
				}

				// Remove translations of the new items
				foreach (var sourceItem in e.OldItems.OfType<TSourceItem>())
				{
					var sourceItemRef = new WeakReference(sourceItem);
					var translatedItem = default(TResultItem);
					var translatedItemRef = (WeakReference)null;
					if (translatedItemsMap.TryGetValue(sourceItemRef, out translatedItemRef) && (translatedItem = (TResultItem)translatedItemRef.Target) != null)
						resultCollection.Remove(translatedItem);
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
						var sourceItemRef = new WeakReference(sourceItem);
						var translatedItem = default(TResultItem);
						var translatedItemRef = (WeakReference)null;
						if (!translatedItemsMap.TryGetValue(sourceItemRef, out translatedItemRef) || (translatedItem = (TResultItem)translatedItemRef.Target) == null)
						{
							translatedItem = translationSelector(sourceItem);
							translatedItemRef = new WeakReference(translatedItem);
							translatedItemsMap[new WeakReference(sourceItem)] = new WeakReference(translatedItem);
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

		public static ICollectionTranslator<TResultItem>
		CreateCollectionTranslator<TSourceObject, TSourceCollection, TSourceItem, TResultItem>(
			this INotifyPropertyChanged sourceObject,
			Expression<Func<TSourceObject, TSourceCollection>> sourcePropertyExpression,
			Func<TSourceItem, TResultItem> translationSelector
			)
			where TSourceCollection : class, INotifyCollectionChanged, IEnumerable
			where TSourceObject : class, INotifyPropertyChanged
			where TResultItem : class
		{
			var collectionTranslator =
				new CollectionTranslator<TSourceObject, TSourceCollection, TSourceItem, TResultItem>(
					sourceObject, sourcePropertyExpression, translationSelector);

			return collectionTranslator;
		}
	}

	public interface ICollectionTranslator<TResultItem>
	{
		ObservableCollection<TResultItem> Collection { get; }
	}

	public class CollectionTranslator<TSourceObject, TSourceCollection, TSourceItem, TResultItem>
		: ICollectionTranslator<TResultItem>
		where TSourceCollection : class, INotifyCollectionChanged, IEnumerable
		where TSourceObject : class, INotifyPropertyChanged
		where TResultItem : class
	{
		private IPropertyObserverItem collectionPropertyObserverItem;

		internal CollectionTranslator(
			INotifyPropertyChanged sourceObject,
			Expression<Func<TSourceObject, TSourceCollection>> sourcePropertyExpression,
			Func<TSourceItem, TResultItem> translationSelector
			)
		{
			if (sourceObject == null)
				throw new ArgumentNullException("sourceObject");
			if (sourcePropertyExpression == null)
				throw new ArgumentNullException("sourcePropertyExpression");
			if (translationSelector == null)
				throw new ArgumentNullException("translationSelector");

			this.collectionPropertyObserverItem = ((TSourceObject)sourceObject).Subscribe(sourcePropertyExpression, source =>
			{
				// Compile the expression to a delegate and evaluate it
				var func = sourcePropertyExpression.Compile();
				var sourceCollection = func((TSourceObject)sourceObject);

				// Create the translating collection from the changed sourceCollection value
				this.Collection = sourceCollection.CreateTranslatingCollection<TSourceCollection, TSourceItem, TResultItem>(translationSelector);
			});

			this.collectionPropertyObserverItem.Refresh();
		}

		public ObservableCollection<TResultItem> Collection { get; private set; }
	}
}
