namespace JNI;
public struct FieldDescriptor
{
    public FieldDescriptor(nint descriptor) => Descriptor = descriptor;

    public nint Descriptor;

    public static implicit operator nint(FieldDescriptor field) => field.Descriptor;
    public static implicit operator FieldDescriptor(nint descriptor) => new(descriptor);
}

public struct MethodDescriptor
{
    public MethodDescriptor(nint descriptor) => Descriptor = descriptor;

    public nint Descriptor;

    public static implicit operator nint(MethodDescriptor field) => field.Descriptor;
    public static implicit operator MethodDescriptor(nint descriptor) => new(descriptor);
}