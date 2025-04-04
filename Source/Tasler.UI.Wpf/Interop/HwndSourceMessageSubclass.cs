using System.Windows;
using System.Windows.Interop;
using Tasler.Interop;
using Tasler.Interop.User;

namespace Tasler.Windows.Interop
{
	public class HwndSourceMessageSubclass : WindowMessageSubclass
	{
		#region Instance Fields
		private IInputElement? _element;
		private HwndSource? _hwndSource;
		#endregion Instance Fields

		#region Construction
		public HwndSourceMessageSubclass(IInputElement? element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			_element = element;
			_hwndSource = (HwndSource)HwndSource.FromDependencyObject(element as DependencyObject);

			PresentationSource.AddSourceChangedHandler(_element, this.PresentationSource_SourceChanged);
		}
		#endregion Construction

		#region Properties
		public SafeHwnd Handle => new() { Handle = _hwndSource?.Handle ?? nint.Zero };
		#endregion Properties

		#region Events
		public event EventHandler? HandleChanged;
		#endregion Events

		#region Event Handlers
		private void PresentationSource_SourceChanged(object sender, SourceChangedEventArgs e)
		{
			var previousHandle = this.Handle;

			if (e.OldSource is HwndSource oldSource)
				_hwndSource = null;

			if (e.NewSource is HwndSource newSource)
				_hwndSource = newSource;

			if (this.Handle != previousHandle)
			{
				this.Attach(this.Handle);
				this.HandleChanged?.Invoke(this, EventArgs.Empty);
			}
		}
		#endregion Event Handlers
	}
}
