using Tasler.Threading;
using Windows.UI.Xaml;

namespace Tasler.UI.Xaml;

public partial class DispatcherTimerAdapter : ITimerAdapter
{
	private readonly DispatcherTimer _timer = new();

	#region ITimerAdapter Members

	public TimeSpan Interval
	{
		get => _timer.Interval;
		set => _timer.Interval = value;
	}

	public bool IsRunning => _timer.IsEnabled;

	public event EventHandler Tick
	{
		add => _timer.Tick += (s, e) => value?.Invoke(this, EventArgs.Empty);
		remove => _timer.Tick -= (s, e) => value?.Invoke(this, EventArgs.Empty);
	}

	public void Start() => _timer.Start();

	public void Stop() => _timer.Stop();

	#endregion ITimerAdapter Members
}
