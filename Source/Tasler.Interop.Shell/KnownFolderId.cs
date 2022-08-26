using System;
using System.Runtime.InteropServices;

namespace Tasler.Interop.Shell
{
    [StructLayout(LayoutKind.Sequential)]
    public class KnownFolderId
    {
        public Guid Guid;

        /// <summary>
        /// Initializes a new instance of the <see cref="KnownFolderId"/> structure.
        /// </summary>
        /// <param name="a">The first 4 bytes of the <see cref="Guid"/>. <seealso cref="M:fmtid"/></param>
        /// <param name="b">The next 2 bytes of the <see cref="Guid"/>. <seealso cref="M:fmtid"/></param>
        /// <param name="c">The next 2 bytes of the <see cref="Guid"/>. <seealso cref="M:fmtid"/></param>
        /// <param name="d">The next byte of the <see cref="Guid"/>. <seealso cref="M:fmtid"/></param>
        /// <param name="e">The next byte of the <see cref="Guid"/>. <seealso cref="M:fmtid"/></param>
        /// <param name="f">The next byte of the <see cref="Guid"/>. <seealso cref="M:fmtid"/></param>
        /// <param name="g">The next byte of the <see cref="Guid"/>. <seealso cref="M:fmtid"/></param>
        /// <param name="h">The next byte of the <see cref="Guid"/>. <seealso cref="M:fmtid"/></param>
        /// <param name="i">The next byte of the <see cref="Guid"/>. <seealso cref="M:fmtid"/></param>
        /// <param name="j">The next byte of the <see cref="Guid"/>. <seealso cref="M:fmtid"/></param>
        /// <param name="k">The next byte of the <see cref="Guid"/>. <seealso cref="M:fmtid"/></param>
        public KnownFolderId(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k)
        {
            this.Guid = new Guid(a, b, c, d, e, f, g, h, i, j, k);
        }
    }

    /// <summary>
    /// Specify special retrieval options for known folders.
    /// </summary>
    [Flags]
    public enum KnownFolderFlags : uint
    {
        /// <summary>
        /// No special retrieval options.
        /// </summary>
        None = 0,

        /// <summary>
        /// Forces the creation of the specified folder if that folder does not already exist.
        /// </summary>
        /// <remarks>The security provisions predefined for that folder are applied. If the folder
        /// does not exist and cannot be created, the function returns a failure code and no path
        /// is returned. This value can be used only with the following functions and methods: 
        /// <list type="bullet">
        ///   <item><term>SHGetKnownFolderPath</term></item>
        ///   <item><term>SHGetKnownFolderIDList</term></item>
        ///   <item><term>IKnownFolder::GetPath</term></item>
        ///   <item><term>IKnownFolder::GetIDList</term></item>
        /// </list>
        /// </remarks>
        Create = 0x00008000,

        /// <summary>
        /// Specifies not to verify the folder's existence before attempting to retrieve the path
        /// or IDList.
        /// </summary>
        /// <remarks>
        /// <para>If this flag is not set, an attempt is made to verify that the folder is truly
        /// present at the path. If that verification fails due to the folder being absent or
        /// inaccessible, the function returns a failure code and no path is returned.
        /// </para>
        /// <para>If the folder is located on a network, the function might take some time to
        /// execute. Setting this flag can reduce that lagtime.</para>
        /// </remarks>
        DontVerify = 0x00004000,

        /// <summary>
        /// Stores the full path in the registry without environment strings.
        /// </summary>
        /// <remarks>
        ///  If this flag is not set, portions of the path may be represented by environment
        ///  strings such as %USERPROFILE%. This flag can only be used with
        ///  SHSetKnownFolderPath and IKnownFolder::SetPath.</remarks>
        DontUnexpand = 0x00002000,

        /// <summary>
        /// Gets the true system path for the folder, free of any aliased placeholders such as
        /// %USERPROFILE%, returned by SHGetKnownFolderIDList and IKnownFolder::GetIDList.
        /// </summary>
        /// <remarks>
        /// This flag has no effect on paths returned by SHGetKnownFolderPath and
        /// IKnownFolder::GetPath. By default, known folder retrieval functions and methods
        /// return the aliased path if an alias exists.
        /// </remarks>
        NoAlias = 0x00001000,

        /// <summary>
        /// Initializes the folder using its Desktop.ini settings.
        /// </summary>
        /// <remarks>
        /// <para>If the folder cannot be initialized, the function returns a failure code and no
        /// path is returned. This flag should be combined with <see cref="Create"/>,
        /// because if the folder has not yet been created, the initialization fails because the
        /// result of <see cref="Init"/> is only a desktop.ini file, not its directory.
        /// <see cref="Create"/> | <see cref="Init"/> will always succeed.
        /// </para>
        /// <para>If the folder is located on a network, the function might take longer to execute.
        /// </para>
        /// </remarks>
        Init = 0x00000800,

        /// <summary>
        /// Gets the default path for a known folder that is redirected elsewhere.
        /// </summary>
        /// <remarks>
        /// If this flag is not set, the function retrieves the current—and possibly
        /// redirected—path of the folder. This flag includes a verification of the folder's
        /// existence unless <see cref="DontVerify"/> is also set.
        /// </remarks>
        DefaultPath = 0x00000400,

        /// <summary>
        /// Gets the folder's default path independent of the current location of its parent.
        /// </summary>
        /// <remarks><see cref="DefaultPath"/> must also be set.</remarks>
        NotParentRelative = 0x00000200,

