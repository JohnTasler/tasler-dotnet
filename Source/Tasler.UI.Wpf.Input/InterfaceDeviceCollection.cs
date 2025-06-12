using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Interop;
using System.Windows.Threading;
using Tasler.Interop.Kernel;
using Tasler.Interop.RawInput;
using Tasler.Interop.RawInput.User;
using Tasler.Interop.User;

namespace Tasler.Windows.Input;

public class InterfaceDeviceCollection : ReadOnlyObservableCollection<InterfaceDevice>
{
	#region Static Fields
	[ThreadStatic]
	public static readonly InterfaceDeviceCollection Instance = new InterfaceDeviceCollection();
	#endregion Static Fields

	#region Instance Fields
	private HwndSource? _hwndSource;

	private Dictionary<InterfaceDeviceType, Dictionary<string, int>> _deviceTypeNameMaps = [];
	#endregion Instance Fields

	#region Construction
	private InterfaceDeviceCollection()
		: base(new ObservableCollection<InterfaceDevice>())
	{
		ComponentDispatcher.ThreadIdle += this.ComponentDispatcher_ThreadIdle;

		foreach (RAWINPUTDEVICELIST device in RawInputApi.GetRawInputDeviceList())
			this.AddInputDevice(device);
	}
	#endregion Construction

	#region Private Implementation
	private void AddInputDevice(RAWINPUTDEVICELIST device)
	{
		InterfaceDevice inputDevice = InterfaceDevice.FromRAWINPUTDEVICELIST(device);
		base.Items.Add(inputDevice);

		if (!_deviceTypeNameMaps.TryGetValue(device.DeviceType, out var nameMap))
		{
			nameMap = new();
			_deviceTypeNameMaps.Add(device.DeviceType, nameMap);
		}

		if (!nameMap.TryGetValue(inputDevice.Name, out int inputDeviceIndex))
		{
			inputDeviceIndex = nameMap.Count;
			nameMap.Add(inputDevice.Name, inputDeviceIndex);
		}

		inputDevice.DisplayName = string.Format("{0}{1}", inputDevice.DeviceType, inputDeviceIndex);
	}

	private bool FindThreadHwndSource()
	{
		return !UserApi.EnumWindows(hwnd =>
		{
			UserApi.GetWindowThreadProcessId(hwnd, out var windowProcessId);
			if (windowProcessId == KernelApi.GetCurrentProcessId())
				_hwndSource = HwndSource.FromHwnd(hwnd.Handle);
			return _hwndSource == null;
		});
	}

	private void OnDeviceNodeChange()
	{
		// Get the current list of raw input devices from the system
		RAWINPUTDEVICELIST[] currentDevices = RawInputApi.GetRawInputDeviceList();

		// Find the ones that have been added
		var added = new List<RAWINPUTDEVICELIST>(currentDevices.Length);
		foreach (var device in currentDevices)
			if (!this.ItemsContains(device))
				added.Add(device);

		// Find the ones that have been removed (using a Stack<T> so that the greater indices are first)
		var removed = new Stack<int>(currentDevices.Length);
		for (var index = 0; index < base.Items.Count; ++index)
			if (!this.ItemIsInDeviceList(base.Items[index], currentDevices))
				removed.Push(index);

		// Remove the ones that have been removed
		foreach (var index in removed)
			base.Items.RemoveAt(index);

		// Add the ones that have been added
		foreach (var device in added)
			this.AddInputDevice(device);
	}

	private bool ItemsContains(RAWINPUTDEVICELIST device)
	{
		for (var index = 0; index < base.Items.Count; ++index)
			if (base.Items[index].Equals(device))
				return true;
		return false;
	}

	private bool ItemIsInDeviceList(InterfaceDevice inputDevice, RAWINPUTDEVICELIST[] devices)
	{
		for (var index = 0; index < devices.Length; ++index)
			if (inputDevice.Equals(devices[index]))
				return true;
		return false;
	}

	#endregion Private Implementation

	#region Event Handlers

	private void ComponentDispatcher_ThreadIdle(object? sender, EventArgs e)
	{
		Debug.Assert(_hwndSource == null);
		if (this.FindThreadHwndSource())
		{
			Debug.Assert(_hwndSource != null);
			_hwndSource.AddHook(this.HwndSource_Hook);
			ComponentDispatcher.ThreadIdle -= this.ComponentDispatcher_ThreadIdle;
			this.OnDeviceNodeChange();
		}
	}

	private IntPtr HwndSource_Hook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
	{
		switch ((WM)msg)
		{
			case WM.DEVICECHANGE:
				if (wParam.ToInt64() == (int)DBT.DevNodesChanged)
					Dispatcher.CurrentDispatcher.BeginInvoke(new Action(this.OnDeviceNodeChange));
				return new IntPtr(1);

			case WM.DESTROY:
				_hwndSource = null;
				ComponentDispatcher.ThreadIdle += this.ComponentDispatcher_ThreadIdle;
				break;
		}

		return IntPtr.Zero;
	}

	#endregion Event Handlers
}
