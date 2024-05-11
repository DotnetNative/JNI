namespace JNI;
public abstract class JStaticMethod(EnvHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : JMethodInstance(handle, name, type, clazz, args);

public unsafe class JStaticVoidMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JStaticMethod(handle, name, handle.Env.Types.Void, clazz, args)
{
    public void Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            Native->CallStaticVoidMethodA(Clazz, Address, ptr);
    }
}

public unsafe class JStaticStringMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JStaticMethod(handle, name, handle.Env.Types.String, clazz, args)
{
    public java.lang.String Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(LHandle.Create(Native->CallStaticObjectMethodA(Clazz, Address, ptr)));
    }

    public java.lang.String CallG(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(GHandle.Create(Native->CallStaticObjectMethodA(Clazz, Address, ptr)));
    }
}

public unsafe class JStaticObjectMethod(LHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : JStaticMethod(handle, name, type, clazz, args)
{
    public LJObject Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return LJObject.Create(Native->CallStaticObjectMethodA(Clazz, Address, ptr));
    }

    public GJObject CallG(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return GJObject.Create(Native->CallStaticObjectMethodA(Clazz, Address, ptr));
    }
}

public unsafe class JStaticBoolMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JStaticMethod(handle, name, handle.Env.Types.Bool, clazz, args)
{
    public bool Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticBooleanMethodA(Clazz, Address, ptr);
    }
}

public unsafe class JStaticByteMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JStaticMethod(handle, name, handle.Env.Types.Byte, clazz, args)
{
    public byte Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticByteMethodA(Clazz, Address, ptr);
    }
}

public unsafe class JStaticCharMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JStaticMethod(handle, name, handle.Env.Types.Char, clazz, args)
{
    public char Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticCharMethodA(Clazz, Address, ptr);
    }
}

public unsafe class JStaticShortMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JStaticMethod(handle, name, handle.Env.Types.Short, clazz, args)
{
    public short Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticShortMethodA(Clazz, Address, ptr);
    }
}

public unsafe class JStaticIntMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JStaticMethod(handle, name, handle.Env.Types.Int, clazz, args)
{
    public int Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticIntMethodA(Clazz, Address, ptr);
    }
}

public unsafe class JStaticLongMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JStaticMethod(handle, name, handle.Env.Types.Long, clazz, args)
{
    public long Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticLongMethodA(Clazz, Address, ptr);
    }
}

public unsafe class JStaticFloatMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JStaticMethod(handle, name, handle.Env.Types.Float, clazz, args)
{
    public float Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticFloatMethodA(Clazz, Address, ptr);
    }
}

public unsafe class JStaticDoubleMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : JStaticMethod(handle, name, handle.Env.Types.Double, clazz, args)
{
    public double Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallStaticDoubleMethodA(Clazz, Address, ptr);
    }
}

public unsafe class JStaticEnumMethod<T> : JStaticMethod where T : struct, Enum
{
    public JStaticEnumMethod(LHandle handle, string name, JEnum<T> type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) => ReturnEnumType = type;

    public JEnum<T> ReturnEnumType;

    public java.lang.Enum<T> Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
        {
            using var data = LJObject.Create(Native->CallStaticObjectMethodA(Clazz, Address, ptr));
            return ReturnEnumType[data];
        }
    }
}