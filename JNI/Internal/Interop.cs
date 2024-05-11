using JNI.Core;
using System.Runtime.InteropServices;

namespace JNI.Internal;
internal static unsafe class Interop
{
    #region DllImport
    const string
        jvm = "jvm",
        kernel = "kernel32",
        user = "user32";

    [DllImport(kernel)]
    public static extern
        void* TlsGetValue(int index);

    [DllImport(kernel, CharSet = CharSet.Unicode)]
    public static extern
        nint GetModuleHandle(string lpModuleName);

    [DllImport(kernel, ExactSpelling = true)]
    public static extern
        int GetModuleHandleW(string filename);

    [DllImport(kernel, CharSet = CharSet.Ansi, ExactSpelling = true)]
    public static extern
        nint GetProcAddress(nint hModule, string procName);


    [DllImport(user, CharSet = CharSet.Auto)]
    public static extern
        int MessageBox(nint hWnd, string text, string caption, uint type);


    [DllImport(jvm, CallingConvention = CallingConvention.StdCall)]
    public static extern
        int JNI_GetCreatedJavaVMs(JVM_** jvms, int size, int* sizePtr);
    #endregion
}