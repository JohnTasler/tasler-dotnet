
namespace Tasler.Interop.Shell;

public static class PersistExtensions
{
	extension(PERSIST_FOLDER_TARGET_INFO @this)
	{
		public ItemIdList PidlTargetFolder => new() { Handle = @this._pidlTargetFolder };

		public string TargetParsingName
		{
			get
			{
				unsafe
				{
					return new(@this._szTargetParsingName);
				}
			}
		}

		public string NetworkProvider
		{
			get
			{
				unsafe
				{
					return new(@this._szNetworkProvider);
				}
			}
		}
	}
}
