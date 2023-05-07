using JNI.Models.Local;

namespace JNI.BaseTypes;
public sealed class JBFloat : JClass
{
    public JBFloat(Env env) : base(env, "java/lang/Float", "F")
    {

    }
}