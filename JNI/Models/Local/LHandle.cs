using JNI.Internal;

namespace JNI.Models.Local;
public unsafe class LHandle : IDisposable
{
    public LHandle(Env env, nint handle)
    {
        Env = env;
        Addr = handle;
    }

    public Env Env;
    public nint Addr;

    public static explicit operator nint(LHandle obj) => obj.Addr;

    public override string ToString() => Addr.AsLetterHex('L');

    public bool IsDisposed;
    public void MarkAsDisposed() => IsDisposed = true;
    public void Dispose() => Dispose(false);

    public void Dispose(bool bypass)
    {
        if (IsDisposed && !bypass)
            return;

        IsDisposed = true;

        Env.Master->DeleteLocalRef(Addr);
    }

    public static nint operator !(LHandle obj) => obj.Addr;
}