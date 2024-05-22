namespace JNI;
public abstract class JField(FieldDescriptor descriptor, string name, TypeInfo type) : JFieldInstance(descriptor, name, type);

public unsafe class JStringField : JField
{
    public JStringField(FieldDescriptor descriptor, string name) : base(descriptor, name, Types.String) { }

    public JString Get(JObject obj) => new(HandleImpl.Create(env_->GetObjectField(obj, Descriptor)));
    public void Set(JObject obj, JString value) => env_->SetObjectField(obj, Descriptor, value);
}

public unsafe class JObjectField(FieldDescriptor descriptor, string name, TypeInfo type) : JField(descriptor, name, type)
{
    public JObject Get(JObject obj) => JObject.Create(env_->GetObjectField(obj, Descriptor));
    public void Set(JObject obj, JObject value) => env_->SetObjectField(obj, Descriptor, value);
}

public unsafe class JBoolField(FieldDescriptor descriptor, string name) : JField(descriptor, name, Types.Bool)
{
    public bool Get(JObject obj) => env_->GetBooleanField(obj, Descriptor);
    public void Set(JObject obj, bool value) => env_->SetBooleanField(obj, Descriptor, value);
}

public unsafe class JByteField(FieldDescriptor descriptor, string name) : JField(descriptor, name, Types.Byte)
{
    public byte Get(JObject obj) => env_->GetByteField(obj, Descriptor);
    public void Set(JObject obj, byte value) => env_->SetByteField(obj, Descriptor, value);
}

public unsafe class JCharField(FieldDescriptor descriptor, string name) : JField(descriptor, name, Types.Char)
{
    public char Get(JObject obj) => env_->GetCharField(obj, Descriptor);
    public void Set(JObject obj, char value) => env_->SetCharField(obj, Descriptor, value);
}

public unsafe class JShortField(FieldDescriptor descriptor, string name) : JField(descriptor, name, Types.Short)
{
    public short Get(JObject obj) => env_->GetShortField(obj, Descriptor);
    public void Set(JObject obj, short value) => env_->SetShortField(obj, Descriptor, value);
}

public unsafe class JIntField(FieldDescriptor descriptor, string name) : JField(descriptor, name, Types.Int)
{
    public int Get(JObject obj) => env_->GetIntField(obj, Descriptor);
    public void Set(JObject obj, int value) => env_->SetIntField(obj, Descriptor, value);
}

public unsafe class JLongField(FieldDescriptor descriptor, string name) : JField(descriptor, name, Types.Long)
{
    public long Get(JObject obj) => env_->GetLongField(obj, Descriptor);
    public void Set(JObject obj, long value) => env_->SetLongField(obj, Descriptor, value);
}

public unsafe class JFloatField(FieldDescriptor descriptor, string name) : JField(descriptor, name, Types.Float)
{
    public float Get(JObject obj) => env_->GetFloatField(obj, Descriptor);
    public void Set(JObject obj, float value) => env_->SetFloatField(obj, Descriptor, value);
}

public unsafe class JDoubleField(FieldDescriptor descriptor, string name) : JField(descriptor, name, Types.Double)
{
    public double Get(JObject obj) => env_->GetDoubleField(obj, Descriptor);
    public void Set(JObject obj, double value) => env_->SetDoubleField(obj, Descriptor, value);
}

public unsafe class JEnumField : JField
{
    public JEnumField(FieldDescriptor descriptor, string name, JEnum type) : base(descriptor, name, type) => EnumType = type;

    public JEnum EnumType;

    public JEnumTuple Get(JObject obj)
    {
        using var data = JObject.Create(env_->GetObjectField(obj, Descriptor));
        return EnumType[data];
    }
    public void Set(JObject obj, JEnumTuple value) => env_->SetObjectField(obj, Descriptor, value);
    public void Set(JObject obj, EnumNotion value) => env_->SetObjectField(obj, Descriptor, value);
}