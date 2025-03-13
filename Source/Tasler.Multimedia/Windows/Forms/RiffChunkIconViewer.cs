using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;
using System.IO;

using Tasler.IO;
using Tasler.Multimedia;
using Tasler.Viewer;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Tasler.Multimedia.Windows.Forms 
{
	public partial class RiffChunkIconViewer : RiffChunkViewer 
	{
		#region Construction
		public RiffChunkIconViewer()
		{
			InitializeComponent();
		}
		#endregion

		#region IViewer<RiffChunk> Overrides

		public override object TransientState 
		{
			get 
			{
				// TODO: Implement per-data state
				return null;
			}
		}

		public override object PersistentState 
		{
			get 
			{
				// TODO: Implement Type-wide persistent state (Zoom, Background, etc.)
				return null;
			}
			set 
			{
			}
		}

		public override void Initialize(ViewerInfo viewerInfo) 
		{
		}

		public override void SetData(RiffChunk data, object transientState) 
		{
			// Save the specified data
			base.Data = data;

			// Apply the specified data
			if (base.Data != null)
			{
				using (Stream stream = data.CreateDataStreamSection())
				{
					// Create a buffer and read the first four bytes into it
					byte[] buffer = new byte[stream.Length];
					stream.Read(buffer, 0, 4);

					// TODO: If we want to support the seldom-used RAW format, we will need to also
					//       examine the anih parent/sibling chunk for that data.

					// Determine if the stream contains an icon or a cursor
					int bytesRead = 0;
					bool isIcon = false;
					if (buffer[0] == 0 && buffer[1] == 0 && buffer[3] == 0)
					{
						switch (buffer[2])
						{
							case 1:
								isIcon = true;
								goto case 2;

							case 2:
								// Read the remainder of the stream
								bytesRead = stream.Read(buffer, 4, buffer.Length - 4);
								break;
						}
					}

					// Check for an invalid header
					if (bytesRead == 0)
					{
						throw new Exception("'icon' chunk does not contain a valid icon or cursor type indicator in its header.");
					}

					// Create the icon or cursor from the bits
					IntPtr hIcon = RiffChunkIconViewer.CreateIconFromResourceEx(buffer, bytesRead, isIcon, 0x00030000, 32, 32, 2);
					if (hIcon == IntPtr.Zero)
					{
						throw new Win32Exception(Marshal.GetLastWin32Error(), "'icon' chunk contains invalid icon or cursor data.");
					}

					// Create the managed Icon object to own the icon or cursor
					this.iconViewerControl.Icon = Icon.FromHandle(hIcon);
				}
			}
			else
			{
				this.iconViewerControl.Icon = null;
			}

			// TODO: Save the specified transient state

		}

		#endregion

		#region P/Invoke Methods
		[DllImport("user32.dll", EntryPoint = "CreateIconFromResourceEx", SetLastError = true)]
		private static extern IntPtr CreateIconFromResourceEx(byte[] iconBits, int cbIconBits, bool fIcon, int dwVersion, int cxDesired, int cyDesired, int flags);
		#endregion
	}
}
