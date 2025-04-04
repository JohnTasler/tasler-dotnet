using System.Buffers;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tasler.Interop.Gdi;

namespace Tasler.Interop.RawInput.User;

public static class SafeRawInputHandleExtensions
{
	/// <summary>
	/// Function to retrieve raw input data.
	/// </summary>
	/// <param name="hRawInput">Handle to the raw input.</param>
	/// <param name="uiCommand">Command to issue when retrieving data.</param>
	/// <param name="pData">Raw input data.</param>
	/// <param name="pcbSize">Number of bytes in the array.</param>
	/// <param name="cbSizeHeader">Size of the header.</param>
	/// <returns>0 if successful if pData is null, otherwise number of bytes if pData is not null.</returns>
	public static RAWINPUTHEADER GetRawInputHeader(this SafeRawInputHandle hRawInput)
	{
		int cbSize = 0;
		RawInputApi.NativeMethods.GetRawInputData(hRawInput, Command.Header, out RAWINPUTHEADER data, ref cbSize, Marshal.SizeOf<RAWINPUTHEADER>());
		return data;
	}



	/// <summary>
	/// Gets information about the raw input device.
	/// </summary>
	/// <param name="deviceHandle">Handle to the raw input device. This comes from the lParam of the <see cref="WM_INPUT"/> message, from <see cref="RAWINPUTHEADER.hDevice"/>, or from <see cref="GetRawInputDeviceList"/>.</param>
	/// <returns></returns>
	public static string GetRawInputDeviceName(this SafeRawInputHandle deviceHandle)
	{
		unsafe
		{
			uint charCount = 0;
			var result = RawInputApi.NativeMethods.GetRawInputDeviceInfoW(deviceHandle, DeviceInfoItem.DeviceName, null, ref charCount);
			if (result != 0)
				throw new Win32Exception();

			char[]? buffer = null;
			using (var bufferScope = new DisposeScopeExit(() => ArrayPool<char>.Shared.Return(buffer!)))
			{
				buffer = ArrayPool<char>.Shared.Rent(unchecked((int)charCount) + 1);
				fixed (char* bufferPtr = buffer)
				{
					result = RawInputApi.NativeMethods.GetRawInputDeviceInfoW(deviceHandle, DeviceInfoItem.DeviceName, bufferPtr, ref charCount);
				}
				return new(buffer);
			}
		}
	}

	public static RIDDEVICEINFO GetRawInputDeviceInfo(this SafeRawInputHandle deviceHandle)
	{
		unsafe
		{
			RIDDEVICEINFO deviceInfo = new RIDDEVICEINFO();
			uint byteCount = deviceInfo.Size;
			var result = RawInputApi.NativeMethods.GetRawInputDeviceInfoW(deviceHandle, DeviceInfoItem.DeviceName, &deviceInfo, ref byteCount);
			if (result != 0)
				throw new Win32Exception();

			return deviceInfo;
		}
	}
}
