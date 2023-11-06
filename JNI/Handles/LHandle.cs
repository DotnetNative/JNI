namespace JNI;
public unsafe class LHandle : EnvHandle, IDisposable
{
    public LHandle(nint addr)
    {
        localAddr = addr;
    }

    nint localAddr;

    public override nint Addr { get => localAddr; set => localAddr = value; }

    Env env = Env.ThreadEnv;
    public override Env Env => env;

    public static LHandle Create(nint addr) => new(addr);

    public void Dispose()
    {
        Native->DeleteLocalRef(localAddr);
    }
}