using System.Runtime.InteropServices;

namespace JNI.Internal;
internal sealed unsafe class CoMem : IDisposable
{
    public CoMem(string str, CoStrType charSet = CoStrType.Utf8)
        => Alloc(str, charSet);

    private void Alloc(string str, CoStrType charSet)
    {
        if (charSet == CoStrType.Utf8)
            Ptr = (byte*)Marshal.StringToCoTaskMemUTF8(str);
        else if (charSet == CoStrType.Ansi)
            Ptr = (byte*)Marshal.StringToCoTaskMemAnsi(str);
        else if (charSet == CoStrType.Auto)
            Ptr = (byte*)Marshal.StringToCoTaskMemAuto(str);
        else Ptr = (byte*)Marshal.StringToCoTaskMemUni(str);
    }

    public byte* Ptr;

    public void MarkAsDisposed() => isDisposed = true;

    private bool isDisposed;
    public void Dispose()
    {
        if (isDisposed)
            return;
        isDisposed = true;

        Marshal.FreeCoTaskMem((nint)Ptr);
        GC.SuppressFinalize(this);
    }

    public static byte* operator !(CoMem obj) => obj.Ptr;

    ~CoMem() => Dispose();
}

internal sealed unsafe class CoMem<T> : IDisposable where T : unmanaged
{
    public CoMem(T obj) => Ptr = obj.Pin();

    public CoMem(T[] arr) => Ptr = arr.Pin();

    public T* Ptr;

    private bool isDisposed;
    public void Dispose()
    {
        if (isDisposed)
            return;
        isDisposed = true;

        Marshal.FreeCoTaskMem((nint)Ptr);
        GC.SuppressFinalize(this);
    }

    public static T* operator !(CoMem<T> obj) => obj.Ptr;

    ~CoMem() => Dispose();
}