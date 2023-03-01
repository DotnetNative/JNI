global using static Sample.EntryPoint;
using System;
using System.Collections.Generic;
using System.Linq;
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
        Log("Env ver: " + env.Version);

        JBClassObj bibClass = env.BaseTypes.Class.ForName("bib");
        Log(bibClass.IsNull);
    }

    public void Unload()
    {

    }
}