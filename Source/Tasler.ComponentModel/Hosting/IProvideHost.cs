using Microsoft.Extensions.Hosting;

namespace Tasler.ComponentModel.Hosting;

/// <summary>
/// Proides a dependency injection host for the application.
/// </summary>
public interface IProvideHost
{
		/// <summary>
		/// Gets the host for the application.
		/// </summary>
		IHost Host { get; }
}
