using System;
using System.Collections.Generic;
using System.IO;

using Tasler.IO;
using Tasler.Multimedia;
using Tasler.Multimedia.RiffTypes;
using Tasler.Viewer;

namespace Tasler.Multimedia.Windows.Forms 
{
	public class AviViewerProvider : IViewerProvider<RiffChunk>
	{
		#region IViewerProvider<RiffChunk> Members

		public List<ViewerInfo> GetViewerInfos(RiffChunk chunk) 
		{
			List<ViewerInfo> viewers = new List<ViewerInfo>(1);

			switch (chunk.Id.Value)
			{
				case RiffTags.AviTags.avih.Value:
					AviViewerProvider.ParseAVIH(chunk, ref viewers);
					break;

				case RiffTags.AviTags.StreamInfo.strh.Value:
					AviViewerProvider.ParseSTRH(chunk, ref viewers);
					break;

				case RiffTags.AviTags.StreamInfo.strf.Value:
					AviViewerProvider.ParseSTRF(chunk, ref viewers);
					break;

				case RiffTags.AviTags.idx1.Value:
					AviViewerProvider.ParseIDX1(chunk, ref viewers);
					break;
			}

			return viewers;
		}

		#endregion

		#region Implementation

		private static void ParseAVIH(RiffChunk chunk, ref List<ViewerInfo> viewers) 
		{
			viewers.Add(new ViewerInfo("AVIMAINHEADER", typeof(RiffChunkStructViewer), null, typeof(AVIMAINHEADER)));
		}

		private static void ParseSTRH(RiffChunk chunk, ref List<ViewerInfo> viewers) 
		{
			viewers.Add(new ViewerInfo("AVISTREAMHEADER", typeof(RiffChunkStructViewer), null, typeof(AVISTREAMHEADER)));
		}

		private static void ParseSTRF(RiffChunk chunk, ref List<ViewerInfo> viewers) 
		{
			RiffChunk parent = chunk.Parent as RiffChunk;
			if (parent != null && parent.ListType == RiffTags.AviTags.Lists.strl.FourCC)
			{
				RiffChunk strhChunk = parent.FindChunk(RiffTags.AviTags.StreamInfo.strh.FourCC, false);
				if (strhChunk != null)
				{
					using (Stream stream = strhChunk.CreateDataStreamSection())
					{
						AVISTREAMHEADER streamHeader =
							(AVISTREAMHEADER)StreamUtility.ReadStruct(stream, typeof(AVISTREAMHEADER));

						switch (streamHeader.fccType.Value)
						{
							case RiffTags.AviTags.StreamInfo.Types.auds.Value:
								viewers.Add(new ViewerInfo("WAVEFORMATEX", typeof(RiffChunkStructViewer),
									(object)typeof(WAVEFORMATEX)));
								break;

							case RiffTags.AviTags.StreamInfo.Types.vids.Value:
								viewers.Add(new ViewerInfo("BITMAPINFOHEADER", typeof(RiffChunkStructViewer),
									(object)typeof(BITMAPINFOHEADER)));
								break;

							//case RiffTags.AviTags.StreamInfo.Types.mids.Value:
							//    break;

							//case RiffTags.AviTags.StreamInfo.Types.txts.Value:
							//    break;
						}
					}
				}
			}
		}

		private static void ParseIDX1(RiffChunk chunk, ref List<ViewerInfo> viewers) 
		{
			viewers.Add(new ViewerInfo("Index", typeof(IndexViewer)));
		}


		#endregion
	}
}
