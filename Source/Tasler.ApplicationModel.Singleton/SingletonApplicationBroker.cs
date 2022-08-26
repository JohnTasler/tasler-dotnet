using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Permissions;
using Tasler.IO;

namespace Tasler.ApplicationModel
{
    public abstract class SingletonApplicationBroker : MarshalByRefObject
    {
        #region Construction
        #if DEBUG
        public SingletonApplicationBroker()
        {
            Debug.WriteLine("SingletonApplicationBroker.SingletonApplicationBroker: in constructor at " + DateTime.Now.ToLongTimeString());
        }

        ~SingletonApplicationBroker()
        {
            Debug.WriteLine("SingletonApplicationBroker.~SingletonApplicationBroker: in finalizer at " + DateTime.Now.ToLongTimeString());
        }
        #endif
        #endregion Construction

        #region Overrides
        public override object InitializeLifetimeService()
        {
            // Return null to indicate an infinite lifetime
            return null;
        }
        #endregion Overrides

        #region Properties
        public static string ExecutablePath
        {
            get
            {
                string executablePath;
                Assembly assembly = Assembly.GetEntryAssembly();
                Debug.Assert(assembly != null);

                string codeBase = assembly.EscapedCodeBase;
                Uri uri = new Uri(codeBase);
                if (uri.Scheme == "file")
                {
                    Uri codeBaseUri = new Uri(codeBase);
                    executablePath = codeBaseUri.LocalPath + codeBaseUri.Fragment;
                }
                else
                {
                    executablePath = uri.ToString();
                }

                uri = new Uri(executablePath);
                if (uri.Scheme == "file")
                {
                    new FileIOPermission(FileIOPermissionAccess.PathDiscovery, executablePath).Demand();
                }

                return executablePath; // TODO: Implement PathUtility.GetUniversalName(executablePath);
            }
        }
        #endregion Properties

        #region Overridables
        public virtual string UniqueName
        {
            get
            {
                string executablePath = SingletonApplicationBroker.ExecutablePath.ToLowerInvariant();
                return executablePath;
            }
        }

        public abstract long MainWindowHandle
        {
            get;
        }
        public abstract void OnStartupFirstInstance(SingletonApplicationStartupArgs startupArgs);
        public abstract void OnStartupNextInstance(SingletonApplicationStartupArgs startupArgs);
        public abstract void OnRun();
        #endregion Overridables
    }
}
