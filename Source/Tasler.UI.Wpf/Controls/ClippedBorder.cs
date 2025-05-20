using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CommunityToolkit.Diagnostics;
using Tasler.Windows.Media;

namespace Tasler.Windows.Controls;

public sealed class ClippedBorder : Border
{
	#region Construction
	/// <summary>
	/// Initializes a new instance of the <see cref="ClippedBorder"/> class.
	/// </summary>
	public ClippedBorder()
	{
	}
	#endregion Construction

	#region Private Implementation
	private Geometry? GenerateChildClipGeometry(Size finalSize)
	{
		Guard.IsNotNull(this.Child);

		CornerRadius cornerRadius = base.CornerRadius;
		if (cornerRadius.TopLeft == 0.0 && cornerRadius.BottomLeft == 0.0
		 && cornerRadius.TopRight == 0.0 && cornerRadius.BottomRight == 0.0)
			return null;

		Rect bounds = new Rect(finalSize);
		GeneralTransform tranform = base.TransformToDescendant(base.Child);
		Rect childBounds = tranform.TransformBounds(bounds);

		Geometry geometry = GeometryBuilder.BuildRoundedRectangle(
			childBounds.Deflate(base.BorderThickness), base.CornerRadius, base.BorderThickness, false);
		geometry.Freeze();

		return geometry;
	}
	#endregion Private Implementation

	#region Overrides
	protected override Size ArrangeOverride(Size finalSize)
	{
		// Perform default processing
		Size arrangedSize = base.ArrangeOverride(finalSize);

		// Clip the child element to its interior
		if (base.Child != null)
			base.Child.Clip = this.GenerateChildClipGeometry(arrangedSize);

		// Return the arranged size
		return arrangedSize;
	}
	#endregion Overrides
}
