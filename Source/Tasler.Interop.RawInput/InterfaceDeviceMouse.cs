using System;
using System.Runtime.InteropServices;
using Tasler.Interop.RawInput.User;

namespace Tasler.Interop.RawInput
{
    public class InterfaceDeviceMouse : InterfaceDeviceBase<InterfaceDeviceMouse.Info>
    {
        #region Nested Types
        [StructLayout(LayoutKind.Sequential)]
        public class Info
        {
            public int Size;
            public int DeviceType;
            public int Id;
            public int NumberOfButtons;
            public int SampleRate;
            [MarshalAs(UnmanagedType.Bool)]
            public bool HasHorizontalWheel;
        }
        #endregion Nested Types

        #region Construction
        internal InterfaceDeviceMouse(RAWINPUTDEVICELIST device)
            : base(device)
        {
        }
        #endregion Construction

        #region Properties
        public override short UsagePage
        {
            get { return 1; }
        }

        public override short Usage
        {
          get { return 2; }
        }

        public int Id
        {
            get { return base.DeviceInfo.Id; }
        }

        public int NumberOfButtons
        {
            get { return base.DeviceInfo.NumberOfButtons; }
        }

        public int SampleRate
        {
            get { return base.DeviceInfo.SampleRate; }
        }

        public bool HasHorizontalWheel
        {
            get { return this.DeviceInfo.HasHorizontalWheel; }
        }
        #endregion Properties
    }

    public class MouseInput : RawInputBase
    {
        private RAWINPUTMOUSE _raw;

        internal MouseInput(IntPtr pData)
        {
            _raw = (RAWINPUTMOUSE)Marshal.PtrToStructure(
                new IntPtr(pData.ToInt64() + RAWINPUTHEADER.SizeOf), typeof(RAWINPUTMOUSE));
        }

        /// <summary>Flags for the event.</summary>
        public MouseFlags Flags { get { return _raw.Flags; } }
        /// <summary>Flags for the event.</summary>
        public MouseButtons Buttons { get { return _raw.Buttons; } }
        /// <summary>If the mouse wheel is moved, this will contain the delta amount.</summary>
        public short ButtonData { get { return _raw.ButtonData; } }
        /// <summary>Raw button data.</summary>
        public int RawButtons { get { return _raw.RawButtons; } }
        /// <summary>Relative direction of motion, depending on flags.</summary>
        public int LastX { get { return _raw.LastX; } }
        /// <summary>Relative direction of motion, depending on flags.</summary>
        public int LastY { get { return _raw.LastY; } }
        /// <summary>Extra information.</summary>
        public int ExtraInformation { get { return _raw.ExtraInformation; } }
    }
}