        /// <summary>
        /// Build a simple pointer to an item identifier list (PIDL).
        /// </summary>
        SimpleIdList = 0x00000100,
    }

    /// <summary>
    /// Constants that represent GUIDs that identify standard folders registered with the system as
    /// Known Folders. These folders are installed with Windows Vista and later operating systems,
    /// and a computer will have only folders appropriate to it installed. 
    /// </summary>
    public static class KnownFolder
    {
        /// <summary>Get Programs</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Get Programs</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable-virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Add New Programs (found in the Add or Remove Programs item in the Control Panel)</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable—virtual folder</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId AddNewPrograms =
            new KnownFolderId(0xde61d971, 0x5ebc, 0x4f02, 0xa3, 0xa9, 0x6c, 0x82, 0x89, 0x5e, 0x5c, 0x04);

        /// <summary>AdminTools</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Administrative Tools</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%APPDATA%\Microsoft\Windows\Start Menu\Programs\Administrative Tools</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_ADMINTOOLS</description></item>
        ///   <item><term>Legacy Display Name</term><description>Administrative Tools</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\Start Menu\Programs\Administrative Tools</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId AdminTools =
            new KnownFolderId(0x724EF170, 0xA42D, 0x4FEF, 0x9F, 0x26, 0xB6, 0x0E, 0x84, 0x6F, 0xBA, 0x4F);

        /// <summary>AppUpdates</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Installed Updates</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>None, new in Windows Vista. In earlier versions of Microsoft Windows, the information on this page was included in Add or Remove Programs if the Show updates box was checked.</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId AppUpdates =
            new KnownFolderId(0xa305ce99, 0xf527, 0x492b, 0x8b, 0x1a, 0x7e, 0x76, 0xfa, 0x98, 0xd6, 0xe4);

        /// <summary>CDBurning</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Temporary Burn Folder</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%LOCALAPPDATA%\Microsoft\Windows\Burn\Burn</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_CDBURN_AREA</description></item>
        ///   <item><term>Legacy Display Name</term><description>CD Burning</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\Local Settings\Application Data\Microsoft\CD Burning</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId CDBurning =
            new KnownFolderId(0x9E52AB10, 0xF80D, 0x49DF, 0xAC, 0xB8, 0x43, 0x30, 0xF5, 0x68, 0x78, 0x55);

        /// <summary>ChangeRemovePrograms</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Programs and Features</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Add or Remove Programs</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable—virtual folder</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId ChangeRemovePrograms =
            new KnownFolderId(0xdf7266ac, 0x9274, 0x4867, 0x8d, 0x55, 0x3b, 0xd6, 0x61, 0xde, 0x87, 0x2d);

        /// <summary>CommonAdminTools</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Administrative Tools</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\Administrative Tools</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_COMMON_ADMINTOOLS</description></item>
        ///   <item><term>Legacy Display Name</term><description>Administrative Tools</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ALLUSERSPROFILE%\Start Menu\Programs\Administrative Tools</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId CommonAdminTools =
            new KnownFolderId(0xD0384E7D, 0xBAC3, 0x4797, 0x8F, 0x14, 0xCB, 0xA2, 0x29, 0xB3, 0x92, 0xB5);

        /// <summary>CommonOEMLinks</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>OEM Links</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%ALLUSERSPROFILE%\OEM Links</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_COMMON_OEM_LINKS</description></item>
        ///   <item><term>Legacy Display Name</term><description>OEM Links</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ALLUSERSPROFILE%\OEM Links</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId CommonOEMLinks =
            new KnownFolderId(0xC1BAE2D0, 0x10DF, 0x4334, 0xBE, 0xDD, 0x7A, 0xA2, 0x0B, 0x22, 0x7A, 0x9D);

        /// <summary>CommonPrograms</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Programs</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_COMMON_PROGRAMS</description></item>
        ///   <item><term>Legacy Display Name</term><description>Programs</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ALLUSERSPROFILE%\Start Menu\Programs</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId CommonPrograms =
            new KnownFolderId(0x0139D44E, 0x6AFE, 0x49F2, 0x86, 0x90, 0x3D, 0xAF, 0xCA, 0xE6, 0xFF, 0xB8);

        /// <summary>CommonStartMenu</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Start Menu</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%ALLUSERSPROFILE%\Microsoft\Windows\Start Menu</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_COMMON_STARTMENU</description></item>
        ///   <item><term>Legacy Display Name</term><description>Start Menu</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ALLUSERSPROFILE%\Start Menu</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId CommonStartMenu =
            new KnownFolderId(0xA4115719, 0xD62E, 0x491D, 0xAA, 0x7C, 0xE7, 0x4B, 0x8B, 0xE3, 0xB0, 0x67);

        /// <summary>CommonStartup</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Startup</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%ALLUSERSPROFILE%\Microsoft\Windows\Start Menu\Programs\StartUp</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_COMMON_STARTUP, CSIDL_COMMON_ALTSTARTUP</description></item>
        ///   <item><term>Legacy Display Name</term><description>Startup</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ALLUSERSPROFILE%\Start Menu\Programs\StartUp</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId CommonStartup =
            new KnownFolderId(0x82A5EA35, 0xD9CD, 0x47C5, 0x96, 0x29, 0xE1, 0x5D, 0x2F, 0x71, 0x4E, 0x6E);

        /// <summary>CommonTemplates</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Templates</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%ALLUSERSPROFILE%\Templates</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_COMMON_TEMPLATES</description></item>
        ///   <item><term>Legacy Display Name</term><description>Templates</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ALLUSERSPROFILE%\Templates</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId CommonTemplates =
            new KnownFolderId(0xB94237E7, 0x57AC, 0x4347, 0x91, 0x51, 0xB0, 0x8C, 0x6C, 0x32, 0xD1, 0xF7);

