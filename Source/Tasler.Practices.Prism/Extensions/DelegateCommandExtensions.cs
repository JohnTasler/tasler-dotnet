using Microsoft.Practices.Prism.Commands;

namespace Tasler.Practices.Prism.Extensions
{
	public static class DelegateCommandExtensions
	{
		public static void RaiseCanExecuteChanged(this DelegateCommandBase source)
		{
			if (source != null)
				source.RaiseCanExecuteChanged();
		}

		public static void RaiseCanExecuteChanged(params DelegateCommandBase[] commands)
		{
			if (commands != null)
				foreach (var command in commands)
					if (command != null)
						command.RaiseCanExecuteChanged();
		}
	}
}
