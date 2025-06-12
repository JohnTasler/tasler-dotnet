using System.ComponentModel;
using System.Runtime.InteropServices;
using Tasler.Extensions;

namespace Tasler.Interop.RawInput.User;

public static partial class RawInputApi
{
	public static RAWINPUTDEVICELIST[] GetRawInputDeviceList()
	{
		// Get the number of structures are needed to hold the list of raw input devices
		int deviceCount = 0;

		unsafe
		{
			var result = NativeMethods.GetRawInputDeviceList(null, ref deviceCount, RAWINPUTDEVICELIST.SizeOf);
			if (result >= 0)
			{
				// If the result is >= 0, then there are no devices
				if (deviceCount == 0)
					return [];

				var devices = new RAWINPUTDEVICELIST[deviceCount];
				fixed (RAWINPUTDEVICELIST* pDevices = devices)
				{
					result = NativeMethods.GetRawInputDeviceList(pDevices, ref deviceCount, RAWINPUTDEVICELIST.SizeOf);
					if (result < 0)
						throw new Win32Exception();

					return devices;
				}
			}
			else
			{
				throw new Win32Exception();
			}
		}
	}

	public static RAWINPUTDEVICE[] GetRegisteredRawInputDevices()
	{
		const int ERROR_INSUFFICIENT_BUFFER = 0x007A;
		const int E_UNEXPECTED = unchecked((int)0x8000FFFF);
		unsafe
		{
			uint cbSize = unchecked((uint)RAWINPUTDEVICE.SizeOf);
			uint numDevices;
			uint result = NativeMethods.GetRegisteredRawInputDevices(null, out numDevices, cbSize);

			if (result != uint.MaxValue)
				throw new InvalidOperationException { HResult = E_UNEXPECTED };

			if (Marshal.GetLastPInvokeError() != ERROR_INSUFFICIENT_BUFFER)
				throw new Win32Exception();

			RAWINPUTDEVICE[] rawInputDevices = new RAWINPUTDEVICE[numDevices];
			#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
			unsafe
			{
				fixed (RAWINPUTDEVICE* rawInputDevicesPtr = &rawInputDevices[0])
				{
					result = NativeMethods.GetRegisteredRawInputDevices(rawInputDevicesPtr, out numDevices, cbSize);
					if (result != uint.MaxValue && Marshal.GetLastPInvokeError() != ERROR_INSUFFICIENT_BUFFER)
						throw new Win32Exception();
				}
			}
			#pragma warning restore CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type

			return rawInputDevices;
		}
	}

