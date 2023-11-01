using JNI.Models.Local;

namespace JNI.Models.Weak;
public class WeakJObject : JObject, IDisposable
{
    public WeakJObject(Env env, nint addr) : base(env, addr) { }

    public new void Dispose() { }
}