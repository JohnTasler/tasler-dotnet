using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Tasler.Windows.Forms 
{
	/// <summary>
	/// Summary description for WizardDialog.
	/// </summary>
	public class WizardDialog : System.Windows.Forms.Form 
		, IWizardFrame 
	{
		#region Designer generated fields
		private System.Windows.Forms.Panel pagePanel;
		private System.Windows.Forms.Panel shadowLinePanel;
		private System.Windows.Forms.Panel highlightLinePanel;
		protected System.Windows.Forms.Button backButton;
		protected System.Windows.Forms.Button nextButton;
		protected System.Windows.Forms.Button finishButton;
		protected System.Windows.Forms.Button cancelButton;
		#endregion

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() 
		{
			this.pagePanel = new System.Windows.Forms.Panel();
			this.shadowLinePanel = new System.Windows.Forms.Panel();
			this.highlightLinePanel = new System.Windows.Forms.Panel();
			this.backButton = new System.Windows.Forms.Button();
			this.nextButton = new System.Windows.Forms.Button();
			this.finishButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pagePanel
			// 
			this.pagePanel.BackColor = System.Drawing.SystemColors.Window;
			this.pagePanel.Location = new System.Drawing.Point(0, 0);
			this.pagePanel.Name = "pagePanel";
			this.pagePanel.Size = new System.Drawing.Size(498, 316);
			this.pagePanel.TabIndex = 9;
			// 
			// shadowLinePanel
			// 
			this.shadowLinePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.shadowLinePanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.shadowLinePanel.Location = new System.Drawing.Point(0, 316);
			this.shadowLinePanel.Name = "shadowLinePanel";
			this.shadowLinePanel.Size = new System.Drawing.Size(498, 1);
			this.shadowLinePanel.TabIndex = 5;
			// 
			// highlightLinePanel
			// 
			this.highlightLinePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.highlightLinePanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.highlightLinePanel.Location = new System.Drawing.Point(0, 317);
			this.highlightLinePanel.Name = "highlightLinePanel";
			this.highlightLinePanel.Size = new System.Drawing.Size(498, 1);
			this.highlightLinePanel.TabIndex = 6;
			// 
			// backButton
			// 
			this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.backButton.Enabled = false;
			this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.backButton.Location = new System.Drawing.Point(251, 328);
			this.backButton.Name = "backButton";
			this.backButton.TabIndex = 7;
			this.backButton.Text = "< &Back";
			this.backButton.Click += new System.EventHandler(this.backButton_Click);
			// 
			// nextButton
			// 
			this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.nextButton.Location = new System.Drawing.Point(326, 328);
			this.nextButton.Name = "nextButton";
			this.nextButton.TabIndex = 8;
			this.nextButton.Text = "&Next >";
			this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
			// 
			// finishButton
			// 
			this.finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.finishButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.finishButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.finishButton.Location = new System.Drawing.Point(326, 328);
			this.finishButton.Name = "finishButton";
			this.finishButton.TabIndex = 8;
			this.finishButton.Text = "&Finish";
			this.finishButton.Visible = false;
			this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cancelButton.Location = new System.Drawing.Point(412, 328);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// WizardDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(498, 361);
			this.Controls.Add(this.pagePanel);
			this.Controls.Add(this.shadowLinePanel);
			this.Controls.Add(this.highlightLinePanel);
			this.Controls.Add(this.backButton);
			this.Controls.Add(this.nextButton);
			this.Controls.Add(this.finishButton);
			this.Controls.Add(this.cancelButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WizardDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Wizard Dialog";
			this.ResumeLayout(false);

		}
		#endregion

		#region Instance Fields
		private ArrayList pages = new ArrayList();
		private IWizardPage currentPage;
		private WizardInteriorPageHost interiorPageHost;
		#endregion

		#region Construction / Disposal
		public WizardDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Create the WizardInteriorPageHost
			this.interiorPageHost = new WizardInteriorPageHost();
			this.interiorPageHost.Visible = false;
			this.pagePanel.Controls.Add(this.interiorPageHost);
		}
		#endregion

		#region Properties
		[Browsable(false)]
		public IWizardPage CurrentPage 
		{
			get { return this.currentPage; }
			set 
			{
				WizardInteriorPage interiorPage = value as WizardInteriorPage;
				if (interiorPage != null)
				{
					this.interiorPageHost.CurrentPage = interiorPage;
					if (!(this.currentPage is WizardInteriorPage))
					{
						// Show the new page
						this.interiorPageHost.Visible = true;
						this.interiorPageHost.BringToFront();

						// Hide the old page
						if (this.currentPage !=  null)
						{
							((Control)this.currentPage).SendToBack();
							((Control)this.currentPage).Visible = false;
						}
					}
					this.currentPage = value;
				}
				else
				{
					// New page is a Welcome or Completion page
					Control valueControl = (Control)value;
					if (valueControl != null)
					{
						// Add the new page as a child of the pagePanel
						if (valueControl.Parent != this.pagePanel)
						{
							valueControl.Visible = false;
							this.pagePanel.Controls.Add(valueControl);
						}

						// Show the new page
						valueControl.Visible = true;
						valueControl.BringToFront();
					}

					// Hide the old page
					Control oldPage = (Control)this.currentPage;
					if (this.currentPage is WizardInteriorPage)
					{
						oldPage = this.interiorPageHost;
					}
					if (oldPage != null)
					{
						oldPage.SendToBack();
						oldPage.Visible = false;
					}
					this.currentPage = value;
				}
			}
		}
		#endregion

		#region IWizardFrame Properties
		public int PageCount 
		{
			get { return this.pages.Count; }
		}
		public IWizardPage ActivePage 
		{
			get { return this.CurrentPage; }
		}
		public bool BackButtonEnabled 
		{
			get { return this.backButton.Enabled; }
			set { this.backButton.Enabled = value; }
		}
		public bool BackButtonVisible 
		{
			get { return this.backButton.Visible; }
			set { this.backButton.Visible = value; }
		}
		public bool NextButtonEnabled 
		{
			get { return this.nextButton.Enabled; }
			set { this.nextButton.Enabled = value; }
		}
		public bool NextButtonVisible 
		{
			get { return this.nextButton.Visible; }
			set { this.nextButton.Visible = value; }
		}
		public bool FinishButtonEnabled 
		{
			get { return this.finishButton.Enabled; }
			set { this.finishButton.Enabled = value; }
		}
		public bool FinishButtonVisible 
		{
			get { return this.finishButton.Visible; }
			set { this.finishButton.Visible = value; }
		}
		#endregion

		#region IWizardFrame Methods
		public void AddPage(IWizardPage page) 
		{
			// Validate the parameters
			if (page == null)
			{
				throw new ArgumentNullException("page");
			}

			// Add the page to the end of the collection
			this.pages.Add(page);
			page.WizardFrame = this;

			// If this is the only/first page, set it as active
			if (this.pages.Count == 1)
			{
				this.CurrentPage = page;
			}
		}
		public void InsertPage(IWizardPage insertAfter, IWizardPage page) 
		{
			// Validate the parameters
			if (insertAfter == null)
			{
				throw new ArgumentNullException("insertAfter");
			}
			if (page == null)
			{
				throw new ArgumentNullException("page");
			}

			// Find the specified page to insert after
			int index = this.pages.IndexOf(insertAfter);
			if (index < 0)
			{
				throw new ArgumentException("The specified page is not in the collection.", "insertAfter");
			}

			// Insert the page
			this.pages.Insert(index, page);
			page.WizardFrame = this;
		}
		public void PressBackButton() 
		{
			if (this.BackButtonEnabled && this.BackButtonVisible)
			{
				this.backButton.PerformClick();
			}
		}
		public void PressNextButton() 
		{
			if (this.NextButtonEnabled && this.NextButtonVisible)
			{
				this.nextButton.PerformClick();
			}
		}
		public void PressFinishButton() 
		{
			if (this.FinishButtonEnabled && this.FinishButtonVisible)
			{
				this.finishButton.PerformClick();
			}
		}
		public void PressCancelButton() 
		{
			this.cancelButton.PerformClick();
		}
		#endregion

		#region Event Handlers
		private void backButton_Click(object sender, System.EventArgs e) 
		{
			// Get the index of the current page
			int index = this.pages.IndexOf(this.CurrentPage);
			Debug.Assert(index >= 0);

			IWizardPage pageActivating = (index > 0) ?
				(IWizardPage)this.pages[index - 1] : this.CurrentPage;
			if (pageActivating != this.CurrentPage)
			{
				// Send the OnDeactivating notification to the deactivating page
				IWizardPage pageChange = this.CurrentPage.OnDeactivating(pageActivating, false);
				if (pageChange == null)
				{
					pageChange = pageActivating;
				}

				// Ensure that it is in our pages collection
				index = this.pages.IndexOf(pageChange);
				if (index < 0)
				{
					throw new ArgumentException("Return value from IWizardPage.OnDeactivating must be null or a page added to the IWizardFrame.");
				}

				// Disable the Back button, if index is zero
				if (index == 0)
				{
					this.BackButtonEnabled = false;
				}

				// Send the OnActivating notification to the activating page
				pageChange.OnActivating(this.CurrentPage, false);

				// Change the page
				this.CurrentPage = pageChange;
			}
		}

		private void nextButton_Click(object sender, System.EventArgs e) 
		{
			// Get the index of the current page
			int index = this.pages.IndexOf(this.CurrentPage);
			Debug.Assert(index >= 0);

			IWizardPage pageActivating = (index < this.PageCount - 1) ?
				(IWizardPage)this.pages[index + 1] : this.CurrentPage;
			if (pageActivating != this.CurrentPage)
			{
				// Send the OnDeactivating notification to the deactivating page
				IWizardPage pageChange = this.CurrentPage.OnDeactivating(pageActivating, true);
				if (pageChange == null)
				{
					pageChange = pageActivating;
				}

				// Ensure that it is in our pages collection
				index = this.pages.IndexOf(pageChange);
				if (index < 0)
				{
					throw new ArgumentException("Return value from IWizardPage.OnDeactivating must be null or a page added to the IWizardFrame.");
				}

				// Enable the Back button
				this.BackButtonEnabled = true;

				// Send the OnActivating notification to the activating page
				pageChange.OnActivating(this.CurrentPage, true);

				// Change the page
				this.CurrentPage = pageChange;
			}
		}

		private void finishButton_Click(object sender, System.EventArgs e) 
		{
			// Send the OnDeactivating notification to the deactivating/current page
			this.CurrentPage.OnDeactivating(null, true);
		}

		private void cancelButton_Click(object sender, System.EventArgs e) 
		{
			// Send the OnDeactivating notification to the deactivating/current page
			this.CurrentPage.OnDeactivating(null, true);
		}

		private void WizardDialog_Closed(object sender, System.EventArgs e) 
		{
			// Send the OnDeactivating notification to the deactivating/current page
			this.CurrentPage.OnDeactivating(null, true);
		}
		#endregion

	}
}
