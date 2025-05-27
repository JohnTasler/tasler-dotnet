using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using CommunityToolkit.Diagnostics;
using Microsoft.Xaml.Behaviors;
using Tasler.Windows.Attachments;

namespace Tasler.Windows.Behaviors;

public class MouseBehavior : Behavior<FrameworkElement>
{
	#region Dependency Properties

	#region ContextMenuOpenMode

	/// <summary>
	/// Identifies the <see cref="ContextMenuOpenMode"/> dependency property.
	/// </summary>
	public static readonly DependencyProperty ContextMenuOpenModeProperty =
		DependencyPropertyFactory<MouseBehavior>.Register<ContextOpenMode>(
			nameof(ContextMenuOpenMode), ContextMenuOpenModePropertyChanged);

	/// <summary>
	/// Gets or sets a value indicating whether the <see cref="FrameworkElement.ContextMenu"/> of the
	/// <see cref="AssociatedObject"/> is opened on left click.
	/// </summary>
	/// <value>
	/// 	<see langword="true"/> if the <see cref="FrameworkElement.ContextMenu"/> of the <see cref="AssociatedObject"/>
	/// 	is opened on left click; otherwise, <see langword="false"/>.
	/// </value>
	public ContextOpenMode ContextMenuOpenMode
	{
		get => (ContextOpenMode)GetValue(ContextMenuOpenModeProperty);
		set => SetValue(ContextMenuOpenModeProperty, value);
	}

