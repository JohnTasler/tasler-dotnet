using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Tasler.Interop.Com;

public class RunningObjectTable : IDisposable, IEnumerable<IMoniker>
{
	#region Instance Fields
	private IRunningObjectTable? _rot = ComApi.GetRunningObjectTable();
	#endregion Instance Fields

	#region Finalizer
	~RunningObjectTable()
	{
		this.Dispose();
	}
	#endregion Finalizer

	#region IDisposable Members
	public void Dispose()
	{
		if (_rot is not null)
		{
			GC.SuppressFinalize(this);
			Marshal.ReleaseComObject(_rot);
			_rot = null;
		}
	}
	#endregion IDisposable Members

	#region IEnumerable<IMoniker> Members

	public IEnumerator<IMoniker> GetEnumerator()
	{
		using (var enumMoniker = new ComPtr<IEnumMoniker>())
		{
			_rot?.EnumRunning(out enumMoniker.Value);
			return enumMoniker.Value?.AsEnumerator<IEnumMoniker, IMoniker>(ComEnumExtensions.FetchIMoniker) ?? throw new COMException();
		}
	}

	#endregion IEnumerable<IMoniker> Members

	#region IEnumerable Members

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

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
