using System;
using System.Windows.Threading;

namespace Tasler.Windows.Extensions
{
	/// <summary>
	/// Provides extension methods for instances of the <see cref="Dispatcher"/> type.
	/// </summary>
	public static class DispatcherExtensions
	{
		/// <summary>
		/// Executes the specified <paramref name="action"/> asynchronously on the thread that the
		/// <see cref="Dispatcher"/> was created on.
		/// </summary>
		/// <param name="source">The <see cref="Dispatcher"/> on which to post the asynchronous operation.</param>
		/// <param name="action">The action to be pushed onto the <see cref="Dispatcher"/> event queue.</param>
		/// <returns>
		/// An object, which is returned immediately after
		/// <see cref="DispatcherExtensions.BeginInvoke(Dispatcher, Action)"/> is called, that can be
		/// used to interact with the delegate as it is pending execution in the event queue.
		/// </returns>
		/// <summary>
		/// Asynchronously executes the specified action on the thread associated with the dispatcher.
		/// </summary>
		/// <param name="action">The action to execute.</param>
		/// <returns>A DispatcherOperation representing the asynchronous operation.</returns>
		/// <exception cref="System.ArgumentNullException">The specified <paramref name="source"/> is <see langword="null"/>.</exception>
		public static DispatcherOperation BeginInvoke(this Dispatcher source, Action action)
		{
			ValidateSource(source);
			return source.BeginInvoke(action);
		}

#if !SILVERLIGHT
		/// <summary>
		/// Executes the specified <paramref name="action"/> asynchronously on the thread that the
		/// <see cref="Dispatcher"/> was created on.
		/// </summary>
		/// <param name="source">The <see cref="Dispatcher"/> on which to post the asynchronous operation.</param>
		/// <param name="priority">The priority that the specified action is invoked, relative to the other pending
		/// operations in the <see cref="Dispatcher"/> event queue.</param>
		/// <param name="action">The action to be pushed onto the <see cref="Dispatcher"/> event queue.</param>
		/// <returns>
		/// An object, which is returned immediately after
		/// <see cref="DispatcherExtensions.BeginInvoke(Dispatcher, Action)"/> is called, that can be
		/// used to interact with the delegate as it is pending execution in the event queue.
		/// </returns>
		/// <summary>
		/// Asynchronously executes the specified action on the dispatcher's thread with the given priority.
		/// </summary>
		/// <param name="priority">The priority at which to invoke the action.</param>
		/// <param name="action">The action to execute on the dispatcher thread.</param>
		/// <returns>A DispatcherOperation representing the asynchronous operation.</returns>
		/// <exception cref="System.ArgumentNullException">The specified <paramref name="source"/> is <see langword="null"/>.</exception>
		public static DispatcherOperation BeginInvoke(this Dispatcher source, DispatcherPriority priority, Action action)
		{
			ValidateSource(source);
			return source.BeginInvoke((Delegate)action, priority);
		}
#endif // !SILVERLIGHT

		/// <summary>
		/// Executes the specified <paramref name="action"/> synchronously on the thread that the
		/// <see cref="Dispatcher"/> was created on.
		/// </summary>
		/// <param name="source">The <see cref="Dispatcher"/> on which to invoke the synchronous operation.</param>
		/// <param name="action">The action to be synchronously executed on the <see cref="Dispatcher"/> thread.</param>
		/// <summary>
		/// Executes the specified action synchronously on the dispatcher's thread.
		/// </summary>
		/// <param name="action">The action to execute.</param>
		/// <exception cref="System.ArgumentNullException">The specified <paramref name="source"/> is <see langword="null"/>.</exception>
		public static void Invoke(this Dispatcher source, Action action)
		{
			ValidateSource(source);
			source.Invoke(action);
		}

		/// <summary>
		/// Executes the specified <paramref name="function" /> synchronously on the thread that the
		/// <see cref="Dispatcher" /> was created on.
		/// </summary>
		/// <typeparam name="T">The return type of the <paramref name="function"/>.</typeparam>
		/// <param name="source">The <see cref="Dispatcher" /> on which to invoke the synchronous operation.</param>
		/// <param name="function">The function to be synchronously executed on the <see cref="Dispatcher"/> thread.</param>
		/// <returns>The return value from the <paramref name="function"/>.</returns>
		/// <summary>
		/// Executes the specified function synchronously on the dispatcher's thread and returns its result.
		/// </summary>
		/// <typeparam name="T">The type of the result returned by the function.</typeparam>
		/// <param name="function">The function to execute on the dispatcher's thread.</param>
		/// <returns>The result of the executed function.</returns>
		/// <exception cref="System.ArgumentNullException">The specified <paramref name="source"/> is <see langword="null"/>.</exception>
		public static T Invoke<T>(this Dispatcher source, Func<T> function)
		{
			ValidateSource(source);
			return (T)source.Invoke(function);
		}


		#region Private Implementation
		private static void ValidateSource(Dispatcher source)
		{
			if (source == null)
				throw new ArgumentNullException("source");
		}
		#endregion Private Implementation
	}
}
