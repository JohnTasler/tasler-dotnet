using System.Windows;
using System.Windows.Markup;
using Microsoft.Extensions.Hosting;

namespace Tasler.Windows.Markup;

public class ServiceLocatorExtension : MarkupExtension
{
	public ServiceLocatorExtension(Type type)
	{
		this.Type = type;

		if (Application.Current is HostedApplication hostedApp)
		{
			this.Host = hostedApp.Host;
		}
		else
		{
			throw new InvalidOperationException(Properties.Resources.CurrentApplicationIsNotHostedApplication);
		}
	}

	public Type Type { get; set; }

	protected IHost Host { get; }

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return this.Host.Services.GetService(this.Type)
			?? throw new ArgumentException(string.Format(Properties.Resources.TypeNotRegisteredInHostFormat1, this.Type.FullName));
	}
}
