using JNI.Internal;
using JNI.Models.Local;
using JNI.Utils;
using Memory;

namespace JNI.Models.Global;
public unsafe class JGStaticMethod : GMethodData
{
    public JGStaticMethod(nint gAddr, nint lAddr, string name, TypeInfo type, ClassHandle clazz, params Arg[] args) : base(gAddr, lAddr, name, type, args)
    {
        Clazz = clazz;
    }

    public JGStaticMethod(Env env, string name, TypeInfo type, ClassHandle clazz, params Arg[] args) : base(nint.Zero, nint.Zero, name, type, args)
    {
        Clazz = clazz;
        using var nameCo = new CoMem(name);
        using var sigCo = new CoMem(SigGen.Method(type, args));
        LocalAddr = env.Native->GetStaticMethodID(!clazz, nameCo.Ptr, sigCo.Ptr);
        Addr = env.Native->NewGlobalRef(LocalAddr);
    }

    public ClassHandle Clazz;

    public JGObject Call(Env env) => Call(env, new());
    public JGObject Call(Env env, Params args)
    {
        fixed (JValue* ptr = args.Values)
        {
            nint addr = env.Native->CallStaticObjectMethodA(!Clazz, Addr, ptr);
            return new(env.NewGlobalRef(addr), addr);
        }
    }
    public void CallVoid(Env env) => CallVoid(env, new());
    public void CallVoid(Env env, Params args)
    {
        fixed (JValue* ptr = args.Values)
            env.Native->CallStaticVoidMethodA(!Clazz, Addr, ptr);
    }
    public bool CallBool(Env env) => CallBool(env, new());
    public bool CallBool(Env env, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallStaticBooleanMethodA(!Clazz, Addr, ptr);
    }
    public byte CallByte(Env env) => CallByte(env, new());
    public byte CallByte(Env env, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallStaticByteMethodA(!Clazz, Addr, ptr);
    }
    public short CallShort(Env env) => CallShort(env, new());
    public short CallShort(Env env, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallStaticShortMethodA(!Clazz, Addr, ptr);
    }
    public int CallInt(Env env) => CallInt(env, new());
    public int CallInt(Env env, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallStaticIntMethodA(!Clazz, Addr, ptr);
    }
    public long CallLong(Env env) => CallLong(env, new());
    public long CallLong(Env env, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallStaticLongMethodA(!Clazz, Addr, ptr);
    }
    public float CallFloat(Env env) => CallFloat(env, new());
    public float CallFloat(Env env, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallStaticFloatMethodA(!Clazz, Addr, ptr);
    }
    public double CallDouble(Env env) => CallDouble(env, new());
    public double CallDouble(Env env, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallStaticDoubleMethodA(!Clazz, Addr, ptr);
    }

    public JObject CallLocal(Env env) => CallLocal(env, new());
    public JObject CallLocal(Env env, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return new(env, env.Native->CallStaticObjectMethodA(!Clazz, Addr, ptr));
    }
}