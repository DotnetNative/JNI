using JNI.Core;
using Memory;

namespace JNI;
public sealed unsafe class NativeMethod
{
    public NativeMethod(string name, void* funcPtr, TypeInfo retType, params Arg[] args)
    {
        Name = name;
        Sig = SigGen.Method(retType, args);
        FuncPtr = funcPtr;
    }

    public NativeMethod(string name, void* funcPtr, TypeInfo retType, params TypeInfo[] args) : this(name, funcPtr, retType, args.ToArgs()) { }

    public NativeMethod(string name, nint funcAddr, TypeInfo retType, params Arg[] args) : this(name, funcAddr.ToPointer(), retType, args) { }

    public NativeMethod(string name, nint funcAddr, TypeInfo retType, params TypeInfo[] args) : this(name, funcAddr.ToPointer(), retType, args.ToArgs()) { }

    public readonly string Name;
    public readonly string Sig;
    public readonly void* FuncPtr;

    public NativeMethod_ ToStruct()
    {
        var nameCo = new CoMem(Name);
        nameCo.MarkAsDisposed();
        var sigCo = new CoMem(Sig);
        sigCo.MarkAsDisposed();
        return new(nameCo.Ptr, sigCo.Ptr, FuncPtr);
    }
}