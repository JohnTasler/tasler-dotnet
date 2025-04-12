
namespace Tasler.Windows.Controls;

/// <summary>
/// A set of flags indicating which input gestures will toggle the
/// <see cref="ToggleSwitchBase.IsChecked">IsChecked</see> state of the <see cref="ToggleSwitchBase"/> control.
/// </summary>
/// <seealso cref="ToggleSwitchBase.GestureMode"/>
/// <seealso cref="HorizontalToggleSwitch"/>
[Flags]
public enum ToggleGestureMode : uint
{
	/// <summary>No modes will toggle the state. Simply for value comparison.</summary>
	None = 0x00,

	/// <summary>A left mouse slide/swipe gesture will toggle the state (on button release).</summary>
	Slide = 0x01,

	/// <summary>A left mouse click gesture will toggle the state (on button release).</summary>
	Click = 0x02,

	/// <summary>The <see cref="M:System.Windows.Input.Key.Enter"/> key will toggle the state.</summary>
	Enter = 0x04,

	/// <summary>The <see cref="M:System.Windows.Input.Key.Space"/> key will toggle the state.</summary>
	Space = 0x08,

	/// <summary>All defined toggle mouse gestures will toggle the state.</summary>
	/// <seealso cref="Slide"/> <seealso cref="Click"/>
	AllMouse = Slide | Click,

	/// <summary>All defined toggle keyboard gestures will toggle the state.</summary>
	/// <seealso cref="Enter"/> <seealso cref="Space"/>
	AllKeyboard = Enter | Space,

	/// <summary>All defined toggle gestures will toggle the state.</summary>
	/// <seealso cref="Slide"/> <seealso cref="Click"/>
	/// <seealso cref="Enter"/> <seealso cref="Space"/>
	/// <seealso cref="AllMouse"/> <seealso cref="AllKeyboard"/>
	All = AllMouse | AllKeyboard,
}
