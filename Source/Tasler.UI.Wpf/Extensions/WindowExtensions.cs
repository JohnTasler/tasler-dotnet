using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Tasler.Windows.Extensions
{
	/// <summary>
	/// Provides extension methods for instances of the <see cref="Popup"/> type.
	/// </summary>
	public static class WindowExtensions
	{
		public static IEnumerable<Window> GetOwners(this Window window)
		{
			if (window != null)
			{
				var owner = window.Owner;
				while (owner != null)
				{
					yield return owner;
					owner = owner.Owner;
				}
			}
		}

		public static IEnumerable<Window> GetSelfAndOwners(this Window window)
		{
			if (window != null)
			{
				var result = new[] { window };
				return result.Concat(window.GetOwners());
			}

			return Enumerable.Empty<Window>();
		}
	}
}
