using System;
using System.Windows;
using System.Windows.Input;
using Tasler.Interop.RawInput;
using Tasler.Interop.RawInput.User;

namespace Tasler.Windows.Input
{
	public class HumanInputEventArgs : KeyEventArgs
	{
		#region Construction
		internal HumanInputEventArgs(PresentationSource presentationSource, HumanInput humanInput, InterfaceDeviceHuman humanInterfaceDevice)
			: base(null, presentationSource, 0, Key.NoName)
		{
			this.HumanInput = humanInput;
			this.HumanInterfaceDevice = humanInterfaceDevice;
		}

		internal static HumanInputEventArgs FromRawInput(IntPtr hRawInput)
		{
			RAWINPUTHEADER header;
			RawInputBase.FromHandle(hRawInput, out header, true);

			HumanInputEventArgs args = null;
			if (header.Type == InterfaceDeviceType.HID)
			{
				var humanInput = (HumanInput)RawInputBase.FromHandle(hRawInput, header);

				var humanInterfaceDevice = new InterfaceDeviceHuman(
					new RAWINPUTDEVICELIST()
					{
						dwType = header.Type,
						hDevice = header.Device,
					}
				);

				var focusedElement = Keyboard.FocusedElement as DependencyObject;
				var presentationSource = PresentationSource.FromDependencyObject(focusedElement);
				args = new HumanInputEventArgs(presentationSource, humanInput, humanInterfaceDevice);
			}

			return args;
		}
		#endregion Construction

		#region Properties
		public HumanInput HumanInput { get; private set; }
		public InterfaceDeviceHuman HumanInterfaceDevice { get; private set; }
		#endregion Properties
	}

	public delegate void HumanInputEventHandler(object sender, HumanInputEventArgs e);
}
