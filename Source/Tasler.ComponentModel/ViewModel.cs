using System.ComponentModel;

namespace Tasler.ComponentModel
{
	public abstract class ViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// Raised when a property on this object has a new value.
		/// </summary>
		event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
		{
			add { this.PropertyChanged += value; }
			remove { this.PropertyChanged -= value; }
		}

		protected PropertyChangedEventHandler PropertyChanged { get; private set; }
	}
}

