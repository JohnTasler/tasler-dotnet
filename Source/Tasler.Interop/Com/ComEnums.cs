namespace Tasler.Interop.Com;

/// <summary>
/// CLSCTX
/// </summary>
[Flags]
public enum ClsCtx
{
	Default = InprocServer | NoCodeDownload,

	InprocServer = 0x1,
	InprocHandler = 0x2,
	LocalServer = 0x4,
	InprocServer16 = 0x8,
	RemoteServer = 0x10,
	InprocHandler16 = 0x20,
	NoCodeDownload = 0x400,
	NoCustomMarshal = 0x1000,
	EnableCodeDownload = 0x2000,
	NoFailureLog = 0x4000,
	DisableActivateAsActivator = 0x8000,
	EnableActivateAsActivator = 0x10000,
	FromDefaultContext = 0x20000,
	Activate32BitServer = 0x40000,
	Activate64BitServer = 0x80000
}

[Flags]
public enum RegCls : uint
{
	SingleUse = 0,
	MultipleUse = 1,
	MultiSeparate = 2,
	Suspended = 4,
	Surrogate = 8,
	Agile = 0x10
}

public enum STGTY
{
	/// <summary>Indicates that the storage element is a storage object.</summary>
	Storage = 1,
	/// <summary>Indicates that the storage element is a stream object.</summary>
	Stream = 2,
	/// <summary>Indicates that the storage element is a byte-array object.</summary>
	LockBytes = 3,
	/// <summary>Indicates that the storage element is a property storage object.</summary>
	Property = 4
}

/// <summary>
/// The type of locking requested for the specified range of bytes. The values are used in the
/// <see cref="ILockBytes.LockRegion"/> and <see cref="IStream.LockRegion"/> methods.
/// </summary>
[Flags]
public enum LockType : uint
{
	/// <summary>
	/// If this lock is granted, the specified range of bytes can be opened and read any number of
	/// times, but writing to the locked range is prohibited except for the owner that was granted
	/// this lock.
	/// </summary>
	Write = 1,

	/// <summary>
	/// If this lock is granted, writing to the specified range of bytes is prohibited except by the
	/// owner that was granted this lock.
	/// </summary>
	Exclusive = 2,

	/// <summary>
	/// If this lock is granted, no other LOCK_ONLYONCE lock can be obtained on the range. Usually
	/// this lock type is an alias for some other lock type. Thus, specific implementations can have
	/// additional behavior associated with this lock type.
	/// </summary>
	OnlyOnce = 4
}

/// <summary>
/// Indicates whether a method should try to return a name in the <see cref="STATSTG.Name"/> member.
/// The values are used in the <see cref="ILockBytes.Stat"/>, <see cref="IStorage.Stat"/>, and
/// <see cref="IStream.Stat"/> methods to save memory when the <see cref="STATSTG.Name"/> member is
/// not required.
/// </summary>
public enum STATFLAG
{
	/// <summary>
	/// Requests that the statistics include the pwcsName member of the  <see cref="STATSTG"/> structure.
	/// </summary
	Default = 0,

	/// <summary>
	/// Requests that the statistics not include the <see cref="STATSTG.Name"/>Name member of the
	/// <see cref="STATSTG"/> structure. If the name is omitted, there is no need for the
	/// <see cref="ILockBytes.Stat"/>, <see cref="IStorage.Stat"/>, and <see cref="IStream.Stat"/>
	/// methods to allocate and free memory for the string value of the name, therefore the method
	/// reduces time and resources used in an allocation and free operation.
	/// </summary>
	NoName = 1,

	/// <summary>Not implemented.</summary>
	NoOpen = 2
}

public enum STREAM_SEEK
{
	Set = 0,
	Current = 1,
	End = 2
}

[Flags]
public enum STGCOMMIT : uint
{
	Default = 0,
	Overwrite = 1,
	OnlyIfCurrent = 2,
	DangerouslyCommitMerelyToDiskCache = 4,
	Consolidate = 8
}

public enum STGM : uint
{
	Direct           = 0x00000000,
	Transacted       = 0x00010000,
	Simple           = 0x08000000,

	Read             = 0x00000000,
	Write            = 0x00000001,
	ReadWrite        = 0x00000002,

	ShareDenyNone    = 0x00000040,
	ShareDenyRead    = 0x00000030,
	ShareDenyWrite   = 0x00000020,
	ShareExclusive   = 0x00000010,

	Priority         = 0x00040000,
	DeleteOnRelease  = 0x04000000,
	NoScratch        = 0x00100000,

	Create           = 0x00001000,
	Convert          = 0x00020000,
	FailIfThere      = 0x00000000,

	NoSnapshot       = 0x00200000,
	DirectSWMR       = 0x00400000,
}

/// <summary>
/// Indicates whether a storage element is to be moved or copied. They are used in the
/// <see cref="IStorage.MoveElementTo"/> method.
/// </summary>
public enum STGMOVE
{
	/// <summary>Indicates that the method should move the data from the source to the destination.</summary>
	Move = 0,

	/// <summary>
	/// Indicates that the method should copy the data from the source to the destination. A copy is
	/// the same as a move except that the source element is not removed after copying the element to
	/// the destination. Copying an element on top of itself is undefined.
	/// </summary>
	Copy = 1,

	/// <summary>Not implemented.</summary>
	ShallowCopy = 2
}

/// <summary>Controls aspects of moniker binding operations.</summary>
public enum BIND_FLAGS
{
	/// <summary>
	/// If this flag is specified, the moniker implementation can interact with the end user.
	/// Otherwise, the moniker implementation should not interact with the user in any way, such as
	/// by asking for a password for a network volume that needs mounting. If prohibited from
	/// interacting with the user when it otherwise would, a moniker implementation can use a
	/// different algorithm that does not require user interaction, or it can fail with the error
	/// MK_E_MUSTBOTHERUSER.
	/// </summary>
	MayBotherUser = 1,

	/// <summary>
	/// If this flag is specified, the caller is not interested in having the operation carried out,
	/// but only in learning whether the operation could have been carried out had this flag not been
	/// specified. For example, this flag lets the caller indicate only an interest in finding out
	/// whether an object actually exists by using this flag in a <see cref="IMoniker.BindToObject"/>
	/// call. Moniker implementations can, however, ignore this possible optimization and carry out
	/// the operation in full. Callers must be able to deal with both cases.
	/// </summary>
	JustTestExistence = 2
}

/// <summary>
/// Indicates the moniker's class.
/// </summary>
public enum MKSYS
{
	/// <summary>0 Indicates a custom moniker implementation.</summary>
	None = 0,
	/// <summary>1 Indicates the system's generic composite moniker class.</summary>
	GenericComposite = 1,
	/// <summary>2 Indicates the system's file moniker class.</summary>
	FileMoniker = 2,
	/// <summary>3 Indicates the system's anti-moniker class.</summary>
	AntiMoniker = 3,
	/// <summary>4 Indicates the system's item moniker class.</summary>
	ItemMoniker = 4,
	/// <summary>5 Indicates the system's pointer moniker class.</summary>
	PointerMoniker = 5,
	/// <summary>7 Indicates the system's class moniker class.</summary>
	ClassMoniker = 7,
	/// <summary>8 Indicates the system's OBJREF moniker class.</summary>
	ObjrefMoniker = 8,
	/// <summary>9 Indicates the system's terminal server session moniker class.</summary>
	SessionMoniker = 9,
	/// <summary>10 Indicates the system's elevation moniker class.</summary>
	LuaMoniker = 10
}
