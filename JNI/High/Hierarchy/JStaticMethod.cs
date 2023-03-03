using CSJNI.High.BaseTypes;
using CSJNI.Low;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public unsafe class JStaticMethod : MethodData
{
    public JStaticMethod(Env env, IntPtr handle, string name, JType type, ClassHandle clazz, params Arg[] args) : base(env, handle, name, type, args)
    {
        this.clazz = clazz;
    }

    public JStaticMethod(Env env, string name, JType type, ClassHandle clazz, params Arg[] args) : base(env, IntPtr.Zero, name, type, args)
    {
        this.clazz = clazz;
        string argsStr = SigGen.Method(this);
        Addr = env.Master->GetStaticMethodID((IntPtr)clazz, name.AnsiPtr(), argsStr.AnsiPtr());
    }

    private ClassHandle clazz;

    public JObject Call(JBStringS arg)
    {
        JObject str = new JObject(Env.Master->NewStringUTF("String 1".AnsiPtr()));
        JObject str2 = new JObject(Env.Master->NewStringUTF("String 2".AnsiPtr()));
        JValue[] values = new JValue[2];
        values[0] = new JValue(str);
        values[1] = new JValue(str2);
        fixed (JValue* arr = values)
        {
            ClassHandle c = Env.GetClass("chf");
            MethodHandle m = new MethodHandle(Env, Env.Master->GetMethodID((IntPtr)c, "<init>".AnsiPtr(), "(Ljava/lang/String;Ljava/lang/String;)V".AnsiPtr()));
            JObject o = new JObject(Env.Master->NewObjectA((IntPtr)c, (IntPtr)m, arr));
            FieldHandle f = new FieldHandle(Env, Env.Master->GetFieldID((IntPtr)c, "a".AnsiPtr(), "Ljava/lang/String;".AnsiPtr()));
            JObject or = new JObject(Env.Master->GetObjectField((IntPtr)o, (IntPtr)f));
            int count = Env.Master->GetStringLength((IntPtr)or);

            Interop.MessageBox(0, o.Addr.ToString() + "\n" + count, "!!!", 0);

            //IntPtr retAddr = Env.Master->CallStaticObjectMethodA(clazz.Addr, Addr, arr);
            //Interop.MessageBox(0, retAddr.ToString(), "CC35", 0);
            //return new JObject(retAddr);
        }

        return null;


        /*
        JObject str = new JObject(Env.Master->NewStringUTF("aa".AnsiPtr()));
        JValue[] values = new JValue[1];
        values[0] = new JValue(str);
        fixed (JValue* arr = values)
        {
            IntPtr retAddr = Env.Master->CallStaticObjectMethodA(clazz.Addr, Addr, arr);
            Interop.MessageBox(0, retAddr.ToString(), "CC35", 0);
            return new JObject(retAddr);
        }
        */

        /*
        fixed (byte* bytes = rawBytes)
        {
            JValue[] values = new JValue[1];
            //IntPtr addr_1 = new IntPtr(&arg);
            //IntPtr addr_2 = Marshal.AllocHGlobal(Marshal.SizeOf(arg));
            //Marshal.StructureToPtr(arg, addr_2, false);
            //Interop.MessageBox(0, addr_1.ToString() + "  -  " + addr_2.ToString(), "CC", 0);

            //values[0] = new JValue(new IntPtr(&arg));
            
        }
        */
    }
}