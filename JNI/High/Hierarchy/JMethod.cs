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
        Addr = env.Master->GetMethodID((IntPtr)clazz, name.UtfPtr(), SigGen.Method(this).UtfPtr());
    }

    public ClassHandle Clazz;

    public JObject Call(JObject obj) => new JObject(Env, Env.Master->CallNonvirtualObjectMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, new Params().Ptr));
    public JObject Call(JObject obj, Params args) => new JObject(Env, Env.Master->CallNonvirtualObjectMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, args.Ptr));
    public JObject CallVirt(JObject obj) => new JObject(Env, Env.Master->CallObjectMethodA((IntPtr)obj, Addr, new Params().Ptr));
    public JObject CallVirt(JObject obj, Params args) => new JObject(Env, Env.Master->CallObjectMethodA((IntPtr)obj, Addr, args.Ptr));
    
    public void CallBoolean(JObject obj) => Env.Master->CallNonvirtualBooleanMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, new Params().Ptr);
    public void CallBoolean(JObject obj, Params args) => Env.Master->CallNonvirtualBooleanMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, args.Ptr);
    public void CallVirtBoolean(JObject obj) => Env.Master->CallBooleanMethodA((IntPtr)obj, Addr, new Params().Ptr);
    public void CallVirtBoolean(JObject obj, Params args) => Env.Master->CallBooleanMethodA((IntPtr)obj, Addr, args.Ptr);

    public byte CallByte(JObject obj) => Env.Master->CallNonvirtualByteMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, new Params().Ptr);
    public byte CallByte(JObject obj, Params args) => Env.Master->CallNonvirtualByteMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, args.Ptr);
    public byte CallVirtByte(JObject obj) => Env.Master->CallByteMethodA((IntPtr)obj, Addr, new Params().Ptr);
    public byte CallVirtByte(JObject obj, Params args) => Env.Master->CallByteMethodA((IntPtr)obj, Addr, args.Ptr);

    public short CallShort(JObject obj) => Env.Master->CallNonvirtualShortMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, new Params().Ptr);
    public short CallShort(JObject obj, Params args) => Env.Master->CallNonvirtualShortMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, args.Ptr);
    public short CallVirtShort(JObject obj) => Env.Master->CallShortMethodA((IntPtr)obj, Addr, new Params().Ptr);
    public short CallVirtShort(JObject obj, Params args) => Env.Master->CallShortMethodA((IntPtr)obj, Addr, args.Ptr);

    public int CallInt(JObject obj) => Env.Master->CallNonvirtualIntMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, new Params().Ptr);
    public int CallInt(JObject obj, Params args) => Env.Master->CallNonvirtualIntMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, args.Ptr);
    public int CallVirtInt(JObject obj) => Env.Master->CallIntMethodA((IntPtr)obj, Addr, new Params().Ptr);
    public int CallVirtInt(JObject obj, Params args) => Env.Master->CallIntMethodA((IntPtr)obj, Addr, args.Ptr);

    public long CallLong(JObject obj) => Env.Master->CallNonvirtualLongMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, new Params().Ptr);
    public long CallLong(JObject obj, Params args) => Env.Master->CallNonvirtualLongMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, args.Ptr);
    public long CallVirtLong(JObject obj) => Env.Master->CallLongMethodA((IntPtr)obj, Addr, new Params().Ptr);
    public long CallVirtLong(JObject obj, Params args) => Env.Master->CallLongMethodA((IntPtr)obj, Addr, args.Ptr);

    public float CallFloat(JObject obj) => Env.Master->CallNonvirtualFloatMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, new Params().Ptr);
    public float CallFloat(JObject obj, Params args) => Env.Master->CallNonvirtualFloatMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, args.Ptr);
    public float CallVirtFloat(JObject obj) => Env.Master->CallFloatMethodA((IntPtr)obj, Addr, new Params().Ptr);
    public float CallVirtFloat(JObject obj, Params args) => Env.Master->CallFloatMethodA((IntPtr)obj, Addr, args.Ptr);

    public double CallDouble(JObject obj) => Env.Master->CallNonvirtualDoubleMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, new Params().Ptr);
    public double CallDouble(JObject obj, Params args) => Env.Master->CallNonvirtualDoubleMethodA((IntPtr)obj, (IntPtr)Clazz, Addr, args.Ptr);
    public double CallVirtDouble(JObject obj) => Env.Master->CallDoubleMethodA((IntPtr)obj, Addr, new Params().Ptr);
    public double CallVirtDouble(JObject obj, Params args) => Env.Master->CallDoubleMethodA((IntPtr)obj, Addr, args.Ptr);
}