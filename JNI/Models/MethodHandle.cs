namespace JNI.Models;
public class MethodHandle : HandleEnv
{
    public MethodHandle(Env env, IntPtr handle) : base(env, handle) { }
}