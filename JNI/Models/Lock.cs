using JNI.Models.Models.Object;

namespace JNI.Models;
public class Lock : IDisposable
{
    public Lock(JObject obj)
    {
        Obj = obj;
        obj.Env.Lock(obj);
    }

    public JObject Obj;

    public void Dispose() => Obj.Env.Unlock(Obj);
}