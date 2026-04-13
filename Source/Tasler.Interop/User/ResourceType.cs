using System.Runtime.InteropServices;
using CommunityToolkit.Diagnostics;

namespace Tasler.Interop.User;

public class ResourceType : ResourceValue
{
	public ResourceType(nint id) : base(id) { }

	public ResourceType(IntegerResourceType id) : base((int)id) { }

	public ResourceType(string id) : base(id) { }

	public IntegerResourceType AsIntegerResourceType
	{
		get
		{
			Guard.IsTrue(this.IsIntResouce);

			return (IntegerResourceType)this.Id switch
			{
				IntegerResourceType.Cursor       => IntegerResourceType.Cursor      ,
				IntegerResourceType.Bitmap       => IntegerResourceType.Bitmap      ,
				IntegerResourceType.Icon         => IntegerResourceType.Icon        ,
				IntegerResourceType.Menu         => IntegerResourceType.Menu        ,
				IntegerResourceType.Dialog       => IntegerResourceType.Dialog      ,
				IntegerResourceType.String       => IntegerResourceType.String      ,
				IntegerResourceType.FontDir      => IntegerResourceType.FontDir     ,
				IntegerResourceType.Font         => IntegerResourceType.Font        ,
				IntegerResourceType.Accelerator  => IntegerResourceType.Accelerator ,
				IntegerResourceType.RcData       => IntegerResourceType.RcData      ,
				IntegerResourceType.MessageTable => IntegerResourceType.MessageTable,
				IntegerResourceType.GroupCursor  => IntegerResourceType.GroupCursor ,
				IntegerResourceType.GroupIcon    => IntegerResourceType.GroupIcon   ,
				IntegerResourceType.Version      => IntegerResourceType.Version     ,
				IntegerResourceType.DlgInclude   => IntegerResourceType.DlgInclude  ,
				IntegerResourceType.PlugPlay     => IntegerResourceType.PlugPlay    ,
				IntegerResourceType.Vxd          => IntegerResourceType.Vxd         ,
				IntegerResourceType.AniCursor    => IntegerResourceType.AniCursor   ,
				IntegerResourceType.AniIcon      => IntegerResourceType.AniIcon     ,
				IntegerResourceType.Html         => IntegerResourceType.Html        ,
				IntegerResourceType.Manifest     => IntegerResourceType.Manifest    ,
				_ => throw new InvalidCastException(string.Format("Cannot convert {0} to an {} value.", this.Id, nameof(IntegerResourceType)))
			};
		}
	}

	public override string ToString()
		=> this.IsIntResouce ? this.GetResouceTypeEnumName() : Marshal.PtrToStringUni(this.Id)!;

	private string GetResouceTypeEnumName()
	{
		return (IntegerResourceType) this.Id switch
		{
			IntegerResourceType.Cursor => "Cursor",
			IntegerResourceType.Bitmap => "Bitmap",
			IntegerResourceType.Icon => "Icon",
			IntegerResourceType.Menu => "Menu",
			IntegerResourceType.Dialog => "Dialog",
			IntegerResourceType.String => "String",
			IntegerResourceType.FontDir => "FontDir",
			IntegerResourceType.Font => "Font",
			IntegerResourceType.Accelerator => "Accelerator",
			IntegerResourceType.RcData => "RcData",
			IntegerResourceType.MessageTable => "MessageTable",
			IntegerResourceType.GroupCursor => "GroupCursor",
			IntegerResourceType.GroupIcon => "GroupIcon",
			IntegerResourceType.Version => "Version",
			IntegerResourceType.DlgInclude => "DlgInclude",
			IntegerResourceType.PlugPlay => "PlugPlay",
			IntegerResourceType.Vxd => "Vxd",
			IntegerResourceType.AniCursor => "AniCursor",
			IntegerResourceType.AniIcon => "AniIcon",
			IntegerResourceType.Html => "Html",
			IntegerResourceType.Manifest => "Manifest",
			_ => this.AsInt.ToString("#{0}")
		};
	}

	public static implicit operator ResourceType(int resourceInteger) => new(resourceInteger);
	public static implicit operator ResourceType(nint resourceType) => new(resourceType);
	public static implicit operator ResourceType(IntegerResourceType intResource) => new((int)intResource);
}
