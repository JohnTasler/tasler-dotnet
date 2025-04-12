using System.Windows.Media;

namespace Tasler.Windows.Media.Imaging;

public interface ISizeableImageFactory
{
	void RequestImageSource(Int32Size size);

	event EventHandler<SizeableImageLoadedEventArgs> Loaded;

	event EventHandler<SizeableImageFailedEventArgs> Failed;
}

public class SizeableImageLoadedEventArgs : EventArgs
{
	public SizeableImageLoadedEventArgs(ImageSource imageSource)
	{
		this.ImageSource = imageSource;
	}

	public ImageSource ImageSource { get; private set; }
}

public class SizeableImageFailedEventArgs : EventArgs
{
	public SizeableImageFailedEventArgs(Exception exception)
	{
		this.Exception = exception;
	}

	public Exception Exception { get; private set; }
}

