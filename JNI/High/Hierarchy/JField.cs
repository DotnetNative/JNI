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

    public T GetValue<T>(JObject obj) where T : struct => Env.Master->GetIntPtrField((IntPtr)obj, Addr).ToStruct<T>();
    public JObject GetObjectValue(JObject obj) => new JObject(Env.Master->GetIntPtrField((IntPtr)obj, Addr));
}