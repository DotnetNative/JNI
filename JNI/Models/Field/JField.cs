namespace JNI;

public abstract class JField(EnvHandle handle, string name, TypeInfo type) : JFieldInstance(handle, name, type);
public abstract class LJField(LHandle handle, string name, TypeInfo type) : JField(handle, name, type);
public abstract class GJField(GHandle handle, string name, TypeInfo type) : JField(handle, name, type);

public unsafe class LJStringField : LJField
{
    public LJStringField(LHandle handle, string name) : base(handle, name, handle.Env.Types.String) { }

    public java.lang.String Get(JObject obj) => new(LHandle.Create(Native->GetObjectField(obj, Addr)));
    public java.lang.String GetG(JObject obj) => new(GHandle.Create(Native->GetObjectField(obj, Addr)));
    public void Set(JObject obj, java.lang.String value) => Native->SetObjectField(obj, Addr, value);
}

public unsafe class GJStringField(GHandle handle, string name) : GJField(handle, name, handle.Env.Types.String)
{
    public java.lang.String Get(JObject obj) => new(LHandle.Create(Native->GetObjectField(obj, Addr)));
    public java.lang.String GetG(JObject obj) => new(GHandle.Create(Native->GetObjectField(obj, Addr)));
    public void Set(JObject obj, java.lang.String value) => Native->SetObjectField(obj, Addr, value);
}

public unsafe class LJObjectField(LHandle handle, string name, TypeInfo type) : LJField(handle, name, type)
{
    public LJObject Get(JObject obj) => LJObject.Create(Native->GetObjectField(obj, Addr));
    public GJObject GetG(JObject obj) => GJObject.Create(Native->GetObjectField(obj, Addr));
    public void Set(JObject obj, JObject value) => Native->SetObjectField(obj, Addr, value);
}

public unsafe class GJObjectField(GHandle handle, string name, TypeInfo type) : GJField(handle, name, type)
{
    public LJObject Get(JObject obj) => LJObject.Create(Native->GetObjectField(obj, Addr));
    public GJObject GetG(JObject obj) => GJObject.Create(Native->GetObjectField(obj, Addr));
    public void Set(JObject obj, JObject value) => Native->SetObjectField(obj, Addr, value);
}

public unsafe class LJBoolField(LHandle handle, string name) : LJField(handle, name, handle.Env.Types.Bool)
{
    public bool Get(JObject obj) => Native->GetBooleanField(obj, Addr);
    public void Set(JObject obj, bool value) => Native->SetBooleanField(obj, Addr, value);
}

public unsafe class GJBoolField(GHandle handle, string name) : GJField(handle, name, handle.Env.Types.Bool)
{
    public bool Get(JObject obj) => Native->GetBooleanField(obj, Addr);
    public void Set(JObject obj, bool value) => Native->SetBooleanField(obj, Addr, value);
}

public unsafe class LJByteField(LHandle handle, string name) : LJField(handle, name, handle.Env.Types.Byte)
{
    public byte Get(JObject obj) => Native->GetByteField(obj, Addr);
    public void Set(JObject obj, byte value) => Native->SetByteField(obj, Addr, value);
}

public unsafe class GJByteField(GHandle handle, string name) : GJField(handle, name, handle.Env.Types.Byte)
{
    public byte Get(JObject obj) => Native->GetByteField(obj, Addr);
    public void Set(JObject obj, byte value) => Native->SetByteField(obj, Addr, value);
}

public unsafe class LJCharField(LHandle handle, string name) : LJField(handle, name, handle.Env.Types.Char)
{
    public char Get(JObject obj) => Native->GetCharField(obj, Addr);
    public void Set(JObject obj, char value) => Native->SetCharField(obj, Addr, value);
}

public unsafe class GJCharField(GHandle handle, string name) : GJField(handle, name, handle.Env.Types.Char)
{
    public char Get(JObject obj) => Native->GetCharField(obj, Addr);
    public void Set(JObject obj, char value) => Native->SetCharField(obj, Addr, value);
}

