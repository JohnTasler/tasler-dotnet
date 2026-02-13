using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Tasler.Diagnostics;

[DebuggerStepThrough]
public static class Diagnostic
{
	#region DEBUG

	[Conditional("DEBUG")]
	public static void DebugWritePropertyGetMessage<T>(this T @this, string? message = null, [CallerMemberName] string? methodName = null)
	{
		DebugWritePropertyGetMessage<T>(message, methodName);
	}

	[Conditional("DEBUG")]
	public static void DebugWritePropertySetMessage<T>(this T @this, string? message = null, [CallerMemberName] string? methodName = null)
	{
		DebugWritePropertySetMessage<T>(message, methodName);
	}

	[Conditional("DEBUG")]
	public static void DebugWriteItemPropertyGetMessage<T, Index>(this T @this, Index index, string? message = null)
	{
		DebugWriteItemPropertyGetMessage<T, Index>(index, message);
	}

	[Conditional("DEBUG")]
	public static void DebugWriteItemPropertySetMessage<T, Index>(this T @this, Index index, string? message = null, [CallerMemberName] string? methodName = null)
	{
		DebugWriteItemPropertySetMessage<T, Index>(index, message);
	}

	[Conditional("DEBUG")]
	public static void DebugWriteMethodMessage<T>(this T @this, string? message = null, [CallerMemberName] string? methodName = null)
	{
		DebugWriteMethodMessage<T>(message, methodName);
	}

	[Conditional("DEBUG")]
	public static void DebugWritePropertyGetMessage<T>(string? message = null, [CallerMemberName] string? methodName = null)
	{
		DebugWriteMethodMessage<T>(message, $"get_{methodName}");
	}

	[Conditional("DEBUG")]
	public static void DebugWritePropertySetMessage<T>(string? message = null, [CallerMemberName] string? methodName = null)
	{
		DebugWriteMethodMessage<T>(message, $"set_{methodName}");
	}

	[Conditional("DEBUG")]
	public static void DebugWriteItemPropertyGetMessage<T, Index>(Index index, string? message = null)
	{
		DebugWriteMethodMessage<T>(message, $"get_Item[{index}]");
	}

	[Conditional("DEBUG")]
	public static void DebugWriteItemPropertySetMessage<T, Index>(Index index, string? message = null, [CallerMemberName] string? methodName = null)
	{
		DebugWriteMethodMessage<T>(message, $"set_Item[{index}]");
	}

	[Conditional("DEBUG")]
	public static void DebugWriteMethodMessage<T>(string? message = null, [CallerMemberName] string? methodName = null)
	{
		DebugWriteLine($"{typeof(T).Name}.{methodName}: {message}");
	}

	[Conditional("DEBUG")]
	private static void DebugWriteLine(string? text)
	{
		if (Debugger.IsAttached)
		{
			Debug.WriteLine(text);
		}
	}

	#endregion DEBUG

	#region TRACE

	[Conditional("TRACE")]
	public static void TraceWritePropertyGetMessage<T>(this T @this, string? message = null, [CallerMemberName] string? methodName = null)
	{
		TraceWritePropertyGetMessage<T>(message, methodName);
	}

	[Conditional("TRACE")]
	public static void TraceWritePropertySetMessage<T>(this T @this, string? message = null, [CallerMemberName] string? methodName = null)
	{
		TraceWritePropertySetMessage<T>(message, methodName);
	}

	[Conditional("TRACE")]
	public static void TraceWriteItemPropertyGetMessage<T, Index>(this T @this, Index index, string? message = null)
	{
		TraceWriteItemPropertyGetMessage<T, Index>(index, message);
	}

	[Conditional("TRACE")]
	public static void TraceWriteItemPropertySetMessage<T, Index>(this T @this, Index index, string? message = null, [CallerMemberName] string? methodName = null)
	{
		TraceWriteItemPropertySetMessage<T, Index>(index, message);
	}

