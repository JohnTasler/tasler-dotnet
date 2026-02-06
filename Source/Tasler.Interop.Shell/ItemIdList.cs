using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace Tasler.Interop.Shell;

public class ItemIdList : SafeCoTaskMemHandle, IList<ChildItemIdList>
{
	#region Static Fields
	public static readonly ItemIdList Null = new();
	#endregion Static Fields

	#region Construction
	public ItemIdList()
	{
	}

	public ItemIdList(ChildItemIdList childItemIdList)
			: this(ItemIdList.Null, childItemIdList)
	{
	}

	public ItemIdList(ItemIdList itemIdList, ChildItemIdList childItemIdList)
	{
		int parentByteLength = itemIdList.ByteLength - sizeof(ushort);
		int childByteLength = childItemIdList.ByteLength;
		int newLength = parentByteLength + childByteLength;

		byte[] buffer = new byte[newLength];
		if (!itemIdList.IsEmpty)
			Marshal.Copy(itemIdList.Value, buffer, 0, parentByteLength);
		Marshal.Copy(childItemIdList.Value, buffer, parentByteLength, childByteLength);
		base.SetHandle(Marshal.AllocCoTaskMem(newLength));
		Marshal.Copy(buffer, 0, base.handle, newLength);
	}

	public ItemIdList(ItemIdList itemIdList)
	{
		if (!itemIdList.IsEmpty)
		{
			int byteLength = itemIdList.ByteLength;
			byte[] buffer = new byte[byteLength];
			Marshal.Copy(itemIdList.Value, buffer, 0, byteLength);
			base.SetHandle(Marshal.AllocCoTaskMem(byteLength));
			Marshal.Copy(buffer, 0, base.handle, byteLength);
		}
	}
	#endregion Construction

	#region Properties
	public nint Value => base.handle;

	public int ByteLength => ItemIdList.GetByteLength(base.handle);

	public bool IsEmpty => ItemIdList.GetIsEmpty(base.handle);
	#endregion Properties

	#region Methods
	/// <summary>
	/// Produces a new ItemIdList containing the sequence of child identifiers up to (but not including) the final child entry; if this list has no parent entries the result is an empty ItemIdList.
	/// </summary>
	/// <returns>An ItemIdList that is a newly allocated copy of this list's parent portion; empty when this list contains no parent entries.</returns>
	public ItemIdList GetParent()
	{
		ushort cb = 0;
		int offset = 0;
		int previousOffset = 0;
		do
		{
			cb = (ushort)Marshal.ReadInt16(base.handle, offset);
			if (cb != 0)
			{
				previousOffset = offset;
				offset += cb;
			}

		} while (cb != 0);

		byte[] buffer = new byte[previousOffset + sizeof(ushort)];
		Marshal.Copy(base.handle, buffer, 0, previousOffset);

		ItemIdList parent = new() { Handle = Marshal.AllocCoTaskMem(buffer.Length) };
		Marshal.Copy(buffer, 0, parent.handle, buffer.Length);
		return parent;
	}

	/// <summary>
	/// Split this PIDL into a parent item-id list and its final child item.
	/// </summary>
	/// <param name="child">Receives the final child entry as a ChildItemIdList.</param>
	/// <returns>An ItemIdList containing all entries up to but excluding the final child. If this list is empty, returns an empty ItemIdList and sets <paramref name="child"/> to an empty ChildItemIdList.</returns>
	public ItemIdList GetParentAndChild(out ChildItemIdList child)
	{
		ushort cb = 0;
		ushort cbPrev = 0;
		int offset = 0;
		int offsetPrev = 0;
		do
		{
			cbPrev = cb;
			cb = (ushort)Marshal.ReadInt16(base.handle, offset);
			if (cb != 0)
			{
				offsetPrev = offset;
				offset += cb;
			}

		} while (cb != 0);

		byte[] buffer = new byte[cbPrev + sizeof(ushort)];
		Marshal.Copy(new nint(base.handle.ToInt64() + offsetPrev), buffer, 0, buffer.Length);
		child = new ChildItemIdList(buffer);

		buffer = new byte[offsetPrev + sizeof(ushort)];
		Marshal.Copy(base.handle, buffer, 0, offsetPrev);
		ItemIdList parent = new() { Handle = Marshal.AllocCoTaskMem(buffer.Length) };
		Marshal.Copy(buffer, 0, parent.handle, buffer.Length);
		return parent;
	}

