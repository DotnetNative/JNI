using JNI.Internal;
using JNI.Utils;
using Memory;

namespace JNI.Models.Local;
public unsafe class JMethod : MethodData
{
    public JMethod(Env env, nint handle, string name, TypeInfo type, ClassHandle clazz, params Arg[] args) : base(env, handle, name, type, args)
        => Clazz = clazz;

    public JMethod(Env env, nint handle, string name, string sig, ClassHandle clazz) : base(env, handle, name, sig)
        => Clazz = clazz;

    public JMethod(Env env, string name, TypeInfo type, ClassHandle clazz, params Arg[] args) : base(env, nint.Zero, name, type, args)
    {
        Clazz = clazz;
        using var nameCo = new CoMem(name);
        using var argsCo = new CoMem(SigGen.Method(type, args));
        Addr = env.Native->GetMethodID(!clazz, (byte*)nameCo, (byte*)argsCo);
    }

    public ClassHandle Clazz;

    public JObject Call(JObject obj) => Call(obj, new());
    public JObject Call(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return new(Env, Env.Native->CallNonvirtualObjectMethodA(!obj, !Clazz, Addr, ptr));
    }
    public JObject CallVirt(JObject obj) => CallVirt(obj, new());
    public JObject CallVirt(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return new(Env, Env.Native->CallObjectMethodA(!obj, Addr, ptr));
    }

    public void CallVoid(JObject obj) => CallVoid(obj, new());
    public void CallVoid(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            Env.Native->CallNonvirtualVoidMethodA(!obj, !Clazz, Addr, ptr);
    }
    public void CallVirtVoid(JObject obj) => CallVirtVoid(obj, new());
    public void CallVirtVoid(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            Env.Native->CallVoidMethodA(!obj, Addr, ptr);
    }

    public bool CallBool(JObject obj) => CallBool(obj, new());
    public bool CallBool(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallNonvirtualBooleanMethodA(!obj, !Clazz, Addr, ptr);
    }
    public bool CallVirtBool(JObject obj) => CallVirtBool(obj, new());
    public bool CallVirtBool(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallBooleanMethodA(!obj, Addr, ptr);
    }

    public byte CallByte(JObject obj) => CallByte(obj, new());
    public byte CallByte(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallNonvirtualByteMethodA(!obj, !Clazz, Addr, ptr);
    }
    public byte CallVirtByte(JObject obj) => CallVirtByte(obj, new());
    public byte CallVirtByte(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallByteMethodA(!obj, Addr, ptr);
    }

    public short CallShort(JObject obj) => CallShort(obj, new());
    public short CallShort(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallNonvirtualShortMethodA(!obj, !Clazz, Addr, ptr);
    }
    public short CallVirtShort(JObject obj) => CallVirtShort(obj, new());
    public short CallVirtShort(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallShortMethodA(!obj, Addr, ptr);
    }

    public int CallInt(JObject obj) => CallInt(obj, new());
    public int CallInt(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallNonvirtualIntMethodA(!obj, !Clazz, Addr, ptr);
    }
    public int CallVirtInt(JObject obj) => CallVirtInt(obj, new());
    public int CallVirtInt(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallIntMethodA(!obj, Addr, ptr);
    }

    public long CallLong(JObject obj) => CallLong(obj, new());
    public long CallLong(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallNonvirtualLongMethodA(!obj, !Clazz, Addr, ptr);
    }
    public long CallVirtLong(JObject obj) => CallVirtLong(obj, new());
    public long CallVirtLong(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallLongMethodA(!obj, Addr, ptr);
    }

    public float CallFloat(JObject obj) => CallFloat(obj, new());
    public float CallFloat(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallNonvirtualFloatMethodA(!obj, !Clazz, Addr, ptr);
    }
    public float CallVirtFloat(JObject obj) => CallVirtFloat(obj, new());
    public float CallVirtFloat(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallFloatMethodA(!obj, Addr, ptr);
    }

    public double CallDouble(JObject obj) => CallDouble(obj, new());
    public double CallDouble(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallNonvirtualDoubleMethodA(!obj, !Clazz, Addr, ptr);
    }
    public double CallVirtDouble(JObject obj) => CallVirtDouble(obj, new());
    public double CallVirtDouble(JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return Env.Native->CallDoubleMethodA(!obj, Addr, ptr);
    }
}