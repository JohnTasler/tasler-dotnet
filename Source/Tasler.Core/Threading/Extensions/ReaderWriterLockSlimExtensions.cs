using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Tasler.Threading;

public static class ReaderWriterLockSlimExtensions
{
	#region Extension Methods

	public static IDisposable GetReadLock(this ReaderWriterLockSlim @this)
	{
		ValidateArgument.IsNotNull(@this, nameof(@this));

		Debug.WriteLineIf(IsLogging, GetCallingFrameInfo("Entering GetReadLock"));
		@this.EnterReadLock();
		return new AutoExitRead(@this);
	}

	public static IDisposable GetUpgradeableReadLock(this ReaderWriterLockSlim @this)
	{
		ValidateArgument.IsNotNull(@this, nameof(@this));

		Debug.WriteLineIf(IsLogging, GetCallingFrameInfo("Entering GetUpgradeableLock"));
		@this.EnterUpgradeableReadLock();
		return new AutoExitUpgradeableRead(@this);
	}

	public static IDisposable GetWriteLock(this ReaderWriterLockSlim @this)
	{
		ValidateArgument.IsNotNull(@this, nameof(@this));

		Debug.WriteLineIf(IsLogging, GetCallingFrameInfo("Entering GetWriteLock"));
		@this.EnterWriteLock();
		return new AutoExitWrite(@this);
	}

	#endregion Extension Methods

	#region Diagnostics

	private const bool IsLogging = false;

	internal static string GetCallingFrameInfo(string middleText)
	{
		StackFrame frame = new StackTrace(2, true).GetFrame(0)!;
		return string.Format(
			"{0}.{1}: {2}\n{3}({4}, {5})",
			frame.GetMethod()?.DeclaringType?.Name, frame.GetMethod()?.Name, middleText,
			frame.GetFileName(), frame.GetFileLineNumber(), frame.GetFileColumnNumber());
	}

	#endregion Diagnostics

	#region Nested Types

	[StructLayout(LayoutKind.Sequential)]
	private struct AutoExitRead : IDisposable
	{
		private ReaderWriterLockSlim _readerWriterLockSlim;
		public AutoExitRead(ReaderWriterLockSlim readerWriterLockSlim)
		{
			_readerWriterLockSlim = readerWriterLockSlim;
		}

		public void Dispose()
		{
			Debug.WriteLineIf(IsLogging, ReaderWriterLockSlimExtensions.GetCallingFrameInfo("Exiting ReadLock"));
			_readerWriterLockSlim.ExitReadLock();
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	private struct AutoExitUpgradeableRead : IDisposable
	{
		private ReaderWriterLockSlim _readerWriterLockSlim;
		public AutoExitUpgradeableRead(ReaderWriterLockSlim readerWriterLockSlim)
		{
			_readerWriterLockSlim = readerWriterLockSlim;
		}

		public void Dispose()
		{
			_readerWriterLockSlim.ExitUpgradeableReadLock();
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	private struct AutoExitWrite : IDisposable
	{
		private ReaderWriterLockSlim _readerWriterLockSlim;
		public AutoExitWrite(ReaderWriterLockSlim rwLock)
		{
			_readerWriterLockSlim = rwLock;
		}

		public void Dispose()
		{
			Debug.WriteLineIf(IsLogging, ReaderWriterLockSlimExtensions.GetCallingFrameInfo("Exiting WriteLock"));
			_readerWriterLockSlim.ExitWriteLock();
		}
	}

	#endregion Nested Types
}
