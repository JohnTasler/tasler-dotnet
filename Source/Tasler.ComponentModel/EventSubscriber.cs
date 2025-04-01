namespace Tasler.ComponentModel;

// TODO: NEEDS_UNIT_TESTS

public sealed class EventSubscriber<TDelegate>
		where TDelegate : System.Delegate
{
	public TDelegate? Handler { get; private set; }

	private EventSubscriber(TDelegate? handler)
	{
		this.Handler = handler;
	}

	public static EventSubscriber<TDelegate> operator +(EventSubscriber<TDelegate>? source, TDelegate handler)
	{
		var result = (source != null && source.Handler != null)
				? Delegate.Combine(source.Handler, handler) as TDelegate
				: handler;

		return new EventSubscriber<TDelegate>(result);
	}

	public static EventSubscriber<TDelegate>? operator -(EventSubscriber<TDelegate>? source, TDelegate handler)
	{
		if (source != null)
		{
			source.Handler = Delegate.Remove(source.Handler as Delegate, handler as Delegate) as TDelegate;
			if (source.Handler == null)
				source = null;
		}

		return source;
	}
}
