using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public unsafe class JMethod : MethodData
{
    public JMethod(Env env, IntPtr handle, string name, JType type, Arg[] args, ClassHandle clazz) : base(env, handle, name, type, args)
    {
        this.clazz = clazz;
    }

    public JMethod(Env env, string name, JType type, Arg[] args, ClassHandle clazz) : base(env, IntPtr.Zero, name, type, args)
    {
        this.clazz = clazz;
        Addr = env.Master->GetMethodID((IntPtr)clazz, name.AnsiPtr(), SigGen.Method(this).AnsiPtr());
    }

    private ClassHandle clazz;

    public JObject Call(JObject obj, __arglist) => new JObject(Env.Master->CallNonvirtualObjectMethod((IntPtr)obj, (IntPtr)clazz, Addr, new ArgIterator(__arglist)));
}