using System;

namespace Tasler.Windows.Forms
{
	/// <summary>
	/// Summary description for SortableColumnHeader.
	/// </summary>
	public class SortableColumnHeader : System.Windows.Forms.ColumnHeader 
	{
		#region Instance Fields
		private ListViewItemSorter sorter;
		#endregion

		#region Properties
		public ListViewItemSorter Sorter 
		{
			get { return this.sorter; }
			set { this.sorter = value; }
		}
		#endregion
	}
}
