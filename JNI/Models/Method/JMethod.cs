namespace JNI;
public abstract class JMethod(EnvHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : JMethodInstance(handle, name, type, clazz, args);

public unsafe class JVoidMethod : JMethod
{
    public JVoidMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Void, clazz, args) { }

    public void Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            Native->CallNonvirtualVoidMethodA(obj, Clazz, Address, ptr);
    }

    public void CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            Native->CallVoidMethodA(obj, Address, ptr);
    }
}

public unsafe class JStringMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, handle.Env.Types.String, clazz, args)
{
    public java.lang.String Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(LHandle.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Address, ptr)));
    }

    public java.lang.String CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(GHandle.Create(Native->CallObjectMethodA(obj, Address, ptr)));
    }

    public java.lang.String CallG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(GHandle.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Address, ptr)));
    }

    public java.lang.String CallVirtG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(LHandle.Create(Native->CallObjectMethodA(obj, Address, ptr)));
    }

    public java.lang.String CallUTF8(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(LHandle.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Address, ptr)), false);
    }

    public java.lang.String CallVirtUTF8(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(GHandle.Create(Native->CallObjectMethodA(obj, Address, ptr)), false);
    }

    public java.lang.String CallGUTF8(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(GHandle.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Address, ptr)), false);
    }

    public java.lang.String CallVirtGUTF8(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(LHandle.Create(Native->CallObjectMethodA(obj, Address, ptr)), false);
    }
}

public unsafe class JObjectMethod(LHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : JMethod(handle, name, type, clazz, args)
{
    public LJObject Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return LJObject.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Address, ptr));
    }

    public LJObject CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return LJObject.Create(Native->CallObjectMethodA(obj, Address, ptr));
    }

    public GJObject CallG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return GJObject.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Address, ptr));
    }

    public GJObject CallVirtG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return GJObject.Create(Native->CallObjectMethodA(obj, Address, ptr));
    }
}

public unsafe class JBoolMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, handle.Env.Types.Bool, clazz, args)
{
    public bool Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualBooleanMethodA(obj, Clazz, Address, ptr);
    }

    public bool CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallBooleanMethodA(obj, Address, ptr);
    }
}

public unsafe class JByteMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, handle.Env.Types.Byte, clazz, args)
{
    public byte Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualByteMethodA(obj, Clazz, Address, ptr);
    }

    public byte CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallByteMethodA(obj, Address, ptr);
    }
}

public unsafe class JCharMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, handle.Env.Types.Char, clazz, args)
{
    public char Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualCharMethodA(obj, Clazz, Address, ptr);
    }

    public char CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallCharMethodA(obj, Address, ptr);
    }
}

public unsafe class JShortMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, handle.Env.Types.Short, clazz, args)
{
    public short Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualShortMethodA(obj, Clazz, Address, ptr);
    }

    public short CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallShortMethodA(obj, Address, ptr);
    }
}

public unsafe class JIntMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, handle.Env.Types.Int, clazz, args)
{
    public int Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualIntMethodA(obj, Clazz, Address, ptr);
    }

    public int CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallIntMethodA(obj, Address, ptr);
    }
}

public unsafe class JLongMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, handle.Env.Types.Long, clazz, args)
{
    public long Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualLongMethodA(obj, Clazz, Address, ptr);
    }

    public long CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallLongMethodA(obj, Address, ptr);
    }
}

public unsafe class JFloatMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, handle.Env.Types.Float, clazz, args)
{
    public float Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualFloatMethodA(obj, Clazz, Address, ptr);
    }

    public float CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallFloatMethodA(obj, Address, ptr);
    }
}

public unsafe class JDoubleMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, handle.Env.Types.Double, clazz, args)
{
    public double Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualDoubleMethodA(obj, Clazz, Address, ptr);
    }

    public double CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallDoubleMethodA(obj, Address, ptr);
    }
}

public unsafe class JEnumMethod<T> : JMethod where T : struct, Enum
{
    public JEnumMethod(LHandle handle, string name, JEnum<T> type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) => ReturnEnumType = type;

    public readonly JEnum<T> ReturnEnumType;

    public java.lang.Enum<T> Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
        {
            using var data = LJObject.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Address, ptr));
            return ReturnEnumType[data];
        }
    }

    public java.lang.Enum<T> CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
        {
            using var data = LJObject.Create(Native->CallObjectMethodA(obj, Address, ptr));
            return ReturnEnumType[data];
        }
    }
}