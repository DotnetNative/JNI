namespace JNI;
/// <summary>
/// Contains local address and global of jvm object, like <see cref="JObject"/>, <see cref="JField"/> and etc
/// </summary>
public unsafe class HandleImpl : Handle, IDisposable
{
    public HandleImpl(nint localAddress, nint globalAddress)
    {
        this.localAddress = localAddress;
        this.globalAddress = globalAddress;
    }

    nint localAddress;
    nint globalAddress;

    /// <summary>
    /// An local address that represents where the object is stored. This is not necessarily a valid address
    /// </summary>
    public override nint LocalAddress => localAddress;
    /// <summary>
    /// An global address that represents where the object is stored. This is not necessarily a valid address
    /// </summary>
    public override nint Address => globalAddress;

    /// <summary>
    /// Creates new instance from local addr
    /// </summary>
    public static HandleImpl Create(nint localAddress)
    {
        var globalAddress = env_->NewGlobalRef(localAddress);
        var handle = new HandleImpl(localAddress, globalAddress);
        HandleController.InvokeOnCreate(handle);
        return handle;
    }

    /// <summary>
    /// Creates new instance from local and global addr
    /// </summary>
    public static HandleImpl Create(nint localAddress, nint globalAddress)
    {
        var handle = new HandleImpl(localAddress, globalAddress);
        HandleController.InvokeOnCreate(handle);
        return handle;
    }

    public override bool IsDisposed => disposed;

    #region IDisposable
    bool disposed;
    public void Dispose()
    {
        if (disposed)
            return;

        disposed = true;
        HandleController.InvokeOnDispose(this);

        var e = env_;
        e->DeleteGlobalRef(globalAddress);
        if (localAddress != 0)
            e->DeleteLocalRef(localAddress);

        GC.SuppressFinalize(this);
    }

    public override void DisposeHandle() => Dispose();

    ~HandleImpl() => Dispose();
    #endregion

    public static implicit operator nint(HandleImpl value) => value.globalAddress;
    public static implicit operator void*(HandleImpl value) => (void*)value.globalAddress;
}