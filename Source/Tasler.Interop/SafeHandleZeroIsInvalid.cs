using System.Runtime.InteropServices;

namespace Tasler.Interop
{
	public abstract class SafeHandleZeroIsInvalid : SafeHandle
	{
		public SafeHandleZeroIsInvalid()
			: base(nint.Zero, false)
		{
		}

		public SafeHandleZeroIsInvalid(bool ownsHandle)
			: base(nint.Zero, ownsHandle)
		{
		}

		public override bool IsInvalid => base.handle == nint.Zero;

		public nint Handle
		{
			get => base.handle;
			init => base.SetHandle(value);
		}
	}
}
