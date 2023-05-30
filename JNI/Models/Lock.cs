using JNI.Models.Global;
using JNI.Models.Local;

namespace JNI.Models;
public class Lock : IDisposable
{
    public Lock(JObject obj)
    {
        Obj = obj;
        Env = obj.Env;
        Env.Lock(obj);
    }

    public Lock(Env env, JGObject obj) : this(obj.AsWeak(env)) { }

    public JObject Obj;
    public Env Env;

    public void Dispose() => Env.Unlock(Obj);
}