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
	/// <summary>
	/// Creates a COM object for the specified CLSID and returns a native pointer to the requested interface IID.
	/// </summary>
	/// <param name="clsid">The CLSID of the COM class to instantiate.</param>
	/// <param name="iid">The IID of the interface to retrieve from the created COM object.</param>
	/// <param name="dwClsContext">The execution context for the code that manages the newly created object.</param>
	/// <returns>A raw native pointer to the requested interface.</returns>
	/// <exception cref="System.Runtime.InteropServices.COMException">Thrown when the underlying COM call returns a failure HRESULT.</exception>
	public static nint CoCreateInstance(Guid clsid, Guid iid, ClsCtx dwClsContext = ClsCtx.Default)
	{
		int hr = NativeMethods.CoCreateInstance(ref clsid, nint.Zero, dwClsContext, ref iid, out nint ppv);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return ppv;
	}

	/// <summary>
	/// Creates a COM object for the specified CLSID and returns it as the requested interface.
	/// </summary>
	/// <param name="clsid">The CLSID of the COM class to instantiate.</param>
	/// <param name="dwClsContext">The execution context in which the code that manages the newly created object will run.</param>
	/// <returns>The created COM object wrapped and cast to <typeparamref name="TInterface"/>.</returns>
	public static TInterface CoCreateInstance<TInterface>(Guid clsid, ClsCtx dwClsContext = ClsCtx.Default)
		where TInterface : class
	{
		return (TInterface)Wrappers.GetOrCreateObjectForComInstance(
			CoCreateInstance(clsid, typeof(TInterface).GUID, dwClsContext),
			CreateObjectFlags.UniqueInstance);
	}

	/// <summary>
	/// Creates a COM object for TClass and returns it cast to TInterface.
	/// </summary>
	/// <param name="dwClsContext">The class context used when creating the COM object.</param>
	/// <returns>An instance of <typeparamref name="TInterface"/> representing the created COM object.</returns>
	public static TInterface CoCreateInstance<TClass, TInterface>(ClsCtx dwClsContext = ClsCtx.Default)
		where TClass : class
		where TInterface : class
	{
		return CoCreateInstance<TInterface>(typeof(TClass).GUID, dwClsContext);
	}

	/// <summary>
	/// Registers a COM class object (class factory or raw IUnknown pointer) with the COM runtime.
	/// </summary>
	/// <param name="rclsid">The CLSID of the class to register.</param>
	/// <param name="pUnk">A pointer to the class object (an IUnknown pointer) to register.</param>
	/// <param name="dwClsContext">The execution context in which the code that manages the newly created object will run.</param>
	/// <param name="flags">Registration options that control lifetime and behavior of the class object.</param>
	/// <returns>The registration cookie assigned by COM that identifies the registered class object.</returns>
	/// <exception cref="System.Runtime.InteropServices.COMException">Thrown when the COM call returns a failure HRESULT.</exception>
	public static uint CoRegisterClassObject(Guid rclsid, nint pUnk, ClsCtx dwClsContext, RegCls flags)
	{
		int hr = NativeMethods.CoRegisterClassObject(ref rclsid, pUnk, dwClsContext, flags, out uint lpdwRegister);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return lpdwRegister;
	}

	/// <summary>
	/// Registers a class factory for the specified CLSID with the COM runtime.
	/// </summary>
	/// <param name="clsID">The CLSID of the class to register.</param>
	/// <param name="classFactory">The class factory instance that creates objects for the CLSID.</param>
	/// <param name="dwClsContext">The execution contexts in which the class object is to be made available.</param>
	/// <param name="flags">Registration options that control how the class object is registered.</param>
	/// <returns>The registration cookie for the registered class object.</returns>
	public static uint CoRegisterClassObject(Guid clsID, IClassFactory classFactory, ClsCtx dwClsContext, RegCls flags)
	{
		nint pUnk = Wrappers.GetOrCreateComInterfaceForObject(classFactory, CreateComInterfaceFlags.None);
		return CoRegisterClassObject(clsID, pUnk, dwClsContext, flags);
	}

	/// <summary>
	/// Registers a class factory that creates new instances of T and returns its registration cookie.
	/// </summary>
	/// <typeparam name="T">The concrete COM class type to register; must implement IUnknown and have a public parameterless constructor.</typeparam>
	/// <param name="dwClsContext">The class context in which the code that manages the newly created object will run.</param>
	/// <param name="flags">Registration options that control how the class object is registered.</param>
	/// <returns>The registration cookie that can be used to revoke the class object.</returns>
	public static uint CoRegisterClassObject<T>(ClsCtx dwClsContext, RegCls flags)
		where T : class, IUnknown, new()
	{
		var classFactory = new DefaultClassFactory(() => new T());
		return CoRegisterClassObject(typeof(T).GUID, classFactory, dwClsContext, flags);
	}

	/// <summary>
