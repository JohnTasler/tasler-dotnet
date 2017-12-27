using System;
using System.Runtime.InteropServices;

namespace Tasler.Interop
{
	public class SafeHGlobalHandle : SafeHandle
	{
		#region Construction
		public SafeHGlobalHandle()
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
			Marshal.FreeHGlobal(base.handle);
			return true;
		}
		#endregion Overrides
	}
}
