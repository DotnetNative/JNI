namespace JNI;

/// <summary>
/// Contains address of jvm object, like <see cref="JObject"/>, <see cref="JField"/> and etc
/// </summary>
public unsafe abstract class Handle
{
    /// <summary>
    /// An address that represents where the object is stored. This is not necessarily a valid address, may be field or method descriptor
    /// </summary>
    public abstract nint Address { get; set; }

    protected private bool disposed;

    /// <summary>
    /// Checks if handle is null. This check can't be used for <see cref="JObject"/>
    /// </summary>
    public bool IsNull => Address == nint.Zero;

    public override string ToString() => $"{Address:X2}";

    public static implicit operator nint(Handle value) => value.Address;
    public static implicit operator void*(Handle value) => (void*)value.Address;
}