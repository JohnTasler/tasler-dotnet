using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Controls
{
	public partial class Popup : System.Windows.Controls.Primitives.Popup
	{
		#region Instance Fields
		private MouseButtonEventArgs captureLostMouseDownArgs;
		private IInputElement previouslyFocusedElement;
		#endregion Instance Fields

		#region Constructors
		static Popup()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Popup),
				new FrameworkPropertyMetadata(typeof(Popup), FrameworkPropertyMetadataOptions.AffectsMeasure));
		}

		public Popup()
		{
			this.InputBindings.Add(new KeyBinding(CloseCommand, Key.Escape, ModifierKeys.None));
		}
		#endregion Constructors

		#region Attached Properties

		/// <summary>
		/// Identifies the <see cref="GetStaysOpenOnClick">StaysOpenOnClick</see> attached property.
		/// </summary>
		public static readonly DependencyProperty StaysOpenOnClickProperty =
			DependencyProperty.RegisterAttached("StaysOpenOnClick", typeof(bool), typeof(Popup),
				new PropertyMetadata(true, StaysOpenOnClickPropertyChanged));

		/// <summary>
		/// Gets the <see cref="GetStaysOpenOnClick">StaysOpenOnClick</see> attached property value.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <returns></returns>
		public static bool GetStaysOpenOnClick(FrameworkElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			return (bool)element.GetValue(StaysOpenOnClickProperty);
		}

		public static void SetStaysOpenOnClick(FrameworkElement element, bool value)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			element.SetValue(StaysOpenOnClickProperty, value);
		}

		private static void StaysOpenOnClickPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var element = (FrameworkElement)d;
			var newValue = (bool)e.NewValue;

			MouseButtonEventHandler handler = (s, e2) =>
			{
				var popup = d.GetLogicalAncestors().OfType<System.Windows.Controls.Primitives.Popup>().FirstOrDefault();
				if (popup != null)
					popup.Close();
			};

			var buttonBase = d as ButtonBase;
			if (buttonBase != null)
			{
				if (!newValue)
					buttonBase.AddHandler(ButtonBase.ClickEvent, handler, true);
				else
					buttonBase.RemoveHandler(ButtonBase.ClickEvent, handler);
			}
			else
			{
				if (!newValue)
					element.AddHandler(UIElement.MouseUpEvent, handler, true);
				else
					element.RemoveHandler(UIElement.MouseUpEvent, handler);
			}
		}

		#endregion Attached Properties

		#region Commands

		public ICommand CloseCommand
		{
			get { return this.closeCommand ?? (this.closeCommand = new DelegateCommand(() => this.Close())); }
		}
		private DelegateCommand closeCommand;

		#endregion Commands

		#region Routed Events

		#region Opened
		public static readonly RoutedEvent OpenedEvent =
			EventManager.RegisterRoutedEvent("Opened", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(Popup));
		#endregion Opened

		#endregion Routed Events

		#region Overrides

		protected override void OnGotFocus(RoutedEventArgs e)
		{
			base.OnGotFocus(e);
		}

		protected override void OnOpened(EventArgs e)
		{
			// Default processing raises the CLR event
			base.OnOpened(e);

			// Raise the RoutedEvent
			var args = new RoutedEventArgs(OpenedEvent);
			RaiseEvent(args);
			if (args.Handled)
				return;

			// Save the keyboard focused element
			this.previouslyFocusedElement = Keyboard.FocusedElement;

			// Set focus on the first focusable descendant
			var firstFocusableDescendant =
				this.GetLogicalDescendantsRecursive().OfType<UIElement>().Where(u => u.Focusable).FirstOrDefault();
			if (firstFocusableDescendant != null)
				firstFocusableDescendant.Focus();
		}

		protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
		{
			Debug.WriteLine("Popup.OnPreviewDown: IsMouseOutsideMe={0}", IsMouseOutsideMe(e));

			// TODO: See if we can re-enable this feature without crashing on Window.DragMove.
			// TODO: Perhaps control it with a bool property of PassThroughOnCloseClick (bad name)
			// Save the event arguments if the mouse down was outside our own bounds
			this.captureLostMouseDownArgs = (!StaysOpen && IsMouseOutsideMe(e)) ? e : null;

			// Perform default processing
			base.OnPreviewMouseDown(e);
		}

		protected override void OnMouseDown(MouseButtonEventArgs e)
		{
			this.Focus();
			base.OnMouseDown(e);
		}

		protected override void OnClosed(EventArgs e)
		{
			Debug.WriteLine("Popup.OnClosed: this.captureLostMouseDownArgs={0} Mouse.LeftButton={1}",
				this.captureLostMouseDownArgs.FormatNameAndType(),
				Mouse.LeftButton);

			// Check if we're closing due to a mouse down outside our bounds
			if (this.captureLostMouseDownArgs != null && Mouse.LeftButton == MouseButtonState.Pressed)
			{
				// Must do this while Mouse.LeftButton == MouseButtonState.Pressed or else Window.DragMove() will throw

				//Dispatcher.BeginInvoke(() =>
				//{
				// Copy event args for the PreviewMouseDown and MouseDown routed events
				var args = new MouseButtonEventArgs(
					this.captureLostMouseDownArgs.MouseDevice,
					this.captureLostMouseDownArgs.Timestamp,
					this.captureLostMouseDownArgs.ChangedButton);
				args.RoutedEvent = PreviewMouseDownEvent;

				// Hit-test the position of the mouse down event that caused the Popup to close
				var firstChild = this.GetFirstChild();
				Debug.WriteLine("Popup.OnClosed: firstChild={0}", firstChild.FormatNameAndType());
				if (firstChild != null)
				{
					var window = Window.GetWindow(firstChild);
					if (window != null)
					{
						// TODO: hit test until source is non-null, iterating through all Owned, Owners, and Application.Windows

						var position = this.captureLostMouseDownArgs.GetPosition(window);
						var originalSource = window.InputHitTest(position);
						Debug.WriteLine("Popup.OnClosed: window={0} position={1} originalSource={2}",
							window.FormatNameAndType(), position.Round(), originalSource.FormatNameAndType());

						if (originalSource != null)
						{
							args.Source = originalSource;

							// Raise the (tunneling) PreviewMouseDownEvent to the original source
							originalSource.RaiseEvent(args);

							// If not handled, raise the (bubbling) MouseDownEvent to the original source
							if (!args.Handled)
							{
								args.RoutedEvent = MouseDownEvent;
								originalSource.RaiseEvent(args);
							}
						}
					}
				}

				// Clear the mouse down event args that caused us to lose capture
				this.captureLostMouseDownArgs = null;
				//});
			}

			// Restore the previously focused element
			if (this.previouslyFocusedElement != null)
				Keyboard.Focus(this.previouslyFocusedElement);

			// Perform default processing
			base.OnClosed(e);
		}

		#endregion Overrides

		#region Private Implementation
		private bool IsMouseOutsideMe(MouseEventArgs e)
		{
			// Determine if the specified mouse event was outside our own bounds or not
			var popupRoot = this.GetPopupRoot();
			if (popupRoot == null)
				return false;

			var source = popupRoot.InputHitTest(e.GetPosition(popupRoot)) as DependencyObject;
			Debug.WriteLine("Popup.IsMouseOutsideMe: source={0} position={1}", source.FormatNameAndType(), e.GetPosition(this));

			return source == null || !source.GetVisualAncestors().Contains(popupRoot);
		}
		#endregion Private Implementation
	}
}
