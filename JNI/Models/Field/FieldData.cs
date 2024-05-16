namespace JNI;
public abstract class FieldData
{
    public FieldData(FieldDescriptor descriptor, string name, TypeInfo type)
    {
        Descriptor = descriptor;
        Name = name;
        Signature = SigGen.Field(type);
        Type = type;
    }

    public readonly string Name;
    public readonly string Signature;
    public readonly TypeInfo Type;
    public readonly FieldDescriptor Descriptor;

    public static implicit operator nint(FieldData data) => data.Descriptor;
}