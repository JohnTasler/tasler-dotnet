using System.Diagnostics;
using System.Runtime.InteropServices;
using Tasler.Interop.RawInput.Properties;
using Tasler.Interop.RawInput.User;
using Tasler.Extensions;

namespace Tasler.Interop.RawInput
{
	public abstract class InterfaceDevice
	{
		#region Instance Fields
		internal RAWINPUTDEVICELIST _device;
		private string? _name = null!;
		#endregion Instance Fields

		#region Construction
		public InterfaceDevice(RAWINPUTDEVICELIST device)
		{
			_device = device;
		}

		public static InterfaceDevice FromRAWINPUTDEVICELIST(RAWINPUTDEVICELIST device)
		{
			return device.DeviceType switch
			{
				InterfaceDeviceType.Mouse => new InterfaceDeviceMouse(device),
				InterfaceDeviceType.Keyboard => new InterfaceDeviceKeyboard(device),
				InterfaceDeviceType.HID => new InterfaceDeviceHuman(device),
				_ => throw new ArgumentException(string.Format(Strings.UnrecognizedDeviceType_1, device.DeviceType)),
			};
		}
		#endregion Construction

		#region Properties
		public InterfaceDeviceType DeviceType => _device.DeviceType;

		public nint Handle => _device.DeviceHandle.Handle;

		public string Name => _name ??= _device.DeviceHandle.GetRawInputDeviceName();

		public string? DisplayName { get; set; }

		public abstract short UsagePage { get; }

		public abstract short Usage { get; }

		public virtual string UsagePageDisplayName => this.UsagePage.ToString("X2");

		public virtual string UsageDisplayName => this.Usage.ToString("X2");

		#endregion Properties

		#region Overrides
		public override bool Equals(object? obj)
		{
			if (obj is RAWINPUTDEVICELIST)
				return obj.Equals(_device);
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		#endregion Overrides
	}

	public abstract class InterfaceDeviceBase<T> : InterfaceDevice
	{
		#region Instance Fields
		protected T DeviceInfo = default!;
		#endregion Instance Fields

		#region Construction
		internal InterfaceDeviceBase(RAWINPUTDEVICELIST device)
			: base(device)
		{
		}
		#endregion Construction

		#region Private Implementation
		//protected T DeviceInfo
		//{
		//	get
		//	{
		//		if (_deviceInfo == null)
		//		{
		//			// Get the size of buffer needed
		//			var byteCount = 0;
		//			unsafe
		//			{
		//				RawInputApi.NativeMethods.GetRawInputDeviceInfo(_device.DeviceHandle.Handle, DeviceInfoItem.DeviceInfo, null, ref byteCount);
		//			}

		//			// Allocate a buffer
		//			var buffer = new byte[byteCount];

		//			try
		//			{
		//				// Get the device info
		//				unsafe
		//				{
		//					fixed (byte* bufferPtr = buffer)
		//					{
		//						RawInputApi.NativeMethods.GetRawInputDeviceInfo(_device.DeviceHandle.Handle, DeviceInfoItem.DeviceInfo, bufferPtr, ref byteCount);
		//					}
		//				}

		//				// Marshal the device info to a managed structure
		//				_deviceInfo = (T)Marshal.PtrToStructure(buffer, typeof(T));
		//			}
		//			finally
		//			{
		//				// Free the buffer
		//				Marshal.FreeHGlobal(buffer);
		//			}
		//		}

		//		return _deviceInfo;
		//	}
		//}
		#endregion Private Implementation
	}

	public abstract class RawInputBase
	{
		public static RawInputBase? FromHandle(nint hRawInput, out RAWINPUTHEADER header)
			=>  RawInputBase.FromHandle(hRawInput, out header, false);

		public static RawInputBase? FromHandle(nint hRawInput, out RAWINPUTHEADER header, bool headerOnly)
		{
			// Get the header
			int size = RAWINPUTHEADER.SizeOf;
			RawInputApi.NativeMethods.GetRawInputData(hRawInput, Command.Header, out header, ref size, size);

			// Do nothing else if only the header was requested
			return headerOnly ? null : RawInputBase.FromHandle(hRawInput, out header);
		}

		//public static RawInputBase? FromHandle(nint hRawInput, RAWINPUTHEADER header)
		//{
		//	// Get the buffer size needed and allocate the buffer
		//	int size = 0;
		//	int result = RawInputApi.NativeMethods.GetRawInputData(hRawInput, Command.Input, nint.Zero, ref size, RAWINPUTHEADER.SizeOf);
		//	Debug.Assert(result != -1);


		//	nint pData = Marshal.AllocHGlobal(size);
		//	try
		//	{
		//		// Get the data
		//		result = RawInputApi.NativeMethods.GetRawInputData(hRawInput, Command.Input, pData, ref size, RAWINPUTHEADER.SizeOf);
		//		Debug.Assert(result != -1);

		//		RawInputBase? input = null;
		//		if (header.Type == InterfaceDeviceType.Mouse)
		//			input = new MouseInput(pData);
		//		else if (header.Type == InterfaceDeviceType.Keyboard)
		//			input = new KeyboardInput(pData);
		//		else if (header.Type == InterfaceDeviceType.HID)
		//			input = new HumanInput(pData);

		//		return input ?? throw new InvalidOperationException();
		//	}
		//	finally
		//	{
		//		Marshal.FreeHGlobal(pData);
		//	}
		//}
	}
}
