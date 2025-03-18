using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Tasler.Interop;

public class NativeEventWaitHandle : NativeWaitHandle
{
	#region Construction

	/// <summary>
	/// Wraps the specified native event handle.
	/// </summary>
	/// <param name="nativeHandle"></param>
	public NativeEventWaitHandle(SafeWaitHandle nativeHandle)
		: this(nativeHandle, false)
	{
	}

	/// <summary>
	/// Wraps the specified native event handle or, optionally, a duplicate of it.
	/// </summary>
	/// <param name="nativeHandle">The native event handle.</param>
	/// <param name="createDuplicate">If <c>true</c>, wraps a duplicate of
	/// <paramref name="nativeHandle"/>. If <c>false</c>, wraps <paramref name="nativeHandle"/>
	/// directly. The default is <c>false</c>.</param>
	public NativeEventWaitHandle(SafeWaitHandle nativeHandle, bool createDuplicate)
		: base(nativeHandle, createDuplicate)
	{
	}

	#endregion Construction

	#region Methods

	/// <summary>
	/// Sets the state of the event to nonsignaled, causing threads to block.
	/// </summary>
	public void Reset()
	{
		if (!NativeEventWaitHandle.ResetEvent(base.SafeWaitHandle))
			throw new Win32Exception(Marshal.GetLastWin32Error());
	}

	/// <summary>
	/// Sets the state of the event to signaled, allowing one or more waiting threads to proceed.
	/// </summary>
	public void Set()
	{
		if (!NativeEventWaitHandle.SetEvent(base.SafeWaitHandle))
			throw new Win32Exception(Marshal.GetLastWin32Error());
	}

	#endregion Methods

	#region Platform Invoke

	#region Imported Methods

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool ResetEvent(SafeWaitHandle handle);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern bool SetEvent(SafeWaitHandle handle);

	#endregion Imported Methods

	#endregion Platform Invoke
}
