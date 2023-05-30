using JNI.Models.Local;

namespace JNI.Models;
public class MethodHandle : LHandle
{
    public MethodHandle(Env env, nint handle) : base(env, handle) { }
}