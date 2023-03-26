﻿using System;
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
        Addr = env.Master->GetMethodID((IntPtr)clazz, name.UtfPtr(), SigGen.Method(this).UtfPtr());
    }

    public ClassHandle Clazz;

    public JObject Call(JObject obj) => new JObject(Env, Env.Master->CallNonvirtualObjectMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, new Params().Ptr));
    public JObject CallVirt(JObject obj) => new JObject(Env, Env.Master->CallObjectMethodA((IntPtr)obj, Addr, new Params().Ptr));
    public JObject Call(JObject obj, Params args) => new JObject(Env, Env.Master->CallNonvirtualObjectMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, args.Ptr));
    public JObject CallVirt(JObject obj, Params args) => new JObject(Env, Env.Master->CallObjectMethodA((IntPtr)obj, Addr, args.Ptr));
    public void CallVoid(JObject obj) => Env.Master->CallNonvirtualVoidMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, new Params().Ptr);
    public void CallVirtVoid(JObject obj) => Env.Master->CallVoidMethodA((IntPtr)obj, Addr, new Params().Ptr);
    public void CallVoid(JObject obj, Params args) => Env.Master->CallNonvirtualObjectMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, args.Ptr);
    public void CallVirtVoid(JObject obj, Params args) => Env.Master->CallObjectMethodA((IntPtr)obj, Addr, args.Ptr);

}