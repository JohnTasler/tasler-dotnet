namespace Tasler.Multimedia.Windows.Forms 
{
	partial class RiffChunkHexViewer
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
			this.hexDumpControl = new Tasler.Windows.Forms.HexDumpControl();
			this.SuspendLayout();
			// 
			// hexDumpControl
			// 
			this.hexDumpControl.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.hexDumpControl.ColumnCount = 1;
			this.hexDumpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.hexDumpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.hexDumpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.hexDumpControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.hexDumpControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hexDumpControl.Location = new System.Drawing.Point(0, 0);
			this.hexDumpControl.Name = "hexDumpControl";
			this.hexDumpControl.RowCount = 1;
			this.hexDumpControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.hexDumpControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.hexDumpControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.hexDumpControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.hexDumpControl.Size = new System.Drawing.Size(800, 500);
			this.hexDumpControl.TabIndex = 0;
			// 
			// RiffChunkHexViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.hexDumpControl);
			this.Name = "RiffChunkHexViewer";
			this.Size = new System.Drawing.Size(800, 500);
			this.ResumeLayout(false);

		}

		#endregion

		private Tasler.Windows.Forms.HexDumpControl hexDumpControl;

	}
}
