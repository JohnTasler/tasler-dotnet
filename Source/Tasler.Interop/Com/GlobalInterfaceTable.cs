using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Tasler.Interop.Com
{
	/// <summary>
	/// Managed code wrapper for the standard Global Interface Table.
	/// </summary>
	public class GlobalInterfaceTable : IGlobalInterfaceTable
	{
		#region IGlobalInterfaceTable Method Delegates
		private const int RegisterInterfaceInGlobalIndex = 3;
		private delegate int RegisterInterfaceInGlobalDelegate(
			IntPtr pThis,
			IntPtr pUnk,
			ref Guid riid,
			out int pdwCookie);

		private const int RevokeInterfaceFromGlobalIndex = 4;
		private delegate int RevokeInterfaceFromGlobalDelegate(
			IntPtr pThis,
			int dwCookie);

		private const int GetInterfaceFromGlobalIndex = 5;
		private delegate int GetInterfaceFromGlobalDelegate(
			IntPtr pThis,
			int dwCookie,
			ref Guid riid,
			out IntPtr ppv);
		#endregion IGlobalInterfaceTable Method Delegates

		#region Static Fields
		private static Guid clsidStdGlobalInterfaceTable = typeof(StdGlobalInterfaceTable).GUID;
		private static Guid iidIGlobalInterfaceTable = typeof(IGlobalInterfaceTable).GUID;
		#endregion Static Fields

		#region Instance Fields
		private IntPtr pGit;
		private IntPtr vtbl;
		private RegisterInterfaceInGlobalDelegate fnRegisterInterfaceInGlobal;
		private RevokeInterfaceFromGlobalDelegate fnRevokeInterfaceFromGlobal;
		private GetInterfaceFromGlobalDelegate fnGetInterfaceFromGlobal;
		#endregion Instance Fields

		#region Construction / Finalization
		public GlobalInterfaceTable()
		{
			int hr = ComApi.CoCreateInstance(ref clsidStdGlobalInterfaceTable, IntPtr.Zero,
				ClsCtx.InprocServer, ref iidIGlobalInterfaceTable, out this.pGit);
			if (hr < 0)
				Marshal.ThrowExceptionForHR(hr);

			this.vtbl = Marshal.ReadIntPtr(this.pGit);
			IntPtr pfnRegisterInterfaceInGlobal = Marshal.ReadIntPtr(this.vtbl, 3 * IntPtr.Size);
			IntPtr pfnRevokeInterfaceFromGlobal = Marshal.ReadIntPtr(this.vtbl, 4 * IntPtr.Size);
			IntPtr pfnGetInterfaceFromGlobal = Marshal.ReadIntPtr(this.vtbl, 5 * IntPtr.Size);

			this.fnRegisterInterfaceInGlobal = (RegisterInterfaceInGlobalDelegate)
				Marshal.GetDelegateForFunctionPointer(pfnRegisterInterfaceInGlobal,
					typeof(RegisterInterfaceInGlobalDelegate));
			this.fnRevokeInterfaceFromGlobal = (RevokeInterfaceFromGlobalDelegate)
				Marshal.GetDelegateForFunctionPointer(pfnRevokeInterfaceFromGlobal,
					typeof(RevokeInterfaceFromGlobalDelegate));
			this.fnGetInterfaceFromGlobal = (GetInterfaceFromGlobalDelegate)
				Marshal.GetDelegateForFunctionPointer(pfnGetInterfaceFromGlobal,
					typeof(GetInterfaceFromGlobalDelegate));
		}

		~GlobalInterfaceTable()
		{
			if (this.vtbl != IntPtr.Zero)
				this.vtbl = IntPtr.Zero;

			if (this.pGit != IntPtr.Zero)
			{
				Marshal.Release(this.pGit);
				this.pGit = IntPtr.Zero;
			}
		}
		#endregion Construction / Finalization

		#region IGlobalInterfaceTable Methods

		public int RegisterInterfaceInGlobal(object pUnk, ref Guid riid, out int pdwCookie)
		{
			IntPtr pUnknown = Marshal.GetIUnknownForObject(pUnk);
			int hr = this.fnRegisterInterfaceInGlobal(this.vtbl, pUnknown, ref riid, out pdwCookie);
			Marshal.Release(pUnknown);
			return hr;
		}

		public int RevokeInterfaceFromGlobal(int dwCookie)
		{
			return this.fnRevokeInterfaceFromGlobal(this.vtbl, dwCookie);
		}

		public int GetInterfaceFromGlobal(int dwCookie, ref Guid riid, out object ppv)
		{
			IntPtr pUnknown;
			int hr = this.fnGetInterfaceFromGlobal(this.vtbl, dwCookie, ref riid, out pUnknown);
			ppv = (hr >= 0 && pUnknown != IntPtr.Zero) ? Marshal.GetObjectForIUnknown(pUnknown) : null;
			return hr;
		}

		#endregion IGlobalInterfaceTable Methods
	}

	/// <summary>
	/// StdGlobalInterfaceTable
	/// </summary>
	[ComImport]
	[Guid("00000323-0000-0000-C000-000000000046")]
	internal class StdGlobalInterfaceTable
	{
	}

	/// <summary>
	/// IGlobalInterfaceTable
	/// </summary>
	[ComImport]
	[Guid("00000146-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[SuppressUnmanagedCodeSecurity]
	public interface IGlobalInterfaceTable
	{
		[PreserveSig]
		int RegisterInterfaceInGlobal(
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)]
			object pUnk,
			ref Guid riid,
			out int pdwCookie);

		[PreserveSig]
		int RevokeInterfaceFromGlobal(int dwCookie);

		[PreserveSig]
		int GetInterfaceFromGlobal(
			int dwCookie,
			ref Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)]
			out object ppv);
	}
}
