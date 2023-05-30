using JNI.Models.Local;
using JNI.Utils;

namespace JNI.Models.Global;

public class GMethodData : GMethodHandle
{
    public GMethodData(nint gAddr, nint lAddr, string name, JType type, Arg[] args) : this(gAddr, lAddr, name, ~type, args) { }

    public GMethodData(nint gAddr, nint lAddr, string name, JGType type, Arg[] args) : this(gAddr, lAddr, name, ~type, args) { }

    public GMethodData(nint gAddr, nint lAddr, string name, TypeInfo info, Arg[] args) : base(gAddr, lAddr)
    {
        MethodName = name;
        Sig = SigGen.Method(info, args);
    }

    public GMethodData(nint gAddr, nint lAddr, string name, string sig) : base(gAddr, lAddr)
    {
        MethodName = name;
        Sig = sig;
    }

    public string MethodName;
    public string Sig;
}