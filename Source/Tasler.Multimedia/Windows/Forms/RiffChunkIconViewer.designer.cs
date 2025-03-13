namespace Tasler.Multimedia.Windows.Forms 
{
	partial class RiffChunkIconViewer
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RiffChunkIconViewer));
			this.iconViewerControl = new Tasler.Windows.Forms.IconViewerControl();
			this.SuspendLayout();
			// 
			// iconViewerControl
			// 
			this.iconViewerControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.iconViewerControl.AutoScroll = true;
			this.iconViewerControl.AutoScrollMinSize = new System.Drawing.Size(33, 33);
			this.iconViewerControl.Icon = ((System.Drawing.Icon)(resources.GetObject("iconViewerControl.Icon")));
			this.iconViewerControl.Location = new System.Drawing.Point(3, 3);
			this.iconViewerControl.Name = "iconViewerControl";
			this.iconViewerControl.ShowGrid = true;
			this.iconViewerControl.Size = new System.Drawing.Size(515, 383);
			this.iconViewerControl.TabIndex = 0;
			this.iconViewerControl.ZoomLevel = 11;
			// 
			// RiffChunkIconViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.iconViewerControl);
			this.Name = "RiffChunkIconViewer";
			this.Size = new System.Drawing.Size(521, 389);
			this.ResumeLayout(false);

		}

		#endregion

		private Tasler.Windows.Forms.IconViewerControl iconViewerControl;


	}
}