        /// <summary>ComputerFolder</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Computer</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_DRIVES</description></item>
        ///   <item><term>Legacy Display Name</term><description>My Computer</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable—virtual folder</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId ComputerFolder =
            new KnownFolderId(0x0AC0837C, 0xBBF8, 0x452A, 0x85, 0x0D, 0x79, 0xD0, 0x8E, 0x66, 0x7C, 0xA7);

        /// <summary>ConflictFolder</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Conflicts</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new in Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable. This KNOWNFOLDERID refers to the Windows Vista Synchronization Manager. It is not the folder referenced by the older ISyncMgrConflictFolder.</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId ConflictFolder =
            new KnownFolderId(0x4bfefb45, 0x347d, 0x4006, 0xa5, 0xbe, 0xac, 0x0c, 0xb0, 0x56, 0x71, 0x92);

        /// <summary>ConnectionsFolder</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Network Connections</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_CONNECTIONS</description></item>
        ///   <item><term>Legacy Display Name</term><description>Network Connections</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable—virtual folder</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId ConnectionsFolder =
            new KnownFolderId(0x6F0CD92B, 0x2E97, 0x45D1, 0x88, 0xFF, 0xB0, 0xD1, 0x86, 0xB8, 0xDE, 0xDD);

        /// <summary>Contacts</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Contacts</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%USERPROFILE%\Contacts</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new in Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Contacts =
            new KnownFolderId(0x56784854, 0xc6cb, 0x462b, 0x81, 0x69, 0x88, 0xe3, 0x50, 0xac, 0xb8, 0x82);

        /// <summary>ControlPanelFolder</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Control Panel</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_CONTROLS</description></item>
        ///   <item><term>Legacy Display Name</term><description>Control Panel</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable—virtual folder</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId ControlPanelFolder =
            new KnownFolderId(0x82A74AEB, 0xAEB4, 0x465C, 0xA0, 0x14, 0xD0, 0x97, 0xEE, 0x34, 0x6D, 0x63);

        /// <summary>Cookies</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Cookies</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%APPDATA%\Microsoft\Windows\Cookies</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_COOKIES</description></item>
        ///   <item><term>Legacy Display Name</term><description>Cookies</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\Cookies</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Cookies =
            new KnownFolderId(0x2B0F765D, 0xC0E9, 0x4171, 0x90, 0x8E, 0x08, 0xA6, 0x11, 0xB8, 0x4F, 0xF6);

        /// <summary>Desktop</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Desktop</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%USERPROFILE%\Desktop</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_DESKTOP, CSIDL_DESKTOPDIRECTORY</description></item>
        ///   <item><term>Legacy Display Name</term><description>Desktop</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\Desktop</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Desktop =
            new KnownFolderId(0xB4BFCC3A, 0xDB2C, 0x424C, 0xB0, 0x29, 0x7F, 0xE9, 0x9A, 0x87, 0xC6, 0x41);

        /// <summary>Documents</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Documents</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%USERPROFILE%\Documents</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_MYDOCUMENTS, CSIDL_PERSONAL</description></item>
        ///   <item><term>Legacy Display Name</term><description>My Documents</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\My Documents</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Documents =
            new KnownFolderId(0xFDD39AD0, 0x238F, 0x46AF, 0xAD, 0xB4, 0x6C, 0x85, 0x48, 0x03, 0x69, 0xC7);

        /// <summary>Downloads</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Downloads</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%USERPROFILE%\Downloads</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Downloads =
            new KnownFolderId(0x374de290, 0x123f, 0x4565, 0x91, 0x64, 0x39, 0xc4, 0x92, 0x5e, 0x46, 0x7b);

        /// <summary>Favorites</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Favorites</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%USERPROFILE%\Favorites</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_FAVORITES, CSIDL_COMMON_FAVORITES</description></item>
        ///   <item><term>Legacy Display Name</term><description>Favorites</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\Favorites</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Favorites =
            new KnownFolderId(0x1777F761, 0x68AD, 0x4D8A, 0x87, 0xBD, 0x30, 0xB7, 0x59, 0xFA, 0x33, 0xDD);

        /// <summary>Fonts</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Fonts</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%windir%\Fonts</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_FONTS</description></item>
        ///   <item><term>Legacy Display Name</term><description>Fonts</description></item>
        ///   <item><term>Legacy Default Path</term><description>%windir%\Fonts</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Fonts =
            new KnownFolderId(0xFD228CB7, 0xAE11, 0x4AE3, 0x86, 0x4C, 0x16, 0xF3, 0x91, 0x0A, 0xB8, 0xFE);

        /// <summary>Games</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Games</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Games =
            new KnownFolderId(0xcac52c1a, 0xb53d, 0x4edc, 0x92, 0xd7, 0x6b, 0x2e, 0x8a, 0xc1, 0x94, 0x34);

        /// <summary>GameTasks</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>GameExplorer</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%LOCALAPPDATA%\Microsoft\Windows\GameExplorer</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new in Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId GameTasks =
            new KnownFolderId(0x54fae61, 0x4dd8, 0x4787, 0x80, 0xb6, 0x9, 0x2, 0x20, 0xc4, 0xb7, 0x0);

