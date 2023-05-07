using JNI.Internal;
using JNI.Models.Global;
using JNI.Utils;

namespace JNI.Models.Local;
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

    public bool CallBoolean() => Env.Master->CallStaticBooleanMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public bool CallBoolean(Params args) => Env.Master->CallStaticBooleanMethodA((IntPtr)Clazz, Addr, args.Ptr);

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


    public JGObject Call(Env env) => new JGObject(env, env.Master->CallStaticObjectMethodA((IntPtr)Clazz, Addr, new Params().Ptr));
    public JGObject Call(Env env, Params args) => new JGObject(env, env.Master->CallStaticObjectMethodA((IntPtr)Clazz, Addr, args.Ptr));

    public void CallVoid(Env env) => env.Master->CallStaticVoidMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public void CallVoid(Env env, Params args) => env.Master->CallStaticVoidMethodA((IntPtr)Clazz, Addr, args.Ptr);

    public bool CallBoolean(Env env) => env.Master->CallStaticBooleanMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public bool CallBoolean(Env env, Params args) => env.Master->CallStaticBooleanMethodA((IntPtr)Clazz, Addr, args.Ptr);

    public byte CallByte(Env env) => env.Master->CallStaticByteMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public byte CallByte(Env env, Params args) => env.Master->CallStaticByteMethodA((IntPtr)Clazz, Addr, args.Ptr);

    public short CallShort(Env env) => env.Master->CallStaticShortMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public short CallShort(Env env, Params args) => env.Master->CallStaticShortMethodA((IntPtr)Clazz, Addr, args.Ptr);

    public int CallInt(Env env) => env.Master->CallStaticIntMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public int CallInt(Env env, Params args) => env.Master->CallStaticIntMethodA((IntPtr)Clazz, Addr, args.Ptr);

    public long CallLong(Env env) => env.Master->CallStaticLongMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public long CallLong(Env env, Params args) => env.Master->CallStaticLongMethodA((IntPtr)Clazz, Addr, args.Ptr);

    public float CallFloat(Env env) => env.Master->CallStaticFloatMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public float CallFloat(Env env, Params args) => env.Master->CallStaticFloatMethodA((IntPtr)Clazz, Addr, args.Ptr);

    public double CallDouble(Env env) => env.Master->CallStaticDoubleMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public double CallDouble(Env env, Params args) => env.Master->CallStaticDoubleMethodA((IntPtr)Clazz, Addr, args.Ptr);
}