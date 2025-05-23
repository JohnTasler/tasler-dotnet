using System.Collections;
using System.Collections.Specialized;

namespace Tasler;

public static class NotifyCollectionChangedEventHandlerExtensions
{
#if !SILVERLIGHT
	public static bool RaiseReset(this NotifyCollectionChangedEventHandler handler, object sender)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		return true;
	}

	public static bool RaiseReset(this NotifyCollectionChangedEventHandler handler, object sender, object changedItem)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, changedItem));
		return true;
	}

	public static bool RaiseReset(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, changedItems));
		return true;
	}

	public static bool RaiseReset(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems, int startingIndex)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, changedItems, startingIndex));
		return true;
	}

	public static bool RaiseAdd(this NotifyCollectionChangedEventHandler handler, object sender, object changedItem)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItem));
		return true;
	}

	public static bool RaiseAdd(this NotifyCollectionChangedEventHandler handler, object sender, object changedItem, int index)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItem, index));
		return true;
	}

	public static bool RaiseAdd(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItems));
		return true;
	}

	public static bool RaiseAdd(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems, int startingIndex)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItems, startingIndex));
		return true;
	}

	public static bool RaiseRemove(this NotifyCollectionChangedEventHandler handler, object sender, object changedItem)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, changedItem));
		return true;
	}

	public static bool RaiseRemove(this NotifyCollectionChangedEventHandler handler, object sender, object changedItem, int index)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, changedItem, index));
		return true;
	}

	public static bool RaiseRemove(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, changedItems));
		return true;
	}

	public static bool RaiseRemove(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems, int startingIndex)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, changedItems, startingIndex));
		return true;
	}

	public static bool RaiseReplace(this NotifyCollectionChangedEventHandler handler, object sender, object newItem, object oldItem)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItem, oldItem));
		return true;
	}

	public static bool RaiseReplace(this NotifyCollectionChangedEventHandler handler, object sender, object newItem, object oldItem, int index)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItem, oldItem, index));
		return true;
	}

	public static bool RaiseReplace(this NotifyCollectionChangedEventHandler handler, object sender, IList newItems, IList oldItems)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItems, oldItems));
		return true;
	}

	public static bool RaiseReplace(this NotifyCollectionChangedEventHandler handler, object sender, IList newItems, IList oldItems, int startingIndex)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItems, oldItems, startingIndex));
		return true;
	}

#else // !SILVERLIGHT

	public static bool RaiseReset(this NotifyCollectionChangedEventHandler handler, object sender)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		return true;
	}

	public static bool RaiseReset(this NotifyCollectionChangedEventHandler handler, object sender, object changedItem)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, changedItem, -1));
		return true;
	}

	public static bool RaiseReset(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems)
	{
		if (handler == null)
			return false;

		if (changedItems != null)
			foreach (var changedItem in changedItems)
				handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, changedItem, -1));
		return true;
	}

	public static bool RaiseReset(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems, int startingIndex)
	{
		throw new NotImplementedException();

		// TODO: implement this if needed
		#if false
			if (handler == null)
				return false;

			// TODO:

			return true;
		#endif
	}

	public static bool RaiseAdd(this NotifyCollectionChangedEventHandler handler, object sender, object changedItem)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItem, -1));
		return true;
	}

	public static bool RaiseAdd(this NotifyCollectionChangedEventHandler handler, object sender, object changedItem, int index)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItem, index));
		return true;
	}

	public static bool RaiseAdd(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems)
	{
		if (handler == null)
			return false;

		if (changedItems != null)
			foreach (var changedItem in changedItems)
				handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItem, -1));
		return true;
	}

	public static bool RaiseAdd(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems, int startingIndex)
	{
		if (handler == null)
			return false;

		if (changedItems != null)
			foreach (var changedItem in changedItems)
				handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItem, startingIndex++));
		return true;
	}

	public static bool RaiseRemove(this NotifyCollectionChangedEventHandler handler, object sender, object changedItem)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, changedItem, -1));
		return true;
	}

	public static bool RaiseRemove(this NotifyCollectionChangedEventHandler handler, object sender, object changedItem, int index)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, changedItem, index));
		return true;
	}

	public static bool RaiseRemove(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems)
	{
		if (handler == null)
			return false;

		if (changedItems != null)
			foreach (var changedItem in changedItems)
				handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, changedItem, -1));

		return true;
	}

	public static bool RaiseRemove(this NotifyCollectionChangedEventHandler handler, object sender, IList changedItems, int startingIndex)
	{
		if (handler == null)
			return false;

		if (changedItems != null)
			foreach (var changedItem in changedItems)
				handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, changedItem, startingIndex++));
		return true;
	}

	public static bool RaiseReplace(this NotifyCollectionChangedEventHandler handler, object sender, object newItem, object oldItem)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItem, oldItem, -1));
		return true;
	}

	public static bool RaiseReplace(this NotifyCollectionChangedEventHandler handler, object sender, object newItem, object oldItem, int index)
	{
		if (handler == null)
			return false;

		handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItem, oldItem, index));
		return true;
	}

	public static bool RaiseReplace(this NotifyCollectionChangedEventHandler handler, object sender, IList newItems, IList oldItems)
	{
		if (handler == null)
			return false;

		if (oldItems != null && newItems != null && oldItems.Count == newItems.Count)
			for (var index = 0; index < oldItems.Count; ++index)
				handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItems[index], oldItems[index], -1));
		return true;
	}

	public static bool RaiseReplace(this NotifyCollectionChangedEventHandler handler, object sender, IList newItems, IList oldItems, int startingIndex)
	{
		if (handler == null)
			return false;

		if (oldItems != null && newItems != null && oldItems.Count == newItems.Count)
			for (var index = 0; index < oldItems.Count; ++index)
				handler(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItems[index], oldItems[index], startingIndex + index));
		return true;
	}

#endif // !SILVERLIGHT
}
