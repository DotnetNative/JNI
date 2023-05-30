using JNI.Internal;
using JNI.Models.Local;

namespace JNI.Models.Global;
public class GHandle
{
    public GHandle(nint gAddr, nint lAddr)
    { 
        Addr = gAddr;
        LocalAddr = lAddr;
    }

    public nint Addr;
    public nint LocalAddr;

    public override string ToString() => $"{Addr.AsLetterHex('G')}/{LocalAddr.AsLetterHex('L')}";

    public bool IsDisposed;
    public void MarkAsDisposed() => IsDisposed = true;
    public void Dispose(Env env, bool bypass = false)
    {
        if (IsDisposed && !bypass)
            return;
        IsDisposed = true;

        env.DeleteGlobalRef(Addr);
        env.DeleteLocalRef(LocalAddr);
    }

    public LHandle ToLHandle(Env env)
    {
        env.DeleteGlobalRef(Addr);
        return new LHandle(env, LocalAddr);
    }

    public static nint operator !(GHandle obj) => obj.Addr;
}