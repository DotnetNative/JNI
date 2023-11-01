using JNI.Models.Local;
using JNI.New.Handles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.New.Models.Field;
public unsafe class JField : FieldData
{
    public JField(EnvHandle handle, string name, string sig) : base(handle, name, sig)
    {
    }

    public JObject GetValue(JObject obj) => new(Env, Native->GetObjectField((nint)obj, Addr));
    public JString GetString(Env env, JObject obj, bool isUnicode = true) => new(env, Native->GetObjectField(!obj, Addr), isUnicode);
    public bool GetBool(JObject obj) => Native->GetBooleanField((nint)obj, Addr);
    public byte GetByte(JObject obj) => Native->GetByteField((nint)obj, Addr);
    public short GetShort(JObject obj) => Native->GetShortField((nint)obj, Addr);
    public int GetInt(JObject obj) => Native->GetIntField((nint)obj, Addr);
    public long GetLong(JObject obj) => Native->GetLongField((nint)obj, Addr);
    public float GetFloat(JObject obj) => Native->GetFloatField((nint)obj, Addr);
    public double GetDouble(JObject obj) => Native->GetDoubleField((nint)obj, Addr);
    public void SetValue(JObject obj, JObject value) => Native->SetObjectField((nint)obj, Addr, (nint)value);
    public void SetBool(JObject obj, bool value) => Native->SetBooleanField((nint)obj, Addr, value);
    public void SetByte(JObject obj, byte value) => Native->SetByteField((nint)obj, Addr, value);
    public void SetShort(JObject obj, short value) => Native->SetShortField((nint)obj, Addr, value);
    public void SetInt(JObject obj, int value) => Native->SetIntField((nint)obj, Addr, value);
    public void SetLong(JObject obj, long value) => Native->SetLongField((nint)obj, Addr, value);
    public void SetFloat(JObject obj, float value) => Native->SetFloatField((nint)obj, Addr, value);
    public void SetDouble(JObject obj, double value) => Native->SetDoubleField((nint)obj, Addr, value);
}