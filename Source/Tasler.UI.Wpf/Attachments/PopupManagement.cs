using System.Windows;
using CommunityToolkit.Diagnostics;
using Tasler.Windows.Controls;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Attachments;

using APFactory = Tasler.Windows.AttachedPropertyFactory<PopupManagement>;

public sealed partial class PopupManagement
{
	#region Constructors
	static PopupManagement()
	{
		EventManager.RegisterClassHandler(typeof(Window), FrameworkElement.LoadedEvent, new RoutedEventHandler(Window_Loaded), true);
		EventManager.RegisterClassHandler(typeof(Popup), Popup.OpenedEvent, new RoutedEventHandler(Popup_Opened), true);
	}

	private PopupManagement() { }
	#endregion Constructors

	#region Attached Properties

	#region PrivateBehavior

	/// <summary>
	/// Identifies the <see cref="PrivateBehavior"/> dependency property key.
	/// </summary>
	private static readonly DependencyPropertyKey PrivateBehaviorPropertyKey =
		APFactory.RegisterReadOnly<PrivateBehavior>("PrivateBehavior");

	#endregion PrivateBehavior

	#region PrivateWindowBehavior

	/// <summary>
	/// Identifies the <see cref="PrivateWindowBehavior"/> dependency property.
	/// </summary>
	private static readonly DependencyPropertyKey PrivateWindowBehaviorPropertyKey =
		APFactory.RegisterReadOnly<PrivateWindowBehavior>("PrivateWindowBehavior");

	private static PrivateWindowBehavior? GetPrivateWindowBehavior(Window? window)
	{
		Guard.IsNotNull(window);
		return (PrivateWindowBehavior)window.GetValue(PrivateWindowBehaviorPropertyKey.DependencyProperty);
	}

	private static void SetPrivateWindowBehavior(Window? window, PrivateWindowBehavior? value)
	{
		Guard.IsNotNull(window);

		if (value is null)
			window.ClearValue(PrivateWindowBehaviorPropertyKey);
		else
			window.SetValue(PrivateWindowBehaviorPropertyKey, value);
	}

	#endregion PrivateWindowBehavior

	#region AllowsOpenPopups

	/// <summary>
	/// Identifies the <c>AllowsOpenPopups</c> attached property.
	/// </summary>
	public static readonly DependencyProperty AllowsOpenPopupsProperty =
		APFactory.Register<bool>("AllowsOpenPopups", true,
			PrivateBehaviorPropertyKey.BehaviorPropertyChanged<FrameworkElement, PrivateBehavior, bool>);

	/// <summary>
	/// Gets a value indicating whether popups are allowed to open for the specified element.
	/// </summary>
	/// <param name="element">The <see cref="FrameworkElement"/> for which to get the property value.</param>
	/// <returns>The attached property value. </returns>
	/// <returns><c>true</c> if popups are allowed to open; otherwise, <c>false</c>.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="element"/> is <see langword="null"/>.</exception>
	public static bool GetAllowsOpenPopups(FrameworkElement element)
	{
		Guard.IsNotNull(element);
		return (bool)element.GetValue(AllowsOpenPopupsProperty);
	}

	/// <summary>
	/// Sets whether the specified element is allowed to open popups.
	/// </summary>
	/// <param name="element">The <see cref="FrameworkElement"/> for which to set the property value.</param>
	/// <param name="value"><see langword="true"/> to allow popups; <see langword="false"/> to block them.</param>
	/// <exception cref="ArgumentNullException"><paramref name="element"/> is <see langword="null"/>.</exception>
	public static void SetAllowsOpenPopups(FrameworkElement element, bool value)
	{
		Guard.IsNotNull(element);
		element.SetValue(AllowsOpenPopupsProperty, value);
	}

	#endregion AllowsOpenPopups

	#region IsAlwaysAllowedToOpen

	/// <summary>
	/// Identifies the <c>IsAlwaysAllowedToOpen</c> attached property.
	/// </summary>
	public static readonly DependencyProperty IsAlwaysAllowedToOpenProperty =
		APFactory.Register<bool>("IsAlwaysAllowedToOpen", false);

	/// <summary>
	/// Gets whether the specified element is always allowed to open popups, regardless of blocking rules.
	/// </summary>
	/// <param name="element">The <see cref="FrameworkElement"/> for which to get the property value.</param>
	/// <returns>The attached property value. </returns>
	/// <returns><see langword="true"/> if the element is always allowed to open popups; otherwise, <see langword="false"/>.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="element"/> is <see langword="null"/>.</exception>
	public static bool GetIsAlwaysAllowedToOpen(FrameworkElement element)
	{
		Guard.IsNotNull(element);
		return (bool)element.GetValue(IsAlwaysAllowedToOpenProperty);
	}

	/// <summary>
	/// Sets whether the specified element is always allowed to open popups, regardless of blocking rules.
	/// </summary>
	/// <param name="element">The <see cref="FrameworkElement"/> for which to set the property value.</param>
	/// <returns>The attached property value. </returns>
	/// <param name="value"><see langword="true"/> to always allow popups for this element; otherwise, <see langword="false"/>.</param>
	/// <exception cref="ArgumentNullException"><paramref name="element"/> is <see langword="null"/>.</exception>
	public static void SetIsAlwaysAllowedToOpen(FrameworkElement element, bool value)
	{
		Guard.IsNotNull(element);
		element.SetValue(IsAlwaysAllowedToOpenProperty, value);
	}

	#endregion IsAlwaysAllowedToOpen

	#region ArePopupsBlocked

	private static readonly DependencyPropertyKey ArePopupsBlockedPropertyKey =
		APFactory.RegisterReadOnly<bool>("ArePopupsBlocked", false);

	/// <summary>
	/// Identifies the <see cref="ArePopupsBlocked"/> attached property.
	/// </summary>
	public static readonly DependencyProperty ArePopupsBlockedProperty = ArePopupsBlockedPropertyKey.DependencyProperty;

	/// <summary>
	/// Gets a value indicating whether the popups are currently being blocked.
	/// </summary>
	public static bool GetArePopupsBlocked(Window window)
	{
		Guard.IsNotNull(window);
		return (bool)window.GetValue(ArePopupsBlockedProperty);
	}

	private static void SetArePopupsBlocked(Window window, bool? value)
	{
		Guard.IsNotNull(window);

		if (value.HasValue)
			window.SetValue(ArePopupsBlockedPropertyKey, value.Value);
		else
			window.ClearValue(ArePopupsBlockedPropertyKey);
	}

	#endregion ArePopupsBlocked

	#endregion Attached Properties

	#region Event Handlers

	private static void Window_Loaded(object sender, RoutedEventArgs e)
	{
		if (sender is Window window)
		{
			var topWindow = window.GetSelfAndOwners().Last();
			var windowBehavior = GetPrivateWindowBehavior(topWindow);
			if (windowBehavior is not null && windowBehavior.ArePopupsBlocked && !GetIsAlwaysAllowedToOpen(window))
				windowBehavior.BlockWindow(window);
		}
	}

	private static void Popup_Opened(object sender, RoutedEventArgs e)
	{
		if (sender is Popup popup && !GetIsAlwaysAllowedToOpen(popup))
		{
			var window = Window.GetWindow(popup).GetSelfAndOwners().LastOrDefault();
			if (window is not null)
			{
				var windowBehavior = GetPrivateWindowBehavior(window);
				if (windowBehavior is not null && windowBehavior.ArePopupsBlocked)
				{
					windowBehavior.BlockPopup(popup);
					e.Handled = true;
				}
			}
		}
	}

	#endregion Event Handlers
}
