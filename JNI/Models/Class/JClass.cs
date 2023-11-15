using JNI.Core;
using Memory;

namespace JNI;

public unsafe abstract class JClass(EnvHandle handle) : HandleContainer(handle)
{
    public LJCtor GetCtor(params Arg[] args) => new(GetVoidMethod("<init>", args));
    public GJCtor GetGCtor(params Arg[] args) => new(GetVoidGMethod("<init>", args));

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

    public LJStringField GetStringField(string name) => new(GetFieldHandle(name, Env.Types.String), name);
    public LJObjectField GetObjectField(string name, TypeInfo type) => new(GetFieldHandle(name, type), name, type);
    public LJBoolField GetBoolField(string name) => new(GetFieldHandle(name, Env.Types.Bool), name);
    public LJByteField GetByteField(string name) => new(GetFieldHandle(name, Env.Types.Byte), name);
    public LJCharField GetCharField(string name) => new(GetFieldHandle(name, Env.Types.Char), name);
    public LJShortField GetShortField(string name) => new(GetFieldHandle(name, Env.Types.Short), name);
    public LJIntField GetIntField(string name) => new(GetFieldHandle(name, Env.Types.Int), name);
    public LJLongField GetLongField(string name) => new(GetFieldHandle(name, Env.Types.Long), name);
    public LJFloatField GetFloatField(string name) => new(GetFieldHandle(name, Env.Types.Float), name);
    public LJDoubleField GetDoubleField(string name) => new(GetFieldHandle(name, Env.Types.Double), name);
    public LJEnumField<T> GetEnumField<T>(string name, JEnum<T> jenum) where T : struct, Enum => new(GetFieldHandle(name, jenum), name, jenum);

    public GJStringField GetStringGField(string name) => new(GetFieldGHandle(name, Env.Types.String), name);
    public GJObjectField GetObjectGField(string name, TypeInfo type) => new(GetFieldGHandle(name, type), name, type);
    public GJBoolField GetBoolGField(string name) => new(GetFieldGHandle(name, Env.Types.Bool), name);
    public GJByteField GetByteGField(string name) => new(GetFieldGHandle(name, Env.Types.Byte), name);
    public GJCharField GetCharGField(string name) => new(GetFieldGHandle(name, Env.Types.Char), name);
    public GJShortField GetShortGField(string name) => new(GetFieldGHandle(name, Env.Types.Short), name);
    public GJIntField GetIntGField(string name) => new(GetFieldGHandle(name, Env.Types.Int), name);
    public GJLongField GetLongGField(string name) => new(GetFieldGHandle(name, Env.Types.Long), name);
    public GJFloatField GetFloatGField(string name) => new(GetFieldGHandle(name, Env.Types.Float), name);
    public GJDoubleField GetDoubleGField(string name) => new(GetFieldGHandle(name, Env.Types.Double), name);
    public GJEnumField<T> GetEnumGField<T>(string name, JEnum<T> jenum) where T : struct, Enum => new(GetFieldGHandle(name, jenum), name, jenum);

    public LJStaticStringField GetStaticStringField(string name) => new(GetStaticFieldHandle(name, Env.Types.String), name, this);
    public LJStaticObjectField GetStaticObjectField(string name, TypeInfo type) => new(GetStaticFieldHandle(name, type), name, type, this);
    public LJStaticBoolField GetStaticBoolField(string name) => new(GetStaticFieldHandle(name, Env.Types.Bool), name, this);
    public LJStaticByteField GetStaticByteField(string name) => new(GetStaticFieldHandle(name, Env.Types.Byte), name, this);
    public LJStaticCharField GetStaticCharField(string name) => new(GetStaticFieldHandle(name, Env.Types.Char), name, this);
    public LJStaticShortField GetStaticShortField(string name) => new(GetStaticFieldHandle(name, Env.Types.Short), name, this);
    public LJStaticIntField GetStaticIntField(string name) => new(GetStaticFieldHandle(name, Env.Types.Int), name, this);
    public LJStaticLongField GetStaticLongField(string name) => new(GetStaticFieldHandle(name, Env.Types.Long), name, this);
    public LJStaticFloatField GetStaticFloatField(string name) => new(GetStaticFieldHandle(name, Env.Types.Float), name, this);
    public LJStaticDoubleField GetStaticDoubleField(string name) => new(GetStaticFieldHandle(name, Env.Types.Double), name, this);
    public LJStaticEnumField<T> GetStaticEnumField<T>(string name, JEnum<T> jenum) where T : struct, Enum => new(GetStaticFieldHandle(name, jenum), name, jenum, this);

    public GJStaticStringField GetStaticStringGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.String), name, this);
    public GJStaticObjectField GetStaticObjectGField(string name, TypeInfo type) => new(GetStaticFieldGHandle(name, type), name, type, this);
    public GJStaticBoolField GetStaticBoolGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Bool), name, this);
    public GJStaticByteField GetStaticByteGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Byte), name, this);
    public GJStaticCharField GetStaticCharGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Char), name, this);
    public GJStaticShortField GetStaticShortGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Short), name, this);
    public GJStaticIntField GetStaticIntGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Int), name, this);
    public GJStaticLongField GetStaticLongGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Long), name, this);
    public GJStaticFloatField GetStaticFloatGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Float), name, this);
    public GJStaticDoubleField GetStaticDoubleGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Double), name, this);
    public GJStaticEnumField<T> GetStaticEnumGField<T>(string name, JEnum<T> jenum) where T : struct, Enum => new(GetStaticFieldGHandle(name, jenum), name, jenum, this);
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

    public LJStringMethod GetStringMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.String, args), name, this, args);
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
    public LJEnumMethod<T> GetEnumMethod<T>(string name, JEnum<T> jenum, params Arg[] args) where T : struct, Enum => new(GetMethodHandle(name, jenum, args), name, jenum, this, args);

    public GJStringMethod GetStringGMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.String, args), name, this, args);
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
    public GJEnumMethod<T> GetEnumGMethod<T>(string name, JEnum<T> jenum, params Arg[] args) where T : struct, Enum => new(GetMethodGHandle(name, jenum, args), name, jenum, this, args);

    public LJStaticStringMethod GetStaticbStringMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.String, args), name, this, args);
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
    public LJStaticEnumMethod<T> GetStaticEnumMethod<T>(string name, JEnum<T> jenum, params Arg[] args) where T : struct, Enum => new(GetStaticMethodHandle(name, jenum, args), name, jenum, this, args);

    public GJStaticStringMethod GetStaticStringGMethod(string name, params Arg[] args) => new(GetStaticMethodGHandle(name, Env.Types.String, args), name, this, args);
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
    public GJStaticEnumMethod<T> GetStaticEnumGMethod<T>(string name, JEnum<T> jenum, params Arg[] args) where T : struct, Enum => new(GetStaticMethodGHandle(name, jenum, args), name, jenum, this, args);
    #endregion

    public LJClass GetSuperclass() => new(LHandle.Create(Env.Native->GetSuperclass(Addr)));
    public GJClass GetGSuperclass() => new(GHandle.Create(Env.Native->GetSuperclass(Addr)));

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

    public string ClassName => new java.lang.Class(this).NameNative;
}

public unsafe class LJClass(LHandle handle) : JClass(handle)
{
    public LJObject AsObject => LJObject.Create(Addr);
}

public unsafe class GJClass(GHandle handle) : JClass(handle)
{
    public GJObject AsObject => GJObject.Create(Addr);
}