using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Tasler.Windows.Input
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class MediaGestures
	{
		#region Static Fields
		private static readonly MediaGestures instance = new MediaGestures();
		#endregion Static Fields

		#region Construction
		/// <summary>
		/// Initializes a new instance of the <see cref="MediaGestures"/> class.
		/// </summary>
		private MediaGestures()
		{
			// Initialize from XAML
			this.InitializeComponent();
		}
		#endregion Construction

		#region Properties
		public static HumanInputGesture Guide
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Guide"]; }
		}

		public static HumanInputGesture Play
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Play"]; }
		}

		public static HumanInputGesture Pause
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Pause"]; }
		}

		public static HumanInputGesture Record
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Record"]; }
		}

		public static HumanInputGesture Forward
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Forward"]; }
		}

		public static HumanInputGesture Rewind
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Rewind"]; }
		}

		public static HumanInputGesture Skip
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Skip"]; }
		}

		public static HumanInputGesture Replay
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Replay"]; }
		}

		public static HumanInputGesture Stop
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Stop"]; }
		}

		public static HumanInputGesture Details
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Details"]; }
		}

		public static HumanInputGesture Back
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Back"]; }
		}

		public static HumanInputGesture eHome
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.eHome"]; }
		}

		public static HumanInputGesture DvdMenu
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.DvdMenu"]; }
		}

		public static HumanInputGesture LiveTV
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.LiveTV"]; }
		}

		public static HumanInputGesture Aspect
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Aspect"]; }
		}

		public static HumanInputGesture MyTV
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.MyTV"]; }
		}

		public static HumanInputGesture MyMusic
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.MyMusic"]; }
		}

		public static HumanInputGesture RecordedTV
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.RecordedTV"]; }
		}

		public static HumanInputGesture MyPictures
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.MyPictures"]; }
		}

		public static HumanInputGesture MyVideos
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.MyVideos"]; }
		}

		public static HumanInputGesture DvdAngle
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.DvdAngle"]; }
		}

		public static HumanInputGesture DvdAudio
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.DvdAudio"]; }
		}

		public static HumanInputGesture DvdSubtitle
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.DvdSubtitle"]; }
		}

		public static HumanInputGesture Radio
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Radio"]; }
		}

		public static HumanInputGesture TeleText
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.TeleText"]; }
		}

		public static HumanInputGesture Red
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Red"]; }
		}

		public static HumanInputGesture Green
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Green"]; }
		}

		public static HumanInputGesture Yellow
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Yellow"]; }
		}

		public static HumanInputGesture Blue
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.Blue"]; }
		}

		public static HumanInputGesture OEM1
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.OEM1"]; }
		}

		public static HumanInputGesture OEM2
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.OEM2"]; }
		}

		public static HumanInputGesture NumInput
		{
			get { return (HumanInputGesture)MediaGestures.instance["Media.NumInput"]; }
		}
		#endregion Properties
	}
}
