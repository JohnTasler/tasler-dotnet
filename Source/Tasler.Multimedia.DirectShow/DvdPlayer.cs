using System;
using System.Runtime.InteropServices;
using Tasler.Multimedia.DirectShow.DvdTypes;

namespace Tasler.Multimedia.DirectShow
{
	public class DvdPlayer
	{
		#region Instance Fields
		private DvdGraphBuilder dvdGraphBuilder;
		private IMediaControl mediaControl;
		private IDvdControl2 dvdControl2;
		private IDvdInfo2 dvdInfo2;
		private IVideoWindow videoWindow;
		private ILine21Decoder line21Decoder;
		#endregion Instance Fields

		#region Properties

		public DvdGraphBuilder DvdGraphBuilder
		{
			get
			{
				return this.dvdGraphBuilder;
			}
		}

		public IMediaControl MediaControl
		{
			get
			{
				if (this.mediaControl == null)
				{
					if (this.dvdGraphBuilder != null)
					{
						int hr;
						this.mediaControl = this.dvdGraphBuilder.GetFiltergraphInterface<IMediaControl>(out hr);
						if (hr != 0)
							throw new COMException("DvdGraphHelper.GetFiltergraphInterface<IMediaControl>", hr);
					}
				}

				return this.mediaControl;
			}
		}

		public IDvdControl2 DvdControl
		{
			get
			{
				if (this.dvdControl2 == null)
				{
					if (this.dvdGraphBuilder != null)
					{
						int hr;
						this.dvdControl2 = this.dvdGraphBuilder.GetDvdInterface<IDvdControl2>(out hr);
						if (hr != 0)
							throw new COMException("IDvdGraphBuilder.GetDvdInterface<IDvdControl2>", hr);
					}
				}

				return this.dvdControl2;
			}
		}

		public IDvdInfo2 DvdInfo
		{
			get
			{
				if (this.dvdInfo2 == null)
				{
					if (this.dvdGraphBuilder != null)
					{
						int hr;
						this.dvdInfo2 = this.dvdGraphBuilder.GetDvdInterface<IDvdInfo2>(out hr);
						if (hr != 0)
							throw new COMException("IDvdGraphBuilder.GetDvdInterface<IDvdInfo2>", hr);
					}
				}

				return this.dvdInfo2;
			}
		}

		public IVideoWindow VideoWindow
		{
			get
			{
				if (this.videoWindow == null)
				{
					if (this.dvdGraphBuilder != null)
					{
						int hr;
						this.videoWindow = this.dvdGraphBuilder.GetDvdInterface<IVideoWindow>(out hr);
						if (hr != 0)
							throw new COMException("IDvdGraphBuilder.GetDvdInterface<IVideoWindow>", hr);
					}
				}

				return this.videoWindow;
			}
		}

		public ILine21Decoder Line21Decoder
		{
			get
			{
				if (this.line21Decoder == null)
				{
					if (this.dvdGraphBuilder != null)
					{
						int hr;
						this.line21Decoder = this.dvdGraphBuilder.GetDvdInterface<ILine21Decoder>(out hr);
						if (hr != 0)
							throw new COMException("IDvdGraphBuilder.GetDvdInterface<ILine21Decoder>", hr);
					}
				}

				return this.line21Decoder;
			}
		}

		#endregion Properties

		#region Methods

		public void Open()
		{
			if (this.dvdGraphBuilder != null)
				throw new InvalidOperationException("Already open.");

			// Create the DvdGraphBuilder object
			this.dvdGraphBuilder = new DvdGraphBuilder();
		}

		public void Close()
		{
			// Shut everything down, if it's running
			if (this.MediaControl != null)
				this.MediaControl.Stop();

			if (this.VideoWindow != null)
				this.VideoWindow.WindowState = WindowState.Hide;

			this.dvdGraphBuilder = null;
			this.mediaControl = null;
			this.dvdControl2 = null;
			this.dvdInfo2 = null;
			this.videoWindow = null;
			this.line21Decoder = null;
		}

		#endregion Methods


	}
}