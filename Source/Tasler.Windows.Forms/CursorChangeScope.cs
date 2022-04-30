using System;
using System.Windows.Forms;

namespace Tasler.Windows.Forms
{
	/// <summary>
	/// Summary description for CursorChangeScope.
	/// </summary>
	public struct CursorChangeScope : IDisposable 
	{
		private System.Windows.Forms.Control control;
		private System.Windows.Forms.Cursor previousCursor;

		public CursorChangeScope(System.Windows.Forms.Control control) 
			: this(control, Cursors.WaitCursor) 
		{
		}

		public CursorChangeScope(System.Windows.Forms.Control control, Cursor cursor) 
		{
			// Save the specified reference
			this.control = control;

			// Save the current cursor
			this.previousCursor = this.control.Cursor;

			// Change the cursor
			this.control.Cursor = cursor;
		}

		public void Dispose() 
		{
			if (this.control != null)
			{
				this.control.Cursor = this.previousCursor;
			}
		}
	}
}
