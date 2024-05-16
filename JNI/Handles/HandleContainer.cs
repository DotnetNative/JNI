namespace JNI;
public class HandleContainer : Handle, IDisposable
{
    public HandleContainer(Handle handle) => Handle = handle;

    public Handle Handle;

    public override nint LocalAddress => Handle.LocalAddress;

    public override nint Address => Handle.Address;

    public override bool IsDisposed => Handle.IsDisposed;

    #region IDisposable
    public void Dispose()
    {
        if (!IsDisposed)
            Handle.DisposeHandle();
    }

    public override void DisposeHandle() => Handle.DisposeHandle();

    ~HandleContainer() => Dispose();
    #endregion
}