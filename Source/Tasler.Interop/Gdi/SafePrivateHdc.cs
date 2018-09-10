
namespace Tasler.Interop.Gdi
{
    public class SafePrivateHdc : SafeHdc
    {
        #region Overrides
        protected override bool ReleaseHandle()
        {
            return GdiApi.DeleteDC(base.handle);
        }
        #endregion Overrides
    }
}
