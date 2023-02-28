using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public unsafe class JStaticMethod : MethodData
{
    public JStaticMethod(Env env, IntPtr handle, string name, JType type, ClassHandle clazz, params Arg[] args) : base(env, handle, name, type, args)
    {
        this.clazz = clazz;
    }

    public JStaticMethod(Env env, string name, JType type, ClassHandle clazz, params Arg[] args) : base(env, IntPtr.Zero, name, type, args)
    {
        this.clazz = clazz;
        Addr = env.Master->GetStaticMethodID((IntPtr)clazz, name.Ptr(), SigGen.Method(this).Ptr());
    }

    private ClassHandle clazz;

    public JObject Call(__arglist) => new JObject(Env.Master->CallStaticIntPtrMethod((IntPtr)clazz, Addr, new ArgIterator(__arglist)), clazz);
}