        /// <summary>History</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>History</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%LOCALAPPDATA%\Microsoft\Windows\History</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_HISTORY</description></item>
        ///   <item><term>Legacy Display Name</term><description>History</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\Local Settings\History</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId History =
            new KnownFolderId(0xD9DC8A3B, 0xB784, 0x432E, 0xA7, 0x81, 0x5A, 0x11, 0x30, 0xA7, 0x59, 0x63);

        /// <summary>InternetCache</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Temporary Internet Files</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%LOCALAPPDATA%\Microsoft\Windows\Temporary Internet Files</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_INTERNET_CACHE</description></item>
        ///   <item><term>Legacy Display Name</term><description>Temporary Internet Files</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\Local Settings\Temporary Internet Files</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId InternetCache =
            new KnownFolderId(0x352481E8, 0x33BE, 0x4251, 0xBA, 0x85, 0x60, 0x07, 0xCA, 0xED, 0xCF, 0x9D);

        /// <summary>InternetFolder</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Internet Explorer</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_INTERNET</description></item>
        ///   <item><term>Legacy Display Name</term><description>Internet Explorer</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable—virtual folder</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId InternetFolder =
            new KnownFolderId(0x4D9F7874, 0x4E0C, 0x4904, 0x96, 0x7B, 0x40, 0xB0, 0xD2, 0x0C, 0x3E, 0x4B);

        /// <summary>Links</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Links</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%USERPROFILE%\Links</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Links =
            new KnownFolderId(0xbfb9d5e0, 0xc6a9, 0x404c, 0xb2, 0xb2, 0xae, 0x6d, 0xb6, 0xaf, 0x49, 0x68);

        /// <summary>LocalAppData</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Local</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%LOCALAPPDATA% (%USERPROFILE%\AppData\Local)</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_LOCAL_APPDATA</description></item>
        ///   <item><term>Legacy Display Name</term><description>Application Data</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\Local Settings\Application Data</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId LocalAppData =
            new KnownFolderId(0xF1B32785, 0x6FBA, 0x4FCF, 0x9D, 0x55, 0x7B, 0x8E, 0x7F, 0x15, 0x70, 0x91);

        /// <summary>LocalAppDataLow</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>LocalLow</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%USERPROFILE%\AppData\LocalLow</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId LocalAppDataLow =
            new KnownFolderId(0xA520A1A4, 0x1780, 0x4FF6, 0xBD, 0x18, 0x16, 0x73, 0x43, 0xC5, 0xAF, 0x16);

        /// <summary>LocalizedResourcesDir</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>None</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%windir%\resources\0409 (code page)</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_RESOURCES_LOCALIZED</description></item>
        ///   <item><term>Legacy Display Name</term><description>None</description></item>
        ///   <item><term>Legacy Default Path</term><description>%windir%\resources\0409 (code page)</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId LocalizedResourcesDir =
            new KnownFolderId(0x2A00375E, 0x224C, 0x49DE, 0xB8, 0xD1, 0x44, 0x0D, 0xF7, 0xEF, 0x3D, 0xDC);

        /// <summary>Music</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Music</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%USERPROFILE%\Music</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_MYMUSIC</description></item>
        ///   <item><term>Legacy Display Name</term><description>My Music</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\My Documents\My Music</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Music =
            new KnownFolderId(0x4BD8D571, 0x6D19, 0x48D3, 0xBE, 0x97, 0x42, 0x22, 0x20, 0x08, 0x0E, 0x43);

        /// <summary>NetHood</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Network Shortcuts</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%APPDATA%\Microsoft\Windows\Network Shortcuts</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_NETHOOD</description></item>
        ///   <item><term>Legacy Display Name</term><description>NetHood</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\NetHood</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId NetHood =
            new KnownFolderId(0xC5ABBF53, 0xE17F, 0x4121, 0x89, 0x00, 0x86, 0x62, 0x6F, 0xC2, 0xC9, 0x73);

        /// <summary>NetworkFolder</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Network</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_NETWORK, CSIDL_COMPUTERSNEARME</description></item>
        ///   <item><term>Legacy Display Name</term><description>My Network Places</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable—virtual folder</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId NetworkFolder =
            new KnownFolderId(0xD20BEEC4, 0x5CA8, 0x4905, 0xAE, 0x3B, 0xBF, 0x25, 0x1E, 0xA0, 0x9B, 0x53);

        /// <summary>OriginalImages</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Original Images</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%LOCALAPPDATA%\Microsoft\Windows Photo Gallery\Original Images</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new in Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId OriginalImages =
            new KnownFolderId(0x2C36C0AA, 0x5812, 0x4b87, 0xbf, 0xd0, 0x4c, 0xd0, 0xdf, 0xb1, 0x9b, 0x39);

        /// <summary>PhotoAlbums</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Slide Shows</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%USERPROFILE%\Pictures\Slide Shows</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new in Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId PhotoAlbums =
            new KnownFolderId(0x69D2CF90, 0xFC33, 0x4FB7, 0x9A, 0x0C, 0xEB, 0xB0, 0xF0, 0xFC, 0xB4, 0x3C);

        /// <summary>Pictures</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Pictures</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%USERPROFILE%\Pictures</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_MYPICTURES</description></item>
        ///   <item><term>Legacy Display Name</term><description>My Pictures</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\My Documents\My Pictures</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Pictures =
            new KnownFolderId(0x33E28130, 0x4E1E, 0x4676, 0x83, 0x5A, 0x98, 0x39, 0x5C, 0x3B, 0xC3, 0xBB);

        /// <summary>Playlists</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Playlists</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%USERPROFILE%\Music\Playlists</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Playlists =
            new KnownFolderId(0xDE92C1C7, 0x837F, 0x4F69, 0xA3, 0xBB, 0x86, 0xE6, 0x31, 0x20, 0x4A, 0x23);

