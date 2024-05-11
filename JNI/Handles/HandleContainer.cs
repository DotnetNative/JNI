using JNI.Core;

namespace JNI;
/// <summary>
/// Contains and implements handle of jvm object
/// </summary>
public abstract unsafe class HandleContainer : Handle, IDisposable
{
    public HandleContainer(EnvHandle handle) => Handle = handle;

    public EnvHandle Handle { get; init; }
    public bool IsGlobal => Handle is GHandle;

    public override nint Address { get => Handle.Address; set => Handle.Address = value; }
    public Env Env => Handle.Env;
    public Env_* Native => Handle.Native;

    public static implicit operator EnvHandle(HandleContainer value) => value.Handle;

    public void Dispose()
    {
        if (!disposed)
        {
            if (IsGlobal)
                (Handle as GHandle)!.Dispose();
        }        
    }

    ~HandleContainer() => Dispose();
}