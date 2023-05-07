using JNI.Models.Local;

namespace JNI.Models.Global;
public class JGObject : JObject
{
    public JGObject(Env env, nint addr) : base(env, addr) => PutGlobal();
}
