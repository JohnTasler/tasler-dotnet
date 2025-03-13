using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;
//using System.IO;

using Tasler.IO;
using Tasler.Multimedia;
using Tasler.Viewer;

namespace Tasler.Multimedia.Windows.Forms 
{
	public partial class RiffChunkHexViewer : RiffChunkViewer 
	{
		#region Construction
		public RiffChunkHexViewer() 
		{
			InitializeComponent();

			// Add an event handler for when the object is disposed
			base.Disposed += new EventHandler(
				delegate(object sender, EventArgs e)
				{
					using (this.hexDumpControl.DataStream)
					{
						this.hexDumpControl.DataStream = null;
					}
				}
			);
		}
		#endregion

		#region IViewer<RiffChunk> Overrides

		public override object TransientState 
		{
			get 
			{
				// TODO: Implement per-data state (ScrollPosition, Selection, etc.)
				return null;
			}
		}

		public override object PersistentState 
		{
			get 
			{
				// TODO: Implement Type-wide persistent state (BytesPerLine, Grouping, etc.)
				return null;
			}
			set 
			{
			}
		}

		public override void Initialize(ViewerInfo viewerInfo) 
		{
		}

		public override void SetData(RiffChunk data, object transientState) 
		{
			// Clear the inner control
			using (this.hexDumpControl.DataStream)
			{
				this.hexDumpControl.DataStream = null;
			}

			// Save the specified data
			base.Data = data;

			// Apply the specified data
			if (base.Data != null)
			{
				this.hexDumpControl.DataStream =
					new StreamSection(base.Data.Stream, base.Data.DataPosition, base.Data.DataLength);
			}

			// TODO: Save the specified transient state

		}

		#endregion
	}
}
