namespace Tasler.Extensions;

public static class UnmanagedExtensions
{
	public static int GetSize<T>() where T : unmanaged
	{
		unsafe
		{
			return sizeof(T);
		}
	}

	public static int GetSize<T>(this T value) where T : unmanaged
	{
		return GetSize<T>();
	}
}
