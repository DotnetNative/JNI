using JNI.Models.Handles;
using JNI.Models.Models.Class;
using JNI.Models.Models.Object;
using JNI.Models.Models.Type;
using Memory;

namespace JNI.Models.Models.Method;
public unsafe abstract class JMethod : JMethodInstance
{
    public JMethod(EnvHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) { }
}

public unsafe abstract class LJMethod : JMethod
{
    public LJMethod(LHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) { }
}

public unsafe abstract class GJMethod : JMethod
{
    public GJMethod(GHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) { }
}

public unsafe class LJVoidMethod : LJMethod
{
    public LJVoidMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Void, clazz, args) { }

    public void Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            Native->CallNonvirtualVoidMethodA(obj, Clazz, Addr, ptr);
    }

    public void CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            Native->CallVoidMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJVoidMethod : GJMethod
{
    public GJVoidMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Void, clazz, args) { }

    public void Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            Native->CallNonvirtualVoidMethodA(obj, Clazz, Addr, ptr);
    }

    public void CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            Native->CallVoidMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJObjectMethod : LJMethod
{
    public LJObjectMethod(LHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) { }

    public LJObject Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return LJObject.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Addr, ptr));
    }

    public LJObject CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return LJObject.Create(Native->CallObjectMethodA(obj, Addr, ptr));
    }

    public GJObject CallG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return GJObject.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Addr, ptr));
    }

    public GJObject CallVirtG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return GJObject.Create(Native->CallObjectMethodA(obj, Addr, ptr));
    }
}

public unsafe class GJObjectMethod : GJMethod
{
    public GJObjectMethod(GHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : base(handle, name, type, clazz, args) { }

    public LJObject Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return LJObject.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Addr, ptr));
    }

    public LJObject CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return LJObject.Create(Native->CallObjectMethodA(obj, Addr, ptr));
    }

    public GJObject CallG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return GJObject.Create(Native->CallNonvirtualObjectMethodA(obj, Clazz, Addr, ptr));
    }

    public GJObject CallVirtG(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return GJObject.Create(Native->CallObjectMethodA(obj, Addr, ptr));
    }
}

public unsafe class LJBoolMethod : LJMethod
{
    public LJBoolMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Bool, clazz, args) { }

    public bool Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualBooleanMethodA(obj, Clazz, Addr, ptr);
    }

    public bool CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallBooleanMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJBoolMethod : GJMethod
{
    public GJBoolMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Bool, clazz, args) { }

    public bool Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualBooleanMethodA(obj, Clazz, Addr, ptr);
    }

    public bool CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallBooleanMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJByteMethod : LJMethod
{
    public LJByteMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Byte, clazz, args) { }

    public byte Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualByteMethodA(obj, Clazz, Addr, ptr);
    }

    public byte CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallByteMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJByteMethod : GJMethod
{
    public GJByteMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Byte, clazz, args) { }

    public byte Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualByteMethodA(obj, Clazz, Addr, ptr);
    }

    public byte CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallByteMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJCharMethod : LJMethod
{
    public LJCharMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Char, clazz, args) { }

    public char Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualCharMethodA(obj, Clazz, Addr, ptr);
    }

    public char CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallCharMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJCharMethod : GJMethod
{
    public GJCharMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Char, clazz, args) { }

    public char Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualCharMethodA(obj, Clazz, Addr, ptr);
    }

    public char CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallCharMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJShortMethod : LJMethod
{
    public LJShortMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Short, clazz, args) { }

    public short Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualShortMethodA(obj, Clazz, Addr, ptr);
    }

    public short CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallShortMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJShortMethod : GJMethod
{
    public GJShortMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Short, clazz, args) { }

    public short Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualShortMethodA(obj, Clazz, Addr, ptr);
    }

    public short CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallShortMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJIntMethod : LJMethod
{
    public LJIntMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Int, clazz, args) { }

    public int Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualIntMethodA(obj, Clazz, Addr, ptr);
    }

    public int CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallIntMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJIntMethod : GJMethod
{
    public GJIntMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Int, clazz, args) { }

    public int Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualIntMethodA(obj, Clazz, Addr, ptr);
    }

    public int CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallIntMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJLongMethod : LJMethod
{
    public LJLongMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Long, clazz, args) { }

    public long Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualLongMethodA(obj, Clazz, Addr, ptr);
    }

    public long CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallLongMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJLongMethod : GJMethod
{
    public GJLongMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Long, clazz, args) { }

    public long Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualLongMethodA(obj, Clazz, Addr, ptr);
    }

    public long CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallLongMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJFloatMethod : LJMethod
{
    public LJFloatMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Float, clazz, args) { }

    public float Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualFloatMethodA(obj, Clazz, Addr, ptr);
    }

    public float CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallFloatMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJFloatMethod : GJMethod
{
    public GJFloatMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Float, clazz, args) { }

    public float Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualFloatMethodA(obj, Clazz, Addr, ptr);
    }

    public float CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallFloatMethodA(obj, Addr, ptr);
    }
}

public unsafe class LJDoubleMethod : LJMethod
{
    public LJDoubleMethod(LHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Double, clazz, args) { }

    public double Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualDoubleMethodA(obj, Clazz, Addr, ptr);
    }

    public double CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallDoubleMethodA(obj, Addr, ptr);
    }
}

public unsafe class GJDoubleMethod : GJMethod
{
    public GJDoubleMethod(GHandle handle, string name, JClass clazz, params Arg[] args) : base(handle, name, handle.Env.Types.Double, clazz, args) { }

    public double Call(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallNonvirtualDoubleMethodA(obj, Clazz, Addr, ptr);
    }

    public double CallVirt(JObject obj, params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return Native->CallDoubleMethodA(obj, Addr, ptr);
    }
}