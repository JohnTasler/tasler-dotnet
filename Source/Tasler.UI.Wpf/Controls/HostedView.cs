using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.Hosting;
using Tasler.ComponentModel.Hosting;

namespace Tasler.Windows.Controls;

/// <summary>
/// An element that can be used in the XAML of a <see cref="HostedApplication" />. This allows the use of
/// dependency injection to create the child element.
/// </summary>
public sealed class HostedView : Decorator
{
	#region Construction
	/// <summary>
	/// Initializes a new instance of the <see cref="HostedView"/> class.
	/// </summary>
	/// <exception cref="InvalidOperationException">
	/// Thrown if the <see cref="HostedView"/> is not used within a <see cref="HostedApplication"/>.
	/// </exception>
	public HostedView()
	{
		if (Application.Current is IProvideHost hostedApplication)
		{
			_host = hostedApplication.Host;
		}
		else
		{
			throw new InvalidOperationException(Properties.Resources.HostedViewMustBeUsedWithinHostedApplication);
		}
	}
	#endregion Construction

	#region Properties

	/// <summary>
	/// The <see cref="DependencyProperty"/> for the <see cref="Type"/> property.
	/// </summary>
	public static readonly DependencyProperty TypeProperty =
		DependencyPropertyFactory<HostedView>.Register<Type>(nameof(Type), OnTypePropertyChanged);

	/// <summary>
	/// Gets or sets the <see cref="Type"/> of the <see cref="UIElement"/> to contain within this element.
	/// </summary>
	/// <value>
	/// The <see cref="Type"/> of the <see cref="UIElement"/> to contain within this element."/> It will
	/// be resolved using the <see cref="IHost"/> of the current application.
	/// </value>
	public Type Type
	{
		get => (Type)GetValue(TypeProperty);
		set => SetValue(TypeProperty, value);
	}

	private static void OnTypePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var hostedView = (HostedView)d;
		hostedView.OnTypePropertyChanged((Type)e.NewValue);
	}

	private void OnTypePropertyChanged(Type newValue)
	{
		if (newValue.IsAssignableTo(typeof(UIElement)) is false)
			throw new InvalidOperationException(string.Format(
				Properties.Resources.HostedViewTypeMustBeUIElementFormat1, newValue.FullName));

		var newView = default(UIElement);

		if (newValue is not null)
		{
			if (_host.Services.GetService(newValue) is not UIElement view)
				throw new InvalidOperationException(string.Format(Properties.Resources.CouldNotResolveViewOfTypeFormat1, newValue.FullName));
			newView = view;
		}

		this.Child = newView;
		this.InvalidateMeasure();
		this.InvalidateArrange();
		this.InvalidateVisual();
	}
	#endregion Properties

	#region Private Implementation

	private IHost _host;

	#endregion Private Implementation
}
