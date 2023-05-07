using JNI.Models.Local;

namespace JNI.BaseTypes;
public sealed class JBDouble : JClass
{
    public JBDouble(Env env) : base(env, "java/lang/Double", "D")
    {

    }
}