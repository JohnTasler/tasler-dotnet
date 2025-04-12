using System;
using Tasler.Threading;
using System.Diagnostics;

#if WINDOWS_UWP
using Windows.Foundation;
using Dispatcher = Windows.UI.Core.CoreDispatcher;
using DispatcherTimer = Windows.UI.Xaml.DispatcherTimer;
using DispatcherPriority = Windows.UI.Core.CoreDispatcherPriority;
#elif WINDOWS_WPF
using System.Windows.Threading;
namespace Tasler.Windows.Threading
#endif
{
    public partial class DispatcherTimerAdapter : ITimerAdapter
    {
        private DispatcherTimer _timer;

        public DispatcherTimerAdapter()
        {
            this._timer = new DispatcherTimer();
        }

        public DispatcherTimerAdapter(DispatcherPriority dispatcherPriority)
        {
            this._timer = new DispatcherTimer(dispatcherPriority);
        }

        public DispatcherTimerAdapter(DispatcherPriority dispatcherPriority, Dispatcher dispatcher)
        {
            this._timer = new DispatcherTimer(dispatcherPriority, dispatcher);
        }

        #region ITimerAdapter Members

        public TimeSpan Interval
        {
            get => this._timer.Interval;
            set => this._timer.Interval = value;
        }

        public bool IsRunning => this._timer.IsEnabled;

        public event EventHandler Tick
        {
            add => this._timer.Tick += value;
            remove => this._timer.Tick -= value;
        }

        public void Start() => this._timer.Start();

        public void Stop() => this.PlatformStop();

        #endregion ITimerAdapter Members

#if WINDOWS_UWP
        private void PlatformStop()
        {
            if (!this._timer.Dispatcher.HasThreadAccess)
                this._timer.Dispatcher.RunAsync(DispatcherPriority.Normal, new Action(() => _timer.Stop()));
            else
                this._timer.Stop();
        }
#elif WINDOWS_WPF
        private void PlatformStop()
        {
            if (!this._timer.Dispatcher.CheckAccess())
                this._timer.Dispatcher.BeginInvoke(new Action(() => _timer.Stop()));
            else
                this._timer.Stop();
        }
#endif
    }
}
