using JNI.Models.Local;

namespace JNI.BaseTypes;
public sealed class JBInt : JClass
{
    public JBInt(Env env) : base(env, "java/lang/Integer", "I")
    {

    }
}