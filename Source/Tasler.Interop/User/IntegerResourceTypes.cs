namespace Tasler.Interop.User;

public enum IntegerResourceType
{
	/// <summery>Hardware-dependent cursor resource.</summary
	Cursor = 1,

	/// <summery>Bitmap resource.</summary
	Bitmap = 2,

	/// <summery>Hardware-dependent icon resource.</summary
	Icon = 3,

	/// <summery>Menu resource.</summary
	Menu = 4,

	/// <summery>Dialog box.</summary
	Dialog = 5,

	/// <summery>String-table entry.</summary
	String = 6,

	/// <summery>Font directory resource.</summary
	FontDir = 7,

	/// <summery>Font resource.</summary
	Font = 8,

	/// <summery>Accelerator table.</summary
	Accelerator = 9,

	/// <summery>Application-defined resource (raw data).</summary
	RcData = 10,

	/// <summery>Message-table entry.</summary
	MessageTable = 11,

	/// <summery>Hardware-independent cursor resource.</summary
	GroupCursor = Cursor + 11,

	/// <summery>Hardware-independent icon resource.</summary
	GroupIcon = Icon + 11,

	/// <summery>Version resource.</summary
	Version = 16,

	/// <summery>
	/// Allows a resource editing tool to associate a string with an .rc file. Typically, the string
	/// is the name of the header file that provides symbolic names. The resource compiler parses the
	/// string but otherwise ignores the value. For example, 1 DLGINCLUDE "MyFile.h"
	/// </summary
	DlgInclude = 17,

	/// <summery>Plug and Play resource.</summary
	PlugPlay = 19,

	/// <summery>VXD.</summary
	Vxd = 20,

	/// <summery>Animated cursor.</summary
	AniCursor = 21,

	/// <summery>Animated icon.</summary
	AniIcon = 22,

	/// <summery>HTML resource.</summary
	Html = 23,

	/// <summery>Side-by-Side Assembly Manifest.</summary
	Manifest = 24,
}
