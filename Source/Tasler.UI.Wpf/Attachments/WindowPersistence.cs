using System.Configuration;
using System.Windows;
using System.Windows.Interop;
using CommunityToolkit.Diagnostics;
using Tasler.Configuration;
using Tasler.Interop.User;
using Tasler.Windows.Extensions;
using Tasler.Windows.Model;

namespace Tasler.Windows.Attachments;

using APFactory = Tasler.Windows.AttachedPropertyFactory<WindowPersistence>;

public sealed partial class WindowPersistence
{
	private WindowPersistence() {}

	#region Attached Properties

	#region PrivateBehavior

	/// <summary>
	/// Identifies the <see cref="PrivateBehavior"/> dependency property key.
	/// </summary>
	private static readonly DependencyPropertyKey PrivateBehaviorPropertyKey =
		APFactory.RegisterReadOnly<PrivateBehavior>("PrivateBehavior");

	#endregion PrivateBehavior

	#region Placement

	/// <summary>
	/// Identifies the <c>Placement</c> attached property.
	/// </summary>
	public static readonly DependencyProperty PlacementProperty =
		APFactory.Register<WindowPlacementModel>("Placement", PlacementPropertyChanged);

	/// <summary>
	/// Gets the instance of the <see cref="WindowPlacementModel"/> class.
	/// </summary>
	/// <param name="element">The <see cref="Window"/> for which to get the property value.</param>
	/// <returns>An instance of the <see cref="WindowPlacementModel"/> class.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="element"/> is <see langword="null"/>.</exception>
	public static WindowPlacementModel GetPlacement(Window element)
	{
		Guard.IsNotNull(element);
		return (WindowPlacementModel)element.GetValue(PlacementProperty);
	}

	/// <summary>
	/// Sets the instance of the <see cref="WindowPlacementModel"/> class.
	/// </summary>
	/// <param name="element">The <see cref="Window"/> for which to set the property value.</param>
	/// <param name="value">An instance of the <see cref="WindowPlacementModel"/> class.</param>
	/// <exception cref="ArgumentNullException"><paramref name="element"/> is <see langword="null"/>.</exception>
	public static void SetPlacement(Window element, WindowPlacementModel? value)
	{
		Guard.IsNotNull(element);
		element.SetValue(PlacementProperty, value);
	}

	private static void PlacementPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		PrivateBehaviorPropertyKey.BehaviorPropertyChanged<Window, PrivateBehavior,(d, e);
		if (d is Window window)
		{
			if (e.NewValue is WindowPlacementModel placement)
			{
				AttachedBehaviorExtensions.

			}
			else
			{

			}
		}
	}

	#endregion Placement

	#endregion Attached Properties
}
