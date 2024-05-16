namespace JNI;
public abstract class JStaticMethod(MethodDescriptor descriptor, string name, TypeInfo type, JClass clazz, params Arg[] args) : JMethodInstance(descriptor, name, type, clazz, args);

public unsafe class JStaticVoidMethod(MethodDescriptor descriptor, string name, JClass clazz, params Arg[] args) : JStaticMethod(descriptor, name, Types.Void, clazz, args)
{
    public void Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            env_->CallStaticVoidMethod(Class, Descriptor, ptr);
    }
}

public unsafe class JStaticStringMethod(MethodDescriptor descriptor, string name, JClass clazz, params Arg[] args) : JStaticMethod(descriptor, name, Types.String, clazz, args)
{
    public JString Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(HandleImpl.Create(env_->CallStaticObjectMethod(Class, Descriptor, ptr))) ;
    }
}

public unsafe class JStaticObjectMethod(MethodDescriptor descriptor, string name, TypeInfo type, JClass clazz, params Arg[] args) : JStaticMethod(descriptor, name, type, clazz, args)
{
    public JObject Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return JObject.Create(env_->CallStaticObjectMethod(Class, Descriptor, ptr));
    }
}

public unsafe class JStaticBoolMethod(MethodDescriptor descriptor, string name, JClass clazz, params Arg[] args) : JStaticMethod(descriptor, name, Types.Bool, clazz, args)
{
    public bool Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallStaticBooleanMethod(Class, Descriptor, ptr);
    }
}

public unsafe class JStaticByteMethod(MethodDescriptor descriptor, string name, JClass clazz, params Arg[] args) : JStaticMethod(descriptor, name, Types.Byte, clazz, args)
{
    public byte Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallStaticByteMethod(Class, Descriptor, ptr);
    }
}

public unsafe class JStaticCharMethod(MethodDescriptor descriptor, string name, JClass clazz, params Arg[] args) : JStaticMethod(descriptor, name, Types.Char, clazz, args)
{
    public char Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallStaticCharMethod(Class, Descriptor, ptr);
    }
}

public unsafe class JStaticShortMethod(MethodDescriptor descriptor, string name, JClass clazz, params Arg[] args) : JStaticMethod(descriptor, name, Types.Short, clazz, args)
{
    public short Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallStaticShortMethod(Class, Descriptor, ptr);
    }
}

public unsafe class JStaticIntMethod(MethodDescriptor descriptor, string name, JClass clazz, params Arg[] args) : JStaticMethod(descriptor, name, Types.Int, clazz, args)
{
    public int Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallStaticIntMethod(Class, Descriptor, ptr);
    }
}

public unsafe class JStaticLongMethod(MethodDescriptor descriptor, string name, JClass clazz, params Arg[] args) : JStaticMethod(descriptor, name, Types.Long, clazz, args)
{
    public long Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallStaticLongMethod(Class, Descriptor, ptr);
    }
}

public unsafe class JStaticFloatMethod(MethodDescriptor descriptor, string name, JClass clazz, params Arg[] args) : JStaticMethod(descriptor, name, Types.Float, clazz, args)
{
    public float Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallStaticFloatMethod(Class, Descriptor, ptr);
    }
}

public unsafe class JStaticDoubleMethod(MethodDescriptor descriptor, string name, JClass clazz, params Arg[] args) : JStaticMethod(descriptor, name, Types.Double, clazz, args)
{
    public double Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallStaticDoubleMethod(Class, Descriptor, ptr);
    }
}

public unsafe class JStaticEnumMethod<T> : JStaticMethod where T : struct, Enum
{
    public JStaticEnumMethod(MethodDescriptor descriptor, string name, JEnum<T> type, JClass clazz, params Arg[] args) : base(descriptor, name, type, clazz, args) => ReturnEnumType = type;

    public JEnum<T> ReturnEnumType;

    public JEnumTuple<T> Call(params JValue[] args)
    {
        fixed (JValue* ptr = args)
        {
            using var data = JObject.Create(env_->CallStaticObjectMethod(Class, Descriptor, ptr));
            return ReturnEnumType[data];
        }
    }
}