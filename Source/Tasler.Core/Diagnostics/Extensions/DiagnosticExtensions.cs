using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Tasler.Diagnostics
{
	public static class DiagnosticExtensions
	{
		#region DEBUG

		[Conditional("DEBUG")]
		public static void DebugWritePropertyGetMessage<T>(this T @this, string message = null, [CallerMemberName] string methodName = null)
		{
			DebugWritePropertyGetMessage<T>(message, methodName);
		}

		[Conditional("DEBUG")]
		public static void DebugWritePropertySetMessage<T>(this T @this, string message = null, [CallerMemberName] string methodName = null)
		{
			DebugWritePropertySetMessage<T>(message, methodName);
		}

		[Conditional("DEBUG")]
		public static void DebugWriteItemPropertyGetMessage<T, Index>(this T @this, Index index, string message = null)
		{
			DebugWriteItemPropertyGetMessage<T, Index>(index, message);
		}

		[Conditional("DEBUG")]
		public static void DebugWriteItemPropertySetMessage<T, Index>(this T @this, Index index, string message = null, [CallerMemberName] string methodName = null)
		{
			DebugWriteItemPropertySetMessage<T, Index>(index, message);
		}

		[Conditional("DEBUG")]
		public static void DebugWriteMethodMessage<T>(this T @this, string message = null, [CallerMemberName] string methodName = null)
		{
			DebugWriteMethodMessage<T>(message, methodName);
		}

		[Conditional("DEBUG")]
		public static void DebugWritePropertyGetMessage<T>(string message = null, [CallerMemberName] string methodName = null)
		{
			DebugWriteMethodMessage<T>(message, $"get_{methodName}");
		}

		[Conditional("DEBUG")]
		public static void DebugWritePropertySetMessage<T>(string message = null, [CallerMemberName] string methodName = null)
		{
			DebugWriteMethodMessage<T>(message, $"set_{methodName}");
		}

		[Conditional("DEBUG")]
		public static void DebugWriteItemPropertyGetMessage<T, Index>(Index index, string message = null)
		{
			DebugWriteMethodMessage<T>(message, $"get_Item[{index}]");
		}

		[Conditional("DEBUG")]
		public static void DebugWriteItemPropertySetMessage<T, Index>(Index index, string message = null, [CallerMemberName] string methodName = null)
		{
			DebugWriteMethodMessage<T>(message, $"set_Item[{index}]");
		}

		[Conditional("DEBUG")]
		public static void DebugWriteMethodMessage<T>(string message = null, [CallerMemberName] string methodName = null)
		{
			DebugWriteLine($"{typeof(T).Name}.{methodName}: {message}");
		}

		[Conditional("DEBUG")]
		private static void DebugWriteLine(string text)
		{
			if (Debugger.IsAttached)
			{
				Debug.WriteLine(text);
			}
		}

		#endregion DEBUG

		#region TRACE

		[Conditional("TRACE")]
		public static void TraceWritePropertyGetMessage<T>(this T @this, string message = null, [CallerMemberName] string methodName = null)
		{
			TraceWritePropertyGetMessage<T>(message, methodName);
		}

		[Conditional("TRACE")]
		public static void TraceWritePropertySetMessage<T>(this T @this, string message = null, [CallerMemberName] string methodName = null)
		{
			TraceWritePropertySetMessage<T>(message, methodName);
		}

		[Conditional("TRACE")]
		public static void TraceWriteItemPropertyGetMessage<T, Index>(this T @this, Index index, string message = null)
		{
			TraceWriteItemPropertyGetMessage<T, Index>(index, message);
		}

		[Conditional("TRACE")]
		public static void TraceWriteItemPropertySetMessage<T, Index>(this T @this, Index index, string message = null, [CallerMemberName] string methodName = null)
		{
			TraceWriteItemPropertySetMessage<T, Index>(index, message);
		}

		[Conditional("TRACE")]
		public static void TraceWriteMethodMessage<T>(this T @this, string message = null, [CallerMemberName] string methodName = null)
		{
			TraceWriteMethodMessage<T>(message, methodName);
		}

		[Conditional("TRACE")]
		public static void TraceWritePropertyGetMessage<T>(string message = null, [CallerMemberName] string methodName = null)
		{
			TraceWriteMethodMessage<T>(message, $"get_{methodName}");
		}

		[Conditional("TRACE")]
		public static void TraceWritePropertySetMessage<T>(string message = null, [CallerMemberName] string methodName = null)
		{
			TraceWriteMethodMessage<T>(message, $"set_{methodName}");
		}

		[Conditional("TRACE")]
		public static void TraceWriteItemPropertyGetMessage<T, Index>(Index index, string message = null)
		{
			TraceWriteMethodMessage<T>(message, $"get_Item[{index}]");
		}

		[Conditional("TRACE")]
		public static void TraceWriteItemPropertySetMessage<T, Index>(Index index, string message = null, [CallerMemberName] string methodName = null)
		{
			TraceWriteMethodMessage<T>(message, $"set_Item[{index}]");
		}

		[Conditional("TRACE")]
		public static void TraceWriteMethodMessage<T>(string message = null, [CallerMemberName] string methodName = null)
		{
			TraceWriteLine($"{typeof(T).Name}.{methodName}: {message}");
		}

		[Conditional("TRACE")]
		private static void TraceWriteLine(string text)
		{
			Trace.WriteLine(text);
		}

		#endregion TRACE

		public static string NullOrNonNull(this object @this)
		{
			if (@this == null)
				return "<null>";

			var asString = @this.ToString();
			if (asString == @this.GetType().FullName)
				asString = "<non-null";
			return $"HashCode={@this.GetHashCode()} {asString}";
		}
	}
}