/// Revokes a previously registered class object using its registration cookie.
/// </summary>
/// <param name="dwRegister">The registration cookie returned by CoRegisterClassObject.</param>
/// <returns>The HRESULT returned by CoRevokeClassObject; `0` (S_OK) on success, a negative value on failure.</returns>
public static int CoRevokeClassObject(uint dwRegister) => NativeMethods.CoRevokeClassObject(dwRegister);

	/// <summary>
	/// Creates a COM Global Interface Table (GIT) instance.
	/// </summary>
	/// <returns>An <see cref="IGlobalInterfaceTable"/> representing the COM Global Interface Table.</returns>
	public static IGlobalInterfaceTable GetGlobalInterfaceTable()
	{
		return CoCreateInstance<IGlobalInterfaceTable>(new Guid("00000323-0000-0000-C000-000000000046"));
	}

	/// <summary>
	/// Obtain the system Running Object Table (ROT) wrapped as an IRunningObjectTable.
	/// </summary>
	/// <returns>An IRunningObjectTable instance representing the system Running Object Table.</returns>
	/// <exception cref="System.Runtime.InteropServices.COMException">Thrown when retrieving the Running Object Table fails with a COM error.</exception>
	public static IRunningObjectTable GetRunningObjectTable()
	{
		var hr = NativeMethods.GetRunningObjectTable(0, out nint rotHandle);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return (IRunningObjectTable)Wrappers.GetOrCreateObjectForComInstance(rotHandle, CreateObjectFlags.Unwrap);
	}

	/// <summary>
	/// Creates a COM bind context and returns an IBindCtx representing it.
	/// </summary>
	/// <returns>The created IBindCtx instance for the new bind context.</returns>
	/// <exception cref="System.Exception">Thrown when the underlying CreateBindCtx call fails; a corresponding exception is thrown for the HRESULT returned.</exception>
	public static IBindCtx CreateBindCtx()
	{
		var hr = NativeMethods.CreateBindCtx(0, out nint ctx);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return (IBindCtx)Wrappers.GetOrCreateObjectForComInstance(ctx, CreateObjectFlags.Unwrap);
	}

	/// <summary>
	/// Obtains the requested COM interface from the given object, returning the object itself when it already implements TQuery.
	/// </summary>
	/// <param name="@this">The source object to query for the interface.</param>
	/// <returns>The requested interface as TQuery.</returns>
	/// <exception cref="System.Runtime.InteropServices.COMException">Thrown when the native QueryInterface call fails with a COM error.</exception>
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
	/// <summary>
	/// Enables tracker support on the provided ComWrappers instance.
	/// </summary>
	/// <param name="this">The ComWrappers instance to enable tracker support for.</param>
	/// <returns>The same <typeparamref name="TWrappers"/> instance.</returns>
	public static TWrappers RegisterForTrackingSupport<TWrappers>(this TWrappers @this)
		where TWrappers : ComWrappers
	{
		Guard.IsNotNull(@this);

		ComWrappers.RegisterForTrackerSupport(@this);
		return (TWrappers)@this;
	}

	/// <summary>
	/// Enables COM marshalling support on the provided ComWrappers instance.
	/// </summary>
	/// <typeparam name="TWrappers">The specific ComWrappers subtype.</typeparam>
	/// <param name="@this">The ComWrappers instance to enable marshalling on.</param>
	/// <returns>The same <typeparamref name="TWrappers"/> instance.</returns>
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

		/// <summary>
			/// Creates a COM object for the specified CLSID and returns a pointer to the requested interface.
			/// </summary>
			/// <param name="rclsid">The CLSID of the COM class to instantiate.</param>
			/// <param name="pUnkOuter">Pointer to the controlling IUnknown for aggregation, or <c>nint.Zero</c> if not aggregating.</param>
			/// <param name="dwClsContext">The execution context in which the code that manages the newly created object will run.</param>
			/// <param name="riid">The IID of the interface being requested from the new object.</param>
			/// <param name="ppv">When successful, receives a pointer to the requested interface.</param>
			/// <returns>HRESULT result code: S_OK (0) on success; a negative value indicates failure.</returns>
			[LibraryImport(ApiLib)]
		public static partial int CoCreateInstance(
			ref Guid rclsid,
			nint pUnkOuter,
			ClsCtx dwClsContext,
			ref Guid riid,
			out nint ppv);

		/// <summary>
		/// Registers a class object for the specified CLSID with the COM runtime.
		/// </summary>
		/// <param name="rclsid">The CLSID of the class to register.</param>
		/// <param name="pUnk">A pointer to the class object's `IUnknown` (or `nint.Zero` for none).</param>
		/// <param name="dwClsContext">The execution context in which the code that manages the newly created object will run.</param>
		/// <param name="flags">Registration options that control lifetime and behavior of the class object.</param>
		/// <param name="lpdwRegister">Receives the registration cookie that can be used to revoke the registration.</param>
		/// <returns>The HRESULT result code; negative values indicate failure.</returns>
		[LibraryImport(ApiLib)]
		public static partial int CoRegisterClassObject(
			ref Guid rclsid,
			nint pUnk,
			ClsCtx dwClsContext,
			RegCls flags,
			out uint lpdwRegister
		);

		/// <summary>
		/// Revokes a previously registered class object identified by the registration cookie.
		/// </summary>
		/// <param name="dwRegister">The registration cookie returned by CoRegisterClassObject.</param>
		/// <returns>HRESULT result: `0` on success, a failure HRESULT otherwise.</returns>
		[LibraryImport(ApiLib)]
		public static partial int CoRevokeClassObject(
			uint dwRegister
		);

		/// <summary>
			/// Obtains a class object (for example, a class factory) for the specified CLSID and returns a pointer to the requested interface.
			/// </summary>
			/// <param name="rclsid">The CLSID of the class for which the class object is requested.</param>
			/// <param name="dwClsContext">Context in which the code that manages the newly created object will run (CLSCTX flags).</param>
			/// <param name="pvReserved">Reserved; must be zero.</param>
			/// <param name="riid">The IID of the interface being requested on the class object.</param>
			/// <param name="ppv">Receives a pointer to the requested interface on success.</param>
			/// <returns>An HRESULT value: `S_OK` on success; otherwise an error code. On success `ppv` receives the requested interface pointer.</returns>
			[LibraryImport(ApiLib)]
		public static partial int CoGetClassObject(
			ref Guid rclsid,
			ClsCtx dwClsContext,
			nint pvReserved,
			ref Guid riid,
			out nint ppv);

		/// <summary>
		/// Retrieves a pointer to the Running Object Table (ROT) for the current process.
		/// </summary>
		/// <param name="reserved">Reserved; must be zero.</param>
		/// <param name="pprot">When the method returns successfully, receives a pointer to the ROT (an IRunningObjectTable COM interface).</param>
		/// <returns>An HRESULT value: `S_OK` (0) on success or an error HRESULT on failure.</returns>
		[LibraryImport(ApiLib)]
		public static partial int GetRunningObjectTable(int reserved, out nint pprot);

		[LibraryImport(ApiLib)]
		public static partial int CreateBindCtx(int reserved, out nint ppbc);
	}

	#endregion Nested Types
}