using System.Runtime.InteropServices;
using Tasler.Interop;
using Tasler.Interop.Com;
using Tasler.Interop.Com.Extensions;
using Tasler.Interop.Shell;
using Tasler.Interop.Shell.AutoComplete;
using TrimmingTests;

Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown);
Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

#if true

Console.WriteLine(PropertyKeys.Core.FileAttributes.Name);

IShellFolder2 desktopFolder = ShellApi.GetDesktopFolder();

SFGAOF flags = SFGAOF.Hidden | SFGAOF.FileSystem;
desktopFolder.ParseDisplayName(nint.Zero, null, "desktop.ini", out var eaten, out var idlist, ref flags);
using var relativeIdList = new ChildItemIdList(idlist);

IShellItem item = ShellApi.CreateShellItem(new (), desktopFolder, relativeIdList);
IShellItem2 item2 = (IShellItem2)item;

var propertyKey = PropertyKeys.Core.FileAttributes;
var property = item2.GetProperty(ref propertyKey);

propertyKey = PropertyKeys.Core.DateModified;
property = item2.GetProperty(ref propertyKey);

propertyKey = PropertyKeys.Core.ItemPathDisplay;
var path = item2.GetString(propertyKey);

propertyKey = PropertyKeys.Core.ShellOmitFromView;
var omit = item2.GetString(propertyKey);

// var clsid = PropSysApi.PSLookupPropertyHandlerCLSID(@"C:\Users\John Tasler\Desktop\desktop.ini");
// Console.WriteLine($"PSLookupPropertyHandlerCLSID = {clsid:B}");



var propertyStore = item2.GetItemPropertyStore(GetPropertyStoreFlags.ReadWrite | GetPropertyStoreFlags.ExtrinsicPropertiesOnly);
property.vt = VARTYPE.LPWStr;
property.punkVal = Marshal.StringToCoTaskMemUni("True");
propertyStore.SetValue(ref propertyKey, ref property);
propertyStore.Commit();

#else

nint objMgrRaw = ComApi.CoCreateInstance(Guids.Guid_ACLMulti, Guids.Guid_IObjMgr);
var objMgr = (IObjMgr)ComApi.Wrappers.GetOrCreateObjectForComInstance(objMgrRaw, CreateObjectFlags.UniqueInstance);
var objMgrEnumString = ComApi.CoCreateInstance<IEnumString>(Guids.Guid_ACLMulti);
//var objMgr = ComApi.CoCreateInstance<IEnumString>(Guids.Guid_ACLMulti);
var acList = ComApi.CoCreateInstance<IACList>(Guids.Guid_ACListISF);

var enumString = (IEnumString)acList!;
if (enumString is null)
{
	Console.WriteLine("Failed to create instance of CLSID_ACListISF with IEnumString.");
	return;
}
objMgr.Append(enumString);

var acList2 = (IACList2)enumString;
acList2.SetOptions(AutoCompleteListOptions.MyComputer);
// acList2.SetOptions(AutoCompleteListOptions.None);

objMgr.Append(new CustomAcList());

var acMultiEnumString = (IEnumString)objMgr;
acMultiEnumString.Reset();

while (true)
{
	foreach (var item in acMultiEnumString.AsEnumerable())
		Console.WriteLine(item);

	string? input;
	while (true)
	{
		//Console.WriteLine("[0] None"             );
		//Console.WriteLine("[1] Favorites"        );
		//Console.WriteLine("[2] Desktop"          );
		//Console.WriteLine("[3] FileSysOnly"      );
		//Console.WriteLine("[4] FileSysDirs"      );
		//Console.WriteLine("[5] CurrentDir"       );
		//Console.WriteLine("[6] MyComputer"       );
		//Console.WriteLine("[7] VirtualNamespaces");
		Console.Write("> ");
		input = Console.ReadLine() ?? string.Empty;
		//if (string.IsNullOrEmpty(input))
		//{
		//	Console.WriteLine("No input provided. Exiting");
		//	return;
		//}
		/*else*/ if (input.Equals("exit", StringComparison.OrdinalIgnoreCase) || input.Equals("quit", StringComparison.OrdinalIgnoreCase))
		{
			Console.WriteLine("Exiting.");
			return;
		}
		else if (input.Equals("cls", StringComparison.OrdinalIgnoreCase))
		{
			Console.Write("\ec\e[;H\e[1A"); // Clear the console
			continue;
		}
		//else if (input.Length == 1 && input[0] >= '0' && input[0] <= '7')
		//{
		//	var selectedOption = input[0] - '0';
		//	input = string.Empty;

		//	switch (selectedOption)
		//	{
		//		case 0:
		//			acList2.SetOptions(AutoCompleteListOptions.None);
		//			break;
		//		case 1:
		//			acList2.SetOptions(AutoCompleteListOptions.Favorites);
		//			break;
		//		case 2:
		//			acList2.SetOptions(AutoCompleteListOptions.Desktop);
		//			break;
		//		case 3:
		//			acList2.SetOptions(AutoCompleteListOptions.FileSysOnly);
		//			break;
		//		case 4:
		//			acList2.SetOptions(AutoCompleteListOptions.FileSysDirs);
		//			break;
		//		case 5:
		//			acList2.SetOptions(AutoCompleteListOptions.CurrentDir);
		//			break;
		//		case 6:
		//			acList2.SetOptions(AutoCompleteListOptions.MyComputer);
		//			break;
		//		case 7:
		//			acList2.SetOptions(AutoCompleteListOptions.VirtualNamespace);
		//			break;
		//	}
		//	break;
		//}

		if (input.Length == 1)
		{
			input += @":\";
		}
		else if (!input.EndsWith('\\'))
		{
			var saveInput = input;
			var lastBackslash = input.LastIndexOf(@"\", StringComparison.OrdinalIgnoreCase);
			if (lastBackslash != -1)
			{
				acMultiEnumString.Reset();
				var acListMulti = (IACList)acMultiEnumString;
				int hr = acListMulti.Expand(input.Substring(0, lastBackslash + 1));
				if (hr < 0)
					Console.WriteLine($"{hr:X8} {Marshal.GetExceptionForHR(hr)?.Message}");

				var firstMatch = acMultiEnumString.AsEnumerable()
					.FirstOrDefault(s => (s??string.Empty)
					.StartsWith(saveInput, StringComparison.CurrentCultureIgnoreCase));
				if (firstMatch is not null)
					input = firstMatch;
			}
		}

		break;
	}

	{
		//enumString?.Reset();
		acMultiEnumString.Reset();
		var acListMulti = (IACList)acMultiEnumString;
		int hr = acListMulti.Expand(input);
		if (hr < 0)
			Console.WriteLine($"{hr:X8} {Marshal.GetExceptionForHR(hr)?.Message}");
	}
}
#endif
