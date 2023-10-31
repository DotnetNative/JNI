namespace JNI.Models.Local;
public unsafe sealed class JStaticField : FieldData
{
    public JStaticField(Env env, nint handle, string name, string sig, ClassHandle clazz) : base(env, handle, name, sig)
        => this.clazz = clazz;

    private ClassHandle clazz;

    public JObject Value => new JObject(Env, Env.Native->GetStaticObjectField(!clazz, Addr));
    public JString GetString(Env env, JObject obj, bool isUnicode = true) => new(env, Env.Native->GetStaticObjectField(!clazz, Addr), isUnicode);
    public bool GetBool() => Env.Native->GetStaticBooleanField(!clazz, Addr);
    public byte GetByte() => Env.Native->GetStaticByteField(!clazz, Addr);
    public short GetShort() => Env.Native->GetStaticShortField(!clazz, Addr);
    public int GetInt() => Env.Native->GetStaticIntField(!clazz, Addr);
    public long GetLong() => Env.Native->GetStaticLongField(!clazz, Addr);
    public float GetFloat() => Env.Native->GetStaticFloatField(!clazz, Addr);
    public double GetDouble() => Env.Native->GetStaticDoubleField(!clazz, Addr);
    public void SetBool(bool value) => Env.Native->SetStaticBooleanField(!clazz, Addr, value);
    public void SetByte(byte value) => Env.Native->SetStaticByteField(!clazz, Addr, value);
    public void SetShort(short value) => Env.Native->SetStaticShortField(!clazz, Addr, value);
    public void SetInt(int value) => Env.Native->SetStaticIntField(!clazz, Addr, value);
    public void SetLong(long value) => Env.Native->SetStaticLongField(!clazz, Addr, value);
    public void SetFloat(float value) => Env.Native->SetStaticFloatField(!clazz, Addr, value);
    public void SetDouble(double value) => Env.Native->SetStaticDoubleField(!clazz, Addr, value);
    public void SetValue(JObject value) => Env.Native->SetStaticObjectField(!clazz, Addr, !value);
}