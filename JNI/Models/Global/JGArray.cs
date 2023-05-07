using JNI.Models.Local;

namespace JNI.Models.Global;
public class JGArray : JArray
{
    public JGArray(JObject obj) : base(obj) => PutGlobal();

    public JGArray(Env env, nint addr, bool putGlobal) : base(env, addr)
    {
        if (putGlobal)
            PutGlobal();
    }
}