using System.Runtime.InteropServices;
using CommunityToolkit.Diagnostics;
using Tasler.Extensions;
using Tasler.Interop.RawInput.User;
using Tasler.Interop.User;

namespace Tasler.Interop.RawInput;

public class InterfaceDeviceKeyboard : InterfaceDeviceBase<InterfaceDeviceKeyboard.Info>
{
	#region Nested Types
	[StructLayout(LayoutKind.Sequential)]
	public class Info
	{
		public int Size;
		public int DeviceType;
		public int KeyboardType;
		public int KeyboardSubType;
		public int KeyboardMode;
		public int NumberOfFunctionKeys;
		public int NumberOfIndicators;
		public int NumberOfKeysTotal;
	}
	#endregion Nested Types

	#region Construction
	internal InterfaceDeviceKeyboard(RAWINPUTDEVICELIST device)
			: base(device)
	{
	}
	#endregion Construction

	#region Properties
	public int KeyboardType => base.DeviceInfo.KeyboardType;

	public int KeyboardSubType => base.DeviceInfo.KeyboardSubType;

	public int KeyboardMode => base.DeviceInfo.KeyboardMode;

	public int NumberOfFunctionKeys => base.DeviceInfo.NumberOfFunctionKeys;

	public int NumberOfIndicators => base.DeviceInfo.NumberOfIndicators;

	public int NumberOfKeysTotal => base.DeviceInfo.NumberOfKeysTotal;

	public override short UsagePage => 1;

	public override short Usage => 6;

	#endregion Properties
}

public class KeyboardInput : RawInputBase
{
	private RAWINPUTKEYBOARD _raw;

	internal KeyboardInput(nint pData)
	{
		Guard.IsNotDefault(pData, nameof(pData));

		var targetSpan = MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref _raw, 1));
		unsafe
		{
			new Span<byte>(pData.ToPointer(), RAWINPUTKEYBOARD.SizeOf).CopyTo(targetSpan);
		}
	}

	/// <summary>Scan code for key depression.</summary>
	public ushort MakeCode => _raw.MakeCode;
	/// <summary>Scan code information.</summary>
	public KeyboardFlags Flags => _raw.Flags;
	/// <summary>Virtual key code.</summary>
	public ushort VirtualKey => _raw.VirtualKey;
	/// <summary>The display name of the scan code key.</summary>
	public string KeyName => UserApi.GetScanCodeKeyDisplayText(this.MakeCode);

	/// <summary>Corresponding window message.</summary>
	public uint Message => _raw.Message;
	/// <summary>Extra information.</summary>
	public uint ExtraInformation => _raw.ExtraInformation;
}
