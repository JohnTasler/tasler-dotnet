using System;

namespace Tasler.Interop.Com
{
    /// <summary>
    /// Wraps an RCW interface into a disposable wrapper. WARNING: Read the remarks
    /// </summary>
    /// <typeparam name="T">The type of the RCW interface.</typeparam>
    /// <remarks>
    /// <para>The intention of this class is to encourage the GC to perform a more deterministic lifetime for
    /// COM objects accessed through a Runtime Callable Wrapper (RCW).</para>
    /// <para>
    /// I'm not really certain if this wrapper is needed, or if it even works correctly. The <see cref="Dispose"/> method
    /// has a call to <see cref="System.Runtime.InteropServices.Marshal.ReleaseComObject"/>, although it is
    /// <b>currently</b> commented-out. See the following link for more details:
    /// <br/>
    /// <blockquote>
    /// <a href="http://blogs.msdn.com/b/visualstudio/archive/2010/03/01/marshal-releasecomobject-considered-dangerous.aspx"
    ///    target="_blank"
    ///     >Marshal.ReleaseComObject Considered Dangerous
    /// <br/>http://blogs.msdn.com/b/visualstudio/archive/2010/03/01/marshal-releasecomobject-considered-dangerous.aspx</a>
    /// </blockquote>
    /// </para>
    /// </remarks>
    public class ComPtr<T> : IDisposable
        where T : class
    {
        public T Value;

        public ComPtr()
        {
        }

        public ComPtr(T pointer)
        {
            this.Value = pointer;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (this.Value != default(T))
            {
//                Marshal.ReleaseComObject(this.Value);
                this.Value = default(T);
            }
        }

        #endregion IDisposable Members

        public bool HasValue
        {
            get { return !this.IsNull; }
        }

        public bool IsNull
        {
            get { return this.Value == default(T); }
        }
    }
}
