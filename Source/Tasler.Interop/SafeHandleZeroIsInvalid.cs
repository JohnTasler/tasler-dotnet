using System.Runtime.InteropServices;

namespace Tasler.Interop;

public abstract class SafeHandleZeroIsInvalid : SafeHandle
{
	public SafeHandleZeroIsInvalid()
		: this(nint.Zero, false)
	{
	}

	public SafeHandleZeroIsInvalid(nint handle, bool ownsHandle = false)
		: base(handle, ownsHandle)
	{
	}

	public override bool IsInvalid => base.handle == nint.Zero;

	/// <summary>Gets or sets the underlying system handle.</summary>
	/// <value>The handle.</value>
	public nint Handle
	{
		get => base.handle;
		init => base.SetHandle(value);
	}

	/// <summary>
	/// Detaches and returns the current handle, resetting the internal handle to zero.
	/// </summary>
	/// <returns>The original handle value before detachment.</returns>
	public nint DetachHandle()
	{
		return Interlocked.Exchange(ref base.handle, nint.Zero);
	}

	/// <summary>
	/// Returns a hexadecimal string representation of the internal handle.
	/// </summary>
	/// <returns>A string in the format "handle = 0xXXXXXXXX".</returns>
	public override string ToString() => $"handle = 0x{base.handle:X8}";
}
