//======================================================================================
// Based on Prism 4.1.0.0.
// Namespace renamed from Microsoft.Practices.Prism.Commands to Tasler.Windows.Commands.
//
// This allows the library components to provide delagate-based ICommand implementations
// without taking a dependency on the Prism library.
//======================================================================================

//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation and Silverlight
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================

using System.Windows;
using System.Windows.Threading;

namespace Tasler.Windows.Commands;

/// <summary>
/// Handles management and dispatching of EventHandlers in a weak way.
/// </summary>
internal static class WeakEventHandlerManager
{
	///<summary>
	/// Invokes the handlers
	///</summary>
	///<param name="sender"></param>
	///<param name="handlers"></param>
	public static void CallWeakReferenceHandlers(object sender, List<WeakReference> handlers)
	{
		if (handlers is not null)
		{
			// Take a snapshot of the handlers before we call out to them since the handlers
			// could cause the array to me modified while we are reading it.
			EventHandler[] callees = new EventHandler[handlers.Count];
			int count = 0;

			//Clean up handlers
			count = CleanupOldHandlers(handlers, callees, count);

			// Call the handlers that we snapshotted
			for (int i = 0; i < count; i++)
			{
				CallHandler(sender, callees[i]);
			}
		}
	}

	private static void CallHandler(object sender, EventHandler eventHandler)
	{
		DispatcherProxy? dispatcher = DispatcherProxy.CreateDispatcher();

		if (eventHandler is not null)
		{
			if (dispatcher is not null && !dispatcher.CheckAccess())
			{
				dispatcher.BeginInvoke((Action<object, EventHandler>)CallHandler, sender, eventHandler);
			}
			else
			{
				eventHandler(sender, EventArgs.Empty);
			}
		}
	}

	/// <summary>
	/// Hides the dispatcher mis-match between Silverlight and .Net, largely so code reads a bit easier
	/// </summary>
	private class DispatcherProxy
	{
		Dispatcher _innerDispatcher;

		private DispatcherProxy(Dispatcher dispatcher)
		{
			_innerDispatcher = dispatcher;
		}

		public static DispatcherProxy? CreateDispatcher()
		{
			DispatcherProxy? proxy = null;
			if (Application.Current == null)
				return null;

			proxy = new DispatcherProxy(Application.Current.Dispatcher);
			return proxy;
		}

		public bool CheckAccess()
		{
			return _innerDispatcher.CheckAccess();
		}

		public DispatcherOperation BeginInvoke(Delegate method, params Object[] args)
		{
			return _innerDispatcher.BeginInvoke(method, DispatcherPriority.Normal, args);
		}
	}

	private static int CleanupOldHandlers(List<WeakReference> handlers, EventHandler[] callees, int count)
	{
		for (int i = handlers.Count - 1; i >= 0; i--)
		{
			WeakReference reference = handlers[i];
			if (reference.Target is not EventHandler handler)
			{
				// Clean up old handlers that have been collected
				handlers.RemoveAt(i);
			}
			else
			{
				callees[count] = handler;
				count++;
			}
		}
		return count;
	}

	///<summary>
	/// Adds a handler to the supplied list in a weak way.
	///</summary>
	///<param name="handlers">Existing handler list.  It will be created if null.</param>
	///<param name="handler">Handler to add.</param>
	///<param name="defaultListSize">Default list size.</param>
	public static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler handler, int defaultListSize)
	{
		if (handlers == null)
		{
			handlers = (defaultListSize > 0 ? new List<WeakReference>(defaultListSize) : new List<WeakReference>());
		}

		handlers.Add(new WeakReference(handler));
	}

	///<summary>
	/// Removes an event handler from the reference list.
	///</summary>
	///<param name="handlers">Handler list to remove reference from.</param>
	///<param name="handler">Handler to remove.</param>
	public static void RemoveWeakReferenceHandler(List<WeakReference> handlers, EventHandler handler)
	{
		if (handlers != null)
		{
			for (int i = handlers.Count - 1; i >= 0; i--)
			{
				WeakReference reference = handlers[i];
				if ((reference.Target is not EventHandler existingHandler) || (existingHandler == handler))
				{
					// Clean up old handlers that have been collected
					// in addition to the handler that is to be removed.
					handlers.RemoveAt(i);
				}
			}
		}
	}
}
