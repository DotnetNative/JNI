global using static Sample.EntryPoint;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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

    public void Load()
    {
        File.WriteAllText(logPath, "");
        Log($"Injected at {DateTime.Now}");
                
        JNI jni = new JNI(JNIVersion.V18);
        JVM jvm = jni.GetJVM();
        Env env = jvm.AttachCurrentThread();
        Env_* mst = env.Master;
        BaseTypeCollection types = env.BaseTypes;

        using JString arg1 = new JString(env, "This is arg #1");
        using JString arg2 = new JString(env, "This is arg #2");

        ClassHandle chfClass = env.GetClass("chf");
        JObject chfObj = chfClass.GetCtor(types.String, types.String).NewInstance(new Params(arg1, arg2));

        Log(env.CreateString(chfClass.GetMethod("a", types.String).CallObj(chfObj)));
        Log(env.CreateString(chfClass.GetMethod("b", types.String).CallObj(chfObj)));
    }

    public void Unload()
    {
        Log($"Uninjected at {DateTime.Now}");
    }
}