using System;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Tasler.Windows.Threading
{
    public static class DispatcherExtensions
    {
        #region Non-waiting (fire-and-forget) Methods

        public static void RunAsyncNoWait(this Dispatcher @this, Action action)
        {
            @this.RunAsyncNoWait(DispatcherPriority.Normal, action);
        }

        public static void RunAsyncNoWait(this Dispatcher @this, DispatcherPriority priority, Action action)
        {
            ValidateArgument.IsNotNull(@this, nameof(@this));
            ValidateArgument.IsNotNull(action, nameof(action));
            var unused = @this.RunAsync(priority, () => action());
        }

        public static void RunIdleAsyncNoWait(this Dispatcher @this, Action action)
        {
            ValidateArgument.IsNotNull(@this, nameof(@this));
            ValidateArgument.IsNotNull(action, nameof(action));
            var unused = @this.RunIdleAsync(() => action());
        }

        #endregion Non-waiting (fire-and-forget) Methods

        #region Awaitable Methods

        public static Task RunAsync(this Dispatcher @this, Action action)
        {
            return @this.RunAsync(DispatcherPriority.Normal, action);
        }

        public static Task RunAsync(this Dispatcher @this, DispatcherPriority priority, Action action)
        {
            ValidateArgument.IsNotNull(@this, nameof(@this));
            ValidateArgument.IsNotNull(action, nameof(action));
            return @this.InvokeAsync(action, priority).Task;
        }

        public static Task RunIdleAsync(this Dispatcher @this, Action action)
        {
            return @this.RunAsync(DispatcherPriority.ContextIdle, action);
        }

        #endregion Awaitable Methods

        #region Awaitable Methods with result

        public static Task<TResult> RunAsync<TResult>(this Dispatcher @this, Func<TResult> func)
        {
            return @this.RunAsync(DispatcherPriority.Normal, func);
        }

        public static async Task<TResult> RunAsync<TResult>(this Dispatcher @this, DispatcherPriority priority, Func<TResult> func)
        {
            ValidateArgument.IsNotNull(@this, nameof(@this));
            ValidateArgument.IsNotNull(func, nameof(func));
            return await @this.InvokeAsync<TResult>(func, priority);
        }

        public static async Task<TResult> RunIdleAsync<TResult>(this Dispatcher @this, Func<TResult> func)
        {
            ValidateArgument.IsNotNull(@this, nameof(@this));
            ValidateArgument.IsNotNull(func, nameof(func));
            var result = default(TResult);
            await @this.RunIdleAsync(() => result = func());
            return result;
        }

        //public static async Task<TResult> RunIdleAsync<TResult>(this Dispatcher @this, Func<bool, TResult> func)
        //{
        //    ValidateArgument.IsNotNull(@this, nameof(@this));
        //    ValidateArgument.IsNotNull(func, nameof(func));
        //    var result = default(TResult);
        //    await @this.RunIdleAsync(e => result = func(true));
        //    return result;
        //}

        #endregion Awaitable Methods

    }
}