	public static bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevices)
		=> NativeMethods.RegisterRawInputDevices(pRawInputDevices, pRawInputDevices.Length, RAWINPUTDEVICE.SizeOf);

	internal static partial class NativeMethods
	{
		#region Constants
		private const string ApiLib = "user32.dll";
		#endregion Constants

		/// <summary>
		/// Function to register a raw input device.
		/// </summary>
		/// <param name="pRawInputDevices">Array of raw input devices.</param>
		/// <param name="uiNumDevices">Number of devices.</param>
		/// <param name="cbSize">Size of the RAWINPUTDEVICE structure.</param>
		/// <returns><see langword="true"/> if successful; otherwise <see langword="false"/>.</returns>
		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool
		RegisterRawInputDevices(
				[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] RAWINPUTDEVICE[] pRawInputDevices,
				int uiNumDevices,
				int cbSize);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static unsafe partial uint
		GetRegisteredRawInputDevices(
			RAWINPUTDEVICE* pRawInputDevices,
			out uint numDevices,
			uint cbSize);

		/// <summary>
		/// Function to retrieve raw input data.
		/// </summary>
		/// <param name="hRawInput">Handle to the raw input.</param>
		/// <param name="uiCommand">Command to issue when retrieving data.</param>
		/// <param name="pData">Raw input data.</param>
		/// <param name="pcbSize">Number of bytes in the array.</param>
		/// <param name="cbSizeHeader">Size of the header.</param>
		/// <returns>0 if successful if pData is null, otherwise number of bytes if pData is not null.</returns>
		[LibraryImport(ApiLib)]
		public static partial int
		GetRawInputData(
			nint hRawInput,
			Command uiCommand,
			out RAWINPUTHEADER pData,
			ref int pcbSize,
			int cbSizeHeader);

		/// <summary>
		/// Function to retrieve raw input data.
		/// </summary>
		/// <param name="hRawInput">Handle to the raw input.</param>
		/// <param name="uiCommand">Command to issue when retrieving data.</param>
		/// <param name="pData">Raw input data.</param>
		/// <param name="pcbSize">Number of bytes in the array.</param>
		/// <param name="cbSizeHeader">Size of the header.</param>
		/// <returns>0 if successful if pData is null, otherwise number of bytes if pData is not null.</returns>
		[LibraryImport(ApiLib)]
		public static partial int
		GetRawInputData(
			nint hRawInput,
			Command uiCommand,
			nint pData,
			ref int pcbSize,
			int cbSizeHeader);

		/// <summary>
		/// Enumerates the raw input devices attached to the system.
		/// </summary>
		/// <param name="pRawInputDeviceList">
		/// An array of <see cref="RAWINPUTDEVICELIST"/> structures for the devices attached to the
		/// system. Pointer should be aligned on a DWORD (32-bit) boundary. If <see langword="null"/>,
		/// the number of devices are returned in *<paramref name="puiNumDevices"/>.
		/// </param>
		/// <param name="puiNumDevices">
		/// If <paramref name="pRawInputDeviceList"/> is <see langword="null"/>, the function
		/// populates this variable with the number of devices attached to the system; otherwise, this
		/// variable specifies the number of <see cref="RAWINPUTDEVICELIST"/> structures that can be
		/// contained in the buffer to which <paramref name="pRawInputDeviceList"/> points. If this
		/// value is less than the number of devices attached to the system, the function returns the
		/// actual number of devices in this variable and fails with ERROR_INSUFFICIENT_BUFFER. If this
		/// value is greater than or equal to the number of devices attached to the system, then the
		/// value is unchanged, and the number of devices is reported as the return value.
		/// </param>
		/// <param name="cbSize">Size of a <see cref="RAWINPUTDEVICELIST"/> structure.</param>
		/// <returns>
		/// <para>If the function is successful, the return value is the number of devices stored in
		/// the buffer pointed to by <paramref name="pRawInputDeviceList"/>.</para>
		/// <para>If <paramref name="pRawInputDeviceList"/> is <see langword="null"/>, the return
		/// value is zero.</para>
		/// <para>If *<paramref name="puiNumDevices"/> is smaller than needed to contain all the
		/// <see cref="RAWINPUTDEVICELIST"/> structures, the return value is <c>-1</c> and the
		/// required buffer is returned in *<paramref name="puiNumDevices"/>. Calling
		/// <see cref="Marshal.GetLastWin32Error"/> returns ERROR_INSUFFICIENT_BUFFER.</para>
		/// <para>On any other error, the function returns <c>-1</c> and
		/// <see cref="Marshal.GetLastWin32Error"/> returns the error indication.</para>
		/// </returns>
		/// <remarks>
		/// <para>The devices returned from this function are the mouse, the keyboard, and other
		/// Human Interface Device (HID) devices.</para>
		/// <para>To get more detailed information about the attached devices, call
		/// <see cref="GetRawInputDeviceInfo"/> using the <see cref="RAWINPUTDEVICELIST.DeviceHandle"/>.
		/// </para>
		/// </remarks>
		[LibraryImport(ApiLib, SetLastError = true)]
		public unsafe static partial int GetRawInputDeviceList(
			RAWINPUTDEVICELIST* pRawInputDeviceList,
			ref int  puiNumDevices,
			int cbSize);

		/// <summary>
		/// Gets information about the raw input device.
		/// </summary>
		/// <param name="deviceHandle">Handle to the raw input device. This comes from the lParam of the <see cref="WM_INPUT"/> message, from <see cref="RAWINPUTHEADER.hDevice"/>, or from <see cref="GetRawInputDeviceList"/>.</param>
		/// <param name="command">Specifies what data will be returned in pData.</param>
		/// <param name="data"></param>
		/// <param name="dataSize"></param>
		/// <returns></returns>
		[LibraryImport(ApiLib, EntryPoint = "GetRawInputDeviceInfoW", SetLastError = true)]
		public static unsafe partial uint
		GetRawInputDeviceInfo(
			nint deviceHandle,
			DeviceInfoItem command,
			void* data,
			ref int dataSize);

		//[DllImport(ApiLib)]
		//public static extern nint
		//DefRawInputProc(
		//	[MarshalAs(UnmanagedType.
		//	__in_ecount(nInput) PRAWINPUT* paRawInput,
		//	int nInput,
		//	int cbSizeHeader);
	}
}
