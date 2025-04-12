#if WINDOWS_UWP
using Windows.UI.Xaml;
namespace Tasler.UI.Xaml;
#elif WINDOWS_WPF
using System.Windows;
namespace Tasler.Windows;
#endif

// TODO: NEEDS_UNIT_TESTS

public static class DependencyPropertyFactory<TOwner> where TOwner : DependencyObject
{
	public static DependencyProperty Register<TProperty>(string propertyName)
	{
		return Register(propertyName, default(TProperty));
	}

	public static DependencyProperty Register<TProperty>(string propertyName, TProperty defaultValue)
	{
		return DependencyProperty.Register(propertyName, typeof(TProperty), typeof(TOwner),
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
		return DependencyProperty.Register(propertyName, typeof(TProperty), typeof(TOwner),
				new PropertyMetadata(defaultValue, propertyChangedCallback));
	}

	public static DependencyPropertyKey RegisterReadOnly<TProperty>(string propertyName)
	{
		return RegisterReadOnly(propertyName, default(TProperty));
	}

	public static DependencyPropertyKey RegisterReadOnly<TProperty>(string propertyName, TProperty defaultValue)
	{
#if WINDOWS_UWP
		return new DependencyPropertyKey(DependencyProperty.Register(propertyName,
			typeof(TProperty), typeof(TOwner), new PropertyMetadata(defaultValue)));
#elif WINDOWS_WPF
		return DependencyProperty.RegisterReadOnly(propertyName,
			typeof(TProperty), typeof(TOwner), new PropertyMetadata(defaultValue));
#endif
	}

	public static DependencyPropertyKey RegisterReadOnly<TProperty>(
		string propertyName, PropertyChangedCallback propertyChangedCallback)
	{
		return RegisterReadOnly(propertyName, default(TProperty), propertyChangedCallback);
	}

	public static DependencyPropertyKey RegisterReadOnly<TProperty>(
		string propertyName, TProperty defaultValue, PropertyChangedCallback propertyChangedCallback)
	{
#if WINDOWS_UWP
		return new DependencyPropertyKey(DependencyProperty.Register(propertyName,
			typeof(TProperty), typeof(TOwner), new PropertyMetadata(defaultValue, propertyChangedCallback)));
#elif WINDOWS_WPF
		return DependencyProperty.RegisterReadOnly(propertyName,
			typeof(TProperty), typeof(TOwner), new PropertyMetadata(defaultValue, propertyChangedCallback));
#endif
	}
}
