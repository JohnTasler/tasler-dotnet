
namespace Tasler.Interop.Shell.AutoComplete;

public static class Guids
{
	// These GUIDs are used for the AutoComplete functionality in Windows Shell.
	public const string IID_IACList                  = "77A130B0-94FD-11D0-A544-00C04FD7D062";
	public const string IID_IACList2                 = "470141A0-5186-11D2-BBB6-0060977B464C";
	public const string IID_IAutoComplete            = "00BB2762-6A77-11D0-A535-00C04FD7D062";
	public const string IID_IAutoComplete2           = "EAC04BC0-3791-11D2-BB95-0060977B464C";
	public const string IID_ICurrentWorkingDirectory = "91956D21-9276-11D1-921A-006097DF5BD4";
	public const string IID_IEnumACString            = "8E74C210-CF9D-4eaf-A403-7356428F0A5A";
	public const string IID_IObjMgr                  = "00BB2761-6A77-11D0-A535-00C04FD7D062";
	public const string CLSID_ACLCustomMRU           = "6935DB93-21E8-4CCC-BEB9-9FE3C77A297A";    // Custom MRU AutoCompleted List
	public const string CLSID_ACLHistory             = "00BB2764-6A77-11D0-A535-00C04FD7D062";    // Microsoft History AutoComplete List
	public const string CLSID_ACListISF              = "03C036F1-A186-11D0-824A-00AA005B4383";    // Microsoft Shell Folder AutoComplete List
	public const string CLSID_ACLMRU                 = "6756A641-DE71-11D0-831B-00AA005B4383";    // MRU AutoComplete List
	public const string CLSID_ACLMulti               = "00BB2765-6A77-11D0-A535-00C04FD7D062";    // Microsoft Multiple AutoComplete List Container
	public const string CLSID_AutoComplete           = "00BB2763-6A77-11D0-A535-00C04FD7D062";    // Microsoft AutoComplete

	public static readonly Guid Guid_IACList                  = new(IID_IACList                 );
	public static readonly Guid Guid_IACList2                 = new(IID_IACList2                );
	public static readonly Guid Guid_IAutoComplete            = new(IID_IAutoComplete           );
	public static readonly Guid Guid_IAutoComplete2           = new(IID_IAutoComplete2          );
	public static readonly Guid Guid_ICurrentWorkingDirectory = new(IID_ICurrentWorkingDirectory);
	public static readonly Guid Guid_IEnumACString            = new(IID_IEnumACString           );
	public static readonly Guid Guid_IObjMgr                  = new(IID_IObjMgr                 );
	public static readonly Guid Guid_ACLCustomMRU             = new(CLSID_ACLCustomMRU          );
	public static readonly Guid Guid_ACLHistory               = new(CLSID_ACLHistory            );
	public static readonly Guid Guid_ACListISF                = new(CLSID_ACListISF             );
	public static readonly Guid Guid_ACLMRU                   = new(CLSID_ACLMRU                );
	public static readonly Guid Guid_ACLMulti                 = new(CLSID_ACLMulti              );
	public static readonly Guid Guid_AutoComplete             = new(CLSID_AutoComplete          );
}
