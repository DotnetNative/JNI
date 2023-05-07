using JNI.Models.Local;

namespace JNI.BaseTypes;
public sealed class JBVoid : JClass
{
    public JBVoid(Env env) : base(env, "java/lang/Void", "V")
    {

    }
}