namespace Tasler.Windows.ApplicationFramework
{
    using System;

    /// <summary>
    /// Provides the data for the <see cref="UserApplicationContext.StartupArguments"/> event
    /// </summary>
    public class StartupArgumentsEventArgs : EventArgs
    {
        bool m_newInstance;
        StringCollection m_args;
        /// <summary>
        /// Creates a new instance of the StartupArgumentsEventArgs class.
        /// </summary>
        /// <param name="args">Command line arguments to be parsed.</param>
        /// <param name="newInstance">true if a new application instance is being created.
        /// This is normally when the application is first started.</param>
        public StartupArgumentsEventArgs(string[] args, bool newInstance) 
        {
            this.m_newInstance = newInstance;
            this.m_args = new StringCollection();
            this.m_args.AddRange(args);
        }
        /// <summary>
        /// Command line arguments to be parsed.
        /// </summary>
        public StringCollection Arguments 
        {
            get 
            {
                return m_args;
            }
        }
        /// <summary>
        /// true if a new application instance is being created.
        /// This is normally when the application is first started.
        /// </summary>
        public bool NewInstance
        {
            get 
            {
                return this.m_newInstance;
            }
        }
    }

    /// <summary>
    /// Represents the method that will handle the <see cref="UserApplicationContext.StartupArguments"/> event.
    /// </summary>
    public delegate void StartupArgumentsEventHandler(object sender, StartupArgumentsEventArgs e);
}
