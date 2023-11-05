namespace JNI;
public abstract class FieldData : FieldHandle
{
    public FieldData(EnvHandle handle, string name, TypeInfo type) : base(handle)
    {
        Name = name;
        Signature = SigGen.Field(type);
        Type = type;
    }

    public readonly string Name;
    public readonly string Signature;
    public readonly TypeInfo Type;
}