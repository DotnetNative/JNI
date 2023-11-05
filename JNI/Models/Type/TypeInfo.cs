using JNI.Internal;

namespace JNI;
public class TypeInfo
{
    public TypeInfo(string name, string sig, int dim = 0)
    {
        Name = name.AsJavaPath();
        Sig = sig.AsJavaPath();
        Dim = dim;
    }

    public TypeInfo(string nameAndSig, int dim = 0) : this(nameAndSig, nameAndSig, dim) { }

    public string Name;
    public string Sig;
    public int Dim = 0;

    public bool IsArray => Dim != 0;

    public static implicit operator Arg(TypeInfo val) => new(val);
}