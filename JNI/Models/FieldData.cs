using JNI.Models.Local;

namespace JNI.Models;
public class FieldData : FieldHandle
{
    public FieldData(Env env, IntPtr handle, string name, JType type) : base(env, handle)
    {
        FieldName = name;
        Type = type;
    }

    public string FieldName { get; protected private set; }
    public JType Type { get; protected private set; }
}