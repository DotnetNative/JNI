using Memory;
using System.Runtime.InteropServices;

namespace JNI.Core;


public unsafe struct NativeMethod_ : IDisposable
{
    public NativeMethod_(byte* name, byte* signature, byte* fnPtr)
    {
        Name = name;
        Signature = signature;
        FnPtr = fnPtr;
    }

    public byte* Name;
    public byte* Signature;
    public byte* FnPtr;

    public void Dispose() => MemEx.Free(Name, Signature);
}