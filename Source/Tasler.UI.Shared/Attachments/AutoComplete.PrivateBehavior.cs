using Microsoft.Xaml.Behaviors;
using System.Runtime.InteropServices;
using Tasler.Extensions;
using Tasler.Interop.Com;
using Tasler.Interop.Com.Extensions;
using Tasler.Interop.Shell.AutoComplete;


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

public static partial class AutoComplete
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
		}

		public AutoCompleteFlags Flags
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

			_acMultiList = ComApi.CoCreateInstance<IACList>(Guids.Guid_ACLMulti);
			IObjMgr objMgr = (IObjMgr)_acMultiList;

			var flags = this.Flags;
			if (flags == AutoCompleteFlags.Default)
				flags = AutoCompleteFlags.FileSystem | AutoCompleteFlags.UrlAll;

			if (flags.HasFlag(AutoCompleteFlags.UrlHistory))
			{
				objMgr.Append(ComApi.CoCreateInstance<IEnumString>(Guids.Guid_ACLHistory));
			}

			if (flags.HasFlag(AutoCompleteFlags.UrlMru))
			{
				objMgr.Append(ComApi.CoCreateInstance<IEnumString>(Guids.Guid_ACLMRU));
			}

			if (flags.HasFlag(AutoCompleteFlags.FileSystem | AutoCompleteFlags.FileSystemOnly | AutoCompleteFlags.FileSystemDirs | AutoCompleteFlags.VirtualNamespace))
			{
				var options = AutoCompleteListOptions.None;
				if (flags.HasAnyFlag(AutoCompleteFlags.FileSystem))
					options = AutoCompleteListOptions.FileSysOnly | AutoCompleteListOptions.CurrentDir | AutoCompleteListOptions.Desktop | AutoCompleteListOptions.MyComputer;
				if (flags.HasAnyFlag(AutoCompleteFlags.FileSystemOnly | AutoCompleteFlags.FileSystemDirs))
					options |=  AutoCompleteListOptions.CurrentDir | AutoCompleteListOptions.Desktop | AutoCompleteListOptions.MyComputer;
				if (flags.HasAnyFlag(AutoCompleteFlags.FileSystemOnly))
					options |= AutoCompleteListOptions.FileSysOnly;
				if (flags.HasAnyFlag(AutoCompleteFlags.FileSystemDirs))
					options |= AutoCompleteListOptions.FileSysDirs;
				if (flags.HasAnyFlag(AutoCompleteFlags.VirtualNamespace))
					options |= AutoCompleteListOptions.VirtualNamespace;

				var acList = ComApi.CoCreateInstance<IACList2>(Guids.Guid_ACListISF);
				acList.SetOptions(options);
				objMgr.Append((IEnumString)acList);
			}

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
		}

		private void AssociatedObject_Loaded(object sender, RoutedEventArgs args)
		{
			AssociatedObject.Loaded -= this.AssociatedObject_Loaded;
			this.DoAttach();
		}

		private void AssociatedObject_TextChanged(object sender, TextChangedEventArgs e)
		{
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
				int hr = _acMultiList?.Expand(value) ?? -1;
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
				if (suggestionCollection.Count() > 0)
				{
					AssociatedObject.Select(value.Length, AssociatedObject.Text.Length - value.Length);
					AssociatedObject.Text = suggestionCollection[0];
				}
			}

		}

		private void RefreshSuggestions()
		{
			SetSuggestions(AssociatedObject, new(_enumString?.AsEnumerable() ?? []));
		}

		private void AssociatedObject_KeyDown(object sender, KeyEventArgs e)
		{
		}

		private IACList? _acMultiList;
		private IEnumString? _enumString;
		private bool _inTextChanged;

		protected override void OnDetaching()
		{
		}
	}
}
