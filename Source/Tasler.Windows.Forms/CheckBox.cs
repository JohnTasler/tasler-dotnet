using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Tasler.Windows.Forms
{
	/// <summary>
	/// Summary description for CheckBox.
	/// </summary>
	public class CheckBox : System.Windows.Forms.CheckBox 
	{
		#region Instance Fields
		private bool validateOnCheckStateChanged = true;
		#endregion

		#region Construction
		public CheckBox() 
		{
		}
		#endregion

		#region Properties
		public bool ValidateOnCheckStateChanged 
		{
			get { return this.validateOnCheckStateChanged; }
			set { this.validateOnCheckStateChanged = value; }
		}
		#endregion

		#region Overrides
		protected override void OnCheckStateChanged(EventArgs e) 
		{
			// Perform default processing
			base.OnCheckStateChanged(e);

			// Find the parent ContainerControl
			Control parent = this.Parent;
			while (parent != null && (parent as ContainerControl) == null)
			{
				parent = parent.Parent;
			}

			// Validate the parent ContainerControl
			ContainerControl container = parent as ContainerControl;
			if (container != null)
			{
				container.Validate();
			}
		}
		#endregion
	}
}
