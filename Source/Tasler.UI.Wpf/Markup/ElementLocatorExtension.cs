using System.Windows;
using System.Windows.Markup;

namespace Tasler.Windows.Markup;

[MarkupExtensionReturnType(typeof(FrameworkElement))]
public class ElementLocatorExtension : ServiceLocatorExtension
{
	public ElementLocatorExtension(Type type)
		: base(type)
	{
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return this.Host.Services.GetService(this.Type)
			?? throw new ArgumentException(string.Format(Properties.Resources.TypeNotRegisteredInHostFormat1, this.Type.FullName));
	}
}
