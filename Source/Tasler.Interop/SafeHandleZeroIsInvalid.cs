using System.Runtime.InteropServices;

namespace Tasler.Interop
{
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
			var oldHandle = base.handle;
			base.SetHandle(nint.Zero);
			return oldHandle;
		}

		/// <summary>
/// Returns a hexadecimal string representation of the internal handle.
/// </summary>
/// <returns>A string in the format "handle = 0xXXXXXXXX".</returns>
public override string ToString() => $"handle = 0x{base.handle:X8}";
	}
}
