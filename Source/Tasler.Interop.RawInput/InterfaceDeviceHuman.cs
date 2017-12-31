using System;
using System.Runtime.InteropServices;
using System.Text;
using Tasler.Interop.RawInput.User;

namespace Tasler.Interop.RawInput
{
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
		public int VendorId
		{
			get { return base.DeviceInfo.VendorId; }
		}

		public int ProductId
		{
			get { return base.DeviceInfo.ProductId; }
		}

		public int VersionNumber
		{
			get { return base.DeviceInfo.VersionNumber; }
		}

		public override short UsagePage
		{
			get { return base.DeviceInfo.UsagePage; }
		}

		public override short Usage
		{
			get { return base.DeviceInfo.Usage; }
		}

		#endregion Properties
	}


	public class HumanInput : RawInputBase
	{
		private RAWINPUTHID raw;
		private byte[][] data;

		internal HumanInput(IntPtr pData)
		{
			this.raw = (RAWINPUTHID)Marshal.PtrToStructure(
				new IntPtr(pData.ToInt64() + RAWINPUTHEADER.SizeOf), typeof(RAWINPUTHID));

			this.data = new byte[this.raw.Count][];
			for (int index = 0; index < this.data.Length; ++index)
			{
				long offset = RAWINPUTHEADER.SizeOf + RAWINPUTHID.SizeOf + (index * this.raw.Size);
				this.data[index] = new byte[this.raw.Size];
				Marshal.Copy(new IntPtr(pData.ToInt64() + offset), data[index], 0, this.raw.Size);
			}
		}

		public int Count { get { return this.raw.Count; } }

		public int Size { get { return this.raw.Size; } }

		public byte[][] Bytes { get { return this.data; } }

		public string FormattedBytes
		{
			get
			{
				StringBuilder sb = new StringBuilder((this.raw.Count * 4) + (this.raw.Size * 3));
				foreach (byte[] buffer in this.data)
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
}
