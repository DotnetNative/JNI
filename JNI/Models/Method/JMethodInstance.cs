namespace JNI;
public abstract class JMethodInstance : MethodData
{
    public JMethodInstance(EnvHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : base(handle, name, type, args) => Clazz = clazz;

    public readonly JClass Clazz;
}