	/// <summary>
	/// Gets the number of bytes to contain the specified item id list, including the terminating NULL.
	/// </summary>
	/// <param name="pidl"></param>
	/// <returns></returns>
	public static int GetByteLength(nint pidl)
	{
		int offset = 0;
		if (!ItemIdList.GetIsEmpty(pidl))
		{
			ushort cb;
			do
			{
				cb = (ushort)Marshal.ReadInt16(pidl, offset);
				offset += cb;

			} while (cb != 0);
		}

		return offset + sizeof(ushort);
	}

	/// <summary>
	/// Computes a hash code from the raw bytes of the item identifier list referenced by the given PIDL handle.
	/// </summary>
	/// <param name="pidl">A pointer-sized handle to the unmanaged item identifier list (PIDL) memory.</param>
	/// <returns>An integer hash code computed over the PIDL's bytes; for an empty or zero-length PIDL the hash of an empty byte sequence is returned.</returns>
	internal static int GetHashCode(nint pidl)
	{
		var hashCode = new HashCode();

		// read the bytes and combine them into the hash code.
		int byteLength = ItemIdList.GetByteLength(pidl);
		if (byteLength > 0)
		{
			unsafe
			{
				var span = new ReadOnlySpan<byte>(pidl.ToPointer(), byteLength);
				hashCode.AddBytes(span);
			}
		}

		return hashCode.ToHashCode();
	}

	/// <summary>
	/// Determines whether the unmanaged item identifier list (PIDL) is empty.
	/// </summary>
	/// <param name="pidl">A pointer to a PIDL (pointer to an SHITEMID list); may be <c>nint.Zero</c>.</param>
	/// <returns><c>true</c> if <paramref name="pidl"/> is null or represents an empty PIDL, <c>false</c> otherwise.</returns>
	internal static bool GetIsEmpty(nint pidl)
		=> (pidl == nint.Zero) || (Marshal.ReadInt16(pidl) == 0);
	#endregion Methods

	#region Equality Comparisons
	public static bool operator ==(ItemIdList pidl1, ItemIdList pidl2)
		=> ItemIdList.Equals(pidl1, pidl2);

	public static bool operator !=(ItemIdList pidl1, ItemIdList pidl2)
		=> !ItemIdList.Equals(pidl1, pidl2);

	/// <summary>
	/// Determines whether two ItemIdList instances represent the same item identifier list (PIDL).
	/// </summary>
	/// <param name="pidl1">The first ItemIdList to compare.</param>
	/// <param name="pidl2">The second ItemIdList to compare.</param>
	/// <returns>`true` if the two lists represent the same PIDL, `false` otherwise.</returns>
	public static bool Equals(ItemIdList pidl1, ItemIdList pidl2)
		=> ShellApi.NativeMethods.ILIsEqual(pidl1.Handle, pidl2.Handle);

	/// <summary>
	/// Determines whether this ItemIdList is equal to the specified ItemIdList.
	/// </summary>
	/// <param name="value">The ItemIdList to compare with this instance.</param>
	/// <returns>`true` if the lists represent the same item identifier list, `false` otherwise.</returns>
	public bool Equals(ItemIdList value) => Equals(this, value);

	public static bool operator ==(ItemIdList pidl1, ChildItemIdList pidl2)
		=> ItemIdList.Equals(pidl1, pidl2);

	public static bool operator !=(ItemIdList pidl1, ChildItemIdList pidl2)
		=> !ItemIdList.Equals(pidl1, pidl2);

	/// <summary>
	/// Determines whether the specified ItemIdList and ChildItemIdList represent the same shell item.
	/// </summary>
	/// <param name="pidl1">The parent or full item identifier list to compare.</param>
	/// <param name="pidl2">The child item identifier list to compare.</param>
	/// <returns>`true` if both identifier lists refer to the same shell item, `false` otherwise.</returns>
	public static bool Equals(ItemIdList pidl1, ChildItemIdList pidl2)
		=> ShellApi.NativeMethods.ILIsEqual(pidl1.Handle, pidl2.Handle);

	/// <summary>
	/// Determines whether this instance represents the same item identifier list as the specified ChildItemIdList.
	/// </summary>
	/// <param name="value">The ChildItemIdList to compare with the current instance.</param>
	/// <returns>`true` if the two represent the same item identifier list, `false` otherwise.</returns>
	public bool Equals(ChildItemIdList value) => Equals(this, value);
	#endregion Equality Comparisons

