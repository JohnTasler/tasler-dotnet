using System;
using System.Runtime.InteropServices;

namespace Tasler.Interop
{
	public class SafeCoTaskMemHandle : SafeHandle
	{
		#region Construction
		public SafeCoTaskMemHandle()
			: base(IntPtr.Zero, true)
		{
		}
		#endregion Construction

		#region Overrides
		public override bool IsInvalid
		{
			get
			{
				return base.handle == IntPtr.Zero;
			}
		}

		protected override bool ReleaseHandle()
		{
			Marshal.FreeCoTaskMem(base.handle);
			return true;
		}
		#endregion Overrides
	}
}
