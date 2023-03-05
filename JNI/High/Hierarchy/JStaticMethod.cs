using CSJNI.High.BaseTypes;
using CSJNI.Low;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public unsafe class JStaticMethod : MethodData
{
    public JStaticMethod(Env env, IntPtr handle, string name, JType type, ClassHandle clazz, params Arg[] args) : base(env, handle, name, type, args)
    {
        Clazz = clazz;
    }

    public JStaticMethod(Env env, string name, JType type, ClassHandle clazz, params Arg[] args) : base(env, IntPtr.Zero, name, type, args)
    {
        Clazz = clazz;
        string argsStr = SigGen.Method(this);
        Addr = env.Master->GetStaticMethodID((IntPtr)clazz, name.AnsiPtr(), argsStr.AnsiPtr());
    }

    public ClassHandle Clazz;

    public void CallVoid() => Env.Master->CallStaticVoidMethodA((IntPtr)Clazz, Addr, new Params().Ptr);
    public void CallVoid(Params args) => Env.Master->CallStaticVoidMethodA((IntPtr)Clazz, Addr, args.Ptr);
    public JObject CallObj() => new JObject(Env, Env.Master->CallStaticObjectMethodA((IntPtr)Clazz, Addr, new Params().Ptr));
    public T Call<T>() where T : struct => Env.Master->CallStaticObjectMethodA((IntPtr)Clazz, Addr, new Params().Ptr).ToStruct<T>();
    public JObject CallObj(Params args) => new JObject(Env, Env.Master->CallStaticObjectMethodA((IntPtr)Clazz, Addr, args.Ptr));
    public T Call<T>(Params args) where T : struct => Env.Master->CallStaticObjectMethodA((IntPtr)Clazz, Addr, args.Ptr).ToStruct<T>();
}