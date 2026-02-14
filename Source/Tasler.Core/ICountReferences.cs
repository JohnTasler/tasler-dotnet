namespace Tasler;

/// <summary>
/// Indicates that the implementation keeps a reference count.
/// </summary>
public interface ICountReferences
{
	/// <summary>
	/// Increments the reference count of the implementation. Other than the increment (returning 1
	/// for the first call), nothing else is implied by calling this method. In other words the usage
	/// is caller/callee defined. Threading issues and resource lifecycle are not handled in any
	/// particular way.
	/// </summary>
	/// <returns>
	/// The reference count after the method executes. This will be 1 for the first call, or any
	/// positive integer count.
	/// </returns>
	int Add();

	/// <summary>
	/// Decrements the reference count of the implementation. Other than the decrement (returning 0
	/// for the last call), nothing else is implied by calling this method. In other words the usage
	/// is caller/callee defined. Threading issues and resource lifecycle are not handled in any
	/// particular way.
	/// </summary>
	/// <returns>
	/// The reference count after the method executes. This will never be less than zero.
	/// </returns>
	int Release();
}
