using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

using Tasler.IO;
using Tasler.ComponentModel;
using Tasler.Multimedia;
using Tasler.Viewer;
using Tasler.Windows.Forms.Viewer;

namespace Tasler.Multimedia.Windows.Forms 
{
	public partial class RiffChunkStructViewer : RiffChunkStructViewerUserControl
	{
		#region Construction
		public RiffChunkStructViewer() 
		{
			InitializeComponent();
		}
		#endregion

		#region Overrides
		protected override object GetDataStruct() 
		{
			using (Stream dataStream = base.Data.CreateDataStreamSection())
			{
				// Marshal the bytes into the structure
				object dataStruct = StreamUtility.ReadStruct(dataStream, base.StructType);
				return dataStruct;
			}
		}
		#endregion
	}

	public class RiffChunkStructViewerUserControl : StructViewerUserControl<RiffChunk> 
	{
	}
}
