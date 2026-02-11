using System.Configuration;
using System.Windows;
using CommunityToolkit.Diagnostics;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Attachments;

public static partial class WindowPersistence
{
	#region Attached Properties

	#region Key

	/// <summary>
	/// Identifies the <c>Key</c> attached property.
	/// </summary>
	public static readonly DependencyProperty KeyProperty =
		DependencyProperty.RegisterAttached("Key", typeof(string), typeof(PopupManagement),
			new PropertyMetadata(null, KeyPropertyChanged));

	/// <summary>
	/// Gets the key into the <see cref="ApplicationSettingsBase"/>-derived class where the window
	/// placement is persisted.
	/// </summary>
	/// <param name="element">The <see cref="Window"/> for which to get the property value.</param>
	/// <returns>The attached property value. </returns>
	/// <returns>The key into the <see cref="ApplicationSettingsBase"/>-derived class where the window
	/// placement is persisted.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="element"/> is <see langword="null"/>.</exception>
	public static string GetKey(Window element)
	{
		Guard.IsNotNull(element);
		return (string)element.GetValue(KeyProperty);
	}

	/// <summary>
	/// Sets the key into the <see cref="ApplicationSettingsBase"/>-derived class where the window
	/// placement is persisted.
	/// </summary>
	/// <param name="element">The <see cref="Window"/> for which to set the property value.</param>
	/// <param name="value"><see langword="true"/> to allow popups; <see langword="false"/> to block them.</param>
	/// <exception cref="ArgumentNullException"><paramref name="element"/> is <see langword="null"/>.</exception>
	public static void SetKey(Window element, string value)
	{
		Guard.IsNotNull(element);
		element.SetValue(KeyProperty, value);
	}

	private static void KeyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		PrivateBehaviorPropertyKey.BehaviorPropertyChanged<Window, PrivateBehavior, string>(d, e, string.IsNullOrEmpty);
	}

	#endregion Key

	#region Settings

	/// <summary>
	/// Identifies the <c>Settings</c> attached property.
	/// </summary>
	public static readonly DependencyProperty SettingsProperty =
		DependencyProperty.RegisterAttached("Settings", typeof(ApplicationSettingsBase), typeof(PopupManagement),
			new PropertyMetadata(null, SettingsPropertyChanged));

	/// <summary>
	/// Gets the instance of the <see cref="ApplicationSettingsBase"/>-derived class where the window
	/// placement is persisted.
	/// </summary>
	/// <param name="element">The <see cref="Window"/> for which to get the property value.</param>
	/// <returns>The attached property value. </returns>
	/// <returns>An instance of the <see cref="ApplicationSettingsBase"/>-derived class.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="element"/> is <see langword="null"/>.</exception>
	public static ApplicationSettingsBase GetSettings(Window element)
	{
		Guard.IsNotNull(element);
		return (ApplicationSettingsBase)element.GetValue(SettingsProperty);
	}

	/// <summary>
	/// Sets the instance of the <see cref="ApplicationSettingsBase"/>-derived class where the window
	/// placement is persisted.
	/// </summary>
	/// <param name="element">The <see cref="Window"/> for which to set the property value.</param>
	/// <param name="value">An instance of the <see cref="ApplicationSettingsBase"/>-derived class.</param>
	/// <exception cref="ArgumentNullException"><paramref name="element"/> is <see langword="null"/>.</exception>
	public static void SetSettings(Window element, ApplicationSettingsBase value)
	{
		Guard.IsNotNull(element);
		element.SetValue(SettingsProperty, value);
	}

	private static void SettingsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		PrivateBehaviorPropertyKey.BehaviorPropertyChanged<Window, PrivateBehavior, ApplicationSettingsBase>(d, e);
	}

	#endregion Settings

	#region PrivateBehavior

	/// <summary>
	/// Identifies the <see cref="PrivateBehavior"/> dependency property key.
	/// </summary>
	private static readonly DependencyPropertyKey PrivateBehaviorPropertyKey =
		DependencyProperty.RegisterAttachedReadOnly("PrivateBehavior", typeof(PrivateBehavior), typeof(WindowPersistence),
			new PropertyMetadata());

	#endregion PrivateBehavior

	#endregion Attached Properties
}