	#region Overrides
	/// <summary>
	/// Determines whether the specified object represents the same item identifier list as this instance.
	/// </summary>
	/// <param name="o">An object to compare with this instance; expected to be an <see cref="ItemIdList"/> or <see cref="ChildItemIdList"/>.</param>
	/// <returns>`true` if <paramref name="o"/> is an <see cref="ItemIdList"/> or <see cref="ChildItemIdList"/> that represents the same underlying PIDL as this instance, `false` otherwise.</returns>
	public override bool Equals(object? o)
	{
		if ((o is null) || !(o is ItemIdList || o is ChildItemIdList))
			return false;

		return (o is ItemIdList list) ? Equals(this, list) : Equals(this, (ChildItemIdList)o);
	}

	/// <summary>
	/// Computes a hash code representing the underlying item identifier list.
	/// </summary>
	/// <returns>A 32-bit hash code for the contents of the underlying PIDL handle.</returns>
	public override int GetHashCode() => ItemIdList.GetHashCode(base.handle);

	/// <summary>
	/// Produces a human-readable representation of the ItemIdList and its child entries.
	/// </summary>
	/// <returns>A string starting with "ItemIdList:" followed by each child entry on its own line formatted as a two-digit hexadecimal index and the child's string representation.</returns>
	public override string ToString()
	{
		StringBuilder sb = new StringBuilder("ItemIdList:\n");
		int index = 0;
		foreach (ChildItemIdList child in this)
			using (child)
				sb.AppendFormat("  [{0:X2}] {1}\n", index++, child.ToString());
		return sb.ToString();
	}
	#endregion Overrides

	#region IList<ChildItemIdList> Members
	/// <summary>
	/// Gets the zero-based index of the specified child item within this ItemIdList.
	/// </summary>
	/// <param name="item">The child item to locate.</param>
	/// <returns>The zero-based index of <paramref name="item"/> if found; otherwise -1.</returns>
	/// <exception cref="NotImplementedException">The method is not implemented.</exception>
	public int IndexOf(ChildItemIdList item) => throw new NotImplementedException();

	/// <summary>
	/// Inserts a child item identifier into the list at the specified index.
	/// </summary>
	/// <param name="index">Zero-based position at which to insert the child item.</param>
	/// <param name="item">The child item identifier to insert.</param>
	/// <exception cref="NotImplementedException">Always thrown; insertion is not implemented.</exception>
	public void Insert(int index, ChildItemIdList item) => throw new NotImplementedException();

	/// <summary>
	/// Removal by index is not supported; this method always throws <see cref="NotImplementedException"/>.
	/// </summary>
	/// <param name="index">The zero-based index of the element to remove.</param>
	/// <exception cref="NotImplementedException">Always thrown because indexed removal is not implemented.</exception>
	public void RemoveAt(int index) => throw new NotImplementedException();

	public ChildItemIdList this[int index]
	{
		get
		{
			ushort cb = 0;
			int offset = 0;
			for (int pidlIndex = index; pidlIndex >= 0; --pidlIndex)
			{
				cb = (ushort)Marshal.ReadInt16(base.handle, offset);
				if (cb == 0)
					throw new ArgumentOutOfRangeException(nameof(index));
				if (pidlIndex > 0)
					offset += cb;
			}

			byte[] childPidl = new byte[cb + sizeof(ushort)];
			Marshal.Copy(base.handle + offset, childPidl, 0, childPidl.Length - sizeof(ushort));

			return new ChildItemIdList(childPidl);
		}
		set => throw new NotImplementedException();
	}
	#endregion IList<ChildItemIdList> Members

	#region ICollection<ChildItemIdList> Members
	/// <summary>
	/// Attempts to add a child item to the list — not supported for this read-only collection.
	/// </summary>
	/// <param name="item">The child item to add.</param>
	/// <exception cref="System.NotImplementedException">Always thrown because adding items is not implemented for ItemIdList.</exception>
	public void Add(ChildItemIdList item) => throw new NotImplementedException();

	/// <summary>
	/// Attempts to remove all child item identifiers from the list; this operation is not supported.
	/// </summary>
	/// <exception cref="System.NotImplementedException">Always thrown.</exception>
	public void Clear() => throw new NotImplementedException();

