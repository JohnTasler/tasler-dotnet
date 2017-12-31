using System;

namespace Tasler.Interop.Shell
{
	public static partial class PropertyKeys
	{
		public static class Computer
		{
			/// <summary>
			/// Free space and total space: "%s free of %s"</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Computer.DecoratedFreeSpace -- PKEY_Computer_DecoratedFreeSpace</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue UInt64 -- VT_VECTOR | VT_UI8  (For variants: VT_ARRAY | VT_UI8)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_Volume) 9B174B35-40FF-11D2-A27E-00C04FC30871, 7  (Filesystem Volume Properties)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey DecoratedFreeSpace { get { return new PropertyKey(0x9B174B35, 0x40FF, 0x11D2, 0xA2, 0x7E, 0x00, 0xC0, 0x4F, 0xC3, 0x08, 0x71, 7); } }
		}
	}
}