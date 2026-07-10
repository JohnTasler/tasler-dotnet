using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com;

namespace Tasler.Interop.Shell;

[Guid("7E9FB0D3-919F-4307-AB2E-9B1860310C93")]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IShellItem2 : IShellItem
{
	public IUnknown GetPropertyStore(GetPropertyStoreFlags flags, ref Guid riid);

	public IUnknown GetPropertyStoreWithCreateObject(
		GetPropertyStoreFlags flags,
		IUnknown punkCreateObject,
		ref Guid riid);

	public IUnknown GetPropertyStoreForKeys(
		ref PropertyKey rgKeys,
		uint cKeys,
		GetPropertyStoreFlags flags,
		ref Guid riid);

	public IUnknown GetPropertyDescriptionList(
		ref PropertyKey keyType,
		ref Guid riid);

	public void Update(IBindCtx pbc);

	public PROPVARIANT GetProperty(ref PropertyKey key);

	public Guid GetCLSID(ref PropertyKey key);

	public ulong GetFileTime(ref PropertyKey key);

	public int GetInt32(ref PropertyKey key);

	public nint GetString(ref PropertyKey key);

	public uint GetUInt32(ref PropertyKey key);

	public ulong GetUInt64(ref PropertyKey key);

	[return: MarshalAs(UnmanagedType.Bool)]
	public bool GetBool(ref PropertyKey key);
}
