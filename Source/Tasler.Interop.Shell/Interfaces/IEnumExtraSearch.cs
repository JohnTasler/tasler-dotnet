using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com;

namespace Tasler.Interop.Shell;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("0E700BE1-9DB6-11d1-A1CE-00C04FD75D13")]
public partial interface IEnumExtraSearch
{
	/// <param name="elementCount"></param>
	/// <param name="elements"></param>
	/// <param name="elementsFetched"></param>
	[PreserveSig]
	int Next(int elementCount, [MarshalUsing(CountElementName = nameof(elementCount))] [Out] EXTRASEARCH[] elements, out int elementsFetched);

	/// <param name="elementsToSkip"></param>
	[PreserveSig]
	int Skip(int elementsToSkip);

	void Reset();

	IEnumExtraSearch Clone();
}

[StructLayout(LayoutKind.Sequential)]
public struct EXTRASEARCH
{
	public Guid GuidSearch;
	private unsafe fixed char _friendlyName[80];
	private unsafe fixed char _url[2084];

	public readonly string FriendlyName
	{
		get
		{
			unsafe
			{
				fixed (char* friendlyName = _friendlyName)
				{
					return new(friendlyName);
				}
			}
		}
	}

	public readonly string Url
	{
		get
		{
			unsafe
			{
				fixed (char* url = _url)
				{
					return new(url);
				}
			}
		}
	}
}
