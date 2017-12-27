using System;
using System.ComponentModel;

namespace Tasler.ComponentModel
{
	/// <summary>
	/// Provides extension methods used to observe changes to a single property of an object
	/// supporting the <see cref="INotifyPropertyChanged"/> interface.
	/// </summary>
	public static class PropertyObserver
	{
		#region Methods
		///// <summary>
		///// Subscribes to property change notifications on the <paramref name="source"/>.
		///// </summary>
		///// <typeparam name="T">A class implementing the <see cref="INotifyPropertyChanged"/> interface.</typeparam>
		///// <param name="source">The source object on which to observe property changes.</param>
		///// <param name="propertyExpression">The lambda expression from which the property name is extracted.</param>
		///// <param name="handlerAction">The action to be called when the <paramref name="source"/> object raises the
		///// <see cref="INotifyPropertyChanged.PropertyChanged"/> event that indicates either the property whose name is
		///// specified by the <paramref name="propertyExpression"/>, or one of <c>null</c>, <see cref="String.Empty"/>, or a
		///// <see cref="String"/> containing only whitespace. Any of the latter three can be indicated when "all properties"
		///// should be refreshed.</param>
		///// <returns>
		///// An <see cref="IPropertyObserverItem"/> that can be used to <see cref="IPropertyObserverItem.Unsubscribe"/>
		///// from the notifications, and <see cref="IPropertyObserverItem.Refresh"/> the notification callback.
		///// </returns>
		//public static IPropertyObserverItem Subscribe<TSource, TProperty>(
		//	this TSource source,
		//	Expression<Func<TSource, TProperty>> propertyExpression,
		//	Action<TSource> handlerAction)
		//	where TSource : class, INotifyPropertyChanged
		//{
		//	return source.Subscribe(PropertySupport.ExtractPropertyName(propertyExpression), s => handlerAction((TSource)s));
		//}

		///// <summary>
		///// Subscribes to property change notifications on the <paramref name="source"/>.
		///// </summary>
		///// <typeparam name="TSource">A class implementing the <see cref="INotifyPropertyChanged"/> interface.</typeparam>
		///// <param name="source">The source object on which to observe property changes.</param>
		///// <param name="propertyExpression">The lambda expression from which the property name is extracted.</param>
		///// <param name="eventHandler">The event handler to be called when the <paramref name="source"/> object raises the
		///// <see cref="INotifyPropertyChanged.PropertyChanged"/> event that indicates either the property whose name is
		///// specified by the <paramref name="propertyExpression"/>, or one of <c>null</c>, <see cref="String.Empty"/>, or a
		///// <see cref="String"/> containing only whitespace. Any of the latter three can be indicated when "all properties"
		///// should be refreshed.</param>
		///// <returns>
		///// An <see cref="IPropertyObserverItem"/> that can be used to <see cref="IPropertyObserverItem.Unsubscribe"/>
		///// from the notifications, and <see cref="IPropertyObserverItem.Refresh"/> the notification callback.
		///// </returns>
		//public static IPropertyObserverItem Subscribe<TSource, TProperty>(
		//	this TSource source,
		//	Expression<Func<TSource, TProperty>> propertyExpression,
		//	PropertyChangedEventHandler eventHandler)
		//	where TSource : class, INotifyPropertyChanged
		//{
		//	return source.Subscribe(PropertySupport.ExtractPropertyName(propertyExpression), eventHandler);
		//}

		/// <summary>
		/// Subscribes to property change notifications on the <paramref name="source"/>.
		/// </summary>
		/// <typeparam name="TSource">A class implementing the <see cref="INotifyPropertyChanged"/> interface.</typeparam>
		/// <param name="source">The source object on which to observe property changes.</param>
		/// <param name="propertyName">The property name to observe.</param>
		/// <param name="eventHandler">The event handler to be called when the <paramref name="source"/> object raises the
		/// <see cref="INotifyPropertyChanged.PropertyChanged"/> event that indicates either the property whose name is
		/// specified by the <paramref name="propertyExpression"/>, or one of <c>null</c>, <see cref="String.Empty"/>, or a
		/// <see cref="String"/> containing only whitespace. Any of the latter three can be indicated when "all properties"
		/// should be refreshed.</param>
		/// <returns>
		/// An <see cref="IPropertyObserverItem"/> that can be used to <see cref="IPropertyObserverItem.Unsubscribe"/>
		/// from the notifications, and <see cref="IPropertyObserverItem.Refresh"/> the notification callback.
		/// </returns>
		public static IPropertyObserverItem Subscribe(this INotifyPropertyChanged source, string propertyName, Action<INotifyPropertyChanged> handlerAction)
		{
			var observerItem = new ObserverItem(source, propertyName, handlerAction);
			return observerItem;
		}

