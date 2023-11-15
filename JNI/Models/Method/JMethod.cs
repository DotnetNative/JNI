namespace JNI;
public abstract class JMethod(EnvHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : JMethodInstance(handle, name, type, clazz, args);
public abstract class LJMethod(LHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : JMethod(handle, name, type, clazz, args);
public abstract class GJMethod(GHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : JMethod(handle, name, type, clazz, args);

public unsafe class LJVoidMethod : LJMethod
{
    public LJVoidMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Void, clazz, args) { }

    public void Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            Native->CallNonvirtualVoidMethodA(obj, Clazz, Addr, ptr);
    }

    public void CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            Native->CallVoidMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJVoidMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJMethod(handle, name, handle.Env.Types.Void, clazz, args)
{
    public void Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            Native->CallNonvirtualVoidMethodA(obj, Clazz, Addr, ptr);
    }

    public void CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            Native->CallVoidMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJStringMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJMethod(handle, name, handle.Env.Types.String, clazz, args)
{
    public java.lang.String Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(LHandle.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Addr, ptr)));
    }

    public java.lang.String CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(GHandle.Create(Native->CallObjectMethodA(obj, Addr, ptr)));
    }

    public java.lang.String CallG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(GHandle.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Addr, ptr)));
    }

    public java.lang.String CallVirtG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(LHandle.Create(Native->CallObjectMethodA(obj, Addr, ptr)));
    }
}

public unsafe class GJStringMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJMethod(handle, name, handle.Env.Types.String, clazz, args)
{
    public java.lang.String Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(LJObject.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Addr, ptr)));
    }

    public java.lang.String CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(LJObject.Create(Native->CallObjectMethodA(obj, Addr, ptr)));
    }

    public java.lang.String CallG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(GJObject.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Addr, ptr)));
    }

    public java.lang.String CallVirtG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(GJObject.Create(Native->CallObjectMethodA(obj, Addr, ptr)));
    }
}

public unsafe class LJObjectMethod(LHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : LJMethod(handle, name, type, clazz, args)
{
    public LJObject Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return LJObject.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Addr, ptr));
    }

    public LJObject CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return LJObject.Create(Native->CallObjectMethodA(obj, Addr, ptr));
    }

    public GJObject CallG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return GJObject.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Addr, ptr));
    }

    public GJObject CallVirtG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return GJObject.Create(Native->CallObjectMethodA(obj, Addr, ptr));
    }
}

public unsafe class GJObjectMethod(GHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : GJMethod(handle, name, type, clazz, args)
{
    public LJObject Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return LJObject.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Addr, ptr));
    }

    public LJObject CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return LJObject.Create(Native->CallObjectMethodA(obj, Addr, ptr));
    }

    public GJObject CallG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return GJObject.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Addr, ptr));
    }

    public GJObject CallVirtG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return GJObject.Create(Native->CallObjectMethodA(obj, Addr, ptr));
    }
}

public unsafe class LJBoolMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJMethod(handle, name, handle.Env.Types.Bool, clazz, args)
{
    public bool Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualBooleanMethodA(obj, Clazz, Addr, ptr);
    }

    public bool CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallBooleanMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJBoolMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJMethod(handle, name, handle.Env.Types.Bool, clazz, args)
{
    public bool Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualBooleanMethodA(obj, Clazz, Addr, ptr);
    }

    public bool CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallBooleanMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJByteMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJMethod(handle, name, handle.Env.Types.Byte, clazz, args)
{
    public byte Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualByteMethodA(obj, Clazz, Addr, ptr);
    }

    public byte CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallByteMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJByteMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJMethod(handle, name, handle.Env.Types.Byte, clazz, args)
{
    public byte Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualByteMethodA(obj, Clazz, Addr, ptr);
    }

    public byte CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallByteMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJCharMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJMethod(handle, name, handle.Env.Types.Char, clazz, args)
{
    public char Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualCharMethodA(obj, Clazz, Addr, ptr);
    }

    public char CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallCharMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJCharMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJMethod(handle, name, handle.Env.Types.Char, clazz, args)
{
    public char Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualCharMethodA(obj, Clazz, Addr, ptr);
    }

    public char CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallCharMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJShortMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJMethod(handle, name, handle.Env.Types.Short, clazz, args)
{
    public short Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualShortMethodA(obj, Clazz, Addr, ptr);
    }

    public short CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallShortMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJShortMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJMethod(handle, name, handle.Env.Types.Short, clazz, args)
{
    public short Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualShortMethodA(obj, Clazz, Addr, ptr);
    }

    public short CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallShortMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJIntMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJMethod(handle, name, handle.Env.Types.Int, clazz, args)
{
    public int Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualIntMethodA(obj, Clazz, Addr, ptr);
    }

    public int CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallIntMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJIntMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJMethod(handle, name, handle.Env.Types.Int, clazz, args)
{
    public int Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualIntMethodA(obj, Clazz, Addr, ptr);
    }

    public int CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallIntMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJLongMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJMethod(handle, name, handle.Env.Types.Long, clazz, args)
{
    public long Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualLongMethodA(obj, Clazz, Addr, ptr);
    }

    public long CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallLongMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJLongMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJMethod(handle, name, handle.Env.Types.Long, clazz, args)
{
    public long Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualLongMethodA(obj, Clazz, Addr, ptr);
    }

    public long CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallLongMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJFloatMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJMethod(handle, name, handle.Env.Types.Float, clazz, args)
{
    public float Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualFloatMethodA(obj, Clazz, Addr, ptr);
    }

    public float CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallFloatMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJFloatMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJMethod(handle, name, handle.Env.Types.Float, clazz, args)
{
    public float Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualFloatMethodA(obj, Clazz, Addr, ptr);
    }

    public float CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallFloatMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJDoubleMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJMethod(handle, name, handle.Env.Types.Double, clazz, args)
{
    public double Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualDoubleMethodA(obj, Clazz, Addr, ptr);
    }

    public double CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallDoubleMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJDoubleMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJMethod(handle, name, handle.Env.Types.Double, clazz, args)
{
    public double Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualDoubleMethodA(obj, Clazz, Addr, ptr);
    }

    public double CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallDoubleMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJEnumMethod<T> : LJMethod where T : struct, Enum
{
    public LJEnumMethod(LHandle handle, string name, JEnum<T> type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) => ReturnEnumType = type;

    public readonly JEnum<T> ReturnEnumType;

    public java.lang.Enum<T> Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
        {
            using var data = LJObject.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Addr, ptr));
            return ReturnEnumType[data];
        }
    }

    public java.lang.Enum<T> CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
        {
            using var data = LJObject.Create(Native->CallObjectMethodA(obj, Addr, ptr));
            return ReturnEnumType[data];
        }
    }
}

public unsafe class GJEnumMethod<T> : GJMethod where T : struct, Enum
{
    public GJEnumMethod(GHandle handle, string name, JEnum<T> type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) => ReturnEnumType = type;

    public readonly JEnum<T> ReturnEnumType;

    public java.lang.Enum<T> Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
        {
            using var data = LJObject.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Addr, ptr));
            return ReturnEnumType[data];
        }
    }

    public java.lang.Enum<T> CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
        {
            using var data = LJObject.Create(Native->CallObjectMethodA(obj, Addr, ptr));
            return ReturnEnumType[data];
        }
    }
}