#if WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Tasler.UI.Xaml.Extensions;
namespace Tasler.UI.Xaml.Attachments;

#elif WINDOWS_WPF
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Diagnostics;
using Tasler.Windows.Extensions;
namespace Tasler.Windows.Attachments;
#endif

public static partial class AutoComplete
{
	#region PrivateBehavior
	/// <summary>
	/// Identifies the <see cref="PrivateBehavior"/> dependency property key.
	/// </summary>
	private static readonly DependencyPropertyKey PrivateBehaviorPropertyKey =
		AttachedPropertyFactory.RegisterReadOnly<PrivateBehavior>(typeof(AutoComplete), nameof(PrivateBehavior));

	private static PrivateBehavior? GetPrivateBehavior(DependencyObject d)
		=> d.GetValue(PrivateBehaviorPropertyKey.DependencyProperty) as PrivateBehavior;

	private static void SetPrivateBehavior(DependencyObject d, PrivateBehavior behavior)
		=> d.SetValue(PrivateBehaviorPropertyKey, behavior);

	#endregion PrivateBehavior

	#region Mode

	private const string Mode = nameof(Mode);

	public static readonly DependencyProperty ModeProperty =
		AttachedPropertyFactory.Register<AutoCompleteMode>(typeof(AutoComplete), Mode, AutoCompleteMode.None, ModePropertyChanged);

	public static AutoCompleteMode GetMode(TextBox textBox) => (AutoCompleteMode)textBox.GetValue(ModeProperty);

	public static void SetMode(TextBox textBox, AutoCompleteMode mode) => textBox.SetValue(ModeProperty, mode);

	private static void ModePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var textBox = d as TextBox;
		Guard.IsNotNull(textBox);

		var oldValue = (AutoCompleteMode)e.OldValue;
		var newValue = (AutoCompleteMode)e.NewValue;

		if (oldValue == AutoCompleteMode.None)
		{
			var behavior = CreateBehaviorIfNeeded(textBox);
			behavior.Mode = newValue;
		}
		else if (newValue == AutoCompleteMode.None)
		{
			textBox.ClearValue(PrivateBehaviorPropertyKey);
		}
		else
		{
			var behavior = GetPrivateBehavior(textBox)!;
			behavior.Mode = newValue;
		}
	}

	#endregion Mode

	#region Suggestions

	private const string Suggestions = nameof(Suggestions);

	private static readonly DependencyPropertyKey SuggestionsPropertyKey =
		AttachedPropertyFactory.RegisterReadOnly<ObservableCollection<string>>(typeof(AutoComplete), Suggestions, []);

	public static DependencyProperty SuggestionsProperty => SuggestionsPropertyKey.DependencyProperty;

	public static ObservableCollection<string> GetSuggestions(TextBox textBox) => (ObservableCollection<string>)textBox.GetValue(SuggestionsProperty);

	private static void SetSuggestions(TextBox textBox, ObservableCollection<string> mode) => textBox.SetValue(SuggestionsPropertyKey, mode);

	#endregion Suggestions

	private static PrivateBehavior CreateBehaviorIfNeeded(TextBox textBox)
	{
		var behavior = GetPrivateBehavior(textBox);
		if (behavior is null)
		{
			behavior = new PrivateBehavior();
			behavior.Attach(textBox);
			textBox.SetValue(PrivateBehaviorPropertyKey.DependencyProperty, behavior);
		}

		return behavior;
	}
}
