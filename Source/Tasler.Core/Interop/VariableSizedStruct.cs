namespace Tasler.Interop;

public class VariableSizedStruct<THeader, TElement>
	where THeader : unmanaged
	where TElement : unmanaged
{
	/// <summary>
	/// Initializes a new instance of the <see cref="VariableSizedStruct{THeader, TElement}"/> class with the specified header and elements.
	/// </summary>
	/// <param name="header">The header value to assign.</param>
	/// <param name="elements">The array of elements to include in the structure.</param>
	public VariableSizedStruct(THeader header, TElement[] elements)
	{
		this.Header = header;
		this.Elements = elements;
	}

	public THeader Header { get; init; }

	public TElement[] Elements { get; init; }
}
