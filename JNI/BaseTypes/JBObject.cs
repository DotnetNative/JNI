using JNI.Models.Local;

namespace JNI.BaseTypes;
public sealed class JBObject : JClass
{
    public JBObject(Env env) : base(env, "java/lang/Object")
    {

    }
}