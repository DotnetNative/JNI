namespace JNI;
public abstract class JMethodInstance : MethodData
{
    public JMethodInstance(MethodDescriptor descriptor, string name, TypeInfo type, JClass clazz, params Arg[] args) : base(descriptor, name, type, args) => Class = clazz;

    public readonly JClass Class;
}