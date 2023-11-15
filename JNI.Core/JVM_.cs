using System.Runtime.InteropServices;

namespace JNI.Core;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct JVM_
{
    JNIInvokeInterface* functions;

    [MethImpl(AggressiveInlining)]
    public RetCode AttachCurrentThread(void** penv, void* args)
    {
        fixed (JVM_* jvm = &this)
            return functions->AttachCurrentThread(jvm, penv, args);
    }

    [MethImpl(AggressiveInlining)]
    public RetCode GetEnv(void** penv, JVersion version)
    {
        fixed (JVM_* jvm = &this)
            return functions->GetEnv(jvm, penv, version);
    }

    [MethImpl(AggressiveInlining)]
    public RetCode DestroyJavaVM()
    {
        fixed (JVM_* jvm = &this)
            return functions->DestroyJavaVM(jvm);
    }

    [MethImpl(AggressiveInlining)]
    public RetCode DetachCurrentThread()
    {
        fixed (JVM_* jvm = &this)
            return functions->DetachCurrentThread(jvm);
    }

    [MethImpl(AggressiveInlining)]
    public RetCode AttachCurrentThreadAsDaemon(void** penv, void* args)
    {
        fixed (JVM_* jvm = &this)
            return functions->AttachCurrentThreadAsDaemon(jvm, penv, args);
    }
}