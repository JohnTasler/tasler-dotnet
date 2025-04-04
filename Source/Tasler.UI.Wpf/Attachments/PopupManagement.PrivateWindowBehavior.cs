using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using Microsoft.Xaml.Behaviors;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Attachments
{
	public static partial class PopupManagement
	{
		private class PrivateWindowBehavior : Behavior<Window>
		{
			private HashSet<FrameworkElement> popupBlockingElements = new HashSet<FrameworkElement>();
			private List<Popup> popupsToRestore = new List<Popup>();
			private List<Window> windowsToRestore = new List<Window>();
			private Window activeWindowOnRestore;

			public PrivateWindowBehavior(Window associatedObject)
			{
				this.Attach(associatedObject);
			}

			public void AddPopupBlockingElement(FrameworkElement element)
			{
				if (element == null)
					throw new ArgumentNullException("element");
				if (this.popupBlockingElements.Contains(element))
					throw new InvalidOperationException("TODO: Unexpected internal state");

				this.popupBlockingElements.Add(element);

				this.ArePopupsBlocked = true;
			}

			public void RemovePopupBlockingElement(FrameworkElement element)
			{
				if (element == null)
					throw new ArgumentNullException("element");
				if (!this.popupBlockingElements.Remove(element))
					throw new InvalidOperationException("TODO: Unexpected internal state");

				this.ArePopupsBlocked = this.popupBlockingElements.Count != 0;
			}

			public void BlockPopup(Popup popup)
			{
				if (!this.popupsToRestore.Contains(popup))
				{
					this.popupsToRestore.Add(popup);

					var topElement = popup.GetPopupRoot();
					if (topElement != null)
						topElement.Visibility = Visibility.Collapsed;
				}
			}

			private void UnblockPopup(Popup popup)
			{
				var topElement = popup.GetPopupRoot();
				if (topElement != null)
					topElement.Visibility = Visibility.Visible;
			}

			public void BlockWindow(Window window)
			{
				this.windowsToRestore.Add(window);
				if (window.IsActive)
					this.activeWindowOnRestore = window;
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
				this.ArePopupsBlocked = this.popupBlockingElements.Count != 0;
			}

			public bool ArePopupsBlocked
			{
				get { return this.arePopupsBlocked; }
				private set
				{
					if (this.arePopupsBlocked != value)
					{
						this.arePopupsBlocked = value;

						var isOpen = !this.arePopupsBlocked;
						var windows = new List<Window>(AssociatedObject.OwnedWindows.OfType<Window>()) { AssociatedObject };
						if (this.arePopupsBlocked)
						{
							foreach (var window in windows)
							{
								// Find all descendant Popup's that are open
								var logicalPopups = window.GetLogicalDescendantsRecursive().OfType<Popup>().Where(p => p.IsOpen);
								var visualPopups = window.GetVisualDescendantsDepthFirst().OfType<Popup>().Where(p => p.IsOpen);

								// Using the ToList method to execute/snapshot the IEnumerable
								var affectedPopups = logicalPopups.Union(visualPopups).Where(p => !PopupManagement.GetIsAlwaysAllowedToOpen(p)).ToList();
								foreach (var popup in affectedPopups)
									this.BlockPopup(popup);

								PopupManagement.SetArePopupsBlocked(window, true);

								if (window.Owner != null && window.IsVisible && !PopupManagement.GetIsAlwaysAllowedToOpen(window))
									this.BlockWindow(window);
							}


						}
						else
						{
							foreach (var window in windows)
								PopupManagement.SetArePopupsBlocked(window, null);

							foreach (var window in this.windowsToRestore)
								this.UnblockWindow(window);
							this.windowsToRestore.Clear();

							if (this.activeWindowOnRestore != null)
							{
								this.activeWindowOnRestore.Activate();
								this.activeWindowOnRestore = null;
							}

							// Restore (open) each affected popup
							foreach (var popup in this.popupsToRestore)
								this.UnblockPopup(popup);
							this.popupsToRestore.Clear();
						}

						// Detach ourself if our behavior is no longer needed
						if (isOpen)
							this.Detach();
					}
				}
			}
			private bool arePopupsBlocked;
		}
	}
}
