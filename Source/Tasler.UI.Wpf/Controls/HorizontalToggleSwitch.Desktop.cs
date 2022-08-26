using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Tasler.Windows.Controls
{
	/// <summary>
	/// Horizontally oriented toggle switch control.
	/// </summary>
	public class HorizontalToggleSwitch : ToggleSwitchBase
	{
		#region Constructors
		static HorizontalToggleSwitch()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(
				typeof(HorizontalToggleSwitch), new FrameworkPropertyMetadata(typeof(HorizontalToggleSwitch)));
		}
		#endregion Constructors

		#region Overrides
		/// <summary>
		/// The current offset of the Thumb.
		/// </summary>
		protected override double Offset
		{
			get { return Canvas.GetLeft(SwitchThumb); }
			set
			{
				SwitchTrack.BeginAnimation(Canvas.LeftProperty, null);
				SwitchThumb.BeginAnimation(Canvas.LeftProperty, null);
				Canvas.SetLeft(SwitchTrack, value);
				Canvas.SetLeft(SwitchThumb, value);
			}
		}

		/// <summary>
		/// Gets the slide property path.
		/// </summary>
		protected override PropertyPath SlidePropertyPath
		{
			get { return new PropertyPath("(Canvas.Left)"); }
		}

		/// <summary>
		/// Raised while dragging the <see cref="Thumb/>.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void OnDragDelta(object sender, DragDeltaEventArgs e)
		{
			DragOffset += e.HorizontalChange;
			Offset = Math.Max(UncheckedOffset, Math.Min(CheckedOffset, DragOffset));
		}

		/// <summary>
		/// Raised when the dragging of the <see cref="Thumb"/> has completed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override ToggleGestureMode OnDragCompleted(object sender, DragCompletedEventArgs e)
		{
			IsDragging = false;
			var inputGesture = ToggleGestureMode.None;
			var fullThumbWidth = SwitchThumb.ActualWidth + SwitchThumb.BorderThickness.Left + SwitchThumb.BorderThickness.Right;

			if ((!IsChecked && DragOffset > (SwitchRoot.ActualWidth - fullThumbWidth) * (Elasticity - 1.0))
				|| (IsChecked && DragOffset < (SwitchRoot.ActualWidth - fullThumbWidth) * -Elasticity))
			{
				var edge = IsChecked ? CheckedOffset : UncheckedOffset;
				if (Offset != edge)
					inputGesture = ToggleGestureMode.Slide;
			}
			else if (DragOffset == CheckedOffset || DragOffset == UncheckedOffset)
			{
				inputGesture = ToggleGestureMode.Click;
			}
			else
			{
				ChangeCheckStates(true);
			}

			DragOffset = 0;

			return inputGesture;
		}

		/// <summary>
		/// Recalculates the layout of the control.
		/// </summary>
		protected override void LayoutControls()
		{
			if (SwitchThumb == null || SwitchRoot == null)
				return;

			var fullThumbWidth = SwitchThumb.ActualWidth + SwitchThumb.BorderThickness.Left + SwitchThumb.BorderThickness.Right;

			if (SwitchChecked != null && SwitchUnchecked != null)
			{
				SwitchChecked.Width = SwitchUnchecked.Width = Math.Max(0, SwitchRoot.ActualWidth - fullThumbWidth / 2);
				SwitchChecked.Padding = new Thickness(0, 0, (SwitchThumb.ActualWidth + SwitchThumb.BorderThickness.Left) / 2, 0);
				SwitchUnchecked.Padding = new Thickness((SwitchThumb.ActualWidth + SwitchThumb.BorderThickness.Right) / 2, 0, 0, 0);
			}

			SwitchThumb.Margin = new Thickness(SwitchRoot.ActualWidth - fullThumbWidth, SwitchThumb.Margin.Top, 0, SwitchThumb.Margin.Bottom);
			UncheckedOffset = -SwitchRoot.ActualWidth + fullThumbWidth - SwitchThumb.BorderThickness.Left;
			CheckedOffset = SwitchThumb.BorderThickness.Right;

			if (!IsDragging)
			{
				Offset = IsChecked ? CheckedOffset : UncheckedOffset;
				ChangeCheckStates(false);
			}
		}
		#endregion Overrides
	}
}
