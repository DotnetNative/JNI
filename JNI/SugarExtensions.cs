using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

    public static byte* UnicodePtr(this string str)
    {
        byte[] bytes = Encoding.Unicode.GetBytes(str);
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
        fixed (T* ptr = obj)
            return ptr;
    }

    public static T[] ToArr<T>(this T[] arr, T* ptr)
    {
        for (int i = 0; i < arr.Length; i++)
            arr[i] = *(ptr + i);
        return arr;
    }

    public static IntPtr Addr<T>(this T obj) where T : unmanaged
    {
        TypedReference reference = __makeref(obj);
        return (IntPtr)(&reference);
    }

    public static T ToStruct<T>(this IntPtr addr) where T : struct => Marshal.PtrToStructure<T>(addr);
}