using System.Runtime.InteropServices;

namespace CSJNI.Low;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct JVM_
{
    private JNIInvokeInterface* functions;

    public int AttachCurrentThread(void** penv, void* args)
    {
        fixed (JVM_* jvm = &this)
            return functions->AttachCurrentThread(jvm, penv, args);
    }

    public int GetEnv(void** penv, int version)
    {
        fixed (JVM_* jvm = &this)
            return functions->GetEnv(jvm, penv, version);
    }

    public int DestroyJavaVM()
    {
        fixed (JVM_* jvm = &this)
            return functions->DestroyJavaVM(jvm);
    }

    public int DetachCurrentThread()
    {
        fixed (JVM_* jvm = &this)
            return functions->DetachCurrentThread(jvm);
    }

    public int AttachCurrentThreadAsDaemon(void** penv, void* args)
    {
        fixed (JVM_* jvm = &this)
            return functions->AttachCurrentThreadAsDaemon(jvm, penv, args);
    }
}