using System.ComponentModel;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Tasler.Interop.Extensions;

public static class ReturnValueExtensions
{
	public static T ReturnOrThrow<T>(this T result, Func<T, bool> isInvalidFunc)
		where T : unmanaged, INumberBase<T>
	{
		if (isInvalidFunc(result) && Marshal.GetLastPInvokeError() != 0)
			throw new Win32Exception();
		return result;
	}

	public static T ReturnOrThrow<T>(this T result, T invalidValue = default)
		where T : unmanaged, INumberBase<T>
	{
		if (invalidValue == default)
			invalidValue = T.Zero;
		if (result.Equals(T.Zero) && Marshal.GetLastPInvokeError() != 0)
			throw new Win32Exception();
		return result;
	}

	public static T ReturnOrThrow<T>(this T result)
		where T : SafeHandle
	{
		if (result.IsInvalid && Marshal.GetLastPInvokeError() != 0)
			throw new Win32Exception();
		return result;
	}

	/// <summary>
	///   Throws the last P/Invoke error if <paramref name="result"/> is <see langword="false"/>.
	/// </summary>
	/// <param name="result">The result of the interop call to be tested.</param>
	/// <returns>
	///   <see langword="true"/>, since otherwise it would throw <see cref="Win32Exception"/>.
	/// </returns>
	/// <exception cref="Win32Exception">
	///   The specified <paramref name="result"/> is <see langword="false"/>
	/// </exception>
	public static bool ReturnOrThrow(this bool result)
	{
		if (!result && Marshal.GetLastPInvokeError() != 0)
			throw new Win32Exception();
		return result;
	}

	public static HRESULT ReturnOrThrow(this HRESULT result)
	{
		if (result < 0)
			Marshal.ThrowExceptionForHR(result);
		return result;
	}
}
