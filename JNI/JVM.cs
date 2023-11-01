using JNI.Core;
namespace JNI;
public sealed unsafe class JVM
{
    public JVM(JVM_* jvm) => Native = jvm;

    public JVM_* Native { get; init; }

    public Env AttachCurrentThread(void* args = null)
    {
        Env_* env;
        Native->AttachCurrentThread((void**)&env, args);
        return new(env);
    }

    public Env AttachCurrentThreadAsDaemon(void* args = null)
    {
        Env_* env;
        Native->AttachCurrentThreadAsDaemon((void**)&env, args);
        return new(env);
    }

    public void DetachCurrentThread() => Native->DetachCurrentThread();

    public void DestroyJVM() => Native->DestroyJavaVM();
}