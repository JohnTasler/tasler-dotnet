namespace Tasler.Threading;

// TODO: NEEDS_UNIT_TESTS

public static class ThreadExtensions
{
	public static Thread Create<TParameter>(Action<TParameter?> typedThreadProc)
		where TParameter : class
	{
		return new Thread(arg => typedThreadProc((TParameter?)arg));
	}
}
