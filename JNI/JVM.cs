namespace JNI;
public static unsafe class JVM
{
    [DllImport("jvm", CallingConvention = CallingConvention.StdCall)] public static extern
        int JNI_GetCreatedJavaVMs(JVM_** jvms, int size, int* sizePtr);

    public static int JVM_INDEX = 0;

    public static JVM_* GetJVM()
    {
        int count;
        JNI_GetCreatedJavaVMs(null, 0, &count);
        JVM_*[] jvms = new JVM_*[count];
        fixed (JVM_** jvmPrr = jvms)
            JNI_GetCreatedJavaVMs(jvmPrr, count, &count);

        if (jvms.Length <= JVM_INDEX)
            throw new MessageBoxException($"JVM.JVM_INDEX is bigger than count of available java virtual machines. JVM_INDEX = {JVM_INDEX}. Count of available JVM is {jvms.Length}");

        return jvms[JVM_INDEX];
    }

    public static void AttachCurrentThread(void* args = null)
    {
        var jvm = GetJVM();
        Env_* e_;
        jvm->AttachCurrentThread((void**)&e_, args);
        var e = new Env(e_);
    }

    public static void AttachCurrentThreadAsDaemon(void* args = null)
    {
        var jvm = GetJVM();
        Env_* e_;
        jvm->AttachCurrentThreadAsDaemon((void**)&e_, args);
        var e = new Env(e_);
    }

    public static void DetachCurrentThread()
    {
        var jvm = GetJVM();
        jvm->DetachCurrentThread();
    }

    public static void DestroyJVM()
    {
        var jvm = GetJVM();
        jvm->DestroyJavaVM();
    }
}