public unsafe class LJShortField(LHandle handle, string name) : LJField(handle, name, handle.Env.Types.Short)
{
    public short Get(JObject obj) => Native->GetShortField(obj, Addr);
    public void Set(JObject obj, short value) => Native->SetShortField(obj, Addr, value);
}

public unsafe class GJShortField(GHandle handle, string name) : GJField(handle, name, handle.Env.Types.Short)
{
    public short Get(JObject obj) => Native->GetShortField(obj, Addr);
    public void Set(JObject obj, short value) => Native->SetShortField(obj, Addr, value);
}

public unsafe class LJIntField(LHandle handle, string name) : LJField(handle, name, handle.Env.Types.Int)
{
    public int Get(JObject obj) => Native->GetIntField(obj, Addr);
    public void Set(JObject obj, int value) => Native->SetIntField(obj, Addr, value);
}

public unsafe class GJIntField(GHandle handle, string name) : GJField(handle, name, handle.Env.Types.Int)
{
    public int Get(JObject obj) => Native->GetIntField(obj, Addr);
    public void Set(JObject obj, int value) => Native->SetIntField(obj, Addr, value);
}

public unsafe class LJLongField(LHandle handle, string name) : LJField(handle, name, handle.Env.Types.Long)
{
    public long Get(JObject obj) => Native->GetLongField(obj, Addr);
    public void Set(JObject obj, long value) => Native->SetLongField(obj, Addr, value);
}

public unsafe class GJLongField(GHandle handle, string name) : GJField(handle, name, handle.Env.Types.Long)
{
    public long Get(JObject obj) => Native->GetLongField(obj, Addr);
    public void Set(JObject obj, long value) => Native->SetLongField(obj, Addr, value);
}

public unsafe class LJFloatField(LHandle handle, string name) : LJField(handle, name, handle.Env.Types.Float)
{
    public float Get(JObject obj) => Native->GetFloatField(obj, Addr);
    public void Set(JObject obj, float value) => Native->SetFloatField(obj, Addr, value);
}

public unsafe class GJFloatField(GHandle handle, string name) : GJField(handle, name, handle.Env.Types.Float)
{
    public float Get(JObject obj) => Native->GetFloatField(obj, Addr);
    public void Set(JObject obj, float value) => Native->SetFloatField(obj, Addr, value);
}

public unsafe class LJDoubleField(LHandle handle, string name) : LJField(handle, name, handle.Env.Types.Double)
{
    public double Get(JObject obj) => Native->GetDoubleField(obj, Addr);
    public void Set(JObject obj, double value) => Native->SetDoubleField(obj, Addr, value);
}

public unsafe class GJDoubleField(GHandle handle, string name) : GJField(handle, name, handle.Env.Types.Double)
{
    public double Get(JObject obj) => Native->GetDoubleField(obj, Addr);
    public void Set(JObject obj, double value) => Native->SetDoubleField(obj, Addr, value);
}

public unsafe class LJEnumField<T> : LJField where T : struct, Enum
{
    public LJEnumField(LHandle handle, string name, JEnum<T> type) : base(handle, name, type) => EnumType = type;

    public JEnum<T> EnumType;

    public java.lang.Enum<T> Get(JObject obj)
    {
        using var data = LJObject.Create(Native->GetObjectField(obj, Addr));
        return EnumType[data];
    }
    public void Set(JObject obj, java.lang.Enum<T> value) => Native->SetObjectField(obj, Addr, value);
}

public unsafe class GJEnumField<T> : GJField where T : struct, Enum
{
    public GJEnumField(GHandle handle, string name, JEnum<T> type) : base(handle, name, type) => EnumType = type;

    public JEnum<T> EnumType;

    public java.lang.Enum<T> Get(JObject obj)
    {
        using var data = LJObject.Create(Native->GetObjectField(obj, Addr));
        return EnumType[data];
    }
    public void Set(JObject obj, java.lang.Enum<T> value) => Native->SetObjectField(obj, Addr, value);
}