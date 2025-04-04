using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Tasler.Interop.Gdi;

namespace Tasler.Interop.RawInput.User
{
	public static partial class RawInputApi
	{
		public static RAWINPUTDEVICELIST[] GetRawInputDeviceList()
		{
			// Get the size of an unmanaged RAWINPUTDEVICELIST structure
			var sizeOfRAWINPUTDEVICELIST = Marshal.SizeOf<RAWINPUTDEVICELIST>();

			// Get the number of raw input devices on the system
			var deviceCount = 0;
			if (-1 == NativeMethods.GetRawInputDeviceList(nint.Zero, ref deviceCount, sizeOfRAWINPUTDEVICELIST))
				throw new Win32Exception();

			// Allocate a buffer to hold the list
			var bufferByteCount = deviceCount * sizeOfRAWINPUTDEVICELIST;
			var buffer = Marshal.AllocHGlobal(bufferByteCount);

			try
			{
				// Get the list
				_ = NativeMethods.GetRawInputDeviceList(buffer, ref bufferByteCount, sizeOfRAWINPUTDEVICELIST);

				// Marshal the buffer to a managed array
				var deviceList = new RAWINPUTDEVICELIST[deviceCount];
				for (int deviceIndex = 0; deviceIndex < deviceCount; ++deviceIndex)
				{
					var offsetBuffer = new nint(buffer.ToInt64() + deviceIndex * sizeOfRAWINPUTDEVICELIST);
					deviceList[deviceIndex] = Marshal.PtrToStructure<RAWINPUTDEVICELIST>(offsetBuffer);
				}

				// Return the managed array
				return deviceList;
			}
			finally
			{
				// Free the buffer
				Marshal.FreeHGlobal(buffer);
			}
		}

		public static RAWINPUTDEVICE[] GetRegisteredRawInputDevices()
		{
			const uint ERROR_INSUFFICIENT_BUFFER = 0x7Au;
			const uint E_UNEXPECTED = 0x8000FFFFu;
			unsafe
			{
				uint cbSize = unchecked((uint)Marshal.SizeOf<RAWINPUTDEVICE>()); E_UNEXPECTED.ToInt();
				uint numDevices;
				uint result = NativeMethods.GetRegisteredRawInputDevices(null, out numDevices, cbSize);

				if (result != uint.MaxValue)
					throw new InvalidOperationException { HResult = unchecked((int)E_UNEXPECTED) };

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
			=> NativeMethods.RegisterRawInputDevices(pRawInputDevices, pRawInputDevices.Length, Marshal.SizeOf<RAWINPUTDEVICE>());

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
			/// <returns>TRUE if successful, FALSE if not.</returns>
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
					SafeRawInputHandle hRawInput,
					Command uiCommand,
					out RAWINPUT pData,
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
				SafeRawInputHandle hRawInput,
				Command uiCommand,
				nint pData,
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
				SafeRawInputHandle hRawInput,
				Command uiCommand,
				out RAWINPUTHEADER pData,
				ref int pcbSize,
				int cbSizeHeader);

			/// <summary>
			/// Enumerates the raw input devices attached to the system.
			/// </summary>
			/// <param name="pRawInputDeviceList">Pointer to buffer that holds an array of <see cref="RAWINPUTDEVICELIST"/>
			/// structures for the devices attached to the system. If NULL, the number of devices are returned in *puiNumDevices.</param>
			/// <param name="puiNumDevices">Pointer to a variable. If <paramref name="pRawInputDeviceList"/> is NULL,
			/// it specifies the number of devices attached to the system. Otherwise, it contains the size, in bytes,
			/// of the preallocated buffer pointed to by <paramref name="pRawInputDeviceList"/>. However, if *puiNumDevices
			/// is smaller than needed to contain <see cref="RAWINPUTDEVICELIST"/> structures, the required buffer size is returned here.</param>
			/// <param name="cbSize">Size of a <see cref="RAWINPUTDEVICELIST"/> structure.</param>
			/// <returns>
			/// <para>If the function is successful, the return value is the number of devices stored in the buffer pointed to by
			/// <paramref name="pRawInputDeviceList"/>.</para>
			/// <para>If <paramref name="pRawInputDeviceList"/> is NULL, the return value is zero.</para>
			/// <para>If *<paramref name="puiNumDevices"/> is smaller than needed to contain all the <see cref="RAWINPUTDEVICELIST"/>
			/// structures, the return value is (UINT) -1 and the required buffer is returned in *<paramref name="puiNumDevices"/>.
			/// Calling <see cref="Marshal.GetLastWin32Error"/> returns ERROR_INSUFFICIENT_BUFFER.</para>
			/// <para>On any other error, the function returns (UINT) -1 and <see cref="Marshal.GetLastWin32Error"/>
			/// returns the error indication.</para>
			/// </returns>
			/// <remarks>
			/// <para>The devices returned from this function are the mouse, the keyboard, and other
			/// Human Interface Device (HID) devices.</para>
			/// <para>To get more detailed information about the attached devices, call <see cref="GetRawInputDeviceInfo"/>
			/// using the <see cref="RAWINPUTDEVICELIST.DeviceHandle"/>.</para>
			/// </remarks>
			[LibraryImport(ApiLib, EntryPoint = "GetRawInputDeviceListW", SetLastError = true)]
			public static partial int GetRawInputDeviceList(
				nint pRawInputDeviceList,
				ref int puiNumDevices,
				int cbSize);

			/// <summary>
			/// Gets information about the raw input device.
			/// </summary>
			/// <param name="deviceHandle">Handle to the raw input device. This comes from the lParam of the <see cref="WM_INPUT"/> message, from <see cref="RAWINPUTHEADER.hDevice"/>, or from <see cref="GetRawInputDeviceList"/>.</param>
			/// <param name="command">Specifies what data will be returned in pData.</param>
			/// <param name="data"></param>
			/// <param name="dataSize"></param>
			/// <returns></returns>
			[LibraryImport(ApiLib, SetLastError = true)]
			public static unsafe partial uint
			GetRawInputDeviceInfoW(
				SafeRawInputHandle deviceHandle,
				DeviceInfoItem command,
				void* data,
				ref uint dataSize);

			//[DllImport(ApiLib)]
			//public static extern nint
			//DefRawInputProc(
			//	[MarshalAs(UnmanagedType.
			//	__in_ecount(nInput) PRAWINPUT* paRawInput,
			//	int nInput,
			//	int cbSizeHeader);
		}
	}
}
