using System.Runtime.InteropServices;

namespace Tasler.Interop;

public class SafeCoTaskMemString : SafeCoTaskMemHandle
{
	#region Construction
	public SafeCoTaskMemString()
	{
	}
	#endregion Construction

	#region Properties

	public string Value => Marshal.PtrToStringUni(base.handle) ?? string.Empty;

	#endregion Properties

}
