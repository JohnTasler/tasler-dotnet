using Windows.System;

namespace Tasler.UI.Core;

public static class DispatcherQueueExtensions
{
	#region Non-waiting (fire-and-forget) Methods

	public static void RunAsyncNoWait(this DispatcherQueue @this, Action action)
	{
		@this.RunAsyncNoWait(DispatcherQueuePriority.Normal, action);
	}

	public static void RunAsyncNoWait(this DispatcherQueue @this, DispatcherQueuePriority priority, Action action)
	{
		_ = @this.RunAsync(priority, () => action());
	}

	public static void RunIdleAsyncNoWait(this DispatcherQueue @this, Action action)
	{
		_ = @this.TryEnqueue(() => action());
	}

	#endregion Non-waiting (fire-and-forget) Methods

	#region Awaitable Methods

	public static Task RunAsync(this DispatcherQueue @this, Action action)
	{
		return @this.RunAsync(DispatcherQueuePriority.Normal, action);
	}

	public static Task RunAsync(this DispatcherQueue @this, DispatcherQueuePriority priority, Action action)
	{
		return @this.TryEnqueue(priority, () => action()).AsTask();
	}

	public static Task RunIdleAsync(this DispatcherQueue @this, Action action)
	{
		return @this.RunIdleAsync(e => action()).AsTask();
	}

	#endregion Awaitable Methods

	#region Awaitable Methods with result

	public static Task<TResult?> RunAsync<TResult>(this DispatcherQueue @this, Func<TResult?> func)
	{
		return @this.RunAsync(DispatcherQueuePriority.Normal, func);
	}

	public static async Task<TResult?> RunAsync<TResult>(this DispatcherQueue @this, DispatcherQueuePriority priority, Func<TResult?> func)
	{
		var result = default(TResult);
		await @this.RunAsync(priority, () => result = func());
		return result;
	}

	public static async Task<TResult?> RunIdleAsync<TResult>(this DispatcherQueue @this, Func<TResult?> func)
	{
		var result = default(TResult);
		await @this.RunIdleAsync(e => result = func());
		return result;
	}

	public static async Task<TResult?> RunIdleAsync<TResult>(this DispatcherQueue @this, Func<bool, TResult?> func)
	{
		var result = default(TResult);
		await @this.RunIdleAsync(e => result = func(e.IsDispatcherIdle));
		return result;
	}

	#endregion Awaitable Methods
}

