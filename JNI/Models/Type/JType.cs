namespace JNI;
public unsafe class JType : JClass
{
    public JType(Handle handle, string name, int dim = 0) : base(handle) => Info = new(name, dim);
    public JType(Handle handle, TypeInfo info) : base(handle) => Info = info;

    public TypeInfo Info;

    public static implicit operator Arg(JType type) => new(type);
    public static implicit operator TypeInfo(JType type) => type.Info;
}