namespace JNI.Models.Local;
public class MethodHandle : LHandle
{
    public MethodHandle(Env env, nint handle) : base(env, handle) { }
}