using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Kernel;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("0000000f-0000-0000-C000-000000000046")]
public partial interface IMoniker	: IPersistStream
{
	/// <summary>
	/// Binds the moniker to the object it identifies or to a specific interface using the provided binding context.
	/// </summary>
	/// <param name="pbc">The binding context that supplies parameters and services for the bind operation.</param>
	/// <param name="pmkToLeft">An optional moniker to the left of this moniker when binding relative names; null if not used.</param>
	/// <param name="riidResult">Reference to the GUID of the interface being requested; on success the resulting object implements this interface.</param>
	/// <returns>A COM HRESULT value as a native integer indicating success or failure.</returns>
	nint BindToObject(IBindCtx pbc, IMoniker? pmkToLeft, ref Guid riidResult);

	/// <summary>
	/// Binds the moniker to its storage object using the specified binding context.
	/// </summary>
	/// <param name="pbc">The binding context used during the bind operation; may be null.</param>
	/// <param name="pmkToLeft">An optional moniker that represents the object to the left of this moniker in a composite binding; may be null.</param>
	/// <param name="riid">The GUID of the interface being requested for the storage object.</param>
	/// <returns>An HRESULT value indicating success or failure of the bind operation.</returns>
	nint BindToStorage(IBindCtx pbc, IMoniker? pmkToLeft, ref Guid riid);

	/// <summary>
	/// Produces a reduced moniker that represents this moniker after truncating up to the specified reduction distance.
	/// </summary>
	/// <param name="pbc">The binding context used during reduction; may be null.</param>
	/// <param name="dwReduceHowFar">The requested reduction depth indicating how far the moniker should be reduced.</param>
	/// <param name="ppmkToLeft">On return, receives the left-side moniker portion that was removed during reduction; may be null.</param>
	/// <returns>A moniker representing the reduced portion of this moniker.</returns>
	IMoniker Reduce(IBindCtx pbc, int dwReduceHowFar, ref IMoniker? ppmkToLeft);

	/// <summary>
	/// Creates a moniker that represents this moniker followed by the specified right-hand moniker.
	/// </summary>
	/// <param name="pmkRight">The moniker to append to the right of this moniker.</param>
	/// <param name="fOnlyIfNotGeneric">If `true`, perform the composition only when it does not involve generic monikers; if `false`, always compose.</param>
	/// <returns>A moniker representing the composition of this moniker with <paramref name="pmkRight"/>.</returns>
	IMoniker ComposeWith(IMoniker pmkRight, [MarshalAs(UnmanagedType.Bool)] bool fOnlyIfNotGeneric);

	/// <summary>
	/// Retrieves an enumerator that iterates the monikers in the specified direction.
	/// </summary>
	/// <param name="fForward">`true` to enumerate monikers in forward order; `false` to enumerate them in reverse order.</param>
	/// <returns>An <see cref="IEnumMoniker"/> that enumerates the monikers in the requested direction.</returns>
	IEnumMoniker Enum([MarshalAs(UnmanagedType.Bool)] bool fForward);

	/// <summary>
	/// Compares this moniker with another moniker to determine whether they identify the same object.
	/// </summary>
	/// <param name="pmkOtherMoniker">The moniker to compare against this instance.</param>
	/// <returns>`S_OK` if the monikers are equal, `S_FALSE` if they are not equal, or an HRESULT error code on failure.</returns>
	[PreserveSig]
	int IsEqual(IMoniker pmkOtherMoniker);

	/// <summary>
	/// Invokes the moniker's hash operation.
	/// </summary>
	/// <returns>`int` HRESULT-style result code: `S_OK` on success, other HRESULT codes on failure.</returns>
	[PreserveSig]
	int Hash();

	/// <summary>
	/// Determines whether the object identified by this moniker is currently running.
	/// </summary>
	/// <param name="pbc">Optional binding context used for the query; may be null.</param>
	/// <param name="pmkToLeft">Optional moniker that precedes this moniker in a composite bind; may be null.</param>
	/// <param name="pmkNewlyRunning">Optional moniker to receive a newly running object associated with this moniker; may be null.</param>
	/// <returns>`S_OK` if the object's target is running, or a COM error `HRESULT` otherwise.</returns>
	[PreserveSig]
	int IsRunning(IBindCtx pbc, IMoniker? pmkToLeft, IMoniker? pmkNewlyRunning);

