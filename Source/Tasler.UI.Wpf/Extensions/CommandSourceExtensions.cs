using System.Windows;
using System.Windows.Input;

namespace Tasler.Windows.Extensions
{
	/// <summary>
	/// Provides extension methods for instances of classes implementing the <see cref="ICommandSource"/> interface.
	/// </summary>
	public static class CommandSourceExtensions
	{
		public static bool CanExecuteCommandSource(this ICommandSource commandSource)
		{
			var command = commandSource.Command;
			if (command == null)
				return false;

			var commandParameter = commandSource.CommandParameter;
			var commandTarget = commandSource.CommandTarget;

			var routedCommand = command as RoutedCommand;
			if (routedCommand == null)
				return command.CanExecute(commandParameter);

			commandTarget = commandTarget ?? commandSource as IInputElement;
			return routedCommand.CanExecute(commandParameter, commandTarget);
		}

		public static void ExecuteCommandSource(this ICommandSource commandSource)
		{
			var command = commandSource.Command;
			if (command != null)
			{
				var commandParameter = commandSource.CommandParameter;
				var commandTarget = commandSource.CommandTarget;
				var routedCommand = command as RoutedCommand;
				if (routedCommand != null)
				{
					commandTarget = commandTarget ?? commandSource as IInputElement;
					if (routedCommand.CanExecute(commandParameter, commandTarget))
						routedCommand.Execute(commandParameter, commandTarget);
				}
				else if (command.CanExecute(commandParameter))
				{
					command.Execute(commandParameter);
				}
			}
		}
	}
}
