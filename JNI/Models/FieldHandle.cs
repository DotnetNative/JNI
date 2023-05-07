namespace JNI.Models;
public class FieldHandle : HandleEnv
{
    public FieldHandle(Env env, IntPtr handle) : base(env, handle) { }
}