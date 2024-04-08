using JNI.Core;
namespace JNI;
public sealed unsafe class JVM
{
    public JVM(JVM_* jvm) => Native = jvm;

    public readonly JVM_* Native;

    public Env_* NativeAttachCurrentThread(void* args = null)
    {
        Env_* env;
        Native->AttachCurrentThread((void**)&env, args);
        return env;
    }

    public Env AttachCurrentThread(void* args = null) => new(NativeAttachCurrentThread(args));

    public Env_* NativeAttachCurrentThreadAsDaemon(void* args = null)
    {
        Env_* env;
        Native->AttachCurrentThreadAsDaemon((void**)&env, args);
        return env;
    }

    public Env AttachCurrentThreadAsDaemon(void* args = null) => new(NativeAttachCurrentThreadAsDaemon(args));

    public void DetachCurrentThread() => Native->DetachCurrentThread();

    public void DestroyJVM() => Native->DestroyJavaVM();
}