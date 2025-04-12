using System.Windows.Data;

namespace Tasler.Windows.Converters;

public abstract class SingletonValueConverter<T> : BaseValueConverter
	where T : BaseValueConverter, new()
{
	#region Static Properties
	public static readonly IValueConverter Instance = new T();
	#endregion Static Properties
}
