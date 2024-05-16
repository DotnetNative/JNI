namespace JNI;
public unsafe class JType : JClass
{
    public JType(Handle handle, string name, string sig, int dim = 0) : base(handle) => Info = new TypeInfo(name, sig, dim);
    public JType(Handle handle, TypeInfo info) : base(handle) => Info = info;
    public JType(Handle handle, string nameAndSig, int dim = 0) : this(handle, nameAndSig, nameAndSig, dim) { }

    public TypeInfo Info;

    public static implicit operator Arg(JType type) => new Arg(type);
    public static implicit operator TypeInfo(JType type) => type.Info;
}