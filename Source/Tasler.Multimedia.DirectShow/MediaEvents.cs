using System;
using System.Runtime.InteropServices;
using System.Threading;
using DirectShowLib;

namespace Tasler.Multimedia.DirectShow
{
	public partial class MediaEvents
	{
		private MediaEventsListener listener;

		protected internal MediaEvents(MediaEventsListener listener)
		{
			this.listener = listener;
		}

		protected bool AddSubscriber<T>(EventCode eventCode, EventHandler<T> subscriber, bool cancelDefaultHandling)
			where T : MediaEventArgs, new()
		{
			return this.listener.AddSubscriber<T>(eventCode, subscriber, cancelDefaultHandling);
		}

		protected bool RemoveSubscriber(EventCode eventCode, Delegate subscriber)
		{
			return this.listener.RemoveSubscriber(eventCode, subscriber);
		}
	}

	#region Activate (EC_ACTIVATE)

	public class MediaEventActivateArgs : MediaEventArgs, IDisposable
	{
		#region Instance Fields
		private object renderer;
		#endregion Instance Fields

		#region Finalization
		~MediaEventActivateArgs()
		{
			this.Dispose();
		}
		#endregion Finalization

		#region Properties

		/// <summary>
		/// <c>true</c> if the window is activated, or <c>false</c> if the window is deactivated.
		/// </summary>
		public bool IsActivated
		{
			get
			{
				return base.Param1 != IntPtr.Zero;
			}
		}

		/// <summary>
		/// The renderer's <see cref="IBaseFilter"/> interface.
		/// </summary>
		public IBaseFilter Renderer
		{
			get
			{
				var unknown = this.renderer;
				if (unknown == null)
				{
					unknown = Marshal.GetObjectForIUnknown(base.Param2);
					var previousUnknown = Interlocked.Exchange(ref this.renderer, unknown);
					if (previousUnknown != null)
						Marshal.ReleaseComObject(previousUnknown);
				}
				return unknown as IBaseFilter;
			}
		}

		#endregion Properties

		#region IDisposable Members

		public void Dispose()
		{
			var previousUnknown = Interlocked.Exchange(ref this.renderer, null);
			if (previousUnknown != null)
				Marshal.ReleaseComObject(previousUnknown);
			GC.SuppressFinalize(this);
		}

		#endregion IDisposable Members
	}

	public partial class MediaEvents
	{
		/// <summary>
		/// A video window is being activated or deactivated.
		/// </summary>
		public event EventHandler<MediaEventActivateArgs> Activate
		{
			add
			{
				this.AddSubscriber<MediaEventActivateArgs>(EventCode.Activate, value, false);
			}
			remove
			{
				this.RemoveSubscriber(EventCode.Activate, value);
			}
		}
	}

	#endregion Activate (EC_ACTIVATE)

	#region BufferingData (EC_BUFFERING_DATA)

	/// <summary>
	/// Provides data for the <see cref="MediaEvents.BufferingData"/> event.
	/// </summary>
	public class MediaEventBufferingDataArgs : MediaEventArgs
	{
		#region Properties

		/// <summary>
		/// <c>true</c> if the graph is starting to buffer, or <c>false</c> if
		/// the graph has stopped buffering.
		/// </summary>
		public bool IsStarting
		{
			get
			{
				return base.Param1 != IntPtr.Zero;
			}
		}

		#endregion Properties
	}

	public partial class MediaEvents
	{
		/// <summary>
		/// Occurs when the graph is buffering data, or has stopped buffering data.
		/// </summary>
		public event EventHandler<MediaEventBufferingDataArgs> BufferingData
		{
			add
			{
				this.AddSubscriber<MediaEventBufferingDataArgs>(EventCode.BufferingData, value, false);
			}
			remove
			{
				this.RemoveSubscriber(EventCode.BufferingData, value);
			}
		}
	}

	#endregion BufferingData (EC_BUFFERING_DATA)

	#region ClockChanged (EC_CLOCK_CHANGED)

	public partial class MediaEvents
	{
		/// <summary>
		/// Occurs when the reference clock has changed.
		/// </summary>
		public event EventHandler<MediaEventArgs> ClockChanged
		{
			add
			{
				this.AddSubscriber<MediaEventArgs>(EventCode.ClockChanged, value, false);
			}
			remove
			{
				this.RemoveSubscriber(EventCode.ClockChanged, value);
			}
		}
	}

	#endregion ClockChanged (EC_CLOCK_CHANGED)

	#region ClockUnset (EC_CLOCK_UNSET)

	public partial class MediaEvents
	{
		/// <summary>
		/// Occurs when the clock provider was disconnected.
		/// </summary>
		/// <remarks>
		/// KSProxy signals this event when the pin of a clock-providing filter is disconnected.
		/// </remarks>
		public event EventHandler<MediaEventArgs> ClockUnset
		{
			add
			{
				this.AddSubscriber<MediaEventArgs>(EventCode.ClockUnset, value, false);
			}
			remove
			{
				this.RemoveSubscriber(EventCode.ClockUnset, value);
			}
		}
	}

	#endregion ClockUnset (EC_CLOCK_UNSET)

	#region Complete (EC_COMPLETE)

