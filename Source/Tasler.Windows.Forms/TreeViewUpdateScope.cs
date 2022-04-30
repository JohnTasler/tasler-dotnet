using System;

namespace Tasler.Windows.Forms
{
	/// <summary>
	/// Summary description for TreeViewUpdateScope.
	/// </summary>
	public struct TreeViewUpdateScope : IDisposable 
	{
		private System.Windows.Forms.TreeView treeview;

		public TreeViewUpdateScope(System.Windows.Forms.TreeView treeview) 
		{
			// Save the specified reference
			this.treeview = treeview;

			// Suspend update
			treeview.BeginUpdate();
		}

		public void Dispose() 
		{
			if (treeview != null)
			{
				treeview.EndUpdate();
			}
		}
	}
}
