using JNI.Enums;
using System.Runtime.InteropServices;

namespace JNI.Low;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct JVM_
{
    private JNIInvokeInterface* functions;

    public RetCode AttachCurrentThread(void** penv, void* args)
    {
        fixed (JVM_* jvm = &this)
            return functions->AttachCurrentThread(jvm, penv, args);
    }

    public RetCode GetEnv(void** penv, JVersion version)
    {
        fixed (JVM_* jvm = &this)
            return functions->GetEnv(jvm, penv, version);
    }

    public RetCode DestroyJavaVM()
    {
        fixed (JVM_* jvm = &this)
            return functions->DestroyJavaVM(jvm);
    }

    public RetCode DetachCurrentThread()
    {
        fixed (JVM_* jvm = &this)
            return functions->DetachCurrentThread(jvm);
    }

    public RetCode AttachCurrentThreadAsDaemon(void** penv, void* args)
    {
        fixed (JVM_* jvm = &this)
            return functions->AttachCurrentThreadAsDaemon(jvm, penv, args);
    }
}