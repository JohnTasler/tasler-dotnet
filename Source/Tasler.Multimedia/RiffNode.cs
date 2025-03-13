using System;
using System.IO;
using System.Collections.Generic;

namespace Tasler.Multimedia 
{
	public abstract class RiffNode
	{
		#region Properties
		public abstract bool IsBigEndian { get; }
		public abstract bool IsList { get; }
		public abstract RiffNode Parent { get; }
		public abstract Stream Stream { get; }
		public abstract long DataPosition { get; }
		public abstract long DataLength { get; }

		public RiffChunk TopChunk 
		{
			get 
			{
				RiffChunk chunk = this as RiffChunk;
				while (chunk != null)
				{
					RiffChunk parentChunk = chunk.Parent as RiffChunk;
					if (parentChunk != null)
					{
						chunk = parentChunk;
					}
					else
					{
						return chunk;
					}
				}

				// Reached only if current node is not a RiffChunk
				return null;
			}
		}

		public IEnumerable<RiffChunk> SubChunks 
		{
			get 
			{
				return this.FindChunks(FourCC.Empty, FourCC.Empty, false);
			}
		}
		#endregion

		#region Methods
		public static RiffChunk GetFirst(IEnumerable<RiffChunk> enumerable) 
		{
			IEnumerator<RiffChunk> enumerator = enumerable.GetEnumerator();
			return enumerator.MoveNext() ? enumerator.Current : null;
		}

		public RiffChunk FindList(FourCC listType) 
		{
			return RiffNode.GetFirst(this.FindLists(listType));
		}

		public RiffChunk FindList(FourCC listId, FourCC listType) 
		{
			return RiffNode.GetFirst(this.FindLists(listId, listType));
		}

		public RiffChunk FindList(FourCC listType, bool traverseInto) 
		{
			return RiffNode.GetFirst(this.FindLists(listType, traverseInto));
		}

		public RiffChunk FindList(FourCC listId, FourCC listType, bool traverseInto) 
		{
			return RiffNode.GetFirst(this.FindLists(listId, listType, traverseInto));
		}

		public RiffChunk FindChunk(FourCC chunkId) 
		{
			return RiffNode.GetFirst(this.FindChunks(chunkId));
		}

		public RiffChunk FindChunk(FourCC chunkId, bool traverseInto) 
		{
			return RiffNode.GetFirst(this.FindChunks(chunkId, FourCC.Empty, traverseInto));
		}

		public RiffChunk FindChunk(FourCC chunkId, FourCC listType, bool traverseInto) 
		{
			return RiffNode.GetFirst(this.FindChunks(chunkId, listType, traverseInto));
		}

		public IEnumerable<RiffChunk> FindLists(FourCC listType) 
		{
			return this.FindChunks(FourCC.Empty, listType, true);
		}

		public IEnumerable<RiffChunk> FindLists(FourCC listType, bool traverseInto) 
		{
			return this.FindChunks(FourCC.Empty, listType, traverseInto);
		}

		public IEnumerable<RiffChunk> FindLists(FourCC listId, FourCC listType) 
		{
			return this.FindChunks(listId, listType, true);
		}

		public IEnumerable<RiffChunk> FindLists(FourCC listId, FourCC listType, bool traverseInto) 
		{
			return this.FindChunks(listId, listType, traverseInto);
		}

		public IEnumerable<RiffChunk> FindChunks(FourCC chunkId) 
		{
			return this.FindChunks(chunkId, FourCC.Empty, true);
		}

		public IEnumerable<RiffChunk> FindChunks(FourCC chunkId, bool traverseInto) 
		{
			return this.FindChunks(chunkId, FourCC.Empty, traverseInto);
		}

		public IEnumerable<RiffChunk> FindChunks(FourCC chunkId, FourCC listType, bool traverseInto) 
		{
			if (this.IsList)
			{
				long position = this.ListDataPosition;
				long endPosition = this.ListDataEndPosition;

				// Create a chunk to reuse for the iteration
				RiffChunk chunk = new RiffChunk();

				// TODO: Validate sizes and such
				do
				{
					// Initialize the chunk at the current stream position
					try
					{
						chunk.Initialize(this, position);
					}
					catch (EndOfStreamException)
					{
						break;
					}

					// Yield the current chunk to the enumerator, if it matches
					if (chunkId == FourCC.Empty || chunkId == chunk.Id)
					{
						// If the chunk is a list, yield it only if the listType matches
						if (!chunk.IsList || (listType == FourCC.Empty || listType == chunk.ListType))
						{
							yield return new RiffChunk(chunk);
						}
					}

					// If the chunk is a list, traverse into it, if specified
					if (traverseInto && chunk.IsList)
					{
						foreach (RiffChunk subChunk in chunk.FindChunks(chunkId, listType, true))
						{
							yield return subChunk;
						}
					}

					// Advance the position past the current chunk
					position += chunk.Length;

					// Move the position to a 2-byte boundary, if needed
					position += position % 2;

				} while (position < endPosition);
			}
		}
		#endregion

		#region Protected Properties
		protected abstract long ListDataPosition { get; }
		protected abstract long ListDataEndPosition { get; }
		#endregion
	}
}
