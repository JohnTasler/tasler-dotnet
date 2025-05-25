using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Tasler.Threading;

public static class DelegateInvoker
{
	public static void Invoke(Delegate theDelegate, params object[] parameters)
	{
		SynchronizedInvoker.EnsureRegistered();

		if (theDelegate != null)
		{
			foreach (Delegate d in theDelegate.GetInvocationList())
			{
				try
				{
					ISynchronizeInvoke syncInvoke = SynchronizedInvoker.Instance.GetSynchronizeInvokeForTarget(d.Target);
					if (syncInvoke != null && syncInvoke.InvokeRequired)
					{
						syncInvoke.Invoke(d, parameters);
					}
					else
					{
						d.Method.Invoke(d.Target, parameters);
					}
				}
				catch (Exception e)
				{
					Debug.WriteLine(string.Format("While invoking a delegate:\n{0}", e));
				}
			}
		}
	}
}
