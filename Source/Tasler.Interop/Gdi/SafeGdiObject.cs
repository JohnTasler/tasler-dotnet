using System;
using System.Runtime.InteropServices;

namespace Tasler.Interop.Gdi
{
    public class SafeGdiObject : SafeHandle
    {
        #region Constructors
        public SafeGdiObject()
            : this(false)
        {
        }

        protected SafeGdiObject(bool ownsHandle)
            : base(IntPtr.Zero, ownsHandle)
        {
        }
        #endregion Constructors

        #region Properties
        public IntPtr Handle
        {
            get { return base.handle; }
        }
        #endregion Properties

        #region Overrides
        public override bool IsInvalid
        {
            get { return base.handle == IntPtr.Zero; }
        }

        protected override bool ReleaseHandle()
        {
            return GdiApi.DeleteObject(base.handle);
        }
        #endregion Overrides
    }

    public class SafeGdiObjectOwned : SafeGdiObject
    {
        public SafeGdiObjectOwned()
            : base(true)
        {
        }
    }
}
