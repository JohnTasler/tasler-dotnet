using System;
using System.Windows;
using System.Windows.Threading;
using Tasler.Threading;

namespace Tasler.Windows.Threading
{
	public class DispatcherTimerAdapter : ITimerAdapter
	{
		private Dispatcher dispatcher = Deployment.Current.Dispatcher;
		private DispatcherTimer timer;

		public DispatcherTimerAdapter()
		{
			this.timer = new DispatcherTimer();
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
			add
			{
				this.tickHandler += value;
				this.timer.Tick += this.timer_Tick;
			}
			remove
			{
				this.tickHandler -= value;
				this.timer.Tick -= this.timer_Tick;
			}
		}

		public void Start()
		{
			this.timer.Start();
		}

		public void Stop()
		{
			if (!this.dispatcher.CheckAccess())
				this.dispatcher.BeginInvoke(() => this.timer.Stop());
			else
				this.timer.Stop();
		}

		#endregion ITimerAdapter Members

		private void timer_Tick(object sender, EventArgs e)
		{
			if (this.dispatcher.CheckAccess())
			{
				var handler = this.tickHandler;
				if (handler != null)
					handler(sender, e);
			}
			else
			{
				this.dispatcher.BeginInvoke(() => this.timer_Tick(sender, e));
			}
		}
		private EventHandler tickHandler;
	}
}
