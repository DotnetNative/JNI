namespace JNI;
public class TypeInfo
{
    public TypeInfo(string signature, int dimension = 0)
    {
        Signature = signature.AsJavaPath();
        Dimension = dimension;
    }

    public TypeInfo(TypeInfo type, int dimension) : this(type.Signature, type.Dimension + dimension) { }

    public readonly string Signature;
    public readonly int Dimension = 0;

    public bool IsArray => Dimension != 0;

    public override string ToString() => new string('[', Dimension) + Signature;
    public static implicit operator Arg(TypeInfo val) => new(val);
}