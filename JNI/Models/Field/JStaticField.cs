namespace JNI;
public unsafe abstract class JStaticField : JFieldInstance
{
    public JStaticField(EnvHandle handle, string name, TypeInfo type, JClass clazz) : base(handle, name, type) => Clazz = clazz;

    public readonly JClass Clazz;
}

public unsafe abstract class LJStaticField(LHandle handle, string name, TypeInfo type, JClass clazz) : JStaticField(handle, name, type, clazz);

public unsafe abstract class GJStaticField(GHandle handle, string name, TypeInfo type, JClass clazz) : JStaticField(handle, name, type, clazz);

public unsafe class LJStaticStringField(LHandle handle, string name, JClass clazz) : JStaticField(handle, name, handle.Env.Types.String, clazz)
{
    public java.lang.String Value { get => new(LHandle.Create(Native->GetStaticObjectField(Clazz, Addr))); set => Native->SetStaticObjectField(Clazz, Addr, value); }
    public java.lang.String GValue { get => new(GHandle.Create(Native->GetStaticObjectField(Clazz, Addr))); set => Native->SetStaticObjectField(Clazz, Addr, value); }
}

public unsafe class GJStaticStringField(GHandle handle, string name, JClass clazz) : JStaticField(handle, name, handle.Env.Types.String, clazz)
{
    public java.lang.String Value { get => new(LHandle.Create(Native->GetStaticObjectField(Clazz, Addr))); set => Native->SetStaticObjectField(Clazz, Addr, value); }
    public java.lang.String GValue { get => new(GHandle.Create(Native->GetStaticObjectField(Clazz, Addr))); set => Native->SetStaticObjectField(Clazz, Addr, value); }
}

public unsafe class LJStaticObjectField(LHandle handle, string name, TypeInfo type, JClass clazz) : JStaticField(handle, name, type, clazz)
{
    public LJObject Value { get => LJObject.Create(Native->GetStaticObjectField(Clazz, Addr)); set => Native->SetStaticObjectField(Clazz, Addr, value); }
    public GJObject GValue { get => GJObject.Create(Native->GetStaticObjectField(Clazz, Addr)); set => Native->SetStaticObjectField(Clazz, Addr, value); }
}

public unsafe class GJStaticObjectField(GHandle handle, string name, TypeInfo type, JClass clazz) : JStaticField(handle, name, type, clazz)
{
    public LJObject Value { get => LJObject.Create(Native->GetStaticObjectField(Clazz, Addr)); set => Native->SetStaticObjectField(Clazz, Addr, value); }
    public GJObject GValue { get => GJObject.Create(Native->GetStaticObjectField(Clazz, Addr)); set => Native->SetStaticObjectField(Clazz, Addr, value); }
}

public unsafe class LJStaticBoolField(LHandle handle, string name, JClass clazz) : LJStaticField(handle, name, handle.Env.Types.Bool, clazz)
{
    public bool Value { get => Native->GetStaticBooleanField(Clazz, Addr); set => Native->SetStaticBooleanField(Clazz, Addr, value); }
}

public unsafe class GJStaticBoolField(GHandle handle, string name, JClass clazz) : GJStaticField(handle, name, handle.Env.Types.Bool, clazz)
{
    public bool Value { get => Native->GetStaticBooleanField(Clazz, Addr); set => Native->SetStaticBooleanField(Clazz, Addr, value); }
}

public unsafe class LJStaticByteField(LHandle handle, string name, JClass clazz) : LJStaticField(handle, name, handle.Env.Types.Byte, clazz)
{
    public byte Value { get => Native->GetStaticByteField(Clazz, Addr); set => Native->SetStaticByteField(Clazz, Addr, value); }
}

public unsafe class GJStaticByteField(GHandle handle, string name, JClass clazz) : GJStaticField(handle, name, handle.Env.Types.Byte, clazz)
{
    public byte Value { get => Native->GetStaticByteField(Clazz, Addr); set => Native->SetStaticByteField(Clazz, Addr, value); }
}

public unsafe class LJStaticShortField(LHandle handle, string name, JClass clazz) : LJStaticField(handle, name, handle.Env.Types.Short, clazz)
{
    public short Value { get => Native->GetStaticShortField(Clazz, Addr); set => Native->SetStaticShortField(Clazz, Addr, value); }
}

