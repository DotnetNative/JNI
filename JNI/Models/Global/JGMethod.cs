using JNI.Internal;
using JNI.Models.Local;
using JNI.Utils;
using Memory;

namespace JNI.Models.Global;
public unsafe class JGMethod : GMethodData
{
    public JGMethod(nint gAddr, nint lAddr, string name, TypeInfo type, ClassHandle clazz, params Arg[] args) : base(gAddr, lAddr, name, type, args)
        => Clazz = clazz;

    public JGMethod(nint gAddr, nint lAddr, string name, string sig, ClassHandle clazz) : base(gAddr, lAddr, name, sig)
        => Clazz = clazz;

    public JGMethod(Env env, string name, TypeInfo type, ClassHandle clazz, params Arg[] args) : base(nint.Zero, nint.Zero, name, type, args)
    {
        Clazz = clazz;
        using var nameCo = new CoMem(name);
        using var sigCo = new CoMem(SigGen.Method(type, args));
        LocalAddr = env.Native->GetMethodID(!clazz, (byte*)nameCo, (byte*)sigCo);
        Addr = env.Native->NewGlobalRef(LocalAddr);
    }

    public ClassHandle Clazz;

    public JGObject Call(Env env, JGObject obj) => Call(env, obj, new());
    public JGObject Call(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
        {
            var res = env.Native->CallNonvirtualObjectMethodA(!obj, !Clazz, Addr, ptr);
            return new(env.Native->NewGlobalRef(res), res);
        }
    }
    public JGObject CallVirt(Env env, JGObject obj) => CallVirt(env, obj, new());
    public JGObject CallVirt(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
        {
            var res = env.Native->CallObjectMethodA(!obj, Addr, ptr);
            return new(env.Native->NewGlobalRef(res), res);
        }
    }
    public void CallVoid(Env env, JGObject obj) => CallVoid(env, obj, new());
    public void CallVoid(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            env.Native->CallNonvirtualVoidMethodA(!obj, !Clazz, Addr, ptr);
    }
    public void CallVirtVoid(Env env, JGObject obj) => CallVirtVoid(env, obj, new());
    public void CallVirtVoid(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            env.Native->CallVoidMethodA(!obj, Addr, ptr);
    }

    public bool CallBool(Env env, JGObject obj) => CallBool(env, obj, new());
    public bool CallBool(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallNonvirtualBooleanMethodA(!obj, !Clazz, Addr, ptr);
    }
    public bool CallVirtBool(Env env, JGObject obj) => CallVirtBool(env, obj, new());
    public bool CallVirtBool(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallBooleanMethodA(!obj, Addr, ptr);
    }

    public byte CallByte(Env env, JGObject obj) => CallByte(env, obj, new());
    public byte CallByte(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallNonvirtualByteMethodA(!obj, !Clazz, Addr, ptr);
    }
    public byte CallVirtByte(Env env, JGObject obj) => CallVirtByte(env, obj, new());
    public byte CallVirtByte(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallByteMethodA(!obj, Addr, ptr);
    }

    public short CallShort(Env env, JGObject obj) => CallShort(env, obj, new());
    public short CallShort(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallNonvirtualShortMethodA(!obj, !Clazz, Addr, ptr);
    }
    public short CallVirtShort(Env env, JGObject obj) => CallVirtShort(env, obj, new());
    public short CallVirtShort(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallShortMethodA(!obj, Addr, ptr);
    }

    public int CallInt(Env env, JGObject obj) => CallInt(env, obj, new());
    public int CallInt(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallNonvirtualIntMethodA(!obj, !Clazz, Addr, ptr);
    }
    public int CallVirtInt(Env env, JGObject obj) => CallVirtInt(env, obj, new());
    public int CallVirtInt(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallIntMethodA(!obj, Addr, ptr);
    }

    public long CallLong(Env env, JGObject obj) => CallLong(env, obj, new());
    public long CallLong(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallNonvirtualLongMethodA(!obj, !Clazz, Addr, ptr);
    }
    public long CallVirtLong(Env env, JGObject obj) => CallVirtLong(env, obj, new());
    public long CallVirtLong(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallLongMethodA(!obj, Addr, ptr);
    }

    public float CallFloat(Env env, JGObject obj) => CallFloat(env, obj, new());
    public float CallFloat(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallNonvirtualFloatMethodA(!obj, !Clazz, Addr, ptr);
    }
    public float CallVirtFloat(Env env, JGObject obj) => CallVirtFloat(env, obj, new());
    public float CallVirtFloat(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallFloatMethodA(!obj, Addr, ptr);
    }

    public double CallDouble(Env env, JGObject obj) => CallDouble(env, obj, new());
    public double CallDouble(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallNonvirtualDoubleMethodA(!obj, !Clazz, Addr, ptr);
    }
    public double CallVirtDouble(Env env, JGObject obj) => CallVirtDouble(env, obj, new());
    public double CallVirtDouble(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallDoubleMethodA(!obj, Addr, ptr);
    }

