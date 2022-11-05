using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Interop;
using Tasler.Interop;
using Tasler.Interop.User;

namespace Tasler.Windows.Interop
{
	public class HwndSourceMessageSubclass : WindowMessageSubclass
	{
		#region Instance Fields
		private IInputElement element;
		private HwndSource hwndSource;
		#endregion Instance Fields

		#region Construction
		public HwndSourceMessageSubclass(IInputElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			this.element = element;
			this.hwndSource = (HwndSource)HwndSource.FromDependencyObject(element as DependencyObject);

			PresentationSource.AddSourceChangedHandler(this.element, this.PresentationSource_SourceChanged);
		}
		#endregion Construction

		#region Properties
		public IntPtr Handle
		{
			get
			{
				return (this.hwndSource != null) ? this.hwndSource.Handle : IntPtr.Zero;
			}
		}
		#endregion Properties

		#region Events
		public event EventHandler HandleChanged;
		#endregion Events

		#region Event Handlers
		private void PresentationSource_SourceChanged(object sender, SourceChangedEventArgs e)
		{
			var previousHandle = this.Handle;

			var oldSource = e.OldSource as HwndSource;
			if (oldSource != null)
				this.hwndSource = null;

			var newSource = e.NewSource as HwndSource;
			if (newSource != null)
				this.hwndSource = newSource;

			if (this.Handle != previousHandle)
			{
				this.Attach(this.Handle);

				if (this.HandleChanged != null)
					this.HandleChanged(this, EventArgs.Empty);
			}
		}
		#endregion Event Handlers
	}
}
