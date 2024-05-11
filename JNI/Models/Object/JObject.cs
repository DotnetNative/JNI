namespace JNI;
/// <summary>
/// Contains handle of object implemented from java.lang.Object
/// </summary>
public unsafe abstract class JObject(EnvHandle handle) : HandleContainer(handle)
{
    public bool InstanceOf(JClass clazz) => Native->IsInstanceOf(Address, clazz);

    public LJClass GetClass() => new LJClass(LHandle.Create(Native->GetObjectClass(Address)));
    public GJClass GetGClass() => new GJClass(GHandle.Create(Native->GetObjectClass(Address)));

    /// <summary>
    /// Checks if object is null
    /// </summary>
    public new bool IsNull => Native->IsSameObject(this, nint.Zero);

    public java.lang.String this[JStringField field] { get => field.Get(this); set => field.Set(this, value); }

    public LJObject this[JObjectField field] { get => field.Get(this); set => field.Set(this, value); }

    public bool this[JBoolField field] { get => field.Get(this); set => field.Set(this, value); }

    public byte this[JByteField field] { get => field.Get(this); set => field.Set(this, value); }

    public char this[JCharField field] { get => field.Get(this); set => field.Set(this, value); }

    public short this[JShortField field] { get => field.Get(this); set => field.Set(this, value); }

    public int this[JIntField field] { get => field.Get(this); set => field.Set(this, value); }

    public long this[JLongField field] { get => field.Get(this); set => field.Set(this, value); }

    public float this[JFloatField field] { get => field.Get(this); set => field.Set(this, value); }

    public double this[JDoubleField field] { get => field.Get(this); set => field.Set(this, value); }

    #region Equals
    public static bool operator ==(JObject a, JObject b) => a.Native->IsSameObject(a, b);
    public static bool operator !=(JObject a, JObject b) => !a.Native->IsSameObject(a, b);

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

public unsafe class LJObject : JObject
{
    public LJObject(LHandle handle) : base(handle) => Handle = handle;

    public new LHandle Handle;

    public static LJObject Create(nint localAddress) => new LJObject(LHandle.Create(localAddress));
}

public unsafe class GJObject : JObject
{
    public GJObject(GHandle handle) : base(handle) => Handle = handle;

    public new GHandle Handle;

    public static GJObject Create(nint localAddress) => new GJObject(GHandle.Create(localAddress));
    public static GJObject Create(nint localAddress, nint globalAddress) => new GJObject(GHandle.Create(localAddress, globalAddress));
}