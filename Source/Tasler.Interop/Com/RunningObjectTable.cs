using System.Collections;
using System.Runtime.InteropServices;
using Tasler.Interop.Com.Extensions;

namespace Tasler.Interop.Com;

public class RunningObjectTable : IDisposable, IEnumerable<IMoniker?>
{
	#region Instance Fields
	private IRunningObjectTable? _rot;
	#endregion Instance Fields

	public RunningObjectTable()
	{
		_rot = ComApi.GetRunningObjectTable();
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
		var rot = Interlocked.Exchange(ref _rot, null);
		if (rot is not null)
		{
			rot.Release();
			GC.SuppressFinalize(this);
		}
	}

	#endregion IDisposable Members

	#region IEnumerable<IMoniker> Members

	public IEnumerator<IMoniker?> GetEnumerator()
	{
		var enumMoniker = _rot?.EnumRunning();
		var enumerable = enumMoniker is not null
			? enumMoniker.AsEnumerable()
			: ((IEnumerable<IMoniker?>)[]);

		return enumerable.GetEnumerator();
	}

	#endregion IEnumerable<IMoniker> Members

	#region IEnumerable Members

	IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

	#endregion IEnumerable Members

	public T? GetObject<T>(IMoniker moniker)
		where T : class
	{
		var rot = _rot;
		if (rot is not null)
		{
			rot.GetObject(moniker, out nint runningObjectPtr);

			object runningObject = ComApi.Wrappers.GetOrCreateObjectForComInstance(runningObjectPtr, CreateObjectFlags.Unwrap);
			if (runningObject is T result)
			{
				return result;
			}

			Marshal.Release(runningObjectPtr);
		}

		return null;
	}
}
