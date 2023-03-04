using CSJNI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public unsafe class JStaticField : FieldData
{
    public JStaticField(Env env, IntPtr handle, string name, JType type, ClassHandle clazz) : base(env, handle, name, type)
    {
        this.clazz = clazz;
    }

    private ClassHandle clazz;

    public T GetValue<T>() where T : struct => Env.Master->GetStaticObjectField((IntPtr)clazz, Addr).ToStruct<T>();
    public JObject GetObjectValue() => new JObject(Env.Master->GetStaticObjectField((IntPtr)clazz, Addr));
    public void SetValue<T>(JObject obj, T value) where T : struct => Env.Master->SetStaticObjectField((IntPtr)obj, Addr, new IntPtr(&value));
    public void SetValue(JObject obj, JObject value) => Env.Master->SetStaticObjectField((IntPtr)obj, Addr, (IntPtr)value);
}