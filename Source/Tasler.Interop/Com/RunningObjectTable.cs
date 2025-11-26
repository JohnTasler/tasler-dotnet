using System.Collections;
using System.Runtime.InteropServices;
using Tasler.Interop.Com.Extensions;

namespace Tasler.Interop.Com;

public class RunningObjectTable : IDisposable, IEnumerable<IMoniker?>
{
	#region Instance Fields
	private IRunningObjectTable? _rot;
	#endregion Instance Fields

	/// <summary>
	/// Initializes a new RunningObjectTable and acquires the system running object table.
	/// </summary>
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
	/// <summary>
	/// Releases the underlying running object table and suppresses the finalizer.
	/// </summary>
	/// <remarks>
	/// If a running object table instance is held, it is released and GC.SuppressFinalize is called; calling Dispose again is a no-op.
	/// </remarks>
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

	/// <summary>
	/// Enumerates the monikers currently registered in the running object table.
	/// </summary>
	/// <returns>An enumerator over the registered monikers; each element is an IMoniker or null.</returns>
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

	/// <summary>
/// Provides a non-generic enumerator for the running object table's monikers.
/// </summary>
/// <returns>An <see cref="IEnumerator"/> that iterates over the running object table's monikers (may yield null entries).</returns>
IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

	#endregion IEnumerable Members

	/// <summary>
	/// Retrieve the running COM object identified by the given moniker and return it as type T when available and compatible.
	/// </summary>
	/// <param name="moniker">The moniker that identifies the running COM object to retrieve.</param>
	/// <returns>`T` instance corresponding to the moniker if present and compatible; otherwise `null`. If a COM object is obtained but does not match `T`, its COM reference is released.</returns>
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