using System.Windows.Interop;

namespace Tasler.Windows.Diagnostics;

public class ThreadIdleCounter
{
	private long _counter;

	private ThreadIdleCounter()
	{
		ComponentDispatcher.ThreadIdle += this.ComponentDispatcher_ThreadIdle;
	}

	private void ComponentDispatcher_ThreadIdle(object? sender, EventArgs e)
	{
		++this._counter;
	}

	[ThreadStatic]
	public static readonly ThreadIdleCounter Instance = new ThreadIdleCounter();

	public long Counter => _counter;
}
