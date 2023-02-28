using CSJNI.Low;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High;
public unsafe class JVM
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