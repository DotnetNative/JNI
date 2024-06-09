namespace JNI;
public delegate void OnCreateDelegateHandle(Handle handle);
public unsafe abstract class Handle
{
    public abstract nint LocalAddress { get; }
    public abstract nint Address { get; }
    public abstract bool IsDisposed { get; }
    public abstract void DisposeHandle();

    /// <summary>
    /// Checks if handle is null. This check can't be used for <see cref="JObject"/>
    /// </summary>
    public bool IsNull => Address == nint.Zero;

    public override string ToString() => $"{(pointer)Address}";

    public static implicit operator nint(Handle value) => value.Address;
    public static implicit operator void*(Handle value) => (void*)value.Address;
}

public static class HandleController
{
    public static event OnCreateDelegateHandle? OnCreate;
    public static event OnCreateDelegateHandle? OnDispose;

    public static void InvokeOnCreate(Handle handle) => OnCreate?.Invoke(handle);
    public static void InvokeOnDispose(Handle handle) => OnDispose?.Invoke(handle);
}