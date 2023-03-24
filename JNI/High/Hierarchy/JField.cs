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
    public void SetValue(JObject obj, JObject value) => Env.Master->SetObjectField((IntPtr)obj, Addr, (IntPtr)value);
}