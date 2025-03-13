using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Tasler.Threading;

public class ReaderWriterLockSlimWrapper : IDisposable
{
	private const bool _isLogging = false;

	internal static string GetCallingFrameInfo(string middleText)
	{
		StackFrame frame = new StackTrace(2, true).GetFrame(0)!;
		return string.Format(
			"{0}.{1}: {2}\n{3}({4}, {5})",
			frame.GetMethod()!.DeclaringType!.Name, frame.GetMethod()!.Name, middleText,
			frame.GetFileName(), frame.GetFileLineNumber(), frame.GetFileColumnNumber());
	}

	#region Instance Fields
	private AutoExitRead autoExitRead;
	private AutoExitUpgradeableRead autoExitUpgradeableRead;
	private AutoExitWrite autoExitWrite;
	private ReaderWriterLockSlim? readerWriterLockSlim;
	#endregion Instance Fields

	#region Construction
	public ReaderWriterLockSlimWrapper()
			: this(new ReaderWriterLockSlim())
	{
	}

	public ReaderWriterLockSlimWrapper(ReaderWriterLockSlim readerWriterLockSlim)
	{
		this.readerWriterLockSlim = readerWriterLockSlim;
		this.autoExitWrite = new AutoExitWrite(this.readerWriterLockSlim);
		this.autoExitUpgradeableRead = new AutoExitUpgradeableRead(this.readerWriterLockSlim);
		this.autoExitRead = new AutoExitRead(this.readerWriterLockSlim);
	}
	#endregion Construction

	#region Properties

	[DebuggerDisplay("")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public IDisposable ReadLock
	{
		get
		{
			if (this.readerWriterLockSlim is null)
				throw new ObjectDisposedException(nameof(ReaderWriterLockSlim));

			Debug.WriteLineIf(_isLogging, GetCallingFrameInfo("Entering ReadLock"));
			this.readerWriterLockSlim.EnterReadLock();
			return this.autoExitRead;
		}
	}

	[DebuggerDisplay("")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public IDisposable UpgradeableReadLock
	{
		get
		{
			if (this.readerWriterLockSlim is null)
				throw new ObjectDisposedException(nameof(ReaderWriterLockSlim));

			this.readerWriterLockSlim.EnterUpgradeableReadLock();
			return this.autoExitUpgradeableRead;
		}
	}

	[DebuggerDisplay("")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public IDisposable WriteLock
	{
		get
		{
			if (this.readerWriterLockSlim is null)
				throw new ObjectDisposedException(nameof(ReaderWriterLockSlim));

			Debug.WriteLineIf(_isLogging, GetCallingFrameInfo("Entering WriteLock"));
			this.readerWriterLockSlim.EnterWriteLock();
			return this.autoExitWrite;
		}
	}

	#endregion Properties

	#region IDisposable Members

	public void Dispose()
	{
		using (this.readerWriterLockSlim)
			this.readerWriterLockSlim = null;
	}

	#endregion IDisposable Members

	#region Nested Types

	[StructLayout(LayoutKind.Sequential)]
	private struct AutoExitRead : IDisposable
	{
		private ReaderWriterLockSlim readerWriterLockSlim;
		public AutoExitRead(ReaderWriterLockSlim readerWriterLockSlim)
		{
			this.readerWriterLockSlim = readerWriterLockSlim;
		}

		public void Dispose()
		{
			Debug.WriteLineIf(_isLogging, ReaderWriterLockSlimWrapper.GetCallingFrameInfo("Exiting ReadLock"));
			this.readerWriterLockSlim.ExitReadLock();
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	private struct AutoExitUpgradeableRead : IDisposable
	{
		private ReaderWriterLockSlim readerWriterLockSlim;
		public AutoExitUpgradeableRead(ReaderWriterLockSlim readerWriterLockSlim)
		{
			this.readerWriterLockSlim = readerWriterLockSlim;
		}

		public void Dispose()
		{
			this.readerWriterLockSlim.ExitUpgradeableReadLock();
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	private struct AutoExitWrite : IDisposable
	{
		private ReaderWriterLockSlim readerWriterLockSlim;
		public AutoExitWrite(ReaderWriterLockSlim rwLock)
		{
			this.readerWriterLockSlim = rwLock;
		}

		public void Dispose()
		{
			Debug.WriteLineIf(_isLogging, ReaderWriterLockSlimWrapper.GetCallingFrameInfo("Exiting WriteLock"));
			this.readerWriterLockSlim.ExitWriteLock();
		}
	}

	#endregion Nested Types
}
