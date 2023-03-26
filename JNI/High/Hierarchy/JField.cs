using CSJNI;
using CSJNI.High;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public unsafe class JField : FieldData
{
    public JField(Env env, IntPtr handle, string name, JType type) : base(env, handle, name, type)
    {
    }

    public JObject GetValue(JObject obj) => new JObject(Env, Env.Master->GetObjectField((IntPtr)obj, Addr));
    public bool GetBool(JObject obj) => Env.Master->GetBooleanField((IntPtr)obj, Addr);
    public byte GetByte(JObject obj) => Env.Master->GetByteField((IntPtr)obj, Addr);
    public short GetShort(JObject obj) => Env.Master->GetShortField((IntPtr)obj, Addr);
    public int GetInt(JObject obj) => Env.Master->GetIntField((IntPtr)obj, Addr);
    public long GetLong(JObject obj) => Env.Master->GetLongField((IntPtr)obj, Addr);
    public float GetFloat(JObject obj) => Env.Master->GetFloatField((IntPtr)obj, Addr);
    public double GetDouble(JObject obj) => Env.Master->GetDoubleField((IntPtr)obj, Addr);
    public void SetValue(JObject obj, JObject value) => Env.Master->SetObjectField((IntPtr)obj, Addr, (IntPtr)value);
    public void SetBool(JObject obj, bool value) => Env.Master->SetBooleanField((IntPtr)obj, Addr, value);
    public void SetByte(JObject obj, byte value) => Env.Master->SetByteField((IntPtr)obj, Addr, value);
    public void SetShort(JObject obj, short value) => Env.Master->SetShortField((IntPtr)obj, Addr, value);
    public void SetInt(JObject obj, int value) => Env.Master->SetIntField((IntPtr)obj, Addr, value);
    public void SetLong(JObject obj, long value) => Env.Master->SetLongField((IntPtr)obj, Addr, value);
    public void SetFloat(JObject obj, float value) => Env.Master->SetFloatField((IntPtr)obj, Addr, value);
    public void SetDouble(JObject obj, double value) => Env.Master->SetDoubleField((IntPtr)obj, Addr, value);
}