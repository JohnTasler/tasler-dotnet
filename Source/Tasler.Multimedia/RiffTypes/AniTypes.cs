using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Tasler.Multimedia.RiffTypes
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct AniHeader
	{
		/// <summary>Number of bytes in AniHeader.</summary>
		public uint cbSizeOf;
		/// <summary>Number of unique Icons in this cursor.</summary>
		public uint cFrames;
		/// <summary>Number of Blits before the animation cycles.</summary>
		public uint cSteps;
		/// <summary>Total width in pixels.</summary>
		public uint cx;
		/// <summary>Total height in pixels.</summary>
		public uint cy;
		/// <summary>Number of bits per pixel.</summary>
		public uint cBitCount;
		/// <summary>This is always 1.</summary>
		public uint cPlanes;
		/// <summary>Default Jiffies (1/60th of a second) if rate chunk not present.</summary>
		public uint JifRate;
		/// <summary>Animation Flags (see AF_ constants).</summary>
		public AniFlag flags;
	}

	[Flags]
	public enum AniFlag
	{
		/// <summary>Frames are raw (BITMAP) data without the header.</summary>
		Raw = 0x0000,

		/// <summary>Frames are Window Icon/Cursor format including header.</summary>
		Icon = 0x0001,

		/// <summary>File contains sequence data.</summary>
		Sequence = 0x0002,

		/// <summary>Mask to isolate the format flags.</summary>
		FormatMask = 0x0001,
	}
}
