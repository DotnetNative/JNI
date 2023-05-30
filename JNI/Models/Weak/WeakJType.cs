using JNI.Models.Local;

namespace JNI.Models.Weak;

public class WeakJType : JType, IDisposable
{
    public WeakJType(Env env, nint handle, TypeInfo info) : base(env, handle, info) { }

    public new void Dispose() { }
}