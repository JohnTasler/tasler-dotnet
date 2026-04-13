using System.Runtime.InteropServices;
using Tasler.Interop.Extensions;
using Tasler.Interop.User;

namespace Tasler.Interop.Kernel;

public static partial class KernelApi
{
	public static uint GetCurrentProcessId() => NativeMethods.GetCurrentProcessId();

	public static uint GetCurrentThreadId() => NativeMethods.GetCurrentThreadId();

	public static SafeProcessHandle GetCurrentProcess() => NativeMethods.GetCurrentProcess();

	public static SafeInstanceHandle LoadLibrary(string libFileName)
		=> NativeMethods.LoadLibraryW(libFileName).ReturnOrThrow();

	public static SafeInstanceHandle LoadLibraryEx(string libFileName, LoadLibraryFlags flags)
		=> NativeMethods.LoadLibraryExW(libFileName, default, flags).ReturnOrThrow();

	public static bool CloseProcess(this SafeProcessHandle @this)
		=> NativeMethods.CloseHandle(@this).ReturnOrThrow();

	public static bool FreeLibrary(this SafeInstanceHandle module)
		=> NativeMethods.FreeLibrary(module).ReturnOrThrow();

	public static bool DuplicateHandle(
		this SafeProcessHandle hSourceProcessHandle,
		SafeHandle hSourceHandle,
		SafeProcessHandle hTargetProcessHandle,
		out nint pTargetHandle,
		uint dwDesiredAccess,
		bool bInheritHandle,
		uint dwOptions) =>
			NativeMethods.DuplicateHandle(
				hSourceProcessHandle,
				hSourceHandle,
				hTargetProcessHandle,
				out pTargetHandle,
				dwDesiredAccess,
				bInheritHandle,
				dwOptions).ReturnOrThrow();

	public static nint FindResource(this SafeInstanceHandle @this, ResourceValue name, ResourceType type)
		=> NativeMethods.FindResourceW(@this, name.Id, type.Id).ReturnOrThrow();

	public static nint LoadResource(this SafeInstanceHandle @this, nint hResInfo)
		=> NativeMethods.LoadResource(@this, hResInfo).ReturnOrThrow();

	public static int SizeofResource(this SafeInstanceHandle hModule, nint hResInfo)
		=> NativeMethods.SizeofResource(hModule, hResInfo).ReturnOrThrow();

	public static nint LockResource(this nint hResData)
		=> NativeMethods.LockResource(hResData);

	public unsafe static ReadOnlySpan<byte> FindLoadAndLockResource(this SafeInstanceHandle hModule, ResourceValue name, ResourceType type)
		=> hModule.FindLoadAndLockResource(name, type, out byte* pointer);

	public unsafe static ReadOnlySpan<byte> FindLoadAndLockResource(this SafeInstanceHandle hModule, ResourceValue name, ResourceType type, out byte* pointer)
	{
		var hResInfo = hModule.FindResource(name, type);
		var hResData = hModule.LoadResource(hResInfo);
		pointer = (byte*)hResData.LockResource();
		unsafe
		{
			var span = new ReadOnlySpan<byte>(pointer, hModule.SizeofResource(hResInfo));
			return span;
		}
	}

	public static IEnumerable<ResourceValue> EnumerateResourceNames(this SafeInstanceHandle @this, ResourceType resourceType)
	{
		unsafe
		{
			var data = new NativeMethods.ResourceNameData([]);
#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
			NativeMethods.EnumResourceNamesW(@this, resourceType.Id, EnumResourceNameProc, &data).ReturnOrThrow();
#pragma warning restore CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type

			return data.Items.Select(d => d.Name);
		}
	}

	private unsafe static bool EnumResourceNameProc(nint hModule, nint pszType, nint pszName, void* param)
	{
		#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
		var data = *((NativeMethods.ResourceNameData*)param);
		#pragma warning restore CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type

		data.Items.Add(new NativeMethods.ResourceNameDataItem( hModule, pszType, pszName));
		return true;
}

	public static IEnumerable<ResourceType> EnumerateResourceTypes(this SafeInstanceHandle @this)
	{
		unsafe
		{
			var data = new NativeMethods.ResourceTypeData([]);
#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
			NativeMethods.EnumResourceTypesW(@this, EnumResourceTypeProc, &data).ReturnOrThrow();
#pragma warning restore CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type

			return data.Items.Select(d => d.Type);
		}
	}

	private unsafe static bool EnumResourceTypeProc(nint hModule, nint pszType, void* param)
	{
		#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
		var data = *((NativeMethods.ResourceTypeData*)param);
		#pragma warning restore CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type

		data.Items.Add(new NativeMethods.ResourceTypeDataItem(hModule, pszType));
		return true;
	}
}
