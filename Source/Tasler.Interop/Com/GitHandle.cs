using System;
using System.Runtime.InteropServices;

namespace Tasler.Interop.Com
{
	public class GitHandleBase : IDisposable
	{
		#region Static Fields
		private static GlobalInterfaceTable git = new GlobalInterfaceTable();
		#endregion Static Fields

		#region Instance Fields
		protected int cookie;
		#endregion Instance Fields

		#region Properties

		protected static IGlobalInterfaceTable Git
		{
			get
			{
				if (git == null)
					git = (GlobalInterfaceTable)new GlobalInterfaceTable();
				return git;
			}
		}

		public int Cookie
		{
			get
			{
				return this.cookie;
			}
		}
		#endregion Properties

		#region Methods
		public int DetachCookie()
		{
			int result = this.cookie;
			this.cookie = 0;
			return result;
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
			if (this.cookie != 0)
			{
				Git.RevokeInterfaceFromGlobal(this.cookie);
				this.cookie = 0;
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
			if (unknown == null)
				throw new ArgumentNullException("unknown");

			Guid iid = typeof(T).GUID;
			int hr = Git.RegisterInterfaceInGlobal(unknown, ref iid, out base.cookie);
			if (hr < 0)
				Marshal.ThrowExceptionForHR(hr);
		}
		#endregion Construction

		#region Properties
		public T Interface
		{
			get
			{
				object unknown;
				Guid iid = typeof(T).GUID;
				int hr = Git.GetInterfaceFromGlobal(base.cookie, ref iid, out unknown);
				if (hr < 0)
					Marshal.ThrowExceptionForHR(hr);
				return unknown as T;
			}
		}
		#endregion Properties
	}
}
