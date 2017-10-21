using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Microsoft.IoT.Cortana.SampleDeviceApp
{
	public static class NotifyPropertyChangedExtensions
	{
		public static bool SetProperty<TSender, TValue>(this PropertyChangedEventHandler @this, TSender sender, ref TValue field, TValue newValue, [CallerMemberName] string propertyName = null)
			where TSender : INotifyPropertyChanged
		{
			var propertyChanged = !object.Equals(field, newValue);
			if (propertyChanged)
			{
				field = newValue;
				@this.RaisePropertyChanged(sender, propertyName);
			}
			return propertyChanged;
		}

		public static bool SetProperty<TSender, TValue>(this PropertyChangedEventHandler @this, TSender sender, ref TValue field, TValue newValue, params string[] propertyNames)
			where TSender : INotifyPropertyChanged
		{
			var propertyChanged = !object.Equals(field, newValue);
			if (propertyChanged)
			{
				field = newValue;
				@this.RaisePropertyChanged(sender, propertyNames);
			}
			return propertyChanged;
		}

		public static void RaisePropertyChanged<T>(this PropertyChangedEventHandler @this, T sender, string propertyName)
			where T : INotifyPropertyChanged
		{
			if (@this != null && propertyName != null)
			{
				@this.Invoke(sender, new PropertyChangedEventArgs(propertyName));
			}
		}

		public static void RaisePropertyChanged<T>(this PropertyChangedEventHandler @this, T sender, params string[] propertyNames)
			where T : INotifyPropertyChanged
		{
			if (@this != null && propertyNames != null)
			{
				var length = propertyNames.Length;
				for (var index = 0; index < length; ++index)
				{
					var propertyName = propertyNames[index];
					@this.Invoke(sender, new PropertyChangedEventArgs(propertyName));
				}
			}
		}
	}
}
