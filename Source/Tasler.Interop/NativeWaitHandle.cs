using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace Tasler.Interop
{
    public class NativeWaitHandle : WaitHandle
    {
        #region Construction

        /// <summary>
        /// Wraps the specified native wait handle.
        /// </summary>
        /// <param name="nativeHandle">The native wait handle.</param>
        public NativeWaitHandle(SafeWaitHandle nativeHandle)
            : this(nativeHandle, false)
        {
        }

        /// <summary>
        /// Wraps the specified native wait handle or, optionally, a duplicate of it.
        /// </summary>
        /// <param name="nativeHandle">The native wait handle.</param>
        /// <param name="createDuplicate">If <c>true</c>, wraps a duplicate of
        /// <paramref name="nativeHandle"/>. If <c>false</c>, wraps <paramref name="nativeHandle"/>
        /// directly. The default is <c>false</c>.</param>
        public NativeWaitHandle(SafeWaitHandle nativeHandle, bool createDuplicate)
        {
            if (createDuplicate)
            {
                var hCurrentProcess = NativeWaitHandle.GetCurrentProcess();

                SafeWaitHandle duplicatedHandle;
                bool succeeded = NativeWaitHandle.DuplicateHandle(
                    hCurrentProcess, nativeHandle, hCurrentProcess, out duplicatedHandle,
                    0, false, DUPLICATE_SAME_ACCESS);

                if (!succeeded)
                    throw new Win32Exception(Marshal.GetLastWin32Error());

                nativeHandle = duplicatedHandle;
            }

            base.SafeWaitHandle = nativeHandle;
        }

        #endregion Construction

        #region Platform Invoke

        #region Constants

        private const int DUPLICATE_SAME_ACCESS = 0x00000002;

        #endregion Constants

        #region Imported Methods

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private extern static IntPtr GetCurrentProcess();

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        private extern static bool DuplicateHandle(
            IntPtr hSourceProcessHandle,
            SafeWaitHandle hSourceHandle,
            IntPtr hTargetProcessHandle,
            out SafeWaitHandle lpTargetHandle,
            int dwDesiredAccess,
            [MarshalAs(UnmanagedType.Bool)]
            bool bInheritHandle,
            int dwOptions);

        #endregion Imported Methods

        #endregion Platform Invoke
    }
}
