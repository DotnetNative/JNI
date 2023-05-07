using JNI.Models.Local;

namespace JNI.Models.Global;
public class JGClass : JClass
{
    public JGClass(Env env, string nameAndSig) : base(env, nameAndSig) => PutGlobal();
    public JGClass(Env env, string name, string sig) : base(env, name, sig) => PutGlobal();
}