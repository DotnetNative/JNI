namespace JNI.Models.Local;
public class WeakJObject : JObject, IDisposable
{
    public WeakJObject(Env env, nint addr) : base(env, addr) { }

    public new void Dispose() { }
}