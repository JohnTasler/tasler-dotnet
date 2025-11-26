using System.Runtime.CompilerServices;

namespace Tasler;

/// <summary>
/// Encapsulates the pattern of preventing a recursive call into a method by setting a
/// <see langword="bool"/> to true for the remainder of the scope.
/// </summary>
/// <example>
///   partial void OnTextChanged(string oldValue, string newValue)
///   {
///     using var textChangeScope = RecursionPreventionScope.GetScope(ref _isInTextChange);
///     if (textChangeScope.IsInScope)
///       return;
///
///     this.Text = "something else"; // Because of the recursion prevention the processing after
///                                   // the <see langword="if"/> statement above will not occur again.
/// </example>
/// <seealso cref="System.IDisposable" />
public readonly ref struct RecursionPreventionScope : IDisposable
{
	private readonly ref bool _flag;

	/// <summary>
	/// Gets a recursion scope, controlled by a caller-provided flag.
	/// </summary>
	/// <param name="flag">A reference to the caller-provided flag.</param>
	/// <returns>
	/// A <see cref="RecursionPreventionScope"/> to be used in a <see langword="using"/> statement or
	/// manually disposed.
	/// <summary>
	/// Creates a recursion-prevention scope by setting the provided flag to true if it is not already set.
	/// </summary>
	/// <param name="flag">The caller-owned boolean that will be set to true for the lifetime of the returned scope.</param>
	/// <returns>An active RecursionPreventionScope that set <paramref name="flag"/> to true, or a default (inactive) scope if the flag was already true.</returns>
	public static RecursionPreventionScope GetScope(ref bool flag)
	{
		return flag ? default(RecursionPreventionScope) : new RecursionPreventionScope(ref flag);
	}

	/// <summary>
	/// Initializes an active recursion-prevention scope by setting the provided flag to true and capturing a reference to it.
	/// </summary>
	/// <param name="flag">The caller's recursion flag to activate and retain by reference for the scope's lifetime.</param>
	private RecursionPreventionScope(ref bool flag)
	{
		flag = true;
		_flag = ref flag;
	}

	/// <summary>Gets a value indicating whether this instance is in scope.</summary>
	/// <value>
	/// <see langword="true"/> if this instance is in scope; otherwise, <see langword="false"/>.
	/// </value>
	public bool IsInScope => !Unsafe.IsNullRef(ref _flag) && _flag;

	/// <summary>
	/// Clears the caller's recursion-prevention flag when this scope is not active.
	/// </summary>
	/// <remarks>
	/// If the scope is active, disposal does nothing; otherwise the referenced flag is set to <c>false</c>.
	/// </remarks>
	void IDisposable.Dispose()
	{
		if (!IsInScope)
			_flag = false;
	}
}