using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Tasler.Windows.Forms 
{
	/// <summary>
	/// This control hosts controls of type <c>WizardInteriorPage</c>. It is used
	/// internally by <c>WizardDialog</c> when its CurrentPage property is set
	/// to a control derived from WizardInteriorPage.
	/// </summary>
	public class WizardInteriorPageHost : System.Windows.Forms.UserControl
	{
		#region Designer generated data
		private System.Windows.Forms.Panel pagePanel;
		private System.Windows.Forms.Panel headerPanel;
		private System.Windows.Forms.PictureBox headerPictureBox;
		private System.Windows.Forms.Panel highlightLinePanel;
		private System.Windows.Forms.Panel shadowLinePanel;
		private System.Windows.Forms.Label headerTitleLabel;
		private System.Windows.Forms.Label headerSubtitleLabel;
		#endregion

		#region Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() 
		{
			this.pagePanel = new System.Windows.Forms.Panel();
			this.highlightLinePanel = new System.Windows.Forms.Panel();
			this.shadowLinePanel = new System.Windows.Forms.Panel();
			this.headerPanel = new System.Windows.Forms.Panel();
			this.headerTitleLabel = new System.Windows.Forms.Label();
			this.headerPictureBox = new System.Windows.Forms.PictureBox();
			this.headerSubtitleLabel = new System.Windows.Forms.Label();
			this.headerPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// pagePanel
			// 
			this.pagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pagePanel.Location = new System.Drawing.Point(11, 72);
			this.pagePanel.Name = "pagePanel";
			this.pagePanel.Size = new System.Drawing.Size(476, 233);
			this.pagePanel.TabIndex = 5;
			// 
			// highlightLinePanel
			// 
			this.highlightLinePanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.highlightLinePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.highlightLinePanel.Location = new System.Drawing.Point(0, 60);
			this.highlightLinePanel.Name = "highlightLinePanel";
			this.highlightLinePanel.Size = new System.Drawing.Size(498, 1);
			this.highlightLinePanel.TabIndex = 7;
			// 
			// shadowLinePanel
			// 
			this.shadowLinePanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.shadowLinePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.shadowLinePanel.Location = new System.Drawing.Point(0, 59);
			this.shadowLinePanel.Name = "shadowLinePanel";
			this.shadowLinePanel.Size = new System.Drawing.Size(498, 1);
			this.shadowLinePanel.TabIndex = 8;
			// 
			// headerPanel
			// 
			this.headerPanel.BackColor = System.Drawing.SystemColors.Window;
			this.headerPanel.Controls.Add(this.headerTitleLabel);
			this.headerPanel.Controls.Add(this.headerPictureBox);
			this.headerPanel.Controls.Add(this.headerSubtitleLabel);
			this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.headerPanel.Location = new System.Drawing.Point(0, 0);
			this.headerPanel.Name = "headerPanel";
			this.headerPanel.Size = new System.Drawing.Size(498, 59);
			this.headerPanel.TabIndex = 6;
			// 
			// headerTitleLabel
			// 
			this.headerTitleLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.headerTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.headerTitleLabel.Location = new System.Drawing.Point(21, 11);
			this.headerTitleLabel.Name = "headerTitleLabel";
			this.headerTitleLabel.Size = new System.Drawing.Size(414, 16);
			this.headerTitleLabel.TabIndex = 0;
			this.headerTitleLabel.Text = "Wizard Header Title";
			// 
			// headerPictureBox
			// 
			this.headerPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.headerPictureBox.Location = new System.Drawing.Point(439, 0);
			this.headerPictureBox.Name = "headerPictureBox";
			this.headerPictureBox.Size = new System.Drawing.Size(59, 59);
			this.headerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.headerPictureBox.TabIndex = 6;
			this.headerPictureBox.TabStop = false;
			// 
			// headerSubtitleLabel
			// 
			this.headerSubtitleLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.headerSubtitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.headerSubtitleLabel.Location = new System.Drawing.Point(42, 26);
			this.headerSubtitleLabel.Name = "headerSubtitleLabel";
			this.headerSubtitleLabel.Size = new System.Drawing.Size(393, 30);
			this.headerSubtitleLabel.TabIndex = 1;
			this.headerSubtitleLabel.Text = "Wizard header subtitle text goes here to better explain what the purpose of this " +
				"step is.";
			// 
			// WizardInteriorPageHost
			// 
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.highlightLinePanel);
			this.Controls.Add(this.shadowLinePanel);
			this.Controls.Add(this.headerPanel);
			this.Controls.Add(this.pagePanel);
			this.Name = "WizardInteriorPageHost";
			this.Size = new System.Drawing.Size(498, 316);
			this.headerPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Instance Fields
		WizardInteriorPage currentPage;
		#endregion

		#region Construction
		public WizardInteriorPageHost()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}
		#endregion

		#region Properties
		[Browsable(false)]
		public WizardInteriorPage CurrentPage 
		{
			get { return this.currentPage; }
			set 
			{
				if ((value != null) && (value.Parent != this.pagePanel))
				{
					value.Visible = false;
					this.pagePanel.Controls.Add(value);
					value.Anchor = AnchorStyles.None;
				}

				if (this.currentPage != value)
				{
					if (value != null)
					{
						value.Visible = true;
						value.BringToFront();
						this.headerTitleLabel.Text = value.HeaderTitle;
						this.headerSubtitleLabel.Text = value.HeaderSubtitle;
						this.headerPictureBox.Image = value.HeaderImage;
					}
					if (this.currentPage !=  null)
					{
						this.currentPage.SendToBack();
						this.currentPage.Visible = false;
					}
					this.currentPage = value;
				}
			}
		}
		#endregion
	}
}
