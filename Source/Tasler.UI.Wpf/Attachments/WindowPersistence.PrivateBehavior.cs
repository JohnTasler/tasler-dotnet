using System.Configuration;
using System.Windows;
using System.Windows.Interop;
using CommunityToolkit.Diagnostics;
using Microsoft.Xaml.Behaviors;
using Tasler.Configuration;
using Tasler.Windows.Model;

namespace Tasler.Windows.Attachments;

public static partial class WindowPersistence
{
	private class PrivateBehavior : Behavior<Window>
	{
		protected override void OnAttached()
		{
			if (this.AssociatedObject is null)
				return;

			this.AssociatedObject.SourceInitialized -= this.AssociatedObject_SourceInitialized;
			this.AssociatedObject.StateChanged -= this.AssociatedObject_PlacementChanged;
			this.AssociatedObject.SizeChanged -= this.AssociatedObject_PlacementChanged;
			this.AssociatedObject.LocationChanged -= this.AssociatedObject_PlacementChanged;
			this.AssociatedObject.Closed -= this.AssociatedObject_Closed;
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
			var placement = this.Placement;
			if (placement is null)
				this.Placement = placement = new WindowPlacementModel();

			if (placement is not null
				&& HwndSource.FromVisual(this.AssociatedObject) is HwndSource source
				&& source.Handle != nint.Zero)
			{
				placement.Get(new() { Handle = source.Handle });
			}
		}

		private void AssociatedObject_Closed(object? sender, EventArgs e)
		{
			this.AssociatedObject.SourceInitialized -= this.AssociatedObject_SourceInitialized;
			this.AssociatedObject.StateChanged -= this.AssociatedObject_PlacementChanged;
			this.AssociatedObject.SizeChanged -= this.AssociatedObject_PlacementChanged;
			this.AssociatedObject.LocationChanged -= this.AssociatedObject_PlacementChanged;
			this.AssociatedObject.Closed -= this.AssociatedObject_Closed;

			GetSettings(this.AssociatedObject)?.ExpireAutoSaveDeferral();
		}

		private WindowPlacementModel? Placement
		{
			get
			{
				if (WindowPersistence.GetSettings(this.AssociatedObject) is ApplicationSettingsBase settings
					&& WindowPersistence.GetKey(this.AssociatedObject) is string key)
				{
					return settings[key] is WindowPlacementModel placement
						? placement
						: null;
				}

				return null;
			}
			set
			{
				Guard.IsNotNull(value);

				if (WindowPersistence.GetSettings(this.AssociatedObject) is ApplicationSettingsBase settings
					&& WindowPersistence.GetKey(this.AssociatedObject) is string key)
				{
					settings[key] = value;
				}
				else
				{
					throw new NotSupportedException("");
				}
			}
		}
	}
}
