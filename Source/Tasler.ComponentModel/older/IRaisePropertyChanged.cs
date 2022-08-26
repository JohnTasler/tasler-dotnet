using System.Collections.Generic;
using System.ComponentModel;

namespace Tasler.ComponentModel
{
	/// <summary>
	/// Provides a way for extension methods in (see <see cref="RaisePropertyChangedExtensions"/>) to raise
	/// property change notifications from an object.
	/// </summary>
	public interface IRaisePropertyChanged : INotifyPropertyChanged
	{
		/// <summary>
		/// Raises the property changed event for a single property.
		/// </summary>
		/// <param name="propertyName">The name of the property that has changed.</param>
		/// <returns><c>true</c> if the <see cref="INotifyPropertyChanged.PropertyChanged"/> event has
		/// any subscribers; <c>false</c> if the event has no subscribers. <c>true</c> should also be
		/// returned in the case that the base implementation does not provide such data.
		/// </returns>
		bool RaisePropertyChanged(string propertyName);

		/// <summary>
		/// Raises the property changed event for a multiple properties.
		/// </summary>
		/// <param name="propertyNames">The names of the properties that have changed.</param>
		/// <returns><c>true</c> if the <see cref="INotifyPropertyChanged.PropertyChanged"/> event has
		/// any subscribers; <c>false</c> if the event has no subscribers. <c>true</c> should also be
		/// returned in the case that the base implementation does not provide such data.
		/// </returns>
		bool RaisePropertyChanged(IEnumerable<string> propertyNames);
	}
}
