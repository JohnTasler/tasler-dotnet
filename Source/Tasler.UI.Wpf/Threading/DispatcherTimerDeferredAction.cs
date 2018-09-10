using System;
using System.Windows.Threading;
using Tasler.Threading;

namespace Tasler.Windows.Threading
{
    public class DispatcherTimerDeferredAction : TimerDeferredAction
    {
        public DispatcherTimerDeferredAction(TimeSpan timeSpan, Action action)
            : base(new DispatcherTimerAdapter(), timeSpan, action)
        {
        }

        public DispatcherTimerDeferredAction(TimeSpan timeSpan, Action action, DispatcherPriority dispatcherPriority)
            : base(new DispatcherTimerAdapter(dispatcherPriority), timeSpan, action)
        {
        }

        public DispatcherTimerDeferredAction(TimeSpan timeSpan, Action action, DispatcherPriority dispatcherPriority, Dispatcher dispatcher)
            : base(new DispatcherTimerAdapter(dispatcherPriority, dispatcher), timeSpan, action)
        {
        }
    }
}
