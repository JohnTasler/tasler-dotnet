using System;

namespace Tasler.Windows.Forms
{
	/// <summary>
	/// Summary description for ListBoxUpdateScope.
	/// </summary>
	public struct ListBoxUpdateScope : IDisposable 
	{
		private System.Windows.Forms.ListBox control;

		public ListBoxUpdateScope(System.Windows.Forms.ListBox control) 
		{
			// Save the specified reference
			this.control = control;

			// Suspend update
			control.BeginUpdate();
		}

		public void Dispose() 
		{
			if (control != null)
			{
				control.EndUpdate();
			}
		}
	}
}
