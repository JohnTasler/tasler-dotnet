using System.Text;
using System.Text.RegularExpressions;

namespace Tasler.Text.RegularExpressions
{
	// TODO: NEEDS_UNIT_TESTS

	public static class RegexUtility
	{
		#region Methods
		public static Regex CharsToRegex(char[] chars)
		{
			var pattern = new StringBuilder(chars.Length * 2 + 2);
			pattern.Append('[');
			foreach (char c in chars)
				pattern.Append('\\').Append(c);
			pattern.Append(']');
			return new Regex(pattern.ToString());
		}
		#endregion Methods
	}
}
