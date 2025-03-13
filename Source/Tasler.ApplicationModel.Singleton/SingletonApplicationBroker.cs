using System.Diagnostics;
using System.Reflection;

namespace Tasler.ApplicationModel;

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
			var assembly = Assembly.GetEntryAssembly()!;

			string codeBase = assembly.Location;
			Uri uri = new(codeBase);
			if (uri.Scheme == "file")
			{
				Uri codeBaseUri = new(codeBase);
				executablePath = codeBaseUri.LocalPath + codeBaseUri.Fragment;
			}
			else
			{
				executablePath = uri.ToString();
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
