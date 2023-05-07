using JNI.Models.Local;

namespace JNI.BaseTypes;
public sealed class JBString : JClass
{
    public JBString(Env env) : base(env, "java/lang/String")
    {

    }
}