using System.Runtime.InteropServices;

namespace Tasler.Interop.Kernel;

[StructLayout(LayoutKind.Sequential)]
public struct FILETIME
{
	public uint LowDateTime;
	public uint HighDateTime;

	public FILETIME(ulong value)
	{
		LowDateTime = (uint)(value & 0xFFFFFFFF);
		HighDateTime = (uint)((value >> 32) & 0xFFFFFFFF);
	}
	public FILETIME(long value) : this((ulong)value) { }

	public static implicit operator ulong(FILETIME ft)
		=> ((ulong)ft.HighDateTime << 32) | ft.LowDateTime;

	public static implicit operator long(FILETIME ft)
		=> (long)((ulong)ft.HighDateTime << 32) | ft.LowDateTime;
}
