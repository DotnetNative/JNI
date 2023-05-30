namespace JNI.Models.Local;
public unsafe sealed class JField : FieldData
{
    public JField(Env env, nint handle, string name, string sig) : base(env, handle, name, sig) { }

    public JObject GetValue(JObject obj) => new(Env, Env.Master->GetObjectField((nint)obj, Addr));
    public JString GetString(Env env, JObject obj, bool isUnicode = true) => new(env, Env.Master->GetObjectField(!obj, Addr), isUnicode);
    public bool GetBool(JObject obj) => Env.Master->GetBooleanField((nint)obj, Addr);
    public byte GetByte(JObject obj) => Env.Master->GetByteField((nint)obj, Addr);
    public short GetShort(JObject obj) => Env.Master->GetShortField((nint)obj, Addr);
    public int GetInt(JObject obj) => Env.Master->GetIntField((nint)obj, Addr);
    public long GetLong(JObject obj) => Env.Master->GetLongField((nint)obj, Addr);
    public float GetFloat(JObject obj) => Env.Master->GetFloatField((nint)obj, Addr);
    public double GetDouble(JObject obj) => Env.Master->GetDoubleField((nint)obj, Addr);
    public void SetValue(JObject obj, JObject value) => Env.Master->SetObjectField((nint)obj, Addr, (nint)value);
    public void SetBool(JObject obj, bool value) => Env.Master->SetBooleanField((nint)obj, Addr, value);
    public void SetByte(JObject obj, byte value) => Env.Master->SetByteField((nint)obj, Addr, value);
    public void SetShort(JObject obj, short value) => Env.Master->SetShortField((nint)obj, Addr, value);
    public void SetInt(JObject obj, int value) => Env.Master->SetIntField((nint)obj, Addr, value);
    public void SetLong(JObject obj, long value) => Env.Master->SetLongField((nint)obj, Addr, value);
    public void SetFloat(JObject obj, float value) => Env.Master->SetFloatField((nint)obj, Addr, value);
    public void SetDouble(JObject obj, double value) => Env.Master->SetDoubleField((nint)obj, Addr, value);
}