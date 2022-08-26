using System;
using System.Runtime.InteropServices;

namespace Tasler.Interop.Com
{
    public class GitHandleBase : IDisposable
    {
        #region Instance Fields
        private readonly object _cookieLock = new object();
        private int _cookie;
        #endregion Instance Fields

        #region Properties

        protected static IGlobalInterfaceTable Git { get; } = new GlobalInterfaceTable();

        public int Cookie
        {
            get
            {
                lock (_cookieLock)
                    return _cookie;
            }
            protected set
            {
                lock (_cookieLock)
                    _cookie = value;
            }
        }

        #endregion Properties

        #region Methods
        public int DetachCookie()
        {
            lock (_cookieLock)
            {
                int result = _cookie;
                _cookie = 0;
                return result;
            }
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
            lock (_cookieLock)
            {
                if (_cookie != 0)
                {
                    Git.RevokeInterfaceFromGlobal(_cookie);
                    _cookie = 0;
                }
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
            ValidateArgument.IsNotNull(unknown, nameof(unknown));

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
                return unknown as T;
            }
        }
        #endregion Properties
    }
}
