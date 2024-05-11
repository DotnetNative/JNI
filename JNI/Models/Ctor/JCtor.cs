namespace JNI;
public unsafe class JCtor : JMethod
{
    public JCtor(EnvHandle handle, string name, Arg[] args, JClass clazz) : base(handle, name, handle.Env.Types.Void, clazz, args) { }
    public JCtor(JMethod method) : base(method.Handle, method.MethodName, method.ReturnType, method.Clazz) { }

    public LJObject NewInstance(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return LJObject.Create(Env.Native->NewObjectA(Clazz, Address, ptr));
    }

    public GJObject NewGInstance(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return GJObject.Create(Env.Native->NewObjectA(Clazz, Address, ptr));
    }
}