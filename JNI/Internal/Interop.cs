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

    [DllImport(kernel, CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern
        nint GetModuleHandle(string lpModuleName);

    [DllImport(kernel, ExactSpelling = true, SetLastError = true)]
    public static extern
        int GetModuleHandleW(string filename);

    [DllImport(kernel, CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
    public static extern
        nint GetProcAddress(nint hModule, string procName);


    [DllImport(user, SetLastError = true, CharSet = CharSet.Auto)]
    public static extern
        int MessageBox(nint hWnd, string text, string caption, uint type);


    [DllImport(jvm, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    public static extern
        int JNI_GetCreatedJavaVMs(JVM_** jvms, int size, int* sizePtr);
    #endregion

    #region Method
    public static int MessageBox(object obj) => MessageBox(0, obj.ToString(), "", 0);
    #endregion
}