using System.Windows;

namespace Tasler.Windows.Extensions
{
	/// <summary>
	/// Provides extension methods useful for diagnostics.
	/// </summary>
	public static class DiagnosticExtensions
	{
		public static string FormatNameAndType(this object instance)
		{
			return instance.FormatNameAndType("<null>");
		}

		public static string FormatNameAndType(this object instance, string resultIfNull)
		{
			if (instance is null)
				return resultIfNull;

			var result = string.Empty;
			var frameworkElement = instance as FrameworkElement;
			if (frameworkElement is not null && !string.IsNullOrWhiteSpace(frameworkElement.Name))
				result = frameworkElement.Name + " ";

			result += "(" + instance.GetType().Name + ")";

			return result;
		}
	}
}
