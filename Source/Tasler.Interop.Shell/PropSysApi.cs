using System;
using System.Runtime.InteropServices;

namespace Tasler.Interop.Shell
{
    public static class PropSysApi
    {
        [DllImport("propsys.dll", ExactSpelling = true, PreserveSig = true)]
        private static extern int PSGetNameFromPropertyKey(
            PropertyKey propkey,
            out SafeCoTaskMemHandle ppszCanonicalName);

        public static string GetNameFromPropertyKey(
            PropertyKey propkey)
        {
            string name = string.Empty;
            SafeCoTaskMemHandle pszCanonicalName = new SafeCoTaskMemHandle();
            int hr = PSGetNameFromPropertyKey(propkey, out pszCanonicalName);
            if (hr == 0)
            {
                name = Marshal.PtrToStringUni(pszCanonicalName.DangerousGetHandle());
                pszCanonicalName.Close();
            }

            return name;
        }

        [return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)]
        [DllImport("propsys.dll", ExactSpelling = true)]
        public static extern object PSGetPropertyDescription(
            PropertyKey propkey,
            ref Guid riid);

    } // End: PropSysApi

} // End: namespace
