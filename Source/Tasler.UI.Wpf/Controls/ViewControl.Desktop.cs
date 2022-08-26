using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Tasler.Windows.Controls
{
	/// <summary>
	/// </summary>
	public class ViewControl : UserControl
	{
		static ViewControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ViewControl), new FrameworkPropertyMetadata(typeof(ViewControl)));
		}

		public ViewControl()
		{
			this.Loaded += (s, e) => this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
		}
	}
}
