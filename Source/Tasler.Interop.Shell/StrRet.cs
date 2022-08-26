using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Tasler.Interop.Shell
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct StrRet : IDisposable
    {
        #region Instance Fields
        private STRRET_TYPE _type;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        private byte[] _cStr;
        #endregion Instance Fields

        #region IDisposable Members
        public void Dispose()
        {
            if (_type == STRRET_TYPE.WStr)
            {
                Marshal.FreeCoTaskMem(this.GetWStr());
                Array.Clear(_cStr, 0, IntPtr.Size);
            }
        }
        #endregion IDisposable Members

        #region Properties
        public string Value
        {
            get
            {
                string value = null;
                switch (_type)
                {
                    case STRRET_TYPE.WStr:
                        {
                            value = Marshal.PtrToStringUni(this.GetWStr());
                            break;
                        }
                    case STRRET_TYPE.CStr:
                        {
                            char[] chars = new char[_cStr.Length];
                            Encoding.ASCII.GetDecoder().GetChars(_cStr, 0, _cStr.Length, chars, 0, true);
                            value = new string(chars);
                            break;
                        }
                }
                return value;
            }
        }
        #endregion Properties

        #region Methods
        public string GetValue(ItemIdList itemIdList)
        {
            return this.GetValue(itemIdList.Value);
        }

        public string GetValue(ChildItemIdList childItemIdList)
        {
            return this.GetValue(childItemIdList.Value);
        }
        #endregion Methods

        #region Private Implementation
        private IntPtr GetWStr()
        {
            Int64 ptr = BitConverter.ToInt64(_cStr, 0);
            if (IntPtr.Size == 4)
                ptr &= 0x00000000FFFFFFFF;
            return new IntPtr(ptr);
        }

        private string GetValue(IntPtr pidl)
        {
            if (_type != STRRET_TYPE.Offset)
                return this.Value;
            uint offset = BitConverter.ToUInt32(_cStr, 0);
            string value = Marshal.PtrToStringAnsi(new IntPtr(pidl.ToInt64() + offset));
            return value;
        }
        #endregion Private Implementation

        #region Nested Types
        private enum STRRET_TYPE
        {
            WStr = 0,
            Offset = 0x1,
            CStr = 0x2
        }
        #endregion Nested Types
    }
}
