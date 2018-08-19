using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Tasler.Interop.Com
{
	/// <summary>
	/// Managed code wrapper for the standard Global Interface Table.
	/// </summary>
	internal class GlobalInterfaceTable : IGlobalInterfaceTable
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

		#region Instance Fields
		private IntPtr _pGit;
		private IntPtr _vtbl;
		private RegisterInterfaceInGlobalDelegate _fnRegisterInterfaceInGlobal;
		private RevokeInterfaceFromGlobalDelegate _fnRevokeInterfaceFromGlobal;
		private GetInterfaceFromGlobalDelegate _fnGetInterfaceFromGlobal;
		#endregion Instance Fields

		#region Construction / Finalization
		public GlobalInterfaceTable()
		{
			var clsidStdGlobalInterfaceTable = typeof(StdGlobalInterfaceTable).GUID;
			var iidIGlobalInterfaceTable = typeof(IGlobalInterfaceTable).GUID;

			int hr = ComApi.CoCreateInstance(ref clsidStdGlobalInterfaceTable, IntPtr.Zero,
				ClsCtx.InprocServer, ref iidIGlobalInterfaceTable, out _pGit);
			if (hr < 0)
				Marshal.ThrowExceptionForHR(hr);

			_vtbl = Marshal.ReadIntPtr(_pGit);
			IntPtr pfnRegisterInterfaceInGlobal = Marshal.ReadIntPtr(_vtbl, IntPtr.Size * RegisterInterfaceInGlobalIndex);
			IntPtr pfnRevokeInterfaceFromGlobal = Marshal.ReadIntPtr(_vtbl, IntPtr.Size * RevokeInterfaceFromGlobalIndex);
			IntPtr pfnGetInterfaceFromGlobal    = Marshal.ReadIntPtr(_vtbl, IntPtr.Size * GetInterfaceFromGlobalIndex);

			_fnRegisterInterfaceInGlobal = (RegisterInterfaceInGlobalDelegate)
				Marshal.GetDelegateForFunctionPointer(pfnRegisterInterfaceInGlobal,
					typeof(RegisterInterfaceInGlobalDelegate));
			_fnRevokeInterfaceFromGlobal = (RevokeInterfaceFromGlobalDelegate)
				Marshal.GetDelegateForFunctionPointer(pfnRevokeInterfaceFromGlobal,
					typeof(RevokeInterfaceFromGlobalDelegate));
			_fnGetInterfaceFromGlobal = (GetInterfaceFromGlobalDelegate)
				Marshal.GetDelegateForFunctionPointer(pfnGetInterfaceFromGlobal,
					typeof(GetInterfaceFromGlobalDelegate));
		}

		~GlobalInterfaceTable()
		{
			_vtbl = IntPtr.Zero;
			_fnRegisterInterfaceInGlobal = null;
			_fnRevokeInterfaceFromGlobal = null;
			_fnGetInterfaceFromGlobal = null;

			if (_pGit != IntPtr.Zero)
			{
				Marshal.Release(_pGit);
				_pGit = IntPtr.Zero;
			}
		}
		#endregion Construction / Finalization

		#region IGlobalInterfaceTable Methods

		public int RegisterInterfaceInGlobal(object pUnk, ref Guid riid, out int pdwCookie)
		{
			IntPtr pUnknown = Marshal.GetIUnknownForObject(pUnk);
			int hr = _fnRegisterInterfaceInGlobal(_vtbl, pUnknown, ref riid, out pdwCookie);
			Marshal.Release(pUnknown);
			return hr;
		}

		public int RevokeInterfaceFromGlobal(int dwCookie)
		{
			return _fnRevokeInterfaceFromGlobal(_vtbl, dwCookie);
		}

		public int GetInterfaceFromGlobal(int dwCookie, ref Guid riid, out object ppv)
		{
			int hr = _fnGetInterfaceFromGlobal(_vtbl, dwCookie, ref riid, out IntPtr pUnknown);
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
