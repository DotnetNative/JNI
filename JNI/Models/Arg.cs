namespace JNI;
public sealed class Arg
{
    public Arg(string sig)
    {
        if (sig.EndsWith(';'))
            Sig = sig;
        else
        {
            var dim = 0;
            for (var i = 0; i < sig.Length; i++)
                if (sig[i] == '[')
                    dim++;

            if (sig.Length - dim == 1 && SigGen.PrimitiveTypes.Contains(sig[^1]))
                Sig = sig;
            else Sig = $"{new string('[', dim)}L{sig};";
        }
    }
    public Arg(JType type) : this(SigGen.Arg(type)) { }
    public Arg(TypeInfo info) : this(SigGen.Arg(info)) { }

    public readonly string Sig;
}