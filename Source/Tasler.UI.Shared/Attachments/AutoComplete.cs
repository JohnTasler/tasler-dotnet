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

using APFactory = AttachedPropertyFactory<AutoComplete>;

public abstract partial class AutoComplete
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
		APFactory.Register(Mode, AutoCompleteMode.None, ModePropertyChanged);

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
			var behavior = GetOrCreateBehavior(textBox);
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

	#region UseTabKey

	private const string UseTabKey = nameof(UseTabKey);

	public static readonly DependencyProperty UseTabKeyProperty =
		APFactory.Register<bool>(UseTabKey, true, UseTabKeyPropertyChanged);

	public static bool GetUseTabKey(TextBox textBox) => (bool)textBox.GetValue(UseTabKeyProperty);

	public static void SetUseTabKey(TextBox textBox, bool mode) => textBox.SetValue(UseTabKeyProperty, mode);

	private static void UseTabKeyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var textBox = d as TextBox;
		Guard.IsNotNull(textBox);
		var newValue = (bool)e.NewValue;

		var behavior = GetOrCreateBehavior(textBox);
		behavior.UseTabKey = newValue;
	}

	#endregion UseTabKey

	#region Sources

	private const string Sources = nameof(Sources);

	public static readonly DependencyProperty SourcesProperty =
		APFactory.Register<AutoCompleteSources>(Sources, AutoCompleteSources.Default, SourcesPropertyChanged);

	public static AutoCompleteSources GetSources(TextBox textBox) => (AutoCompleteSources)textBox.GetValue(SourcesProperty);

	public static void SetSources(TextBox textBox, AutoCompleteSources mode) => textBox.SetValue(SourcesProperty, mode);

	private static void SourcesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var textBox = d as TextBox;
		Guard.IsNotNull(textBox);

		var newValue = (AutoCompleteSources)e.NewValue;
		var behavior = GetOrCreateBehavior(textBox);
		behavior.Sources = newValue;
	}

	#endregion Sources

	#region Suggestions

	private const string Suggestions = nameof(Suggestions);

	private static readonly DependencyPropertyKey SuggestionsPropertyKey =
		APFactory.RegisterReadOnly<ObservableCollection<string>>(Suggestions, []);

	public static DependencyProperty SuggestionsProperty
		=> SuggestionsPropertyKey.DependencyProperty;

	public static ObservableCollection<string> GetSuggestions(TextBox textBox)
		=> (ObservableCollection<string>)textBox.GetValue(SuggestionsProperty);

	internal static void SetSuggestions(TextBox textBox, ObservableCollection<string> suggestions)
		=> textBox.SetValue(SuggestionsPropertyKey, suggestions);

	#endregion Suggestions

	private static PrivateBehavior GetOrCreateBehavior(TextBox textBox)
	{
		var behavior = GetPrivateBehavior(textBox);
		if (behavior is null)
		{
			behavior = new PrivateBehavior();
			behavior.Attach(textBox);
			SetPrivateBehavior(textBox, behavior);
		}

		return behavior;
	}
}
