using System.Windows.Controls;
using System.Windows.Input;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Controls;

/// <summary>
/// </summary>
public class ViewControl : UserControl
{
	public ViewControl()
	{
		this.SetDefaultStyleKey();
		this.Loaded += (s, e) => this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
	}
}
