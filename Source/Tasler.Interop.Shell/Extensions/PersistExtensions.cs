namespace Tasler.Interop.Shell.Extensions;

public static class PersistExtensions
{
	/// <summary>
/// Gets an ItemIdList for the target folder with its Handle set to the underlying PIDL.
/// </summary>
/// <returns>An ItemIdList whose Handle is bound to the target folder PIDL.</returns>
///
/// <summary>
/// Gets the parsing name of the target folder.
/// </summary>
/// <returns>The target folder's parsing name as a string.</returns>
///
/// <summary>
/// Gets the network provider name associated with the target folder.
/// </summary>
/// <returns>The network provider name as a string.</returns>
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