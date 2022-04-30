using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Tasler.Windows.Forms
{
	/// <summary>
	/// Summary description for BorderPanel.
	/// </summary>
	public class BorderPanel : System.Windows.Forms.Panel 
	{
		#region Construction
		public BorderPanel()
		{
		}
		#endregion

		#region Properties
		#endregion

		#region Overrides
		protected override void WndProc(ref Message m) 
		{
			if (m.Msg == WM_NCPAINT)
			{
				if (ThemeActive && base.BorderStyle == BorderStyle.Fixed3D)
				{
					IntPtr hdc = GetDCEx(this.Handle, IntPtr.Zero, DCX_WINDOW | DCX_CACHE);
					if (hdc != IntPtr.Zero)
					{
						// Get the rectangle of the window
						RECT rectWindow = new RECT();
						GetWindowRect(this.Handle, rectWindow);

						// Save the current clipping region of the DC
						IntPtr hrgnClipPrev = CreateRectRgn(0, 0, 0, 0);
						GetClipRgn(hdc, hrgnClipPrev);

						// Include the whole window area
						if (m.WParam.ToInt32() == 1)
						{
							IntPtr hrgnWindow = CreateRectRgn(0, 0, rectWindow.Width, rectWindow.Height);
							SelectClipRgn(hdc, hrgnWindow);
						}
						else
						{
							ExtSelectClipRgn(hdc, m.WParam, RGN_OR);
						}

						// Exclude the client area from being painted on
						ExcludeClipRect(hdc, 2, 2, rectWindow.Width-2,  rectWindow.Height-2);

						try
						{
							IntPtr hTheme = OpenThemeData(this.Handle, "EDIT;EDITTEXT");
							if (hTheme != IntPtr.Zero)
							{
								try
								{
									RECT rect = new RECT();
									rect.left = 0;
									rect.top = 0;
									rect.right = rectWindow.Width;
									rect.bottom = rectWindow.Height;
									DrawThemeBackground(hTheme, hdc, 1, 1, rect, null);
									m.Result = IntPtr.Zero;
									return;
								}
								finally
								{
									CloseThemeData(hTheme);
								}
							}
						}
						finally
						{
							// Restore the previous clip region
							SelectClipRgn(hdc, hrgnClipPrev);

							// Release the DC
							ReleaseDC(this.Handle, hdc);
						}
					}
				}
			}

			// Perform default processing
			base.WndProc(ref m);
		}

		#endregion

		#region Interop Wrappers
		private static bool themeChecked = false;
		private static bool themeActive = false;
		private static bool ThemeActive 
		{
			get 
			{
				if (!themeChecked)
				{
					try 
					{
						themeActive = IsAppThemed() && VisualStyles.IsComCtlVersion6InUse;
					}
					catch
					{
					}
					themeChecked = true;
				}
				return themeActive;
			}
		}
		#endregion

		#region Interop Constants
		const int WM_NCPAINT = 0x0085;
		const uint DCX_WINDOW        = 0x00000001;
		const uint DCX_CACHE         = 0x00000002;
		const uint DCX_PARENTCLIP    = 0x00000020;
		const uint DCX_EXCLUDERGN    = 0x00000040;
		const uint DCX_INTERSECTRGN  = 0x00000080;
		const uint DCX_EXCLUDEUPDATE = 0x00000100;
		const int RGN_AND  = 1;
		const int RGN_OR   = 2;
		const int RGN_XOR  = 3;
		const int RGN_DIFF = 4;
		const int RGN_COPY = 5;

		#endregion

		#region Interop Structures
		[StructLayout(LayoutKind.Sequential)]
		class RECT 
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
			public int Width { get { return this.right - this.left; } }
			public int Height { get { return this.bottom - this.top; } }
		}
		#endregion

		#region Interop Methods
		[DllImport("uxtheme.dll")]
		static extern bool IsThemeActive();
		[DllImport("uxtheme.dll")]
		static extern bool IsAppThemed();
		[DllImport("uxtheme.dll")]
		static extern uint GetThemeAppProperties();
		[DllImport("uxtheme.dll", CharSet=CharSet.Unicode, ExactSpelling=true)]
		static extern IntPtr OpenThemeData([In] IntPtr hWnd, [In] string classList);
		[DllImport("uxtheme.dll")]
		static extern IntPtr CloseThemeData([In] IntPtr hTheme);
		[DllImport("uxtheme.dll")]
		static extern int DrawThemeBackground([In] IntPtr hTheme, [In] IntPtr hdc,
			[In] int iPartId, [In] int iStateId, [In] RECT rect, [In] RECT clipRect);
		[DllImport("user32.dll")]
		static extern IntPtr GetDCEx([In] IntPtr hWnd, [In] IntPtr hrgnClip, [In] uint flags);
		[DllImport("user32.dll")]
		static extern int ReleaseDC([In] IntPtr hWnd, [In] IntPtr hdc);
		[DllImport("gdi32.dll")]
		static extern IntPtr CreateRectRgn(int left, int top, int right, int bottom);
		[DllImport("gdi32.dll")]
		static extern int ExcludeClipRect(IntPtr hdc, int left, int top, int right, int bottom);
		[DllImport("gdi32.dll")]
		static extern int GetClipRgn(IntPtr hdc, IntPtr hrgn);
		[DllImport("gdi32.dll")]
		static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);
		[DllImport("gdi32.dll")]
		static extern int ExtSelectClipRgn(IntPtr hdc, IntPtr hrgn, int fnMode);

		[DllImport("user32.dll")]
		static extern bool GetWindowRect(IntPtr hwnd, RECT rect);

		#endregion
	}
}
