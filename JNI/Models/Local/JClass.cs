using JNI.Internal;

namespace JNI.Models.Local;
public unsafe class JClass : JType
{
    public JClass(Env env, string name, string sig) : base(env, env.Master->FindClass(name.UtfPtr()), name, sig) { }

    public JClass(Env env, string nameAndSig) : this(env, nameAndSig, nameAndSig) { }
}