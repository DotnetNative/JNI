namespace JNI.Models.Local;
public unsafe sealed class JField : FieldData
{
    public JField(Env env, nint handle, string name, string sig) : base(env, handle, name, sig) { }

    public JObject GetValue(JObject obj) => new(Env, Env.Native->GetObjectField((nint)obj, Addr));
    public JString GetString(Env env, JObject obj, bool isUnicode = true) => new(env, Env.Native->GetObjectField(!obj, Addr), isUnicode);
    public bool GetBool(JObject obj) => Env.Native->GetBooleanField((nint)obj, Addr);
    public byte GetByte(JObject obj) => Env.Native->GetByteField((nint)obj, Addr);
    public short GetShort(JObject obj) => Env.Native->GetShortField((nint)obj, Addr);
    public int GetInt(JObject obj) => Env.Native->GetIntField((nint)obj, Addr);
    public long GetLong(JObject obj) => Env.Native->GetLongField((nint)obj, Addr);
    public float GetFloat(JObject obj) => Env.Native->GetFloatField((nint)obj, Addr);
    public double GetDouble(JObject obj) => Env.Native->GetDoubleField((nint)obj, Addr);
    public void SetValue(JObject obj, JObject value) => Env.Native->SetObjectField((nint)obj, Addr, (nint)value);
    public void SetBool(JObject obj, bool value) => Env.Native->SetBooleanField((nint)obj, Addr, value);
    public void SetByte(JObject obj, byte value) => Env.Native->SetByteField((nint)obj, Addr, value);
    public void SetShort(JObject obj, short value) => Env.Native->SetShortField((nint)obj, Addr, value);
    public void SetInt(JObject obj, int value) => Env.Native->SetIntField((nint)obj, Addr, value);
    public void SetLong(JObject obj, long value) => Env.Native->SetLongField((nint)obj, Addr, value);
    public void SetFloat(JObject obj, float value) => Env.Native->SetFloatField((nint)obj, Addr, value);
    public void SetDouble(JObject obj, double value) => Env.Native->SetDoubleField((nint)obj, Addr, value);
}