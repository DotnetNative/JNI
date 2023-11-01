using JNI.Core.Enums;
using System.Runtime.InteropServices;

namespace JNI.Core;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct JNIInvokeInterface
{
    public JNIInvokeInterface() { }

    public void* reserved0, reserved1, reserved2;

    public delegate* unmanaged<JVM_*, RetCode> DestroyJavaVM;
    public delegate* unmanaged<JVM_*, void**, void*, RetCode> AttachCurrentThread;
    public delegate* unmanaged<JVM_*, RetCode> DetachCurrentThread;
    public delegate* unmanaged<JVM_*, void**, JVersion, RetCode> GetEnv;
    public delegate* unmanaged<JVM_*, void**, void*, RetCode> AttachCurrentThreadAsDaemon;
}