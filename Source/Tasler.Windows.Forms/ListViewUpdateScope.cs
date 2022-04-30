using System;

namespace Tasler.Windows.Forms
{
	/// <summary>
	/// Summary description for ListViewUpdateScope.
	/// </summary>
	public struct ListViewUpdateScope : IDisposable 
	{
		private System.Windows.Forms.ListView listview;

		public ListViewUpdateScope(System.Windows.Forms.ListView listview) 
		{
			// Save the specified reference
			this.listview = listview;

			// Suspend update
			listview.BeginUpdate();
		}

		public void Dispose() 
		{
			if (listview != null)
			{
				listview.EndUpdate();
			}
		}
	}
}
