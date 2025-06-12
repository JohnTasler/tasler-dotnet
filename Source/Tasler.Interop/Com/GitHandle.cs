using System.Runtime.InteropServices;

namespace Tasler.Interop.Com;

public class GitHandleBase : IDisposable
{
	#region Instance Fields
	private int _cookie;
	#endregion Instance Fields

	#region Properties

	protected static IGlobalInterfaceTable Git { get; } = (IGlobalInterfaceTable)new StdGlobalInterfaceTable();

	public int Cookie
	{
		get => _cookie;
		protected set => Interlocked.CompareExchange(ref _cookie, value, 0);
	}

	#endregion Properties

	#region Methods
	public int DetachCookie()
	{
		var cookie = Interlocked.Exchange(ref _cookie, 0);
		return cookie;
	}
	#endregion Methods

	#region Construction / Finalization

	protected GitHandleBase()
	{
	}

	~GitHandleBase()
	{
		this.Dispose();
	}

	#endregion Construction / Finalization

	#region IDisposable Members

	public void Dispose()
	{
		var cookie = Interlocked.Exchange(ref _cookie, 0);
		if (cookie != 0)
		{
			Git.RevokeInterfaceFromGlobal(cookie);
		}

		GC.SuppressFinalize(this);
	}

	#endregion IDisposable Members
}

public class GitHandle<T> : GitHandleBase
	where T : class
{
	#region Construction
	public GitHandle(T unknown)
	{
		Guid iid = typeof(T).GUID;
		int hr = Git.RegisterInterfaceInGlobal(unknown, ref iid, out int cookie);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);
		else
			base.Cookie = cookie;
	}
	#endregion Construction

	#region Properties
	public T Interface
	{
		get
		{
			Guid iid = typeof(T).GUID;
			int hr = Git.GetInterfaceFromGlobal(base.Cookie, ref iid, out var unknown);
			if (hr < 0)
				Marshal.ThrowExceptionForHR(hr);
			return (T)unknown;
		}
	}
	#endregion Properties
}
