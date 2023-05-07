using JNI.Internal;
using JNI.Low;
using JNI.Models.Local;
using JNI.Utils;

namespace JNI.Models;
public sealed unsafe class NativeMethod
{
    public NativeMethod(string name, void* funcPtr, JType retType, params Arg[] args)
    {
        Name = name;
        Type = retType;
        Args = args;
        Sig = SigGen.Method(retType, args);
        FuncPtr = funcPtr;
    }

    public NativeMethod(string name, void* funcPtr, JType retType, params JType[] args) : this(name, funcPtr, retType, args.Select(a => (Arg)a).ToArray()) { }

    public NativeMethod(string name, IntPtr funcAddr, JType retType, params Arg[] args) : this(name, funcAddr.ToPointer(), retType, args) { }
    
    public NativeMethod(string name, IntPtr funcAddr, JType retType, params JType[] args) : this(name, funcAddr.ToPointer(), retType, args.Select(a => (Arg)a).ToArray()) { }

    public string Name { get; init; }
    public JType Type { get; init; }
    public Arg[] Args { get; init; }
    public string Sig { get; init; }
    public void* FuncPtr { get; init; }

    public NativeMethod_ AsStruct => new NativeMethod_(Name.UtfPtr(), Sig.UtfPtr(), FuncPtr);
}