        /// <summary>PrintersFolder</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Printers</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_PRINTERS</description></item>
        ///   <item><term>Legacy Display Name</term><description>Printers and Faxes</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable—virtual folder</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId PrintersFolder =
            new KnownFolderId(0x76FC4E2D, 0xD6AD, 0x4519, 0xA6, 0x63, 0x37, 0xBD, 0x56, 0x06, 0x81, 0x85);

        /// <summary>PrintHood</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Printer Shortcuts</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%APPDATA%\Microsoft\Windows\Printer Shortcuts</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_PRINTHOOD</description></item>
        ///   <item><term>Legacy Display Name</term><description>PrintHood</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\PrintHood</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId PrintHood =
            new KnownFolderId(0x9274BD8D, 0xCFD1, 0x41C3, 0xB3, 0x5E, 0xB1, 0x3F, 0x55, 0xA7, 0x58, 0xF4);

        /// <summary>Profile</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>The user's username (%USERNAME%)</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%USERPROFILE% (%SystemDrive%\Users\%USERNAME%)</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_PROFILE</description></item>
        ///   <item><term>Legacy Display Name</term><description>The user's username (%USERNAME%)</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE% (%SystemDrive%\Documents and Settings\%USERNAME%)</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Profile =
            new KnownFolderId(0x5E6C858F, 0x0E22, 0x4760, 0x9A, 0xFE, 0xEA, 0x33, 0x17, 0xB6, 0x71, 0x73);

        /// <summary>ProgramData</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>ProgramData</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%ALLUSERSPROFILE% (%ProgramData%, %SystemDrive%\ProgramData)</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_COMMON_APPDATA</description></item>
        ///   <item><term>Legacy Display Name</term><description>Application Data</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ALLUSERSPROFILE%\Application Data</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId ProgramData =
            new KnownFolderId(0x62AB5D82, 0xFDC1, 0x4DC3, 0xA9, 0xDD, 0x07, 0x0D, 0x1D, 0x49, 0x5D, 0x97);

        /// <summary>ProgramFiles</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Program Files</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%ProgramFiles% (%SystemDrive%\Program Files)</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_PROGRAM_FILES</description></item>
        ///   <item><term>Legacy Display Name</term><description>Program Files</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ProgramFiles% (%SystemDrive%\Program Files)</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId ProgramFiles =
            new KnownFolderId(0x905e63b6, 0xc1bf, 0x494e, 0xb2, 0x9c, 0x65, 0xb7, 0x32, 0xd3, 0xd2, 0x1a);

        /// <summary>ProgramFilesX64</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Program Files</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%ProgramFiles% (%SystemDrive%\Program Files)</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None </description></item>
        ///   <item><term>Legacy Display Name</term><description>Program Files</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ProgramFiles% (%SystemDrive%\Program Files)</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId ProgramFilesX64 =
            new KnownFolderId(0x6d809377, 0x6af0, 0x444b, 0x89, 0x57, 0xa3, 0x77, 0x3f, 0x02, 0x20, 0x0e);

        /// <summary>ProgramFilesX86</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Program Files</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%ProgramFiles% (%SystemDrive%\Program Files)</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_PROGRAM_FILESX86</description></item>
        ///   <item><term>Legacy Display Name</term><description>Program Files</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ProgramFiles% (%SystemDrive%\Program Files)</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId ProgramFilesX86 =
            new KnownFolderId(0x7C5A40EF, 0xA0FB, 0x4BFC, 0x87, 0x4A, 0xC0, 0xF2, 0xE0, 0xB9, 0xFA, 0x8E);

        /// <summary>ProgramFilesCommon</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Common Files</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%ProgramFiles%\Common Files</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_PROGRAM_FILES_COMMON</description></item>
        ///   <item><term>Legacy Display Name</term><description>Common Files</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ProgramFiles%\Common Files</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId ProgramFilesCommon =
            new KnownFolderId(0xF7F1ED05, 0x9F6D, 0x47A2, 0xAA, 0xAE, 0x29, 0xD3, 0x17, 0xC6, 0xF0, 0x66);

        /// <summary>ProgramFilesCommonX64</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Common Files</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%ProgramFiles%\Common Files</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Common Files</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ProgramFiles%\Common Files</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId ProgramFilesCommonX64 =
            new KnownFolderId(0x6365d5a7, 0xf0d, 0x45e5, 0x87, 0xf6, 0xd, 0xa5, 0x6b, 0x6a, 0x4f, 0x7d);

        /// <summary>ProgramFilesCommonX86</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Common Files</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%ProgramFiles%\Common Files</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_PROGRAM_FILES_COMMONX86</description></item>
        ///   <item><term>Legacy Display Name</term><description>Common Files</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ProgramFiles%\Common Files</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId ProgramFilesCommonX86 =
            new KnownFolderId(0xDE974D24, 0xD9C6, 0x4D3E, 0xBF, 0x91, 0xF4, 0x45, 0x51, 0x20, 0xB9, 0x17);

        /// <summary>Programs</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Programs</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%APPDATA%\Microsoft\Windows\Start Menu\Programs</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_PROGRAMS</description></item>
        ///   <item><term>Legacy Display Name</term><description>Programs</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\Start Menu\Programs</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Programs =
            new KnownFolderId(0xA77F5D77, 0x2E2B, 0x44C3, 0xA6, 0xA2, 0xAB, 0xA6, 0x01, 0x05, 0x4A, 0x51);

