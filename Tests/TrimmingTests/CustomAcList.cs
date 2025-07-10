using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com;
using Tasler.Interop.Shell.AutoComplete;

namespace TrimmingTests;

[GeneratedComClass]
[Guid("10E82C99-4FDF-42AA-9DE6-FEF99803694A")]
public partial class CustomAcList : IEnumString, IACList
{
	private IEnumerator<string> GetStrings()
	{
		yield return "John";
		yield return "Andrew";
		yield return "Tasler";
	}

	private IEnumerator<string> _enumerator;
	private Func<string, bool>? _filter = null;

	public CustomAcList() => _enumerator = GetStrings();

	public int Next(int elementCount, [MarshalUsing(CountElementName = "elementCount"), Out] nint[] elements, out int elementsFetched)
	{
		elementsFetched = 0;
		while (elementsFetched < elementCount && _enumerator.MoveNext())
		{
			var current = _enumerator.Current;
			if (_filter is null || _filter(current))
			{
				elements[elementsFetched] = Marshal.StringToCoTaskMemUni(current);
				++elementsFetched;
			}
		}

		return elementsFetched == elementCount ? 0 : 1;
	}

	public int Skip(uint elementCount) => throw new NotImplementedException();

	public void Reset() => _enumerator = GetStrings();

	public IEnumString Clone() => new CustomAcList();

	public int Expand([MarshalAs(UnmanagedType.LPWStr)] string pszExpand)
	{
		_filter = s => s.StartsWith(pszExpand, StringComparison.CurrentCultureIgnoreCase);
		this.Reset();
		return 0;
	}
}
