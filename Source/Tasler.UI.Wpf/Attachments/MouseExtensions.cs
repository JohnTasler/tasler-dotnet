using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Attachments
{
	public static class MouseExtensions
	{
		#region Attached Properties

		#region LeftClickCommand

		/// <summary>
		/// Identifies the <c>LeftClickCommand</c> attached property.
		/// </summary>
		public static readonly DependencyProperty LeftClickCommandProperty =
			DependencyProperty.RegisterAttached("LeftClickCommand", typeof(ICommand), typeof(MouseExtensions),
				new PropertyMetadata(LeftClickCommandPropertyChanged));

		/// <summary>
		/// Gets the command to be executed when the input element captures a left click event.
		/// </summary>
		/// <param name="d">The object for which to get the property value. This must support the
		/// <see cref="IInputElement"/> interface.</param>
		/// <returns>The attached property value. </returns>
		/// <exception cref="ArgumentNullException"><paramref name="d"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="d"/> does not implement the
		/// <see cref="IInputElement"/> interface.</exception>
		public static ICommand GetLeftClickCommand(DependencyObject d)
		{
			ValidateInputElementDependencyObject(d, "LeftClickCommand");
			return (ICommand)d.GetValue(LeftClickCommandProperty);
		}

		/// <summary>
		/// Sets the command to be executed when the input element captures a left click event.
		/// </summary>
		/// <param name="d">The object on which to set the property value. This must support the
		/// <see cref="IInputElement"/> interface.</param>
		/// <param name="value">The new value for the attached property.</param>
		/// <exception cref="ArgumentNullException"><paramref name="d"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="d"/> does not implement the
		/// <see cref="IInputElement"/> interface.</exception>
		public static void SetLeftClickCommand(DependencyObject d, ICommand value)
		{
			ValidateInputElementDependencyObject(d, "LeftClickCommand");
			d.SetValue(LeftClickCommandProperty, value);
		}

		private static void LeftClickCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d != null)
			{
				var oldValue = (ICommand)e.OldValue;
				if (oldValue != null)
				{
					RemoveLeftClickHandler(d, LeftClickCommand_Execute);
					oldValue.CanExecuteChanged -= LeftClickCommand_CanExecute;
				}

				var newValue = (ICommand)e.NewValue;
				if (newValue != null)
				{
					var uiElement = d as UIElement;
					var uiElement3D = d as UIElement3D;
					if (uiElement != null || uiElement3D != null)
						newValue.CanExecuteChanged += LeftClickCommand_CanExecute;
					AddLeftClickHandler(d, LeftClickCommand_Execute);
				}
			}
		}

		private static void LeftClickCommand_CanExecute(object sender, EventArgs e)
		{
			var uiElement = sender as UIElement;
			var uiElement3D = sender as UIElement3D;
			if (uiElement != null || uiElement3D != null)
			{
				var d = (DependencyObject)sender;
				var command = GetLeftClickCommand(d);
				if (command != null)
				{
					var commandParameter = GetLeftClickCommandParameter(d);
					var canExecute = command.CanExecute(commandParameter);

					if (uiElement3D != null)
						uiElement.IsEnabled = canExecute;
					else
						uiElement3D.IsEnabled = canExecute;
				}
			}
		}

		private static void LeftClickCommand_Execute(object sender, MouseButtonEventArgs e)
		{
			var d = sender as DependencyObject;
			if (d != null)
			{
				var command = GetLeftClickCommand(d);
				if (command != null)
				{
					var commandParameter = GetLeftClickCommandParameter(d);
					if (command.CanExecute(commandParameter))
						command.Execute(commandParameter);
				}
			}
		}

		#endregion LeftClickCommand

		#region LeftClickCommandParameter

		/// <summary>
		/// Identifies the <c>LeftClickCommandParameter</c> attached property.
		/// </summary>
		public static readonly DependencyProperty LeftClickCommandParameterProperty =
			DependencyProperty.RegisterAttached("LeftClickCommandParameter", typeof(object), typeof(MouseExtensions),
				new PropertyMetadata());

		/// <summary>
		/// Gets the command parameter for the command executed when the input element captures a left click event.
		/// </summary>
		/// <param name="d">The object for which to get the property value. This must support the
		/// <see cref="IInputElement"/> interface.</param>
		/// <returns>The attached property value. </returns>
		/// <exception cref="ArgumentNullException"><paramref name="d"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="d"/> does not implement the
		/// <see cref="IInputElement"/> interface.</exception>
		public static object GetLeftClickCommandParameter(DependencyObject d)
		{
			ValidateInputElementDependencyObject(d, "LeftClickCommandParameter");
			return d.GetValue(LeftClickCommandParameterProperty);
		}

		/// <summary>
		/// Sets the command parameter for the command executed when the input element captures a left click event.
		/// </summary>
		/// <param name="d">The object on which to set the property value. This must support the
		/// <see cref="IInputElement"/> interface.</param>
		/// <param name="value">The new value for the attached property.</param>
		/// <exception cref="ArgumentNullException"><paramref name="d"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="d"/> does not implement the
		/// <see cref="IInputElement"/> interface.</exception>
		public static void SetLeftClickCommandParameter(DependencyObject d, object value)
		{
			ValidateInputElementDependencyObject(d, "LeftClickCommandParameter");
			d.SetValue(LeftClickCommandParameterProperty, value);
		}

		#endregion LeftClickCommandParameter

		#region RightClickCommand

		/// <summary>
		/// Identifies the <c>RightClickCommand</c> attached property.
		/// </summary>
		public static readonly DependencyProperty RightClickCommandProperty =
			DependencyProperty.RegisterAttached("RightClickCommand", typeof(ICommand), typeof(MouseExtensions),
				new PropertyMetadata(RightClickCommandPropertyChanged));

		/// <summary>
		/// Gets the command to be executed when the input element captures a right click event.
		/// </summary>
		/// <param name="d">The object for which to get the property value. This must support the
		/// <see cref="IInputElement"/> interface.</param>
		/// <returns>The attached property value. </returns>
		/// <exception cref="ArgumentNullException"><paramref name="d"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="d"/> does not implement the
		/// <see cref="IInputElement"/> interface.</exception>
		public static ICommand GetRightClickCommand(DependencyObject d)
		{
			ValidateInputElementDependencyObject(d, "RightClickCommand");
			return (ICommand)d.GetValue(RightClickCommandProperty);
		}

		/// <summary>
		/// Sets the command to be executed when the input element captures a right click event.
		/// </summary>
		/// <param name="d">The object on which to set the property value. This must support the
		/// <see cref="IInputElement"/> interface.</param>
		/// <param name="value">The new value for the attached property.</param>
		/// <exception cref="ArgumentNullException"><paramref name="d"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="d"/> does not implement the
		/// <see cref="IInputElement"/> interface.</exception>
		public static void SetRightClickCommand(DependencyObject d, ICommand value)
		{
			ValidateInputElementDependencyObject(d, "RightClickCommand");
			d.SetValue(RightClickCommandProperty, value);
		}

		private static void RightClickCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d != null)
			{
				var oldValue = (ICommand)e.OldValue;
				if (oldValue != null)
				{
					RemoveRightClickHandler(d, RightClickCommand_Execute);
					oldValue.CanExecuteChanged -= RightClickCommand_CanExecute;
				}

				var newValue = (ICommand)e.NewValue;
				if (newValue != null)
				{
					var uiElement = d as UIElement;
					var uiElement3D = d as UIElement3D;
					if (uiElement != null || uiElement3D != null)
						newValue.CanExecuteChanged += RightClickCommand_CanExecute;
					AddRightClickHandler(d, RightClickCommand_Execute);
				}
			}
		}

		private static void RightClickCommand_CanExecute(object sender, EventArgs e)
		{
			var uiElement = sender as UIElement;
			var uiElement3D = sender as UIElement3D;
			if (uiElement != null || uiElement3D != null)
			{
				var d = (DependencyObject)sender;
				var command = GetRightClickCommand(d);
				if (command != null)
				{
					var commandParameter = GetRightClickCommandParameter(d);
					var canExecute = command.CanExecute(commandParameter);

					if (uiElement3D != null)
						uiElement.IsEnabled = canExecute;
					else
						uiElement3D.IsEnabled = canExecute;
				}
			}
		}

		private static void RightClickCommand_Execute(object sender, MouseButtonEventArgs e)
		{
			var d = sender as DependencyObject;
			if (d != null)
			{
				var command = GetRightClickCommand(d);
				if (command != null)
				{
					var commandParameter = GetRightClickCommandParameter(d);
					if (command.CanExecute(commandParameter))
						command.Execute(commandParameter);
				}
			}
		}

		#endregion RightClickCommand

		#region RightClickCommandParameter

		/// <summary>
		/// Identifies the <c>RightClickCommandParameter</c> attached property.
		/// </summary>
		public static readonly DependencyProperty RightClickCommandParameterProperty =
			DependencyProperty.RegisterAttached("RightClickCommandParameter", typeof(object), typeof(MouseExtensions),
				new PropertyMetadata());

		/// <summary>
		/// Gets the command parameter for the command executed when the input element captures a right click event.
		/// </summary>
		/// <param name="d">The object for which to get the property value. This must support the
		/// <see cref="IInputElement"/> interface.</param>
		/// <returns>The attached property value. </returns>
		/// <exception cref="ArgumentNullException"><paramref name="d"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="d"/> does not implement the
		/// <see cref="IInputElement"/> interface.</exception>
		public static object GetRightClickCommandParameter(DependencyObject d)
		{
			ValidateInputElementDependencyObject(d, "RightClickCommandParameter");
			return d.GetValue(RightClickCommandParameterProperty);
		}

		/// <summary>
		/// Sets the command parameter for the command executed when the input element captures a right click event.
		/// </summary>
		/// <param name="d">The object on which to set the property value. This must support the
		/// <see cref="IInputElement"/> interface.</param>
		/// <param name="value">The new value for the attached property.</param>
		/// <exception cref="ArgumentNullException"><paramref name="d"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="d"/> does not implement the
		/// <see cref="IInputElement"/> interface.</exception>
		public static void SetRightClickCommandParameter(DependencyObject d, object value)
		{
			ValidateInputElementDependencyObject(d, "RightClickCommandParameter");
			d.SetValue(RightClickCommandParameterProperty, value);
		}

		#endregion RightClickCommandParameter

		#region ContextPopup

		/// <summary>
		/// Identifies the <c>ContextPopup</c> attached property.
		/// </summary>
		public static readonly DependencyProperty ContextPopupProperty =
			DependencyProperty.RegisterAttached("ContextPopup", typeof(object), typeof(MouseExtensions),
				new PropertyMetadata(ContextPopupPropertyChanged));

		/// <summary>
		/// Gets the command parameter for the command executed when the input element captures a right click event.
		/// </summary>
		/// <param name="d">The Popup for which to get the property value. This must support the
		/// <see cref="IInputElement"/> interface.</param>
		/// <returns>The attached property value. </returns>
		/// <exception cref="ArgumentNullException"><paramref name="d"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="d"/> does not implement the
		/// <see cref="IInputElement"/> interface.</exception>
		public static object GetContextPopup(DependencyObject d)
		{
			if (d == null)
				throw new ArgumentNullException("d");
			return d.GetValue(ContextPopupProperty);
		}

		/// <summary>
		/// Sets the command parameter for the command executed when the input element captures a right click event.
		/// </summary>
		/// <param name="d">The Popup on which to set the property value. This must support the
		/// <see cref="IInputElement"/> interface.</param>
		/// <param name="value">The new value for the attached property.</param>
		/// <exception cref="ArgumentNullException"><paramref name="d"/> is <c>null</c>.</exception>
		/// <exception cref="ArgumentException"><paramref name="d"/> does not implement the
		/// <see cref="IInputElement"/> interface.</exception>
		public static void SetContextPopup(DependencyObject d, object value)
		{
			if (d == null)
				throw new ArgumentNullException("d");
			d.SetValue(ContextPopupProperty, value);
		}

		private static void ContextPopupPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var newValue = e.NewValue;
			var popup = newValue as Popup;
			if (popup == null)
			{
				popup = new Popup();
				var addChild = (IAddChild)popup;
				if (newValue is string)
					addChild.AddText((string)newValue);
				else
					addChild.AddChild(newValue);
			}

			SetContextPopupInternal(d, popup);
		}

		#endregion ContextPopup

		#region ContextPopupInternal

		private static readonly DependencyPropertyKey ContextPopupInternalPropertyKey =
			DependencyProperty.RegisterAttachedReadOnly("ContextPopupInternal", typeof(Popup), typeof(MouseExtensions),
				new PropertyMetadata());

		internal static Popup GetContextPopupInternal(DependencyObject d)
		{
			ValidateInputElementDependencyObject(d, ContextPopupInternalPropertyKey.DependencyProperty.Name);
			return (Popup)d.GetValue(ContextPopupInternalPropertyKey.DependencyProperty);
		}

		private static void SetContextPopupInternal(DependencyObject d, Popup value)
		{
			ValidateInputElementDependencyObject(d, ContextPopupInternalPropertyKey.DependencyProperty.Name);
			d.SetValue(ContextPopupInternalPropertyKey, value);
		}

		#endregion ContextPopupInternal

		#endregion Attached Properties

		#region Attached Events

		#region LeftClick Attached Event
		/// <summary>
		/// Identifies the <c>LeftClick</c> attached event.
		/// </summary>
		public static readonly RoutedEvent LeftClickEvent =
			EventManager.RegisterRoutedEvent("LeftClick", RoutingStrategy.Bubble,
				typeof(MouseButtonEventHandler), typeof(MouseExtensions));

		/// <summary>
		/// Adds an event handler for the <c>LeftClick</c> attached event.
		/// </summary>
		/// <param name="d">The object on which to set the event handler. This must support the
		/// <see cref="IInputElement"/> interface.</param>
		/// <param name="handler">The event handler.</param>
		public static void AddLeftClickHandler(DependencyObject d, MouseButtonEventHandler handler)
		{
			//System.Diagnostics.Debug.WriteLine("AddLeftClickHandler: " + d.GetType().Name);

			var inputElement = d as IInputElement;
			if (inputElement != null)
			{
				inputElement.AddHandler(MouseExtensions.LeftClickEvent, handler);
				inputElement.PreviewMouseLeftButtonDown += inputElement_PreviewMouseLeftButtonDown;
			}
		}

		/// <summary>
		/// Adds an event handler for the <c>LeftClick</c> attached event.
		/// </summary>
		/// <param name="element">The <see cref="UIElement"/> on which to set the event handler.</param>
		/// <param name="handler">The event handler.</param>
		/// <param name="handledEventsToo">
		/// <c>true</c> to register the handler such that it is invoked even when the routed event is marked handled
		/// in its event data; <c>false</c> to register the handler with the default condition that it will not be
		/// invoked if the routed event is already marked handled. The default is false.
		/// </param>
		public static void AddLeftClickHandler(UIElement element, MouseButtonEventHandler handler, bool handledEventsToo)
		{
			if (element != null)
			{
				element.AddHandler(MouseExtensions.LeftClickEvent, handler, handledEventsToo);
				element.PreviewMouseLeftButtonDown += inputElement_PreviewMouseLeftButtonDown;
			}
		}

		public static void RemoveLeftClickHandler(DependencyObject d, MouseButtonEventHandler handler)
		{
			var inputElement = d as IInputElement;
			if (inputElement != null)
			{
				inputElement.PreviewMouseLeftButtonDown -= inputElement_PreviewMouseLeftButtonDown;
				inputElement.RemoveHandler(MouseExtensions.LeftClickEvent, handler);
			}
		}

		private static void inputElement_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			//System.Diagnostics.Debug.WriteLine("inputElement_PreviewMouseLeftButtonDown: sender=\"{0}\" e.Source=\"{1}\" e.OriginalSource=\"{2}\"",
			//    sender.FormatNameAndType(), e.Source.FormatNameAndType(), e.OriginalSource.FormatNameAndType());

			var d = (DependencyObject)sender;
			var inputElement = d as IInputElement;
			if (inputElement != null)
			{
				// ButtonBase has its own Click handling
				var source = e.Source as DependencyObject;
				if (source == null || !source.GetSelfAndVisualAncestors().TakeWhile(a => a != d).OfType<ButtonBase>().Any())
				{
					d.Dispatcher.BeginInvoke(() =>
					{
						inputElement.CaptureMouse();
						inputElement.LostMouseCapture += inputElement_LostMouseCapture;
						inputElement.MouseLeftButtonUp += inputElement_MouseLeftButtonUp;
					});
				}
			}
		}

		private static void inputElement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			//System.Diagnostics.Debug.WriteLine("inputElement_MouseLeftButtonUp: sender=\"{0}\" e.Source=\"{1}\" e.OriginalSource=\"{2}\" e.Handled={3}",
			//    sender.FormatNameAndType(), e.Source.FormatNameAndType(), e.OriginalSource.FormatNameAndType(), e.Handled);

			var inputElement = sender as IInputElement;
			if (inputElement != null)
			{
				inputElement.ReleaseMouseCapture();

				if (inputElement.IsMouseOver)
				{
					var args = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice);
					args.RoutedEvent = LeftClickEvent;
					inputElement.RaiseEvent(args);
					e.Handled = true;
				}
			}
		}
		#endregion LeftClick Attached Event

		#region RightClick Attached Event
		/// <summary>
		/// Identifies the <c>RightClick</c> attached event.
		/// </summary>
		public static readonly RoutedEvent RightClickEvent =
			EventManager.RegisterRoutedEvent("RightClick", RoutingStrategy.Bubble,
				typeof(MouseButtonEventHandler), typeof(MouseExtensions));

		/// <summary>
		/// Adds an event handler for the <c>RightClick</c> attached event.
		/// </summary>
		/// <param name="d">The object on which to set the event handler. This must support the
		/// <see cref="IInputElement"/> interface.</param>
		/// <param name="handler">The event handler.</param>
		public static void AddRightClickHandler(DependencyObject d, MouseButtonEventHandler handler)
		{
			var inputElement = d as IInputElement;
			if (inputElement != null)
			{
				inputElement.AddHandler(MouseExtensions.RightClickEvent, handler);
				inputElement.PreviewMouseRightButtonDown += inputElement_PreviewMouseRightButtonDown;
			}
		}

		public static void RemoveRightClickHandler(DependencyObject d, MouseButtonEventHandler handler)
		{
			var inputElement = d as IInputElement;
			if (inputElement != null)
			{
				inputElement.PreviewMouseRightButtonDown -= inputElement_PreviewMouseRightButtonDown;
				inputElement.RemoveHandler(MouseExtensions.RightClickEvent, handler);
			}
		}

		private static void inputElement_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("inputElement_PreviewMouseRightButtonDown: " + sender.GetType().Name);

			var d = (DependencyObject)sender;
			var inputElement = sender as IInputElement;
			if (inputElement != null)
			{
				d.Dispatcher.BeginInvoke(() =>
				{
					inputElement.CaptureMouse();
					inputElement.LostMouseCapture += inputElement_LostMouseCapture;
					inputElement.MouseRightButtonUp += inputElement_MouseRightButtonUp;
				});
			}
		}

		private static void inputElement_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
			var inputElement = sender as IInputElement;
			if (inputElement != null)
			{
				inputElement.ReleaseMouseCapture();

				if (inputElement.IsMouseOver)
				{
					var args = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice);
					args.RoutedEvent = RightClickEvent;
					inputElement.RaiseEvent(args);
					e.Handled = true;
				}
			}
		}
		#endregion RightClick Attached Event

		#endregion Attached Events

		#region Internal Implementation

		internal static IInputElement ValidateInputElementDependencyObject(DependencyObject d, string propertyName)
		{
			if (d == null)
				throw new ArgumentNullException("d");

			var inputElement = d as IInputElement;
			if (inputElement == null)
				throw new ArgumentException(
					string.Format(Properties.Resources.PropertyNotAttachableToTypeFormat2, propertyName, d.GetType()), "d");

			return inputElement;
		}

		#endregion Internal Implementation

		#region Event Handlers
		private static void inputElement_LostMouseCapture(object sender, MouseEventArgs e)
		{
			var inputElement = sender as IInputElement;
			if (inputElement != null)
			{
				inputElement.MouseRightButtonUp -= inputElement_MouseRightButtonUp;
				inputElement.MouseLeftButtonUp -= inputElement_MouseLeftButtonUp;
				inputElement.LostMouseCapture -= inputElement_LostMouseCapture;
			}
		}
		#endregion Event Handlers
	}
}
