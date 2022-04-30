using System;

namespace Tasler.Windows.Forms
{
	/// <summary>
	/// Summary description for ComboBoxUpdateScope.
	/// </summary>
	public struct ComboBoxUpdateScope : IDisposable 
	{
		private System.Windows.Forms.ComboBox control;

		public ComboBoxUpdateScope(System.Windows.Forms.ComboBox control) 
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
