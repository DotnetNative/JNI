using JNI.Enums;
using System.Runtime.InteropServices;

namespace JNI.Low;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct JNIInvokeInterface
{
    public JNIInvokeInterface() { }

    private void* reserved0 = null, reserved1 = null, reserved2 = null;

    public delegate* unmanaged<JVM_*, RetCode> DestroyJavaVM = null;
    public delegate* unmanaged<JVM_*, void**, void*, RetCode> AttachCurrentThread = null;
    public delegate* unmanaged<JVM_*, RetCode> DetachCurrentThread = null;
    public delegate* unmanaged<JVM_*, void**, int, RetCode> GetEnv = null;
    public delegate* unmanaged<JVM_*, void**, void*, RetCode> AttachCurrentThreadAsDaemon = null;
}