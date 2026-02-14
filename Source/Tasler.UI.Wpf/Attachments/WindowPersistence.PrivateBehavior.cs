using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Interop;
using CommunityToolkit.Diagnostics;
using Microsoft.Xaml.Behaviors;
using Tasler.Configuration;
using Tasler.Windows.Model;

namespace Tasler.Windows.Attachments;

public sealed partial class WindowPersistence
{
	private class PrivateBehavior : Behavior<Window>, ICountReferences
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
		}

		private void AssociatedObject_SourceInitialized(object? sender, EventArgs e)
		{
			if (this.Placement is WindowPlacementModel placement
				&& HwndSource.FromVisual(this.AssociatedObject) is HwndSource source
				&& source.Handle != nint.Zero)
			{
				placement.Set(new() { Handle = source.Handle });
				_isSourceInitialized = true;
			}
		}

		private void AssociatedObject_PlacementChanged(object? sender, EventArgs e)
		{
			if (!_isSourceInitialized)
				return;

			var placement = this.Placement;
			if (placement is null)
				this.Placement = placement = new WindowPlacementModel();

			if (placement is not null
				&& HwndSource.FromVisual(this.AssociatedObject) is HwndSource source
				&& source.Handle != nint.Zero)
			{
				placement.Get(new() { Handle = source.Handle });
				this.Placement = placement;
			}
		}

		private void AssociatedObject_Closed(object? sender, EventArgs e)
		{
			this.AssociatedObject.SourceInitialized -= this.AssociatedObject_SourceInitialized;
			this.AssociatedObject.StateChanged -= this.AssociatedObject_PlacementChanged;
			this.AssociatedObject.SizeChanged -= this.AssociatedObject_PlacementChanged;
			this.AssociatedObject.LocationChanged -= this.AssociatedObject_PlacementChanged;
			this.AssociatedObject.Closed -= this.AssociatedObject_Closed;

			GetSettings(this.AssociatedObject)?.ExpireAndClearAutoSaveDeferral();
		}

		/// <inheritdoc/>
		public int Add() => ++_referenceCount;

		/// <inheritdoc/>
		public int Release() => _referenceCount = Math.Max(--_referenceCount, 0);

		private int _referenceCount;

		private WindowPlacementModel? Placement
		{
			get
			{
				if (WindowPersistence.GetSettings(this.AssociatedObject) is ApplicationSettingsBase settings
					&& WindowPersistence.GetKey(this.AssociatedObject) is string key)
				{
					if (settings.Properties.OfType<SettingsProperty>().Any(p => p.Name.Equals(key, StringComparison.OrdinalIgnoreCase)))
					{
						return settings[key] is WindowPlacementModel placement
							? placement
							: null;
					}
				}

				return new WindowPlacementModel();
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
					throw new NotSupportedException(Properties.Resources.IncorrectUseOfWindowPersistence);
				}
			}
		}

		private bool _isSourceInitialized;
	}
}
