using System.Windows;
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

	#region Instance Fields
	private WINDOWPLACEMENT _windowPlacement;
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

	/// <summary>Gets or sets the maximized width.</summary>
	/// <value>The maximized width.</value>
	[XmlAttribute]
	public int MaximizedX
	{
		get => _windowPlacement.MaximizedPosition.X;
		set => this.SetProperty(ref _windowPlacement.MaximizedPosition.X, value);
	}

	/// <summary>Gets or sets the maximized height.</summary>
	/// <value>The maximized height.</value>
	[XmlAttribute]
	public int MaximizedY
	{
		get => _windowPlacement.MaximizedPosition.Y;
		set => this.SetProperty(ref _windowPlacement.MaximizedPosition.Y, value);
	}

	/// <summary>Gets or sets the left coordinate of the normal position rectangle.</summary>
	/// <value>The left coordinate.</value>
	[XmlAttribute]
	public int Left
	{
		get => _windowPlacement.NormalPosition.Left;
		set => this.SetProperty(ref _windowPlacement.NormalPosition.Left, value);
	}

	/// <summary>Gets or sets the top coordinate of the normal position rectangle.</summary>
	/// <value>The top coordinate.</value>
	[XmlAttribute]
	public int Top
	{
		get => _windowPlacement.NormalPosition.Top;
		set => this.SetProperty(ref _windowPlacement.NormalPosition.Top, value);
	}

	/// <summary>Gets or sets the right coordinate of the normal position rectangle.</summary>
	/// <value>The right coordinate.</value>
	[XmlAttribute]
	public int Right
	{
		get => _windowPlacement.NormalPosition.Right;
		set => this.SetProperty(ref _windowPlacement.NormalPosition.Right, value);
	}

	/// <summary>Gets or sets the bottom coordinate of the normal position rectangle.</summary>
	/// <value>The bottom coordinate.</value>
	[XmlAttribute]
	public int Bottom
	{
		get => _windowPlacement.NormalPosition.Bottom;
		set => this.SetProperty(ref _windowPlacement.NormalPosition.Bottom, value);
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

		var wp = hwnd.GetWindowPlacement();

		this.IsMaximized = wp.ShowCommand == SW.ShowMaximized;
		this.MaximizedX = wp.MaximizedPosition.X;
		this.MaximizedY = wp.MaximizedPosition.Y;
		this.Left = wp.NormalPosition.Left;
		this.Top = wp.NormalPosition.Top;
		this.Right = wp.NormalPosition.Right;
		this.Bottom = wp.NormalPosition.Bottom;
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
