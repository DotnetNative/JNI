namespace JNI;
public abstract class FieldData
{
    public FieldData(FieldDescriptor descriptor, string name, TypeInfo type)
    {
        Descriptor = descriptor;
        Name = name;
        Signature = SigGen.Type(type);
        Type = type;
    }

    public readonly string Name;
    public readonly string Signature;
    public readonly TypeInfo Type;
    public readonly FieldDescriptor Descriptor;

    public override string ToString() => $"0x{Descriptor.Descriptor:X}";

    public static implicit operator nint(FieldData data) => data.Descriptor;
}