	private static void ContextMenuOpenModePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var @this = (MouseBehavior)d;
		@this.SubscribeToLeftClickAsNeeded();
		@this.SubscribeToRightClickAsNeeded();
	}

	#endregion ContextMenuOpenMode

	#region ContextPopupOpenMode

	/// <summary>
	/// Identifies the <see cref="ContextPopupOpenMode"/> dependency property.
	/// </summary>
	public static readonly DependencyProperty ContextPopupOpenModeProperty =
		DependencyProperty.Register("ContextPopupOpenMode", typeof(ContextOpenMode), typeof(MouseBehavior),
			new PropertyMetadata(ContextPopupOpenModePropertyChanged));

	/// <summary>
	/// Gets or sets a value indicating whether the <see cref="FrameworkElement.ContextPopup"/> of the
	/// <see cref="AssociatedObject"/> is opened on left click.
	/// </summary>
	/// <value>
	/// 	<see langword="true"/> if the <see cref="FrameworkElement.ContextPopup"/> of the <see cref="AssociatedObject"/>
	/// 	is opened on left click; otherwise, <see langword="false"/>.
	/// </value>
	public ContextOpenMode ContextPopupOpenMode
	{
		get { return (ContextOpenMode)GetValue(ContextPopupOpenModeProperty); }
		set { SetValue(ContextPopupOpenModeProperty, value); }
	}

	private static void ContextPopupOpenModePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var instance = (MouseBehavior)d;
		instance.SubscribeToLeftClickAsNeeded();
		instance.SubscribeToRightClickAsNeeded();
	}

	#endregion ContextPopupOpenMode

	#region LeftClickCommand

	/// <summary>
	/// Identifies the <c>LeftClickCommand</c> attached property.
	/// </summary>
	public static readonly DependencyProperty LeftClickCommandProperty =
		DependencyProperty.RegisterAttached("LeftClickCommand", typeof(ICommand), typeof(MouseBehavior),
			new PropertyMetadata(null, null, CoerceLeftClickCommandProperty));

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
		MouseExtensions.ValidateInputElementDependencyObject(d, "LeftClickCommand");
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
		MouseExtensions.ValidateInputElementDependencyObject(d, "LeftClickCommand");
		d.SetValue(LeftClickCommandProperty, value);
	}

	private static object CoerceLeftClickCommandProperty(DependencyObject d, object value)
	{
		var instance = d as MouseBehavior;
		if (instance is not null && instance.AssociatedObject is not null)
			instance.AssociatedObject.SetValue(MouseExtensions.LeftClickCommandProperty, value);
		return value;
	}

	#endregion LeftClickCommand

	#region LeftClickCommandParameter

	/// <summary>
	/// Identifies the <c>LeftClickCommandParameter</c> attached property.
	/// </summary>
	public static readonly DependencyProperty LeftClickCommandParameterProperty =
		DependencyProperty.RegisterAttached("LeftClickCommandParameter", typeof(object), typeof(MouseBehavior),
			new PropertyMetadata(null, null, CoerceLeftClickCommandParameterProperty));

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
		MouseExtensions.ValidateInputElementDependencyObject(d, "LeftClickCommandParameter");
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
		MouseExtensions.ValidateInputElementDependencyObject(d, "LeftClickCommandParameter");
		d.SetValue(LeftClickCommandParameterProperty, value);
	}

	private static object CoerceLeftClickCommandParameterProperty(DependencyObject d, object value)
	{
		var instance = d as MouseBehavior;
		if (instance is not null && instance.AssociatedObject is not null)
			instance.AssociatedObject.SetValue(MouseExtensions.LeftClickCommandParameterProperty, value);
		return value;
	}

	#endregion LeftClickCommandParameter

	#region RightClickCommand

	/// <summary>
	/// Identifies the <c>RightClickCommand</c> attached property.
	/// </summary>
	public static readonly DependencyProperty RightClickCommandProperty =
		DependencyProperty.RegisterAttached("RightClickCommand", typeof(object), typeof(MouseBehavior),
			new PropertyMetadata(null, null, CoerceRightClickCommandProperty));

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
		MouseExtensions.ValidateInputElementDependencyObject(d, "RightClickCommand");
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
		MouseExtensions.ValidateInputElementDependencyObject(d, "RightClickCommand");
		d.SetValue(RightClickCommandProperty, value);
	}

	private static object CoerceRightClickCommandProperty(DependencyObject d, object value)
	{
		var instance = d as MouseBehavior;
		if (instance is not null && instance.AssociatedObject is not null)
			instance.AssociatedObject.SetValue(MouseExtensions.RightClickCommandProperty, value);
		return value;
	}

	#endregion RightClickCommand

	#region RightClickCommandParameter

	/// <summary>
	/// Identifies the <c>RightClickCommandParameter</c> attached property.
	/// </summary>
	public static readonly DependencyProperty RightClickCommandParameterProperty =
		DependencyProperty.RegisterAttached("RightClickCommandParameter", typeof(object), typeof(MouseBehavior),
			new PropertyMetadata(null, null, CoerceRightClickCommandParameterProperty));

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
		MouseExtensions.ValidateInputElementDependencyObject(d, "RightClickCommandParameter");
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
		MouseExtensions.ValidateInputElementDependencyObject(d, "RightClickCommandParameter");
		d.SetValue(RightClickCommandParameterProperty, value);
	}

	private static object CoerceRightClickCommandParameterProperty(DependencyObject d, object value)
	{
		var instance = d as MouseBehavior;
		if (instance is not null && instance.AssociatedObject is not null)
			instance.AssociatedObject.SetValue(MouseExtensions.RightClickCommandParameterProperty, value);
		return value;
	}

	#endregion RightClickCommandParameter

	#region ContextMenu

	/// <summary>
	/// Identifies the <c>ContextMenu</c> attached property.
	/// </summary>
	public static readonly DependencyProperty ContextMenuProperty =
		DependencyProperty.RegisterAttached("ContextMenu", typeof(ContextMenu), typeof(MouseBehavior),
			new PropertyMetadata(null, null, CoerceContextMenuProperty));

	/// <summary>
	/// Gets the command parameter for the command executed when the input element captures a right click event.
	/// </summary>
	/// <param name="d">The Popup for which to get the property value. This must support the
	/// <see cref="IInputElement"/> interface.</param>
	/// <returns>The attached property value. </returns>
	/// <exception cref="ArgumentNullException"><paramref name="d"/> is <c>null</c>.</exception>
	/// <exception cref="ArgumentException"><paramref name="d"/> does not implement the
	/// <see cref="IInputElement"/> interface.</exception>
	public static ContextMenu GetContextMenu(DependencyObject d)
	{
		MouseExtensions.ValidateInputElementDependencyObject(d, "ContextMenu");
		return (ContextMenu)d.GetValue(ContextMenuProperty);
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
	public static void SetContextMenu(DependencyObject d, ContextMenu value)
	{
		MouseExtensions.ValidateInputElementDependencyObject(d, "ContextMenu");
		d.SetValue(ContextMenuProperty, value);
	}

	private static object CoerceContextMenuProperty(DependencyObject d, object value)
	{
		var instance = d as MouseBehavior;
		if (instance is not null && instance.AssociatedObject is not null)
			instance.AssociatedObject.SetValue(FrameworkElement.ContextMenuProperty, value);
		return value;
	}

	#endregion ContextMenu

	#region ContextPopup

	/// <summary>
	/// Identifies the <c>ContextPopup</c> attached property.
	/// </summary>
	public static readonly DependencyProperty ContextPopupProperty =
		DependencyProperty.RegisterAttached("ContextPopup", typeof(object), typeof(MouseBehavior),
			new PropertyMetadata(null, null, CoerceContextPopupProperty));

	/// <summary>
	/// Gets the command parameter for the command executed when the input element captures a right click event.
	/// </summary>
	/// <param name="d">The Popup for which to get the property value. This must support the
	/// <see cref="IInputElement"/> interface.</param>
	/// <returns>The attached property value. </returns>
	/// <exception cref="ArgumentNullException"><paramref name="d"/> is <c>null</c>.</exception>
	/// <exception cref="ArgumentException"><paramref name="d"/> does not implement the
	/// <see cref="IInputElement"/> interface.</exception>
	public static object? GetContextPopup(DependencyObject d)
	{
		Guard.IsNotNull(d);
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
	public static void SetContextPopup(DependencyObject d, object? value)
	{
		Guard.IsNotNull(d);
		d.SetValue(ContextPopupProperty, value);
	}

	private static object? CoerceContextPopupProperty(DependencyObject d, object? value)
	{
		if (d is MouseBehavior instance && instance.AssociatedObject is not null)
			instance.AssociatedObject.SetValue(MouseExtensions.ContextPopupProperty, value);
		return value;
	}

	#endregion ContextPopup

	#endregion Dependency Properties

	#region Overrides
	protected override void OnAttached()
	{
		base.OnAttached();

		var enumerator = this.GetLocalValueEnumerator();
		while (enumerator.MoveNext())
			this.CoerceValue(enumerator.Current.Property);

		this.SubscribeToContextMenuChanged(true);
		this.SubscribeToContextPopupChanged(true);
		this.HasContextMenu = this.AssociatedObject.ContextMenu is not null;
		this.HasContextPopup = MouseExtensions.GetContextPopupInternal(this.AssociatedObject) is not null;
		this.AssociatedObject.PreviewMouseRightButtonUp += AssociatedObject_PreviewMouseRightButtonUp;
	}

	protected override void OnDetaching()
	{
		base.OnDetaching();

		var enumerator = this.GetLocalValueEnumerator();
		while (enumerator.MoveNext())
			this.AssociatedObject.ClearValue(enumerator.Current.Property);

		this.AssociatedObject.PreviewMouseRightButtonUp -= AssociatedObject_PreviewMouseRightButtonUp;
		this.HasContextPopup = false;
		this.HasContextMenu = false;
		this.SubscribeToContextPopupChanged(false);
		this.SubscribeToContextMenuChanged(false);
	}
	#endregion Overrides

	#region Private Implementation

	private bool IsContextMenuOpenedOnLeftClick
		=> (ContextMenuOpenMode & ContextOpenMode.LeftButton) != 0;

	private bool IsContextMenuOpenedOnRightClick
		=> (ContextMenuOpenMode & ContextOpenMode.RightButton) != 0;

	private bool HasContextMenu
	{
		get { return this._hasContextMenu; }
		set
		{
			if (this._hasContextMenu != value)
			{
				this._hasContextMenu = value;
				SubscribeToLeftClickAsNeeded();
				SubscribeToRightClickAsNeeded();
			}
		}
	}
	private bool _hasContextMenu;

	private bool IsContextPopupOpenedOnLeftClick
	{
		get { return (ContextPopupOpenMode & ContextOpenMode.LeftButton) != 0; }
	}

	private bool IsContextPopupOpenedOnRightClick
	{
		get { return (ContextPopupOpenMode & ContextOpenMode.RightButton) != 0; }
	}

	private bool HasContextPopup
	{
		get => _hasContextPopup;
		set
		{
			if (_hasContextPopup != value)
			{
				_hasContextPopup = value;
				SubscribeToLeftClickAsNeeded();
				SubscribeToRightClickAsNeeded();
			}
		}
	}
	private bool _hasContextPopup;

	private void SubscribeToContextMenuChanged(bool subscribe)
	{
		var descriptor = DependencyPropertyDescriptor.FromProperty(FrameworkElement.ContextMenuProperty, AssociatedType);
		if (descriptor is not null)
		{
			if (subscribe)
				descriptor.AddValueChanged(AssociatedObject, AssociatedObject_ContextMenuPropertyChanged);
			else
				descriptor.RemoveValueChanged(AssociatedObject, AssociatedObject_ContextMenuPropertyChanged);
		}
	}

	private void SubscribeToContextPopupChanged(bool subscribe)
	{
		var descriptor = DependencyPropertyDescriptor.FromProperty(MouseExtensions.ContextPopupProperty, AssociatedType);
		if (descriptor is not null)
		{
			if (subscribe)
				descriptor.AddValueChanged(AssociatedObject, AssociatedObject_ContextPopupPropertyChanged);
			else
				descriptor.RemoveValueChanged(AssociatedObject, AssociatedObject_ContextPopupPropertyChanged);
		}
	}

	private void SubscribeToLeftClick(bool subscribe)
	{
		if (this.isSubscribedToLeftClick != subscribe)
		{
			this.isSubscribedToLeftClick = subscribe;

			if (subscribe)
				MouseExtensions.AddLeftClickHandler(AssociatedObject, AssociatedObject_MouseLeftClick);
			else
				MouseExtensions.RemoveLeftClickHandler(AssociatedObject, AssociatedObject_MouseLeftClick);
		}
	}
	private bool isSubscribedToLeftClick;

	private void SubscribeToLeftClickAsNeeded()
	{
		var subscribe = (IsContextMenuOpenedOnLeftClick && HasContextMenu)
					 || (IsContextPopupOpenedOnLeftClick && HasContextPopup);
		SubscribeToLeftClick(subscribe);
	}

	private void SubscribeToRightClick(bool subscribe)
	{
		if (this.isSubscribedToRightClick != subscribe)
		{
			this.isSubscribedToRightClick = subscribe;

			if (subscribe)
				MouseExtensions.AddRightClickHandler(AssociatedObject, AssociatedObject_MouseRightClick);
			else
				MouseExtensions.RemoveRightClickHandler(AssociatedObject, AssociatedObject_MouseRightClick);
		}
	}
	private bool isSubscribedToRightClick;

	private void SubscribeToRightClickAsNeeded()
	{
		var subscribe = HasContextMenu || HasContextPopup;
		SubscribeToRightClick(subscribe);
	}

	private void OpenContextMenu(MouseButtonEventArgs e)
	{
		var contextMenu = AssociatedObject.ContextMenu;
		if (contextMenu is not null)
		{
			AssociatedObject.Dispatcher.BeginInvoke(() =>
			{
				e.Handled = true;
				contextMenu.SetCurrentValue(ContextMenu.IsOpenProperty, true);
			});
		}
	}

	private void OpenContextPopup(MouseButtonEventArgs e)
	{
		var contextPopup = MouseExtensions.GetContextPopupInternal(AssociatedObject);
		if (contextPopup is not null)
		{
			AssociatedObject.Dispatcher.BeginInvoke(() =>
			{
				contextPopup.Opened += this.ContextPopup_Opened;

				e.Handled = true;
				contextPopup.PlacementTarget = AssociatedObject;
				contextPopup.SetCurrentValue(Popup.IsOpenProperty, true);

			});
		}
	}

	private void ContextPopup_Opened(object? sender, EventArgs e)
	{
		//var contextPopup = (Popup)sender;
		//if (contextPopup.Child is not null)
		//{
		//    var focusSucceeded = contextPopup.Child.Focus();
		//    System.Diagnostics.Debug.WriteLine("OpenContextPopup: focusSucceeded=" + focusSucceeded);
		//}
	}

	#endregion Private Implementation

	#region Event Handlers

	private void AssociatedObject_ContextMenuPropertyChanged(object? sender, EventArgs e)
	{
		this.HasContextMenu = this.AssociatedObject is not null && this.AssociatedObject.ContextMenu is not null;
	}

	private void AssociatedObject_ContextPopupPropertyChanged(object? sender, EventArgs e)
	{
		this.HasContextPopup = this.AssociatedObject is not null
			&& MouseExtensions.GetContextPopupInternal(this.AssociatedObject) is not null;
	}

	private void AssociatedObject_MouseLeftClick(object? sender, MouseButtonEventArgs e)
	{
		if (this.IsContextMenuOpenedOnLeftClick)
			this.OpenContextMenu(e);
		if (this.IsContextPopupOpenedOnLeftClick)
			this.OpenContextPopup(e);
	}

	private void AssociatedObject_MouseRightClick(object? sender, MouseButtonEventArgs e)
	{
		if (this.IsContextMenuOpenedOnRightClick)
			this.OpenContextMenu(e);
		if (this.IsContextPopupOpenedOnRightClick)
			this.OpenContextPopup(e);
	}

	private void AssociatedObject_PreviewMouseRightButtonUp(object? sender, MouseButtonEventArgs e)
	{
		if (!this.AssociatedObject.IsMouseCaptured || !this.IsContextMenuOpenedOnRightClick)
		{
			var savedContextMenu = this.AssociatedObject.ContextMenu;
			this.SubscribeToContextMenuChanged(false);
			this.AssociatedObject.ContextMenu = null;
			this.AssociatedObject.Dispatcher.BeginInvoke(() =>
			{
				this.AssociatedObject.ContextMenu = savedContextMenu;
				this.SubscribeToContextMenuChanged(true);
			});
		}
	}

	#endregion Event Handlers

}

[Flags]
public enum ContextOpenMode : uint
{
	Disabled = 0x0,
	LeftButton = 0x1,
	RightButton = 0x2,
	LeftAndRightButtons = LeftButton | RightButton,
}
