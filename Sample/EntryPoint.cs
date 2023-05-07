using JNI;
using JNI.Enums;
using JNI.Low;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Sample;
public sealed unsafe class EntryPoint
{
    private static string logPath = @"C:\log.txt";
    public static void Log(object obj)
    {
        File.AppendAllText(logPath, $"{obj}\n");
    }

    private static JCI jni;
    private static JVM jvm;
    private static Env env;
    private static Env_* mst;
    private static RuntimeTypeCollection types;

    [UnmanagedCallersOnly(EntryPoint = "Load", CallConvs = new Type[] { typeof(CallConvCdecl) })]
    public static void Load()
    {
        File.WriteAllText(logPath, "");
        Log($"Injected at {DateTime.Now}");
                
        jni = new JCI(JVersion.V18);
        jvm = jni.GetJVM();
        env = jvm.AttachCurrentThread();
        mst = env.Master;
        types = env.Types;
    }

    [UnmanagedCallersOnly(EntryPoint = "Unload", CallConvs = new Type[] { typeof(CallConvCdecl) })]
    public static void Unload()
    {
        Log($"Uninjected at {DateTime.Now}");
    }
}