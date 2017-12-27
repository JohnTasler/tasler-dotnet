using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading;

namespace Tasler.ApplicationModel
{
	[Serializable]
	public class SingletonApplicationStartupArgs : EventArgs, ISerializable
	{
		#region Instance Fields
		private int processId;
		private string[] commandLineArgs;
		private string commandLine;
		private string currentDirectory;
		private IDictionary environmentVariables;
		private int imitationRefCount;
		private string previousCurrentDirectory;
		private IDictionary previousEnvironmentVariables;
		#endregion Instance Fields

		#region Construction
		public SingletonApplicationStartupArgs(string[] args)
		{
			this.processId = Process.GetCurrentProcess().Id;
			this.commandLineArgs = args;
			this.commandLine = Environment.CommandLine;
			this.currentDirectory = Environment.CurrentDirectory;
			this.environmentVariables = Environment.GetEnvironmentVariables();
		}
		#endregion Construction

		#region Properties
		public string[] CommnadLineArgs { get { return this.commandLineArgs; } }
		public string CommandLine { get { return this.commandLine; } }
		public string CurrentDirectory { get { return this.currentDirectory; } }
		public IDictionary EnvironmentVariables { get { return this.environmentVariables; } }
		#endregion Properties

		#region Methods
		public IDisposable BeginImitateStartupEnvironment()
		{
			return new ImitationState(this);
		}
		#endregion Methods

		#region Private Implementation
		private void IncrementRefCount()
		{
			if (Interlocked.Increment(ref this.imitationRefCount) == 1)
			{
				if (this.processId != Process.GetCurrentProcess().Id)
				{
					// Save the current working directory and change to that of the other process
					this.previousCurrentDirectory = Environment.CurrentDirectory;
					Environment.CurrentDirectory = this.CurrentDirectory;

					// Save the current set of environment variables and change to that of the other process
					this.previousEnvironmentVariables = EnvironmentUtility.ReplaceEnvironmentVariables(this.EnvironmentVariables);
				}
			}
		}

		private void DecrementRefCount()
		{
			if (Interlocked.Decrement(ref this.imitationRefCount) == 0)
			{
				if (this.processId != Process.GetCurrentProcess().Id)
				{
					// Restore the previous working directory and process environment
					Environment.CurrentDirectory = this.previousCurrentDirectory;
					EnvironmentUtility.ReplaceEnvironmentVariables(this.previousEnvironmentVariables);
					this.previousCurrentDirectory = null;
					this.previousEnvironmentVariables = null;
				}
			}
		}
		#endregion Private Implementation

		#region Nested Types
		private class ImitationState : IDisposable
		{
			#region Instance Fields
			private SingletonApplicationStartupArgs owner;
			#endregion Instance Fields

			#region Construction / Finalization
			public ImitationState(SingletonApplicationStartupArgs owner)
			{
				this.owner = owner;
				this.owner.IncrementRefCount();
			}

			~ImitationState()
			{
				if (this.owner != null)
					this.Dispose();
			}
			#endregion Construction / Finalization

			#region IDisposable Members
			public void Dispose()
			{
				SingletonApplicationStartupArgs owner = Interlocked.Exchange(ref this.owner, null);
				if (owner != null)
				{
					GC.SuppressFinalize(this);
					owner.DecrementRefCount();
				}
			}
			#endregion IDisposable Members
		}
		#endregion Nested Types

		#region ISerializable Members

		protected SingletonApplicationStartupArgs(SerializationInfo info, StreamingContext context)
		{
			this.processId = info.GetInt32("processId");
			this.commandLineArgs = (string[])info.GetValue("commandLineArgs", typeof(string[]));
			this.commandLine = info.GetString("commandLine");
			this.currentDirectory = info.GetString("currentDirectory");
			this.environmentVariables = (IDictionary)info.GetValue("environmentVariables", typeof(Hashtable));
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("processId", processId);
			info.AddValue("commandLineArgs", this.commandLineArgs);
			info.AddValue("commandLine", this.commandLine);
			info.AddValue("currentDirectory", this.currentDirectory);
			info.AddValue("environmentVariables", this.environmentVariables);
		}

		#endregion ISerializable Members
	}
}
