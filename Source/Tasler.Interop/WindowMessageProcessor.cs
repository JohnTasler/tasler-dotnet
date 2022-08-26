using System;
using Tasler.Interop.User;

namespace Tasler.Interop
{
    public abstract class WindowMessageProcessor : WindowMessageRedirector
    {
        #region Constructors
        protected WindowMessageProcessor()
        {
        }

        protected WindowMessageProcessor(WindowMessageRedirector outerRedirector)
            : base(outerRedirector)
        {
        }
        #endregion Constructors

        #region Properties
        public IntPtr WindowHandle { get; private set; }
        #endregion Properties

        #region Methods
        public void Attach(IntPtr hwnd)
        {
            if (this.WindowHandle != hwnd)
                this.Detach();

            if (hwnd != IntPtr.Zero)
            {
                this.WindowHandle = hwnd;
                this.OnAttached();
            }
        }

        public void Detach()
        {
            if (this.WindowHandle != IntPtr.Zero)
            {
                this.OnDetaching();
                this.WindowHandle = IntPtr.Zero;
            }
        }
        #endregion Methods

        #region Protected Abstract Methods
        protected abstract void OnAttached();

        protected abstract void OnDetaching();
        #endregion Protected Abstract Methods

        #region Overrides
        protected override IntPtr OnRedirected(IntPtr hwnd, int message, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (message == (int)WM.NCDESTROY)
            {
                this.Detach();
                this.ClearWindowProcedure();
            }

            return IntPtr.Zero;
        }
        #endregion Overrides
    }
}
