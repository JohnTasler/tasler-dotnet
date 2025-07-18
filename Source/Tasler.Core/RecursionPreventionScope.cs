
namespace Tasler;

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
