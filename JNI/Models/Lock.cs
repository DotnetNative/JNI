namespace JNI;
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