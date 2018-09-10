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
        private int _processId;
        private int _imitationRefCount;
        private string _previousCurrentDirectory;
        private IDictionary _previousEnvironmentVariables;
        #endregion Instance Fields

        #region Construction
        public SingletonApplicationStartupArgs(string[] args)
        {
            _processId = Process.GetCurrentProcess().Id;
            this.CommnadLineArgs = args;
            this.CommandLine = Environment.CommandLine;
            this.CurrentDirectory = Environment.CurrentDirectory;
            this.EnvironmentVariables = Environment.GetEnvironmentVariables();
        }
        #endregion Construction

        #region Properties
        public string[] CommnadLineArgs { get; }
        public string CommandLine { get; }
        public string CurrentDirectory { get; }
        public IDictionary EnvironmentVariables { get; }
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
            if (Interlocked.Increment(ref _imitationRefCount) == 1)
            {
                if (_processId != Process.GetCurrentProcess().Id)
                {
                    // Save the current working directory and change to that of the other process
                    _previousCurrentDirectory = Environment.CurrentDirectory;
                    Environment.CurrentDirectory = this.CurrentDirectory;

                    // Save the current set of environment variables and change to that of the other process
                    _previousEnvironmentVariables = EnvironmentUtility.ReplaceEnvironmentVariables(this.EnvironmentVariables);
                }
            }
        }

        private void DecrementRefCount()
        {
            if (Interlocked.Decrement(ref _imitationRefCount) == 0)
            {
                if (_processId != Process.GetCurrentProcess().Id)
                {
                    // Restore the previous working directory and process environment
                    Environment.CurrentDirectory = _previousCurrentDirectory;
                    EnvironmentUtility.ReplaceEnvironmentVariables(_previousEnvironmentVariables);
                    _previousCurrentDirectory = null;
                    _previousEnvironmentVariables = null;
                }
            }
        }
        #endregion Private Implementation

        #region Nested Types
        private class ImitationState : IDisposable
        {
            #region Instance Fields
            private SingletonApplicationStartupArgs _owner;
            #endregion Instance Fields

            #region Construction / Finalization
            public ImitationState(SingletonApplicationStartupArgs owner)
            {
                _owner = owner;
                _owner.IncrementRefCount();
            }

            ~ImitationState()
            {
                if (_owner != null)
                    this.Dispose();
            }
            #endregion Construction / Finalization

            #region IDisposable Members
            public void Dispose()
            {
                SingletonApplicationStartupArgs owner = Interlocked.Exchange(ref _owner, null);
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
            _processId = info.GetInt32("processId");
            this.CommnadLineArgs = (string[])info.GetValue("commandLineArgs", typeof(string[]));
            this.CommandLine = info.GetString("commandLine");
            this.CurrentDirectory = info.GetString("currentDirectory");
            this.EnvironmentVariables = (IDictionary)info.GetValue("environmentVariables", typeof(Hashtable));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("processId", _processId);
            info.AddValue("commandLineArgs", this.CommnadLineArgs);
            info.AddValue("commandLine", this.CommandLine);
            info.AddValue("currentDirectory", this.CurrentDirectory);
            info.AddValue("environmentVariables", this.EnvironmentVariables);
        }

        #endregion ISerializable Members
    }
}
