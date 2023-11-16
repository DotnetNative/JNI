namespace JNI;

/// <summary>
/// Typedefining <see cref="EnvHandle"/>. Indicates that handle is local and can only be used in thread in which was created
/// </summary>
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

    /// <summary>
    /// Creates new instance from local addr
    /// </summary>
    public static LHandle Create(nint addr) => new(addr);

    public void Dispose()
    {
        Native->DeleteLocalRef(localAddr);
    }
}