	[Conditional("TRACE")]
	public static void TraceWriteMethodMessage<T>(this T @this, string? message = null, [CallerMemberName] string? methodName = null)
	{
		TraceWriteMethodMessage<T>(message, methodName);
	}

	[Conditional("TRACE")]
	public static void TraceWritePropertyGetMessage<T>(string? message = null, [CallerMemberName] string? methodName = null)
	{
		TraceWriteMethodMessage<T>(message, $"get_{methodName}");
	}

	[Conditional("TRACE")]
	public static void TraceWritePropertySetMessage<T>(string? message = null, [CallerMemberName] string? methodName = null)
	{
		TraceWriteMethodMessage<T>(message, $"set_{methodName}");
	}

	[Conditional("TRACE")]
	public static void TraceWriteItemPropertyGetMessage<T, Index>(Index index, string? message = null)
	{
		TraceWriteMethodMessage<T>(message, $"get_Item[{index}]");
	}

	[Conditional("TRACE")]
	public static void TraceWriteItemPropertySetMessage<T, Index>(Index index, string? message = null, [CallerMemberName] string? methodName = null)
	{
		TraceWriteMethodMessage<T>(message, $"set_Item[{index}]");
	}

	[Conditional("TRACE")]
	public static void TraceWriteMethodMessage<T>(string? message = null, [CallerMemberName] string? methodName = null)
	{
		TraceWriteLine($"{typeof(T).Name}.{methodName}: {message}");
	}

	[Conditional("TRACE")]
	private static void TraceWriteLine(string text)
	{
		Trace.WriteLine(text);
	}

	#endregion TRACE

	/// <summary>
	/// Converts an object to a <see cref="string"/> useful for logging.
	/// </summary>
	/// <param name="this"></param>
	/// <returns>
	/// This extension method returns one of three type of strings:
	/// <list type="table">
	///		<listheader>
	///			<term>Value of <paramref name="this"/></term>
	///			<description>Method result</description>
	///		</listheader>
	///		<item>
	///			<term><see langword="null"/></term>
	///			<description>The string, "&lt;null&gt;".</description>
	///		</item>
	///		<item>
	///			<term>
	///			Non-<see langword="null"/> and <see cref="object.ToString"/> returns a string that
	///			contains the object's <see cref="Type.Name"/>, usually indicating the default
	///			<see cref="object.ToString"/>.
	///			</term>
	///			<description>
	///			"Address=0123456789ABCDEF &lt;non-null&gt;"
	///			where 0123456789ABCDEF is the hex address of the object.
	///			</descripton>
	///		</item>
	///		<item>
	///			<term>
	///			non-<see langword="null"/> and <see cref="object.ToString"/> returns a string that
	///			does <b>not</b> contain the object's <see cref="Type.Name"/>.
	///			</term>
	///			<description>
	///			"Address=0123456789ABCDEF (return value from <see cref="this.ToString"/>)"
	///			where 0123456789ABCDEF is the hex address of the object.
	///			</description>
	///		</item>
	/// </list>
	/// </returns>
	public static string NullOrNonNull(this object? @this)
	{
		if (@this is null)
			return Properties.Resources.NullOrNonNull_Null;

		var asString = @this.ToString();
		if (asString is not null && asString.Contains(@this.GetType().Name))
			asString = Properties.Resources.NullOrNonNull_NonNull;

		nint address = nint.Zero;
		unsafe
		{
			#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
			address = (nint)(&@this);
			#pragma warning restore CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
		}
		return $"{Properties.Resources.NullOrNonNull_AddressEquals}{address} {asString}";
	}

	/// <summary>
	/// Gets the name of the member from which it was called.
	/// </summary>
	/// <param name="memberName">
	/// The name of the calling member. This should be <see langword="null"/> or not specified , so
	/// that the compiler will generate the name string.
	/// </param>
	/// <returns>
	/// Returns the name of the calling member.
	/// </returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string? GetMemberName([CallerMemberName] string? memberName = null) => memberName;
}
