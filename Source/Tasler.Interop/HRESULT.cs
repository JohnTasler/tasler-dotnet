using System.Runtime.InteropServices;

namespace Tasler.Interop;


[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct HRESULT
{
	public int Value;

	public static implicit operator HRESULT(int value) => value;
	public static implicit operator int(HRESULT value) => value;
}
