using JNI.Models.Local;

namespace JNI.Models.Global;
public class JGStaticMethod : JStaticMethod
{
    public JGStaticMethod(Env env, string name, JType type, ClassHandle clazz, params Arg[] args) : base(env, name, type, clazz, args) => PutGlobal();
    public JGStaticMethod(Env env, nint handle, string name, JType type, ClassHandle clazz, params Arg[] args) : base(env, handle, name, type, clazz, args) => PutGlobal();
}