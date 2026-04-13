using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Tasler.Interop.User;

public class ResourceValue : IEquatable<ResourceValue>
{
	private nint _id = default;
	public nint Id => _id;

	public string? AsText { get; private set; }

	public ResourceValue(nint id)
	{
		_id = id;

		this.AsText = this.IsIntResouce
			? $"#{this.AsInt}"
			: Marshal.PtrToStringUni(_id);
	}

	public ResourceValue(int id) => _id = id;

	public ResourceValue(string id) => this.AsText = id;

	public bool IsIntResouce => (((nuint)(this.Id)) >> 16) == 0;

	public int AsInt
	{
		get
		{
			if (!this.IsIntResouce)
			{
				var name = Marshal.PtrToStringUni(_id);
				if (name is not null && name.StartsWith('#') && int.TryParse(name.AsSpan(1), out int result))
					return result;
				return 0;
			}

			return (int)(((long)this.Id) & 0xFFFF);
		}
	}

	public override string? ToString()
		=> this.IsIntResouce ? $"#{this.AsInt}" : this.AsText;

	public override bool Equals(object? obj) => this.Equals(obj as ResourceValue);

	public bool Equals(ResourceValue? other) => other is not null && this.Id.Equals(other.Id);

	public override int GetHashCode() => this.Id.GetHashCode();

	public static implicit operator ResourceValue(int resourceIndex) => new(resourceIndex);
	public static implicit operator ResourceValue(nint resourceIndex) => new(resourceIndex);
}
