namespace JNI.Models.Local;
public unsafe class JStaticField : FieldData
{
    public JStaticField(Env env, IntPtr handle, string name, JType type, ClassHandle clazz) : base(env, handle, name, type)
    {
        this.clazz = clazz;
    }

    private ClassHandle clazz;

    public JObject Value => Env.GetStaticObjectField(clazz, this);
    public bool GetBool() => Env.Master->GetStaticBooleanField((IntPtr)clazz, Addr);
    public byte GetByte() => Env.Master->GetStaticByteField((IntPtr)clazz, Addr);
    public short GetShort() => Env.Master->GetStaticShortField((IntPtr)clazz, Addr);
    public int GetInt() => Env.Master->GetStaticIntField((IntPtr)clazz, Addr);
    public long GetLong() => Env.Master->GetStaticLongField((IntPtr)clazz, Addr);
    public float GetFloat() => Env.Master->GetStaticFloatField((IntPtr)clazz, Addr);
    public double GetDouble() => Env.Master->GetStaticDoubleField((IntPtr)clazz, Addr);
    public void SetBool(bool value) => Env.Master->SetStaticBooleanField((IntPtr)clazz, Addr, value);
    public void SetByte(byte value) => Env.Master->SetStaticByteField((IntPtr)clazz, Addr, value);
    public void SetShort(short value) => Env.Master->SetStaticShortField((IntPtr)clazz, Addr, value);
    public void SetInt(int value) => Env.Master->SetStaticIntField((IntPtr)clazz, Addr, value);
    public void SetLong(long value) => Env.Master->SetStaticLongField((IntPtr)clazz, Addr, value);
    public void SetFloat(float value) => Env.Master->SetStaticFloatField((IntPtr)clazz, Addr, value);
    public void SetDouble(double value) => Env.Master->SetStaticDoubleField((IntPtr)clazz, Addr, value);
    public void SetValue(JObject value) => Env.Master->SetStaticObjectField((IntPtr)clazz, Addr, (IntPtr)value);
}