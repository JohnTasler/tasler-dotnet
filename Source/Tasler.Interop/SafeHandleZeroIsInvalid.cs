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

		public override string ToString() => $"handle = 0x{base.handle:X8}";
	}
}
