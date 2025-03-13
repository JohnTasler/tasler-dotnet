using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Tasler.Multimedia.DirectShow
{
  [ComImport]
  [Guid("29840822-5B84-11D0-BD3B-00A0C911CE86")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  public interface ICreateDevEnum
  {
    int CreateClassEnumerator(
      ref Guid clsidDeviceClass,
      out IEnumMoniker ppEnumMoniker,
      CreateDevEnumFlags dwFlags);
  }

  public enum CreateDevEnumFlags
  {
    ClassDefault        = 0x0001,
    BypassClassManager  = 0x0002,
    MeritAboveDoNotUse  = 0x0008,
    Devmon_Cmgr_Device  = 0x0010,
    DevmonDmo           = 0x0020,
    DevmonPnpDevice     = 0x0040,
    DevmonFilter        = 0x0080,
    DevmonSelectiveMask = 0x00f0,
  }

}
