namespace JNI;
/// <summary>
/// Contains handle of object implemented from java.lang.Object
/// </summary>
public unsafe abstract class JObject(EnvHandle handle) : HandleContainer(handle)
{
    public bool InstanceOf(JClass clazz) => Native->IsInstanceOf(Addr, clazz);

    public LJClass GetClass() => new LJClass(LHandle.Create(Native->GetObjectClass(Addr)));
    public GJClass GetGClass() => new GJClass(GHandle.Create(Native->GetObjectClass(Addr)));

    /// <summary>
    /// Checks if object is null
    /// </summary>
    public new bool IsNull => Native->IsSameObject(this, nint.Zero);

    public java.lang.String this[LJStringField field] { get => field.Get(this); set => field.Set(this, value); }
    public java.lang.String this[GJStringField field] { get => field.Get(this); set => field.Set(this, value); }

    public LJObject this[LJObjectField field] { get => field.Get(this); set => field.Set(this, value); }
    public LJObject this[GJObjectField field] { get => field.Get(this); set => field.Set(this, value); }

    public bool this[LJBoolField field] { get => field.Get(this); set => field.Set(this, value); }
    public bool this[GJBoolField field] { get => field.Get(this); set => field.Set(this, value); }

    public byte this[LJByteField field] { get => field.Get(this); set => field.Set(this, value); }
    public byte this[GJByteField field] { get => field.Get(this); set => field.Set(this, value); }

    public char this[LJCharField field] { get => field.Get(this); set => field.Set(this, value); }
    public char this[GJCharField field] { get => field.Get(this); set => field.Set(this, value); }

    public short this[LJShortField field] { get => field.Get(this); set => field.Set(this, value); }
    public short this[GJShortField field] { get => field.Get(this); set => field.Set(this, value); }

    public int this[LJIntField field] { get => field.Get(this); set => field.Set(this, value); }
    public int this[GJIntField field] { get => field.Get(this); set => field.Set(this, value); }

    public long this[LJLongField field] { get => field.Get(this); set => field.Set(this, value); }
    public long this[GJLongField field] { get => field.Get(this); set => field.Set(this, value); }

    public float this[LJFloatField field] { get => field.Get(this); set => field.Set(this, value); }
    public float this[GJFloatField field] { get => field.Get(this); set => field.Set(this, value); }

    public double this[LJDoubleField field] { get => field.Get(this); set => field.Set(this, value); }
    public double this[GJDoubleField field] { get => field.Get(this); set => field.Set(this, value); }

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

    public override int GetHashCode() => (int)Addr;
    #endregion
}

public unsafe class LJObject : JObject
{
    public LJObject(LHandle handle) : base(handle) => Handle = handle;

    public new LHandle Handle;

    public static LJObject Create(nint addr) => new LJObject(LHandle.Create(addr));
}

public unsafe class GJObject : JObject
{
    public GJObject(GHandle handle) : base(handle) => Handle = handle;

    public new GHandle Handle;

    public static GJObject Create(nint addr) => new GJObject(GHandle.Create(addr));
}