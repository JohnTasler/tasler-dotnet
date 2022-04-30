using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;
using Tasler.ApplicationModel;
using Tasler.Windows.Extensions;

namespace Tasler.Windows
{
	public class ApplicationBroker<T> : SingletonApplicationBroker
		where T : Application, ISingletonApplicationArgumentProcessor, new()
	{
		#region Properties
		public Application Application { get; protected set; }

		public Action PreRunAction { get; set; }
		#endregion Properties

		#region Overrides

		public override long MainWindowHandle
		{
			get
			{
				if (this.Application.Dispatcher.CheckAccess())
				{
					var mainWindow = this.Application.MainWindow;

					Debug.WriteLine("ApplicationBroker.get_MainWindowHandle: this.GetHashCode()=0x" + this.GetHashCode().ToString("X8"));
					Debug.WriteLineIf(mainWindow == null, "ApplicationBroker.get_MainWindowHandle: mainWindow=null");
					Debug.WriteLineIf(mainWindow != null, "ApplicationBroker.get_MainWindowHandle: mainWindow=" + mainWindow);
					Debug.WriteLineIf(mainWindow != null, "ApplicationBroker.get_MainWindowHandle: mainWindow.Dispatcher=" + mainWindow.Dispatcher);

					var source = PresentationSource.FromVisual(mainWindow) as HwndSource;
					return (source != null) ? source.Handle.ToInt64() : 0;
				}

				// Invoke through the window's dispatcher thread
				return this.Application.Dispatcher.Invoke(() => this.MainWindowHandle);
			}
		}

		public override void OnRun()
		{
			var preRunAction = this.PreRunAction;
			if (preRunAction != null)
				preRunAction();

			this.Application.Run();
		}

		public override void OnStartupFirstInstance(SingletonApplicationStartupArgs startupArgs)
		{
			this.Application = new T();
			var argumentProcessor = (ISingletonApplicationArgumentProcessor)this.Application;
			argumentProcessor.ProcessCommandLine(startupArgs);
		}

		public override void OnStartupNextInstance(SingletonApplicationStartupArgs startupArgs)
		{
			if (this.Application.Dispatcher.CheckAccess())
			{
				// Allow the Application to process the command-line arguments
				var argumentProcessor = (ISingletonApplicationArgumentProcessor)this.Application;
				argumentProcessor.ProcessCommandLine(startupArgs);
			}
			else
			{
				// Invoke through the Dispatcher
				this.Application.Dispatcher.Invoke(() => this.OnStartupNextInstance(startupArgs));
			}
		}

		#endregion Overrides
	}
}
