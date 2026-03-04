using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Tasler.Interop;
using Tasler.Interop.User;

namespace Tasler.Windows.Model;

/// <summary>
/// An XML-serializable model for storing and restoring the placement of a window, including its
/// size, position, and state (maximized or normal).
/// </summary>
/// <seealso cref="CommunityToolkit.Mvvm.ComponentModel.ObservableObject" />
public class WindowPlacementModel : ObservableObject
{
	#region Constants
	private const int c_defaultWidth = 640;
	private const int c_defaultHeight = 480;
	#endregion Constants

	public static readonly WindowPlacementModel Unset = new();

	#region Instance Fields
	private WINDOWPLACEMENT _windowPlacement = new();
	#endregion Instance Fields

	#region Constructors
	/// <summary>
	/// Initializes a new instance of the <see cref="WindowPlacementModel"/> class.
	/// </summary>
	public WindowPlacementModel()
		: this(c_defaultWidth, c_defaultHeight)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="WindowPlacementModel"/> class.
	/// </summary>
	/// <param name="defaultWidth">The default width when not yet persisted.</param>
	/// <param name="defaultHeight">The default height when not yet persisted.</param>
	public WindowPlacementModel(int defaultWidth, int defaultHeight)
	{
		// Calculate the default normal position based on centering within the primary screen size
		var normalPosition = new RECT(0, 0, defaultWidth, defaultHeight);
		int offsetX = (int)SystemParameters.MaximizedPrimaryScreenWidth / 2 - defaultWidth / 2;
		int offsetY = (int)SystemParameters.MaximizedPrimaryScreenHeight / 2 - defaultHeight / 2;

		_windowPlacement = new WINDOWPLACEMENT()
		{
			ShowCommand = SW.ShowNormal,
			NormalPosition = normalPosition.Offset(offsetX, offsetY),
		};
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="WindowPlacementModel"/> class.
	/// </summary>
	/// <param name="hwnd">The HWND from which the initial window placement should be taken.</param>
	public WindowPlacementModel(SafeHwnd hwnd)
	{
		Guard.IsNotDefault(hwnd.Handle);
		_windowPlacement = hwnd.GetWindowPlacement();
	}
	#endregion Constructors

	#region Properties

	/// <summary>
	/// Gets or sets a value indicating whether this instance is maximized.
	/// </summary>
	/// <value>
	///   <see langword="true"/> if this instance is maximized; otherwise, <see langword="false"/>.
	/// </value>
	[XmlAttribute]
	public bool IsMaximized
	{
		get => _windowPlacement.ShowCommand == SW.ShowMaximized;
		set => this.SetProperty(ref _windowPlacement.ShowCommand, value ? SW.ShowMaximized : SW.ShowNormal);
	}

	/// <summary>Gets or sets the maximized position.</summary>
	/// <value>The maximized position.</value>
	[XmlAttribute]
	public string? MaximizedPosition
	{
		get
		{
			var point = new Point(_windowPlacement.MaximizedPosition.X, _windowPlacement.MaximizedPosition.Y);

			var converter = new RectConverter();
			return converter.ConvertToInvariantString(point);
		}
		set
		{
			var converter = new PointConverter();
			if (converter.ConvertFromInvariantString(value!) is Point point)
			{
				_windowPlacement.MaximizedPosition.X = (int)point.X;
				_windowPlacement.MaximizedPosition.Y = (int)point.Y;
			}
		}
	}

	[XmlAttribute]
	public string? NormalPosition
	{
		get
		{
			var rect = new Rect(
				_windowPlacement.NormalPosition.Left, _windowPlacement.NormalPosition.Top,
				_windowPlacement.NormalPosition.Width, _windowPlacement.NormalPosition.Height);

			var converter = new RectConverter();
			return converter.ConvertToInvariantString(rect);
		}
		set
		{
			var converter = new RectConverter();
			if (converter.ConvertFromInvariantString(value!) is Rect rect)
			{
				_windowPlacement.NormalPosition.Left = (int)(rect.X);
				_windowPlacement.NormalPosition.Top = (int)rect.Y;
				_windowPlacement.NormalPosition.Right = (int)(rect.X + rect.Width);
				_windowPlacement.NormalPosition.Bottom = (int)(rect.Y + rect.Height);
			}
		}
	}

	#endregion Properties

	#region Methods

	/// <summary>
	/// Populates the object with the show state and the restored, minimized, and maximized positions
	/// of the window specified by the <paramref name="hwnd"/> parameter.
	/// </summary>
	/// <param name="hwnd">The HWND.</param>
	public void Get(SafeHwnd hwnd)
	{
		Guard.IsNotDefault(hwnd.Handle);

		hwnd.GetWindowPlacement(ref _windowPlacement);
		this.OnPropertyChanged("*");
	}

	/// <summary>
	/// Applies the show state and the restored, minimized, and maximized positions to the window
	/// specified by the <paramref name="hwnd"/> parameter.
	/// </summary>
	/// <param name="hwnd">The HWND.</param>
	public void Set(SafeHwnd hwnd)
	{
		Guard.IsNotDefault(hwnd.Handle);
		hwnd.SetWindowPlacement(ref _windowPlacement);
	}

	#endregion Methods
}
