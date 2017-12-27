using System;
using System.Runtime.InteropServices;

namespace Tasler.Interop.Com
{
	/// <summary>
	/// CLSCTX
	/// </summary>
	[Flags]
	public enum ClsCtx
	{
		InprocServer = 0x1,
		InprocHandler = 0x2,
		LocalServer = 0x4,
		InprocServer16 = 0x8,
		RemoteServer = 0x10,
		InprocHandler16 = 0x20,
		NoCodeDownload = 0x400,
		NoCustomMarshal = 0x1000,
		EnableCodeDownload = 0x2000,
		NoFailureLog = 0x4000,
		DisableActivateAsActivator = 0x8000,
		EnableActivateAsActivator = 0x10000,
		FromDefaultContext = 0x20000,
		Activate32BitServer = 0x40000,
		Activate64BitServer = 0x80000
	}

}
