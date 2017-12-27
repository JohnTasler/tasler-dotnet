using Windows.UI.Xaml;

namespace Tasler.UI.Xaml
{
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
	}
}
