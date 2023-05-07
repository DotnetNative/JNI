using System.Runtime.InteropServices;

namespace JNI.Low;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct NativeMethod_
{
    public NativeMethod_(byte* name, byte* signature, void* fnPtr)
    {
        Name = name;
        Signature = signature;
        FnPtr = fnPtr;
    }

    public byte* Name;
    public byte* Signature;
    public void* FnPtr;
}