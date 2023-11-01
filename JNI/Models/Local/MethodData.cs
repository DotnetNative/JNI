using JNI.Utils;

namespace JNI.Models.Local;
public class MethodData : MethodHandle
{
    public MethodData(Env env, nint handle, string name, TypeInfo info, Arg[] args) : base(env, handle)
    {
        MethodName = name;
        Sig = SigGen.Method(info, args);
    }

    public MethodData(Env env, nint handle, string name, string sig) : base(env, handle)
    {
        MethodName = name;
        Sig = sig;
    }

    public string MethodName;
    public string Sig;
}