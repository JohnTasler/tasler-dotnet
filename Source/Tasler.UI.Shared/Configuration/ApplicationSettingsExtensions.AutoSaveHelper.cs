using System.ComponentModel;
using System.Configuration;
using Tasler.Windows.Threading;

namespace Tasler.Configuration;

public static partial class ApplicationSettingsExtensions
{
	/// <summary>
	/// A class that monitors an instance of <see cref="ApplicationSettingsBase"/> for property changes,
	/// and automatically saves the settings after a period of time after the most recent change.
	/// </summary>
	/// <remarks>
	/// If a property value of the settings is an object that supports the <see cref="INotifyPropertyChange"/> interface,
	/// property change notifications will also trigger the settings to auto-save. If, however, the properties on such an
	/// object are also objects that support <see cref="INotifyPropertyChange"/>, the
	/// <see cref="AutoSaveHelper"/> does not monitor them for property changes. In other words, only property
	/// changes one level deep will trigger the settings to auto-save.
	/// </remarks>
	private class AutoSaveHelper : IDisposable
	{
		#region Constructor / Finalizer
		/// <summary>
		/// Initializes a new instance of the <see cref="AutoSaveHelper"/> class to monitor the
		/// specified settings and automatically save changes after a deferral period.
		/// </summary>
		/// <param name="settings">The application settings instance to monitor for changes.</param>
		/// <param name="deferralTimeSpan">The time to wait after a change before saving the settings.</param>
		internal AutoSaveHelper(ApplicationSettingsBase settings, TimeSpan deferralTimeSpan)
		{
			// Save the specified settings and subscribe to some of its events
			this.Settings = settings;
			this.Settings.SettingsLoaded += this.Settings_OnSettingsLoaded;
			this.Settings.PropertyChanged += this.Settings_OnPropertyChanged;

			// Create a DeferredAction with the specified deferral time
			this.DeferredAction = new DispatcherTimerDeferredAction(deferralTimeSpan, this.Settings.Save);
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="AutoSaveHelper"/> is reclaimed by garbage collection.
		/// </summary>
		~AutoSaveHelper()
		{
			((IDisposable)this).Dispose();
		}
		#endregion Constructor / Finalizer

		#region Properties
		internal bool IsDisposed
		{
			get { return this.DeferredAction is null || this.Settings is null; }
		}
		#endregion Properties

		#region Methods
		internal void Expire()
		{
			// Expire the deferred action
			this.DeferredAction?.Expire();
		}

		internal void Expire(TimeSpan deferralTimeSpan)
		{
			// Expire the deferred action
			this.Expire();

			// Create a new DeferredAction if the specified deferral time has changed
			if (this.DeferredAction?.Interval != deferralTimeSpan && this.Settings is not null)
				this.DeferredAction = new DispatcherTimerDeferredAction(deferralTimeSpan, this.Settings.Save);
		}
		#endregion

		#region IDisposable Members
		void IDisposable.Dispose()
		{
			using (this.DeferredAction)
			{
				this.DeferredAction = null;
				this.Settings = null;
				GC.SuppressFinalize(this);
			}
		}
		#endregion IDisposable Members

		#region Private Properties
		private DispatcherTimerDeferredAction? DeferredAction { get; set; }
		private ApplicationSettingsBase? Settings { get; set; }
		#endregion Private Properties

		#region Private Methods
		private void ItemPropertyChanged(string itemName)
		{
			// Get the specified property value object
			var propertyValue = this.Settings?.PropertyValues[itemName];

			// Set its value to itself, thus marking it as needing to be saved
			// NOTE: Simply setting the IsDirty on the property value is insufficient.
			if (propertyValue is not null)
				propertyValue.PropertyValue = propertyValue.PropertyValue;

			// Trigger the deferred action to save the settings
			this.DeferredAction?.Trigger();
		}
		#endregion Private Methods

		#region Event Handlers
		/// <summary>
		/// Handles the <see cref="ApplicationSettingsBase.SettingsLoaded"/> event.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">A <see cref="SettingsLoadedEventArgs"/> that contains the event data.</param>
		private void Settings_OnSettingsLoaded(object sender, SettingsLoadedEventArgs e)
		{
			if (this.Settings is null)
				return;

			// Loop through each property item
			foreach (SettingsPropertyValue propertyValue in this.Settings.PropertyValues)
			{
				// Check for the INotifyPropertyChanged interface
				var notifyPropertyChanged = propertyValue.PropertyValue as INotifyPropertyChanged;

				// Subscribe to the PropertyChanged event
				if (notifyPropertyChanged is not null)
					notifyPropertyChanged.PropertyChanged += (s, ve) => this.ItemPropertyChanged(propertyValue.Name);
			}
		}

		/// <summary>
		/// Handles the <see cref="ApplicationSettingsBase.PropertyChanged"/> event.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">A <see cref="PropertyChangedEventArgs"/> that contains the event data.</param>
		private void Settings_OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			// Check for the INotifyPropertyChanged interface
			if (this.Settings?[e.PropertyName] is INotifyPropertyChanged notifyPropertyChanged)
			{
				// Re-subscribe to the PropertyChanged event
				notifyPropertyChanged.PropertyChanged -= (s, ve) => this.ItemPropertyChanged(e.PropertyName!);
				notifyPropertyChanged.PropertyChanged += (s, ve) => this.ItemPropertyChanged(e.PropertyName!);
			}

			// Trigger the deferred action to save the settings
			this.DeferredAction?.Trigger();
		}
		#endregion Event Handlers
	}
}
