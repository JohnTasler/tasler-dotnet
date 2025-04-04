namespace Tasler.Windows.Input;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class MediaGestures
{
	#region Static Fields
	private static readonly MediaGestures _instance = new();
	#endregion Static Fields

	#region Construction

	/// <summary>
	/// Initializes a new instance of the <see cref="MediaGestures"/> class.
	/// </summary>
	private MediaGestures() => this.InitializeComponent(); // Initialize from XAML

	#endregion Construction

	#region Private Methods
	private static HumanInputGesture GetGesture(string gestureSuffix) => (HumanInputGesture)_instance[$"Media.{gestureSuffix}"];
	#endregion Private Methods

	#region Properties

	public static HumanInputGesture Guide => GetGesture(nameof(Guide));

	public static HumanInputGesture Play => GetGesture(nameof(Play));

	public static HumanInputGesture Pause => GetGesture(nameof(Pause));

	public static HumanInputGesture Record => GetGesture(nameof(Record));

	public static HumanInputGesture Forward => GetGesture(nameof(Forward));

	public static HumanInputGesture Rewind => GetGesture(nameof(Rewind));

	public static HumanInputGesture Skip => GetGesture(nameof(Skip));

	public static HumanInputGesture Replay => GetGesture(nameof(Replay));

	public static HumanInputGesture Stop => GetGesture(nameof(Stop));

	public static HumanInputGesture Details => GetGesture(nameof(Details));

	public static HumanInputGesture Back => GetGesture(nameof(Back));

	public static HumanInputGesture eHome => GetGesture(nameof(eHome));

	public static HumanInputGesture DvdMenu => GetGesture(nameof(DvdMenu));

	public static HumanInputGesture LiveTV => GetGesture(nameof(LiveTV));

	public static HumanInputGesture Aspect => GetGesture(nameof(Aspect));

	public static HumanInputGesture MyTV => GetGesture(nameof(MyTV));

	public static HumanInputGesture MyMusic => GetGesture(nameof(MyMusic));

	public static HumanInputGesture RecordedTV => GetGesture(nameof(RecordedTV));

	public static HumanInputGesture MyPictures => GetGesture(nameof(MyPictures));

	public static HumanInputGesture MyVideos => GetGesture(nameof(MyVideos));

	public static HumanInputGesture DvdAngle => GetGesture(nameof(DvdAngle));

	public static HumanInputGesture DvdAudio => GetGesture(nameof(DvdAudio));

	public static HumanInputGesture DvdSubtitle => GetGesture(nameof(DvdSubtitle));

	public static HumanInputGesture Radio => GetGesture(nameof(Radio));

	public static HumanInputGesture TeleText => GetGesture(nameof(TeleText));

	public static HumanInputGesture Red => GetGesture(nameof(Red));

	public static HumanInputGesture Green => GetGesture(nameof(Green));

	public static HumanInputGesture Yellow => GetGesture(nameof(Yellow));

	public static HumanInputGesture Blue => GetGesture(nameof(Blue));

	public static HumanInputGesture OEM1 => GetGesture(nameof(OEM1));

	public static HumanInputGesture OEM2 => GetGesture(nameof(OEM2));

	public static HumanInputGesture NumInput => GetGesture(nameof(NumInput));

	#endregion Properties
}
