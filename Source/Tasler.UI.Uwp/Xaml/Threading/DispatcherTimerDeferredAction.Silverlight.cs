using System;
using Tasler.Threading;

namespace Tasler.Windows.Threading
{
	public class DispatcherTimerDeferredAction : TimerDeferredActionBase
	{
		public DispatcherTimerDeferredAction(TimeSpan timeSpan, Action action)
			: base(new DispatcherTimerAdapter(), timeSpan, action)
		{
		}
	}
}
