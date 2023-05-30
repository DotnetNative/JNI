namespace JNI.Models.Local;
public unsafe sealed class JCtor : JMethod
{
    public JCtor(Env env, nint handle, string name, TypeInfo type, Arg[] args, ClassHandle clazz) : base(env, handle, name, type, clazz, args) { }
    public JCtor(JMethod method) : base(method.Env, method.Addr, method.MethodName, method.Sig, method.Clazz) { }

    public JObject NewInstance() => NewInstance(new());
    public JObject NewInstance(Params args)
    {
        fixed (JValue* ptr = args.Values)
            return new(Env, Env.Master->NewObjectA(!Clazz, Addr, ptr));
    }
}