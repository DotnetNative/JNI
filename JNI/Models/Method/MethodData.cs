namespace JNI;
public class MethodData : MethodHandle
{
    public MethodData(EnvHandle handle, string name, TypeInfo info, Arg[] args) : base(handle)
    {
        MethodName = name;
        ReturnType = info;
        Signature = SigGen.Method(info, args);
    }

    public readonly string MethodName;
    public readonly string Signature;
    public readonly TypeInfo ReturnType;
}