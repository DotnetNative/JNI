using JNI.Models.Global;

namespace JNI.Models.Local;
public unsafe class JCtor : JMethod
{
    public JCtor(Env env, string name, JType type, Arg[] args, ClassHandle clazz) : base(env, name, type, args, clazz) { }
    public JCtor(Env env, nint handle, string name, JType type, Arg[] args, ClassHandle clazz) : base(env, handle, name, type, args, clazz) { }
    public JCtor(JMethod method) : base(method.Env, method.MethodName, method.Type, method.Args, method.Clazz) { }

    public JObject NewInstance(Params args) => new JObject(Env, Env.Master->NewObjectA((IntPtr)Clazz, Addr, args.Ptr));
    public JObject NewInstance() => new JObject(Env, Env.Master->NewObjectA((IntPtr)Clazz, Addr, new Params().Ptr));
    public JGObject NewGlobalInstance(Params args) => new JGObject(Env, Env.Master->NewObjectA((IntPtr)Clazz, Addr, args.Ptr));
    public JGObject NewGlobalInstance() => new JGObject(Env, Env.Master->NewObjectA((IntPtr)Clazz, Addr, new Params().Ptr));
    public JGObject NewGlobalInstance(Env env, Params args) => new JGObject(env, env.Master->NewObjectA((IntPtr)Clazz, Addr, args.Ptr));
    public JGObject NewGlobalInstance(Env env) => new JGObject(env, env.Master->NewObjectA((IntPtr)Clazz, Addr, new Params().Ptr));
}