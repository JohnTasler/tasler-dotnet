using System;
using System.Runtime.InteropServices;

namespace Tasler.Interop.Shell
{
	/// <summary>
	/// Specifies the FMTID/PID identifier that programmatically identifies a property.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public class PropertyKey
	{
		#region Instance Fields
		/// <summary>A unique GUID for the property.</summary>
		public Guid fmtid;

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
		public int pid;
		#endregion Instance Fields

		#region Constants
		/// <summary>The first usable property identifier (PID).</summary>
		public const int FirstUsable = 2;
		#endregion Constants

		#region Construction
		/// <summary>
		/// Initializes a new instance of the <see cref="PropertyKey"/> structure.
		/// </summary>
		/// <param name="fmtid">A unique <see cref="Guid"/> for the property. <seealso cref="M:fmtid"/></param>
		/// <param name="pid">A property identifier (PID). <seealso cref="M:pid"/></param>
		public PropertyKey(Guid fmtid, int pid)
		{
			this.fmtid = fmtid;
			this.pid = pid;
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

	//
	// I used these regular expression search/replace operations to help convert from the declarations in the propkey.h file.
	// Keep these around if/when new ones are introduced.
	//
	// Find this:DEFINE_PROPERTYKEY\(PKEY_{:i}, {.+}:b*$
	// Replace with:    public static PropertyKey \1 { get { return new PropertyKey(\2 } }
	//
	// Find this:{Name\::b*}{.+}\n{Type\::b*}{.+}\n{FormatID\::b*}{.+}\n\n{(.|\n)#}\n    public
	// Replace with:    /// <summary>\7</summary>\n    /// <remarks>\n    /// <list type="table">\n    ///   <item>\1</item><description>\2</description>\n    ///   <item>\3</item><description>\4</description>\n    ///   <item>\5</item><description>\6</description>\n    /// </list>\n    /// </remarks>\n    public
	//
}
