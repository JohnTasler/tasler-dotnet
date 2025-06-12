using System.Runtime.InteropServices;
using System.Text;
using Tasler.Extensions;
using Tasler.Interop.RawInput.User;

namespace Tasler.Interop.RawInput;

public class InterfaceDeviceHuman : InterfaceDeviceBase<InterfaceDeviceHuman.Info>
{
	#region Nested Types
	[StructLayout(LayoutKind.Sequential)]
	public class Info
	{
		public int Size;
		public int DeviceType;
		public int VendorId;
		public int ProductId;
		public int VersionNumber;
		public short UsagePage;
		public short Usage;
	}
	#endregion Nested Types

	#region Construction
	public InterfaceDeviceHuman(RAWINPUTDEVICELIST device)
			: base(device)
	{
	}
	#endregion Construction

	#region Properties
	public int VendorId => DeviceInfo.VendorId;

	public int ProductId => DeviceInfo.ProductId;

	public int VersionNumber => DeviceInfo.VersionNumber;

	public override short UsagePage => DeviceInfo.UsagePage;

	public override short Usage => DeviceInfo.Usage;

	#endregion Properties
}


public class HumanInput : RawInputBase
{
	private RAWINPUTHID _raw;
	private byte[][] _data;

	internal HumanInput(nint pData)
	{
		_raw = (RAWINPUTHID)Marshal.PtrToStructure(
				new nint(pData.ToInt64() + RAWINPUTHEADER.SizeOf), typeof(RAWINPUTHID));

		_data = new byte[_raw.Count][];
		for (int index = 0; index < _data.Length; ++index)
		{
			long offset = RAWINPUTHEADER.SizeOf + RAWINPUTHID.SizeOf + (index * _raw.Size);
			_data[index] = new byte[_raw.Size];
			Marshal.Copy(new nint(pData.ToInt64() + offset), _data[index], 0, _raw.Size);
		}
	}

	public int Count { get { return _raw.Count; } }

	public int Size { get { return _raw.Size; } }

	public byte[][] Bytes { get { return _data; } }

	public string FormattedBytes
	{
		get
		{
			StringBuilder sb = new StringBuilder((_raw.Count * 4) + (_raw.Size * 3));
			foreach (byte[] buffer in _data)
			{
				if (sb.Length > 0)
					sb.Append(',').Append('\n');
				foreach (byte dataByte in buffer)
					sb.AppendFormat("{0:X2} ", dataByte);
			}

			return sb.ToString();
		}
	}
}
