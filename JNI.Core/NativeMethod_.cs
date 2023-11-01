using System.Runtime.InteropServices;

namespace JNI.Core;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct NativeMethod_ : IDisposable
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

    public void Dispose()
    {
        Marshal.FreeCoTaskMem((nint)Name);
        Marshal.FreeCoTaskMem((nint)Signature);
    }
}