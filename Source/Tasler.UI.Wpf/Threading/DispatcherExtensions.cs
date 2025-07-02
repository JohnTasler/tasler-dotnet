using System.Windows.Threading;
using CommunityToolkit.Diagnostics;

namespace Tasler.Windows.Threading;

/// <summary>
/// Provides extension methods for the <see cref="Dispatcher"/> class to simplify asynchronous and
/// fire-and-forget execution of actions and functions, including support for specifying dispatcher
/// priority and idle execution.
/// </summary>
public static class DispatcherExtensions
{
	#region Non-waiting (fire-and-forget) Methods

	/// <summary>
	/// Executes the specified <paramref name="action"/> asynchronously on the dispatcher at normal
	/// priority, without waiting for completion.
	/// </summary>
	/// <param name="this">The dispatcher to use for execution.</param>
	/// <param name="action">The action to execute.</param>
	public static void RunAsyncNoWait(this Dispatcher @this, Action action)
		=> @this.RunAsyncNoWait(DispatcherPriority.Normal, action);

	/// <summary>
	/// Executes the specified <paramref name="action"/> asynchronously on the dispatcher at the
	/// given <paramref name="priority"/>, without waiting for completion.
	/// </summary>
	/// <param name="this">The dispatcher to use for execution.</param>
	/// <param name="priority">The priority at which to invoke the action.</param>
	/// <param name="action">The action to execute.</param>
	public static void RunAsyncNoWait(this Dispatcher @this, DispatcherPriority priority, Action action)
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(action);
		var unused = @this.RunAsync(priority, () => action());
	}

	/// <summary>
	/// Executes the specified <paramref name="action"/> asynchronously on the dispatcher at idle
	/// priority, without waiting for completion.
	/// </summary>
	/// <param name="this">The dispatcher to use for execution.</param>
	/// <param name="action">The action to execute.</param>
	public static void RunIdleAsyncNoWait(this Dispatcher @this, Action action)
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(action);
		var unused = @this.RunIdleAsync(() => action());
	}

	#endregion Non-waiting (fire-and-forget) Methods

	#region Awaitable Methods

	/// <summary>
	/// Executes the specified <paramref name="action"/> asynchronously on the dispatcher at normal
	/// priority and returns a task that completes when the action has finished.
	/// </summary>
	/// <param name="this">The dispatcher to use for execution.</param>
	/// <param name="action">The action to execute.</param>
	/// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
	public static Task RunAsync(this Dispatcher @this, Action action)
		=> @this.RunAsync(DispatcherPriority.Normal, action);

	/// <summary>
	/// Executes the specified <paramref name="action"/> asynchronously on the dispatcher at the given
	/// <paramref name="priority"/> and returns a task that completes when the action has finished.
	/// </summary>
	/// <param name="this">The dispatcher to use for execution.</param>
	/// <param name="priority">The priority at which to invoke the action.</param>
	/// <param name="action">The action to execute.</param>
	/// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
	public static Task RunAsync(this Dispatcher @this, DispatcherPriority priority, Action action)
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(action);
		return @this.InvokeAsync(action, priority).Task;
	}

	/// <summary>
	/// Executes the specified <paramref name="action"/> asynchronously on the dispatcher at idle
	/// priority and returns a task that completes when the action has finished.
	/// </summary>
	/// <param name="this">The dispatcher to use for execution.</param>
	/// <param name="action">The action to execute.</param>
	/// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
	public static Task RunIdleAsync(this Dispatcher @this, Action action)
	{
		return @this.RunAsync(DispatcherPriority.ContextIdle, action);
	}

	#endregion Awaitable Methods

	#region Awaitable Methods with result

	/// <summary>
	/// Executes the specified <paramref name="func"/> asynchronously on the dispatcher at normal
	/// priority and returns a task that completes with the function's result.
	/// </summary>
	/// <typeparam name="TResult">The type of the result returned by the function.</typeparam>
	/// <param name="this">The dispatcher to use for execution.</param>
	/// <param name="func">The function to execute.</param>
	/// <returns>
	/// A <see cref="Task{TResult}"/> that represents the asynchronous operation and contains
	/// the result.
	/// </returns>
	public static Task<TResult> RunAsync<TResult>(this Dispatcher @this, Func<TResult> func)
		=> @this.RunAsync(DispatcherPriority.Normal, func);

	/// <summary>
	/// Executes the specified <paramref name="func"/> asynchronously on the dispatcher at the given
	/// <paramref name="priority"/> and returns a task that completes with the function's result.
	/// </summary>
	/// <typeparam name="TResult">The type of the result returned by the function.</typeparam>
	/// <param name="this">The dispatcher to use for execution.</param>
	/// <param name="priority">The priority at which to invoke the function.</param>
	/// <param name="func">The function to execute.</param>
	/// <returns>
	/// A <see cref="Task{TResult}"/> that represents the asynchronous operation and contains the
	/// result of the invoked <paramref name="func"/>.
	/// </returns>
	public static async Task<TResult> RunAsync<TResult>(this Dispatcher @this, DispatcherPriority priority, Func<TResult> func)
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(func);
		return await @this.InvokeAsync<TResult>(func, priority);
	}

	/// <summary>
	/// Executes the specified <paramref name="func"/> asynchronously on the dispatcher at idle
	/// priority and returns a task that completes with the function's result.
	/// </summary>
	/// <typeparam name="TResult">The type of the result returned by the function.</typeparam>
	/// <param name="this">The dispatcher to use for execution.</param>
	/// <param name="func">The function to execute.</param>
	/// <returns>
	/// A <see cref="Task{TResult}"/> that represents the asynchronous operation and contains the
	/// result of the invoked <paramref name="func"/>.
	/// </returns>
	public static async Task<TResult?> RunIdleAsync<TResult>(this Dispatcher @this, Func<TResult> func)
	{
		Guard.IsNotNull(@this);
		Guard.IsNotNull(func);
		var result = default(TResult);
		await @this.RunIdleAsync(() => result = func());
		return result;
	}

	#endregion Awaitable Methods
}
