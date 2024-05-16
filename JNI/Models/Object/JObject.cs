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

    public JString this[JStringField field] { get => field.Get(this); set => field.Set(this, value); }
    public JObject this[JObjectField field] { get => field.Get(this); set => field.Set(this, value); }
    public bool this[JBoolField field] { get => field.Get(this); set => field.Set(this, value); }
    public byte this[JByteField field] { get => field.Get(this); set => field.Set(this, value); }
    public char this[JCharField field] { get => field.Get(this); set => field.Set(this, value); }
    public short this[JShortField field] { get => field.Get(this); set => field.Set(this, value); }
    public int this[JIntField field] { get => field.Get(this); set => field.Set(this, value); }
    public long this[JLongField field] { get => field.Get(this); set => field.Set(this, value); }
    public float this[JFloatField field] { get => field.Get(this); set => field.Set(this, value); }
    public double this[JDoubleField field] { get => field.Get(this); set => field.Set(this, value); }

    public static JObject Create(nint localAddress) => new(HandleImpl.Create(localAddress));
    public static JObject Create(nint localAddress, nint globalAddress) => new(HandleImpl.Create(localAddress, globalAddress));

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