	/// <summary>
	/// Gets the timestamp of the last change for the object identified by this moniker within the given binding context.
	/// </summary>
	/// <param name="pbc">The binding context used to obtain state information for the lookup; may be null.</param>
	/// <param name="pmkToLeft">An optional moniker that binds to the object to the left of this moniker in a composite moniker; may be null.</param>
	/// <returns>A <see cref="FILETIME"/> structure representing when the object's state was last changed.</returns>
	FILETIME GetTimeOfLastChange(IBindCtx pbc, IMoniker? pmkToLeft);

	/// <summary>
	/// Gets a moniker that represents the inverse of this moniker.
	/// </summary>
	/// <returns>An IMoniker representing the inverse of this moniker.</returns>
	IMoniker Inverse();

	/// <summary>
	/// Gets the longest common prefix moniker shared by this moniker and the specified moniker.
	/// </summary>
	/// <param name="pmkOther">The moniker to compare against.</param>
	/// <returns>The moniker that represents the longest common prefix of the two monikers.</returns>
	IMoniker CommonPrefixWith(IMoniker pmkOther);

	/// <summary>
	/// Computes a moniker that denotes the relative path from this moniker to another moniker.
	/// </summary>
	/// <param name="pmkOther">The target moniker to which a relative path is computed.</param>
	/// <returns>A moniker that denotes the relative path from this moniker to <paramref name="pmkOther"/>.</returns>
	IMoniker RelativePathTo(IMoniker pmkOther);

	/// <summary>
	/// Retrieves the display name that identifies this moniker.
	/// </summary>
	/// <param name="pbc">The bind context used to assist name resolution; may be null.</param>
	/// <param name="pmkToLeft">An optional moniker that provides left-side context for forming the display name; pass null if there is no left moniker.</param>
	/// <returns>The display name of the moniker.</returns>
	string GetDisplayName(IBindCtx pbc, IMoniker? pmkToLeft);

	/// <summary>
	/// Parses a display name and returns a moniker that identifies the named object.
	/// </summary>
	/// <param name="pbc">The binding context used during parsing.</param>
	/// <param name="pmkToLeft">An optional moniker that provides left-side context for relative names.</param>
	/// <param name="pszDisplayName">The display name to parse.</param>
	/// <param name="pchEaten">When the method returns, the number of characters from <paramref name="pszDisplayName"/> that were consumed.</param>
	/// <returns>A moniker representing the object described by the parsed portion of <paramref name="pszDisplayName"/>.</returns>
	IMoniker ParseDisplayName(IBindCtx pbc, IMoniker? pmkToLeft, string pszDisplayName, out int pchEaten);

	/// <summary>
	/// Indicates whether this moniker is a system moniker and provides its system type.
	/// </summary>
	/// <param name="pdwMksys">Receives the system moniker type value when the call succeeds.</param>
	/// <returns>HRESULT value indicating success or failure; on success `pdwMksys` is set to the matching `MKSYS` value.</returns>
	[PreserveSig]
	int IsSystemMoniker(out MKSYS pdwMksys);
}

public static class IMonikerExtensions
{
	/// <summary>
	/// Reduces the moniker, allowing the caller to provide or receive the left-side moniker used in reduction.
	/// </summary>
	/// <param name="pbc">Binding context used during reduction.</param>
	/// <param name="dwReduceHowFar">Specifies how far to reduce the moniker.</param>
	/// <param name="monikerToLeft">On input, an optional left-side moniker; on output, receives the left-side moniker resulting from reduction.</param>
	/// <returns>The reduced moniker.</returns>
	extension(IMoniker moniker)
	{
		public IMoniker Reduce(IBindCtx pbc, int dwReduceHowFar)
		{
			IMoniker? toLeft = null;
			return moniker.Reduce(pbc, dwReduceHowFar, ref toLeft);
		}

		public IMoniker Reduce(IBindCtx pbc, int dwReduceHowFar, ref IMoniker? monikerToLeft)
		{
			return moniker.Reduce(pbc, dwReduceHowFar, ref monikerToLeft);
		}
	}
}
