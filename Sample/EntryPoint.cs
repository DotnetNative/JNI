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

        //IntPtr clazz = new IntPtr(0x2A95DFEAC8);
        //IntPtr mcF = new IntPtr(0x2A95DFEAE8);
        delegate* unmanaged<Env_*, IntPtr, IntPtr, IntPtr> GetStaticObjectField = (delegate* unmanaged<Env_*, IntPtr, IntPtr, IntPtr>)new IntPtr(0x6E39A170).ToPointer();
        IntPtr clazz = new IntPtr(0x494F3FE758); //mst->FindClass("bib".AnsiPtrTest());
        IntPtr mcF = new IntPtr(0x494F3FE778); //mst->GetStaticFieldID(clazz, "R".AnsiPtrTest(), "Lbib;".AnsiPtrTest());
        IntPtr mc = GetStaticObjectField(mst, clazz, mcF);
        Interop.MessageBox(0, mc + "\n" + new IntPtr(GetStaticObjectField).ToString("X") + '\n' + new IntPtr(&mst->functions->GetStaticObjectField).ToString("X"), "CA", 0);
        
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