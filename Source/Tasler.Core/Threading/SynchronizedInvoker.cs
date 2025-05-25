using System;
using System.ComponentModel;

namespace Tasler.Threading;

public abstract class SynchronizedInvoker
{
	#region Static Fields
	private static readonly object staticLock = new object();
	private static SynchronizedInvoker instance;
	#endregion Static Fields

	#region Properties
	public static SynchronizedInvoker Instance
	{
		get
		{
			lock (SynchronizedInvoker.staticLock)
				return SynchronizedInvoker.instance;
		}
		protected set
		{
			lock (SynchronizedInvoker.staticLock)
				SynchronizedInvoker.instance = value;
		}
	}
	#endregion Properties

	#region Methods
	public static void EnsureRegistered()
	{
		if (SynchronizedInvoker.Instance == null)
			throw new InvalidOperationException(Properties.Resources.ExceptionMessage_SynchronizedInvokerNotRegistered);
	}
	#endregion Methods

	#region Overridables
	public abstract ISynchronizeInvoke GetSynchronizeInvokeForTarget(object target);
	#endregion Overridables
}