public unsafe class GJStaticShortField(GHandle handle, string name, JClass clazz) : GJStaticField(handle, name, handle.Env.Types.Short, clazz)
{
    public short Value { get => Native->GetStaticShortField(Clazz, Addr); set => Native->SetStaticShortField(Clazz, Addr, value); }
}

public unsafe class LJStaticCharField(LHandle handle, string name, JClass clazz) : LJStaticField(handle, name, handle.Env.Types.Char, clazz)
{
    public char Value { get => Native->GetStaticCharField(Clazz, Addr); set => Native->SetStaticCharField(Clazz, Addr, value); }
}

public unsafe class GJStaticCharField(GHandle handle, string name, JClass clazz) : GJStaticField(handle, name, handle.Env.Types.Char, clazz)
{
    public char Value { get => Native->GetStaticCharField(Clazz, Addr); set => Native->SetStaticCharField(Clazz, Addr, value); }
}

public unsafe class LJStaticIntField(LHandle handle, string name, JClass clazz) : LJStaticField(handle, name, handle.Env.Types.Int, clazz)
{
    public int Value { get => Native->GetStaticIntField(Clazz, Addr); set => Native->SetStaticIntField(Clazz, Addr, value); }
}

public unsafe class GJStaticIntField(GHandle handle, string name, JClass clazz) : GJStaticField(handle, name, handle.Env.Types.Int, clazz)
{
    public int Value { get => Native->GetStaticIntField(Clazz, Addr); set => Native->SetStaticIntField(Clazz, Addr, value); }
}

public unsafe class LJStaticLongField(LHandle handle, string name, JClass clazz) : LJStaticField(handle, name, handle.Env.Types.Long, clazz)
{
    public long Value { get => Native->GetStaticLongField(Clazz, Addr); set => Native->SetStaticLongField(Clazz, Addr, value); }
}

public unsafe class GJStaticLongField(GHandle handle, string name, JClass clazz) : GJStaticField(handle, name, handle.Env.Types.Long, clazz)
{
    public long Value { get => Native->GetStaticLongField(Clazz, Addr); set => Native->SetStaticLongField(Clazz, Addr, value); }
}

public unsafe class LJStaticFloatField(LHandle handle, string name, JClass clazz) : LJStaticField(handle, name, handle.Env.Types.Float, clazz)
{
    public float Value { get => Native->GetStaticFloatField(Clazz, Addr); set => Native->SetStaticFloatField(Clazz, Addr, value); }
}

public unsafe class GJStaticFloatField(GHandle handle, string name, JClass clazz) : GJStaticField(handle, name, handle.Env.Types.Float, clazz)
{
    public float Value { get => Native->GetStaticFloatField(Clazz, Addr); set => Native->SetStaticFloatField(Clazz, Addr, value); }
}

public unsafe class LJStaticDoubleField(LHandle handle, string name, JClass clazz) : LJStaticField(handle, name, handle.Env.Types.Double, clazz)
{
    public double Value { get => Native->GetStaticDoubleField(Clazz, Addr); set => Native->SetStaticDoubleField(Clazz, Addr, value); }
}

public unsafe class GJStaticDoubleField(GHandle handle, string name, JClass clazz) : GJStaticField(handle, name, handle.Env.Types.Double, clazz)
{
    public double Value { get => Native->GetStaticDoubleField(Clazz, Addr); set => Native->SetStaticDoubleField(Clazz, Addr, value); }
}

public unsafe class LJStaticEnumField<T> : JStaticField where T : struct, Enum
{
    public LJStaticEnumField(LHandle handle, string name, JEnum<T> type, JClass clazz) : base(handle, name, type, clazz) => EnumType = type;

    public JEnum<T> EnumType;

    public java.lang.Enum<T> Value
    {
        get
        {
            using var data = LJObject.Create(Native->GetStaticObjectField(Clazz, Addr));
            return EnumType[data];
        }
        set => Native->SetStaticObjectField(Clazz, Addr, value);
    }
}

public unsafe class GJStaticEnumField<T> : JStaticField where T : struct, Enum
{
    public GJStaticEnumField(GHandle handle, string name, JEnum<T> type, JClass clazz) : base(handle, name, type, clazz) => EnumType = type;

    public JEnum<T> EnumType;

    public java.lang.Enum<T> Value
    {
        get
        {
            using var data = LJObject.Create(Native->GetStaticObjectField(Clazz, Addr));
            return EnumType[data];
        }
        set => Native->SetStaticObjectField(Clazz, Addr, value);
    }
}