        /// <summary>Public</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Public</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%PUBLIC% (%SystemDrive%\Users\Public)</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new for Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Public =
            new KnownFolderId(0xDFDF76A2, 0xC82A, 0x4D63, 0x90, 0x6A, 0x56, 0x44, 0xAC, 0x45, 0x73, 0x85);

        /// <summary>PublicDesktop</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Public Desktop</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%PUBLIC%\Desktop</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_COMMON_DESKTOPDIRECTORY</description></item>
        ///   <item><term>Legacy Display Name</term><description>Desktop</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ALLUSERSPROFILE%\Desktop</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId PublicDesktop =
            new KnownFolderId(0xC4AA340D, 0xF20F, 0x4863, 0xAF, 0xEF, 0xF8, 0x7E, 0xF2, 0xE6, 0xBA, 0x25);

        /// <summary>PublicDocuments</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Public Documents</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%PUBLIC%\Documents</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_COMMON_DOCUMENTS</description></item>
        ///   <item><term>Legacy Display Name</term><description>Shared Documents</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ALLUSERSPROFILE%\Documents</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId PublicDocuments =
            new KnownFolderId(0xED4824AF, 0xDCE4, 0x45A8, 0x81, 0xE2, 0xFC, 0x79, 0x65, 0x08, 0x36, 0x34);

        /// <summary>PublicDownloads</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Public Downloads</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%PUBLIC%\Downloads</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new in Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId PublicDownloads =
            new KnownFolderId(0x3d644c9b, 0x1fb8, 0x4f30, 0x9b, 0x45, 0xf6, 0x70, 0x23, 0x5f, 0x79, 0xc0);

        /// <summary>PublicGameTasks</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>GameExplorer</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%ALLUSERSPROFILE%\Microsoft\Windows\GameExplorer</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new in Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId PublicGameTasks =
            new KnownFolderId(0xdebf2536, 0xe1a8, 0x4c59, 0xb6, 0xa2, 0x41, 0x45, 0x86, 0x47, 0x6a, 0xea);

        /// <summary>PublicMusic</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Public Music</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%PUBLIC%\Music</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_COMMON_MUSIC</description></item>
        ///   <item><term>Legacy Display Name</term><description>Shared Music</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ALLUSERSPROFILE%\Documents\My Music</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId PublicMusic =
            new KnownFolderId(0x3214FAB5, 0x9757, 0x4298, 0xBB, 0x61, 0x92, 0xA9, 0xDE, 0xAA, 0x44, 0xFF);

        /// <summary>PublicPictures</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Public Pictures</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%PUBLIC%\Pictures</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_COMMON_PICTURES</description></item>
        ///   <item><term>Legacy Display Name</term><description>Shared Pictures</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ALLUSERSPROFILE%\Documents\My Pictures</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId PublicPictures =
            new KnownFolderId(0xB6EBFB86, 0x6907, 0x413C, 0x9A, 0xF7, 0x4F, 0xC2, 0xAB, 0xF0, 0x7C, 0xC5);

        /// <summary>PublicVideos</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Public Videos</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%PUBLIC%\Videos</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_COMMON_VIDEO</description></item>
        ///   <item><term>Legacy Display Name</term><description>Shared Video</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ALLUSERSPROFILE%\Documents\My Videos</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId PublicVideos =
            new KnownFolderId(0x2400183A, 0x6185, 0x49FB, 0xA2, 0xD8, 0x4A, 0x39, 0x2A, 0x60, 0x2B, 0xA3);

        /// <summary>QuickLaunch</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Quick Launch</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%APPDATA%\Microsoft\Internet Explorer\Quick Launch</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Quick Launch</description></item>
        ///   <item><term>Legacy Default Path</term><description>%APPDATA%\Microsoft\Internet Explorer\Quick Launch</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId QuickLaunch =
            new KnownFolderId(0x52a4f021, 0x7b75, 0x48a9, 0x9f, 0x6b, 0x4b, 0x87, 0xa2, 0x10, 0xbc, 0x8f);

        /// <summary>Recent</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Recent Items</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%APPDATA%\Microsoft\Windows\Recent</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_RECENT</description></item>
        ///   <item><term>Legacy Display Name</term><description>My Recent Documents</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\Recent</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Recent =
            new KnownFolderId(0xAE50C081, 0xEBD2, 0x438A, 0x86, 0x55, 0x8A, 0x09, 0x2E, 0x34, 0x98, 0x7A);

        /// <summary>
        /// Not used.
        /// </summary>
        public static readonly KnownFolderId RecordedTV =
            new KnownFolderId(0xbd85e001, 0x112e, 0x431e, 0x98, 0x3b, 0x7b, 0x15, 0xac, 0x09, 0xff, 0xf1);

        /// <summary>RecycleBinFolder</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Recycle Bin</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_BITBUCKET</description></item>
        ///   <item><term>Legacy Display Name</term><description>Recycle Bin</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable—virtual folder</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId RecycleBinFolder =
            new KnownFolderId(0xB7534046, 0x3ECB, 0x4C18, 0xBE, 0x4E, 0x64, 0xCD, 0x4C, 0xB7, 0xD6, 0xAC);

        /// <summary>ResourceDir</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Resources</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%windir%\Resources</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_RESOURCES</description></item>
        ///   <item><term>Legacy Display Name</term><description>Resources</description></item>
        ///   <item><term>Legacy Default Path</term><description>%windir%\Resources</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId ResourceDir =
            new KnownFolderId(0x8AD10C31, 0x2ADB, 0x4296, 0xA8, 0xF7, 0xE4, 0x70, 0x12, 0x32, 0xC9, 0x72);

