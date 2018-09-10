using System;
using Tasler.Threading;
using Windows.UI.Xaml;

namespace Tasler.UI.Xaml
{
    public partial class DispatcherTimerAdapter : ITimerAdapter
    {
        private DispatcherTimer _timer;

        public DispatcherTimerAdapter()
        {
            _timer = new DispatcherTimer();
        }

        #region ITimerAdapter Members

        public TimeSpan Interval
        {
            get { return _timer.Interval; }
            set { _timer.Interval = value; }
        }

        public bool IsRunning
        {
            get { return _timer.IsEnabled; }
        }

        public event EventHandler Tick
        {
            add { _timer.Tick += (s, e) => value?.Invoke(this, EventArgs.Empty); }
            remove { _timer.Tick -= (s, e) => value?.Invoke(this, EventArgs.Empty); }
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        #endregion ITimerAdapter Members
    }
}
