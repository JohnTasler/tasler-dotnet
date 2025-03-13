namespace Tasler.Multimedia.Windows.Forms 
{
	partial class IndexViewer
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
			this.listView = new System.Windows.Forms.ListView();
			this.chunkColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.positionColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.lengthColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.flagsColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.isKeyFrameColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.listColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.nonTimeColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.bitsColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// listView
			// 
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chunkColumnHeader,
            this.positionColumnHeader,
            this.lengthColumnHeader,
            this.flagsColumnHeader,
            this.isKeyFrameColumnHeader,
            this.listColumnHeader,
            this.nonTimeColumnHeader,
            this.bitsColumnHeader});
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(0, 0);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.ShowItemToolTips = true;
			this.listView.Size = new System.Drawing.Size(605, 320);
			this.listView.TabIndex = 0;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.VirtualMode = true;
			this.listView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listView_RetrieveVirtualItem);
			// 
			// chunkColumnHeader
			// 
			this.chunkColumnHeader.Text = "Chunk";
			this.chunkColumnHeader.Width = 56;
			// 
			// positionColumnHeader
			// 
			this.positionColumnHeader.Text = "Position";
			this.positionColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.positionColumnHeader.Width = 84;
			// 
			// lengthColumnHeader
			// 
			this.lengthColumnHeader.Text = "Length";
			this.lengthColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.lengthColumnHeader.Width = 84;
			// 
			// flagsColumnHeader
			// 
			this.flagsColumnHeader.Text = "Flags";
			this.flagsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.flagsColumnHeader.Width = 84;
			// 
			// isKeyFrameColumnHeader
			// 
			this.isKeyFrameColumnHeader.Text = "Key Frame";
			this.isKeyFrameColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.isKeyFrameColumnHeader.Width = 66;
			// 
			// listColumnHeader
			// 
			this.listColumnHeader.Text = "List";
			this.listColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.listColumnHeader.Width = 66;
			// 
			// nonTimeColumnHeader
			// 
			this.nonTimeColumnHeader.Text = "Non-time";
			this.nonTimeColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.nonTimeColumnHeader.Width = 66;
			// 
			// bitsColumnHeader
			// 
			this.bitsColumnHeader.Text = "Codec Bits";
			this.bitsColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.bitsColumnHeader.Width = 66;
			// 
			// IndexViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.listView);
			this.Name = "IndexViewer";
			this.Size = new System.Drawing.Size(605, 320);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader chunkColumnHeader;
		private System.Windows.Forms.ColumnHeader positionColumnHeader;
		private System.Windows.Forms.ColumnHeader lengthColumnHeader;
		private System.Windows.Forms.ColumnHeader flagsColumnHeader;
		private System.Windows.Forms.ColumnHeader isKeyFrameColumnHeader;
		private System.Windows.Forms.ColumnHeader listColumnHeader;
		private System.Windows.Forms.ColumnHeader nonTimeColumnHeader;
		private System.Windows.Forms.ColumnHeader bitsColumnHeader;
	}
}
