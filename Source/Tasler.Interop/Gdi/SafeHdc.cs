using System;
using System.Runtime.InteropServices;

namespace Tasler.Interop.Gdi
{
	public abstract class SafeHdc : SafeHandle
	{
		public static readonly SafeHdc Null = new NullHdc();

		#region Constructors
		protected SafeHdc()
			: base(IntPtr.Zero, true)
		{
		}
		#endregion Constructors

		#region Overrides
		public override bool IsInvalid
		{
			get { return base.handle == IntPtr.Zero; }
		}

		#endregion Overrides

		#region Nested Types
		private class NullHdc : SafeHdc
		{
			protected override bool ReleaseHandle()
			{
				return true;
			}
		}
		#endregion Nested Types
	}
}
