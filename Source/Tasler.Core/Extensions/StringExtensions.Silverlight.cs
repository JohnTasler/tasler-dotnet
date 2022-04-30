using System;

namespace Tasler.Extensions
{
	public static class StringExtensions
	{
		public static string[] Split(this string source, char[] separators, int count)
		{
			return source.Split(separators, count, StringSplitOptions.None);
		}

		public static string[] Split(this string source, char[] separators, int count, StringSplitOptions options)
		{
			var split = source.Split(separators, options);
			if (split.Length > count)
				split = CombineLastElements(source, count, split);
			return split;
		}

		public static string[] Split(this string source, string[] separators, int count)
		{
			return source.Split(separators, count, StringSplitOptions.None);
		}

		public static string[] Split(this string source, string[] separators, int count, StringSplitOptions options)
		{
			var split = source.Split(separators, options);
			if (split.Length > count)
				split = CombineLastElements(source, count, split);
			return split;
		}

		private static string[] CombineLastElements(string source, int count, string[] split)
		{
			var result = new string[count];
			var charIndex = 0;
			for (var index = 0; index < count - 1; ++index)
			{
				source.IndexOf(split[index], charIndex);
				charIndex += split[index].Length + 1;
				result[index] = split[index];
			}

			charIndex = source.IndexOf(split[count - 1], charIndex);
			result[count - 1] = source.Substring(charIndex);

			return result;
		}


	}
}
