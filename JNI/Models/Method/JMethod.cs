namespace JNI;
public abstract class JMethod(MethodDescriptor handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : JMethodInstance(handle, name, type, clazz, args);

public unsafe class JVoidMethod : JMethod
{
    public JVoidMethod(MethodDescriptor handle, string name, JClass clazz, params Arg[] args) : base(handle, name, Types.Void, clazz, args) { }

    public void Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            env_->CallNonvirtualVoidMethod(obj, Class, Descriptor, ptr);
    }

    public void CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            env_->CallVoidMethod(obj, Descriptor, ptr);
    }
}

public unsafe class JStringMethod(MethodDescriptor handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, Types.String, clazz, args)
{
    public JString Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(HandleImpl.Create(env_->CallNonvirtualObjectMethod(obj, Class, Descriptor, ptr)));
    }

    public JString CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(HandleImpl.Create(env_->CallObjectMethod(obj, Descriptor, ptr)));
    }

    public JString CallUTF8(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(HandleImpl.Create(env_->CallNonvirtualObjectMethod(obj, Class, Descriptor, ptr)), false);
    }

    public JString CallVirtUTF8(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return new(HandleImpl.Create(env_->CallObjectMethod(obj, Descriptor, ptr)), false);
    }
}

public unsafe class JObjectMethod(MethodDescriptor handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : JMethod(handle, name, type, clazz, args)
{
    public JObject Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return JObject.Create(env_->CallNonvirtualObjectMethod(obj, Class, Descriptor, ptr));
    }

    public JObject CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return JObject.Create(env_->CallObjectMethod(obj, Descriptor, ptr));
    }
}

public unsafe class JBoolMethod(MethodDescriptor handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, Types.Bool, clazz, args)
{
    public bool Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallNonvirtualBooleanMethod(obj, Class, Descriptor, ptr);
    }

    public bool CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallBooleanMethod(obj, Descriptor, ptr);
    }
}

public unsafe class JByteMethod(MethodDescriptor handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, Types.Byte, clazz, args)
{
    public byte Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallNonvirtualByteMethod(obj, Class, Descriptor, ptr);
    }

    public byte CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallByteMethod(obj, Descriptor, ptr);
    }
}

public unsafe class JCharMethod(MethodDescriptor handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, Types.Char, clazz, args)
{
    public char Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallNonvirtualCharMethod(obj, Class, Descriptor, ptr);
    }

    public char CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args) 
            return env_->CallCharMethod(obj, Descriptor, ptr);
    }
}

public unsafe class JShortMethod(MethodDescriptor handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, Types.Short, clazz, args)
{
    public short Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallNonvirtualShortMethod(obj, Class, Descriptor, ptr);
    }

    public short CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallShortMethod(obj, Descriptor, ptr);
    }
}

public unsafe class JIntMethod(MethodDescriptor handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, Types.Int, clazz, args)
{
    public int Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallNonvirtualIntMethod(obj, Class, Descriptor, ptr);
    }

    public int CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallIntMethod(obj, Descriptor, ptr);
    }
}

public unsafe class JLongMethod(MethodDescriptor handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, Types.Long, clazz, args)
{
    public long Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallNonvirtualLongMethod(obj, Class, Descriptor, ptr);
    }

    public long CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallLongMethod(obj, Descriptor, ptr);
    }
}

public unsafe class JFloatMethod(MethodDescriptor handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, Types.Float, clazz, args)
{
    public float Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallNonvirtualFloatMethod(obj, Class, Descriptor, ptr);
    }

    public float CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallFloatMethod(obj, Descriptor, ptr);
    }
}

public unsafe class JDoubleMethod(MethodDescriptor handle, string name, JClass clazz, params Arg[] args) : JMethod(handle, name, Types.Double, clazz, args)
{
    public double Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallNonvirtualDoubleMethod(obj, Class, Descriptor, ptr);
    }

    public double CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return env_->CallDoubleMethod(obj, Descriptor, ptr);
    }
}

public unsafe class JEnumMethod<T> : JMethod where T : struct, Enum
{
    public JEnumMethod(MethodDescriptor handle, string name, JEnum<T> type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) => ReturnEnumType = type;

    public readonly JEnum<T> ReturnEnumType;

    public JEnumTuple<T> Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
        {
            using var data = JObject.Create(env_->CallNonvirtualObjectMethod(obj, Class, Descriptor, ptr));
            return ReturnEnumType[data];
        }
    }

    public JEnumTuple<T> CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
        {
            using var data = JObject.Create(env_->CallObjectMethod(obj, Descriptor, ptr));
            return ReturnEnumType[data];
        }
    }
}