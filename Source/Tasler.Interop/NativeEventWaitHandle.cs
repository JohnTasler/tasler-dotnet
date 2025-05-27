using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using Tasler.Interop.Kernel;

namespace Tasler.Interop;

public partial class NativeEventWaitHandle : NativeWaitHandle
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
	/// <param name="createDuplicate">If <see langword="true"/>, wraps a duplicate of
	/// <paramref name="nativeHandle"/>. If <see langword="false"/>, wraps <paramref name="nativeHandle"/>
	/// directly. The default is <see langword="false"/>.</param>
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
		if (!KernelApi.NativeMethods.ResetEvent(base.SafeWaitHandle))
			throw new Win32Exception(Marshal.GetLastWin32Error());
	}

	/// <summary>
	/// Sets the state of the event to signaled, allowing one or more waiting threads to proceed.
	/// </summary>
	public void Set()
	{
		if (!KernelApi.NativeMethods.SetEvent(base.SafeWaitHandle))
			throw new Win32Exception();
	}

	#endregion Methods
}
