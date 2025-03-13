using System;
using System.IO;

namespace Tasler.Multimedia 
{
	public interface IRiffChunkParent 
	{
		IRiffChunkParent Parent { get; }
		BinaryReader Reader { get; }
	}
}
