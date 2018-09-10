using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Tasler.IO
{
    // TODO: NEEDS_UNIT_TESTS

    public static class StreamExtensions
    {
        #region Methods

        public static object ReadStruct(this Stream @this, Type structType)
        {
            var size = Marshal.SizeOf(structType);

            // Read that many bytes from the specified @this
            var buffer = new byte[size];
            var bytesRead = @this.Read(buffer, 0, size);
            if (bytesRead < size)
            {
                // TODO: RESOURCE, FORMAT with stream offset, structure size, and structure type
                throw new IOException("Encountered end of @this while reading structure.");
            }

            // Marshal the bytes into the structure
            var dataStruct = default(object);
            var gch = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                var pData = gch.AddrOfPinnedObject();
                dataStruct = Marshal.PtrToStructure(pData, structType);
            }
            finally
            {
                gch.Free();
            }

            // Return the structure
            return dataStruct;
        }

        public static void ReadStruct(this Stream @this, Object structure)
        {
            var byteCount = Marshal.SizeOf(structure.GetType());
            @this.ReadStruct(structure, byteCount);
        }

        public static void ReadStruct(this Stream @this, Object structure, int byteCount)
        {
            // Read that many bytes from the specified @this
            var buffer = new byte[byteCount];
            var bytesRead = @this.Read(buffer, 0, byteCount);
            if (bytesRead < byteCount)
            {
                throw new IOException("Encountered end of @this while reading structure.");
            }

            // Marshal the bytes into the structure
            var gch = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                var pData = gch.AddrOfPinnedObject();
                Marshal.PtrToStructure(pData, structure);
            }
            finally
            {
                gch.Free();
            }
        }

        public static T[] ReadStructBlock<T>(this Stream @this, int count)
        {
            // Return an empty array if zero is specified
            if (count == 0)
            {
                return new T[0];
            }

            // Get the largest block array for the number of entries remaining
            StructureArray_Base<T> array = StructureArray_Base<T>.GetLargestBlockArray(count);

            // Read the block of structures and return it
            StreamExtensions.ReadStruct(@this, array, array.BlockSize * Marshal.SizeOf(typeof(T)));
            return array.Array;
        }

        #endregion Methods

        #region Nested Types

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private abstract class StructureArray_Base<T>
        {
            #region Abstract Methods

            public abstract T[] Array { get; }

            public abstract int BlockSize { get; }

            #endregion Abstract Methods

            #region Methods
            public static StructureArray_Base<T> GetLargestBlockArray(int count)
            {
                for (int blockArrayIndex = 0; blockArrayIndex < BlockArrays.Length; ++blockArrayIndex)
                {
                    if (count >= BlockArrays[blockArrayIndex].BlockSize)
                    {
                        return (StructureArray_Base<T>)BlockArrays[blockArrayIndex].MemberwiseClone();
                    }
                }

                throw new ArgumentException("Argument cannot be zero.", "itemsRemaining");
            }
            #endregion Methods

            #region Thread Static Fields
            [ThreadStatic]
            private static readonly StructureArray_Base<T>[] BlockArrays = new StructureArray_Base<T>[]
            {
                new StructureArray_0x8000<T>(),
                new StructureArray_0x4000<T>(),
                new StructureArray_0x2000<T>(),
                new StructureArray_0x1000<T>(),
                new StructureArray_0x0800<T>(),
                new StructureArray_0x0400<T>(),
                new StructureArray_0x0200<T>(),
                new StructureArray_0x0100<T>(),
                new StructureArray_0x0080<T>(),
                new StructureArray_0x0040<T>(),
                new StructureArray_0x0020<T>(),
                new StructureArray_0x0010<T>(),
                new StructureArray_0x0008<T>(),
                new StructureArray_0x0004<T>(),
                new StructureArray_0x0002<T>(),
                new StructureArray_0x0001<T>(),
            };
            #endregion Thread Static Fields
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x8000<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x8000;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x4000<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x4000;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x2000<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x2000;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x1000<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x1000;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x0800<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x0800;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x0400<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x0400;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x0200<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x0200;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x0100<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x0100;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x0080<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x0080;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x0040<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x0040;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x0020<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x0020;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x0010<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x0010;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x0008<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x0008;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x0004<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x0004;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x0002<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x0002;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private class StructureArray_0x0001<T> : StructureArray_Base<T>
        {
            private const int _blockSize = 0x0001;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = _blockSize)]
            public T[] Data;

            public override T[] Array { get { return this.Data; } }

            public override int BlockSize { get { return _blockSize; } }
        }

        #endregion Nested Types
    }
}
