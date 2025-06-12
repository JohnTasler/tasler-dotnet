using System.ComponentModel;
using System.Windows.Input;
using Tasler.Converters;

namespace Tasler.Windows.Input;

public class HumanInputGesture : InputGesture
{
	#region Properties
	public ushort UsagePage { get; set; }
	public ushort Usage { get; set; }

	[TypeConverter(typeof(HexStringToByteArrayConverter))]
	public byte[]? Mask { get; set; }

	[TypeConverter(typeof(HexStringToByteArrayConverter))]
	public byte[]? Data { get; set; }
	#endregion Properties

	#region Overrides
	public override bool Matches(object targetElement, InputEventArgs inputEventArgs)
	{
		if (inputEventArgs is HumanInputEventArgs args
			&& args.HumanInterfaceDevice.UsagePage == this.UsagePage
			&& args.HumanInterfaceDevice.Usage == this.Usage)
		{
			foreach (byte[] bytes in args.HumanInput.Bytes)
			{
				// Copy the byte array for masking and testing
				byte[] buffer = new byte[bytes.Length];
				bytes.CopyTo(buffer, 0);

				// Apply the mask, if any
				int maskedLength = buffer.Length;
				if (this.Mask != null)
				{
					maskedLength = Math.Min(this.Mask.Length, bytes.Length);
					for (int index = 0; index < maskedLength; ++index)
						buffer[index] &= this.Mask[index];
				}

				// Compare to the data
				bool isMatch = true;
				if (this.Data != null)
				{
					for (int index = 0; index < maskedLength && isMatch; ++index)
						if (buffer[index] != this.Data[index])
							isMatch = false;
				}

				if (isMatch)
					return true;
			}
		}

		return false;
	}
	#endregion Overrides
}
