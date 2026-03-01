using System.ComponentModel;
using System.Windows;
using System.Windows.Interop;
using Microsoft.Xaml.Behaviors;
using Tasler.Windows.Model;
using Tasler.Windows.Threading;

namespace Tasler.Windows.Attachments;

public sealed partial class WindowPersistence
{
	private class PrivateBehavior : Behavior<Window>
	{
		protected override void OnAttached()
		{
			if (this.AssociatedObject is null)
				return;

			if (DesignerProperties.GetIsInDesignMode(AssociatedObject))
			{
				this.Detach();
				return;
			}

			this.AssociatedObject.SourceInitialized += this.AssociatedObject_SourceInitialized;
			this.AssociatedObject.StateChanged += this.AssociatedObject_PlacementChanged;
			this.AssociatedObject.SizeChanged += this.AssociatedObject_PlacementChanged;
			this.AssociatedObject.LocationChanged += this.AssociatedObject_PlacementChanged;
			this.AssociatedObject.Closed += this.AssociatedObject_Closed;

			if (HwndSource.FromVisual(this.AssociatedObject) is HwndSource source && source.Handle != nint.Zero)
				this.AssociatedObject_SourceInitialized(this.AssociatedObject, EventArgs.Empty);

			_action = new DispatcherTimerDeferredAction(TimeSpan.FromSeconds(2), this.UpdatePlacement);
		}

		protected override void OnDetaching()
		{
			this.AssociatedObject.SourceInitialized -= this.AssociatedObject_SourceInitialized;
			this.AssociatedObject.StateChanged -= this.AssociatedObject_PlacementChanged;
			this.AssociatedObject.SizeChanged -= this.AssociatedObject_PlacementChanged;
			this.AssociatedObject.LocationChanged -= this.AssociatedObject_PlacementChanged;
			this.AssociatedObject.Closed -= this.AssociatedObject_Closed;
			_action?.Expire();
			_action = null;
		}

		private void AssociatedObject_SourceInitialized(object? sender, EventArgs e)
		{
			if (this.Placement is WindowPlacementModel placement
				&& HwndSource.FromVisual(this.AssociatedObject) is HwndSource source
				&& source.Handle != nint.Zero)
			{
				placement.Set(new() { Handle = source.Handle });
			}
		}

		private void AssociatedObject_PlacementChanged(object? sender, EventArgs e)
		{
			_action?.Trigger();
		}

		private void AssociatedObject_Closed(object? sender, EventArgs e) => this.Detach();

		private void UpdatePlacement()
		{
			var placement = this.Placement ??= new WindowPlacementModel();
			if (placement is not null
				&& HwndSource.FromVisual(this.AssociatedObject) is HwndSource source
				&& source.Handle != nint.Zero)
			{
				placement.Get(new() { Handle = source.Handle });
				this.Placement = placement;
			}
		}

		private WindowPlacementModel? Placement
		{
			get => GetPlacement(AssociatedObject);
			set => SetPlacement(AssociatedObject, value);
		}
		private DispatcherTimerDeferredAction? _action;
	}
}