		/// <summary>
		/// Subscribes to property change notifications on the <paramref name="source"/>.
		/// </summary>
		/// <typeparam name="T">A class implementing the <see cref="INotifyPropertyChanged"/> interface.</typeparam>
		/// <param name="source">The source object on which to observe property changes.</param>
		/// <param name="propertyName">The property name to observe.</param>
		/// <param name="handlerAction">The action to be called when the <paramref name="source"/> object raises the
		/// <see cref="INotifyPropertyChanged.PropertyChanged"/> event that indicates either the property whose name is
		/// specified by the <paramref name="propertyExpression"/>, or one of <c>null</c>, <see cref="String.Empty"/>, or a
		/// <see cref="String"/> containing only whitespace. Any of the latter three can be indicated when "all properties"
		/// should be refreshed.</param>
		/// <returns>
		/// An <see cref="IPropertyObserverItem"/> that can be used to <see cref="IPropertyObserverItem.Unsubscribe"/>
		/// from the notifications, and <see cref="IPropertyObserverItem.Refresh"/> the notification callback.
		/// </returns>
		public static IPropertyObserverItem Subscribe(this INotifyPropertyChanged source, string propertyName, PropertyChangedEventHandler eventHandler)
		{
			var observerItem = new ObserverItem(source, propertyName, eventHandler);
			return observerItem;
		}

		#endregion Methods

		#region Nested Types
		private class ObserverItem : IPropertyObserverItem
		{
			#region Constructors
			/// <summary>
			/// Initializes a new instance of the <see cref="ObserverItem"/> class.
			/// </summary>
			/// <param name="source">The source.</param>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="handlerAction">The handler action.</param>
			public ObserverItem(INotifyPropertyChanged source, string propertyName, Action<INotifyPropertyChanged> handlerAction)
			{
				this.SourceReference = new WeakReference(source);
				this.PropertyName = propertyName;
				this.HandlerAction = handlerAction;
				this.Subscribe();
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="ObserverItem"/> class.
			/// </summary>
			/// <param name="source">The source.</param>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="eventHandler">The event handler.</param>
			public ObserverItem(INotifyPropertyChanged source, string propertyName, PropertyChangedEventHandler eventHandler)
			{
				this.SourceReference = new WeakReference(source);
				this.PropertyName = propertyName;
				this.EventHandler = eventHandler;
				this.Subscribe();
			}
			#endregion Constructors

			#region IPropertyObserverItem Members
			/// <summary>
			/// Refreshes the observed property notification by executing the subscribed callback.
			/// </summary>
			void IPropertyObserverItem.Refresh()
			{
				var source = this.Source;
				if (source != null)
					this.source_PropertyChanged(source, new PropertyChangedEventArgs(null));
			}

			/// <summary>
			/// Unsubscribes from the observed object.
			/// </summary>
			void IPropertyObserverItem.Unsubscribe()
			{
				if (this.SourceReference != null)
				{
					var source = this.Source;
					if (source != null)
						source.PropertyChanged -= this.source_PropertyChanged;

					this.Clear();
				}
			}
			#endregion IPropertyObserverItem Members

			#region Private Implementation
			private WeakReference SourceReference { get; set; }

			private string PropertyName { get; set; }

			private Action<INotifyPropertyChanged> HandlerAction { get; set; }

			private PropertyChangedEventHandler EventHandler { get; set; }

			private INotifyPropertyChanged Source
			{
				get
				{
					var source = this.SourceReference.Target as INotifyPropertyChanged;
					if (source == null)
						this.Clear();

					return source;
				}
			}

			private void Subscribe()
			{
				var source = this.Source;
				if (source != null)
					source.PropertyChanged += this.source_PropertyChanged;
			}

			private void Clear()
			{
				this.SourceReference = null;
				this.HandlerAction = null;
				this.EventHandler = null;
			}
			#endregion Private Implementation

			#region Event Handlers
			private void source_PropertyChanged(object sender, PropertyChangedEventArgs e)
			{
				if (sender == this.Source && (string.IsNullOrWhiteSpace(e.PropertyName) || e.PropertyName == this.PropertyName))
				{
					if (this.HandlerAction != null)
						this.HandlerAction(sender as INotifyPropertyChanged);

					if (this.EventHandler != null)
						this.EventHandler(sender, e);
				}
			}
			#endregion Event Handlers
		}
		#endregion Nested Types
	}

	/// <summary>
	/// Represents the result of the <see cref="PropertyObserver.Subscribe"/> method.
	/// </summary>
	public interface IPropertyObserverItem
	{
		/// <summary>
		/// Refreshes the observed property notification by executing the subscribed callback.
		/// </summary>
		void Refresh();

		/// <summary>
		/// Unsubscribes from the observed object.
		/// </summary>
		void Unsubscribe();
	}
}
