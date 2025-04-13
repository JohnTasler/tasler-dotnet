using Windows.UI.Core;

namespace Tasler.UI.Core;

public static class CoreDispatcherExtensions
{
	#region Non-waiting (fire-and-forget) Methods

	public static void RunAsyncNoWait(this CoreDispatcher @this, Action action)
	{
		@this.RunAsyncNoWait(CoreDispatcherPriority.Normal, action);
	}

	public static void RunAsyncNoWait(this CoreDispatcher @this, CoreDispatcherPriority priority, Action action)
	{
		_ = @this.RunAsync(priority, () => action());
	}

	public static void RunIdleAsyncNoWait(this CoreDispatcher @this, Action action)
	{
		_ = @this.RunIdleAsync(e => action());
	}

	#endregion Non-waiting (fire-and-forget) Methods

	#region Awaitable Methods

	public static Task RunAsync(this CoreDispatcher @this, Action action)
	{
		return @this.RunAsync(CoreDispatcherPriority.Normal, action);
	}

	public static Task RunAsync(this CoreDispatcher @this, CoreDispatcherPriority priority, Action action)
	{
		return @this.RunAsync(priority, () => action()).AsTask();
	}

	public static Task RunIdleAsync(this CoreDispatcher @this, Action action)
	{
		return @this.RunIdleAsync(e => action()).AsTask();
	}

	#endregion Awaitable Methods

	#region Awaitable Methods with result

	public static Task<TResult?> RunAsync<TResult>(this CoreDispatcher @this, Func<TResult?> func)
	{
		return @this.RunAsync(CoreDispatcherPriority.Normal, func);
	}

	public static async Task<TResult?> RunAsync<TResult>(this CoreDispatcher @this, CoreDispatcherPriority priority, Func<TResult?> func)
	{
		var result = default(TResult);
		await @this.RunAsync(priority, () => result = func());
		return result;
	}

	public static async Task<TResult?> RunIdleAsync<TResult>(this CoreDispatcher @this, Func<TResult?> func)
	{
		var result = default(TResult);
		await @this.RunIdleAsync(e => result = func());
		return result;
	}

	public static async Task<TResult?> RunIdleAsync<TResult>(this CoreDispatcher @this, Func<bool, TResult?> func)
	{
		var result = default(TResult);
		await @this.RunIdleAsync(e => result = func(e.IsDispatcherIdle));
		return result;
	}

	#endregion Awaitable Methods
}

