using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Tasler.Interop.User;

namespace Tasler.Interop
{
    public class WindowMessageSubclass : WindowMessageProcessor
    {
        #region Constructors
        public WindowMessageSubclass()
        {
        }

        public WindowMessageSubclass(WindowMessageRedirector outerRedirector)
            : base(outerRedirector)
        {
        }
        #endregion Constructors

        #region Overrides

        protected override void OnAttached()
        {
            if (this.HasEventSubscribers)
                this.Subclass();
        }

        protected override void OnDetaching()
        {
            if (this.IsSubclassed)
                this.Unsubclass();
        }

        protected override void OnHasEventSubscribersChanged()
        {
            if (this.WindowHandle != IntPtr.Zero)
            {
                if (this.HasEventSubscribers)
                    this.Subclass();
                else
                    this.Unsubclass();
            }
        }

        #endregion Overrides

        #region Private Implementation

        private bool IsSubclassed
        {
            get { return this.OriginalWindowProcedure != IntPtr.Zero; }
        }

        private void Subclass()
        {
            Debug.Assert(this.WindowHandle != IntPtr.Zero);
            Debug.Assert(this.IsSubclassed == false);

            // Save the window's existing window procedure and swap-in our own
            var hwnd = new HandleRef(this, this.WindowHandle);
            this.OriginalWindowProcedure = UserApi.GetWindowLongPtr(hwnd, GWLP.WndProc);
            UserApi.SetWindowLongPtr(hwnd, GWLP.WndProc, this.WindowProcedure);
        }

        private void Unsubclass()
        {
            Debug.Assert(this.WindowHandle != IntPtr.Zero);
            Debug.Assert(this.IsSubclassed == true);

            // Restore the window's previous window procedure
            var hwnd = new HandleRef(this, this.WindowHandle);
            UserApi.SetWindowLongPtr(hwnd, GWLP.WndProc, this.OriginalWindowProcedure);

            // Clear our state
            this.OriginalWindowProcedure = IntPtr.Zero;
            this.ClearWindowProcedure();
        }

        #endregion Private Implementation
    }
}
