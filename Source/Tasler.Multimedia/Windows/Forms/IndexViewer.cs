using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Tasler.Multimedia;
using Tasler.Multimedia.RiffTypes;
using Tasler.Multimedia.Windows.Forms;
using Tasler.Viewer;
using Tasler.Windows.Forms;
using System.IO;
using Tasler.IO;

namespace Tasler.Multimedia.Windows.Forms 
{
	public partial class IndexViewer : RiffChunkViewer
	{
		#region Static Fields
		private static readonly int AviIndexEntrySize = Marshal.SizeOf(typeof(AVIINDEXENTRY));
		#endregion

		#region Construction
		public IndexViewer() 
		{
			InitializeComponent();
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
			using (new ListViewUpdateScope())
			{
				if (data != null && data.Id == RiffTags.AviTags.idx1.FourCC)
				{
					this.listView.VirtualListSize = (int)data.DataLength / AviIndexEntrySize;
				}
				else
				{
					this.listView.VirtualListSize = 0;
				}
			}

			// Save the specified data
			base.Data = data;

			// TODO: Save the specified transient state

		}

		#endregion

		#region Event Handlers
		private void listView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) 
		{
			if (base.Data == null)
			{
				e.Item = null;
				return;
			}

			using (Stream stream = base.Data.CreateDataStreamSection())
			{
				long position = e.ItemIndex * AviIndexEntrySize;
				stream.Position = position;

				AVIINDEXENTRY entry = (AVIINDEXENTRY)StreamUtility.ReadStruct(stream, typeof(AVIINDEXENTRY));

				string[] subItems = new string[]
				{
					entry.ckid.ToString(),
					string.Format("0x{0:X8}", entry.dwChunkOffset), // TODO: Use INumberFormatPreference
					string.Format("0x{0:X8}", entry.dwChunkLength), // TODO: Use INumberFormatPreference
					string.Format("0x{0:X8}", (uint)entry.dwFlags),
					((entry.dwFlags & AviIndexFlag.KeyFrame) != 0) ? "true" : string.Empty,
					((entry.dwFlags & AviIndexFlag.List) != 0) ? "true" : string.Empty,
					((entry.dwFlags & AviIndexFlag.NoTime) != 0) ? "true" : string.Empty,
					string.Format("0x{0:X3}", ((uint)(entry.dwFlags & AviIndexFlag.CompressorBits)) >> 16), // TODO: Use INumberFormatPreference
				};

				e.Item = new ListViewItem(subItems);
			}
		}
		#endregion
	}
}
