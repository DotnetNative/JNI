namespace JNI;
public unsafe class JConstructor : JMethodInstance
{
    public JConstructor(MethodDescriptor handle, JClass clazz, params Arg[] args) : base(handle, "<init>", Types.Void, clazz, args) { }

    public JObject NewInstance(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return JObjectImpl.Create(env_->NewObject(Class, Descriptor, ptr));
    }
}