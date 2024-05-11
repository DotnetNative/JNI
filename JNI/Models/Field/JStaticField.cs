namespace JNI;
public unsafe abstract class JStaticField : JFieldInstance
{
    public JStaticField(EnvHandle handle, string name, TypeInfo type, JClass clazz) : base(handle, name, type) => Clazz = clazz;

    public readonly JClass Clazz;
}

public unsafe class JStaticStringField(LHandle handle, string name, JClass clazz) : JStaticField(handle, name, handle.Env.Types.String, clazz)
{
    public java.lang.String Value { get => new(LHandle.Create(Native->GetStaticObjectField(Clazz, Address))); set => Native->SetStaticObjectField(Clazz, Address, value); }
    public java.lang.String GValue { get => new(GHandle.Create(Native->GetStaticObjectField(Clazz, Address))); set => Native->SetStaticObjectField(Clazz, Address, value); }
}
public unsafe class JStaticObjectField(LHandle handle, string name, TypeInfo type, JClass clazz) : JStaticField(handle, name, type, clazz)
{
    public LJObject Value { get => LJObject.Create(Native->GetStaticObjectField(Clazz, Address)); set => Native->SetStaticObjectField(Clazz, Address, value); }
    public GJObject GValue { get => GJObject.Create(Native->GetStaticObjectField(Clazz, Address)); set => Native->SetStaticObjectField(Clazz, Address, value); }
}
public unsafe class JStaticBoolField(LHandle handle, string name, JClass clazz) : JStaticField(handle, name, handle.Env.Types.Bool, clazz)
{
    public bool Value { get => Native->GetStaticBooleanField(Clazz, Address); set => Native->SetStaticBooleanField(Clazz, Address, value); }
}

public unsafe class JStaticByteField(LHandle handle, string name, JClass clazz) : JStaticField(handle, name, handle.Env.Types.Byte, clazz)
{
    public byte Value { get => Native->GetStaticByteField(Clazz, Address); set => Native->SetStaticByteField(Clazz, Address, value); }
}

public unsafe class JStaticShortField(LHandle handle, string name, JClass clazz) : JStaticField(handle, name, handle.Env.Types.Short, clazz)
{
    public short Value { get => Native->GetStaticShortField(Clazz, Address); set => Native->SetStaticShortField(Clazz, Address, value); }
}

public unsafe class JStaticCharField(LHandle handle, string name, JClass clazz) : JStaticField(handle, name, handle.Env.Types.Char, clazz)
{
    public char Value { get => Native->GetStaticCharField(Clazz, Address); set => Native->SetStaticCharField(Clazz, Address, value); }
}

public unsafe class JStaticIntField(LHandle handle, string name, JClass clazz) : JStaticField(handle, name, handle.Env.Types.Int, clazz)
{
    public int Value { get => Native->GetStaticIntField(Clazz, Address); set => Native->SetStaticIntField(Clazz, Address, value); }
}

public unsafe class JStaticLongField(LHandle handle, string name, JClass clazz) : JStaticField(handle, name, handle.Env.Types.Long, clazz)
{
    public long Value { get => Native->GetStaticLongField(Clazz, Address); set => Native->SetStaticLongField(Clazz, Address, value); }
}

public unsafe class JStaticFloatField(LHandle handle, string name, JClass clazz) : JStaticField(handle, name, handle.Env.Types.Float, clazz)
{
    public float Value { get => Native->GetStaticFloatField(Clazz, Address); set => Native->SetStaticFloatField(Clazz, Address, value); }
}

public unsafe class JStaticDoubleField(LHandle handle, string name, JClass clazz) : JStaticField(handle, name, handle.Env.Types.Double, clazz)
{
    public double Value { get => Native->GetStaticDoubleField(Clazz, Address); set => Native->SetStaticDoubleField(Clazz, Address, value); }
}

public unsafe class JStaticEnumField<T> : JStaticField where T : struct, Enum
{
    public JStaticEnumField(LHandle handle, string name, JEnum<T> type, JClass clazz) : base(handle, name, type, clazz) => EnumType = type;

    public JEnum<T> EnumType;

    public java.lang.Enum<T> Value
    {
        get
        {
            using var data = LJObject.Create(Native->GetStaticObjectField(Clazz, Address));
            return EnumType[data];
        }
        set => Native->SetStaticObjectField(Clazz, Address, value);
    }
}