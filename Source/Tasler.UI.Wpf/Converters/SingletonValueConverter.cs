using System.Windows.Data;

namespace Tasler.Windows.Converters
{
	public abstract class SingletonValueConverter<T> : BaseValueConverter
		where T : IValueConverter, new()
	{
		public static IValueConverter Instance { get; } = new T();
	}
}
