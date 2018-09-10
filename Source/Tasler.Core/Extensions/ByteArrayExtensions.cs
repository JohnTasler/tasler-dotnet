using System;
using System.Collections.Generic;

namespace Tasler
{
    // TODO: NEEDS_UNIT_TESTS

    public static class ByteArrayExtensions
    {
        public static IEnumerable<short> ToInt16(this byte[] @this)
        {
            for (int index = 0; index < @this.Length; index += 2)
                yield return BitConverter.ToInt16(@this, index);
        }

        public static int ToInt16(this byte[] bytes, short[] @this)
        {
            var bytesLength = bytes.Length;
            var shortsLength = @this.Length;

            var shortIndex = 0;
            for (var byteIndex = 0; shortIndex < shortsLength && byteIndex < bytesLength; ++shortIndex, byteIndex += 2)
                @this[shortIndex] = BitConverter.ToInt16(bytes, byteIndex);

            return shortIndex;
        }

        public static IEnumerable<ushort> ToUInt16(this byte[] @this)
        {
            for (int index = 0; index < @this.Length; index += 2)
                yield return BitConverter.ToUInt16(@this, index);
        }
    }
}
