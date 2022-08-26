using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using DirectShowLib;
using Microsoft.Win32.SafeHandles;
using Tasler.Interop;
using Tasler.Threading;

namespace Tasler.Multimedia.DirectShow
{
	public class MediaEventsListener
	{
		#region Instance Fields
		private ReaderWriterLockSlimWrapper lockWrapper = new ReaderWriterLockSlimWrapper(
			new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion));
		private IMediaEvent mediaEvent;
		private NativeEventWaitHandle waitHandle;
		private ManualResetEvent stopWaitingEvent;
		private Thread waitThread;
		private Dictionary<EventCode, EventCodeEntry> eventCodeLookup;
		private MediaEventHandler mediaEventNotify;
		private Action mediaEventsAvailable;
		private MediaEvents mediaEvents;
		#endregion Instance Fields

		#region Construction / Finalization

		public MediaEventsListener()
		{
			this.mediaEvents = new MediaEvents(this);
		}

		~MediaEventsListener()
		{
			if (this.IsListening)
				this.Stop();
		}

		#endregion Construction / Finalization

		#region Properties

		/// <summary>
		/// Gets an indicator of whether the object is currently monitoring the media events
		/// of a filter graph.
		/// </summary>
		public bool IsListening
		{
			get
			{
				using (this.lockWrapper.ReadLock)
					return this.mediaEvent != null;
			}
		}

		public MediaEvents MediaEvents
		{
			get
			{
				return this.mediaEvents;
			}
		}
		#endregion Properties

		#region Methods

		/// <summary>
		/// Begins monitoring the specified <paramref name="filterGraph"/> for media events.
		/// </summary>
		/// <param name="filterGraph">The <see cref="IFilterGraph"/> to monitor.</param>
		/// <param name="mediaEventsAvailable">An <see cref="Action"/> delegate to be called
		/// from the monitoring thread when the filter graph has media events available in
		/// its queue.</param>
		/// <exception cref="ArgumentNullException">Either <paramref name="filterGraph"/> or
		/// <paramref name="mediaEventsAvailable"/> is null.</exception>
		/// <exception cref="ArgumentException">The specified filter graph does not support the
		/// <see cref="IMediaEvent"/> interface.</exception>
		/// <exception cref="InvalidOperationException">The object is already monitoring the
		/// media events of a filter graph.</exception>
		public void Start(IFilterGraph filterGraph, Action mediaEventsAvailable)
		{
			if (filterGraph == null)
				throw new ArgumentNullException("filterGraph");
			if (mediaEventsAvailable == null)
				throw new ArgumentNullException("mediaEventsAvailable");

			var mediaEvent = filterGraph as IMediaEvent;
			if (mediaEvent == null)
				throw new ArgumentException(Properties.Exceptions.FilterGraphNotIMediaEvent, "filterGraph");

			using (this.lockWrapper.WriteLock)
			{
				// Ensure that we're not already monitoring a filter graph
				if (this.mediaEvent != null)
					throw new InvalidOperationException(Properties.Exceptions.MediaEventsAlreadyMonitoring);

				try
				{
					// Get the manual reset event from the filter graph
					IntPtr hEventHandle;
					DsError.ThrowExceptionForHR(mediaEvent.GetEventHandle(out hEventHandle));

					// Duplicate the filter graph's event
					using (var eventHandle = new SafeWaitHandle(hEventHandle, false))
						this.waitHandle = new NativeEventWaitHandle(eventHandle, true);

					// Create an event to signal the wait thread to exit
					this.stopWaitingEvent = new ManualResetEvent(false);

					// Create the wait thread
					this.waitThread = new Thread(this.WaitThreadProc);
					this.waitThread.SetApartmentState(ApartmentState.MTA);
					this.waitThread.Name = "MediaEventsListener.WaitThread";

					// Save the specified delegate
					this.mediaEventsAvailable = mediaEventsAvailable;

					// Save the IMediaEvent interface
					this.mediaEvent = mediaEvent;

					// Cancel the filter graph's default handling for any subscribed events
					if (this.eventCodeLookup != null)
						foreach (var entry in this.eventCodeLookup)
							if (entry.Value.CancelDefaultHandling)
								this.mediaEvent.CancelDefaultHandling(entry.Key);

					// Start the wait thread
					this.waitThread.Start();
				}
				catch
				{
					this.waitThread = null;
					this.mediaEvent = null;
					using (this.stopWaitingEvent)
						this.stopWaitingEvent = null;
					using (this.waitHandle)
						this.waitHandle = null;

					// Rethrow the exception
					throw;
				}
			}
		}

