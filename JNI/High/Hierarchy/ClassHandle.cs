using CSJNI;
using CSJNI.High;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public unsafe class ClassHandle : HandleEnv
{
    public ClassHandle(Env env, IntPtr handle) : base(env, handle) { }

    public JStaticField GetStaticField(string name, JType type) => new JStaticField(Env, Env.Master->GetStaticFieldID(Addr, name.Ptr(), SigGen.Field(type).Ptr()), name, type, this);
    //public JField GetField(string name, JType type) => new JField(Env, )
}