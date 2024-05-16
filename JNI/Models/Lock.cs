namespace JNI;
public class Lock : IDisposable
{
    public Lock(JObject obj)
    {
        Obj = obj;
        env.Enter(obj);
    }

    public JObject Obj;

    public void Dispose() => env.Exit(Obj);
}