		/// <summary>
		/// Stops monitoring the filter graph for media events.
		/// </summary>
		/// <exception cref="InvalidOperationException">The object is not currenting monitoring
		/// the media events of a filter graph.</exception>
		public void Stop()
		{
			Thread waitThread = null;
			NativeWaitHandle waitHandle = null;
			EventWaitHandle stopWaitingEvent = null;

			using (this.lockWrapper.WriteLock)
			{
				if (this.mediaEvent == null)
					throw new InvalidOperationException(Properties.Exceptions.MediaEventsNotMonitoring);

				// Restore the filter graph's default handling for any subscribed events
				if (this.eventCodeLookup != null)
					foreach (var entry in this.eventCodeLookup)
						if (entry.Value.CancelDefaultHandling)
							this.mediaEvent.RestoreDefaultHandling(entry.Key);

				// Copy the waitThread, waitEvent, and stopWaitingEvent to local variables
				waitThread = this.waitThread;
				waitHandle = this.waitHandle;
				stopWaitingEvent = this.stopWaitingEvent;
			}

			// Signal the stopWaitingEvent to exit the wait thread
			using (stopWaitingEvent)
			using (waitHandle)
			{
				stopWaitingEvent.Set();

				// Wait for the thread to exit
				waitThread.Join();

				// Continue cleaning-up state
				using (this.lockWrapper.WriteLock)
				{
					// Let go of the waitThread
					this.waitThread = null;

					// Let go of the stopWaitingEvent
					this.stopWaitingEvent = null;

					// Let go of the waitHandle
					this.waitHandle = null;

					// Let go of the delegate
					this.mediaEventsAvailable = null;

					// Release the IMediaEvents interface
					this.mediaEvent = null;
				}
			}
		}

		/// <summary>
		/// Processes all media events in the queue.
		/// </summary>
		/// <remarks>
		/// This should be called in the delegate passed to the <see cref="Start"/>
		/// method. Processing is broken-up as such so that the delegate can arrange to process
		/// the media events on whichever thread is appropriate.
		/// </remarks>
		public void ProcessMediaEvents()
		{
			// Copy the IMediaEvent interface and MediaEventHandler locally
			MediaEventHandler mediaEventNotify = null;
			IMediaEvent mediaEvent = null;
			using (this.lockWrapper.ReadLock)
			{
				mediaEvent = this.mediaEvent;
				if (mediaEvent != null && this.mediaEventNotify != null)
					mediaEventNotify = (MediaEventHandler)this.mediaEventNotify.Clone();
			}

			// Get the next event from the queue
			if (mediaEvent != null)
			{
				EventCode eventCode;
				IntPtr param1;
				IntPtr param2;

				while (true)
				{
					int hr = mediaEvent.GetEvent(out eventCode, out param1, out param2, 10);
					if (hr != 0)
						break;

					try
					{
						if (mediaEventNotify != null)
							mediaEventNotify(eventCode, param1, param2);
						this.ProcessMediaEvent(eventCode, param1, param2);
					}
					finally
					{
						mediaEvent.FreeEventParams(eventCode, param1, param2);
					}
				}
			}
		}

		#endregion Methods

		#region Events

		/// <summary>
		/// Raised for every graph builder media event.
		/// </summary>
		/// <remarks>
		/// This is a catch-all event useful for integrating with code that does its own switch logic
		/// with the event code. The preferred way is to subscribe to the specific events of interest,
		/// such as <see cref="StreamComplete"/> or <see cref="StepComplete"/>.
		/// </remarks>
		public event MediaEventHandler MediaEventNotify
		{
			add
			{
				using (this.lockWrapper.WriteLock)
					this.mediaEventNotify += value;
			}
			remove
			{
				using (this.lockWrapper.WriteLock)
					this.mediaEventNotify -= value;
			}
		}

		#endregion Events

