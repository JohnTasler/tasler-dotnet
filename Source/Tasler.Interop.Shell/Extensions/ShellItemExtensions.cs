using System.Runtime.InteropServices;
using Tasler.Interop.Shell.PropertyStore;

namespace Tasler.Interop.Shell;

public static class ShellItemExtensions
{
	public static IPropertyStore GetItemPropertyStore(this IShellItem2 item, GetPropertyStoreFlags flags)
	{
		var riid = typeof(IPropertyStore).GUID;
		return (IPropertyStore)item.GetPropertyStore(flags, ref riid);
	}

	public static PROPVARIANT GetProperty(this IShellItem2 item, PropertyKey key) => item.GetProperty(ref key);

	public static Guid GetCLSID(this IShellItem2 item, PropertyKey key) => item.GetCLSID(ref key);

	public static ulong GetFileTime(this IShellItem2 item, PropertyKey key) => item.GetFileTime(ref key);

	public static int GetInt32(this IShellItem2 item, PropertyKey key) => item.GetInt32(ref key);

	public static string GetString(this IShellItem2 item, PropertyKey key)
	{
		var variant = item.GetProperty(ref key);
		if (variant.vt != VARTYPE.LPWStr || variant.punkVal == nint.Zero)
			return string.Empty;

		using var value = new SafeCoTaskMemString() { Handle = variant.punkVal };
		return value.Value;
	}

	public static uint GetUInt32(this IShellItem2 item, PropertyKey key) => item.GetUInt32(ref key);

	public static ulong GetUInt64(this IShellItem2 item, PropertyKey key) => item.GetUInt64(ref key);

	public static bool GetBool(this IShellItem2 item, PropertyKey key) => item.GetBool(ref key);
}
