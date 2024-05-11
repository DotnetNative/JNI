namespace JNI;

/// <summary>
/// Typedefining <see cref="EnvHandle"/>. Indicates that handle is local and can only be used in thread in which was created
/// </summary>
public unsafe class LHandle : EnvHandle, IDisposable
{
    public LHandle(nint address) => localAddress = address;

    nint localAddress;

    public override nint Address { get => localAddress; set => localAddress = value; }

    Env env = Env.ThreadEnv;
    public override Env Env => env;

    /// <summary>
    /// Creates new instance from local addr
    /// </summary>
    public static LHandle Create(nint addr) => new(addr);

    public void Dispose()
    {
        if (!disposed)
        {
            disposed = true;

            // Pseudo check that it's not a field/method descriptor
            if (Address > short.MaxValue)
            {
                Native->DeleteLocalRef(localAddress);
            }
        }
    }

    ~LHandle() => Dispose();
}