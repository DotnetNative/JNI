namespace JNI.Models.Local;
public unsafe class JType : ClassHandle
{
    public JType(Env env, nint handle, string name, string sig, int dim = 0) : base(env, handle) => Info = new TypeInfo(name, sig, dim);
    public JType(Env env, nint handle, TypeInfo info) : base(env, handle) => Info = info;
    public JType(Env env, nint handle, string nameAndSig, int dim = 0) : this(env, handle, nameAndSig, nameAndSig, dim) { }
    public JType(Env env, TypeInfo info) : this(env, info.Name, info.Sig, info.Dim) { }
    public JType(Env env, string name, string sig, int dim = 0) : base(env, env.GetClassHandle(name)) => Info = new TypeInfo(name, sig, dim);
    public JType(Env env, string nameAndSig, int dim = 0) : this(env, nameAndSig, nameAndSig, dim) { }

    public TypeInfo Info;

    public static explicit operator Arg(JType type) => new Arg(type.Info.Sig);
    public static explicit operator TypeInfo(JType type) => type.Info;
    public static TypeInfo operator ~(JType type) => type.Info;
}