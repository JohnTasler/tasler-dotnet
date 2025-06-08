using System.Windows;
using System.Xml.Linq;
using CommunityToolkit.Diagnostics;
using Tasler.Windows.Controls;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Attachments;

public static partial class PopupManagement
{
	#region Constructors
	static PopupManagement()
	{
		EventManager.RegisterClassHandler(typeof(Window), FrameworkElement.LoadedEvent, new RoutedEventHandler(Window_Loaded), true);
		EventManager.RegisterClassHandler(typeof(Popup), Popup.OpenedEvent, new RoutedEventHandler(Popup_Opened), true);
	}
	#endregion Constructors

	#region Attached Properties

	#region AllowsOpenPopups

	/// <summary>
	/// Identifies the <c>AllowsOpenPopups</c> attached property.
	/// </summary>
	public static readonly DependencyProperty AllowsOpenPopupsProperty =
		DependencyProperty.RegisterAttached("AllowsOpenPopups", typeof(bool), typeof(PopupManagement),
			new PropertyMetadata(true, AllowsOpenPopupsPropertyChanged));

	/// <summary>
	/// Gets the
	/// </summary>
	/// <param name="element">The <see cref="FrameworkElement"/> for which to get the property value.</param>
	/// <returns>The attached property value. </returns>
	/// <exception cref="ArgumentNullException"><paramref name="window"/> is <see langword="null"/>.</exception>
	public static bool GetAllowsOpenPopups(FrameworkElement element)
	{
		Guard.IsNotNull(element);
		return (bool)element.GetValue(AllowsOpenPopupsProperty);
	}

	/// <summary>
	/// Sets the
	/// </summary>
	/// <param name="element">The <see cref="FrameworkElement"/> for which to set the property value.</param>
	/// <returns>The attached property value. </returns>
	/// <param name="value">The new value for the attached property.</param>
	/// <exception cref="ArgumentNullException"><paramref name="window"/> is <see langword="null"/>.</exception>
	public static void SetAllowsOpenPopups(FrameworkElement element, bool value)
	{
		Guard.IsNotNull(element);
		element.SetValue(AllowsOpenPopupsProperty, value);
	}

	private static void AllowsOpenPopupsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var element = (FrameworkElement)d;
		var newValue = (bool)e.NewValue;
		if (newValue)
		{
			var behavior = (PrivateBehavior)element.GetValue(PrivateBehaviorPropertyKey.DependencyProperty);
			if (behavior is not null)
			{
				// Detach and dereference the behavior when the newValue is true, since true is the default value
				behavior.Detach();
				element.ClearValue(PrivateBehaviorPropertyKey);
			}
		}
		else
		{
			// Create and attach the behavior only when the newValue is false, since false is the non-default value
			var behavior = new PrivateBehavior();
			behavior.Attach(element);
			element.SetValue(PrivateBehaviorPropertyKey, behavior);
		}
	}

	#endregion AllowsOpenPopups

	#region IsAlwaysAllowedToOpen

	/// <summary>
	/// Identifies the <c>IsAlwaysAllowedToOpen</c> attached property.
	/// </summary>
	public static readonly DependencyProperty IsAlwaysAllowedToOpenProperty =
		DependencyProperty.RegisterAttached("IsAlwaysAllowedToOpen", typeof(bool), typeof(PopupManagement),
			new PropertyMetadata(false));

	/// <summary>
	/// Gets the
	/// </summary>
	/// <param name="element">The <see cref="FrameworkElement"/> for which to get the property value.</param>
	/// <returns>The attached property value. </returns>
	/// <exception cref="ArgumentNullException"><paramref name="window"/> is <see langword="null"/>.</exception>
	public static bool GetIsAlwaysAllowedToOpen(FrameworkElement element)
	{
		Guard.IsNotNull(element);
		return (bool)element.GetValue(IsAlwaysAllowedToOpenProperty);
	}

	/// <summary>
	/// Sets the
	/// </summary>
	/// <param name="element">The <see cref="FrameworkElement"/> for which to set the property value.</param>
	/// <returns>The attached property value. </returns>
	/// <param name="value">The new value for the attached property.</param>
	/// <exception cref="ArgumentNullException"><paramref name="window"/> is <see langword="null"/>.</exception>
	public static void SetIsAlwaysAllowedToOpen(FrameworkElement element, bool value)
	{
		Guard.IsNotNull(element);
		element.SetValue(IsAlwaysAllowedToOpenProperty, value);
	}

	#endregion IsAlwaysAllowedToOpen

	#region ArePopupsBlocked

	private static readonly DependencyPropertyKey ArePopupsBlockedPropertyKey =
		DependencyProperty.RegisterAttachedReadOnly("ArePopupsBlocked", typeof(bool), typeof(PopupManagement),
			new PropertyMetadata(false));

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

	#region PrivateBehavior

	/// <summary>
	/// Identifies the <see cref="PrivateBehavior"/> dependency property key.
	/// </summary>
	private static readonly DependencyPropertyKey PrivateBehaviorPropertyKey =
		DependencyProperty.RegisterAttachedReadOnly("PrivateBehavior", typeof(PrivateBehavior), typeof(PopupManagement),
			new PropertyMetadata());

	#endregion PrivateBehavior

	#region PrivateWindowBehavior

	/// <summary>
	/// Identifies the <see cref="PrivateWindowBehavior"/> dependency property.
	/// </summary>
	private static readonly DependencyPropertyKey PrivateWindowBehaviorPropertyKey =
		DependencyProperty.RegisterAttachedReadOnly("PrivateWindowBehavior", typeof(PrivateWindowBehavior), typeof(PopupManagement),
			new PropertyMetadata());

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

	#endregion Attached Properties

	#region Event Handlers

	private static void Window_Loaded(object sender, RoutedEventArgs e)
	{
		var window = sender as Window;
		if (window is not null)
		{
			var topWindow = window.GetSelfAndOwners().Last();
			var windowBehavior = GetPrivateWindowBehavior(topWindow);
			if (windowBehavior is not null && windowBehavior.ArePopupsBlocked && !GetIsAlwaysAllowedToOpen(window))
				windowBehavior.BlockWindow(window);
		}
	}

	private static void Popup_Opened(object sender, RoutedEventArgs e)
	{
		var popup = sender as Popup;
		if (popup is not null && !GetIsAlwaysAllowedToOpen(popup))
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
