using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSJNI;
internal unsafe static class SugarExtensions
{
    public static char* Ptr(this string str)
    {
        fixed (char* cptr = str)
            return cptr;
    }

    public static byte* UtfPtr(this string str) => (byte*)Marshal.StringToCoTaskMemUTF8(str).ToPointer();
    public static byte* UniPtr(this string str) => (byte*)Marshal.StringToCoTaskMemUni(str).ToPointer();
    public static byte* AnsiPtr(this string str) => (byte*)Marshal.StringToCoTaskMemAnsi(str).ToPointer();

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

    public static Arg[] ToArgs(this JType[] arr) => arr.Select(t => new Arg(t)).ToArray();
}