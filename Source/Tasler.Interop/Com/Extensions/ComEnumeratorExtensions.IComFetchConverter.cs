namespace Tasler.Interop.Com.Extensions;

public static partial class ComEnumeratorExtensions
{
	/// <summary>
	/// Defines an interface with a static method to convert from a COM type to a .NET-friendly type.
	/// </summary>
	/// <typeparam name="TComItem">The type of the COM item.</typeparam>
	/// <typeparam name="TItem">The type of the .NET friendly type.</typeparam>
	public interface IComFetchConverter<TComItem, TItem>
	{
		/// <summary>
		/// Converts the specified element from a COM type to a more .NET-friendly type.
		/// </summary>
		/// <param name="element">The element to convert.</param>
		/// <summary>
/// Converts a COM element to its .NET-friendly representation.
/// </summary>
/// <param name="element">The COM item to convert.</param>
/// <returns>The converted .NET-friendly item.</returns>
		static abstract TItem Convert(TComItem element);
	}
}