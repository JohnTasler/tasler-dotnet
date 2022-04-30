using System;
using System.Windows.Threading;
using Tasler.Threading;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Threading
{
	public class DispatcherTimerAdapter : ITimerAdapter
	{
		private DispatcherTimer timer;

		public DispatcherTimerAdapter()
		{
			this.timer = new DispatcherTimer();
		}

		public DispatcherTimerAdapter(DispatcherPriority dispatcherPriority)
		{
			this.timer = new DispatcherTimer(dispatcherPriority);
		}

		public DispatcherTimerAdapter(DispatcherPriority dispatcherPriority, Dispatcher dispatcher)
		{
			this.timer = new DispatcherTimer(dispatcherPriority, dispatcher);
		}

		#region ITimerAdapter Members

		public TimeSpan Interval
		{
			get { return this.timer.Interval; }
			set { this.timer.Interval = value; }
		}

		public bool IsRunning
		{
			get { return this.timer.IsEnabled; }
		}

		public event EventHandler Tick
		{
			add { this.timer.Tick += value; }
			remove { this.timer.Tick -= value; }
		}

		public void Start()
		{
			this.timer.Start();
		}

		public void Stop()
		{
			if (!this.timer.Dispatcher.CheckAccess())
				this.timer.Dispatcher.BeginInvoke(() => this.timer.Stop());
			else
				this.timer.Stop();
		}

		#endregion ITimerAdapter Members
	}
}
