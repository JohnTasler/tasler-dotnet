using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Tasler.Interop.Com;

public class RunningObjectTable : IDisposable, IEnumerable<IMoniker>
{
	#region Instance Fields
	private nint _rotHandle;
	private IRunningObjectTable _rot;
	#endregion Instance Fields

	public RunningObjectTable()
	{
		_rot = ComApi.GetRunningObjectTable(out _rotHandle);
	}

	#region Finalizer
	~RunningObjectTable()
	{
		this.Dispose();
	}
	#endregion Finalizer

	#region IDisposable Members
	public void Dispose()
	{
		var rot = Interlocked.Exchange(ref _rot, null!);
		if (rot is not null)
		{
			var rotHandle = Interlocked.Exchange(ref _rotHandle, nint.Zero);
			Debug.Assert(rotHandle != nint.Zero);
			Marshal.Release(rotHandle);
			GC.SuppressFinalize(this);
		}
		else
		{
			#if DEBUG
			var rotHandle = Interlocked.Exchange(ref _rotHandle, nint.Zero);
			Debug.Assert(rotHandle == nint.Zero);
			#endif
		}
	}

	#endregion IDisposable Members

	#region IEnumerable<IMoniker> Members

	public IEnumerator<IMoniker> GetEnumerator()
	{
		var enumMoniker = _rot.EnumRunning();
		return enumMoniker.AsEnumerable<IEnumMoniker, IMoniker>(ComEnumeratorExtensions.FetchIMoniker).GetEnumerator() ?? throw new COMException();
	}

	#endregion IEnumerable<IMoniker> Members

	#region IEnumerable Members

	IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

	#endregion IEnumerable Members

	public T? GetObject<T>(IMoniker moniker)
		where T : class
	{
		object? runningObject = null;
		_rot?.GetObject(moniker, out runningObject);

		if (runningObject is T result)
		{
			Marshal.ReleaseComObject(runningObject);
			return result;
		}

		return null;
	}
}
