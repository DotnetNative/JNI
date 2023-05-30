using JNI.Models.Weak;

namespace JNI.Models.Global;
public unsafe sealed class JGType : GClassHandle
{
    public JGType(nint gAddr, nint lAddr, string name, string sig, int dim = 0) : base(gAddr, lAddr)
        => Info = new(name, sig, dim);

    public JGType(nint gAddr, nint lAddr, string nameAndSig, int dim = 0) : this(gAddr, lAddr, nameAndSig, nameAndSig)
        => Info = new(nameAndSig, nameAndSig, dim);

    public JGType(nint gAddr, nint lAddr, TypeInfo info) : this(gAddr, lAddr, info.Name, info.Sig)
        => Info = info;

    public TypeInfo Info;

    public new WeakJType AsWeak(Env env) => new(env, Addr, Info);
    public WeakClassHandle AsWeakClassHandle(Env env) => base.AsWeak(env);

    public static explicit operator Arg(JGType type) => new(type.Info.Sig);
    public static explicit operator TypeInfo(JGType type) => type.Info;
    public static TypeInfo operator ~(JGType type) => type.Info;
}