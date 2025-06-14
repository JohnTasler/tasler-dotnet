#if WINDOWS_UWP
using Windows.Foundation;
using Windows.UI.Xaml;
namespace Tasler.UI.Xaml;
#elif WINDOWS_WPF
using System.Windows;
namespace Tasler.Windows;
#endif

// TODO: NEEDS_UNIT_TESTS

/// <summary>
/// Provides extension methods for instances of the <see cref="Thickness"/> type.
/// </summary>
public static class ThicknessExtensions
{
	public static double GetWidth(this Thickness @this) => @this.Left + @this.Right;

	public static double GetHeight(this Thickness @this) => @this.Top + @this.Bottom;

	/// <summary>
	/// Determines whether all sides of the <see cref="Thickness"/> are zero.
	/// </summary>
	/// <param name="this">The <see cref="Thickness"/> instance to check.</param>
	/// <returns><see langword="true"/> if all values are zero; otherwise, <see langword="false"/>.</returns>
	public static bool IsEmpty(this Thickness @this)
	{
		return 0.0 == @this.Left + @this.Top + @this.Right + @this.Bottom;
	}

	/// <summary>
	/// Determines whether all sides of the <see cref="Thickness"/> are <see cref="double.NaN"/>.
	/// </summary>
	/// <param name="this">The <see cref="Thickness"/> instance to check.</param>
	/// <returns><see langword="true"/> if all four sides are <see cref="double.NaN"/>; otherwise, <see langword="false"/>.</returns>
	public static bool IsNan(this Thickness @this)
	{
		return double.IsNaN(@this.Left) && double.IsNaN(@this.Top) && double.IsNaN(@this.Right) && double.IsNaN(@this.Bottom);
	}
}
