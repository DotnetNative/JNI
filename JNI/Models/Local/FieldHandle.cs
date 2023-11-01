namespace JNI.Models.Local;
public class FieldHandle : LHandle
{
    public FieldHandle(Env env, nint handle) : base(env, handle) { }
}