using System.Configuration;
using System.Windows;
using CommunityToolkit.Diagnostics;
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

	#region Key

	/// <summary>
	/// Identifies the <c>Key</c> attached property.
	/// </summary>
	public static readonly DependencyProperty KeyProperty = APFactory.Register<string>("Key", KeyPropertyChanged);

	/// <summary>
	/// Gets the key into the <see cref="ApplicationSettingsBase"/>-derived class where the window
	/// placement is persisted.
	/// </summary>
	/// <param name="element">The <see cref="Window"/> for which to get the property value.</param>
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
	/// <param name="value">The key into the <see cref="ApplicationSettingsBase"/>-derived class where the window
	/// placement is persisted.</param>
	/// <exception cref="ArgumentNullException"><paramref name="element"/> is <see langword="null"/>.</exception>
	public static void SetKey(Window element, string value)
	{
		Guard.IsNotNull(element);
		element.SetValue(KeyProperty, value);
	}

	private static void KeyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		PrivateBehaviorPropertyKey.BehaviorPropertyChanged<Window, PrivateBehavior, string>(d, e);

		if (d is Window window)
		{
			var key = WindowPersistence.GetKey(window);
			var settings = WindowPersistence.GetSettings(window);
			if (settings is not null && key is not null)
			{
				CreateSettingsProperty(key, settings);
			}
		}
	}

	private static void CreateSettingsProperty(string key, ApplicationSettingsBase settings)
	{
		var settingsProperty = settings.Properties[key];
		if (settingsProperty is not null)
			return;

		var provider = settings.Providers.OfType<SettingsProvider>().FirstOrDefault();
		if (provider is null)
			return;

		var attributes = new SettingsAttributeDictionary();
		attributes[typeof(UserScopedSettingAttribute)] = new UserScopedSettingAttribute();

		settingsProperty = new(key, typeof(WindowPlacementModel),
			provider, false, null, SettingsSerializeAs.Xml, attributes, true, true);
		SettingsPropertyValue settingsPropertyValue = new (settingsProperty);

		settings.Properties.Add(settingsProperty);
		settings.PropertyValues.Add(settingsPropertyValue);
	}

	#endregion Key

	#region Settings

	/// <summary>
	/// Identifies the <c>Settings</c> attached property.
	/// </summary>
	public static readonly DependencyProperty SettingsProperty =
		APFactory.Register<ApplicationSettingsBase>("Settings", SettingsPropertyChanged);

	/// <summary>
	/// Gets the instance of the <see cref="ApplicationSettingsBase"/>-derived class where the window
	/// placement is persisted.
	/// </summary>
	/// <param name="element">The <see cref="Window"/> for which to get the property value.</param>
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
		PrivateBehaviorPropertyKey.BehaviorPropertyChanged<Window, PrivateBehavior, ApplicationSettingsBase > (d, e);

		if (d is Window window)
		{
			var key = WindowPersistence.GetKey(window);
			var settings = WindowPersistence.GetSettings(window);
			if (settings is not null && key is not null)
			{
				CreateSettingsProperty(key, settings);
			}
		}
	}

	#endregion Settings

	#endregion Attached Properties
}
