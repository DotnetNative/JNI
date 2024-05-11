namespace JNI;

public abstract class JField(EnvHandle handle, string name, TypeInfo type) : JFieldInstance(handle, name, type);

public unsafe class JStringField : JField
{
    public JStringField(LHandle handle, string name) : base(handle, name, handle.Env.Types.String) { }

    public java.lang.String Get(JObject obj) => new(LHandle.Create(Native->GetObjectField(obj, Address)));
    public java.lang.String GetG(JObject obj) => new(GHandle.Create(Native->GetObjectField(obj, Address)));
    public void Set(JObject obj, java.lang.String value) => Native->SetObjectField(obj, Address, value);
}

public unsafe class JObjectField(LHandle handle, string name, TypeInfo type) : JField(handle, name, type)
{
    public LJObject Get(JObject obj) => LJObject.Create(Native->GetObjectField(obj, Address));
    public GJObject GetG(JObject obj) => GJObject.Create(Native->GetObjectField(obj, Address));
    public void Set(JObject obj, JObject value) => Native->SetObjectField(obj, Address, value);
}

public unsafe class JBoolField(LHandle handle, string name) : JField(handle, name, handle.Env.Types.Bool)
{
    public bool Get(JObject obj) => Native->GetBooleanField(obj, Address);
    public void Set(JObject obj, bool value) => Native->SetBooleanField(obj, Address, value);
}

public unsafe class JByteField(LHandle handle, string name) : JField(handle, name, handle.Env.Types.Byte)
{
    public byte Get(JObject obj) => Native->GetByteField(obj, Address);
    public void Set(JObject obj, byte value) => Native->SetByteField(obj, Address, value);
}

public unsafe class JCharField(LHandle handle, string name) : JField(handle, name, handle.Env.Types.Char)
{
    public char Get(JObject obj) => Native->GetCharField(obj, Address);
    public void Set(JObject obj, char value) => Native->SetCharField(obj, Address, value);
}

public unsafe class JShortField(LHandle handle, string name) : JField(handle, name, handle.Env.Types.Short)
{
    public short Get(JObject obj) => Native->GetShortField(obj, Address);
    public void Set(JObject obj, short value) => Native->SetShortField(obj, Address, value);
}

public unsafe class JIntField(LHandle handle, string name) : JField(handle, name, handle.Env.Types.Int)
{
    public int Get(JObject obj) => Native->GetIntField(obj, Address);
    public void Set(JObject obj, int value) => Native->SetIntField(obj, Address, value);
}

public unsafe class JLongField(LHandle handle, string name) : JField(handle, name, handle.Env.Types.Long)
{
    public long Get(JObject obj) => Native->GetLongField(obj, Address);
    public void Set(JObject obj, long value) => Native->SetLongField(obj, Address, value);
}

public unsafe class JFloatField(LHandle handle, string name) : JField(handle, name, handle.Env.Types.Float)
{
    public float Get(JObject obj) => Native->GetFloatField(obj, Address);
    public void Set(JObject obj, float value) => Native->SetFloatField(obj, Address, value);
}

public unsafe class JDoubleField(LHandle handle, string name) : JField(handle, name, handle.Env.Types.Double)
{
    public double Get(JObject obj) => Native->GetDoubleField(obj, Address);
    public void Set(JObject obj, double value) => Native->SetDoubleField(obj, Address, value);
}

public unsafe class JEnumField<T> : JField where T : struct, Enum
{
    public JEnumField(LHandle handle, string name, JEnum<T> type) : base(handle, name, type) => EnumType = type;

    public JEnum<T> EnumType;

    public java.lang.Enum<T> Get(JObject obj)
    {
        using var data = LJObject.Create(Native->GetObjectField(obj, Address));
        return EnumType[data];
    }
    public void Set(JObject obj, java.lang.Enum<T> value) => Native->SetObjectField(obj, Address, value);
}