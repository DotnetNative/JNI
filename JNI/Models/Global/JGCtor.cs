namespace JNI.Models.Global;
public unsafe sealed class JGCtor : JGMethod
{
    public JGCtor(nint gAddr, nint lAddr, string name, TypeInfo type, ClassHandle clazz, params Arg[] args) : base(gAddr, lAddr, name, type, clazz, args) { }
    public JGCtor(JGMethod method) : base(method.Addr, method.LocalAddr, method.MethodName, method.Sig, method.Clazz) { }

    public JGObject NewInstance(Env env) => NewInstance(env, new());
    public JGObject NewInstance(Env env, Params args)
    {
        fixed (JValue* ptr = args.Values)
        {
            var obj = env.Master->NewObjectA(!Clazz, Addr, ptr);
            return new(env.Master->NewGlobalRef(obj), obj);
        }
    }
}