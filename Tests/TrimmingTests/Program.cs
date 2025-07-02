using Tasler.Interop.Com;
using Tasler.Interop.Shell.AutoComplete;

Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown);
Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

var acList = ComApi.CoCreateInstance<IACList>(Guids.Guid_ACListISF);
var enumString = (IEnumString)acList!;
if (enumString is null)
{
	Console.WriteLine("Failed to create instance of CLSID_ACListISF with IEnumString.");
	return;
}

var acList2 = (IACList2)enumString;
acList2.SetOptions(AutoCompleteListOptions.MyComputer | AutoCompleteListOptions.FileSysOnly | AutoCompleteListOptions.FileSysDirs);
// acList2.SetOptions(AutoCompleteListOptions.None);

while (true)
{
	foreach (var item in enumString.AsEnumerable())
		Console.WriteLine(item);

	string? input;
	while (true)
	{
		Console.WriteLine("[0] None"             );
		Console.WriteLine("[1] Favorites"        );
		Console.WriteLine("[2] Desktop"          );
		Console.WriteLine("[3] FileSysOnly"      );
		Console.WriteLine("[4] FileSysDirs"      );
		Console.WriteLine("[5] CurrentDir"       );
		Console.WriteLine("[6] MyComputer"       );
		Console.WriteLine("[7] VirtualNamespaces");
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
		else if (input.Length == 1 && input[0] >= '0' && input[0] <= '7')
		{
			var selectedOption = input[0] - '0';
			input = string.Empty;

			switch (selectedOption)
			{
				case 0:
					acList2.SetOptions(AutoCompleteListOptions.None);
					break;
				case 1:
					acList2.SetOptions(AutoCompleteListOptions.Favorites);
					break;
				case 2:
					acList2.SetOptions(AutoCompleteListOptions.Desktop);
					break;
				case 3:
					acList2.SetOptions(AutoCompleteListOptions.FileSysOnly);
					break;
				case 4:
					acList2.SetOptions(AutoCompleteListOptions.FileSysDirs);
					break;
				case 5:
					acList2.SetOptions(AutoCompleteListOptions.CurrentDir);
					break;
				case 6:
					acList2.SetOptions(AutoCompleteListOptions.MyComputer);
					break;
				case 7:
					acList2.SetOptions(AutoCompleteListOptions.VirtualNamespace);
					break;
			}
			break;
		}

		//if (!input.EndsWith('\\'))
		//{
		//	input += '\\';
		//}

		break;
	}

	int hr = acList2.Expand(input);
	enumString?.Reset();
}
