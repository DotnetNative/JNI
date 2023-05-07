using JNI.Models.Local;

namespace JNI.BaseTypes;
public sealed class JBShort : JClass
{
    public JBShort(Env env) : base(env, "java/lang/Short", "S")
    {

    }
}