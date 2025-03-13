using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Tasler.Multimedia.RiffTypes
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct AVIMAINHEADER
	{    // 'avih'
		public int dwMicroSecPerFrame;
		public int dwMaxBytesPerSec;
		public int dwPaddingGranularity;
		public int dwFlags;
		public int dwTotalFrames;
		public int dwInitialFrames;
		public int dwStreams;
		public int dwSuggestedBufferSize;
		public int dwWidth;
		public int dwHeight;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public int[] dwReserved;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct RECT
	{
		public short left;
		public short top;
		public short right;
		public short bottom;
		public override string ToString()
		{
			return string.Format("({0}, {1}) width={2} height={3}",
				this.left, this.top, this.right - this.left, this.bottom - this.top);
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct AVISTREAMHEADER
	{ // 'strh'
		public FourCC fccType;      // stream type codes
		public FourCC fccHandler;
		public int dwFlags;
		public short wPriority;
		public short wLanguage;
		public int dwInitialFrames;
		public int dwScale;
		public int dwRate;       // dwRate/dwScale is stream tick rate in ticks/sec
		public int dwStart;
		public int dwLength;
		public int dwSuggestedBufferSize;
		public int dwQuality;
		public int dwSampleSize;
		public RECT rcFrame;
	}

	public enum CompressionType
	{
		Rgb       = 0,
		Rle8      = 1,
		Rle4      = 2,
		BitFields = 3,
		Jpeg      = 4,
		Png       = 5,
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct BITMAPINFOHEADER
	{
		public uint biSize;
		public int biWidth;
		public int biHeight;
		public ushort biPlanes;
		public ushort biBitCount;
		public Compression biCompression;
		public uint biSizeImage;
		public int biXPelsPerMeter;
		public int biYPelsPerMeter;
		public uint biClrUsed;
		public uint biClrImportant;

		[StructLayout(LayoutKind.Explicit)]
		public struct Compression
		{
			[FieldOffset(0)]
			private int value;
			[FieldOffset(0)]
			public int compressionType;
			[FieldOffset(0)]
			public FourCC compressionFourCC;

			public override string ToString()
			{
				StringBuilder sb = new StringBuilder("[union] 0x");
				sb.AppendFormat("{0:X8} ", this.value);

				if (this.value > 0x00FFFFFF)
				{
					sb.Append("'").Append(this.compressionFourCC.ToString()).Append("'");
				}
				else
				{
					if (Enum.IsDefined(typeof(CompressionType), this.value))
					{
						sb.Append(Enum.GetName(typeof(CompressionType), this.value));
					}
				}

				return sb.ToString();
			}
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct WAVEFORMATEX
	{
		public ushort wFormatTag;
		public ushort nChannels;
		public uint nSamplesPerSec;
		public uint nAvgBytesPerSec;
		public ushort nBlockAlign;
		public ushort wBitsPerSample;
		public ushort cbSize;
	}

	[Flags]
	public enum AviIndexFlag
	{
		/// <summary>Chunk is 'LIST'</summary>
		List = 0x00000001,

		/// <summary>This frame is a key frame.</summary>
		KeyFrame = 0x00000010,

		/// <summary>This frame doesn't take any time.</summary>
		NoTime = 0x00000100,

		/// <summary>These bits are for compressor use.</summary>
		CompressorBits = 0x0FFF0000,
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct AVIINDEXENTRY
	{
		public FourCC ckid;
		public AviIndexFlag dwFlags;
		public uint dwChunkOffset;
		public uint dwChunkLength;
	}
}
