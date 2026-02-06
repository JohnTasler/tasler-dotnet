using System.Runtime.InteropServices;
using System.Text;
using Tasler.Buffers;
using Tasler.Extensions;

namespace Tasler.Interop.Shell;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct StrRet : IDisposable
{
	#region Instance Fields
	private STRRET_TYPE _type;
	private unsafe fixed byte _cStr[260];
	#endregion Instance Fields

	#region IDisposable Members
	/// <summary>
	/// Releases unmanaged memory held when the instance represents a wide-character string and clears its stored pointer.
	/// </summary>
	/// <remarks>
	/// If the stored wide-string pointer is null, the method does nothing. When the instance's type is <c>WStr</c>, the method frees the unmanaged memory returned by the shell and zeroes the pointer slot in the internal buffer.
	/// </remarks>
	public void Dispose()
	{
		if (this.GetWStr() == nint.Zero)
			return;

		if (_type == STRRET_TYPE.WStr)
		{
			Marshal.FreeCoTaskMem(this.GetWStr());
			unsafe
			{
				fixed (byte* ptr = _cStr)
				{
					BitConverter.TryWriteBytes(new Span<byte>(ptr, sizeof(nint)), 0);
				}
			}
		}
	}
	#endregion IDisposable Members

	#region Properties
	public readonly string? Value
	{
		get
		{
			if (this.GetWStr() != nint.Zero)
			{
				switch (_type)
				{
					case STRRET_TYPE.WStr:
					{
						return Marshal.PtrToStringUni(this.GetWStr()) ?? string.Empty;
					}
					case STRRET_TYPE.CStr:
					{
						unsafe
						{
							fixed (byte* strPointer = _cStr)
							{
								var stringSpan = new ReadOnlySpan<byte>(strPointer, 260);
								var length = stringSpan.IndexOf((byte)0);
								var decoder = Encoding.UTF8.GetDecoder();
								var characterCount = decoder.GetCharCount(strPointer, length, true);
								using (var characters = new SharedArrayPoolRenter<char>(characterCount))
								{
									decoder.GetChars(stringSpan, characters.Data, true);
									return new(characters.Data);
								}
							}
						}
					}
				}
			}

			return null;
		}
	}
	#endregion Properties

	#region Methods
	/// <summary>
	/// Resolve the stored shell string to a managed string using the provided ItemIdList.
	/// </summary>
	/// <param name="itemIdList">The ItemIdList whose PIDL value is used to resolve offset-based STRRET values.</param>
	/// <returns>The resolved string for this STRRET; returns an empty string when no value is available.</returns>
	public readonly string GetValue(ItemIdList itemIdList)
	{
		return this.GetValue(itemIdList.Value);
	}

	/// <summary>
	/// Gets the string representation for the specified child item id list.
	/// </summary>
	/// <param name="childItemIdList">The child item id list whose PIDL is used to resolve the returned string.</param>
	/// <returns>The resolved string for the child item; empty string if no value is available.</returns>
	public readonly string GetValue(ChildItemIdList childItemIdList)
	{
		return this.GetValue(childItemIdList.Value);
	}
	#endregion Methods

	#region Private Implementation
	/// <summary>
	/// Reads the native pointer value stored at the start of the internal fixed `_cStr` buffer.
	/// </summary>
	/// <returns>The pointer value contained in the first pointer-sized bytes of `_cStr`; `nint.Zero` if those bytes are zero.</returns>
	private readonly nint GetWStr()
	{
		unsafe
		{
			fixed (byte* pointer = _cStr)
			{
				return (nint)BitConverter.ToInt64(new ReadOnlySpan<byte>(pointer, nint.Size));
			}
		}
	}

	/// <summary>
	/// Resolve an Offset-type STRRET against the given PIDL and return the referenced ANSI string.
	/// </summary>
	/// <param name="pidl">Pointer to the start of the item ID list (PIDL) used when the STRRET type is Offset.</param>
	/// <returns>The ANSI string located at (pidl + offset) when the STRRET type is Offset; otherwise the struct's Value or an empty string.</returns>
	private readonly string GetValue(nint pidl)
	{
		if (_type != STRRET_TYPE.Offset)
			return this.Value ?? string.Empty;

		unsafe
		{
			fixed (byte* ptr = _cStr)
			{
				uint offset = BitConverter.ToUInt32(new ReadOnlySpan<byte>(ptr, sizeof(uint)));
				return Marshal.PtrToStringAnsi(new nint(pidl + offset))!;
			}
		}
	}
	#endregion Private Implementation

	#region Nested Types
	private enum STRRET_TYPE
	{
		WStr = 0,
		Offset = 0x1,
		CStr = 0x2
	}
	#endregion Nested Types
}
