
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class History
	{
		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.History.VisitCount -- PKEY_History_VisitCount</description></item>
		///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
		///   <item><term><b>Format ID:</b></term><description>{5CBF2787-48CF-4208-B90E-EE5E5D420294}, 7  (PKEYs relating to URLs.  Used by IE History.)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey VisitCount => new(0x5CBF2787, 0x48CF, 0x4208, 0xB9, 0x0E, 0xEE, 0x5E, 0x5D, 0x42, 0x02, 0x94, 7);
	}
}
