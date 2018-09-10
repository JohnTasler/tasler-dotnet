using System;
using Tasler.Interop.Gdi;

namespace Tasler.Interop.User
{
    public class SafeWindowHdc : SafeHdc
    {
        #region Properties
        public IntPtr WindowHandle { get; set; }
        #endregion Properties

        #region Overrides
        protected override bool ReleaseHandle()
        {
            return UserApi.ReleaseDC(this.WindowHandle, base.handle);
        }
        #endregion Overrides
    }
}