	public class MediaEventCompleteArgs : MediaEventArgs
	{
		#region Properties

		public int Status
		{
			get
			{
				return base.Param1.ToInt32();
			}
		}

		#endregion Properties
	}

	public partial class MediaEvents
	{
		public event EventHandler<MediaEventCompleteArgs> Complete
		{
			add
			{
				this.AddSubscriber<MediaEventCompleteArgs>(EventCode.Complete, value, false);
			}
			remove
			{
				this.RemoveSubscriber(EventCode.Complete, value);
			}
		}
	}

	#endregion Complete (EC_COMPLETE)

	#region FileClosed (EC_FILE_CLOSED)

	public partial class MediaEvents
	{
		/// <summary>
		/// Occurs when the source file was closed because of an unexpected event.
		/// For example, the network server was shut down.
		/// </summary>
		/// <remarks>
		/// The legacy Windows Media Source filter sends this event.
		/// New filters should not send this event.
		/// </remarks>
		public event EventHandler<MediaEventArgs> FileClosed
		{
			add
			{
				this.AddSubscriber<MediaEventArgs>((EventCode)0x44, value, false);
			}
			remove
			{
				this.RemoveSubscriber((EventCode)0x44, value);
			}
		}
	}

	#endregion FileClosed (EC_FILE_CLOSED)

	#region LoadStatus (EC_LOADSTATUS)

	/// <summary>
	/// Provides data for the <see cref="MediaEvents.LoadStatus"/> event.
	/// </summary>
	public class MediaEventLoadStatusArgs : MediaEventArgs
	{
		#region Properties

		/// <summary>
		/// Status code.
		/// </summary>
		public AmLoadStatus Status
		{
			get
			{
				return (AmLoadStatus)base.Param1.ToInt32();
			}
		}

		#endregion Properties
	}

	public partial class MediaEvents
	{
		/// <summary>
		/// Occurs when the source filter notifies the application of progress when opening a network file.
		/// </summary>
		/// <remarks>
		/// The WM ASF Reader filter and the legacy Windows Media Source filter send this event.
		/// </remarks>
		public event EventHandler<MediaEventLoadStatusArgs> LoadStatus
		{
			add
			{
				this.AddSubscriber<MediaEventLoadStatusArgs>((EventCode)0x43, value, false);
			}
			remove
			{
				this.RemoveSubscriber((EventCode)0x43, value);
			}
		}
	}

	/// <summary>
	/// Status codes for <see cref="MediaEvents.LoadStatus"/> (EC_LOADSTATUS).
	/// </summary>
	public enum AmLoadStatus
	{
		/// <summary>The source filter has closed the file.</summary>
		Closed = 0x0000,
		/// <summary>Not used.</summary>
		LoadingDescr = 0x0001,
		/// <summary>Not used.</summary>
		LoadingMcast = 0x0002,
		/// <summary>The source filter is locating requested data.</summary>
		Locating = 0x0003,
		/// <summary>The source filter is connecting to the server.</summary>
		Connecting = 0x0004,
		/// <summary>The source filter is opening the file.</summary>
		Opening = 0x0005,
		/// <summary>The source filter has opened the file.</summary>
		Open = 0x0006,
	}

	#endregion LoadStatus (EC_LOADSTATUS)

	#region Paused (EC_PAUSED)

	public class MediaEventPausedArgs : MediaEventArgs
	{
		public int Status
		{
			get
			{
				return base.Param1.ToInt32();
			}
		}
	}

	public partial class MediaEvents
	{
		public event EventHandler<MediaEventPausedArgs> Paused
		{
			add
			{
				this.AddSubscriber<MediaEventPausedArgs>(EventCode.Paused, value, false);
			}
			remove
			{
				this.RemoveSubscriber(EventCode.Paused, value);
			}
		}
	}

	#endregion Paused (EC_PAUSED)

	#region StateChange (EC_STATE_CHANGE)

	public class MediaEventStateChangeArgs : MediaEventArgs
	{
		public FilterState State
		{
			get
			{
				return (FilterState)base.Param1.ToInt32();
			}
		}
	}

	public partial class MediaEvents
	{
		public event EventHandler<MediaEventStateChangeArgs> StateChange
		{
			add
			{
				this.AddSubscriber<MediaEventStateChangeArgs>(EventCode.StateChange, value, true);
			}
			remove
			{
				this.RemoveSubscriber(EventCode.StateChange, value);
			}
		}
	}

	#endregion StateChange (EC_STATE_CHANGE)

	#region StepComplete (EC_STEP_COMPLETE)

	public class MediaEventStepCompleteArgs : MediaEventArgs
	{
		public bool WasCancelled
		{
			get
			{
				return base.Param1.ToInt64() != 0;
			}
		}
	}

	public partial class MediaEvents
	{
		public event EventHandler<MediaEventStepCompleteArgs> StepComplete
		{
			add
			{
				this.AddSubscriber<MediaEventStepCompleteArgs>(EventCode.StepComplete, value, false);
			}
			remove
			{
				this.RemoveSubscriber(EventCode.StepComplete, value);
			}
		}
	}

	#endregion StepComplete (EC_STEP_COMPLETE)

}
