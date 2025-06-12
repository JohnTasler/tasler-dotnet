using System.ComponentModel;
using Tasler.Buffers;
using Tasler.Extensions;

namespace Tasler.Interop.RawInput.User;

public static class SafeRawInputHandleExtensions
{
	/// <summary>
	/// Function to retrieve raw input data.
	/// </summary>
	/// <param name="hRawInput">Handle to the raw input.</param>
	/// <returns>The <see cref="RAWINPUTHEADER"/> read from the device.</returns>
	public static RAWINPUTHEADER GetRawInputHeader(this SafeRawInputHandle hRawInput)
	{
		int cbSize = 0;
		RawInputApi.NativeMethods.GetRawInputData(
			hRawInput.Handle, Command.Header, out RAWINPUTHEADER data, ref cbSize, RAWINPUTHEADER.SizeOf);
		return data;
	}

	//public static int GetRawInputData(
	//	this SafeRawInputHandle hRawInput,
	//	Command uiCommand,
	//	out RAWINPUTHEADER pData,
	//	ref int pcbSize,
	//	int cbSizeHeader)
	//{
	//	int cbSize = 0;

	//	return cbSize;
	//}


	/// <summary>
	/// Gets information about the raw input device.
	/// </summary>
	/// <param name="deviceHandle">Handle to the raw input device. This comes from the lParam of the
	/// <see cref="WM_INPUT"/> message, from <see cref="RAWINPUTHEADER.hDevice"/>, or from
	/// <see cref="GetRawInputDeviceList"/>.</param>
	/// <returns></returns>
	public static string GetRawInputDeviceName(this SafeRawInputHandle deviceHandle)
	{
		unsafe
		{
			int charCount = 0;
			var result = RawInputApi.NativeMethods.GetRawInputDeviceInfo(deviceHandle.Handle, DeviceInfoItem.DeviceName, null, ref charCount);
			if (result != 0)
				throw new Win32Exception();

			using (var renter = new SharedArrayPoolRenter<char>((int)charCount + 1))
			{
				var buffer = renter.Data;
				fixed (char* bufferPtr = buffer)
				{
					result = RawInputApi.NativeMethods.GetRawInputDeviceInfo(deviceHandle.Handle, DeviceInfoItem.DeviceName, bufferPtr, ref charCount);
				}
				return new(buffer);
			}
		}
	}

	public static RIDDEVICEINFO_Mouse GetRawInputMouseDeviceInfo(this SafeRawInputHandle deviceHandle)
	{
		unsafe
		{
			RIDDEVICEINFO_Mouse deviceInfo = new RIDDEVICEINFO_Mouse();
			int byteCount = deviceInfo.Size;
			var result = RawInputApi.NativeMethods.GetRawInputDeviceInfo(deviceHandle.Handle, DeviceInfoItem.DeviceName, &deviceInfo, ref byteCount);
			if (result != 0)
				throw new Win32Exception();

			return deviceInfo;
		}
	}

	public static RIDDEVICEINFO_Keyboard GetRawInputKeyboardDeviceInfo(this SafeRawInputHandle deviceHandle)
	{
		unsafe
		{
			RIDDEVICEINFO_Keyboard deviceInfo = new RIDDEVICEINFO_Keyboard();
			int byteCount = deviceInfo.Size;
			var result = RawInputApi.NativeMethods.GetRawInputDeviceInfo(deviceHandle.Handle, DeviceInfoItem.DeviceName, &deviceInfo, ref byteCount);
			if (result != 0)
			throw new Win32Exception();

			return deviceInfo;
		}
	}

	public static RIDDEVICEINFO_HID GetRawInputHIDDeviceInfo(this SafeRawInputHandle deviceHandle)
	{
		unsafe
		{
			RIDDEVICEINFO_HID deviceInfo = new RIDDEVICEINFO_HID();
			int byteCount = deviceInfo.Size;
			var result = RawInputApi.NativeMethods.GetRawInputDeviceInfo(deviceHandle.Handle, DeviceInfoItem.DeviceName, &deviceInfo, ref byteCount);
			if (result != 0)
				throw new Win32Exception();

			return deviceInfo;
		}
	}
}
