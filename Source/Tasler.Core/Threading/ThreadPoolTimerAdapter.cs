using System;
using System.Threading;

namespace Tasler.Threading
{
    public class ThreadPoolTimerAdapter : ITimerAdapter
    {
        #region Instance Fields
        private readonly object _lock = new object();
        private Timer _threadPoolTimer;
        private TimeSpan _interval;
        private EventHandler _tick;
        #endregion Instance Fields

        #region ITimerAdapter Members

        public TimeSpan Interval
        {
            get
            {
                lock (_lock)
                {
                    return _interval;
                }
            }
            set
            {
                lock (_lock)
                {
                    if (_interval != value)
                    {
                        _interval = value;

                        if (_threadPoolTimer != null)
                            _threadPoolTimer.Change(value, value);
                    }

                }
            }
        }

        public bool IsRunning
        {
            get
            {
                lock (_lock)
                {
                    return _threadPoolTimer != null;
                }
            }
        }

        public event EventHandler Tick
        {
            add    { lock (_lock) { _tick += value; } }
            remove { lock (_lock) { _tick -= value; } }
        }

        public void Start()
        {
            lock (_lock)
            {
                var timer = _threadPoolTimer ?? (_threadPoolTimer = new Timer(this.RaiseTick));
                timer.Change(_interval, _interval);
            }
        }

        public void Stop()
        {
            lock (_lock)
            {
                if (_threadPoolTimer != null)
                {
                    _threadPoolTimer.Change(Timeout.Infinite, Timeout.Infinite);
                    _threadPoolTimer.Dispose();
                    _threadPoolTimer = null;
                }
            }
        }

        #endregion ITimerAdapter Members

        #region Private Implementation

        private void RaiseTick(object state)
        {
            var tick = default(EventHandler);
            lock (_lock)
                tick = _tick;
            tick?.Invoke(this, EventArgs.Empty);
        }

        #endregion Private Implementation
    }
}
