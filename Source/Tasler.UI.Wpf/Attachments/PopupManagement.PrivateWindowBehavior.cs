using System.Windows;
using System.Windows.Controls.Primitives;
using CommunityToolkit.Diagnostics;
using Microsoft.Xaml.Behaviors;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Attachments;

public sealed partial class PopupManagement
{
	private class PrivateWindowBehavior : Behavior<Window>
	{
		private HashSet<FrameworkElement> _popupBlockingElements = [];
		private List<Popup> _popupsToRestore = [];
		private List<Window> _windowsToRestore = [];
		private Window? _activeWindowOnRestore;

		public PrivateWindowBehavior(Window associatedObject)
		{
			this.Attach(associatedObject);
		}

		public void AddPopupBlockingElement(FrameworkElement element)
		{
			Guard.IsNotNull(element);
			if (_popupBlockingElements.Contains(element))
				throw new InvalidOperationException("TODO: Unexpected internal state");

			_popupBlockingElements.Add(element);

			this.ArePopupsBlocked = true;
		}

		public void RemovePopupBlockingElement(FrameworkElement element)
		{
			Guard.IsNotNull(element);
			if (!_popupBlockingElements.Remove(element))
				throw new InvalidOperationException("TODO: Unexpected internal state");

			this.ArePopupsBlocked = _popupBlockingElements.Count != 0;
		}

		public void BlockPopup(Popup popup)
		{
			if (!_popupsToRestore.Contains(popup))
			{
				_popupsToRestore.Add(popup);

				var topElement = popup.GetPopupRoot();
				if (topElement is not null)
					topElement.Visibility = Visibility.Collapsed;
			}
		}

		private void UnblockPopup(Popup popup)
		{
			var topElement = popup.GetPopupRoot();
			if (topElement is not null)
				topElement.Visibility = Visibility.Visible;
		}

		public void BlockWindow(Window window)
		{
			_windowsToRestore.Add(window);
			if (window.IsActive)
				_activeWindowOnRestore = window;
			window.Hide();
		}

		private void UnblockWindow(Window window)
		{
			window.Show();
		}

		protected override void OnAttached()
		{
			base.OnAttached();

			PopupManagement.SetPrivateWindowBehavior(AssociatedObject, this);
		}

		protected override void OnDetaching()
		{
			base.OnDetaching();

			PopupManagement.SetPrivateWindowBehavior(AssociatedObject, null);
		}

		private void UpdateArePopupsBlocked()
		{
			this.ArePopupsBlocked = _popupBlockingElements.Count != 0;
		}

		public bool ArePopupsBlocked
		{
			get => _arePopupsBlocked;
			private set
			{
				if (_arePopupsBlocked != value)
				{
					_arePopupsBlocked = value;

					var isOpen = !_arePopupsBlocked;
					var windows = new List<Window>(AssociatedObject.OwnedWindows.OfType<Window>()) { AssociatedObject };
					if (_arePopupsBlocked)
					{
						foreach (var window in windows)
						{
							// Find all descendant Popup's that are open
							var logicalPopups = window.GetLogicalDescendantsDepthFirst().OfType<Popup>().Where(p => p.IsOpen);
							var visualPopups = window.GetVisualDescendantsDepthFirst().OfType<Popup>().Where(p => p.IsOpen);

							// Using the ToList method to execute/snapshot the IEnumerable
							var affectedPopups = logicalPopups.Union(visualPopups).Where(p => !PopupManagement.GetIsAlwaysAllowedToOpen(p)).ToList();
							foreach (var popup in affectedPopups)
								this.BlockPopup(popup);

							PopupManagement.SetArePopupsBlocked(window, true);

							if (window.Owner is not null && window.IsVisible && !PopupManagement.GetIsAlwaysAllowedToOpen(window))
								this.BlockWindow(window);
						}
					}
					else
					{
						foreach (var window in windows)
							PopupManagement.SetArePopupsBlocked(window, null);

						foreach (var window in _windowsToRestore)
							this.UnblockWindow(window);
						_windowsToRestore.Clear();

						if (_activeWindowOnRestore is not null)
						{
							_activeWindowOnRestore.Activate();
							_activeWindowOnRestore = null;
						}

						// Restore (open) each affected popup
						foreach (var popup in _popupsToRestore)
							this.UnblockPopup(popup);
						_popupsToRestore.Clear();
					}

					// Detach ourself if our behavior is no longer needed
					if (isOpen)
						this.Detach();
				}
			}
		}
		private bool _arePopupsBlocked;
	}
}
