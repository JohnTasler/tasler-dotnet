using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Behaviors
{
	public class ContextMenuScopeBehavior : Behavior<FrameworkElement>
	{
		protected override void OnAttached()
		{
			base.OnAttached();

			AssociatedObject.Loaded += (sender, args) =>
			{
				if (AssociatedObject.ContextMenu != null)
				{
					var scope = AssociatedObject.GetVisualAncestors().OfType<UserControl>().FirstOrDefault() ?? AssociatedObject;
					var nameScope = NameScope.GetNameScope(scope);
					NameScope.SetNameScope(AssociatedObject.ContextMenu, nameScope);
				}
			};
		}
	}
}