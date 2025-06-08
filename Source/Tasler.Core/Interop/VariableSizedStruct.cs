namespace Tasler.Interop;

public class VariableSizedStruct<THeader, TElement>
	where THeader : unmanaged
	where TElement : unmanaged
{
	public VariableSizedStruct(THeader header, TElement[] elements)
	{
		this.Header = header;
		this.Elements = elements;
	}

	public THeader Header { get; init; }

	public TElement[] Elements { get; init; }
}
