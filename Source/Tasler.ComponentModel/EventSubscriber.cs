
namespace Tasler.ComponentModel;

public sealed class EventSubscriber<TDelegate>
	where TDelegate : Delegate
{
	public TDelegate? Handler { get; private set; }

	private EventSubscriber(TDelegate? handler)
	{
		this.Handler = handler;
	}

	public static EventSubscriber<TDelegate> operator +(EventSubscriber<TDelegate> source, TDelegate handler)
	{
		var result = (source is not null && source.Handler is not null)
			? Delegate.Combine(source.Handler as Delegate, handler as Delegate) as TDelegate
			: handler;

		return new EventSubscriber<TDelegate>(result!);
	}

	public static EventSubscriber<TDelegate> operator -(EventSubscriber<TDelegate> source, TDelegate handler)
	{
		if (source is not null)
		{
			source.Handler = Delegate.Remove(source.Handler as Delegate, handler as Delegate) as TDelegate;
			if (source.Handler is null)
				source = null!;
		}

		return source!;
	}
}
