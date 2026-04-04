using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com;

namespace Tasler.Interop.Shell;

public static class Guids
{
	public const string IID_IEnumACString = "8E74C210-CF9D-4eaf-A403-7356428F0A5A";
	public static Guid Guid_IEnumACString => new(IID_IEnumACString);
}

public enum AutoCompleteOption : uint
{
	None            = 0x0000, // No options
	MostRecentFirst = 0x0001, // Display most recently used items first
	FirstUnused     = 0x10000,// 0x00010000 through 0xffff0000 are for enumerator specific options (0x0002-0xffff are reserved)
}

[Guid(Guids.IID_IEnumACString)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IEnumACString : IEnumString
{
	/// <summary>
	/// Retrieves the next auto-complete string into the provided buffer.
	/// </summary>
	/// <param name="pszUr">Buffer that receives the next item string.</param>
	/// <param name="cchMax">Maximum number of characters the buffer can hold, including the terminating null if applicable.</param>
	/// <param name="pulSortIndex">Receives the sort index associated with the returned item.</param>
	/// <returns>An HRESULT indicating success, that no more items are available, or an error code.</returns>
	[PreserveSig]
	int NextItem(
		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I2, SizeParamIndex = 1)]
		[Out] char[] pszUrl,
		uint cchMax,
		out uint pulSortIndex);

	/// <summary>
	/// Sets the enumeration options that control how auto-complete strings are produced and filtered.
	/// </summary>
	/// <param name="dwOptions">Flags specifying the auto-complete enumeration behavior to apply.</param>
	void SetEnumOptions(AutoCompleteOption dwOptions);

	/// <summary>
	/// Gets the options currently applied to auto-complete string enumeration.
	/// </summary>
	/// <returns>The current <see cref="AutoCompleteOption"/> flags controlling enumeration behavior.</returns>
	AutoCompleteOption GetEnumOptions();
}

