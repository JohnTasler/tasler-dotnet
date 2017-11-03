using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Microsoft.IoT.Cortana.SampleDeviceApp
{
	public static class NotifyPropertyChangedExtensions
	{
		public static bool SetProperty<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, [CallerMemberName] string propertyName = null)
		{
			var propertyChanged = !object.Equals(valueField, newValue);
			if (propertyChanged)
			{
				valueField = newValue;
				@this.RaisePropertyChanged(sender, propertyName);
			}
			return propertyChanged;
		}

		public static bool SetProperty<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, params string[] propertyNames)
		{
			var propertyChanged = !object.Equals(valueField, newValue);
			if (propertyChanged)
			{
				valueField = newValue;
				@this.RaisePropertyChanged(sender, propertyNames);
			}
			return propertyChanged;
		}

		public static bool SetProperty<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, out TValue oldValue, [CallerMemberName] string propertyName = null)
		{
			var propertyChanged = !object.Equals(valueField, newValue);
			if (propertyChanged)
			{
				oldValue = valueField;
				valueField = newValue;
				@this.RaisePropertyChanged(sender, propertyName);
			}
			else
			{
				oldValue = default(TValue);
			}

			return propertyChanged;
		}

		public static bool SetProperty<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, out TValue oldValue, params string[] propertyNames)
		{
			var propertyChanged = !object.Equals(valueField, newValue);
			if (propertyChanged)
			{
				oldValue = valueField;
				valueField = newValue;
				@this.RaisePropertyChanged(sender, propertyNames);
			}
			else
			{
				oldValue = default(TValue);
			}

			return propertyChanged;
		}

		public static bool SetPropertyNoRaise<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField)
		{
			var propertyChanged = !object.Equals(valueField, newValue);
			if (propertyChanged)
			{
				valueField = newValue;
			}

			return propertyChanged;
		}

		public static bool SetPropertyNoRaise<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, out TValue oldValue)
		{
			var propertyChanged = !object.Equals(valueField, newValue);
			if (propertyChanged)
			{
				oldValue = valueField;
				valueField = newValue;
			}
			else
			{
				oldValue = default(TValue);
			}

			return propertyChanged;
		}

		public static IDisposable SetPropertyScopeRaise<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, [CallerMemberName] string propertyName = null)
		{
			var propertyChanged = !object.Equals(valueField, newValue);
			if (propertyChanged)
			{
				valueField = newValue;
			}

			return propertyChanged
				? new RaiseScope(@this, sender, propertyName)
				: null;
		}

		public static IDisposable SetPropertyScopeRaise<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, params string[] propertyNames)
		{
			var propertyChanged = !object.Equals(valueField, newValue);
			if (propertyChanged)
			{
				valueField = newValue;
			}

			return propertyChanged
				? new RaiseScope(@this, sender, propertyNames)
				: null;
		}

		public static IDisposable SetPropertyScopeRaise<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, out TValue oldValue, [CallerMemberName] string propertyName = null)
		{
			var propertyChanged = !object.Equals(valueField, newValue);
			if (propertyChanged)
			{
				oldValue = valueField;
				valueField = newValue;
			}
			else
			{
				oldValue = default(TValue);
			}

			return propertyChanged
				? new RaiseScope(@this, sender, propertyName)
				: null;
		}

		public static IDisposable SetPropertyScopeRaise<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, out TValue oldValue, params string[] propertyNames)
		{
			var propertyChanged = !object.Equals(valueField, newValue);
			if (propertyChanged)
			{
				oldValue = valueField;
				valueField = newValue;
			}
			else
			{
				oldValue = default(TValue);
			}

			return propertyChanged
				? new RaiseScope(@this, sender, propertyNames)
				: null;
		}

		public static void RaisePropertyChanged(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, string propertyName)
		{
			if (@this != null && propertyName != null)
			{
				@this.Invoke(sender, new PropertyChangedEventArgs(propertyName));
			}
		}

		public static void RaisePropertyChanged(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, params string[] propertyNames)
		{
			if (@this != null && propertyNames != null)
			{
				var length = propertyNames.Length;
				for (var index = 0; index < length; ++index)
				{
					@this.Invoke(sender, new PropertyChangedEventArgs(propertyNames[index]));
				}
			}
		}

		private class RaiseScope : IDisposable
		{
			private PropertyChangedEventHandler _handler;
			private INotifyPropertyChanged _sender;
			private string[] _propertyNames;

			public RaiseScope(PropertyChangedEventHandler handler, INotifyPropertyChanged sender, string propertyName)
				: this(handler, sender, new[] { propertyName })
			{
			}

			public RaiseScope(PropertyChangedEventHandler handler, INotifyPropertyChanged sender, string[] propertyNames)
			{
				_handler = handler;
				_sender = sender;
				_propertyNames = propertyNames;
			}

			void IDisposable.Dispose()
			{
				_handler.RaisePropertyChanged(_sender, _propertyNames);
			}
		}
	}
}
