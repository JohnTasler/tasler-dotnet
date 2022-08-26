using System;

namespace Tasler.Windows.Forms
{
	/// <summary>
	/// Summary description for ListViewSubItem.
	/// </summary>
	public class ListViewSubItem : System.Windows.Forms.ListViewItem.ListViewSubItem 
	{
		#region Instance Fields
		private int imageIndex = -1;
		#endregion

		#region Properties
		public int ImageIndex 
		{
			get { return this.imageIndex; }
			set { this.imageIndex = value; }
		}
		#endregion
	}
}
