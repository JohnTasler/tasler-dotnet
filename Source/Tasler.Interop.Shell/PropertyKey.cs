using System.Runtime.InteropServices;

namespace Tasler.Interop.Shell;

/// <summary>
/// Specifies the FMTID/PID identifier that programmatically identifies a property.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct PropertyKey
{
	#region Instance Fields
	/// <summary>A unique GUID for the property.</summary>
	public Guid FormatId;

	/// <summary>
	/// A property identifier (PID).
	/// </summary>
	/// <remarks>
	/// <para>It is recommended that you set this value to <see cref="FirstUsable"/>.
	/// Any value greater than or equal to 2 is acceptable.</para>
	/// <para>
	/// <list type="table">
	///   <item>
	///     <term>Note</term>
	///     <description>Values of 0 and 1 are reserved and should not be used.</description>
	///   </item>
	/// </list>
	/// </para>
	/// </remarks>
	public int PropertyId;
	#endregion Instance Fields

	#region Constants
	/// <summary>The first usable property identifier (PID).</summary>
	public const int FirstUsable = 2;
	#endregion Constants

	#region Construction
	/// <summary>
	/// Initializes a new PropertyKey that identifies a property by its format identifier (FMTID) and property identifier (PID).
	/// </summary>
	/// <param name="fmtid">The property set's format identifier (FMTID).</param>
	/// <param name="pid">The property identifier (PID). PIDs 0 and 1 are reserved; use values starting at <see cref="PropertyKey.FirstUsable"/> (2).</param>
	public PropertyKey(Guid fmtid, int pid)
	{
		this.FormatId = fmtid;
		this.PropertyId = pid;
	}

	/// <summary>
	/// Initializes a new PropertyKey with the specified format identifier and property identifier.
	/// </summary>
	/// <param name="fmtid">The string representation of the FMTID GUID.</param>
	/// <param name="pid">The property identifier (PID). Use 2 or greater for user-defined properties; 0 and 1 are reserved.</param>
	public PropertyKey(string fmtid, int pid)
	{
		this.FormatId = new Guid(fmtid);
		this.PropertyId = pid;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="PropertyKey"/> structure.
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
	/// <param name="pid">A property identifier (PID). <seealso cref="M:pid"/></param>
	public PropertyKey(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k, int pid)
			: this(new Guid(a, b, c, d, e, f, g, h, i, j, k), pid)
	{
	}
	#endregion Construction
}

#if false

I used these regular expressions in Visual Studio search/replace operations to help convert from the declarations in the propkey.h file.
KEEP THESE AROUND for when new ones are introduced.

Find this:
DEFINE_PROPERTYKEY\(PKEY_([a-zA-Z_][a-zA-Z_0-9]+), (.+)\s*\);\r\n
Replace with:
\t\tpublic static PropertyKey $1 => new($2);\r\n

Find this:
//  Name:\s+(.+)\r\n//  Type:\s+(.+)\r\n//  FormatID:\s+(.+)\r\n
Replace with:
\t\t/// <summary></summary>\r\n\t\t/// <remarks>\r\n\t\t/// <list type="table">\r\n\t\t///   <item><term><b>Name:     </b></term><description>$1</description></item>\r\n\t\t///   <item><term><b>Type:     </b></term><description>$2</description></item>\r\n\t\t///   <item><term><b>Format ID:</b></term><description>$3</description></item>\r\n\t\t/// </list>\r\n\t\t/// </remarks>\r\n

Find this:
//  Name:\s+(.+)\r\n//  Type:\s+(.+)\r\n//  FormatID:\s+(.+)\r\n//\s*\r\n//  (.+)\r\n
Replace with:
\t\t/// <summary>\r\n\t\t/// $4\r\n\t\t/// </summary>\r\n\t\t/// <remarks>\r\n\t\t/// <list type="table">\r\n\t\t///   <item><term><b>Name:     </b></term><description>$1</description></item>r\n\t\t///   <item><term><b>Type:     </b></term><description>$2</description></item>\r\n\t\t///   <item><term><b>Format ID:</b></term><description>$3</description></item>\r\n\t\t/// </list>\r\n\t\t/// </remarks>\r\n

The most recent propkey.h file CRC32 and SHA512 is:
CRC32 : 03C0AB88
SHA512: 1CE9A7C09F9FA1C5D14D792FD6F918FB86B80688B634821EA067D1A43045DB9148B5FE5F03A1C687F0C17A8ECF1C1050541088952A843DFDD009667D0788BDCE

#endif


