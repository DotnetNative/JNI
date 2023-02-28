using CSJNI.Low;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI;
public unsafe class Interop
{
    [DllImport("jvm")]
    public static extern
        void JVM_Close();

    [DllImport("jvm")]
    public static extern
        long JVM_NanoTime();

    [DllImport("jvm", CallingConvention = CallingConvention.StdCall)]
    public static extern
        int JNI_GetCreatedJavaVMs(JVM_** jvms, int size, int* sizePtr);

    #region Other
    [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern
        IntPtr GetModuleHandle([MarshalAs(UnmanagedType.LPWStr)] string lpModuleName);
    [DllImport("kernel32", ExactSpelling = true)]
    public static extern
        int GetModuleHandleW(string filename);
    [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
    public static extern
        IntPtr GetProcAddress(IntPtr hModule, string procName);


    [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern
        int MessageBox(IntPtr hWnd, string text, string caption, uint type);
    #endregion
}