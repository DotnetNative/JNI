namespace JNI;
public abstract class MethodData
{
    public MethodData(MethodDescriptor descriptor, string name, TypeInfo info, Arg[] args)
    {
        Descriptor = descriptor;
        Name = name;
        ReturnType = info;
        Signature = SigGen.Method(info, args);
    }

    public readonly string Name;
    public readonly string Signature;
    public readonly TypeInfo ReturnType;
    public readonly MethodDescriptor Descriptor;

    public override string ToString() => $"{Signature} [{Descriptor}]";

    public static implicit operator nint(MethodData data) => data.Descriptor;
}