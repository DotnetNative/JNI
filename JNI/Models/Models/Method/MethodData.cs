using JNI.Models;
using JNI.Models.Handles;
using JNI.Models.Models;
using JNI.Models.Models.Type;

namespace JNI.Models.Models.Method;
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