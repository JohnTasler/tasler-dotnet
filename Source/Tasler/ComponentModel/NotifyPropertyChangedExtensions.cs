using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tasler.ComponentModel
{
	public static class NotifyPropertyChangedExtensions
	{
		public static bool SetProperty<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, [CallerMemberName] string propertyName = null)
		{
			return @this.SetProperty(sender, newValue, ref valueField, out TValue oldValue, propertyName);
		}

		public static bool SetProperty<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, params string[] propertyNames)
		{
			return @this.SetProperty(sender, newValue, ref valueField, out TValue oldValue, propertyNames);
		}

		public static bool SetProperty<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, out TValue oldValue, [CallerMemberName] string propertyName = null)
		{
			var propertyChanged = @this.SetPropertyNoRaise(sender, newValue, ref valueField, out oldValue);
			if (propertyChanged)
			{
				@this.RaisePropertyChanged(sender, propertyName);
			}
			return propertyChanged;
		}

		public static bool SetProperty<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, out TValue oldValue, params string[] propertyNames)
		{
			var propertyChanged = @this.SetPropertyNoRaise(sender, newValue, ref valueField, out oldValue);
			if (propertyChanged)
			{
				@this.RaisePropertyChanged(sender, propertyNames);
			}
			return propertyChanged;
		}

		public static bool SetPropertyNoRaise<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField)
		{
			return @this.SetPropertyNoRaise(sender, newValue, ref valueField, out TValue oldValue);
		}

		public static bool SetPropertyNoRaise<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, out TValue oldValue)
		{
			oldValue = valueField;

			var propertyChanged = !object.Equals(valueField, newValue);
			if (propertyChanged)
			{
				valueField = newValue;
			}

			return propertyChanged;
		}

		public static IDisposable SetPropertyScopeRaise<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, [CallerMemberName] string propertyName = null)
		{
			return @this.SetPropertyScopeRaise(sender, newValue, ref valueField, out TValue oldValue, propertyName);
		}

		public static IDisposable SetPropertyScopeRaise<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, params string[] propertyNames)
		{
			return @this.SetPropertyScopeRaise(sender, newValue, ref valueField, out TValue oldValue, propertyNames);
		}

		public static IDisposable SetPropertyScopeRaise<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, out TValue oldValue, [CallerMemberName] string propertyName = null)
		{
			return @this.SetPropertyNoRaise(sender, newValue, ref valueField, out oldValue)
				? new RaiseScope(@this, sender, propertyName)
				: null;
		}

		public static IDisposable SetPropertyScopeRaise<TValue>(this PropertyChangedEventHandler @this,
			INotifyPropertyChanged sender, TValue newValue, ref TValue valueField, out TValue oldValue, params string[] propertyNames)
		{
			return @this.SetPropertyNoRaise(sender, newValue, ref valueField, out oldValue)
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
			private string _propertyName;
			private string[] _propertyNames;

			private RaiseScope(PropertyChangedEventHandler handler, INotifyPropertyChanged sender)
			{
				_handler = handler;
				_sender = sender;
			}

			public RaiseScope(PropertyChangedEventHandler handler, INotifyPropertyChanged sender, string propertyName)
				: this(handler, sender)
			{
				_propertyName = propertyName;
			}

			public RaiseScope(PropertyChangedEventHandler handler, INotifyPropertyChanged sender, string[] propertyNames)
				: this(handler, sender)
			{
				_propertyNames = propertyNames;
			}

			void IDisposable.Dispose()
			{
				if (_propertyName != null)
				{
					_handler.RaisePropertyChanged(_sender, _propertyName);
				}
				if (_propertyNames != null)
				{
					_handler.RaisePropertyChanged(_sender, _propertyNames);
				}
			}
		}
	}
}
