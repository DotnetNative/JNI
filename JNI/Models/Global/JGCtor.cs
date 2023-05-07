using JNI.Models.Local;

namespace JNI.Models.Global;
public class JGCtor : JCtor
{
    public JGCtor(JMethod method) : base(method) => PutGlobal();
    public JGCtor(Env env, string name, JType type, Arg[] args, ClassHandle clazz) : base(env, name, type, args, clazz) => PutGlobal();
    public JGCtor(Env env, nint handle, string name, JType type, Arg[] args, ClassHandle clazz) : base(env, handle, name, type, args, clazz) => PutGlobal();
}