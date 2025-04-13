using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Media;
using Tasler.Windows.Extensions;
using CommunityToolkit.Diagnostics;

namespace Tasler.Windows.Controls;

/// <summary>
/// </summary>
public class WindowPane : UserControl
{
	#region Instance Fields
	private bool _isClosing;
	private bool? _dialogResult;
	private DispatcherFrame? _dispatcherFrame;
	private List<IInputElement> _enabledSiblings = [];
	#endregion Instance Fields

	#region Construction
	public WindowPane()
	{
		this.SetDefaultStyleKey();
		base.InputBindings.Add(new KeyBinding(Commands.Cancel, Key.Escape, ModifierKeys.None));
		base.InputBindings.Add(new KeyBinding(Commands.Cancel, Key.Cancel, ModifierKeys.None));
		base.CommandBindings.Add(new CommandBinding(Commands.Cancel, this.Cancel_Executed));
		base.Loaded += this.This_Loaded;
	}
	#endregion Construction

	#region Properties
	public Grid? Owner
	{
		get => _owner;
		set => _owner = value; // TODO: Ensure the inited/opened/closed state is appropriate
	}
	private Grid? _owner;

	public bool? DialogResult
	{
		get => _dialogResult;
		set
		{
			if (_dialogResult != value)
			{
				_dialogResult = value;
				this.Close();
			}
		}
	}

	public bool IsModal => _dispatcherFrame is not null;

	#endregion Properties

	#region Dependency Properties

	#region IsClosed
	private static readonly DependencyPropertyKey IsClosedPropertyKey =
		DependencyProperty.RegisterReadOnly("IsClosed", typeof(bool), typeof(WindowPane),
			new FrameworkPropertyMetadata());

	public static readonly DependencyProperty IsClosedProperty =
		WindowPane.IsClosedPropertyKey.DependencyProperty;

	public bool IsClosed
	{
		get
		{
			return (bool)base.GetValue(WindowPane.IsClosedProperty);
		}
		private set
		{
			base.SetValue(WindowPane.IsClosedPropertyKey, value);
		}
	}
	#endregion IsClosed

	#endregion Dependency Properties

	#region Methods
	public void Close()
	{
		if (!_isClosing)
		{
			_isClosing = true;
			CancelEventArgs cancelEventArgs = new CancelEventArgs(false);
			this.OnClosing(cancelEventArgs);
			if (!cancelEventArgs.Cancel)
			{
				this.Owner?.Children.Remove(this);
				this.IsClosed = true;
				this.OnClosed(EventArgs.Empty);
				if (_dispatcherFrame is not null)
					_dispatcherFrame.Continue = false;
			}
			_isClosing = false;
		}
	}

	public void Show() => this.Show(true);

	public void Show(bool activate)
	{
		Guard.IsNotNull(this.Owner);

		this.Owner.Children.Add(this);
		this.Visibility = Visibility.Visible;

		if (activate)
			Keyboard.Focus(this);
	}

	public bool? ShowDialog()
	{
		this.Show();

		// Disable all enabled siblings
		_enabledSiblings ??= [];
		if (this.Owner is not null)
		{
			foreach (var sibling in this.Owner.Children.OfType<IInputElement>())
			{
				if (sibling != this && sibling.IsEnabled)
				{
					_enabledSiblings.Add(sibling);
					if (sibling is UIElement uiElement)
						uiElement.IsEnabled = false;
					else if (sibling is ContentElement contentElement)
						contentElement.IsEnabled = false;
					else if (sibling is UIElement3D uiElement3D)
						uiElement3D.IsEnabled = false;
				}
			}
		}

		// Enter a dispatcher frame (msg loop)
		_dispatcherFrame = new DispatcherFrame(true);
		Dispatcher.PushFrame(_dispatcherFrame);
		_dispatcherFrame = null;

		// Re-enable all siblings
		foreach (IInputElement sibling in _enabledSiblings)
		{
			if (sibling is UIElement uiElement)
				uiElement.IsEnabled = true;
			else if (sibling is ContentElement contentElement)
				contentElement.IsEnabled = true;
			else if (sibling is UIElement3D uiElement3D)
				uiElement3D.IsEnabled = true;
		}
		_enabledSiblings.Clear();

		// Return the dialog result
		return _dialogResult;
	}
	#endregion Methods

	#region Events
	public event CancelEventHandler? Closing;
	public event EventHandler? Closed;
	#endregion Events

	#region Overridables
	protected virtual void OnClosing(CancelEventArgs e)
	{
		// Raise the Closing event
		this.Closing?.Invoke(this, e);
	}

	protected virtual void OnClosed(EventArgs e)
	{
		// Raise the Closed event
		this.Closed?.Invoke(this, e);
	}
	#endregion Overridables

	#region Private Implementation
	private static void SetCommandOnButtons(DependencyObject d)
	{
		if (d is Button button)
		{
			if (button.Command is null && button.IsCancel)
				button.Command = Commands.Cancel;
		}

		foreach (var child in d.GetVisualChildren())
			SetCommandOnButtons(child);
	}
	#endregion Private Implementation

	#region Event Handlers
	private void This_Loaded(object sender, RoutedEventArgs e) => SetCommandOnButtons(this);
	#endregion Event Handlers

	#region Command Handlers
	protected void Cancel_Executed(object sender, ExecutedRoutedEventArgs e) => this.Close();
	#endregion Command Handlers

	#region Nested Types
	protected static class Commands
	{
		public static readonly RoutedCommand Cancel = new();
	}
	#endregion Nested Types
}
