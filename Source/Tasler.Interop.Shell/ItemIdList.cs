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
	public nint Value
	{
		get { return base.handle; }
	}

	public int ByteLength
	{
		get { return ItemIdList.GetByteLength(base.handle); }
	}

	public bool IsEmpty
	{
		get { return ItemIdList.GetIsEmpty(base.handle); }
	}
	#endregion Properties

	#region Methods
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

		ItemIdList parent = new ItemIdList();
		parent.SetHandle(Marshal.AllocCoTaskMem(buffer.Length));
		Marshal.Copy(buffer, 0, parent.handle, buffer.Length);
		return parent;
	}

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
		ItemIdList parent = new ItemIdList();
		parent.SetHandle(Marshal.AllocCoTaskMem(buffer.Length));
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

	internal static int GetHashCode(nint pidl)
	{
		int hashCode = 0;
		if (!ItemIdList.GetIsEmpty(pidl))
		{
			int byteLength = ItemIdList.GetByteLength(pidl);
			int intCount = byteLength / sizeof(int);
			int byteCount = byteLength % sizeof(int);

			int[] ints = new int[intCount];
			Marshal.Copy(pidl, ints, 0, intCount);
			for (int index = 0; index < intCount; ++index)
				hashCode ^= ints[index];
			for (int index = 0; index < byteCount; ++index)
				hashCode ^= Marshal.ReadByte(pidl, index) << (index * 8);
		}
		return hashCode;
	}

	internal static bool GetIsEmpty(nint pidl)
	{
		return (pidl == nint.Zero) || (Marshal.ReadInt16(pidl) == 0);
	}
	#endregion Methods

	#region Equality Comparisons
	public static bool operator ==(ItemIdList pidl1, ItemIdList pidl2)
	{
		return ItemIdList.Equals(pidl1, pidl2);
	}

	public static bool operator !=(ItemIdList pidl1, ItemIdList pidl2)
	{
		return !ItemIdList.Equals(pidl1, pidl2);
	}

	public static bool Equals(ItemIdList pidl1, ItemIdList pidl2)
	{
		return ShellApi.ILIsEqual(pidl1, pidl2);
	}

	public bool Equals(ItemIdList value)
	{
		return Equals(this, value);
	}

	public static bool operator ==(ItemIdList pidl1, ChildItemIdList pidl2)
	{
		return ItemIdList.Equals(pidl1, pidl2);
	}

	public static bool operator !=(ItemIdList pidl1, ChildItemIdList pidl2)
	{
		return !ItemIdList.Equals(pidl1, pidl2);
	}

	public static bool Equals(ItemIdList pidl1, ChildItemIdList pidl2)
	{
		return ShellApi.ILIsEqual(pidl1, pidl2);
	}

	public bool Equals(ChildItemIdList value)
	{
		return Equals(this, value);
	}
	#endregion Equality Comparisons

	#region Overrides
	public override bool Equals(object? o)
	{
		if ((o is null) || !(o is ItemIdList || o is ChildItemIdList))
			return false;

		return (o is ItemIdList list) ? Equals(this, list) : Equals(this, (ChildItemIdList)o);
	}

	public override int GetHashCode()
	{
		return ItemIdList.GetHashCode(base.handle);
	}

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
	public int IndexOf(ChildItemIdList item)
	{
		throw new NotImplementedException();
	}

	public void Insert(int index, ChildItemIdList item)
	{
		throw new NotImplementedException();
	}

	public void RemoveAt(int index)
	{
		throw new NotImplementedException();
	}

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
			Marshal.Copy(new nint(base.handle.ToInt64() + offset), childPidl, 0, childPidl.Length - sizeof(ushort));

			return new ChildItemIdList(childPidl);
		}
		set
		{
			throw new NotImplementedException();
		}
	}
	#endregion IList<ChildItemIdList> Members

	#region ICollection<ChildItemIdList> Members
	public void Add(ChildItemIdList item)
	{
		throw new NotImplementedException();
	}

	public void Clear()
	{
		throw new NotImplementedException();
	}

	public bool Contains(ChildItemIdList item)
	{
		throw new NotImplementedException();
	}

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

	public bool IsReadOnly
	{
		get
		{
			return true;
		}
	}

	public bool Remove(ChildItemIdList item)
	{
		throw new NotImplementedException();
	}
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
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}
	#endregion IEnumerable Members
}

public class ChildItemIdList : SafeCoTaskMemHandle
{
	#region Construction
	public ChildItemIdList(nint pidl)
	{
		base.SetHandle(pidl);
	}

	public ChildItemIdList(byte[] array)
	{
		// Accept a null array argument
		array ??= new byte[sizeof(ushort)];

		// Validate the array length
		if (array.Length < sizeof(ushort))
			throw new ArgumentException($"Array argument's Length is too small to be a SHITEMID. Length={array.Length}", nameof(array));
		if (array.Length > ushort.MaxValue)
			throw new ArgumentException("Array argument's Length is too large to be a SHITEMID. Length={array.Length}", nameof(array));

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
	{
		return ChildItemIdList.Equals(pidl1, pidl2);
	}

	public static bool operator !=(ChildItemIdList pidl1, ChildItemIdList pidl2)
	{
		return !ChildItemIdList.Equals(pidl1, pidl2);
	}

	public static bool Equals(ChildItemIdList pidl1, ChildItemIdList pidl2)
	{
		return ShellApi.ILIsEqual(pidl1, pidl2);
	}

	public bool Equals(ChildItemIdList value)
	{
		return Equals(this, value);
	}

	public static bool operator ==(ChildItemIdList pidl1, ItemIdList pidl2)
	{
		return ItemIdList.Equals(pidl1, pidl2);
	}

	public static bool operator !=(ChildItemIdList pidl1, ItemIdList pidl2)
	{
		return !ItemIdList.Equals(pidl1, pidl2);
	}

	public static bool Equals(ChildItemIdList pidl1, ItemIdList pidl2)
	{
		return ShellApi.ILIsEqual(pidl1, pidl2);
	}

	public bool Equals(ItemIdList value)
	{
		return Equals(this, value);
	}
	#endregion Equality Comparisons

	#region Overrides
	public override bool Equals(object o)
	{
		if ((o == null) || !(o is ItemIdList || o is ChildItemIdList))
			return false;

		return (o is ItemIdList) ? Equals(this, (ItemIdList)o) : Equals(this, (ChildItemIdList)o);
	}

	public override int GetHashCode()
	{
		return ItemIdList.GetHashCode(base.handle);
	}

	public override string ToString()
	{
		StringBuilder sb = new ("{");
		foreach (byte b in this.ToArray(true))
			sb.AppendFormat(" {0:X2}", b);
		sb.Append(" }");
		return sb.ToString();
	}
	#endregion Overrides
}
