#if WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Tasler.UI.Xaml.Extensions;
namespace Tasler.UI.Xaml.Controls;

#elif WINDOWS_WPF
using System.Windows.Controls;
using System.Windows.Input;
using Tasler.Windows.Extensions;
namespace Tasler.Windows.Controls;
#endif

/// <summary>
/// </summary>
public partial class ViewControl : UserControl
{
	public ViewControl()
	{
		this.SetDefaultStyleKey();
		this.Loaded += (s, e) => this.FocusToFirstControl();
	}

	private void FocusToFirstControl()
	{
#if WINDOWS_UWP
		var firstTabStop = this.GetSelfAndVisualDescendantsBreadthFirst()
			.OfType<Control>()
			.Where<Control>(c => c.IsTabStop && c.IsEnabled)
			.FirstOrDefault();

		if (firstTabStop is not null)
			firstTabStop.Focus(FocusState.Programmatic);
#elif WINDOWS_WPF
		this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
#endif
	}
}