    public JGObject Call(Env env, JObject obj) => Call(env, obj, new());
    public JGObject Call(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
        {
            var res = env.Native->CallNonvirtualObjectMethodA(!obj, !Clazz, Addr, ptr);
            return new(env.Native->NewGlobalRef(res), res);
        }
    }
    public JGObject CallVirt(Env env, JObject obj) => CallVirt(env, obj, new());
    public JGObject CallVirt(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
        {
            var res = env.Native->CallObjectMethodA(!obj, Addr, ptr);
            return new(env.Native->NewGlobalRef(res), res);
        }
    }
    public void CallVoid(Env env, JObject obj) => CallVoid(env, obj, new());
    public void CallVoid(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            env.Native->CallNonvirtualVoidMethodA(!obj, !Clazz, Addr, ptr);
    }
    public void CallVirtVoid(Env env, JObject obj) => CallVirtVoid(env, obj, new());
    public void CallVirtVoid(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            env.Native->CallVoidMethodA(!obj, Addr, ptr);
    }

    public bool CallBool(Env env, JObject obj) => CallBool(env, obj, new());
    public bool CallBool(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallNonvirtualBooleanMethodA(!obj, !Clazz, Addr, ptr);
    }
    public bool CallVirtBool(Env env, JObject obj) => CallVirtBool(env, obj, new());
    public bool CallVirtBool(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallBooleanMethodA(!obj, Addr, ptr);
    }

    public byte CallByte(Env env, JObject obj) => CallByte(env, obj, new());
    public byte CallByte(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallNonvirtualByteMethodA(!obj, !Clazz, Addr, ptr);
    }
    public byte CallVirtByte(Env env, JObject obj) => CallVirtByte(env, obj, new());
    public byte CallVirtByte(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallByteMethodA(!obj, Addr, ptr);
    }

    public short CallShort(Env env, JObject obj) => CallShort(env, obj, new());
    public short CallShort(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallNonvirtualShortMethodA(!obj, !Clazz, Addr, ptr);
    }
    public short CallVirtShort(Env env, JObject obj) => CallVirtShort(env, obj, new());
    public short CallVirtShort(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallShortMethodA(!obj, Addr, ptr);
    }

    public int CallInt(Env env, JObject obj) => CallInt(env, obj, new());
    public int CallInt(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallNonvirtualIntMethodA(!obj, !Clazz, Addr, ptr);
    }
    public int CallVirtInt(Env env, JObject obj) => CallVirtInt(env, obj, new());
    public int CallVirtInt(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallIntMethodA(!obj, Addr, ptr);
    }

    public long CallLong(Env env, JObject obj) => CallLong(env, obj, new());
    public long CallLong(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallNonvirtualLongMethodA(!obj, !Clazz, Addr, ptr);
    }
    public long CallVirtLong(Env env, JObject obj) => CallVirtLong(env, obj, new());
    public long CallVirtLong(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallLongMethodA(!obj, Addr, ptr);
    }

    public float CallFloat(Env env, JObject obj) => CallFloat(env, obj, new());
    public float CallFloat(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallNonvirtualFloatMethodA(!obj, !Clazz, Addr, ptr);
    }
    public float CallVirtFloat(Env env, JObject obj) => CallVirtFloat(env, obj, new());
    public float CallVirtFloat(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallFloatMethodA(!obj, Addr, ptr);
    }

    public double CallDouble(Env env, JObject obj) => CallDouble(env, obj, new());
    public double CallDouble(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallNonvirtualDoubleMethodA(!obj, !Clazz, Addr, ptr);
    }
    public double CallVirtDouble(Env env, JObject obj) => CallVirtDouble(env, obj, new());
    public double CallVirtDouble(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return env.Native->CallDoubleMethodA(!obj, Addr, ptr);
    }

    public JObject CallLocal(Env env, JGObject obj) => CallLocal(env, obj, new());
    public JObject CallLocal(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return new JObject(env, env.Native->CallNonvirtualObjectMethodA(!obj, !Clazz, Addr, ptr));
    }
    public JObject CallVirtLocal(Env env, JGObject obj) => CallVirtLocal(env, obj, new());
    public JObject CallVirtLocal(Env env, JGObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return new JObject(env, env.Native->CallObjectMethodA(!obj, Addr, ptr));
    }

    public JObject CallLocal(Env env, JObject obj) => CallLocal(env, obj, new());
    public JObject CallLocal(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return new JObject(env, env.Native->CallNonvirtualObjectMethodA(!obj, !Clazz, Addr, ptr));
    }
    public JObject CallVirtLocal(Env env, JObject obj) => CallVirtLocal(env, obj, new());
    public JObject CallVirtLocal(Env env, JObject obj, Params args)
    {
        fixed (JValue* ptr = args.Values)
            return new(env, env.Native->CallObjectMethodA(!obj, Addr, ptr));
    }
}