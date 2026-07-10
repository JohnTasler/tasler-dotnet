using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Tasler.Interop.Com;
using Tasler.Interop.Kernel;
using Tasler.Interop.SuppressMessage;

namespace Tasler.Interop.Shell;

[StructLayout(LayoutKind.Sequential)]
public struct VARIANT_BOOL
{
	public short Value;
	public static implicit operator bool(VARIANT_BOOL v) => v.Value != 0;
	public static implicit operator VARIANT_BOOL(bool v) => new () { Value = (short)(v ? 1 : 0) };
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public struct VersionedStream
{
	public Guid guidVersion;
	public nint pStream;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CAC
{
	public uint cElems;
	public byte* pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CAUB
{
	public uint cElems;
	public byte* pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CAI
{
	public uint cElems;
	public short* pElems;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CAUI
{
	public uint cElems;
	public ushort* pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CAL
{
	public uint cElems;
	public int *pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CAUL
{
	public uint cElems;
	public uint* pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CAFLT
{
	public uint cElems;
	public float* pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CADBL
{
	public uint cElems;
	public double* pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CACY
{
	public uint cElems;
	public ulong* pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CADATE
{
	public uint cElems;
	public double* pElems;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CABSTR
{
	public uint cElems;
	public char** pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CABOOL
{
	public uint cElems;
	public VARIANT_BOOL* pElems;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CASCODE
{
	public uint cElems;
	public int* pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CAPROPVARIANT
{
	public uint cElems;
	public PROPVARIANT* pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CAH
{
	public uint cElems;
	public long* pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CAUH
{
	public uint cElems;
	public ulong* pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CALPSTR
{
	public uint cElems;
	public byte** pElems;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CALPWSTR
{
	public uint cElems;
	public char** pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CAFILETIME
{
	public uint cElems;
	public FILETIME* pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CACLIPDATA
{
	public uint cElems;
	public CLIPDATA* pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CACLSID
{
	public uint cElems;
	public Guid* pElems;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct CLIPDATA
{
	public uint cbSize;
	public int ulClipFmt;
	public byte* pClipData;

	public uint ByteCount => cbSize - sizeof(int);
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct BLOB
{
	public uint cbSize;
	public byte* pBlobData;
}

public enum VARTYPE : ushort
{
	Empty           = 0,
	Null            = 1,
	I2              = 2,
	I4              = 3,
	R4              = 4,
	R8              = 5,
	CY              = 6,
	Date            = 7,
	Bstr            = 8,
	Dispatch        = 9,
	Error           = 10,
	Bool            = 11,
	Variant         = 12,
	Unknown         = 13,
	Decimal         = 14,
	I1              = 16,
	UI1             = 17,
	UI2             = 18,
	UI4             = 19,
	I8              = 20,
	UI8             = 21,
	Int             = 22,
	UInt            = 23,
	Void            = 24,
	Hresult         = 25,
	Ptr             = 26,
	SafeArray       = 27,
	CArray          = 28,
	UserDefined     = 29,
	LPStr           = 30,
	LPWStr          = 31,
	Record          = 36,
	IntPtr          = 37,
	UIntPtr         = 38,
	FileTime        = 64,
	Blob            = 65,
	Stream          = 66,
	Storage         = 67,
	StreamedObject  = 68,
	StoredObject    = 69,
	BlobObject      = 70,
	CF              = 71,
	CLSID           = 72,
	VersionedStream = 73,
	Vector          = 0x1000,
	Array           = 0x2000,
	Byref           = 0x4000,
	Reserved        = 0x8000,
	Illegal         = 0xffff,
	IllegalMasked   = 0xfff,
	TypeMask        = 0xfff
}

[StructLayout(LayoutKind.Explicit)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct PROPVARIANT
{
	[FieldOffset(0)] public VARTYPE vt;
	[FieldOffset(2)] private short _wReserved1;
	[FieldOffset(4)] private short _wReserved2;
	[FieldOffset(6)] private short _wReserved3;
	[FieldOffset(8)] public char cVal;
	[FieldOffset(8)] public char bVal;
	[FieldOffset(8)] public short iVal;
	[FieldOffset(8)] public ushort uiVal;
	[FieldOffset(8)] public int lVal;
	[FieldOffset(8)] public uint ulVal;
	[FieldOffset(8)] public int intVal;
	[FieldOffset(8)] public uint uintVal;
	[FieldOffset(8)] public int hVal;
	[FieldOffset(8)] public uint uhVal;
	[FieldOffset(8)] public float fltVal;
	[FieldOffset(8)] public double dblVal;
	[FieldOffset(8)] public VARIANT_BOOL boolVal;
	[FieldOffset(8)] public int scode;
	[FieldOffset(8)] public double date;
	[FieldOffset(8)] public FILETIME filetime;
	[FieldOffset(8)] public Guid* puuid;
	[FieldOffset(8)] public CLIPDATA* pclipdata;
	[FieldOffset(8)] public char* bstrVal;
	[FieldOffset(8)] public BLOB blob;
	[FieldOffset(8)] public byte* pszVal;
	[FieldOffset(8)] public char* pwszVal;
	[FieldOffset(8)] public nint punkVal; // IUnknown*
	[FieldOffset(8)] public nint pdispVal; // IDispatch*
	[FieldOffset(8)] public nint pStream; // IStream*
	[FieldOffset(8)] public nint pStorage; // IStorage*
	[FieldOffset(8)] public VersionedStream* pVersionedStream;
	[FieldOffset(8)] public CAC cac;
	[FieldOffset(8)] public CAUB caub;
	[FieldOffset(8)] public CAI cai;
	[FieldOffset(8)] public CAUI caui;
	[FieldOffset(8)] public CAL cal;
	[FieldOffset(8)] public CAUL caul;
	[FieldOffset(8)] public CAH cah;
	[FieldOffset(8)] public CAUH cauh;
	[FieldOffset(8)] public CAFLT caflt;
	[FieldOffset(8)] public CADBL cadbl;
	[FieldOffset(8)] public CABOOL cabool;
	[FieldOffset(8)] public CASCODE cascode;
	[FieldOffset(8)] public CACY cacy;
	[FieldOffset(8)] public CADATE cadate;
	[FieldOffset(8)] public CAFILETIME cafiletime;
	[FieldOffset(8)] public CACLSID cauuid;
	[FieldOffset(8)] public CACLIPDATA caclipdata;
	[FieldOffset(8)] public CABSTR cabstr;
	[FieldOffset(8)] public CALPSTR calpstr;
	[FieldOffset(8)] public CALPWSTR calpwstr;
	[FieldOffset(8)] public CAPROPVARIANT capropvar;
	[FieldOffset(8)] public sbyte* pcVal;
	[FieldOffset(8)] public byte* pbVal;
	[FieldOffset(8)] public short* piVal;
	[FieldOffset(8)] public ushort* puiVal;
	[FieldOffset(8)] public int* plVal;
	[FieldOffset(8)] public uint* pulVal;
	[FieldOffset(8)] public int* pintVal;
	[FieldOffset(8)] public uint* puintVal;
	[FieldOffset(8)] public float* pfltVal;
	[FieldOffset(8)] public double* pdblVal;
	[FieldOffset(8)] public VARIANT_BOOL* pboolVal; // VARIANT_BOOL*
	[FieldOffset(8)] public decimal *pdecVal;
	[FieldOffset(8)] public int* pscode;
	[FieldOffset(8)] public double* pdate;
	[FieldOffset(8)] public nint* pbstrVal;
	[FieldOffset(8)] public nint ppunkVal; // IUnknown**
	[FieldOffset(8)] public nint ppdispVal; // IDispatch**
	[FieldOffset(8)] public nint pvarVal; // PROPVARIANT*
	[FieldOffset(8)] public decimal decVal;
};

[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public unsafe struct PropVariantValue
{
	[FieldOffset(0)] public char cVal;
	[FieldOffset(0)] public char bVal;
	[FieldOffset(0)] public short iVal;
	[FieldOffset(0)] public ushort uiVal;
	[FieldOffset(0)] public int lVal;
	[FieldOffset(0)] public uint ulVal;
	[FieldOffset(0)] public int intVal;
	[FieldOffset(0)] public uint uintVal;
	[FieldOffset(0)] public int hVal;
	[FieldOffset(0)] public uint uhVal;
	[FieldOffset(0)] public float fltVal;
	[FieldOffset(0)] public double dblVal;
	[FieldOffset(0)] public VARIANT_BOOL boolVal;
	[FieldOffset(0)] public int scode;
	[FieldOffset(0)] public double date;
	[FieldOffset(0)] public FILETIME filetime;
	[FieldOffset(0)] public Guid* puuid;
	[FieldOffset(0)] public CLIPDATA* pclipdata;
	[FieldOffset(0)] public char* bstrVal;
	[FieldOffset(0)] public BLOB blob;
	[FieldOffset(0)] public byte* pszVal;
	[FieldOffset(0)] public char* pwszVal;
	[FieldOffset(0)] public nint punkVal; // IUnknown*
	[FieldOffset(0)] public nint pdispVal; // IDispatch*
	[FieldOffset(0)] public IStream pStream; // IStream*
	[FieldOffset(0)] public IStorage pStorage; // IStorage*
	[FieldOffset(0)] public VersionedStream* pVersionedStream;
	[FieldOffset(0)] public CAC cac;
	[FieldOffset(0)] public CAUB caub;
	[FieldOffset(0)] public CAI cai;
	[FieldOffset(0)] public CAUI caui;
	[FieldOffset(0)] public CAL cal;
	[FieldOffset(0)] public CAUL caul;
	[FieldOffset(0)] public CAH cah;
	[FieldOffset(0)] public CAUH cauh;
	[FieldOffset(0)] public CAFLT caflt;
	[FieldOffset(0)] public CADBL cadbl;
	[FieldOffset(0)] public CABOOL cabool;
	[FieldOffset(0)] public CASCODE cascode;
	[FieldOffset(0)] public CACY cacy;
	[FieldOffset(0)] public CADATE cadate;
	[FieldOffset(0)] public CAFILETIME cafiletime;
	[FieldOffset(0)] public CACLSID cauuid;
	[FieldOffset(0)] public CACLIPDATA caclipdata;
	[FieldOffset(0)] public CABSTR cabstr;
	[FieldOffset(0)] public CALPSTR calpstr;
	[FieldOffset(0)] public CALPWSTR calpwstr;
	[FieldOffset(0)] public CAPROPVARIANT capropvar;
	[FieldOffset(0)] public sbyte* pcVal;
	[FieldOffset(0)] public byte* pbVal;
	[FieldOffset(0)] public short* piVal;
	[FieldOffset(0)] public ushort* puiVal;
	[FieldOffset(0)] public int* plVal;
	[FieldOffset(0)] public uint* pulVal;
	[FieldOffset(0)] public int* pintVal;
	[FieldOffset(0)] public uint* puintVal;
	[FieldOffset(0)] public float* pfltVal;
	[FieldOffset(0)] public double* pdblVal;
	[FieldOffset(0)] public VARIANT_BOOL* pboolVal; // VARIANT_BOOL*
	[FieldOffset(0)] public decimal *pdecVal;
	[FieldOffset(0)] public int* pscode;
	[FieldOffset(0)] public double* pdate;
	[FieldOffset(0)] public nint* pbstrVal;
	[FieldOffset(0)] public nint ppunkVal; // IUnknown**
	[FieldOffset(0)] public nint ppdispVal; // IDispatch**
	[FieldOffset(0)] public nint pvarVal; // PROPVARIANT*
	[FieldOffset(0)] public decimal decVal;
}
