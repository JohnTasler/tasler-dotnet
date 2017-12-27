using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Tasler.Interop.Com
{
	public class RunningObjectTable : IDisposable, IEnumerable<IMoniker>
	{
		#region Instance Fields
		private IRunningObjectTable rot = ComApi.GetRunningObjectTable();
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
			if (this.rot != null)
			{
				GC.SuppressFinalize(this);
				Marshal.ReleaseComObject(this.rot);
				this.rot = null;
			}
		}
		#endregion IDisposable Members

		#region IEnumerable<IMoniker> Members

		public IEnumerator<IMoniker> GetEnumerator()
		{
			var enumMoniker = new ComPtr<IEnumMoniker>();
			using (enumMoniker)
			{
				this.rot.EnumRunning(out enumMoniker.Value);

				var monikers = new IMoniker[1];
				int hr = 0;
				do
				{
					hr = enumMoniker.Value.Next(1, monikers, IntPtr.Zero);
					if (hr == 0)
						yield return monikers[0];
				} while (hr == 0);
			}
		}

		#endregion IEnumerable<IMoniker> Members

		#region IEnumerable Members

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#endregion IEnumerable Members

		public T GetObject<T>(IMoniker moniker)
			where T : class
		{
			object runningObject;
			this.rot.GetObject(moniker, out runningObject);
			T result = runningObject as T;
			if (result == null)
				Marshal.ReleaseComObject(runningObject);
			return result;
		}
	}
}