        /// <summary>RoamingAppData</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Roaming</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%APPDATA% (%USERPROFILE%\AppData\Roaming)</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_APPDATA</description></item>
        ///   <item><term>Legacy Display Name</term><description>Application Data</description></item>
        ///   <item><term>Legacy Default Path</term><description>%APPDATA% (%USERPROFILE%\Application Data)</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId RoamingAppData =
            new KnownFolderId(0x3EB685DB, 0x65F9, 0x4CF6, 0xA0, 0x3A, 0xE3, 0xEF, 0x65, 0x72, 0x9F, 0x3D);

        /// <summary>SampleMusic</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Sample Music</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%PUBLIC%\Music\Sample Music</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Sample Music</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ALLUSERSPROFILE%\Documents\My Music\Sample Music</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SampleMusic =
            new KnownFolderId(0xB250C668, 0xF57D, 0x4EE1, 0xA6, 0x3C, 0x29, 0x0E, 0xE7, 0xD1, 0xAA, 0x1F);

        /// <summary>SamplePictures</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Sample Pictures</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%PUBLIC%\Pictures\Sample Pictures</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Sample Pictures</description></item>
        ///   <item><term>Legacy Default Path</term><description>%ALLUSERSPROFILE%\Documents\My Pictures\Sample Pictures</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SamplePictures =
            new KnownFolderId(0xC4900540, 0x2379, 0x4C75, 0x84, 0x4B, 0x64, 0xE6, 0xFA, 0xF8, 0x71, 0x6B);

        /// <summary>SamplePlaylists</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Sample Playlists</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%PUBLIC%\Music\Sample Playlists</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new in Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SamplePlaylists =
            new KnownFolderId(0x15CA69B3, 0x30EE, 0x49C1, 0xAC, 0xE1, 0x6B, 0x5E, 0xC3, 0x72, 0xAF, 0xB5);

        /// <summary>SampleVideos</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Sample Videos</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%PUBLIC%\Videos\Sample Videos</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SampleVideos =
            new KnownFolderId(0x859EAD94, 0x2E85, 0x48AD, 0xA7, 0x1A, 0x09, 0x69, 0xCB, 0x56, 0xA6, 0xCD);

        /// <summary>SavedGames</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Saved Games</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%USERPROFILE%\Saved Games</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new in Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SavedGames =
            new KnownFolderId(0x4c5c32ff, 0xbb9d, 0x43b0, 0xb5, 0xb4, 0x2d, 0x72, 0xe5, 0x4e, 0xaa, 0xa4);

        /// <summary>SavedSearches</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Searches</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%USERPROFILE%\Searches</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new in Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SavedSearches =
            new KnownFolderId(0x7d1d3a04, 0xdebb, 0x4115, 0x95, 0xcf, 0x2f, 0x29, 0xda, 0x29, 0x20, 0xda);

        /// <summary>SEARCH_CSC</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Offline Files</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SEARCH_CSC =
            new KnownFolderId(0xee32e446, 0x31ca, 0x4aba, 0x81, 0x4f, 0xa5, 0xeb, 0xd2, 0xfd, 0x6d, 0x5e);

        /// <summary>SEARCH_MAPI</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Microsoft Office Outlook</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SEARCH_MAPI =
            new KnownFolderId(0x98ec0e18, 0x2098, 0x4d44, 0x86, 0x44, 0x66, 0x97, 0x93, 0x15, 0xa2, 0x81);

        /// <summary>SearchHome</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Search Results</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SearchHome =
            new KnownFolderId(0x190337d1, 0xb8ca, 0x4121, 0xa6, 0x39, 0x6d, 0x47, 0x2d, 0x16, 0x97, 0x2a);

        /// <summary>SendTo</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>SendTo</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%APPDATA%\Microsoft\Windows\SendTo</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_SENDTO</description></item>
        ///   <item><term>Legacy Display Name</term><description>SendTo</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\SendTo</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SendTo =
            new KnownFolderId(0x8983036C, 0x27C0, 0x404B, 0x8F, 0x08, 0x10, 0x2D, 0x10, 0xDC, 0xFD, 0x74);

        /// <summary>SidebarDefaultParts</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Gadgets</description></item>
        ///   <item><term>Folder Type</term><description>COMMON</description></item>
        ///   <item><term>Default Path</term><description>%ProgramFiles%\Windows Sidebar\Gadgets</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new for Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SidebarDefaultParts =
            new KnownFolderId(0x7b396e54, 0x9ec5, 0x4300, 0xbe, 0xa, 0x24, 0x82, 0xeb, 0xae, 0x1a, 0x26);

        /// <summary>SidebarParts</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Gadgets</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%LOCALAPPDATA%\Microsoft\Windows Sidebar\Gadgets</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new for Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SidebarParts =
            new KnownFolderId(0xa75d362e, 0x50fc, 0x4fb7, 0xac, 0x2c, 0xa8, 0xbe, 0xaa, 0x31, 0x44, 0x93);

        /// <summary>StartMenu</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Start Menu</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%APPDATA%\Microsoft\Windows\Start Menu</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_STARTMENU</description></item>
        ///   <item><term>Legacy Display Name</term><description>Start Menu</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\Start Menu</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId StartMenu =
            new KnownFolderId(0x625B53C3, 0xAB48, 0x4EC1, 0xBA, 0x1F, 0xA1, 0xEF, 0x41, 0x46, 0xFC, 0x19);

