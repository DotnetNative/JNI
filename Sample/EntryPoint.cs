global using static Sample.EntryPoint;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
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

    JNI jni;
    JVM jvm;
    Env env;
    Env_* mst;
    RuntimeTypeCollection types;
    public void Load()
    {
        File.WriteAllText(logPath, "");
        Log($"Injected at {DateTime.Now}");
                
        jni = new JNI(JNIVersion.V18);
        jvm = jni.GetJVM();
        env = jvm.AttachCurrentThread();
        mst = env.Master;
        types = env.Types;

        GC.Collect();
        IntPtr clazz = mst->FindClass("bib".AnsiPtr());

        IntPtr mcF = mst->GetStaticFieldID(clazz, "R".AnsiPtr(), "Lbib;".AnsiPtr());
        IntPtr mc = mst->GetStaticObjectField(clazz, mcF);

        IntPtr mc2F = mst->GetStaticFieldID(clazz, "K".AnsiPtr(), "Lnf;".AnsiPtr());
        IntPtr mc2 = mst->GetObjectField(clazz, mc2F);


        IntPtr sF = mst->GetStaticFieldID(clazz, "J".AnsiPtr(), "Lorg/apache/logging/log4j/Logger;".AnsiPtr());
        IntPtr s = mst->GetStaticObjectField(clazz, sF);

        IntPtr s2F = mst->GetStaticFieldID(clazz, "ar".AnsiPtr(), "I".AnsiPtr());
        IntPtr s2 = mst->GetStaticObjectField(clazz, s2F);


        Interop.MessageBox(0, mcF + " " + mc + "\n" + mc2F + " " + mc2 + "\n" + sF + " " + s + "\n" + s2F + " " + s2, "CB", 0);


        /*
        IntPtr sF = mst->GetFieldID(clazz, "T".AnsiPtr(), "Z".AnsiPtr());
        IntPtr s = mst->GetObjectField(clazz, sF);
        Interop.MessageBox(0, s.ToString(), "CB", 0);
        */

        /*
        using JStaticField mcF = types.Add("bib").GetStaticField("R", types.Get("bib"));
        Log(0 + ":" + mcF);        
        using JObject mc = mcF.GetObjValue();
        Log(1 + ":" + mc);
        using JField timerF = types.Get("bib").GetField("Y", types.Add("bih"));
        Log(2 + ":" + timerF);
        using JObject timer = timerF.GetObjValue(mc);
        Log(3 + ":" + timer);
        using JField tickLengthF = types.Get("bih").GetField("e", types.Float);
        Log(4 + ":" + tickLengthF);

        tickLengthF.SetValue(mc, 10);
        */
    }

    //using JObject loader = types.ClassLoader.GetStaticMethod("getSystemClassLoader", types.ClassLoader).CallObj();
    //using JBClassObj clazz = types.Class.ForName("bib", true, new JBClassLoaderObj(env, loader));

    private void SetTitle(string str)
    {
        /*
        types["System"] = env.GetClass("java.lang.System");
        using JString jstr = new JString(env, str, false);
        using JStaticMethod getenv = types["System"].GetStaticMethod("getenv", types.String, types.String);
        using JString res = env.CreateString(getenv.CallObj(new Params(jstr)), false);
        Log(res);
        */

        /*
        types["Display"] = env.GetClass("org.lwjgl.opengl.Display");
        JObject jstr = types["Display"].GetStaticMethod("getTitle", types.String).CallObj();
        Log(env.CreateString(jstr));
        using JStaticMethod method = types["Display"].GetStaticMethod("setTitle", types.Void, types.String);
        method.CallVoid(new Params(jstr));
        */
    }

    public void Unload()
    {
        Log($"Uninjected at {DateTime.Now}");
    }
}