using JNI.Models.Local;

namespace JNI.BaseTypes;
public sealed class JBByte : JClass
{
    public JBByte(Env env) : base(env, "java/lang/Byte", "B")
    {

    }
}