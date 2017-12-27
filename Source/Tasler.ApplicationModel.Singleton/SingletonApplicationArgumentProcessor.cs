
namespace Tasler.ApplicationModel
{
	public interface ISingletonApplicationArgumentProcessor
	{
		void ProcessCommandLine(SingletonApplicationStartupArgs startupArgs);
	}
}
