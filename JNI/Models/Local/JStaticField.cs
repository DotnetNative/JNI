namespace JNI.Models.Local;
public unsafe sealed class JStaticField : FieldData
{
    public JStaticField(Env env, nint handle, string name, string sig, ClassHandle clazz) : base(env, handle, name, sig)
        => this.clazz = clazz;

    private ClassHandle clazz;

    public JObject Value => new JObject(Env, Env.Master->GetStaticObjectField(!clazz, Addr));
    public JString GetString(Env env, JObject obj, bool isUnicode = true) => new(env, Env.Master->GetStaticObjectField(!clazz, Addr), isUnicode);
    public bool GetBool() => Env.Master->GetStaticBooleanField(!clazz, Addr);
    public byte GetByte() => Env.Master->GetStaticByteField(!clazz, Addr);
    public short GetShort() => Env.Master->GetStaticShortField(!clazz, Addr);
    public int GetInt() => Env.Master->GetStaticIntField(!clazz, Addr);
    public long GetLong() => Env.Master->GetStaticLongField(!clazz, Addr);
    public float GetFloat() => Env.Master->GetStaticFloatField(!clazz, Addr);
    public double GetDouble() => Env.Master->GetStaticDoubleField(!clazz, Addr);
    public void SetBool(bool value) => Env.Master->SetStaticBooleanField(!clazz, Addr, value);
    public void SetByte(byte value) => Env.Master->SetStaticByteField(!clazz, Addr, value);
    public void SetShort(short value) => Env.Master->SetStaticShortField(!clazz, Addr, value);
    public void SetInt(int value) => Env.Master->SetStaticIntField(!clazz, Addr, value);
    public void SetLong(long value) => Env.Master->SetStaticLongField(!clazz, Addr, value);
    public void SetFloat(float value) => Env.Master->SetStaticFloatField(!clazz, Addr, value);
    public void SetDouble(double value) => Env.Master->SetStaticDoubleField(!clazz, Addr, value);
    public void SetValue(JObject value) => Env.Master->SetStaticObjectField(!clazz, Addr, !value);
}