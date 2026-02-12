using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using Microsoft.Xaml.Behaviors;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Attachments;

public sealed partial class PopupManagement
{
	private class PrivateBehavior : Behavior<FrameworkElement>
	{
		private Window? _window;

		protected override void OnAttached()
		{
			if (DesignerProperties.GetIsInDesignMode(AssociatedObject))
			{
				this.Detach();
				return;
			}

			_window = Window.GetWindow(AssociatedObject).GetSelfAndOwners().LastOrDefault();
			if (_window is not null)
			{
				this.NotifyWindowBehavior(_window);
			}
			else
			{
				Trace.WriteLineIf(AssociatedObject.IsLoaded, "How can IsLoaded be true, yet it is not in the logical tree of a Window?");
				this.AssociatedObject.Loaded += AssociatedObject_Loaded;
			}
		}

		protected override void OnDetaching()
		{
			if (_window is not null)
			{
				var windowBehavior = PopupManagement.GetPrivateWindowBehavior(_window);
				if (windowBehavior is not null)
					windowBehavior.RemovePopupBlockingElement(AssociatedObject);

				_window = null;
			}

			this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
		}

		private void NotifyWindowBehavior(Window window)
		{
			var windowBehavior = PopupManagement.GetPrivateWindowBehavior(window);
			if (windowBehavior is null)
				windowBehavior = new PrivateWindowBehavior(window);

			windowBehavior.AddPopupBlockingElement(AssociatedObject);
		}

		private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
		{
			Trace.WriteLineIf(this.AssociatedObject is null, "Not expecting AssociatedObject to be null. How did this happen?");

			var associatedObject = this.AssociatedObject ?? sender as FrameworkElement;
			if (associatedObject is not null)
			{
				if (_window is null)
				{
					_window = Window.GetWindow(this.AssociatedObject).GetSelfAndOwners().LastOrDefault();
					Trace.WriteLineIf(_window is null, "Not expecting this.window to be null. The FrameworkElement is loaded, so it should be in the logical tree of a Window.");

					if (_window != null)
						this.NotifyWindowBehavior(_window);
				}
			}
		}
	}
}
