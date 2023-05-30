using JNI.Internal;

namespace JNI.Models;
public class TypeInfo
{
    public TypeInfo(string name, string sig, int dim = 0, bool handleSig = false)
    {
        Name = name;
        Sig = sig;
        if (handleSig)
        {
            Name = name.AsJavaPath();
            Sig = Sig.AsJavaPath();
        }
        Dim = dim;
    }

    public TypeInfo(string nameAndSig, int dim = 0, bool handleSig = false) : this(nameAndSig, nameAndSig, dim, handleSig) { }

    public string Name;
    public string Sig;
    public int Dim = 0;

    public override string ToString() => $"TypeInfo({Name}, {Sig}, {Dim})";
}