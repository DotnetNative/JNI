using CSJNI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

    public JObject GetValue() => Env.GetStaticObjectField(clazz, this);
    public void SetValue(JObject value) => Env.Master->SetStaticObjectField((IntPtr)clazz, Addr, (IntPtr)value);
}