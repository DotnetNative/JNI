using JNI.Low;

namespace JNI;
public sealed unsafe class JVM
{
    public JVM(JVM_* jvm)
    {
        Master = jvm;
    }

    public JVM_* Master { get; init; }

    public Env AttachCurrentThread(void* args = null)
    {
        Env_* env;
        Master->AttachCurrentThread((void**)&env, args);
        return new Env(env);
    }

    public Env AttachCurrentThreadAsDaemon(void* args = null)
    {
        Env_* env;
        Master->AttachCurrentThreadAsDaemon((void**)&env, args);
        return new Env(env);
    }

    public void DetachCurrentThread() => Master->DetachCurrentThread();

    public void DestroyJVM() => Master->DestroyJavaVM();
}