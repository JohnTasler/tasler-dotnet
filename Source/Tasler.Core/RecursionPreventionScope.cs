
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

	public static RecursionPreventionScope GetScope(ref bool flag)
	{
		return flag ? default(RecursionPreventionScope) : new RecursionPreventionScope(ref flag);
	}

	private RecursionPreventionScope(ref bool flag)
	{
		flag = true;
		_flag = ref flag;
	}

	public bool IsInScope
	{
		get
		{
			unsafe
			{
				fixed (bool* pLeft = &_flag)
					return pLeft == null;
			}
		}
	}

	void IDisposable.Dispose()
	{
		if (!IsInScope)
			_flag = false;
	}
}
