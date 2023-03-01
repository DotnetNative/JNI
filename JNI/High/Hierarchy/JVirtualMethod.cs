using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public unsafe class JVirtualMethod : MethodData
{
    public JVirtualMethod(Env env, IntPtr handle, string name, JType type, Arg[] args) : base(env, handle, name, type, args)
    {
    }

    public JObject Call(JObject obj, __arglist) => new JObject(Env.Master->CallIntPtrMethod((IntPtr)obj, Addr, new ArgIterator(__arglist)));
}