namespace JNI;
/// <summary>
/// Contains handle of object implemented from java.lang.Object
/// </summary>
public unsafe class JObject(Handle handle) : HandleContainer(handle)
{
    public bool InstanceOf(JClass clazz) => env_->IsInstanceOf(Address, clazz);

    public JClass GetClass() => new JClass(HandleImpl.Create(env_->GetObjectClass(Address)));

    /// <summary>
    /// Checks if object is null
    /// </summary>
    public new bool IsNull => Handle.IsNull || env_->IsSameObject(this, nint.Zero);

    #region Equals
    public static bool operator ==(JObject a, JObject b) => env_->IsSameObject(a, b);
    public static bool operator !=(JObject a, JObject b) => !env_->IsSameObject(a, b);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (ReferenceEquals(obj, null))
            return false;

        return false;
    }

    public override int GetHashCode() => (int)Address;
    #endregion
}

public static class JObjectImpl
{
    public static JObject Create(nint localAddress) => new(HandleImpl.Create(localAddress));
    public static JObject Create(nint localAddress, nint globalAddress) => new(HandleImpl.Create(localAddress, globalAddress));
}