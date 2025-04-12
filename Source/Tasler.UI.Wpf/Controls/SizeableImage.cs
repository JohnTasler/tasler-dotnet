using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tasler.Windows.Media.Imaging;

namespace Tasler.Windows.Controls;

public class SizeableImage : FrameworkElement
{
	#region Instance Fields
	private Image _image;
	#endregion Instance Fields

	#region Construction
	public SizeableImage()
	{
		_image = new Image();
		base.AddVisualChild(_image);
	}
	#endregion Construction

	#region Dependency Properties

	#region ImageFactory
	public static DependencyProperty ImageFactoryProperty = DependencyProperty.Register(
		"ImageFactory", typeof(ISizeableImageFactory), typeof(SizeableImage),
			new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure,
				SizeableImage.ImageFactoryPropertyChanged));

	public ISizeableImageFactory ImageFactory
	{
		get { return (ISizeableImageFactory)base.GetValue(SizeableImage.ImageFactoryProperty); }
		set { base.SetValue(SizeableImage.ImageFactoryProperty, value); }
	}

	private static void ImageFactoryPropertyChanged(DependencyObject? d, DependencyPropertyChangedEventArgs e)
	{
		if (d is SizeableImage instance)
			instance.ImageFactoryPropertyChanged((ISizeableImageFactory)e.OldValue, (ISizeableImageFactory)e.NewValue);
	}

	private void ImageFactoryPropertyChanged(ISizeableImageFactory oldValue, ISizeableImageFactory newValue)
	{
		if (oldValue is not null)
		{
			_image.Source = null;
			oldValue.Loaded -= this.ImageFactory_Loaded;
			oldValue.Failed -= this.ImageFactory_Failed;
		}

		if (newValue != null)
		{
			newValue.Loaded += this.ImageFactory_Loaded;
			newValue.Failed += this.ImageFactory_Failed;
			newValue.RequestImageSource(new Int32Size((int)this.ActualWidth, (int)this.ActualHeight));
		}
	}
	#endregion ImageFactory

	#region Stretch
	public static DependencyProperty StretchProperty =
		Viewbox.StretchProperty.AddOwner(typeof(SizeableImage),
			new FrameworkPropertyMetadata(Stretch.Uniform, FrameworkPropertyMetadataOptions.AffectsMeasure,
				SizeableImage.StretchPropertyChanged));

	public Stretch Stretch
	{
		get => (Stretch)base.GetValue(SizeableImage.StretchProperty);
		set => base.SetValue(SizeableImage.StretchProperty, value);
	}

	private static void StretchPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		SizeableImage instance = (SizeableImage)d;
		instance._image.Stretch = (Stretch)e.NewValue;
	}
	#endregion Stretch

	#region StretchDirection
	public static DependencyProperty StretchDirectionProperty =
		Viewbox.StretchDirectionProperty.AddOwner(typeof(SizeableImage),
			new FrameworkPropertyMetadata(StretchDirection.Both, FrameworkPropertyMetadataOptions.AffectsMeasure,
				SizeableImage.StretchDirectionPropertyChanged));

	public StretchDirection StretchDirection
	{
		get => (StretchDirection)base.GetValue(SizeableImage.StretchDirectionProperty);
		set => base.SetValue(SizeableImage.StretchDirectionProperty, value);
	}

	private static void StretchDirectionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		SizeableImage instance = (SizeableImage)d;
		instance._image.StretchDirection = (StretchDirection)e.NewValue;
	}
	#endregion StretchDirection

	#endregion Dependency Properties

	#region Overrides
	protected override int VisualChildrenCount => _image is null ? 0 : 1;

	protected override Visual GetVisualChild(int index)
	{
		if (_image == null || index != 0)
			throw new ArgumentOutOfRangeException("index");

		return _image;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		_image.Measure(availableSize);
		return _image.DesiredSize;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		_image.Arrange(new Rect(finalSize));
		return finalSize;
	}

	protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
	{
		// Perform default processing
		base.OnRenderSizeChanged(sizeInfo);

		// Determine the size of image to request
		Size size = new Size();
		switch (this.Stretch)
		{
			case Stretch.Fill:
				size = sizeInfo.NewSize;
				break;
			case Stretch.None:
			case Stretch.UniformToFill:
				size.Width = size.Height = Math.Max(sizeInfo.NewSize.Width, sizeInfo.NewSize.Height);
				break;
			case Stretch.Uniform:
				size.Width = size.Height = Math.Min(sizeInfo.NewSize.Width, sizeInfo.NewSize.Height);
				break;
		}

		// Request a new image to best fit the size
		ISizeableImageFactory imageFactory = this.ImageFactory;
		if (imageFactory != null)
			imageFactory.RequestImageSource(new Int32Size((int)size.Width, (int)size.Height));
	}
	#endregion Overrides

	#region Event Handlers
	private void ImageFactory_Loaded(object? sender, SizeableImageLoadedEventArgs e)
	{
		_image.Source = e.ImageSource;
	}

	private void ImageFactory_Failed(object? sender, SizeableImageFailedEventArgs e)
	{
		Debug.WriteLine("SizeableImage.ImageFactory_Failed: Exception=" + e.Exception.Message);
	}
	#endregion Event Handlers
}
