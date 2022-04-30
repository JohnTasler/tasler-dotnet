namespace Tasler.Windows.Forms
{
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Drawing;
	using System.Runtime.InteropServices;
	using System.Windows.Forms;

	/// <summary>
	/// Summary description for TreeView.
	/// </summary>
	public class TreeView : System.Windows.Forms.TreeView
	{
		#region Constants
		const int WM_PAINT = 0x000F;
		const int WM_ERASEBKGND = 0x0014;
		#endregion

		#region Instance Fields
		private bool hideHorizontalScrollBar;
		private bool allowNonEvenItemHeight;
		private bool multiSelect;
		private bool inSelectionDrag;
		private Rectangle selectionDragRectangle;
		private Hashtable selectionDragNodes = new Hashtable();
		private TreeNode selectionDragPrevNode = null;
		#endregion

		#region Construction
		public TreeView() 
		{
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.DoubleBuffer, true);
			base.SetStyle(ControlStyles.UserPaint, true);
		}
		#endregion

		#region Properties
		[Description("Disables horizontal scrolling in the control. The control will not display any horizontal scroll bars.")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool HideHorizontalScrollBar 
		{
			get { return this.hideHorizontalScrollBar; }
			set 
			{
				if (this.hideHorizontalScrollBar != value)
				{
					this.hideHorizontalScrollBar = value;
					if (base.IsHandleCreated)
					{
						base.UpdateStyles();
					}
				}
			}
		}


		[Description("Allows the height of the items to be set to an odd height with the ItemHeight property.")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool AllowNonEvenItemHeight 
		{
			get { return this.allowNonEvenItemHeight; }
			set 
			{
				if (this.allowNonEvenItemHeight != value)
				{
					this.allowNonEvenItemHeight = value;
					if (base.IsHandleCreated)
					{
						base.UpdateStyles();
					}
				}
			}
		}

		[Description("Allows multiple tree nodes to be selected. WORK IN PROGRESS!!!")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool MultiSelect 
		{
			get { return this.multiSelect; }
			set { this.multiSelect = value; }
		}
		#endregion

		#region Overrides
		protected override CreateParams CreateParams 
		{
			get 
			{
				const int TVS_NOHSCROLL = 0x8000;
				const int TVS_NONEVENHEIGHT = 0x4000;
				CreateParams cp = base.CreateParams;
				if (this.hideHorizontalScrollBar)
					cp.Style |= TVS_NOHSCROLL;
				else
					cp.Style &= ~TVS_NOHSCROLL;
				if (this.allowNonEvenItemHeight)
					cp.Style |= TVS_NONEVENHEIGHT;
				else
					cp.Style &= ~TVS_NONEVENHEIGHT;
				return cp;
			}
		}

		protected override void OnMouseDown(MouseEventArgs e) 
		{
			if (this.multiSelect)
			{
				TreeNode tn = base.GetNodeAt(e.X, e.Y);
				if (tn == null || !GetAdjustedBounds(tn).Contains(e.X, e.Y))
				{
					// Create the selection rectangle at the clicked point
					this.selectionDragRectangle = new Rectangle(e.X, e.Y, 0, 0);

					// Enter selection drag mode
					this.inSelectionDrag = true;
					base.Capture = true;

					// Deselect the currently selected node
					selectionDragPrevNode = base.SelectedNode;
					base.SelectedNode = null;
				}
			}

			// Perform default processing
			base.OnMouseDown(e);
		}

		private static Rectangle GetAdjustedBounds(TreeNode node) 
		{
			Rectangle rectangle = node.Bounds;
			rectangle.Width += rectangle.Left;
			rectangle.X = 0;
			return rectangle;
		}

		protected override void OnMouseMove(MouseEventArgs e) 
		{
			if (this.inSelectionDrag)
			{
				// Normalize the old selection rectangle
				Rectangle oldSelectionRectangle = selectionDragRectangle;
				NormalizeRectangle(ref oldSelectionRectangle);

				// Limit the rectangle to the client area
				int x = Math.Max(Math.Min(e.X, this.ClientRectangle.Right), this.ClientRectangle.Left);
				int y = Math.Max(Math.Min(e.Y, this.ClientRectangle.Bottom), this.ClientRectangle.Top);

				// Adjust the selection rectangle
				this.selectionDragRectangle.Width = x - this.selectionDragRectangle.Left;
				this.selectionDragRectangle.Height = y - this.selectionDragRectangle.Top;

				// Normalize the new selection rectangle
				Rectangle newSelectionRectangle = this.selectionDragRectangle;
				NormalizeRectangle(ref newSelectionRectangle);

				// Invalidate the old and new selection rectangles
				this.Invalidate(oldSelectionRectangle);
				this.Invalidate(newSelectionRectangle);
				this.Update();

				// Make the intersecting nodes look selected
				this.selectionDragNodes.Clear();
				TreeNode node = base.TopNode;
				while (node != null)
				{
					if (node.Bounds.IntersectsWith(newSelectionRectangle))
					{
						node.BackColor = SystemColors.Highlight;
						node.ForeColor = SystemColors.HighlightText;
						this.selectionDragNodes.Add(node, null);
					}
					else
					{
						node.BackColor = SystemColors.Window;
						node.ForeColor = SystemColors.WindowText;
					}

					// Get the next visible node
					node = node.NextVisibleNode;
				}
			}

			// Perform default processing
			base.OnMouseMove(e);
		}

		private static void NormalizeRectangle(ref Rectangle rectangle) 
		{
			if (rectangle.Width < 0)
			{
				rectangle.X += rectangle.Width;
				rectangle.Width = -rectangle.Width;
			}
			if (rectangle.Height < 0)
			{
				rectangle.Y += rectangle.Height;
				rectangle.Height = -rectangle.Height;
			}
		}

		protected override void OnMouseUp(MouseEventArgs e) 
		{
			if (this.inSelectionDrag)
			{
				// Leave selection drag mode
				this.selectionDragNodes.Clear();
				this.inSelectionDrag = false;
				base.Capture = false;

				// Invalidate the selection rectangle
				base.Invalidate(this.selectionDragRectangle);
				base.Update();
			}

			// Perform default processing
			base.OnMouseUp(e);
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (this.inSelectionDrag && e.KeyChar == '\u001B')
			{
				// Indicate that we've handled the keypress
				e.Handled = true;

				// Leave selection drag mode
				this.inSelectionDrag = false;
				base.Capture = false;

				// Restore the colors of the selectionDragNodes
				foreach (TreeNode node in this.selectionDragNodes.Keys)
				{
					node.BackColor = SystemColors.Window;
					node.ForeColor = SystemColors.WindowText;
				}

				// Clear the collection of drag selected nodes
				this.selectionDragNodes.Clear();

				// Reselect the previously selected node
				base.SelectedNode = this.selectionDragPrevNode;
				if (base.SelectedNode != null)
				{
					base.Invalidate(base.SelectedNode.Bounds);
				}

				// Invalidate the selection rectangle (to erase it)
				base.Invalidate(this.selectionDragRectangle);
				base.Update();
			}

			// Perform default processing
			base.OnKeyPress(e);
		}

		protected override void OnPaint(PaintEventArgs e) 
		{
//			// Open the clip rectangle
//			e.Graphics.SetClip(base.ClientRectangle);
//			e.Graphics.FillRectangle(SystemBrushes.Window, base.ClientRectangle);

			// Have the underlying control paint onto the double-buffer
			IntPtr hdc = e.Graphics.GetHdc();
			Message m = new Message();
			m.HWnd = this.Handle;
			m.Msg = WM_PAINT;
			m.WParam = hdc;
			base.DefWndProc(ref m);
			e.Graphics.ReleaseHdc(hdc);

			// Draw the selection rectangle, if any
			if (this.inSelectionDrag)
			{
				// Normalize the selection rectangle
				Rectangle rectangle = this.selectionDragRectangle;
				NormalizeRectangle(ref rectangle);

				// Fill the selection rectangle
				using (SolidBrush brush = new SolidBrush(Color.FromArgb(70, SystemColors.Highlight)))
				{
					e.Graphics.FillRectangle(brush, rectangle);
				}

				// Outline the selection rectangle
				using (Pen pen = new Pen(SystemColors.Highlight))
				{
					--rectangle.Width;
					--rectangle.Height;
					e.Graphics.DrawRectangle(pen, rectangle);
				}
			}

			// Perform default processing
			base.OnPaint(e);
		}

		protected override void WndProc(ref Message m) 
		{
			// Ignore WM_ERASEBKGND messages
			if (m.Msg == WM_ERASEBKGND)
			{
				m.Result = (IntPtr)1;
				return;
			}

			// Perform default processing
			base.WndProc(ref m);
		}

		#endregion

		#region Interop

		[DllImport("GDI32.dll")]
		private static extern IntPtr CreateCompatibleDC(IntPtr hdc);
		[DllImport("GDI32.dll")]
		private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
		[DllImport("GDI32.dll")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
		[DllImport("GDI32.dll")]
		private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);
		[DllImport("GDI32.dll")]
		private static extern bool DeleteDC(IntPtr hdc);
		[DllImport("USER32.dll")]
		private static extern IntPtr GetDC(IntPtr hwnd);
		[DllImport("USER32.dll")]
		private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

		private const uint SRCCOPY = 0x00CC0020;
		#endregion
	}
}
