#if WINDOWS_UWP
using CommunityToolkit.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
namespace Tasler.UI.Xaml.Extensions;
#elif WINDOWS_WPF
using System.Windows;
using System.Windows.Controls.Primitives;
namespace Tasler.Windows.Extensions;
#endif

/// <summary>
/// Provides extension methods for instances of the <see cref="Popup"/> type.
/// </summary>
public static partial class PopupExtensions
{
	#region Extension Methods
	/// <summary>
	/// Opens (shows) the specified <see cref="Popup"/>.
	/// </summary>
	/// <param name="popup">The <see cref="Popup"/> on which to set the <see cref="Popup.IsOpen"/> property.</param>
	/// <exception cref="ArgumentNullException">The <paramref name="popup"/> argument is <c>null</c>.</exception>
	public static void Open(this Popup popup) => popup.OpenOrClose(true);

	/// <summary>
	/// Closes (hides) the specified <see cref="Popup"/>.
	/// </summary>
	/// <param name="popup">The <see cref="Popup"/> on which to clear the <see cref="Popup.IsOpen"/> property.</param>
	/// <exception cref="ArgumentNullException">The <paramref name="popup"/> argument is <c>null</c>.</exception>
	public static void Close(this Popup popup) => popup.OpenOrClose(false);

	/// <summary>
	/// Gets the root element hosting the specified <see cref="Popup"/>.
	/// </summary>
	/// <param name="popup">The <see cref="Popup"/> for which to get the root <see cref="UIElement"/>.</param>
	/// <returns>The root element, if one can be found; otherwise <c>null</c>.</returns>
	public static UIElement? GetPopupRoot(this Popup popup)
	{
		var firstChild = popup.GetFirstChild();
		var topElement = firstChild?.GetVisualAncestors().OfType<UIElement>().LastOrDefault();
		return topElement;
	}

	#if WINDOWS_UWP
	/// <summary>
	/// Gets the first (top-most) child <see cref="UIElement"/> within the specified <see cref="Popup"/>.
	/// </summary>
	/// <param name="popup">The <see cref="Popup"/> for which to get the first (top-most)
	/// child <see cref="UIElement"/>.</param>
	/// <returns>The root element, if one can be found; otherwise <c>null</c>.</returns>
	public static UIElement? GetFirstChild(this Popup popup)
	{
		var firstChild = popup.GetVisualDescendantsDepthFirst().OfType<UIElement>().FirstOrDefault();
		return firstChild;
	}
	#elif WINDOWS_WPF

	/// <summary>
	/// Gets the first (top-most) child <see cref="UIElement"/> within the specified <see cref="Popup"/>.
	/// </summary>
	/// <param name="popup">The <see cref="Popup"/> for which to get the first (top-most)
	/// child <see cref="UIElement"/>.</param>
	/// <returns>The root element, if one can be found; otherwise <c>null</c>.</returns>
	public static UIElement? GetFirstChild(this Popup popup)
	{
		var firstChild = popup.GetLogicalDescendantsDepthFirst().OfType<UIElement>().FirstOrDefault();
		return firstChild;
	}
	#endif

	#endregion Extension Methods

	#region Private Implementation
	private static void OpenOrClose(this Popup popup, bool open)
	{
		popup.SetValue(Popup.IsOpenProperty, open);
	}
	#endregion Private Implementation
}
