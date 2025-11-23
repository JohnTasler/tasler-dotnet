using Microsoft.Xaml.Behaviors;
using System.Runtime.InteropServices;
using Tasler.Extensions;
using Tasler.Interop.Com;
using Tasler.Interop.Com.Extensions;
using Tasler.Interop.Shell.AutoComplete;
using System.Diagnostics;

#if WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
namespace Tasler.UI.Xaml.Attachments;

#elif WINDOWS_WPF
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace Tasler.Windows.Attachments;
#endif

public abstract partial class AutoComplete
{
	private class PrivateBehavior : Behavior<TextBox>
	{
		public AutoCompleteMode Mode
		{
			get;
			set
			{
				if (field != value)
				{
					field = value;
					this.ResetMode();
				}
			}
		}

		private void ResetMode()
		{
			if (this.Mode != AutoCompleteMode.None)
				this.ResetSources();
		}

		public bool UseTabKey { get; set; }

		public AutoCompleteSources Sources
		{
			get;
			set
			{
				if (field != value)
				{
					field = value;
					this.ResetSources();
				}
			}
		}

		private void ResetSources()
		{
			if (_acMultiList is not null)
				Marshal.Release(ComApi.Wrappers.GetOrCreateComInterfaceForObject(_acMultiList, CreateComInterfaceFlags.None));
			if (_enumString is not null)
				Marshal.Release(ComApi.Wrappers.GetOrCreateComInterfaceForObject(_enumString, CreateComInterfaceFlags.None));

//			_acMultiList = ComApi.CoCreateInstance<IACList>(Guids.Guid_ACLMulti);
			_acMultiList = ComApi.CoCreateInstance<IACList>(new Guid("F66C5CE8-2EF9-41D4-A55D-CC65B5F8D114"));
			IObjMgr objMgr = (IObjMgr)_acMultiList;

			var flags = this.Sources;
			if (flags == AutoCompleteSources.Default)
				flags = AutoCompleteSources.FileSystem | AutoCompleteSources.UrlAll;

			//if (flags.HasAnyFlag(AutoCompleteSources.FileSystem | AutoCompleteSources.FileSystemOnly | AutoCompleteSources.FileSystemDirs | AutoCompleteSources.VirtualNamespace))
			{
				//var options = AutoCompleteListOptions.None;
				//if (flags.HasAnyFlag(AutoCompleteSources.FileSystem))
				//	options = AutoCompleteListOptions.FileSysOnly | AutoCompleteListOptions.CurrentDir | AutoCompleteListOptions.Desktop | AutoCompleteListOptions.MyComputer;
				//if (flags.HasAnyFlag(AutoCompleteSources.FileSystemOnly | AutoCompleteSources.FileSystemDirs))
				//	options |=  AutoCompleteListOptions.CurrentDir | AutoCompleteListOptions.Desktop | AutoCompleteListOptions.MyComputer;
				//if (flags.HasAnyFlag(AutoCompleteSources.FileSystemOnly))
				//	options |= AutoCompleteListOptions.FileSysOnly;
				//if (flags.HasAnyFlag(AutoCompleteSources.FileSystemDirs))
				//	options |= AutoCompleteListOptions.FileSysDirs;
				//if (flags.HasAnyFlag(AutoCompleteSources.VirtualNamespace))
				//	options |= AutoCompleteListOptions.VirtualNamespace;

				//options = AutoCompleteListOptions.CurrentDir | AutoCompleteListOptions.MyComputer;

//				var acList = ComApi.CoCreateInstance<IACList2>(Guids.Guid_ACListISF);
				var acList = ComApi.CoCreateInstance<IACList2>(new Guid("2C1C211F-1859-4D6A-B291-E82B95609C9A"));
				//acList.SetOptions(options);
				objMgr.Append((IEnumString)acList);
			}

			//if (flags.HasAnyFlag(AutoCompleteSources.UrlMru))
			//{
			//	objMgr.Append(ComApi.CoCreateInstance<IEnumString>(Guids.Guid_ACLMRU));
			//}

			//if (flags.HasAnyFlag(AutoCompleteSources.UrlHistory))
			//{
			//	objMgr.Append(ComApi.CoCreateInstance<IEnumString>(Guids.Guid_ACLHistory));
			//}

			// TODO: Add custom list if specified

			_enumString = (IEnumString)_acMultiList;
		}

		protected override void OnAttached()
		{
			if (AssociatedObject.IsLoaded)
				this.DoAttach();
			else
				AssociatedObject.Loaded += this.AssociatedObject_Loaded;
		}

		private void DoAttach()
		{
			AssociatedObject.TextChanged += this.AssociatedObject_TextChanged;
			AssociatedObject.KeyDown += this.AssociatedObject_KeyDown;
			AssociatedObject.KeyUp += this.AssociatedObject_KeyUp;
			this.RefreshSuggestions();
		}

		private void AssociatedObject_Loaded(object sender, RoutedEventArgs args)
		{
			Debug.WriteLine($"AssociatedObject_Loaded:");
			AssociatedObject.Loaded -= this.AssociatedObject_Loaded;
			this.DoAttach();
		}

		private void AssociatedObject_TextChanged(object sender, TextChangedEventArgs e)
		{
			Debug.WriteLine($"AssociatedObject_TextChanged: _inTextChanged={_inTextChanged}");

			if (_inTextChanged)
				return;

			using var textChangeScope = new DisposeScopeExit(() => _inTextChanged = true, () => _inTextChanged = false);

			var value = AssociatedObject.Text;
			if (value.Length == 0)
			{
				this.RefreshSuggestions();
			}
			else
			{
				int hr = _acMultiList.Expand(value);
				if (hr < 0 || !value.EndsWith('\\'))
				{
					var suggestions = GetSuggestions(AssociatedObject)
						.Where(s => s.StartsWith(value, StringComparison.CurrentCultureIgnoreCase));
					SetSuggestions(AssociatedObject, new(suggestions));
				}
				else
				{
					this.RefreshSuggestions();
				}

				var suggestionCollection = GetSuggestions(AssociatedObject);
				var matchingText = suggestionCollection.FirstOrDefault(s => s.StartsWith(value, StringComparison.CurrentCultureIgnoreCase));
				if (matchingText is not null)
				{
					var valueLength = value.Length;
					AssociatedObject.Text = matchingText;
					AssociatedObject.Select(valueLength, matchingText.Length - valueLength);
				}
			}
		}

		private void RefreshSuggestions()
		{
			var suggestions = _enumString.AsEnumerable().ToList();
			SetSuggestions(AssociatedObject, new(suggestions));
		}

		private void AssociatedObject_KeyDown(object sender, KeyEventArgs e)
		{
			Debug.WriteLine($"AssociatedObject_KeyDown: Key={e.Key}");
		}

		private void AssociatedObject_KeyUp(object sender, KeyEventArgs e)
		{
			Debug.WriteLine($"AssociatedObject_KeyUp: Key={e.Key}");
		}


		private IACList _acMultiList = null!;
		private IEnumString _enumString = null!;
		private bool _inTextChanged;

		protected override void OnDetaching()
		{
		}
	}
}