		#region Private Implementation

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="eventCode"></param>
		/// <param name="subscriber"></param>
		/// <returns><c>true</c> if the added <paramref name="subscriber"/> is the first one
		/// associated with the specified <paramref name="eventCode"/>. Otherwise <c>false</c>.
		/// </returns>
		internal bool AddSubscriber<T>(EventCode eventCode, EventHandler<T> subscriber, bool cancelDefaultHandling)
			where T : MediaEventArgs, new()
		{
			using (this.lockWrapper.WriteLock)
			{
				bool isFirst = false;
				EventCodeEntry eventCodeEntry = null;

				if (this.eventCodeLookup == null)
					this.eventCodeLookup = new Dictionary<EventCode, EventCodeEntry>();
				else
					this.eventCodeLookup.TryGetValue(eventCode, out eventCodeEntry);

				if (eventCodeEntry == null)
				{
					isFirst = true;
					eventCodeEntry = new EventCodeEntry()
					{
						ArgsType = typeof(T),
						CancelDefaultHandling = cancelDefaultHandling
					};
					this.eventCodeLookup.Add(eventCode, eventCodeEntry);

					if (this.mediaEvent != null && eventCodeEntry.CancelDefaultHandling)
						this.mediaEvent.CancelDefaultHandling(eventCode);
				}

				eventCodeEntry.Subscribers = Delegate.Combine(eventCodeEntry.Subscribers, subscriber);
				return isFirst;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventCode"></param>
		/// <param name="subscriber"></param>
		/// <returns><c>true</c> if the removed <paramref name="subscriber"/> was the last one
		/// associated with the specified <paramref name="eventCode"/>. Otherwise <c>false</c>.
		/// </returns>
		internal bool RemoveSubscriber(EventCode eventCode, Delegate subscriber)
		{
			using (this.lockWrapper.WriteLock)
			{
				if (this.eventCodeLookup != null)
				{
					EventCodeEntry eventCodeEntry = null;
					if (this.eventCodeLookup.TryGetValue(eventCode, out eventCodeEntry))
					{
						eventCodeEntry.Subscribers = Delegate.Remove(eventCodeEntry.Subscribers, subscriber);
						if (eventCodeEntry.Subscribers == null)
						{
							if (this.mediaEvent != null && eventCodeEntry.CancelDefaultHandling)
								mediaEvent.RestoreDefaultHandling(eventCode);

							this.eventCodeLookup.Remove(eventCode);

							if (this.eventCodeLookup.Count == 0)
								this.eventCodeLookup = null;

							return true;
						}
					}
				}
			}

			return false;
		}

		private void ProcessMediaEvent(EventCode eventCode, IntPtr param1, IntPtr param2)
		{
			Type argsType = null;
			Delegate subscribers = null;

			using (lockWrapper.ReadLock)
			{
				EventCodeEntry eventCodeEntry = null;
				if (this.eventCodeLookup != null)
				{
					if (this.eventCodeLookup.TryGetValue(eventCode, out eventCodeEntry))
					{
						if (eventCodeEntry.Subscribers != null)
						{
							argsType = eventCodeEntry.ArgsType;
							subscribers = (Delegate)eventCodeEntry.Subscribers.Clone();
						}
					}
				}
			}

			if (subscribers != null)
			{
				// Create the event args
				var args = (MediaEventArgs)Activator.CreateInstance(argsType);
				args.Param1 = param1;
				args.Param2 = param2;

				// Notify subscribers
				try
				{
					subscribers.DynamicInvoke(this, args);
				}
				finally
				{
					var disposable = args as IDisposable;
					if (disposable != null)
						disposable.Dispose();
				}
			}
		}

		#endregion Private Implementation

		#region Event Handlers

		private void WaitThreadProc()
		{
			// Get the event handles to wait upon
			var waitHandles = new WaitHandle[2];
			using (this.lockWrapper.ReadLock)
			{
				waitHandles[0] = this.waitHandle;
				waitHandles[1] = this.stopWaitingEvent;
			}

			// Loop until stopWaitingEvent is set
			while (true)
			{
				int waitResult = WaitHandle.WaitAny(waitHandles);
				if (waitResult == 1)
					break;

				// Get the event handler delegate
				Action mediaEventsAvailable = null;
				using (this.lockWrapper.ReadLock)
					if (this.mediaEventsAvailable != null)
						mediaEventsAvailable = this.mediaEventsAvailable;

				// Notify the event handler delegate
				if (mediaEventsAvailable != null)
					mediaEventsAvailable();
				else
					this.ProcessMediaEvents();
			}
		}

		#endregion Event Handlers

		#region Nested Types

		private class EventCodeEntry
		{
			public Type ArgsType { get; set; }
			public Delegate Subscribers { get; set; }
			public bool CancelDefaultHandling { get; set; }
		}

		#endregion Nested Types
	}

	public delegate void MediaEventHandler(EventCode eventCode, IntPtr param1, IntPtr param2);

	/// <summary>
	/// Provides data for DirectShow media events.
	/// </summary>
	public class MediaEventArgs : EventArgs
	{
		public IntPtr Param1 { get; internal set; }
		public IntPtr Param2 { get; internal set; }
	}
}
