using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using CommunityToolkit.Diagnostics;
using Tasler.Extensions;
using Tasler.Interop.RawInput.User;

namespace Tasler.Interop.RawInput;

public class InterfaceDeviceMouse : InterfaceDeviceBase<InterfaceDeviceMouse.Info>
{
	#region Nested Types
	[StructLayout(LayoutKind.Sequential)]
	public struct Info
	{
		public int Size;
		public int DeviceType;
		public int Id;
		public int NumberOfButtons;
		public int SampleRate;
		[MarshalAs(UnmanagedType.Bool)]
		public bool HasHorizontalWheel;
	}
	#endregion Nested Types

	#region Construction
	internal InterfaceDeviceMouse(RAWINPUTDEVICELIST device)
			: base(device)
	{
	}
	#endregion Construction

	#region Properties

	public override short UsagePage => 1;

	public override short Usage => 2;

	public int Id => base.DeviceInfo.Id;

	public int NumberOfButtons => base.DeviceInfo.NumberOfButtons;

	public int SampleRate => base.DeviceInfo.SampleRate;

	public bool HasHorizontalWheel => this.DeviceInfo.HasHorizontalWheel;

	#endregion Properties
}

public class MouseInput : RawInputBase
{
	private RAWINPUTMOUSE _raw;

	internal MouseInput(nint pData)
	{
		// Validate the pointer
		Guard.IsNotDefault(pData);

		// Get the size of the RAWINPUTMOUSE structure
		int size = RAWINPUTMOUSE.SizeOf;

		// Get a byte span of the target structure
		var targetBytes = MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref _raw, 1));

		unsafe
		{
			// Create a byte span of the source data
			Span<byte> sourceSpan = new Span<byte>(pData.ToPointer(), size);

			// Copy the data from the source to the target
			sourceSpan.CopyTo(targetBytes);
		}
	}

	/// <summary>Flags for the event.</summary>
	public MouseFlags Flags => _raw.Flags;

	/// <summary>Flags for the event.</summary>
	public MouseButtons Buttons => _raw.Buttons;

	/// <summary>If the mouse wheel is moved, this will contain the delta amount.</summary>
	public short ButtonData => _raw.ButtonData;

	/// <summary>Raw button data.</summary>
	public int RawButtons => _raw.RawButtons;

	/// <summary>Relative direction of motion, depending on flags.</summary>
	public int LastX => _raw.LastX;

	/// <summary>Relative direction of motion, depending on flags.</summary>
	public int LastY => _raw.LastY;

	/// <summary>Extra information.</summary>
	public int ExtraInformation => _raw.ExtraInformation;
}
