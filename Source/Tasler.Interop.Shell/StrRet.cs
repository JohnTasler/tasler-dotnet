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
	public readonly string GetValue(ItemIdList itemIdList)
	{
		return this.GetValue(itemIdList.Value);
	}

	public readonly string GetValue(ChildItemIdList childItemIdList)
	{
		return this.GetValue(childItemIdList.Value);
	}
	#endregion Methods

	#region Private Implementation
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
