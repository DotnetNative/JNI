namespace JNI;
public abstract class JStaticMethod : JMethodInstance
{
    public JStaticMethod(EnvHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) { }
}

public abstract class LJStaticMethod : JStaticMethod
{
    public LJStaticMethod(LHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) { }
}

public abstract class GJStaticMethod : JStaticMethod
{
    public GJStaticMethod(GHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) { }
}

public unsafe class LJStaticVoidMethod : LJStaticMethod
{
    public LJStaticVoidMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Void, clazz, args) { }

    public void Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            Native->CallStaticVoidMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticVoidMethod : GJStaticMethod
{
    public GJStaticVoidMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Void, clazz, args) { }

    public void Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            Native->CallStaticVoidMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticObjectMethod : LJStaticMethod
{
    public LJStaticObjectMethod(LHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) { }

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

public unsafe class GJStaticObjectMethod : GJStaticMethod
{
    public GJStaticObjectMethod(GHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) { }

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

public unsafe class LJStaticBoolMethod : LJStaticMethod
{
    public LJStaticBoolMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Bool, clazz, args) { }

    public bool Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticBooleanMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticBoolMethod : GJStaticMethod
{
    public GJStaticBoolMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Bool, clazz, args) { }

    public bool Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticBooleanMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticByteMethod : LJStaticMethod
{
    public LJStaticByteMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Byte, clazz, args) { }

    public byte Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticByteMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticByteMethod : GJStaticMethod
{
    public GJStaticByteMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Byte, clazz, args) { }

    public byte Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticByteMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticCharMethod : LJStaticMethod
{
    public LJStaticCharMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Char, clazz, args) { }

    public char Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticCharMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticCharMethod : GJStaticMethod
{
    public GJStaticCharMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Char, clazz, args) { }

    public char Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticCharMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticShortMethod : LJStaticMethod
{
    public LJStaticShortMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Short, clazz, args) { }

    public short Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticShortMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticShortMethod : GJStaticMethod
{
    public GJStaticShortMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Short, clazz, args) { }

    public short Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticShortMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticIntMethod : LJStaticMethod
{
    public LJStaticIntMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Int, clazz, args) { }

    public int Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticIntMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticIntMethod : GJStaticMethod
{
    public GJStaticIntMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Int, clazz, args) { }

    public int Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticIntMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticLongMethod : LJStaticMethod
{
    public LJStaticLongMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Long, clazz, args) { }

    public long Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticLongMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticLongMethod : GJStaticMethod
{
    public GJStaticLongMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Long, clazz, args) { }

    public long Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticLongMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticFloatMethod : LJStaticMethod
{
    public LJStaticFloatMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Float, clazz, args) { }

    public float Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticFloatMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticFloatMethod : GJStaticMethod
{
    public GJStaticFloatMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Float, clazz, args) { }

    public float Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticFloatMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class LJStaticDoubleMethod : LJStaticMethod
{
    public LJStaticDoubleMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Double, clazz, args) { }

    public double Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticDoubleMethodA(Clazz, Addr, ptr);
    }
}

public unsafe class GJStaticDoubleMethod : GJStaticMethod
{
    public GJStaticDoubleMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Double, clazz, args) { }

    public double Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticDoubleMethodA(Clazz, Addr, ptr);
    }
}