	/// <summary>
	/// Determines whether the list contains the specified child item identifier.
	/// </summary>
	/// <param name="item">The child item identifier to locate in the list.</param>
	/// <returns>`true` if the list contains the specified child item identifier, `false` otherwise.</returns>
	public bool Contains(ChildItemIdList item) => throw new NotImplementedException();

	/// <summary>
	/// Copies the child item identifier lists from this ItemIdList into the specified destination array starting at the given index.
	/// </summary>
	/// <param name="array">The destination array that receives the ChildItemIdList elements.</param>
	/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
	public void CopyTo(ChildItemIdList[] array, int arrayIndex)
	{
		foreach (ChildItemIdList item in this)
			array[arrayIndex++] = item;
	}

	public int Count
	{
		get
		{
			ushort cb = 0;
			int offset = 0;
			int count = -1;
			do
			{
				cb = (ushort)Marshal.ReadInt16(base.handle, offset);
				offset += cb;
				++count;

			} while (cb != 0);

			return count;
		}
	}

	public bool IsReadOnly => true;

	/// <summary>
	/// Attempts to remove the specified child item from the list.
	/// </summary>
	/// <param name="item">The child item to remove.</param>
	/// <returns>`true` if the item was found and removed, `false` otherwise.</returns>
	/// <exception cref="NotImplementedException">Always thrown; removal is not supported.</exception>
	public bool Remove(ChildItemIdList item) => throw new NotImplementedException();
	#endregion ICollection<ChildItemIdList> Members

	#region IEnumerable<ChildItemIdList> Members
	public IEnumerator<ChildItemIdList> GetEnumerator()
	{
		ushort cb;
		int offset = 0;
		do
		{
			cb = this.IsEmpty ? (ushort)0 : (ushort)Marshal.ReadInt16(base.handle, offset);
			if (cb != 0)
			{
				byte[] childPidl = new byte[cb + sizeof(ushort)];
				Marshal.Copy(new nint(base.handle.ToInt64() + offset), childPidl, 0, childPidl.Length - sizeof(ushort));
				yield return new ChildItemIdList(childPidl);
			}

			offset += cb;

		} while (cb != 0);
	}
	#endregion IEnumerable<ChildItemIdList> Members

	#region IEnumerable Members
	/// <summary>
	/// Provides an enumerator that iterates the child item identifiers in this ItemIdList.
	/// </summary>
	/// <returns>An <see cref="IEnumerator"/> that enumerates the <see cref="ChildItemIdList"/> elements.</returns>
	IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
	#endregion IEnumerable Members
}

public class ChildItemIdList : SafeCoTaskMemHandle
{
	#region Construction
	public ChildItemIdList(nint pidl)
	{
		base.SetHandle(pidl);
	}

	/// <summary>
	/// Creates a ChildItemIdList by allocating unmanaged memory and copying the provided SHITEMID bytes into it.
	/// </summary>
	/// <param name="array">A byte array containing a single SHITEMID (including its initial 2-byte length prefix). If null, a minimal empty SHITEMID is created.</param>
	/// <exception cref="ArgumentException">Thrown if <paramref name="array"/> has length less than 2 or greater than <see cref="ushort.MaxValue"/>.</exception>
	public ChildItemIdList(byte[] array)
	{
		// Accept a null array argument
		if (array is null)
		{
			array = new byte[sizeof(ushort)];
			BitConverter.TryWriteBytes(array, sizeof(ushort));
		}
		else
		{
			// Validate the array length
			if (array.Length < sizeof(ushort))
				throw new ArgumentException($"Array argument's Length is too small to be a SHITEMID. Length={array.Length}", nameof(array));
			if (array.Length > ushort.MaxValue)
				throw new ArgumentException("Array argument's Length is too large to be a SHITEMID. Length={array.Length}", nameof(array));
		}

		// Allocate the unmanaged memory
		base.SetHandle(Marshal.AllocCoTaskMem(array.Length));

		// Copy the item data
		Marshal.Copy(array, 0, base.handle, array.Length);

		//// Write the terminating null length
		//Marshal.WriteInt16(base.handle, array.Length + sizeof(ushort), 0);
	}
	#endregion Construction

	#region Properties
	public nint Value => base.handle;

	public int ByteLength => ItemIdList.GetByteLength(base.handle);
	#endregion Properties

