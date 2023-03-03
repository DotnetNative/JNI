using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI;
public unsafe static class SugarExtensions
{
    public static char* Ptr(this string str)
    {
        fixed (char* cptr = str)
            return cptr;
    }
    
    public static byte* AnsiPtr(this string str)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(str);
        fixed (byte* cbytes = bytes)
            return cbytes;
    }

    public static T* Ptr<T>(this T obj) where T : unmanaged
    {
        TypedReference reference = __makeref(obj);
        IntPtr addr = (IntPtr)(&reference);
        return (T*)addr.ToPointer();
    }

    public static T* Ptr<T>(this T[] obj) where T : unmanaged
    {
        TypedReference reference = __makeref(obj);
        IntPtr addr = (IntPtr)(&reference);
        return (T*)addr.ToPointer();
    }

    public static IntPtr Addr<T>(this T obj) where T : unmanaged
    {
        TypedReference reference = __makeref(obj);
        return (IntPtr)(&reference);
    }

    public static T ToStruct<T>(this IntPtr addr) where T : struct => Marshal.PtrToStructure<T>(addr);
}