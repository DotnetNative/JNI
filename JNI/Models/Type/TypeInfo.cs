namespace JNI;
public class TypeInfo
{
    public TypeInfo(string name, string signature, int dimension = 0)
    {
        Name = name.AsJavaPath();
        Signature = signature.AsJavaPath();
        Dimension = dimension;
    }

    public TypeInfo(string nameAndSig, int dimension = 0) : this(nameAndSig, nameAndSig, dimension) { }

    public readonly string Name;
    public readonly string Signature;
    public readonly int Dimension = 0;

    public bool IsArray => Dimension != 0;

    public static implicit operator Arg(TypeInfo val) => new(val);
}