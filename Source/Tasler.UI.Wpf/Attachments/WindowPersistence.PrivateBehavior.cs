using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using Microsoft.Xaml.Behaviors;
using Tasler.Windows.Model;
using Tasler.Windows.Threading;

namespace Tasler.Windows.Attachments;

public sealed partial class WindowPersistence
{
	private class PrivateBehavior : Behavior<Window>, ICountReferences
	{
		private int _referenceCount;

		/// <inheritdoc/>
		public int Add() => ++_referenceCount;

		/// <inheritdoc/>
		public int Release() => _referenceCount = Math.Max(--_referenceCount, 0);

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

			if (HwndSource.FromVisual(this.AssociatedObject) is not HwndSource source || source.Handle != nint.Zero)
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
			using (var action = _action)
				_action = null;
		}

		private void AssociatedObject_SourceInitialized(object? sender, EventArgs e)
		{
			if (HwndSource.FromVisual(this.AssociatedObject) is HwndSource source && source.Handle != nint.Zero)
			{
				if (this.Placement is WindowPlacementModel placement)
				{
					placement.Set(source.Handle);
				}
				else
				{
					placement = new WindowPlacementModel();
					placement.Get(source.Handle);
					this.Placement = placement;
				}
			}
		}

		private void AssociatedObject_PlacementChanged(object? sender, EventArgs e)
		{
			_action?.Trigger();
		}

		private void AssociatedObject_Closed(object? sender, EventArgs e) => this.Detach();

		private void UpdatePlacement()
		{
			var placement = this.Placement;
			if (placement is not null
				&& HwndSource.FromVisual(this.AssociatedObject) is HwndSource source
				&& source.Handle != nint.Zero)
			{
				placement.Get(source.Handle);
			}
		}

		private WindowPlacementModel? Placement
		{
			get => GetPlacement(AssociatedObject);
			set
			{
				if (AssociatedObject.ReadLocalValue(PlacementProperty) is BindingExpression binding)
				{
					SetPlacement(AssociatedObject, value);
					binding.UpdateSource();
				}
			}
		}

		private DispatcherTimerDeferredAction? _action;
	}
}
