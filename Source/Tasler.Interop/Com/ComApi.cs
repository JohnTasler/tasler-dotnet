using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using CommunityToolkit.Diagnostics;
using Tasler.Interop.Com.Interfaces;

namespace Tasler.Interop.Com;

public static partial class ComApi
{
	public static readonly StrategyBasedComWrappers Wrappers = new();

	/// <summary>
	/// Creates a COM object instance for the specified class and returns a pointer to the requested interface.
	/// </summary>
	/// <param name="clsid">The CLSID of the COM class to instantiate.</param>
	/// <param name="iid">The IID of the interface to retrieve.</param>
	/// <param name="dwClsContext">The context in which the code that manages the newly created object will run.</param>
	/// <returns>A native pointer to the requested COM interface.</returns>
	/// <exception cref="System.Runtime.InteropServices.COMException">
	/// Thrown if the underlying COM call fails.
	/// </exception>
	public static nint CoCreateInstance(Guid clsid, Guid iid, ClsCtx dwClsContext = ClsCtx.Default)
	{
		int hr = NativeMethods.CoCreateInstance(ref clsid, nint.Zero, dwClsContext, ref iid, out nint ppv);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return ppv;
	}

	public static TInterface CoCreateInstance<TInterface>(Guid clsid, ClsCtx dwClsContext = ClsCtx.Default)
		where TInterface : class
	{
		return (TInterface)Wrappers.GetOrCreateObjectForComInstance(
			CoCreateInstance(clsid, typeof(TInterface).GUID, dwClsContext),
			CreateObjectFlags.UniqueInstance);
	}

	public static TInterface CoCreateInstance<TClass, TInterface>(ClsCtx dwClsContext = ClsCtx.Default)
		where TClass : class
		where TInterface : class
	{
		return CoCreateInstance<TInterface>(typeof(TClass).GUID, dwClsContext);
	}

	public static uint CoRegisterClassObject(Guid rclsid, nint pUnk, ClsCtx dwClsContext, RegCls flags)
	{
		int hr = NativeMethods.CoRegisterClassObject(ref rclsid, pUnk, dwClsContext, flags, out uint lpdwRegister);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return lpdwRegister;
	}

	public static uint CoRegisterClassObject(Guid clsID, IClassFactory classFactory, ClsCtx dwClsContext, RegCls flags)
	{
		nint pUnk = Wrappers.GetOrCreateComInterfaceForObject(classFactory, CreateComInterfaceFlags.None);
		return CoRegisterClassObject(clsID, pUnk, dwClsContext, flags);
	}

	public static uint CoRegisterClassObject<T>(ClsCtx dwClsContext, RegCls flags)
		where T : class, IUnknown, new()
	{
		var classFactory = new DefaultClassFactory(() => new T());
		return CoRegisterClassObject(typeof(T).GUID, classFactory, dwClsContext, flags);
	}

	public static int CoRevokeClassObject(uint dwRegister) => NativeMethods.CoRevokeClassObject(dwRegister);

	public static IGlobalInterfaceTable GetGlobalInterfaceTable()
	{
		return CoCreateInstance<IGlobalInterfaceTable>(new Guid("00000323-0000-0000-C000-000000000046"));
	}

	public static IRunningObjectTable GetRunningObjectTable()
	{
		var hr = NativeMethods.GetRunningObjectTable(0, out nint rotHandle);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return (IRunningObjectTable)Wrappers.GetOrCreateObjectForComInstance(rotHandle, CreateObjectFlags.Unwrap);
	}

	public static IBindCtx CreateBindCtx()
	{
		var hr = NativeMethods.CreateBindCtx(0, out nint ctx);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return (IBindCtx)Wrappers.GetOrCreateObjectForComInstance(ctx, CreateObjectFlags.Unwrap);
	}

	public static TQuery QueryInterface<TQuery>(this object @this)
		where TQuery : class
	{
		if (@this is TQuery query)
			return query;

		var wrapperPtr = Wrappers.GetOrCreateComInterfaceForObject(@this, CreateComInterfaceFlags.None);
		int hr = Marshal.QueryInterface(wrapperPtr, typeof(TQuery).GUID, out nint queryPtr);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return (TQuery)Wrappers.GetOrCreateObjectForComInstance(queryPtr, CreateObjectFlags.None);
	}
	public static TWrappers RegisterForTrackingSupport<TWrappers>(this TWrappers @this)
		where TWrappers : ComWrappers
	{
		Guard.IsNotNull(@this);

		ComWrappers.RegisterForTrackerSupport(@this);
		return (TWrappers)@this;
	}

	public static TWrappers RegisterForMarshalling<TWrappers>(this TWrappers @this)
		where TWrappers : ComWrappers
	{
		Guard.IsNotNull(@this);

		ComWrappers.RegisterForMarshalling(@this);
		return (TWrappers)@this;
	}


	#region Nested Types

	private static partial class NativeMethods
	{
		private const string ApiLib = "ole32.dll";

		[LibraryImport(ApiLib)]
		public static partial int CoCreateInstance(
			ref Guid rclsid,
			nint pUnkOuter,
			ClsCtx dwClsContext,
			ref Guid riid,
			out nint ppv);

		[LibraryImport(ApiLib)]
		public static partial int CoRegisterClassObject(
			ref Guid rclsid,
			nint pUnk,
			ClsCtx dwClsContext,
			RegCls flags,
			out uint lpdwRegister
		);

		[LibraryImport(ApiLib)]
		public static partial int CoRevokeClassObject(
			uint dwRegister
		);

		[LibraryImport(ApiLib)]
		public static partial int CoGetClassObject(
			ref Guid rclsid,
			ClsCtx dwClsContext,
			nint pvReserved,
			ref Guid riid,
			out nint ppv);

		[LibraryImport(ApiLib)]
		public static partial int GetRunningObjectTable(int reserved, out nint pprot);

		[LibraryImport(ApiLib)]
		public static partial int CreateBindCtx(int reserved, out nint ppbc);
	}

	#endregion Nested Types
}
