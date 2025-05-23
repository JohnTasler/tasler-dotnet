namespace Tasler.Threading;

public interface ITimerAdapter
{
	TimeSpan Interval { get; set; }
	bool IsRunning { get; }
	event EventHandler Tick;
	void Start();
	void Stop();
}
