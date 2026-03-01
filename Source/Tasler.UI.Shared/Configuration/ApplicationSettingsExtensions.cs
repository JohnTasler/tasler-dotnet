using System.Configuration;
using CommunityToolkit.Diagnostics;

namespace Tasler.Configuration;

public static partial class ApplicationSettingsExtensions
{
	private static readonly object _autoSaveHelperKey = typeof(AutoSaveHelper);

	public static void SetAutoSaveDeferral(this ApplicationSettingsBase settings, TimeSpan deferralTimeSpan)
	{
		Guard.IsNotNull(settings);
		Guard.IsGreaterThanOrEqualTo(deferralTimeSpan, TimeSpan.Zero);

		var helper = GetAutoSaveHelper(settings);
		if (helper is null)
		{
			helper = new AutoSaveHelper(settings, deferralTimeSpan);
			settings.Context[_autoSaveHelperKey] = helper;
		}
		else
		{
			helper.Expire(deferralTimeSpan);
		}
	}

	public static void ExpireAndClearAutoSaveDeferral(this ApplicationSettingsBase settings)
	{
		var helper = GetAutoSaveHelper(settings);
		if (helper is not null)
		{
			helper.Expire();
		}
		else
		{
			throw new InvalidOperationException(
				Tasler.Windows.Properties.Resources.ClearAutoSaveDeferralCalledBeforeSetAutoSaveDeferral);
		}
	}

	public static void ClearAutoSaveDeferral(this ApplicationSettingsBase settings)
	{
		var helper = GetAutoSaveHelper(settings);
		if (helper is not null)
		{
			using (helper)
			{
				helper.Expire();
				settings.Context.Remove(_autoSaveHelperKey);
			}
		}
		else
		{
			throw new InvalidOperationException(
				Tasler.Windows.Properties.Resources.ClearAutoSaveDeferralCalledBeforeSetAutoSaveDeferral);
		}
	}

	public static void MonitorPropertyValueChanges(this ApplicationSettingsBase settings, SettingsPropertyValue propertyValue)
	{
		var helper = GetAutoSaveHelper(settings);
		if (helper is not null)
			helper.SubscribeToPropertyChanges(propertyValue);
	}

	private static AutoSaveHelper? GetAutoSaveHelper(ApplicationSettingsBase settings)
	{
		return settings.Context.ContainsKey(_autoSaveHelperKey)
			? settings.Context[_autoSaveHelperKey] as AutoSaveHelper
			: null;
	}
}
