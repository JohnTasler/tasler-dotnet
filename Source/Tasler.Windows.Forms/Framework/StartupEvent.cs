namespace Tasler.Windows.ApplicationFramework
{
    using System;

    /// <summary>
    /// Provides the data for the <see cref="UserApplicationContext.Startup"/> event
    /// </summary>
    public class StartupEventArgs : EventArgs
    {
        bool m_newInstance;
        /// <summary>
        /// Creates a new instance of the StartupEventArgs class.
        /// </summary>
        /// <param name="newInstance">true if a new application instance is being created.
        /// This is normally when the application is first started.</param>
        public StartupEventArgs(bool newInstance)
        {
            this.m_newInstance = newInstance;
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
    /// Represents the method that will handle the <see cref="UserApplicationContext.Startup"/> event.
    /// </summary>
    public delegate void StartupEventHandler(object sender, StartupEventArgs e);
}
