using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Tasler.Windows.Extensions
{
	/// <summary>
	/// Provides extension methods for instances of the <see cref="Popup"/> type.
	/// </summary>
	public static class PopupExtensions
	{
		#region Extension Methods
		/// <summary>
		/// Opens (shows) the specified <see cref="Popup"/>.
		/// </summary>
		/// <param name="popup">The <see cref="Popup"/> on which to set the <see cref="Popup.IsOpen"/> property.</param>
		/// <exception cref="ArgumentNullException">The <paramref name="popup"/> argument is <c>null</c>.</exception>
		public static void Open(this Popup popup)
		{
			OpenOrClose(popup, true);
		}

		/// <summary>
		/// Closes (hides) the specified <see cref="Popup"/>.
		/// </summary>
		/// <param name="popup">The <see cref="Popup"/> on which to clear the <see cref="Popup.IsOpen"/> property.</param>
		/// <exception cref="ArgumentNullException">The <paramref name="popup"/> argument is <c>null</c>.</exception>
		public static void Close(this Popup popup)
		{
			OpenOrClose(popup, false);
		}

		/// <summary>
		/// Gets the root element hosting the specified <see cref="Popup"/>.
		/// </summary>
		/// <param name="popup">The <see cref="Popup"/> for which to get the root <see cref="UIElement"/>.</param>
		/// <returns>The root element, if one can be found; otherwise <c>null</c>.</returns>
		/// <exception cref="ArgumentNullException">The <paramref name="popup"/> argument is <c>null</c>.</exception>
		public static UIElement GetPopupRoot(this Popup popup)
		{
			if (popup == null)
				throw new ArgumentNullException("popup");

			var firstChild = popup.GetFirstChild();
			var topElement = (firstChild != null)
				? firstChild.GetVisualAncestors().OfType<UIElement>().LastOrDefault()
				: null;
			return topElement;
		}

		/// <summary>
		/// Gets the first (top-most) child <see cref="UIElement"/> within the specified <see cref="Popup"/>.
		/// </summary>
		/// <param name="popup">The <see cref="Popup"/> for which to get the first (top-most)
		/// child <see cref="UIElement"/>.</param>
		/// <returns>The root element, if one can be found; otherwise <c>null</c>.</returns>
		/// <exception cref="ArgumentNullException">The <paramref name="popup"/> argument is <c>null</c>.</exception>
		public static UIElement GetFirstChild(this Popup popup)
		{
			if (popup == null)
				throw new ArgumentNullException("popup");

			var firstChild = popup.GetLogicalDescendantsRecursive().OfType<UIElement>().FirstOrDefault();
			return firstChild;
		}
		#endregion Extension Methods

		#region Private Implementation
		private static void OpenOrClose(Popup popup, bool open)
		{
			if (popup == null)
				throw new ArgumentNullException("popup");

			popup.SetCurrentValue(Popup.IsOpenProperty, open);
		}
		#endregion Private Implementation
	}
}
