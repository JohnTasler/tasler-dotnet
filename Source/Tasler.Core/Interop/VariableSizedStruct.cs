using CommunityToolkit.Diagnostics;

namespace Tasler.Interop;

/// <summary>
/// A structure that specified a Header and an array of Elements.
/// </summary>
/// <typeparam name="THeader">The type of the Header</typeparam>
/// <typeparam name="TElement">The type of each element of the array.</typeparam>
public record struct VariableSizedStruct<THeader, TElement>
	where THeader : unmanaged
	where TElement : unmanaged
{
	/// <summary>
	/// Initializes a new instance of the <see cref="VariableSizedStruct{THeader, TElement}"/> class
	/// with the specified header and elements.
	/// </summary>
	/// <param name="header">The header value to assign.</param>
	/// <param name="elements">The array of elements to include in the structure.</param>
	public VariableSizedStruct(THeader header, TElement[] elements)
	{
		Guard.IsNotNull(elements);
		this.Header = header;
		this.Elements = elements;
	}

	public THeader Header { get; init; }

	public TElement[] Elements { get; init; }
}
