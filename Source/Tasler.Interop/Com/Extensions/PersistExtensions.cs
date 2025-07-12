
namespace Tasler.Interop.Com;

public static class PersistExtensions
{
	extension(IPersist @this)
	{
		Guid ClassID => @this.GetClassID();
	}

	extension(IPersistStream @this)
	{
		bool IsDirty => @this.IsDirty() == 0;

		ulong MaximumSize => @this.GetSizeMax();
	}

	extension(IPersistStreamInit @this)
	{
		bool IsDirty => @this.IsDirty() == 0;

		ulong MaximumSize => @this.GetSizeMax();
	}

	extension(IPersistStorage @this)
	{
		bool IsDirty => @this.IsDirty() == 0;
	}

	extension(IPersistFile @this)
	{
		bool IsDirty => @this.IsDirty() == 0;
	}

	extension(IPersistMemory @this)
	{
		bool IsDirty => @this.IsDirty() == 0;

		uint MaximumSize => @this.GetSizeMax();
	}
}
