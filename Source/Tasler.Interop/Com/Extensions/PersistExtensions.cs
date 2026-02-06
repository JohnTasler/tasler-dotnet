
namespace Tasler.Interop.Com;

public static class PersistExtensions
{
	/// <summary>
	/// Gets the COM object's class identifier (CLSID).
	/// </summary>
	/// <returns>The class identifier (CLSID) as a Guid.</returns>
	extension(IPersist @this)
	{
		Guid ClassID => @this.GetClassID();
	}

	extension(IPersistStream @this)
	{
		/// <summary>
		/// Indicates whether the stream has unsaved changes.
		/// </summary>
		/// <returns>`true` if the stream has unsaved changes, `false` otherwise.</returns>
		bool IsDirty => @this.IsDirty() == 0;

		/// <summary>
		/// Gets the maximum size, in bytes, required to save the stream's persistent representation.
		/// </summary>
		/// <returns>The maximum size in bytes required to save the stream's persistent representation.</returns>
		ulong MaximumSize => @this.GetSizeMax();
	}

	/// <summary>
	/// Determines whether the object managed by the COM IPersistStreamInit implementation has uncommitted changes.
	/// </summary>
	/// <returns>`true` if the object is dirty (has uncommitted changes), `false` otherwise.</returns>
	/// <summary>
	/// Gets the maximum number of bytes required to save the object according to the COM IPersistStreamInit implementation.
	/// </summary>
	/// <returns>The maximum size in bytes required to save the object.</returns>
	extension(IPersistStreamInit @this)
	{
		bool IsDirty => @this.IsDirty() == 0;

		ulong MaximumSize => @this.GetSizeMax();
	}

	extension(IPersistStorage @this)
	{
		/// <summary>
		/// Indicates whether the persistent storage object has unsaved changes.
		/// </summary>
		/// <returns>`true` if the object has unsaved changes, `false` otherwise.</returns>
		bool IsDirty => @this.IsDirty() == 0;
	}

	extension(IPersistFile @this)
	{
		/// <summary>
		/// Indicates whether the object associated with the persistent file has unsaved changes.
		/// </summary>
		/// <returns>`true` if the object has unsaved changes, `false` otherwise.</returns>
		bool IsDirty => @this.IsDirty() == 0;
	}

	extension(IPersistMemory @this)
	{
		/// <summary>
		/// Indicates whether the object has unsaved changes.
		/// </summary>
		/// <returns>`true` if the object has unsaved changes, `false` otherwise.</returns>
		bool IsDirty => @this.IsDirty() == 0;

		/// <summary>
		/// Gets the maximum number of bytes required to save the object.
		/// </summary>
		/// <returns>The maximum size in bytes.</returns>
		uint MaximumSize => @this.GetSizeMax();
	}
}
