using System;
using System.Collections.Generic;
using System.IO;

using Tasler.IO;
using Tasler.Multimedia;
using Tasler.Multimedia.RiffTypes;
using Tasler.Viewer;
using System.Drawing;

namespace Tasler.Multimedia.Windows.Forms 
{
	public class AniViewerProvider : IViewerProvider<RiffChunk>
	{
		#region IViewerProvider<RiffChunk> Members

		public List<ViewerInfo> GetViewerInfos(RiffChunk chunk) 
		{
			List<ViewerInfo> viewers = new List<ViewerInfo>(1);

			switch (chunk.Id.Value)
			{
				case RiffTags.AniTags.anih.Value:
					AniViewerProvider.ParseANIH(chunk, ref viewers);
					break;

				case RiffTags.AniTags.rate.Value:
					AniViewerProvider.ParseRate(chunk, ref viewers);
					break;

				case RiffTags.AniTags.seq.Value:
					AniViewerProvider.ParseSeq(chunk, ref viewers);
					break;

				case RiffTags.AniTags.icon.Value:
					AniViewerProvider.ParseIcon(chunk, ref viewers);
					break;
			}

			return viewers;
		}

		#endregion

		#region Implementation

		private static void ParseANIH(RiffChunk chunk, ref List<ViewerInfo> viewers) 
		{
			viewers.Add(new ViewerInfo("AniHeader", typeof(RiffChunkStructViewer), null, typeof(AniHeader)));
		}

		private static void ParseRate(RiffChunk chunk, ref List<ViewerInfo> viewers) 
		{
		}

		private static void ParseSeq(RiffChunk chunk, ref List<ViewerInfo> viewers) 
		{
		}

		private static void ParseIcon(RiffChunk chunk, ref List<ViewerInfo> viewers) 
		{
			// TODO: attempt to load the chunk's icon and catch exception with a general error viewer
			viewers.Add(new ViewerInfo("icon", typeof(RiffChunkIconViewer)));
		}


		#endregion
	}
}
