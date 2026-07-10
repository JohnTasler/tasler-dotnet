
namespace Tasler.Interop.SuppressMessage;

internal static class Justification
{
	public const string NamingStyles = "Using the same casing as the native fields.";
	public const string IUnknownNoProblem = "Since base interface is IUnknown, it should not be a problem.";
}

internal static class Category
{
	public const string Style = nameof(Style);
	public const string ComInterfaceGenerator = nameof(ComInterfaceGenerator);
}

internal static class CheckId
{
	public const string IDE1006_NamingStyles = "IDE1006:Naming Styles";
	public const string SYSLIB1230_BaseInterfaceInOtherAssembly = "SYSLIB1230:Specifying 'GeneratedComInterfaceAttribute' on an interface that has a base interface defined in another assembly is not supported";
}
