namespace JNI;
public unsafe abstract class JStaticField : JFieldInstance
{
    public JStaticField(FieldDescriptor descriptor, string name, TypeInfo type, JClass clazz) : base(descriptor, name, type) => Class = clazz;

    public readonly JClass Class;
}

public unsafe class JStaticStringField(FieldDescriptor descriptor, string name, JClass clazz) : JStaticField(descriptor, name, Types.String, clazz)
{
    public JString Value { get => new(HandleImpl.Create(env_->GetStaticObjectField(Class, Descriptor))); set => env_->SetStaticObjectField(Class, Descriptor, value); }
}
public unsafe class JStaticObjectField(FieldDescriptor descriptor, string name, TypeInfo type, JClass clazz) : JStaticField(descriptor, name, type, clazz)
{
    public JObject Value { get => JObject.Create(env_->GetStaticObjectField(Class, Descriptor)); set => env_->SetStaticObjectField(Class, Descriptor, value); }
}
public unsafe class JStaticBoolField(FieldDescriptor descriptor, string name, JClass clazz) : JStaticField(descriptor, name, Types.Bool, clazz)
{
    public bool Value { get => env_->GetStaticBooleanField(Class, Descriptor); set => env_->SetStaticBooleanField(Class, Descriptor, value); }
}

public unsafe class JStaticByteField(FieldDescriptor descriptor, string name, JClass clazz) : JStaticField(descriptor, name, Types.Byte, clazz)
{
    public byte Value { get => env_->GetStaticByteField(Class, Descriptor); set => env_->SetStaticByteField(Class, Descriptor, value); }
}

public unsafe class JStaticShortField(FieldDescriptor descriptor, string name, JClass clazz) : JStaticField(descriptor, name, Types.Short, clazz)
{
    public short Value { get => env_->GetStaticShortField(Class, Descriptor); set => env_->SetStaticShortField(Class, Descriptor, value); }
}

public unsafe class JStaticCharField(FieldDescriptor descriptor, string name, JClass clazz) : JStaticField(descriptor, name, Types.Char, clazz)
{
    public char Value { get => env_->GetStaticCharField(Class, Descriptor); set => env_->SetStaticCharField(Class, Descriptor, value); }
}

public unsafe class JStaticIntField(FieldDescriptor descriptor, string name, JClass clazz) : JStaticField(descriptor, name, Types.Int, clazz)
{
    public int Value { get => env_->GetStaticIntField(Class, Descriptor); set => env_->SetStaticIntField(Class, Descriptor, value); }
}

public unsafe class JStaticLongField(FieldDescriptor descriptor, string name, JClass clazz) : JStaticField(descriptor, name, Types.Long, clazz)
{
    public long Value { get => env_->GetStaticLongField(Class, Descriptor); set => env_->SetStaticLongField(Class, Descriptor, value); }
}

public unsafe class JStaticFloatField(FieldDescriptor descriptor, string name, JClass clazz) : JStaticField(descriptor, name, Types.Float, clazz)
{
    public float Value { get => env_->GetStaticFloatField(Class, Descriptor); set => env_->SetStaticFloatField(Class, Descriptor, value); }
}

public unsafe class JStaticDoubleField(FieldDescriptor descriptor, string name, JClass clazz) : JStaticField(descriptor, name, Types.Double, clazz)
{
    public double Value { get => env_->GetStaticDoubleField(Class, Descriptor); set => env_->SetStaticDoubleField(Class, Descriptor, value); }
}

public unsafe class JStaticEnumField : JStaticField
{
    public JStaticEnumField(FieldDescriptor descriptor, string name, JEnum type, JClass clazz) : base(descriptor, name, type, clazz) => EnumType = type;

    public JEnum EnumType;

    public JEnumTuple Value
    {
        get
        {
            using var data = JObject.Create(env_->GetStaticObjectField(Class, Descriptor));
            return EnumType[data];
        }
        set => env_->SetStaticObjectField(Class, Descriptor, value);
    }

    public EnumNotion JValue
    {
        get
        {
            using var data = JObject.Create(env_->GetStaticObjectField(Class, Descriptor));
            return new(data);
        }
        set => env_->SetStaticObjectField(Class, Descriptor, value);
    }
}