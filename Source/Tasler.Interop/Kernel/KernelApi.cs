using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using Tasler.Interop.Extensions;
using Tasler.Interop.User;

namespace Tasler.Interop.Kernel;

public static partial class KernelApi
{
	internal static partial class NativeMethods
	{
		#region Constants
		private const string ApiLib = "kernel32.dll";
		#endregion Constants

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool ResetEvent(SafeWaitHandle handle);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool SetEvent(SafeWaitHandle handle);

		[LibraryImport(ApiLib)]
		public static partial uint GetCurrentProcessId();

		[LibraryImport(ApiLib)]
		public static partial uint GetCurrentThreadId();

		[LibraryImport(ApiLib)]
		public static partial SafeProcessHandle GetCurrentProcess();

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool CloseHandle(SafeProcessHandle handle);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool DuplicateHandle(
			SafeProcessHandle hSourceProcessHandle,
			SafeHandle hSourceHandle,
			SafeProcessHandle hTargetProcessHandle,
			out nint lpTargetHandle,
			uint dwDesiredAccess,
			[MarshalAs(UnmanagedType.Bool)]
			bool bInheritHandle,
			uint dwOptions);

		[LibraryImport(ApiLib, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
		public static partial SafeInstanceHandle LoadLibraryW(string libFileName);

		[LibraryImport(ApiLib, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
		public static partial SafeInstanceHandle LoadLibraryExW(string libFileName, nint hwndUnused, LoadLibraryFlags flags);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool FreeLibrary(SafeInstanceHandle handle);

		[LibraryImport(ApiLib, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
		public static partial nint FindResourceW(SafeInstanceHandle hModule, nint lpName, nint lpType);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial nint LoadResource(SafeInstanceHandle hModule, nint hResInfo);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial int SizeofResource(SafeInstanceHandle hModule, nint hResInfo);

		[LibraryImport(ApiLib)]
		public static partial nint LockResource(nint hResData);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public unsafe static partial bool EnumResourceNamesW(SafeInstanceHandle hModule, nint pszType, EnumResourceNameProc enumFunc, void* param);

		[return: MarshalAs(UnmanagedType.Bool)]
		public unsafe delegate bool EnumResourceNameProc(nint hModule, nint pszType, nint pszName, void* param);

		[StructLayout(LayoutKind.Sequential)]
		public record struct ResourceNameDataItem(SafeInstanceHandle Module, ResourceType Type, ResourceValue Name);

		[StructLayout(LayoutKind.Sequential)]
		public record struct ResourceNameData(List<ResourceNameDataItem> Items);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public unsafe static partial bool EnumResourceTypesW(SafeInstanceHandle hModule, EnumResourceTypeProc enumFunc, void* param);

		[return: MarshalAs(UnmanagedType.Bool)]
		public unsafe delegate bool EnumResourceTypeProc(nint hModule, nint pszType, void* param);

		[StructLayout(LayoutKind.Sequential)]
		public record struct ResourceTypeDataItem(SafeInstanceHandle Module, ResourceType Type);

		[StructLayout(LayoutKind.Sequential)]
		public record struct ResourceTypeData(List<ResourceTypeDataItem> Items);

	}
}
