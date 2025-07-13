#if WINDOWS_UWP
namespace Tasler.UI.Xaml.Attachments;

#elif WINDOWS_WPF
namespace Tasler.Windows.Attachments;
#endif

/// <summary>
/// Specifies the mode for the automatic completion feature used in the <see cref="AutoComplete.Mode"/> attached property.
/// </summary>
public enum AutoCompleteMode
{
	/// <summary>Disables the automatic completion feature.</summary>
	None,

	/// <summary>Displays the auxiliary drop-down list associated with the edit control. This drop-down is populated with one or more suggested completion strings.</summary>
	Suggest,

	/// <summary>Appends the remainder of the most likely candidate string to the existing characters, highlighting the appended characters.</summary>
	Append,

	/// <summary>Applies both <see langword="Suggest" /> and <see langword="Append" /> options.</summary>
	SuggestAppend
}
