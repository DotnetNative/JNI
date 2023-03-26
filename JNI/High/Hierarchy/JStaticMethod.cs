using CSJNI.High.BaseTypes;
using CSJNI.Low;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public unsafe class JStaticMethod : MethodData
{
    public JStaticMethod(Env env, IntPtr handle, string name, JType type, ClassHandle clazz, params Arg[] args) : base(env, handle, name, type, args)
    {
        Clazz = clazz;
    }

    public JStaticMethod(Env env, string name, JType type, ClassHandle clazz, params Arg[] args) : base(env, IntPtr.Zero, name, type, args)
    {
        Clazz = clazz;
        string argsStr = SigGen.Method(this);
        Addr = env.Master->GetStaticMethodID((IntPtr)clazz, name.UtfPtr(), argsStr.UtfPtr());
    }

    public ClassHandle Clazz;

    public JObject Call() => new JObject(Env, Env.Master->CallStaticObjectMethodA((IntPtr)Clazz, Addr, new Params().Ptr));
    public JObject Call(Params args) => new JObject(Env, Env.Master->CallStaticObjectMethodA((IntPtr)Clazz, Addr, args.Ptr));
    public void CallVoid() => Env.Master->CallStaticVoidMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public void CallVoid(Params args) => Env.Master->CallStaticVoidMethodA((IntPtr)Clazz, Addr, args.Ptr);

    public void CallBoolean() => Env.Master->CallStaticBooleanMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public void CallBoolean(Params args) => Env.Master->CallStaticBooleanMethodA((IntPtr)Clazz, Addr, args.Ptr);

    public byte CallByte() => Env.Master->CallStaticByteMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public byte CallByte(Params args) => Env.Master->CallStaticByteMethodA((IntPtr)Clazz, Addr, args.Ptr);

    public short CallShort() => Env.Master->CallStaticShortMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public short CallShort(Params args) => Env.Master->CallStaticShortMethodA((IntPtr)Clazz, Addr, args.Ptr);

    public int CallInt() => Env.Master->CallStaticIntMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public int CallInt(Params args) => Env.Master->CallStaticIntMethodA((IntPtr)Clazz, Addr, args.Ptr);

    public long CallLong() => Env.Master->CallStaticLongMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public long CallLong(Params args) => Env.Master->CallStaticLongMethodA((IntPtr)Clazz, Addr, args.Ptr);

    public float CallFloat() => Env.Master->CallStaticFloatMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public float CallFloat(Params args) => Env.Master->CallStaticFloatMethodA((IntPtr)Clazz, Addr, args.Ptr);

    public double CallDouble() => Env.Master->CallStaticDoubleMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public double CallDouble(Params args) => Env.Master->CallStaticDoubleMethodA((IntPtr)Clazz, Addr, args.Ptr);
}