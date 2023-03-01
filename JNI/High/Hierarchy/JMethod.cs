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

    private ClassHandle clazz;

    public JObject Call(JObject obj, __arglist) => new JObject(Env.Master->CallNonvirtualIntPtrMethod((IntPtr)obj, (IntPtr)clazz, Addr, new ArgIterator(__arglist)));
}