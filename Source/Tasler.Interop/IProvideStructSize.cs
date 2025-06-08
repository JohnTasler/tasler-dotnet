using System.Runtime.CompilerServices;

namespace Tasler.Interop;

public interface IProvideStructSize<TSelf> where TSelf : unmanaged, IProvideStructSize<TSelf>
{
	static sealed int SizeOf
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get { unsafe { return sizeof(TSelf); } }
	}
}

public static class IProvideStructSizeExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetSizeOf<T>(this T self)
		where T : unmanaged, IProvideStructSize<T>
	{
		return IProvideStructSize<T>.SizeOf;
	}
}
