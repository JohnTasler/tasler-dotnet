using System;
using System.Runtime.InteropServices;
using Tasler.Interop.RawInput.User;
using Tasler.Interop.User;

namespace Tasler.Interop.RawInput
{
    public class InterfaceDeviceKeyboard : InterfaceDeviceBase<InterfaceDeviceKeyboard.Info>
    {
        #region Nested Types
        [StructLayout(LayoutKind.Sequential)]
        public class Info
        {
            public int Size;
            public int DeviceType;
            public int KeyboardType;
            public int KeyboardSubType;
            public int KeyboardMode;
            public int NumberOfFunctionKeys;
            public int NumberOfIndicators;
            public int NumberOfKeysTotal;
        }
        #endregion Nested Types

        #region Construction
        internal InterfaceDeviceKeyboard(RAWINPUTDEVICELIST device)
            : base(device)
        {
        }
        #endregion Construction

        #region Properties
        public int KeyboardType
        {
            get { return base.DeviceInfo.KeyboardType; }
        }

        public int KeyboardSubType
        {
            get { return base.DeviceInfo.KeyboardSubType; }
        }

        public int KeyboardMode
        {
            get { return base.DeviceInfo.KeyboardMode; }
        }

        public int NumberOfFunctionKeys
        {
            get { return base.DeviceInfo.NumberOfFunctionKeys; }
        }

        public int NumberOfIndicators
        {
            get { return base.DeviceInfo.NumberOfIndicators; }
        }

        public int NumberOfKeysTotal
        {
            get { return base.DeviceInfo.NumberOfKeysTotal; }
        }

        public override short UsagePage
        {
            get { return 1; }
        }

        public override short Usage
        {
            get { return 6; }
        }

        #endregion Properties
    }

    public class KeyboardInput : RawInputBase
    {
        private RAWINPUTKEYBOARD _raw;

        internal KeyboardInput(nint pData)
        {
            _raw = (RAWINPUTKEYBOARD)Marshal.PtrToStructure(
                new nint(pData.ToInt64() + RAWINPUTHEADER.SizeOf), typeof(RAWINPUTKEYBOARD));
        }

        /// <summary>Scan code for key depression.</summary>
        public short MakeCode { get { return _raw.MakeCode; } }
        /// <summary>Scan code information.</summary>
        public KeyboardFlags Flags { get { return _raw.Flags; } }
        /// <summary>Virtual key code.</summary>
        public short VirtualKey { get { return _raw.VirtualKey; } }
        /// <summary>The display name of the scan code key.</summary>
        public string KeyName { get { return UserApi.GetScanCodeKeyDisplayText(this.MakeCode); } }

        /// <summary>Corresponding window message.</summary>
        public int Message { get { return _raw.Message; } }
        /// <summary>Extra information.</summary>
        public int ExtraInformation { get { return _raw.ExtraInformation; } }
    }
}
