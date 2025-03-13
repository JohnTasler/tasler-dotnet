using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Microsoft.Xaml.Behaviors;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Attachments
{
	public static partial class PopupManagement
	{
		private class PrivateBehavior : Behavior<FrameworkElement>
		{
			private Window window;

			protected override void OnAttached()
			{
				base.OnAttached();

				if (DesignerProperties.GetIsInDesignMode(AssociatedObject))
				{
					this.Detach();
					return;
				}

				this.window = Window.GetWindow(AssociatedObject).GetSelfAndOwners().LastOrDefault();
				if (this.window != null)
				{
					this.NotifyWindowBehavior(this.window);
				}
				else
				{
					Trace.WriteLineIf(AssociatedObject.IsLoaded, "How can IsLoaded be true, yet it is not in the logical tree of a Window?");
					this.AssociatedObject.Loaded += AssociatedObject_Loaded;
				}
			}

			protected override void OnDetaching()
			{
				base.OnDetaching();

				if (this.window != null)
				{
					var windowBehavior = PopupManagement.GetPrivateWindowBehavior(this.window);
					if (windowBehavior != null)
						windowBehavior.RemovePopupBlockingElement(AssociatedObject);

					this.window = null;
				}

				this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
			}

			private void NotifyWindowBehavior(Window window)
			{
				var windowBehavior = PopupManagement.GetPrivateWindowBehavior(window);
				if (windowBehavior == null)
					windowBehavior = new PrivateWindowBehavior(window);

				windowBehavior.AddPopupBlockingElement(AssociatedObject);
			}

			private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
			{
				Trace.WriteLineIf(this.AssociatedObject == null, "Not expecting AssociatedObject to be null. How did this happen?");

				var associatedObject = this.AssociatedObject ?? sender as FrameworkElement;
				if (associatedObject != null)
				{
					if (this.window == null)
					{
						this.window = Window.GetWindow(this.AssociatedObject).GetSelfAndOwners().LastOrDefault();
						Trace.WriteLineIf(this.window == null, "Not expecting this.window to be null. The FrameworkElement is loaded, so it should be in the logical tree of a Window.");

						if (this.window != null)
							this.NotifyWindowBehavior(this.window);
					}
				}
			}
		}
	}
}