	#region Methods
	public byte[] ToArray(bool includeByteCountPrefix)
	{
		int offset = includeByteCountPrefix ? 0 : sizeof(ushort);
		int byteLength = this.ByteLength - offset;
		byte[] bytes = new byte[byteLength];
		Marshal.Copy(new nint(base.handle.ToInt64() + offset), bytes, 0, byteLength);
		return bytes;
	}
	#endregion Methods

	#region Equality Comparisons
	public static bool operator ==(ChildItemIdList pidl1, ChildItemIdList pidl2)
		=> ChildItemIdList.Equals(pidl1, pidl2);

	public static bool operator !=(ChildItemIdList pidl1, ChildItemIdList pidl2)
		=> !ChildItemIdList.Equals(pidl1, pidl2);

	/// <summary>
	/// Determines whether two child item identifier lists represent the same item.
	/// </summary>
	/// <param name="pidl1">The first child item identifier list to compare.</param>
	/// <param name="pidl2">The second child item identifier list to compare.</param>
	/// <returns>`true` if both child item identifier lists represent the same item identifier list; `false` otherwise.</returns>
	public static bool Equals(ChildItemIdList pidl1, ChildItemIdList pidl2)
		=> ShellApi.NativeMethods.ILIsEqual(pidl1.Handle, pidl2.Handle);

	/// <summary>
	/// Determines whether this instance represents the same item identifier list as the specified ChildItemIdList.
	/// </summary>
	/// <param name="value">The ChildItemIdList to compare with the current instance.</param>
	/// <returns>`true` if the two represent the same item identifier list, `false` otherwise.</returns>
	public bool Equals(ChildItemIdList value) => Equals(this, value);

	public static bool operator ==(ChildItemIdList pidl1, ItemIdList pidl2)
		=> ItemIdList.Equals(pidl1, pidl2);

	public static bool operator !=(ChildItemIdList pidl1, ItemIdList pidl2)
		=> !ItemIdList.Equals(pidl1, pidl2);

	/// <summary>
	/// Determine whether a ChildItemIdList and an ItemIdList represent the same item identifier list.
	/// </summary>
	/// <param name="pidl1">The child item identifier list to compare.</param>
	/// <param name="pidl2">The item identifier list to compare against.</param>
	/// <returns>`true` if both arguments represent the same item identifier list, `false` otherwise.</returns>
	public static bool Equals(ChildItemIdList pidl1, ItemIdList pidl2)
		=> ShellApi.NativeMethods.ILIsEqual(pidl1.Handle, pidl2.Handle);

	/// <summary>
	/// Determines whether this ItemIdList is equal to the specified ItemIdList.
	/// </summary>
	/// <param name="value">The ItemIdList to compare with this instance.</param>
	/// <returns>`true` if the lists represent the same item identifier list, `false` otherwise.</returns>
	public bool Equals(ItemIdList value) => Equals(this, value);
	#endregion Equality Comparisons

	#region Overrides
	/// <summary>
	/// Determines whether this instance represents the same item identifier list as another object.
	/// </summary>
	/// <param name="o">The object to compare with this instance; expected to be an ItemIdList or ChildItemIdList.</param>
	/// <returns>`true` if <paramref name="o"/> is an ItemIdList or ChildItemIdList that represents the same PIDL as this instance, `false` otherwise.</returns>
	public override bool Equals(object? o)
	{
		if ((o == null) || !(o is ItemIdList || o is ChildItemIdList))
			return false;

		return (o is ItemIdList) ? Equals(this, (ItemIdList)o) : Equals(this, (ChildItemIdList)o);
	}

	/// <summary>
	/// Computes a hash code representing the underlying item identifier list.
	/// </summary>
	/// <returns>A 32-bit hash code for the contents of the underlying PIDL handle.</returns>
	public override int GetHashCode() => ItemIdList.GetHashCode(base.handle);

	/// <summary>
	/// Produces a hex-formatted string of the pidl bytes enclosed in braces.
	/// </summary>
	/// <returns>The pidl bytes as two-digit hex pairs separated by spaces and wrapped in braces (for example "{ 01 AF 00 }").</returns>
	public override string ToString()
	{
		StringBuilder sb = new ("{", this.ByteLength * 3 + 3);
		foreach (byte b in this.ToArray(true))
			sb.AppendFormat(" {0:X2}", b);
		sb.Append(" }");
		return sb.ToString();
	}
	#endregion Overrides
}
