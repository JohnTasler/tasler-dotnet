
namespace Tasler.Interop.Com;

public class GitHandleBase : IDisposable
{
	#region Instance Fields
	private int _cookie;
	#endregion Instance Fields

	#region Properties

	protected static IGlobalInterfaceTable Git => ComApi.GetGlobalInterfaceTable();

	public int Cookie
	{
		get => _cookie;
		protected set => Interlocked.Exchange(ref _cookie, value);
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
			IGlobalInterfaceTableExtensions.RevokeInterfaceFromGlobal(Git, cookie);
			GC.SuppressFinalize(this);
		}
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
		base.Cookie = Git.RegisterInterfaceInGlobal(unknown, iid);
	}
	#endregion Construction

	#region Properties
	public T Interface
	{
		get
		{
			Guid iid = typeof(T).GUID;
			return Git.GetInterfaceFromGlobal<T>(base.Cookie);
		}
	}
	#endregion Properties
}