        /// <summary>Startup</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Startup</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%APPDATA%\Microsoft\Windows\Start Menu\Programs\StartUp</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_STARTUP, CSIDL_ALTSTARTUP</description></item>
        ///   <item><term>Legacy Display Name</term><description>Startup</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\Start Menu\Programs\StartUp</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Startup =
            new KnownFolderId(0xB97D20BB, 0xF46A, 0x4C97, 0xBA, 0x10, 0x5E, 0x36, 0x08, 0x43, 0x08, 0x54);

        /// <summary>SyncManagerFolder</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Sync Center</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new in Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SyncManagerFolder =
            new KnownFolderId(0x43668BF8, 0xC14E, 0x49B2, 0x97, 0xC9, 0x74, 0x77, 0x84, 0xD7, 0x84, 0xB7);

        /// <summary>SyncResultsFolder</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Sync Results</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new in Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SyncResultsFolder =
            new KnownFolderId(0x289a9a43, 0xbe44, 0x4057, 0xa4, 0x1b, 0x58, 0x7a, 0x76, 0xd7, 0xe7, 0xf9);

        /// <summary>SyncSetupFolder</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Sync Setup</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new in Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SyncSetupFolder =
            new KnownFolderId(0xf214138, 0xb1d3, 0x4a90, 0xbb, 0xa9, 0x27, 0xcb, 0xc0, 0xc5, 0x38, 0x9a);

        /// <summary>System</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>System32</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%windir%\system32</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_SYSTEM</description></item>
        ///   <item><term>Legacy Display Name</term><description>system32</description></item>
        ///   <item><term>Legacy Default Path</term><description>%windir%\system32</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId System =
            new KnownFolderId(0x1AC14E77, 0x02E7, 0x4E5D, 0xB7, 0x44, 0x2E, 0xB1, 0xAE, 0x51, 0x98, 0xB7);

        /// <summary>SystemX86</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>System32</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%windir%\system32</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_SYSTEMX86</description></item>
        ///   <item><term>Legacy Display Name</term><description>system32</description></item>
        ///   <item><term>Legacy Default Path</term><description>%windir%\system32</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId SystemX86 =
            new KnownFolderId(0xD65231B0, 0xB2F1, 0x4857, 0xA4, 0xCE, 0xA8, 0xE7, 0xC6, 0xEA, 0x7D, 0x27);

        /// <summary>Templates</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Templates</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%APPDATA%\Microsoft\Windows\Templates</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_TEMPLATES</description></item>
        ///   <item><term>Legacy Display Name</term><description>Templates</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\Templates</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Templates =
            new KnownFolderId(0xA63293E8, 0x664E, 0x48DB, 0xA0, 0x79, 0xDF, 0x75, 0x9E, 0x05, 0x09, 0xF7);

        /// <summary>TreeProperties</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Tree property value folder</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId TreeProperties =
            new KnownFolderId(0x5b3749ad, 0xb49f, 0x49c1, 0x83, 0xeb, 0x15, 0x37, 0x0f, 0xbd, 0x48, 0x82);

        /// <summary>UserProfiles</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Users</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%SystemDrive%\Users</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None, new for Windows Vista</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId UserProfiles =
            new KnownFolderId(0x0762D272, 0xC50A, 0x4BB0, 0xA3, 0x82, 0x69, 0x7D, 0xCD, 0x72, 0x9B, 0x80);

        /// <summary>UsersFiles</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>The user's full name (for instance, Jean Philippe Bagel) entered when the user account was created.</description></item>
        ///   <item><term>Folder Type</term><description>VIRTUAL</description></item>
        ///   <item><term>Default Path</term><description>Not applicable—virtual folder</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>None</description></item>
        ///   <item><term>Legacy Display Name</term><description>Not applicable</description></item>
        ///   <item><term>Legacy Default Path</term><description>Not applicable</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId UsersFiles =
            new KnownFolderId(0xf3ce0f7c, 0x4901, 0x4acc, 0x86, 0x48, 0xd5, 0xd4, 0x4b, 0x04, 0xef, 0x8f);

        /// <summary>Videos</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Videos</description></item>
        ///   <item><term>Folder Type</term><description>PERUSER</description></item>
        ///   <item><term>Default Path</term><description>%USERPROFILE%\Videos</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_MYVIDEO</description></item>
        ///   <item><term>Legacy Display Name</term><description>My Videos</description></item>
        ///   <item><term>Legacy Default Path</term><description>%USERPROFILE%\My Documents\My Videos</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Videos =
            new KnownFolderId(0x18989B1D, 0x99B5, 0x455B, 0x84, 0x1C, 0xAB, 0x7C, 0x74, 0xE4, 0xDD, 0xFC);

        /// <summary>Windows</summary>
        /// <remarks>
        /// <list type="table">
        ///   <item><term>Display Name</term><description>Windows</description></item>
        ///   <item><term>Folder Type</term><description>FIXED</description></item>
        ///   <item><term>Default Path</term><description>%windir%</description></item>
        ///   <item><term>CSIDL Equivalent</term><description>CSIDL_WINDOWS</description></item>
        ///   <item><term>Legacy Display Name</term><description>WINDOWS</description></item>
        ///   <item><term>Legacy Default Path</term><description>%windir%</description></item>
        /// </list>
        /// </remarks>
        public static readonly KnownFolderId Windows =
            new KnownFolderId(0xF38BF404, 0x1D43, 0x42F2, 0x93, 0x05, 0x67, 0xDE, 0x0B, 0x28, 0xFC, 0x23);
    }

}
