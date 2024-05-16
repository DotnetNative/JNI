namespace JNI;
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

    public delegate void OnCreateDelegate(Handle handle);
    public static event OnCreateDelegate? OnCreate;
    public static event OnCreateDelegate? OnDispose;

    public override string ToString() => $"{Address:X}";

    internal static void InvokeOnCreate(Handle handle) => OnCreate?.Invoke(handle);
    internal static void InvokeOnDispose(Handle handle) => OnDispose?.Invoke(handle);

    public static implicit operator nint(Handle value) => value.Address;
    public static implicit operator void*(Handle value) => (void*)value.Address;
}

public static class HandleController
{
    public static void InvokeOnCreate(Handle handle) => Handle.InvokeOnCreate(handle);
    public static void InvokeOnDispose(Handle handle) => Handle.InvokeOnDispose(handle);
}