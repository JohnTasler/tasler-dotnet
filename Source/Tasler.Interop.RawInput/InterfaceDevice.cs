using System.Diagnostics;
using System.Runtime.InteropServices;
using Tasler.Interop.RawInput.User;

namespace Tasler.Interop.RawInput
{
	public abstract class InterfaceDevice
	{
		#region Instance Fields
		internal RAWINPUTDEVICELIST _device;
		private string? _name;
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
				_ => throw new InvalidOperationException(string.Format("Unrecognized device type: 0x{0:4X}", device.DeviceType)),
			};
		}
		#endregion Construction

		#region Properties
		public InterfaceDeviceType DeviceType => _device.DeviceType;

		public nint Handle => _device.DeviceHandle.Handle;

		public string? Name
		{
			get
			{
				if (_name is null)
				{
					unsafe
					{
						// Get the size of buffer needed
						var nameLength = 0u;
						RawInputApi.NativeMethods.GetRawInputDeviceInfoW(_device.DeviceHandle, DeviceInfoItem.DeviceName, null, ref nameLength);

						// Allocate an unmanaged buffer
						uint bufferByteCount = nameLength * sizeof(char);
						var buffer = Marshal.AllocHGlobal((int)bufferByteCount);

						try
						{
							// Get the name string
							RawInputApi.NativeMethods.GetRawInputDeviceInfoW(_device.DeviceHandle, DeviceInfoItem.DeviceName, (void*)buffer, ref nameLength);

							// Marshal the name string to a managed string
							_name = Marshal.PtrToStringAuto(buffer);
						}
						finally
						{
							// Free the buffer
							Marshal.FreeHGlobal(buffer);
						}
					}
				}

				return _name;
			}
		}

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
		protected T _deviceInfo;
		#endregion Instance Fields

		#region Construction
		internal InterfaceDeviceBase(RAWINPUTDEVICELIST device)
				: base(device)
		{
		}
		#endregion Construction

		#region Private Implementation
		protected T DeviceInfo
		{
			get
			{
				if (_deviceInfo == null)
				{
					// Get the size of buffer needed
					var byteCount = 0;
					RawInputApi.GetRawInputDeviceInfo(base._device.DeviceHandle, DeviceInfoItem.DeviceInfo, nint.Zero, ref byteCount);

					// Allocate an unmanaged buffer
					var buffer = Marshal.AllocHGlobal(byteCount);

					try
					{
						// Write the buffer size into the buffer
						Marshal.WriteInt32(buffer, byteCount);

						// Get the device info
						RawInputApi.GetRawInputDeviceInfo(base._device.DeviceHandle, DeviceInfoItem.DeviceInfo, buffer, ref byteCount);

						// Marshal the device info to a managed structure
						_deviceInfo = (T)Marshal.PtrToStructure(buffer, typeof(T));
					}
					finally
					{
						// Free the buffer
						Marshal.FreeHGlobal(buffer);
					}
				}

				return _deviceInfo;
			}
		}
		#endregion Private Implementation
	}

	public abstract class RawInputBase
	{
		public static RawInputBase FromHandle(nint hRawInput, out RAWINPUTHEADER header)
		{
			return RawInputBase.FromHandle(hRawInput, out header, false);
		}

		public static RawInputBase FromHandle(nint hRawInput, out RAWINPUTHEADER header, bool headerOnly)
		{
			// Get the header
			int size = RAWINPUTHEADER.SizeOf;
			RawInputApi.GetRawInputData(hRawInput, Command.Header, out header, ref size, size);

			// Do nothing else if only the header was requested
			return headerOnly ? null : RawInputBase.FromHandle(hRawInput, header);
		}

		public static RawInputBase FromHandle(nint hRawInput, RAWINPUTHEADER header)
		{
			// Get the buffer size needed and allocate the buffer
			int size = 0;
			int result = RawInputApi.GetRawInputData(hRawInput, Command.Input, nint.Zero, ref size, RAWINPUTHEADER.SizeOf);
			Debug.Assert(result != -1);
			nint pData = Marshal.AllocHGlobal(size);
			try
			{
				// Get the data
				result = RawInputApi.GetRawInputData(hRawInput, Command.Input, pData, ref size, RAWINPUTHEADER.SizeOf);
				Debug.Assert(result != -1);

				RawInputBase input = null;
				if (header.Type == InterfaceDeviceType.Mouse)
					input = new MouseInput(pData);
				else if (header.Type == InterfaceDeviceType.Keyboard)
					input = new KeyboardInput(pData);
				else if (header.Type == InterfaceDeviceType.HID)
					input = new HumanInput(pData);
				return input;
			}
			finally
			{
				Marshal.FreeHGlobal(pData);
			}
		}
	}
}
