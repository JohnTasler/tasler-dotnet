using System;
using System.Windows.Threading;
using System.Windows.Interop;

namespace Tasler.Windows.Diagnostics
{
	public class ThreadIdleCounter
	{
		[ThreadStatic]
		private static readonly ThreadIdleCounter instance = new ThreadIdleCounter();

		private long counter;

		private ThreadIdleCounter()
		{
			ComponentDispatcher.ThreadIdle += this.ComponentDispatcher_ThreadIdle;
		}

		private void ComponentDispatcher_ThreadIdle(object sender, EventArgs e)
		{
			++this.counter;
		}

		public static ThreadIdleCounter Instance
		{
			get
			{
				return ThreadIdleCounter.instance;
			}
		}

		public long Counter
		{
			get
			{
				return this.counter;
			}
		}
	}
}
