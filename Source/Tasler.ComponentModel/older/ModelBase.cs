using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tasler.ComponentModel
{
	/// <summary>
	/// A common, lightweight implementation of <see cref="INotifyPropertyChanged"/> and an explicit
	/// implementation of <see cref="IRaisePropertyChanged"/>.
	/// </summary>
	/// <remarks>
	/// <para>This object explicitly implements the <see cref="IRaisePropertyChanged"/> interface for sole use with the
	/// extension methods defined in the <see cref="RaisePropertyChangedExtensions"/>
	/// class.</para>
	/// <para>Even though this class is named <see cref="ModelBase"/>, it can just as well be used as a lightweight base
	/// class for View Models.
	/// </para>
	/// </remarks>

#if !SILVERLIGHT	
	[Serializable]
#endif // !SILVERLIGHT
	public abstract class ModelBase : INotifyPropertyChanged, IRaisePropertyChanged
	{
		#region INotifyPropertyChanged Members

		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged
		{
			add { this.propertyChangedHandler += value; }
			remove { this.propertyChangedHandler -= value; }
		}
		private PropertyChangedEventHandler propertyChangedHandler;

		#endregion INotifyPropertyChanged Members

		#region IRaisePropertyChanged Members

		/// <summary>
		/// Raises the property changed event for a single property.
		/// </summary>
		/// <param name="propertyName">The name of the property that has changed.</param>
		/// <returns><c>true</c> if the <see cref="INotifyPropertyChanged.PropertyChanged"/> event has
		/// any subscribers; <c>false</c> if the event has no subscribers. <c>true</c> should also be
		/// returned in the case that the base implementation does not provide such data.
		/// </returns>
		bool IRaisePropertyChanged.RaisePropertyChanged(string propertyName)
		{
			var hasHandler = propertyChangedHandler != null;
			if (hasHandler)
				propertyChangedHandler(this, new PropertyChangedEventArgs(propertyName));

			return hasHandler;
		}

		/// <summary>
		/// Raises the property changed event for multiple properties.
		/// </summary>
		/// <param name="propertyNames">The names of the properties that have changed.</param>
		/// <returns><c>true</c> if the <see cref="INotifyPropertyChanged.PropertyChanged"/> event has
		/// any subscribers; <c>false</c> if the event has no subscribers. <c>true</c> should also be
		/// returned in the case that the base implementation does not provide such data.
		/// </returns>
		bool IRaisePropertyChanged.RaisePropertyChanged(IEnumerable<string> propertyNames)
		{
			if (propertyNames != null)
			{
				var hasHandler = this.propertyChangedHandler != null;
				if (hasHandler)
				{
					foreach (var propertyName in propertyNames)
						this.propertyChangedHandler(this, new PropertyChangedEventArgs(propertyName));
				}

				return hasHandler;
			}

			return false;
		}

		#endregion IRaisePropertyChanged Members
	}
}
