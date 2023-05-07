using JNI.Models.Local;

namespace JNI.BaseTypes;
public sealed class JBBool : JClass
{
    public JBBool(Env env) : base(env, "java/lang/Boolean", "Z")
    {

    }
}