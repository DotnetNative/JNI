using JNI.Models.Local;

namespace JNI.Models.Weak;
public class WeakClassHandle : ClassHandle, IDisposable
{
    public WeakClassHandle(Env env, nint handle) : base(env, handle) { }

    public new void Dispose() { }
}