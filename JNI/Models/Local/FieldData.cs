namespace JNI.Models;
public class FieldData : FieldHandle
{
    public FieldData(Env env, nint handle, string name, string sig) : base(env, handle)
    {
        FieldName = name;
        Sig = sig;
    }

    public string FieldName;
    public string Sig;
}