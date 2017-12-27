using System.Collections.Generic;
using System.Text;

namespace Tasler.Text
{
	// TODO: NEEDS_UNIT_TEST

	/// <summary>
	/// Provides extension methods for the <see cref="StringBuilder"/> class.
	/// </summary>
	public static class StringBuilderExtensions
	{
		public static StringBuilder Append(this StringBuilder @this, IEnumerable<char> characters)
		{
			foreach (var ch in characters)
				@this.Append(ch);

			return @this;
		}
	}
}
