using JNI.Models.Local;

namespace JNI.BaseTypes;
public sealed class JBLong : JClass
{
    public JBLong(Env env) : base(env, "java/lang/Long", "J")
    {

    }
}