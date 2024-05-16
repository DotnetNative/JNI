namespace JNI;
public unsafe class JCtor : JMethod
{
    public JCtor(MethodDescriptor handle, Arg[] args, JClass clazz) : base(handle, "<init>", Types.Void, clazz, args) { }
    public JCtor(JMethod method) : base(method.Descriptor, method.Name, method.ReturnType, method.Class) { }

    public JObject NewInstance(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return JObject.Create(env_->NewObject(Class, Descriptor, ptr));
    }

    public JObject NewGInstance(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return JObject.Create(env_->NewObject(Class, Descriptor, ptr));
    }
}