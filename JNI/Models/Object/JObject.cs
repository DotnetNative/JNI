namespace JNI;
public unsafe abstract class JObject : HandleContainer
{
    public JObject(EnvHandle handle) : base(handle) { }

    public bool IsNull => Addr == nint.Zero;
    public bool InstanceOf(JClass clazz) => Native->IsInstanceOf(Addr, clazz);

    public LJClass GetClass() => new LJClass(LHandle.Create(Native->GetObjectClass(Addr)));
    public GJClass GetGClass() => new GJClass(GHandle.Create(Native->GetObjectClass(Addr)));

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
    public LJObject(LHandle handle) : base(handle) { }

    public static LJObject Create(nint addr) => new LJObject(LHandle.Create(addr));
}

public unsafe class GJObject : JObject
{
    public GJObject(GHandle handle) : base(handle) { }

    public static GJObject Create(nint addr) => new GJObject(GHandle.Create(addr));
}