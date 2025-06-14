using System;
using System.Windows.Threading;
using CommunityToolkit.Diagnostics;

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
		/// <param name="this">The <see cref="Dispatcher"/> on which to post the asynchronous operation.</param>
		/// <param name="action">The action to be pushed onto the <see cref="Dispatcher"/> event queue.</param>
		/// <returns>
		/// An object, which is returned immediately after
		/// <see cref="DispatcherExtensions.BeginInvoke(Dispatcher, Action)"/> is called, that can be
		/// used to interact with the delegate as it is pending execution in the event queue.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified <paramref name="this"/> is <see langword="null"/>.
		/// </exception>
		public static DispatcherOperation BeginInvoke(this Dispatcher @this, Action action)
		{
			ValidateSource(@this);
			return @this.BeginInvoke(action);
		}

#if !SILVERLIGHT
		/// <summary>
		/// Executes the specified <paramref name="action"/> asynchronously on the thread that the
		/// <see cref="Dispatcher"/> was created on.
		/// </summary>
		/// <param name="this">The <see cref="Dispatcher"/> on which to post the asynchronous operation.</param>
		/// <param name="priority">The priority that the specified action is invoked, relative to the other pending
		/// operations in the <see cref="Dispatcher"/> event queue.</param>
		/// <param name="action">The action to be pushed onto the <see cref="Dispatcher"/> event queue.</param>
		/// <returns>
		/// An object, which is returned immediately after
		/// <see cref="DispatcherExtensions.BeginInvoke(Dispatcher, Action)"/> is called, that can be
		/// used to interact with the delegate as it is pending execution in the event queue.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">
		/// Thrown if the specified <paramref name="this"/> is <see langword="null"/>.
		/// </exception>
		public static DispatcherOperation BeginInvoke(this Dispatcher @this, DispatcherPriority priority, Action action)
		{
			ValidateSource(@this);
			return @this.BeginInvoke((Delegate)action, priority);
		}
#endif // !SILVERLIGHT

		/// <summary>
		/// Executes the specified <paramref name="action"/> synchronously on the thread that the
		/// <see cref="Dispatcher"/> was created on.
		/// </summary>
		/// <param name="this">The <see cref="Dispatcher"/> on which to invoke the synchronous operation.</param>
		/// <param name="action">The action to be synchronously executed on the <see cref="Dispatcher"/> thread.</param>
		/// <exception cref="System.ArgumentNullException">
		/// Thrown if the specified <paramref name="this"/> is <see langword="null"/>.
		/// </exception>
		public static void Invoke(this Dispatcher @this, Action action)
		{
			ValidateSource(@this);
			@this.Invoke(action);
		}

		/// <summary>
		/// Executes the specified <paramref name="function" /> synchronously on the thread that the
		/// <see cref="Dispatcher" /> was created on.
		/// </summary>
		/// <typeparam name="T">The return type of the <paramref name="function"/>.</typeparam>
		/// <param name="this">The <see cref="Dispatcher" /> on which to invoke the synchronous operation.</param>
		/// <param name="function">The function to be synchronously executed on the <see cref="Dispatcher"/> thread.</param>
		/// <returns>The return value from the <paramref name="function"/>.</returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the specified <paramref name="this"/> is <see langword="null"/>.
		/// </exception>
		public static T Invoke<T>(this Dispatcher @this, Func<T> function)
		{
			ValidateSource(@this);
			return (T)@this.Invoke(function);
		}

		#region Private Implementation
		private static void ValidateSource(Dispatcher @this) => Guard.IsNotNull(@this);
		#endregion Private Implementation
	}
}
