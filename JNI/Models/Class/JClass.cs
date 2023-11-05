using JNI.Core;
using Memory;

namespace JNI;

public unsafe abstract class JClass : HandleContainer
{
    public JClass(EnvHandle handle) : base(handle) { }

    public LJCtor GetCtor(params Arg[] args) => new LJCtor(GetVoidMethod("<init>", args));
    public GJCtor GetGCtor(params Arg[] args) => new GJCtor(GetVoidGMethod("<init>", args));

    public LJCtor GetCtor(params TypeInfo[] args) => GetCtor(args.ToArgs());
    public GJCtor GetGCtor(params TypeInfo[] args) => GetGCtor(args.ToArgs());

    #region Field
    public LHandle GetFieldHandle(string name, TypeInfo type)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Field(type);
        using var sigCo = new CoMem(sig);
        return LHandle.Create(Native->GetFieldID(Addr, nameCo.Ptr, sigCo.Ptr));
    }

    public GHandle GetFieldGHandle(string name, TypeInfo type)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Field(type);
        using var sigCo = new CoMem(sig);
        return GHandle.Create(Native->GetFieldID(Addr, nameCo.Ptr, sigCo.Ptr));
    }

    public LHandle GetStaticFieldHandle(string name, TypeInfo type)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Field(type);
        using var sigCo = new CoMem(sig);
        return LHandle.Create(Native->GetStaticFieldID(Addr, nameCo.Ptr, sigCo.Ptr));
    }

    public GHandle GetStaticFieldGHandle(string name, TypeInfo type)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Field(type);
        using var sigCo = new CoMem(sig);
        return GHandle.Create(Native->GetStaticFieldID(Addr, nameCo.Ptr, sigCo.Ptr));
    }

    public LJObjectField GetObjectField(string name, TypeInfo type) => new(GetFieldHandle(name, type), name, type);
    public LJBoolField GetBoolField(string name) => new(GetFieldHandle(name, Env.Types.Bool), name);
    public LJByteField GetByteField(string name) => new(GetFieldHandle(name, Env.Types.Byte), name);
    public LJCharField GetCharField(string name) => new(GetFieldHandle(name, Env.Types.Char), name);
    public LJShortField GetShortField(string name) => new(GetFieldHandle(name, Env.Types.Short), name);
    public LJIntField GetIntField(string name) => new(GetFieldHandle(name, Env.Types.Int), name);
    public LJLongField GetLongField(string name) => new(GetFieldHandle(name, Env.Types.Long), name);
    public LJFloatField GetFloatField(string name) => new(GetFieldHandle(name, Env.Types.Float), name);
    public LJDoubleField GetDoubleField(string name) => new(GetFieldHandle(name, Env.Types.Double), name);

    public GJObjectField GetObjectGField(string name, TypeInfo type) => new(GetFieldGHandle(name, type), name, type);
    public GJBoolField GetBoolGField(string name) => new(GetFieldGHandle(name, Env.Types.Bool), name);
    public GJByteField GetByteGField(string name) => new(GetFieldGHandle(name, Env.Types.Byte), name);
    public GJCharField GetCharGField(string name) => new(GetFieldGHandle(name, Env.Types.Char), name);
    public GJShortField GetShortGField(string name) => new(GetFieldGHandle(name, Env.Types.Short), name);
    public GJIntField GetIntGField(string name) => new(GetFieldGHandle(name, Env.Types.Int), name);
    public GJLongField GetLongGField(string name) => new(GetFieldGHandle(name, Env.Types.Long), name);
    public GJFloatField GetFloatGField(string name) => new(GetFieldGHandle(name, Env.Types.Float), name);
    public GJDoubleField GetDoubleGField(string name) => new(GetFieldGHandle(name, Env.Types.Double), name);

    public LJObjectField GetStaticObjectField(string name, TypeInfo type) => new(GetStaticFieldHandle(name, type), name, type);
    public LJBoolField GetStaticBoolField(string name) => new(GetStaticFieldHandle(name, Env.Types.Bool), name);
    public LJByteField GetStaticByteField(string name) => new(GetStaticFieldHandle(name, Env.Types.Byte), name);
    public LJCharField GetStaticCharField(string name) => new(GetStaticFieldHandle(name, Env.Types.Char), name);
    public LJShortField GetStaticShortField(string name) => new(GetStaticFieldHandle(name, Env.Types.Short), name);
    public LJIntField GetStaticIntField(string name) => new(GetStaticFieldHandle(name, Env.Types.Int), name);
    public LJLongField GetStaticLongField(string name) => new(GetStaticFieldHandle(name, Env.Types.Long), name);
    public LJFloatField GetStaticFloatField(string name) => new(GetStaticFieldHandle(name, Env.Types.Float), name);
    public LJDoubleField GetStaticDoubleField(string name) => new(GetStaticFieldHandle(name, Env.Types.Double), name);

    public GJStaticObjectField GetStaticObjectGField(string name, TypeInfo type) => new(GetStaticFieldGHandle(name, type), name, type, this);
    public GJStaticBoolField GetStaticBoolGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Bool), name, this);
    public GJStaticByteField GetStaticByteGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Byte), name, this);
    public GJStaticCharField GetStaticCharGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Char), name, this);
    public GJStaticShortField GetStaticShortGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Short), name, this);
    public GJStaticIntField GetStaticIntGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Int), name, this);
    public GJStaticLongField GetStaticLongGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Long), name, this);
    public GJStaticFloatField GetStaticFloatGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Float), name, this);
    public GJStaticDoubleField GetStaticDoubleGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Double), name, this);
    #endregion

    #region Method
    public LHandle GetMethodHandle(string name, TypeInfo type, params Arg[] args)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Method(type, args);
        using var sigCo = new CoMem(sig);

        return LHandle.Create(Native->GetMethodID(Addr, nameCo.Ptr, sigCo.Ptr));
    }

    public GHandle GetMethodGHandle(string name, TypeInfo type, params Arg[] args)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Method(type, args);
        using var sigCo = new CoMem(sig);

        return GHandle.Create(Native->GetMethodID(Addr, nameCo.Ptr, sigCo.Ptr));
    }

    public LHandle GetStaticMethodHandle(string name, TypeInfo type, params Arg[] args)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Method(type, args);
        using var sigCo = new CoMem(sig);

        return LHandle.Create(Native->GetStaticMethodID(Addr, nameCo.Ptr, sigCo.Ptr));
    }

    public GHandle GetStaticMethodGHandle(string name, TypeInfo type, params Arg[] args)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Method(type, args);
        using var sigCo = new CoMem(sig);

        return GHandle.Create(Native->GetStaticMethodID(Addr, nameCo.Ptr, sigCo.Ptr));
    }

    public LJObjectMethod GetObjectMethod(string name, TypeInfo type, params Arg[] args) => new(GetMethodHandle(name, type, args), name, type, this, args);
    public LJVoidMethod GetVoidMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Void, args), name, this, args);
    public LJBoolMethod GetBoolMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Bool, args), name, this, args);
    public LJByteMethod GetByteMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Byte, args), name, this, args);
    public LJCharMethod GetCharMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Char, args), name, this, args);
    public LJShortMethod GetShortMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Short, args), name, this, args);
    public LJIntMethod GetIntMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Int, args), name, this, args);
    public LJLongMethod GetLongMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Long, args), name, this, args);
    public LJFloatMethod GetFloatMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Float, args), name, this, args);
    public LJDoubleMethod GetDoubleMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Double, args), name, this, args);

    public GJObjectMethod GetObjectGMethod(string name, TypeInfo type, params Arg[] args) => new(GetMethodGHandle(name, type, args), name, type, this, args);
    public GJVoidMethod GetVoidGMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Void, args), name, this, args);
    public GJBoolMethod GetBoolGMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Bool, args), name, this, args);
    public GJByteMethod GetByteGMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Byte, args), name, this, args);
    public GJCharMethod GetCharGMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Char, args), name, this, args);
    public GJShortMethod GetShortGMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Short, args), name, this, args);
    public GJIntMethod GetIntGMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Int, args), name, this, args);
    public GJLongMethod GetLongGMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Long, args), name, this, args);
    public GJFloatMethod GetFloatGMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Float, args), name, this, args);
    public GJDoubleMethod GetDoubleGMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Double, args), name, this, args);

    public LJStaticObjectMethod GetStaticObjectMethod(string name, TypeInfo type, params Arg[] args) => new(GetStaticMethodHandle(name, type, args), name, type, this, args);
    public LJStaticVoidMethod GetStaticVoidMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Void, args), name, this, args);
    public LJStaticBoolMethod GetStaticBoolMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Bool, args), name, this, args);
    public LJStaticByteMethod GetStaticByteMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Byte, args), name, this, args);
    public LJStaticCharMethod GetStaticCharMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Char, args), name, this, args);
    public LJStaticShortMethod GetStaticShortMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Short, args), name, this, args);
    public LJStaticIntMethod GetStaticIntMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Int, args), name, this, args);
    public LJStaticLongMethod GetStaticLongMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Long, args), name, this, args);
    public LJStaticFloatMethod GetStaticFloatMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Float, args), name, this, args);
    public LJStaticDoubleMethod GetStaticDoubleMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Double, args), name, this, args);

    public GJStaticObjectMethod GetStaticObjectGMethod(string name, TypeInfo type, params Arg[] args) => new(GetStaticMethodGHandle(name, type, args), name, type, this, args);
    public GJStaticVoidMethod GetStaticVoidGMethod(string name, params Arg[] args) => new(GetStaticMethodGHandle(name, Env.Types.Void, args), name, this, args);
    public GJStaticBoolMethod GetStaticBoolGMethod(string name, params Arg[] args) => new(GetStaticMethodGHandle(name, Env.Types.Bool, args), name, this, args);
    public GJStaticByteMethod GetStaticByteGMethod(string name, params Arg[] args) => new(GetStaticMethodGHandle(name, Env.Types.Byte, args), name, this, args);
    public GJStaticCharMethod GetStaticCharGMethod(string name, params Arg[] args) => new(GetStaticMethodGHandle(name, Env.Types.Char, args), name, this, args);
    public GJStaticShortMethod GetStaticShortGMethod(string name, params Arg[] args) => new(GetStaticMethodGHandle(name, Env.Types.Short, args), name, this, args);
    public GJStaticIntMethod GetStaticIntGMethod(string name, params Arg[] args) => new(GetStaticMethodGHandle(name, Env.Types.Int, args), name, this, args);
    public GJStaticLongMethod GetStaticLongGMethod(string name, params Arg[] args) => new(GetStaticMethodGHandle(name, Env.Types.Long, args), name, this, args);
    public GJStaticFloatMethod GetStaticFloatGMethod(string name, params Arg[] args) => new(GetStaticMethodGHandle(name, Env.Types.Float, args), name, this, args);
    public GJStaticDoubleMethod GetStaticDoubleGMethod(string name, params Arg[] args) => new(GetStaticMethodGHandle(name, Env.Types.Double, args), name, this, args);
    #endregion

    public LJClass GetSuperclass() => new LJClass(LHandle.Create(Env.Native->GetSuperclass(Addr)));
    public GJClass GetGSuperclass() => new GJClass(GHandle.Create(Env.Native->GetSuperclass(Addr)));

    public bool AssignableFrom(JClass clazz) => Env.Native->IsAssignableFrom(Addr, clazz);

    public RetCode RegisterNatives(params NativeMethod_[] methods)
    {
        fixed (NativeMethod_* ptr = methods)
            return Env.Native->RegisterNatives(Addr, ptr, methods.Length);
    }

    public RetCode RegisterNatives(Env env, params NativeMethod[] methods)
    {
        fixed (NativeMethod_* ptr = methods.ToStructs())
            return env.Native->RegisterNatives(Addr, ptr, methods.Length);
    }

    public RetCode UnregisterNatives() => Env.Native->UnregisterNatives(Addr);
}

public unsafe class LJClass : JClass
{
    public LJClass(LHandle handle) : base(handle) { }

    public LJObject AsObject => LJObject.Create(Addr);
}

public unsafe class GJClass : JClass
{
    public GJClass(GHandle handle) : base(handle) { }

    public GJObject AsObject => GJObject.Create(Addr);
}