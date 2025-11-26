using System.Runtime.InteropServices;
using Tasler.Extensions;
using Tasler.Interop.Kernel;

namespace Tasler.Interop.Com;

[StructLayout(LayoutKind.Sequential)]
public struct BIND_OPTS
{
	private int _size = BIND_OPTS.SizeOf;
	public BIND_FLAGS Flags;
	public STGM       Mode;
	public uint       TickCountDeadline;

	/// <summary>
/// Initializes a new instance of the <see cref="BIND_OPTS"/> struct.
/// </summary>
/// <remarks>
/// Ensures the internal size field is set to the size of the struct for native interop marshalling.
/// </remarks>
public BIND_OPTS() { }
}

[StructLayout(LayoutKind.Sequential)]
public struct STATSTG : IDisposable
{
	private nint     _name;
	public  STGTY    Type;
	public  ulong    ByteSize;
	public  FILETIME ModificationTime;
	public  FILETIME CreationTime;
	public  FILETIME AccessTime;
	public  STGM     Mode;
	public  LockType LocksSupported;
	public  Guid     Clsid;
	private uint     _reserved1; // State bits are not used
	private uint     _reserved2;

	public readonly string Name => Marshal.PtrToStringUni(_name) ?? string.Empty;

	/// <summary>
	/// Releases the unmanaged memory holding the STATSTG name and clears the internal pointer.
	/// </summary>
	/// <remarks>
	/// Performs a thread-safe release of the internal name pointer; if no unmanaged memory is allocated, this method does nothing. After calling Dispose, the Name property will return an empty string.
	/// </remarks>
	public void Dispose()
	{
		nint name = Interlocked.Exchange(ref _name, nint.Zero);
		if (name != nint.Zero)
			Marshal.FreeCoTaskMem(name);
	}
}