using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Tasler.Windows.Forms 
{
	/// <summary>
	/// Summary description for WizardInteriorPage.
	/// </summary>
	public class WizardInteriorPage : WizardPage 
	{
		#region Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() 
		{
			// 
			// WizardInteriorPage
			// 
			this.Name = "WizardInteriorPage";
			this.Size = new System.Drawing.Size(476, 233);

		}
		#endregion

		#region Instance Fields
		private string headerTitle = "Sample Header Title";
		private string headerSubtitle = "Sample header subtitle will help a user complete a certain task in the Sample wizard by clarifying the task in some way.";
		private Image headerImage = null;
		#endregion

		#region Construction / Disposal
		public WizardInteriorPage() 
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}
		#endregion

		#region Properties
		public string HeaderTitle 
		{
			get { return this.headerTitle; }
			set { this.headerTitle = value; }
		}

		public string HeaderSubtitle 
		{
			get { return this.headerSubtitle; }
			set { this.headerSubtitle = value; }
		}

		public Image HeaderImage 
		{
			get { return this.headerImage; }
			set { this.headerImage = value; }
		}
		#endregion
	}
}
