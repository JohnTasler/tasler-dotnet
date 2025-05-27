using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using Tasler.Interop.Kernel;

namespace Tasler.Interop;

public class NativeWaitHandle : WaitHandle
{
	#region Construction

	/// <summary>
	/// Wraps the specified native wait handle.
	/// </summary>
	/// <param name="nativeHandle">The native wait handle.</param>
	public NativeWaitHandle(SafeWaitHandle nativeHandle)
		: this(nativeHandle, false)
	{
	}

	/// <summary>
	/// Wraps the specified native wait handle or, optionally, a duplicate of it.
	/// </summary>
	/// <param name="nativeHandle">The native wait handle.</param>
	/// <param name="createDuplicate">If <see langword="true"/>, wraps a duplicate of
	/// <paramref name="nativeHandle"/>. If <see langword="false"/>, wraps <paramref name="nativeHandle"/>
	/// directly. The default is <see langword="false"/>.</param>
	public NativeWaitHandle(SafeWaitHandle nativeHandle, bool createDuplicate)
	{
		if (createDuplicate)
		{
			var hCurrentProcess = KernelApi.GetCurrentProcess();

			SafeWaitHandle duplicatedHandle = new();
			bool succeeded = hCurrentProcess.DuplicateHandle(
					nativeHandle, hCurrentProcess, ref duplicatedHandle,
					0, false, DUPLICATE_SAME_ACCESS);

			if (!succeeded)
				throw new Win32Exception(Marshal.GetLastWin32Error());

			nativeHandle = duplicatedHandle;
		}

		base.SafeWaitHandle = nativeHandle;
	}

	#endregion Construction

	private const int DUPLICATE_SAME_ACCESS = 0x00000002;
}
