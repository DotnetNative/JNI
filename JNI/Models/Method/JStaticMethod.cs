namespace JNI;
public abstract class JStaticMethod(EnvHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : JMethodInstance(handle, name, type, clazz, args);
public abstract class LJStaticMethod(LHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : JStaticMethod(handle, name, type, clazz, args);
public abstract class GJStaticMethod(GHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : JStaticMethod(handle, name, type, clazz, args);

public unsafe class LJStaticVoidMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJStaticMethod(handle, name, handle.Env.Types.Void, clazz, args)
{
    public void Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            Native->CallStaticVoidMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticVoidMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJStaticMethod(handle, name, handle.Env.Types.Void, clazz, args)
{
    public void Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            Native->CallStaticVoidMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticStringMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJStaticMethod(handle, name, handle.Env.Types.String, clazz, args)
{
    public java.lang.String Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(LHandle.Create(Native->CallStaticObjectMethodA(Clazz, Addr, ptr)));
    }

    public java.lang.String CallG(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(GHandle.Create(Native->CallStaticObjectMethodA(Clazz, Addr, ptr)));
    }
}

public unsafe class GJStaticStringMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJStaticMethod(handle, name, handle.Env.Types.String, clazz, args)
{
    public java.lang.String Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(LHandle.Create(Native->CallStaticObjectMethodA(Clazz, Addr, ptr)));
    }

    public java.lang.String CallG(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(GHandle.Create(Native->CallStaticObjectMethodA(Clazz, Addr, ptr)));
    }
}

public unsafe class LJStaticObjectMethod(LHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : LJStaticMethod(handle, name, type, clazz, args)
{
    public LJObject Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return LJObject.Create(Native->CallStaticObjectMethodA(Clazz, Addr, ptr));
    }

    public GJObject CallG(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return GJObject.Create(Native->CallStaticObjectMethodA(Clazz, Addr, ptr));
    }
}

public unsafe class GJStaticObjectMethod(GHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : GJStaticMethod(handle, name, type, clazz, args)
{
    public LJObject Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return LJObject.Create(Native->CallStaticObjectMethodA(Clazz, Addr, ptr));
    }

    public GJObject CallG(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return GJObject.Create(Native->CallStaticObjectMethodA(Clazz, Addr, ptr));
    }
}

public unsafe class LJStaticBoolMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJStaticMethod(handle, name, handle.Env.Types.Bool, clazz, args)
{
    public bool Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticBooleanMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticBoolMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJStaticMethod(handle, name, handle.Env.Types.Bool, clazz, args)
{
    public bool Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticBooleanMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticByteMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJStaticMethod(handle, name, handle.Env.Types.Byte, clazz, args)
{
    public byte Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticByteMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticByteMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJStaticMethod(handle, name, handle.Env.Types.Byte, clazz, args)
{
    public byte Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticByteMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticCharMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJStaticMethod(handle, name, handle.Env.Types.Char, clazz, args)
{
    public char Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticCharMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticCharMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJStaticMethod(handle, name, handle.Env.Types.Char, clazz, args)
{
    public char Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticCharMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticShortMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJStaticMethod(handle, name, handle.Env.Types.Short, clazz, args)
{
    public short Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticShortMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticShortMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJStaticMethod(handle, name, handle.Env.Types.Short, clazz, args)
{
    public short Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticShortMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticIntMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJStaticMethod(handle, name, handle.Env.Types.Int, clazz, args)
{
    public int Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticIntMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticIntMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJStaticMethod(handle, name, handle.Env.Types.Int, clazz, args)
{
    public int Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticIntMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticLongMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJStaticMethod(handle, name, handle.Env.Types.Long, clazz, args)
{
    public long Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticLongMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticLongMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJStaticMethod(handle, name, handle.Env.Types.Long, clazz, args)
{
    public long Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticLongMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticFloatMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJStaticMethod(handle, name, handle.Env.Types.Float, clazz, args)
{
    public float Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticFloatMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticFloatMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJStaticMethod(handle, name, handle.Env.Types.Float, clazz, args)
{
    public float Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticFloatMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticDoubleMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : LJStaticMethod(handle, name, handle.Env.Types.Double, clazz, args)
{
    public double Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticDoubleMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticDoubleMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : GJStaticMethod(handle, name, handle.Env.Types.Double, clazz, args)
{
    public double Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticDoubleMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticEnumMethod<T> : LJStaticMethod where T : struct, Enum
{
    public LJStaticEnumMethod(LHandle handle, string name, JEnum<T> type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) => ReturnEnumType = type;

    public JEnum<T> ReturnEnumType;

    public java.lang.Enum<T> Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
        {
            using var data = LJObject.Create(Native->CallStaticObjectMethodA(Clazz, Addr, ptr));
            return ReturnEnumType[data];
        }
    }
}

public unsafe class GJStaticEnumMethod<T> : GJStaticMethod where T : struct, Enum
{
    public GJStaticEnumMethod(GHandle handle, string name, JEnum<T> type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) => ReturnEnumType = type;

    public JEnum<T> ReturnEnumType;

    public java.lang.Enum<T> Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
        {
            using var data = LJObject.Create(Native->CallStaticObjectMethodA(Clazz, Addr, ptr));
            return ReturnEnumType[data];
        }
    }
}