#if WINDOWS_UWP
using Windows.UI.Xaml;
namespace Tasler.UI.Xaml;
#elif WINDOWS_WPF
using System.Windows;
namespace Tasler.Windows;
#endif

// TODO: NEEDS_UNIT_TESTS?

public static class AttachedPropertyFactory<TOwner> where TOwner : class
{
	public static DependencyProperty Register<TProperty>(string propertyName)
	{
		return Register(propertyName, default(TProperty));
	}

	public static DependencyProperty Register<TProperty>(string propertyName, TProperty defaultValue)
	{
		return DependencyProperty.RegisterAttached(propertyName, typeof(TProperty), typeof(TOwner),
				new PropertyMetadata(defaultValue));
	}

	public static DependencyProperty Register<TProperty>(
			string propertyName, PropertyChangedCallback propertyChangedCallback)
	{
		return Register(propertyName, default(TProperty), propertyChangedCallback);
	}

	public static DependencyProperty Register<TProperty>(
			string propertyName, TProperty defaultValue, PropertyChangedCallback propertyChangedCallback)
	{
		return DependencyProperty.RegisterAttached(propertyName, typeof(TProperty), typeof(TOwner),
				new PropertyMetadata(defaultValue, propertyChangedCallback));
	}
}

public static class AttachedPropertyFactory
{
	public static DependencyProperty Register<TProperty>(Type ownerType, string propertyName)
	{
		return Register(ownerType, propertyName, default(TProperty));
	}

	public static DependencyProperty Register<TProperty>(Type ownerType, string propertyName, TProperty defaultValue)
	{
		return DependencyProperty.RegisterAttached(propertyName, typeof(TProperty), ownerType,
				new PropertyMetadata(defaultValue));
	}

	public static DependencyProperty Register<TProperty>(
		Type ownerType, string propertyName, PropertyChangedCallback propertyChangedCallback)
	{
		return Register(ownerType, propertyName, default(TProperty), propertyChangedCallback);
	}

	public static DependencyProperty Register<TProperty>(
			Type ownerType, string propertyName, TProperty defaultValue, PropertyChangedCallback propertyChangedCallback)
	{
		return DependencyProperty.RegisterAttached(propertyName, typeof(TProperty), ownerType,
			new PropertyMetadata(defaultValue, propertyChangedCallback));
	}
}
