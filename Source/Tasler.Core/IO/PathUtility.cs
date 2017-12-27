using System.IO;
using System.Text.RegularExpressions;

using Tasler.Text.RegularExpressions;

namespace Tasler.IO
{
	// TODO: NEEDS_UNIT_TESTS

	public static class PathUtility
	{
		#region Methods

		public static Regex GetInvalidFileNameCharsRegex()
		{
			return RegexUtility.CharsToRegex(Path.GetInvalidFileNameChars());
		}

		public static Regex GetInvalidPathCharsRegex()
		{
			return RegexUtility.CharsToRegex(Path.GetInvalidPathChars());
		}

		// TODO: The native methods are not standard across platforms
		//
		//public static bool IsPathUnc(string path)
		//{
		//	return PathUtility.UnsafeNativeMethods.PathIsUNC(path);
		//}

		// TODO: The native methods are not standard across platforms
		//
		//public static string GetUniversalName(string localPath)
		//{
		//	string fullLocalPath = Path.GetFullPath(localPath);
		//	if (PathUtility.IsPathUnc(fullLocalPath))
		//		return fullLocalPath;
		//	int indexOfFirstSlash = fullLocalPath.IndexOf(Path.DirectorySeparatorChar);
		//	string drive = fullLocalPath.Substring(0, indexOfFirstSlash);
		//	string remoteName = PathUtility.UnsafeNativeMethods.WNetGetConnection(drive);
		//	string remotePath = remoteName + fullLocalPath.Substring(indexOfFirstSlash);
		//	return remotePath;
		//}

		#endregion Methods

		#region Nested Types
		// TODO: The native methods are not standard across platforms
		//
		//[SuppressUnmanagedCodeSecurity]
		//private static class UnsafeNativeMethods
		//{
		//	public const int ERROR_MORE_DATA = 234;
		//	public const int ERROR_NOT_CONNECTED = 2250;

		//	public static string WNetGetConnection(string localName)
		//	{
		//		StringBuilder remoteName = new StringBuilder();
		//		int length = remoteName.Capacity;
		//		int result = UnsafeNativeMethods.WNetGetConnection(localName, remoteName, ref length);
		//		if (result == UnsafeNativeMethods.ERROR_MORE_DATA)
		//		{
		//			remoteName.Capacity = length;
		//			result = UnsafeNativeMethods.WNetGetConnection(localName, remoteName, ref length);
		//		}
		//		else if (result == UnsafeNativeMethods.ERROR_NOT_CONNECTED)
		//		{
		//			return localName;
		//		}

		//		if (result != 0)
		//			throw new Win32Exception(result);

		//		return remoteName.ToString();
		//	}

		//	[DllImport("mpr.dll", CharSet = CharSet.Auto)]
		//	public static extern int
		//	WNetGetConnection(
		//		string localName,
		//		StringBuilder remoteName,
		//		ref int length);

		//	[return: MarshalAs(UnmanagedType.Bool)]
		//	[DllImport("shlwapi.dll", CharSet = CharSet.Auto)]
		//	public static extern bool
		//	PathIsUNC(
		//		string path);
		//}
		#endregion Nested Types
	}
}
