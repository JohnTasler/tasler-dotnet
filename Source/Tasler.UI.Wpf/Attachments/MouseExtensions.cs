using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using CommunityToolkit.Diagnostics;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Attachments;

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
	/// Retrieves the command to be executed when the left mouse button is clicked on the specified input element.
	/// </summary>
	/// <param name="d">The object for which to get the property value. This must support the
	/// <see cref="IInputElement"/> interface.</param>
	/// <returns>The attached property value. </returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="d"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentException">Thrown if <paramref name="d"/> does not implement the <see cref="IInputElement"/> interface.</exception>
	/// <returns>The <see cref="ICommand"/> associated with the left click, or <see langword="null"/> if none is set.</returns>
	public static ICommand GetLeftClickCommand(DependencyObject d)
	{
		ValidateInputElementDependencyObject(d, "LeftClickCommand");
		return (ICommand)d.GetValue(LeftClickCommandProperty);
	}

	/// <summary>
	/// Sets the command to be executed when the left mouse button is clicked on the specified input element.
	/// </summary>
	/// <param name="d">The dependency object to attach the command to. This must support the
	/// <see cref="IInputElement"/> interface.</param>
	/// <param name="value">The command to execute on left mouse click.</param>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="d"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentException">Thrown if <paramref name="d"/> does not implement the <see cref="IInputElement"/> interface.</exception>
	public static void SetLeftClickCommand(DependencyObject d, ICommand value)
	{
		ValidateInputElementDependencyObject(d, "LeftClickCommand");
		d.SetValue(LeftClickCommandProperty, value);
	}

	private static void LeftClickCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		Guard.IsNotNull(d);

		if (e.OldValue is ICommand oldValue)
		{
			RemoveLeftClickHandler(d, LeftClickCommand_Execute);
			oldValue.CanExecuteChanged -= LeftClickCommand_CanExecute;
		}

		if (e.NewValue is ICommand newValue)
		{
			if (d is UIElement || d is UIElement3D)
				newValue.CanExecuteChanged += LeftClickCommand_CanExecute;
			AddLeftClickHandler(d, LeftClickCommand_Execute);
		}
	}

	private static void LeftClickCommand_CanExecute(object? sender, EventArgs e)
	{
		if (sender is DependencyObject d)
		{
			var command = GetLeftClickCommand(d);
			if (command is not null)
			{
				var commandParameter = GetLeftClickCommandParameter(d);
				var canExecute = command.CanExecute(commandParameter);

				if (sender is UIElement uiElement)
					uiElement.IsEnabled = canExecute;
				else if (sender is UIElement3D uiElement3D)
					uiElement3D.IsEnabled = canExecute;
			}
		}
	}

	private static void LeftClickCommand_Execute(object sender, MouseButtonEventArgs e)
	{
		if (sender is DependencyObject d)
		{
			var command = GetLeftClickCommand(d);
			if (command is not null)
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
	/// Retrieves the parameter associated with the left click command for the specified input element.
	/// </summary>
	/// <param name="d">The object for which to get the property value. This must support the
	/// <see cref="IInputElement"/> interface.</param>
	/// <returns>The parameter object for the left click command.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="d"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentException">
	/// Thrown if <paramref name="d"/> does not implement the <see cref="IInputElement"/> interface.
	/// </exception>
	public static object GetLeftClickCommandParameter(DependencyObject d)
	{
		ValidateInputElementDependencyObject(d, "LeftClickCommandParameter");
		return d.GetValue(LeftClickCommandParameterProperty);
	}

	/// <summary>
	/// Sets the parameter to be passed to the left click command for the specified input element.
	/// </summary>
	/// <param name="d">The object on which to set the property value. This must support the
	/// <see cref="IInputElement"/> interface.</param>
	/// <param name="value">The parameter value to set.</param>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="d"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentException">Thrown if <paramref name="d"/> does not implement the <see cref="IInputElement"/> interface.</exception>
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
	/// Retrieves the command to be executed when the right mouse button is clicked on the specified input element.
	/// </summary>
	/// <param name="d">The object for which to get the property value. This must support the
	/// <see cref="IInputElement"/> interface.</param>
	/// <returns>The attached property value. </returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="d"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentException">Thrown if <paramref name="d"/> does not implement the <see cref="IInputElement"/> interface.</exception>
	/// <returns>The <see cref="ICommand"/> associated with the right click, or <see langword="null"/> if none is set.</returns>
	public static ICommand GetRightClickCommand(DependencyObject d)
	{
		ValidateInputElementDependencyObject(d, "RightClickCommand");
		return (ICommand)d.GetValue(RightClickCommandProperty);
	}

	/// <summary>
	/// Sets the command to be executed when the right mouse button is clicked on the specified input element.
	/// </summary>
	/// <param name="d">The dependency object to attach the command to. This must support the
	/// <see cref="IInputElement"/> interface.</param>
	/// <param name="value">The command to execute on right mouse click.</param>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="d"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentException">Thrown if <paramref name="d"/> does not implement the <see cref="IInputElement"/> interface.</exception>
	public static void SetRightClickCommand(DependencyObject d, ICommand value)
	{
		ValidateInputElementDependencyObject(d, "RightClickCommand");
		d.SetValue(RightClickCommandProperty, value);
	}

	private static void RightClickCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		Guard.IsNotNull(d);

		if (e.OldValue is ICommand oldValue)
		{
			RemoveRightClickHandler(d, RightClickCommand_Execute);
			oldValue.CanExecuteChanged -= RightClickCommand_CanExecute;
		}

		if (e.NewValue is ICommand newValue)
		{
			if (d is UIElement || d is UIElement3D)
				newValue.CanExecuteChanged += RightClickCommand_CanExecute;
			AddRightClickHandler(d, RightClickCommand_Execute);
		}
	}

	private static void RightClickCommand_CanExecute(object? sender, EventArgs e)
	{
		if (sender is DependencyObject d)
		{
			var command = GetRightClickCommand(d);
			if (command is not null)
			{
				var commandParameter = GetRightClickCommandParameter(d);
				var canExecute = command.CanExecute(commandParameter);

				if (sender is UIElement uiElement)
					uiElement.IsEnabled = canExecute;
				else if (sender is UIElement3D uiElement3D)
					uiElement3D.IsEnabled = canExecute;
			}
		}
	}

	private static void RightClickCommand_Execute(object sender, MouseButtonEventArgs e)
	{
		if (sender is DependencyObject d)
		{
			var command = GetRightClickCommand(d);
			if (command is not null)
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
	/// Retrieves the parameter associated with the right click command for the specified input element.
	/// </summary>
	/// <param name="d">The object for which to get the property value. This must support the
	/// <see cref="IInputElement"/> interface.</param>
	/// <returns>The parameter object for the right click command.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="d"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentException">
	/// Thrown if <paramref name="d"/> does not implement the <see cref="IInputElement"/> interface.
	/// </exception>
	public static object GetRightClickCommandParameter(DependencyObject d)
	{
		ValidateInputElementDependencyObject(d, "RightClickCommandParameter");
		return d.GetValue(RightClickCommandParameterProperty);
	}

	/// <summary>
	/// Sets the parameter to be passed to the right click command for the specified input element.
	/// </summary>
	/// <param name="d">The object on which to set the property value. This must support the
	/// <see cref="IInputElement"/> interface.</param>
	/// <param name="value">The parameter value to set.</param>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="d"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentException">Thrown if <paramref name="d"/> does not implement the <see cref="IInputElement"/> interface.</exception>
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
	/// Gets the context popup associated with the specified dependency object.
	/// </summary>
	/// <param name="d">The dependency object from which to retrieve the context popup.</param>
	/// <see cref="IInputElement"/> interface.</param>
	/// <returns>The attached property value. </returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="d"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentException"><paramref name="d"/> does not implement the
	/// <see cref="IInputElement"/> interface.</exception>
	public static object GetContextPopup(DependencyObject d)
	{
		Guard.IsNotNull(d);
		return d.GetValue(ContextPopupProperty);
	}

	/// <summary>
	/// Sets the context popup object associated with the specified dependency object.
	/// </summary>
	/// <param name="d">The Popup on which to set the property value. This must support the
	/// <see cref="IInputElement"/> interface.</param>
	/// <param name="value">The context popup object to set.</param>
	/// <exception cref="ArgumentException">Thrown if <paramref name="d"/> does not implement the
	/// <see cref="IInputElement"/> interface.</exception>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="d"/> is <see langword="null"/>.</exception>
	public static void SetContextPopup(DependencyObject d, object value)
	{
		Guard.IsNotNull(d);
		d.SetValue(ContextPopupProperty, value);
	}

	private static void ContextPopupPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (e.NewValue is not Popup popup)
		{
			popup = new Popup();
			var addChild = (IAddChild)popup;
			if (e.NewValue is string newValue)
				addChild.AddText(newValue);
			else
				addChild.AddChild(e.NewValue);
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

		if (d is IInputElement inputElement)
		{
			inputElement.AddHandler(MouseExtensions.LeftClickEvent, handler);
			inputElement.PreviewMouseLeftButtonDown += InputElement_PreviewMouseLeftButtonDown;
		}
	}

	/// <summary>
	/// Adds an event handler for the <c>LeftClick</c> attached event.
	/// </summary>
	/// <param name="element">The <see cref="UIElement"/> on which to set the event handler.</param>
	/// <param name="handler">The event handler.</param>
	/// <param name="handledEventsToo">
	/// <see langword="true"/> to register the handler such that it is invoked even when the routed event is marked handled
	/// in its event data; <see langword="false"/> to register the handler with the default condition that it will not be
	/// invoked if the routed event is already marked handled. The default is false.
	/// </param>
	public static void AddLeftClickHandler(UIElement element, MouseButtonEventHandler handler, bool handledEventsToo)
	{
		if (element is not null)
		{
			element.AddHandler(MouseExtensions.LeftClickEvent, handler, handledEventsToo);
			element.PreviewMouseLeftButtonDown += InputElement_PreviewMouseLeftButtonDown;
		}
	}

	public static void RemoveLeftClickHandler(DependencyObject d, MouseButtonEventHandler handler)
	{
		if (d is IInputElement inputElement)
		{
			inputElement.PreviewMouseLeftButtonDown -= InputElement_PreviewMouseLeftButtonDown;
			inputElement.RemoveHandler(MouseExtensions.LeftClickEvent, handler);
		}
	}

	private static void InputElement_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		//System.Diagnostics.Debug.WriteLine("inputElement_PreviewMouseLeftButtonDown: sender=\"{0}\" e.Source=\"{1}\" e.OriginalSource=\"{2}\"",
		//    sender.FormatNameAndType(), e.Source.FormatNameAndType(), e.OriginalSource.FormatNameAndType());

		if (sender is DependencyObject d && d is IInputElement inputElement)
		{
			// ButtonBase has its own Click handling
			var source = e.Source as DependencyObject;
			if (source is null || !source.GetSelfAndVisualAncestors().TakeWhile(a => a != d).OfType<ButtonBase>().Any())
			{
				d.Dispatcher.BeginInvoke(() =>
				{
					inputElement.CaptureMouse();
					inputElement.LostMouseCapture += InputElement_LostMouseCapture;
					inputElement.MouseLeftButtonUp += InputElement_MouseLeftButtonUp;
				});
			}
		}
	}

	private static void InputElement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		//System.Diagnostics.Debug.WriteLine("inputElement_MouseLeftButtonUp: sender=\"{0}\" e.Source=\"{1}\" e.OriginalSource=\"{2}\" e.Handled={3}",
		//    sender.FormatNameAndType(), e.Source.FormatNameAndType(), e.OriginalSource.FormatNameAndType(), e.Handled);

		if (sender is IInputElement inputElement)
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
		if (d is IInputElement inputElement)
		{
			inputElement.AddHandler(MouseExtensions.RightClickEvent, handler);
			inputElement.PreviewMouseRightButtonDown += InputElement_PreviewMouseRightButtonDown;
		}
	}

	public static void RemoveRightClickHandler(DependencyObject d, MouseButtonEventHandler handler)
	{
		if (d is IInputElement inputElement)
		{
			inputElement.PreviewMouseRightButtonDown -= InputElement_PreviewMouseRightButtonDown;
			inputElement.RemoveHandler(MouseExtensions.RightClickEvent, handler);
		}
	}

	private static void InputElement_PreviewMouseRightButtonDown(object? sender, MouseButtonEventArgs e)
	{
		System.Diagnostics.Debug.WriteLine("inputElement_PreviewMouseRightButtonDown: " + sender?.GetType().Name);

		if (sender is DependencyObject d && sender is IInputElement inputElement)
		{
			d.Dispatcher.BeginInvoke(() =>
			{
				inputElement.CaptureMouse();
				inputElement.LostMouseCapture += InputElement_LostMouseCapture;
				inputElement.MouseRightButtonUp += InputElement_MouseRightButtonUp;
			});
		}
	}

	private static void InputElement_MouseRightButtonUp(object? sender, MouseButtonEventArgs e)
	{
		if (sender is IInputElement inputElement)
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

	internal static IInputElement? ValidateInputElementDependencyObject(DependencyObject d, string propertyName)
	{
		Guard.IsNotNull(d);
		Guard.IsOfType<IInputElement>(d);

		return d as IInputElement;
	}

	#endregion Internal Implementation

	#region Event Handlers
	private static void InputElement_LostMouseCapture(object? sender, MouseEventArgs e)
	{
		if (sender is IInputElement inputElement)
		{
			inputElement.MouseRightButtonUp -= InputElement_MouseRightButtonUp;
			inputElement.MouseLeftButtonUp -= InputElement_MouseLeftButtonUp;
			inputElement.LostMouseCapture -= InputElement_LostMouseCapture;
		}
	}
	#endregion Event Handlers
}
