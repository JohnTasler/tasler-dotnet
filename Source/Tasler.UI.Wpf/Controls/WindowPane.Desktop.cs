using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Media;

namespace Tasler.Windows.Controls
{
	/// <summary>
	/// </summary>
	public class WindowPane : UserControl
	{
		#region Instance Fields
		private Grid owner;
		private bool isClosing;
		private bool? dialogResult;
		private DispatcherFrame dispatcherFrame;
		private List<IInputElement> enabledSiblings;
		#endregion Instance Fields

		#region Construction
		static WindowPane()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(
				typeof(WindowPane), new FrameworkPropertyMetadata(typeof(WindowPane)));
		}

		public WindowPane()
		{
			base.InputBindings.Add(new KeyBinding(Commands.Cancel, Key.Escape, ModifierKeys.None));
			base.InputBindings.Add(new KeyBinding(Commands.Cancel, Key.Cancel, ModifierKeys.None));
			base.CommandBindings.Add(new CommandBinding(Commands.Cancel, this.Cancel_Executed));
			base.Loaded += this.this_Loaded;
		}
		#endregion Construction

		#region Properties
		public Grid Owner
		{
			get
			{
				return this.owner;
			}
			set
			{
				// TODO: Ensure the inited/opened/closed state is appropriate
				this.owner = value;
			}
		}

		public bool? DialogResult
		{
			get
			{
				return this.dialogResult;
			}
			set
			{
				if (this.dialogResult != value)
				{
					this.dialogResult = value;
					this.Close();
				}
			}
		}

		public bool IsModal
		{
			get
			{
				return this.dispatcherFrame != null;
			}
		}
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
			if (!this.isClosing)
			{
				this.isClosing = true;
				CancelEventArgs cancelEventArgs = new CancelEventArgs(false);
				this.OnClosing(cancelEventArgs);
				if (!cancelEventArgs.Cancel)
				{
					this.Owner.Children.Remove(this);
					this.IsClosed = true;
					this.OnClosed(EventArgs.Empty);
					if (this.dispatcherFrame != null)
						this.dispatcherFrame.Continue = false;
				}
				this.isClosing = false;
			}
		}

		public void Show()
		{
			this.Show(true);
		}

		public void Show(bool activate)
		{
			if (this.Owner == null)
				throw new InvalidOperationException(); // TODO: Get a string from resources

			this.Owner.Children.Add(this);
			this.Visibility = Visibility.Visible;

			if (activate)
				Keyboard.Focus(this);
		}

		public bool? ShowDialog()
		{
			this.Show();

			// Disable all enabled siblings
			if (this.enabledSiblings == null)
				this.enabledSiblings = new List<IInputElement>();
			foreach (IInputElement sibling in this.Owner.Children.OfType<IInputElement>())
			{
				if (sibling != this && sibling.IsEnabled)
				{
					this.enabledSiblings.Add(sibling);
					if (sibling is UIElement)
						((UIElement)sibling).IsEnabled = false;
					else if (sibling is ContentElement)
						((ContentElement)sibling).IsEnabled = false;
					else if (sibling is UIElement3D)
						((UIElement3D)sibling).IsEnabled = false;
				}
			}

			// Enter a dispatcher frame (msg loop)
			this.dispatcherFrame = new DispatcherFrame(true);
			Dispatcher.PushFrame(this.dispatcherFrame);
			this.dispatcherFrame = null;

			// Re-enable all siblings
			foreach (IInputElement sibling in this.enabledSiblings)
			{
				if (sibling is UIElement)
					((UIElement)sibling).IsEnabled = true;
				else if (sibling is ContentElement)
					((ContentElement)sibling).IsEnabled = true;
				else if (sibling is UIElement3D)
					((UIElement3D)sibling).IsEnabled = true;
			}
			this.enabledSiblings.Clear();

			// Return the dialog result
			return this.dialogResult;
		}
		#endregion Methods

		#region Events
		public event CancelEventHandler Closing;
		public event EventHandler Closed;
		#endregion Events

		#region Overridables
		protected virtual void OnClosing(CancelEventArgs e)
		{
			// Raise the Closing event
			if (this.Closing != null)
				this.Closing(this, e);
		}

		protected virtual void OnClosed(EventArgs e)
		{
			// Raise the Closed event
			if (this.Closed != null)
				this.Closed(this, e);
		}
		#endregion Overridables

		#region Private Implementation
		private void SetCommandOnButtons(DependencyObject d)
		{
			Button button = d as Button;
			if (button != null && button.Command == null && button.IsCancel)
				button.Command = Commands.Cancel;

			for (int index = 0; index < VisualTreeHelper.GetChildrenCount(d); ++index)
				this.SetCommandOnButtons(VisualTreeHelper.GetChild(d, index));
		}
		#endregion Private Implementation

		#region Event Handlers
		private void this_Loaded(object sender, RoutedEventArgs e)
		{
			this.SetCommandOnButtons(this);
		}
		#endregion Event Handlers

		#region Command Handlers
		protected void Cancel_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			this.Close();
		}
		#endregion Command Handlers

		#region Nested Types
		protected static class Commands
		{
			public static readonly RoutedCommand Cancel = new RoutedCommand();
		}
		#endregion Nested Types
	}
}
