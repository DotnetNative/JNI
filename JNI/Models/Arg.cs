using JNI.Models.Local;
using JNI.Utils;

namespace JNI.Models;
public sealed class Arg
{
    public Arg(string sig) => Sig = sig;

    public Arg(JType type) : this(SigGen.Arg(type)) { }

    public Arg(TypeInfo info) : this(SigGen.Arg(info)) { }

    public string Sig;
}