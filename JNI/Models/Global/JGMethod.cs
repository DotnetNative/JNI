using JNI.Models.Local;

namespace JNI.Models.Global;
public class JGMethod : JMethod
{
    public JGMethod(Env env, string name, JType type, Arg[] args, ClassHandle clazz) : base(env, name, type, args, clazz) => PutGlobal();
    public JGMethod(Env env, nint handle, string name, JType type, Arg[] args, ClassHandle clazz) : base(env, handle, name, type, args, clazz) => PutGlobal();
}