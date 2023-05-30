using JNI.Models.Local;

namespace JNI.Models;
public class FieldHandle : LHandle
{
    public FieldHandle(Env env, nint handle) : base(env, handle) { }
}