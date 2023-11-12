namespace JNI;
public unsafe abstract class JField : JFieldInstance
{
    public JField(EnvHandle handle, string name, TypeInfo type) : base(handle, name, type) { }
}

public unsafe abstract class LJField : JField
{
    public LJField(LHandle handle, string name, TypeInfo type) : base(handle, name, type) { }
}

public unsafe abstract class GJField : JField
{
    public GJField(GHandle handle, string name, TypeInfo type) : base(handle, name, type) { }
}

public unsafe class LJStringField : LJField
{
    public LJStringField(LHandle handle, string name) : base(handle, name, handle.Env.Types.String) { }

    public java.lang.String Get(JObject obj) => new(LHandle.Create(Native->GetObjectField(obj, Addr)));
    public java.lang.String GetG(JObject obj) => new(GHandle.Create(Native->GetObjectField(obj, Addr)));
    public void Set(JObject obj, java.lang.String value) => Native->SetObjectField(obj, Addr, value);
}

public unsafe class GJStringField : GJField
{
    public GJStringField(GHandle handle, string name) : base(handle, name, handle.Env.Types.String) { }

    public java.lang.String Get(JObject obj) => new(LHandle.Create(Native->GetObjectField(obj, Addr)));
    public java.lang.String GetG(JObject obj) => new(GHandle.Create(Native->GetObjectField(obj, Addr)));
    public void Set(JObject obj, java.lang.String value) => Native->SetObjectField(obj, Addr, value);
}


public unsafe class LJObjectField : LJField
{
    public LJObjectField(LHandle handle, string name, TypeInfo type) : base(handle, name, type) { }

    public LJObject Get(JObject obj) => LJObject.Create(Native->GetObjectField(obj, Addr));
    public GJObject GetG(JObject obj) => GJObject.Create(Native->GetObjectField(obj, Addr));
    public void Set(JObject obj, JObject value) => Native->SetObjectField(obj, Addr, value);
}

public unsafe class GJObjectField : GJField
{
    public GJObjectField(GHandle handle, string name, TypeInfo type) : base(handle, name, type) { }

    public LJObject Get(JObject obj) => LJObject.Create(Native->GetObjectField(obj, Addr));
    public GJObject GetG(JObject obj) => GJObject.Create(Native->GetObjectField(obj, Addr));
    public void Set(JObject obj, JObject value) => Native->SetObjectField(obj, Addr, value);
}

public unsafe class LJBoolField : LJField
{
    public LJBoolField(LHandle handle, string name) : base(handle, name, handle.Env.Types.Bool) { }

    public bool Get(JObject obj) => Native->GetBooleanField(obj, Addr);
    public void Set(JObject obj, bool value) => Native->SetBooleanField(obj, Addr, value);
}

public unsafe class GJBoolField : GJField
{
    public GJBoolField(GHandle handle, string name) : base(handle, name, handle.Env.Types.Bool) { }

    public bool Get(JObject obj) => Native->GetBooleanField(obj, Addr);
    public void Set(JObject obj, bool value) => Native->SetBooleanField(obj, Addr, value);
}

public unsafe class LJByteField : LJField
{
    public LJByteField(LHandle handle, string name) : base(handle, name, handle.Env.Types.Byte) { }

    public byte Get(JObject obj) => Native->GetByteField(obj, Addr);
    public void Set(JObject obj, byte value) => Native->SetByteField(obj, Addr, value);
}

public unsafe class GJByteField : GJField
{
    public GJByteField(GHandle handle, string name) : base(handle, name, handle.Env.Types.Byte) { }

    public byte Get(JObject obj) => Native->GetByteField(obj, Addr);
    public void Set(JObject obj, byte value) => Native->SetByteField(obj, Addr, value);
}

public unsafe class LJCharField : LJField
{
    public LJCharField(LHandle handle, string name) : base(handle, name, handle.Env.Types.Char) { }

    public char Get(JObject obj) => Native->GetCharField(obj, Addr);
    public void Set(JObject obj, char value) => Native->SetCharField(obj, Addr, value);
}

public unsafe class GJCharField : GJField
{
    public GJCharField(GHandle handle, string name) : base(handle, name, handle.Env.Types.Char) { }

    public char Get(JObject obj) => Native->GetCharField(obj, Addr);
    public void Set(JObject obj, char value) => Native->SetCharField(obj, Addr, value);
}

public unsafe class LJShortField : LJField
{
    public LJShortField(LHandle handle, string name) : base(handle, name, handle.Env.Types.Short) { }

    public short Get(JObject obj) => Native->GetShortField(obj, Addr);
    public void Set(JObject obj, short value) => Native->SetShortField(obj, Addr, value);
}

public unsafe class GJShortField : GJField
{
    public GJShortField(GHandle handle, string name) : base(handle, name, handle.Env.Types.Short) { }

    public short Get(JObject obj) => Native->GetShortField(obj, Addr);
    public void Set(JObject obj, short value) => Native->SetShortField(obj, Addr, value);
}

public unsafe class LJIntField : LJField
{
    public LJIntField(LHandle handle, string name) : base(handle, name, handle.Env.Types.Int) { }

    public int Get(JObject obj) => Native->GetIntField(obj, Addr);
    public void Set(JObject obj, int value) => Native->SetIntField(obj, Addr, value);
}

public unsafe class GJIntField : GJField
{
    public GJIntField(GHandle handle, string name) : base(handle, name, handle.Env.Types.Int) { }

    public int Get(JObject obj) => Native->GetIntField(obj, Addr);
    public void Set(JObject obj, int value) => Native->SetIntField(obj, Addr, value);
}

public unsafe class LJLongField : LJField
{
    public LJLongField(LHandle handle, string name) : base(handle, name, handle.Env.Types.Long) { }

    public long Get(JObject obj) => Native->GetLongField(obj, Addr);
    public void Set(JObject obj, long value) => Native->SetLongField(obj, Addr, value);
}

public unsafe class GJLongField : GJField
{
    public GJLongField(GHandle handle, string name) : base(handle, name, handle.Env.Types.Long) { }

    public long Get(JObject obj) => Native->GetLongField(obj, Addr);
    public void Set(JObject obj, long value) => Native->SetLongField(obj, Addr, value);
}

public unsafe class LJFloatField : LJField
{
    public LJFloatField(LHandle handle, string name) : base(handle, name, handle.Env.Types.Float) { }

    public float Get(JObject obj) => Native->GetFloatField(obj, Addr);
    public void Set(JObject obj, float value) => Native->SetFloatField(obj, Addr, value);
}

public unsafe class GJFloatField : GJField
{
    public GJFloatField(GHandle handle, string name) : base(handle, name, handle.Env.Types.Float) { }

    public float Get(JObject obj) => Native->GetFloatField(obj, Addr);
    public void Set(JObject obj, float value) => Native->SetFloatField(obj, Addr, value);
}

public unsafe class LJDoubleField : LJField
{
    public LJDoubleField(LHandle handle, string name) : base(handle, name, handle.Env.Types.Double) { }

    public double Get(JObject obj) => Native->GetDoubleField(obj, Addr);
    public void Set(JObject obj, double value) => Native->SetDoubleField(obj, Addr, value);
}

public unsafe class GJDoubleField : GJField
{
    public GJDoubleField(GHandle handle, string name) : base(handle, name, handle.Env.Types.Double) { }

    public double Get(JObject obj) => Native->GetDoubleField(obj, Addr);
    public void Set(JObject obj, double value) => Native->SetDoubleField(obj, Addr, value);
}