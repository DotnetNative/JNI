using JNI.Models.Local;

namespace JNI.Models.Global;
public class JGType : JType
{
    public JGType(Env env, string nameAndSig) : base(env, nameAndSig) => PutGlobal();
    public JGType(Env env, nint handle, string nameAndSig) : base(env, handle, nameAndSig) => PutGlobal();
    public JGType(Env env, string name, string sig) : base(env, name, sig) => PutGlobal();
    public JGType(Env env, nint handle, string name, string sig) : base(env, handle, name, sig) => PutGlobal();
    public JGType(Env env, JGObject obj, string nameAndSig) : base(env, obj.Addr, nameAndSig) { }
    public JGType(Env env, JGObject obj, string name, string sig) : base(env, obj.Addr, name, sig) { }
}