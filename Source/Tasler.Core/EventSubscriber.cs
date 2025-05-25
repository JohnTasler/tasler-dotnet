using System;
using Tasler.Extensions;

namespace Tasler;

public sealed class EventSubscriber<TDelegate>
	where TDelegate : class
{
	public TDelegate Handler { get; private set; }

	/// <summary>
	/// Initializes the <see cref="EventSubscriber{TDelegate}" /> class.
	/// </summary>
	/// <exception cref="System.InvalidCastException">The <typeparamref name="TDelegate"/> is not a <see cref="Delegate"/> type.</exception>
	static EventSubscriber()
	{
		// Unfortunately, the C# compiler does not allow Delegate or MulticastDelegate as generic type constraints,
		// so we have to check at runtime.
		if (!typeof(TDelegate).Is<Delegate>())
			throw new InvalidCastException(Properties.Resources.TDelegateMustBeDelegate);
	}

	private EventSubscriber(TDelegate handler)
	{
		this.Handler = handler;
	}

	public static EventSubscriber<TDelegate> operator +(EventSubscriber<TDelegate> source, TDelegate handler)
	{
		var result = (source != null && source.Handler != null)
			? Delegate.Combine(source.Handler as Delegate, handler as Delegate) as TDelegate
			: handler;

		return new EventSubscriber<TDelegate>(result);
	}

	public static EventSubscriber<TDelegate> operator -(EventSubscriber<TDelegate> source, TDelegate handler)
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
