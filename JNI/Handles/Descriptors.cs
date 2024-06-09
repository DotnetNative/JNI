namespace JNI;
public struct FieldDescriptor
{
    public FieldDescriptor(nint descriptor) => Descriptor = descriptor;

    public nint Descriptor;

    public override string ToString() => $"{(pointer)Descriptor}";

    public static implicit operator nint(FieldDescriptor field) => field.Descriptor;
    public static implicit operator pointer(FieldDescriptor field) => field.Descriptor;
    public static implicit operator FieldDescriptor(nint descriptor) => new(descriptor);
}

public struct MethodDescriptor
{
    public MethodDescriptor(nint descriptor) => Descriptor = descriptor;

    public nint Descriptor;

    public override string ToString() => $"{(pointer)Descriptor}";

    public static implicit operator nint(MethodDescriptor method) => method.Descriptor;
    public static implicit operator pointer(MethodDescriptor method) => method.Descriptor;
    public static implicit operator MethodDescriptor(nint descriptor) => new(descriptor);
}