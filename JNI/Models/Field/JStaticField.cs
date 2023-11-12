namespace JNI;
public unsafe abstract class JStaticField : JFieldInstance
{
    public JStaticField(EnvHandle handle, string name, TypeInfo type, JClass clazz) : base(handle, name, type) => Clazz = clazz;

    public readonly JClass Clazz;
}

public unsafe abstract class LJStaticField : JStaticField
{
    public LJStaticField(LHandle handle, string name, TypeInfo type, JClass clazz) : base(handle, name, type, clazz) { }
}

public unsafe abstract class GJStaticField : JStaticField
{
    public GJStaticField(GHandle handle, string name, TypeInfo type, JClass clazz) : base(handle, name, type, clazz) { }
}

public unsafe class LJStaticStringField : JStaticField
{
    public LJStaticStringField(LHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.String, clazz) { }

    public java.lang.String Value { get => new(LHandle.Create(Native->GetStaticObjectField(Clazz, Addr))); set => Native->SetStaticObjectField(Clazz, Addr, value); }
    public java.lang.String GValue { get => new(GHandle.Create(Native->GetStaticObjectField(Clazz, Addr))); set => Native->SetStaticObjectField(Clazz, Addr, value); }
}

public unsafe class GJStaticStringField : JStaticField
{
    public GJStaticStringField(GHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.String, clazz) { }

    public java.lang.String Value { get => new(LHandle.Create(Native->GetStaticObjectField(Clazz, Addr))); set => Native->SetStaticObjectField(Clazz, Addr, value); }
    public java.lang.String GValue { get => new(GHandle.Create(Native->GetStaticObjectField(Clazz, Addr))); set => Native->SetStaticObjectField(Clazz, Addr, value); }
}

public unsafe class LJStaticObjectField : JStaticField
{
    public LJStaticObjectField(LHandle handle, string name, TypeInfo type, JClass clazz) : base(handle, name, type, clazz) { }

    public LJObject Value { get => LJObject.Create(Native->GetStaticObjectField(Clazz, Addr)); set => Native->SetStaticObjectField(Clazz, Addr, value); }
    public GJObject GValue { get => GJObject.Create(Native->GetStaticObjectField(Clazz, Addr)); set => Native->SetStaticObjectField(Clazz, Addr, value); }
}

public unsafe class GJStaticObjectField : JStaticField
{
    public GJStaticObjectField(GHandle handle, string name, TypeInfo type, JClass clazz) : base(handle, name, type, clazz) { }

    public LJObject Value { get => LJObject.Create(Native->GetStaticObjectField(Clazz, Addr)); set => Native->SetStaticObjectField(Clazz, Addr, value); }
    public GJObject GValue { get => GJObject.Create(Native->GetStaticObjectField(Clazz, Addr)); set => Native->SetStaticObjectField(Clazz, Addr, value); }
}

public unsafe class LJStaticBoolField : LJStaticField
{
    public LJStaticBoolField(LHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Bool, clazz) { }

    public bool Value { get => Native->GetStaticBooleanField(Clazz, Addr); set => Native->SetStaticBooleanField(Clazz, Addr, value); }
}

public unsafe class GJStaticBoolField : GJStaticField
{
    public GJStaticBoolField(GHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Bool, clazz) { }

    public bool Value { get => Native->GetStaticBooleanField(Clazz, Addr); set => Native->SetStaticBooleanField(Clazz, Addr, value); }
}

public unsafe class LJStaticByteField : LJStaticField
{
    public LJStaticByteField(LHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Byte, clazz) { }

    public byte Value { get => Native->GetStaticByteField(Clazz, Addr); set => Native->SetStaticByteField(Clazz, Addr, value); }
}

public unsafe class GJStaticByteField : GJStaticField
{
    public GJStaticByteField(GHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Byte, clazz) { }

    public byte Value { get => Native->GetStaticByteField(Clazz, Addr); set => Native->SetStaticByteField(Clazz, Addr, value); }
}

public unsafe class LJStaticShortField : LJStaticField
{
    public LJStaticShortField(LHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Short, clazz) { }

    public short Value { get => Native->GetStaticShortField(Clazz, Addr); set => Native->SetStaticShortField(Clazz, Addr, value); }
}

public unsafe class GJStaticShortField : GJStaticField
{
    public GJStaticShortField(GHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Short, clazz) { }

    public short Value { get => Native->GetStaticShortField(Clazz, Addr); set => Native->SetStaticShortField(Clazz, Addr, value); }
}

public unsafe class LJStaticCharField : LJStaticField
{
    public LJStaticCharField(LHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Char, clazz) { }

    public char Value { get => Native->GetStaticCharField(Clazz, Addr); set => Native->SetStaticCharField(Clazz, Addr, value); }
}

public unsafe class GJStaticCharField : GJStaticField
{
    public GJStaticCharField(GHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Char, clazz) { }

    public char Value { get => Native->GetStaticCharField(Clazz, Addr); set => Native->SetStaticCharField(Clazz, Addr, value); }
}

public unsafe class LJStaticIntField : LJStaticField
{
    public LJStaticIntField(LHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Int, clazz) { }

    public int Value { get => Native->GetStaticIntField(Clazz, Addr); set => Native->SetStaticIntField(Clazz, Addr, value); }
}

public unsafe class GJStaticIntField : GJStaticField
{
    public GJStaticIntField(GHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Int, clazz) { }

    public int Value { get => Native->GetStaticIntField(Clazz, Addr); set => Native->SetStaticIntField(Clazz, Addr, value); }
}

public unsafe class LJStaticLongField : LJStaticField
{
    public LJStaticLongField(LHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Long, clazz) { }

    public long Value { get => Native->GetStaticLongField(Clazz, Addr); set => Native->SetStaticLongField(Clazz, Addr, value); }
}

public unsafe class GJStaticLongField : GJStaticField
{
    public GJStaticLongField(GHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Long, clazz) { }

    public long Value { get => Native->GetStaticLongField(Clazz, Addr); set => Native->SetStaticLongField(Clazz, Addr, value); }
}


public unsafe class LJStaticFloatField : LJStaticField
{
    public LJStaticFloatField(LHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Float, clazz) { }

    public float Value { get => Native->GetStaticFloatField(Clazz, Addr); set => Native->SetStaticFloatField(Clazz, Addr, value); }
}

public unsafe class GJStaticFloatField : GJStaticField
{
    public GJStaticFloatField(GHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Float, clazz) { }

    public float Value { get => Native->GetStaticFloatField(Clazz, Addr); set => Native->SetStaticFloatField(Clazz, Addr, value); }
}

public unsafe class LJStaticDoubleField : LJStaticField
{
    public LJStaticDoubleField(LHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Double, clazz) { }

    public double Value { get => Native->GetStaticDoubleField(Clazz, Addr); set => Native->SetStaticDoubleField(Clazz, Addr, value); }
}

public unsafe class GJStaticDoubleField : GJStaticField
{
    public GJStaticDoubleField(GHandle handle, string name, JClass clazz) : base(handle, name, handle.Env.Types.Double, clazz) { }

    public double Value { get => Native->GetStaticDoubleField(Clazz, Addr); set => Native->SetStaticDoubleField(Clazz, Addr, value); }
}