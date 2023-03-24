global using static Sample.EntryPoint;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CSJNI;
using CSJNI.High;
using CSJNI.High.BaseTypes;
using CSJNI.High.Enums;
using CSJNI.High.Hierarchy;
using CSJNI.Low;

namespace Sample;
public unsafe class EntryPoint
{
    private static string logPath = @"C:\log.txt";
    public static void Log(object obj)
    {
        File.AppendAllText(logPath, $"{obj}\n");
    }

    private static JNI jni;
    private static JVM jvm;
    private static Env env;
    private static Env_* mst;
    private static RuntimeTypeCollection types;

    [UnmanagedCallersOnly(EntryPoint = "Load", CallConvs = new Type[] { typeof(CallConvCdecl) })]
    public static void Load()
    {
        File.WriteAllText(logPath, "");
        Log($"Injected at {DateTime.Now}");
                
        jni = new JNI(JNIVersion.V18);
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