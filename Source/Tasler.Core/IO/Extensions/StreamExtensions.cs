using System.Runtime.InteropServices;
using CommunityToolkit.Diagnostics;
using Tasler.Extensions;
using Tasler.Interop;

namespace Tasler.IO;

// TODO: NEEDS_UNIT_TESTS

public static class StreamExtensions
{
	#region Methods

	/// <summary>
	/// Reads a fixed-size structure from the specified by <paramref name="this"/> <see cref="Stream"/>.
	/// </summary>
	/// <typeparam name="T">The type of the structure</typeparam>
	/// <param name="this">The this.</param>
	/// <param name="value">Specifies where to read the structure value.</param>
	/// <returns>The byte count of a single <typeparamref name="T"/>.</returns>
	public static int ReadStructCore<T>(this Stream @this, out T value)
		where T : unmanaged
	{
		Guard.IsNotNull(@this);
		Guard.CanRead(@this);

		value = new T();
		var singleStructureSpan = MemoryMarshal.CreateSpan(ref value, 1);
		@this.ReadExactly(MemoryMarshal.AsBytes(singleStructureSpan));

		return singleStructureSpan.Length;
	}

	/// <summary>
	/// Reads a fixed-size structure from the specified by <paramref name="this"/> <see cref="Stream"/>.
	/// </summary>
	/// <typeparam name="T">The type of the structure</typeparam>
	/// <param name="this">The <see cref="Stream"/> from which to read the structure.</param>
	/// <param name="value">Specifies into where to read the structure value.</param>
	/// <returns>The byte count of a single <typeparamref name="T"/>.</returns>
	public static int ReadStruct<T>(this Stream @this, out T value)
		where T : unmanaged
	{
		Guard.IsNotNull(@this);
		Guard.CanRead(@this);

		value = new T();
		var singleStructureSpan = MemoryMarshal.CreateSpan(ref value, 1);
		@this.ReadExactly(MemoryMarshal.AsBytes(singleStructureSpan));

		return singleStructureSpan.Length;
	}

	/// <summary>
	/// Reads a fixed-size structure from the specified by <paramref name="this"/> <see cref="Stream"/>.
	/// </summary>
	/// <typeparam name="T">The type of the structure</typeparam>
	/// <param name="this">The <see cref="Stream"/> from which to read the structure.</param>
	/// <param name="byteCount">Specifies where to store the structure byte count.</param>
	/// <returns>
	///   An instance of the <typeparamref name="T"/> structure that was read from the <see cref="Stream"/>.
	/// </returns>
	public static T ReadStruct<T>(this Stream @this, out int byteCount)
		where T : unmanaged
	{
		T value = new();
		byteCount = @this.ReadStructCore(out value);
		return value;
	}

	/// <summary>
	/// Reads a fixed-size structure from the specified by <paramref name="this"/> <see cref="Stream"/>.
	/// </summary>
	/// <typeparam name="T">The type of the structure</typeparam>
	/// <param name="this">The <see cref="Stream"/> from which to read the structure.</param>
	/// <returns>
	///   An instance of the <typeparamref name="T"/> structure that was read from the <see cref="Stream"/>.
	/// </returns>
	public static T ReadStruct<T>(this Stream @this) where T : unmanaged
		=> ReadStruct<T>(@this, out int _);

	/// <summary>
	/// Reads a variable sized structure. See the remarks for the details.
	/// </summary>
	/// <typeparam name="TFixed">The type of the fixed portion of the structure.</typeparam>
	/// <typeparam name="TVariable">The type of the repeating element</typeparam>
	/// <param name="this">The this.</param>
	/// <param name="elementCountSelector">The function that selects the number of variable items.</param>
	/// <returns></returns>
	/// <remarks>
	/// For most variable sized structures, the first part of the structure is a fixed size and contains a
	/// count of the number of repeating elements that immediately follow the fixed sized structure. This
	/// method will read the fixed portion of the structure, and then callback to the provided function to
	/// determine how many repeating elements there are.
	/// </remarks>
	public static VariableSizedStruct<TFixed, TVariable> ReadVariableSizedStruct<TFixed, TVariable>(
		this Stream @this, Func<TFixed, int> elementCountSelector)
			where TFixed : unmanaged
			where TVariable : unmanaged
	{
		// Read the header structure
		int headerByteCount = @this.ReadStruct(out TFixed header);

		// Use the selector to determine how many elements there are
		int elementCount = elementCountSelector(header);

		// Get the size of one element structure
		int elementByteCount = UnmanagedExtensions.GetSize<TVariable>();

		// Compute the byte count of all the elements
		var elementsByteCount = elementCount * elementByteCount;
		Guard.IsGreaterThanOrEqualTo(elementsByteCount, headerByteCount, nameof(elementsByteCount));

		// Allocate a buffer large enough for all of the elements
		var elementBuffer = new TVariable[elementCount];

		// Read each element struct into the buffer
		unsafe
		{
			fixed (TVariable* pElements = elementBuffer)
			{
				for (int i = 0; i < elementCount; ++i)
				{
					@this.ReadStruct(out pElements[i]);
				}
			}
		}

		// Return the variable sized structure containing the header and elements
		return new(header, elementBuffer);
	}

	#endregion Methods
}
