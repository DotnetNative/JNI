using JNI.Internal;
using JNI.Utils;
using Memory;

namespace JNI.Models.Local;
public unsafe sealed class JStaticMethod : MethodData
{
    public JStaticMethod(Env env, nint handle, string name, TypeInfo type, ClassHandle clazz, params Arg[] args) : base(env, handle, name, type, args)
        => Clazz = clazz;

    public JStaticMethod(Env env, string name, TypeInfo type, ClassHandle clazz, params Arg[] args) : base(env, nint.Zero, name, type, args)
    {
        Clazz = clazz;
        using var nameCo = new CoMem(name);
        using var sigCo = new CoMem(SigGen.Method(type, args));
        Addr = env.Native->GetStaticMethodID((nint)clazz, nameCo.Ptr, sigCo.Ptr);
    }

    public ClassHandle Clazz;

    public JObject Call() => Call(new());
    public JObject Call(Params args)
    {
        fixed (JValue* ptr = args.Values)
            return new(Env, Env.Native->CallStaticObjectMethodA((nint)Clazz, Addr, ptr));
    }

    public void CallVoid() => CallVoid(new());
    public void CallVoid(Params args)
    {
        fixed (JValue* ptr = args.Values)
            Env.Native->CallStaticVoidMethodA((nint)Clazz, Addr, ptr);
    }

    public bool CallBool() => CallBool(new());
    public bool CallBool(Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallStaticBooleanMethodA((nint)Clazz, Addr, ptr);
    }

    public byte CallByte() => CallByte(new());
    public byte CallByte(Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallStaticByteMethodA((nint)Clazz, Addr, ptr);
    }

    public short CallShort() => CallShort(new());
    public short CallShort(Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallStaticShortMethodA((nint)Clazz, Addr, ptr);
    }

    public int CallInt() => CallInt(new());
    public int CallInt(Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallStaticIntMethodA((nint)Clazz, Addr, ptr);
    }

    public long CallLong() => CallLong(new());
    public long CallLong(Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallStaticLongMethodA((nint)Clazz, Addr, ptr);
    }

    public float CallFloat() => CallFloat(new());
    public float CallFloat(Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallStaticFloatMethodA((nint)Clazz, Addr, ptr);
    }

    public double CallDouble() => CallDouble(new());
    public double CallDouble(Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallStaticDoubleMethodA((nint)Clazz, Addr, ptr);
    }
}