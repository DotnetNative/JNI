namespace JNI;
public sealed unsafe class NativeMethod
{
    public NativeMethod(string name, pointer functionPointer, TypeInfo retType, params Arg[] args)
    {
        Name = name;
        Sig = SigGen.Method(retType, args);
        FunctionPointer = functionPointer;
    }
    public NativeMethod(string name, pointer functionPointer, TypeInfo retType, params TypeInfo[] args) : this(name, functionPointer, retType, args.ToArgs()) { }

    public readonly string Name;
    public readonly string Sig;
    public readonly pointer FunctionPointer;

    public NativeMethod_ ToStruct()
    {
        var nameCo = new CoMem(Name);
        nameCo.MarkAsDisposed();
        var sigCo = new CoMem(Sig);
        sigCo.MarkAsDisposed();

        return new(nameCo, sigCo, FunctionPointer);
    }
}