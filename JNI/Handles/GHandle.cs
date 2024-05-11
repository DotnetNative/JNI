namespace JNI;

/// <summary>
/// Typedefining <see cref="EnvHandle"/>. Indicates that handle is global.
/// </summary>
public unsafe class GHandle : EnvHandle, IDisposable
{
    public GHandle(nint localAddress, nint globalAddress)
    {
        this.localAddress = localAddress;
        this.globalAddress = globalAddress;
    }

    nint localAddress;
    nint globalAddress;

    public override nint Address { get => globalAddress; set => globalAddress = value; }

    public override Env Env => Env.ThreadEnv;

    /// <summary>
    /// Creates new instance from local addr
    /// </summary>
    public static GHandle Create(nint localAddress)
    {
        var globalAddress = Env.ThreadNativeEnv->NewGlobalRef(localAddress);
        return new(localAddress, globalAddress);
    }

    /// <summary>
    /// Creates new instance from local and global addr
    /// </summary>
    public static GHandle Create(nint localAddress, nint globalAddress) => new(localAddress, globalAddress);

    public void Dispose()
    {
        if (!disposed)
        {
            disposed = true;
            var e = Native;
            e->DeleteGlobalRef(globalAddress);
            e->DeleteLocalRef(localAddress);
        }
    }

    ~GHandle() => Dispose();
}