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
        Clazz = clazz;
    }

    public JMethod(Env env, string name, JType type, Arg[] args, ClassHandle clazz) : base(env, IntPtr.Zero, name, type, args)
    {
        Clazz = clazz;
        Addr = env.Master->GetMethodID((IntPtr)clazz, name.AnsiPtr(), SigGen.Method(this).AnsiPtr());
    }

    public ClassHandle Clazz;

    public JObject CallObj(JObject obj) => new JObject(Env.Master->CallNonvirtualObjectMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, new Params().Ptr));
    public JObject CallVirtObj(JObject obj) => new JObject(Env.Master->CallObjectMethodA((IntPtr)obj, Addr, new Params().Ptr));
    public T Call<T>(JObject obj) where T : struct => Env.Master->CallNonvirtualObjectMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, new Params().Ptr).ToStruct<T>();
    public T CallVirt<T>(JObject obj) where T : struct => Env.Master->CallObjectMethodA((IntPtr)obj, Addr, new Params().Ptr).ToStruct<T>();
    public JObject CallObj(JObject obj, Params args) => new JObject(Env.Master->CallNonvirtualObjectMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, args.Ptr));
    public JObject CallVirtObj(JObject obj, Params args) => new JObject(Env.Master->CallObjectMethodA((IntPtr)obj, Addr, args.Ptr));
    public T Call<T>(JObject obj, Params args) where T : struct => Env.Master->CallNonvirtualObjectMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, args.Ptr).ToStruct<T>();
    public T CallVirt<T>(JObject obj, Params args) where T : struct => Env.Master->CallObjectMethodA((IntPtr)obj, Addr, args.Ptr).ToStruct<T>();
}