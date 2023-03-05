using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public unsafe class JCtor : JMethod
{
    public JCtor(Env env, string name, JType type, Arg[] args, ClassHandle clazz) : base(env, name, type, args, clazz) { }
    public JCtor(Env env, nint handle, string name, JType type, Arg[] args, ClassHandle clazz) : base(env, handle, name, type, args, clazz) { }
    public JCtor(JMethod method) : base(method.Env, method.MethodName, method.Type, method.Args, method.Clazz) { }

    public JObject NewInstance(Params args) => new JObject(Env, Env.Master->NewObjectA((IntPtr)Clazz, Addr, args.Ptr));
}