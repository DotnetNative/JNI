using JNI.Core;
using Memory;

namespace JNI;

public unsafe abstract class JClass(EnvHandle handle) : HandleContainer(handle)
{
    public JCtor GetCtor(params Arg[] args) => new(GetVoidMethod("<init>", args));

    public JCtor GetCtor(params TypeInfo[] args) => GetCtor(args.ToArgs());

    #region Field
    public LHandle GetFieldHandle(string name, TypeInfo type)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Field(type);
        using var sigCo = new CoMem(sig);
        return LHandle.Create(Native->GetFieldID(Address, nameCo.Ptr, sigCo.Ptr));
    }

    public GHandle GetFieldGHandle(string name, TypeInfo type)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Field(type);
        using var sigCo = new CoMem(sig);
        return GHandle.Create(Native->GetFieldID(Address, nameCo.Ptr, sigCo.Ptr));
    }

    public LHandle GetStaticFieldHandle(string name, TypeInfo type)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Field(type);
        using var sigCo = new CoMem(sig);
        return LHandle.Create(Native->GetStaticFieldID(Address, nameCo.Ptr, sigCo.Ptr));
    }

    public GHandle GetStaticFieldGHandle(string name, TypeInfo type)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Field(type);
        using var sigCo = new CoMem(sig);
        return GHandle.Create(Native->GetStaticFieldID(Address, nameCo.Ptr, sigCo.Ptr));
    }

    public JStringField GetStringField(string name) => new(GetFieldHandle(name, Env.Types.String), name);
    public JObjectField GetObjectField(string name, TypeInfo type) => new(GetFieldHandle(name, type), name, type);
    public JBoolField GetBoolField(string name) => new(GetFieldHandle(name, Env.Types.Bool), name);
    public JByteField GetByteField(string name) => new(GetFieldHandle(name, Env.Types.Byte), name);
    public JCharField GetCharField(string name) => new(GetFieldHandle(name, Env.Types.Char), name);
    public JShortField GetShortField(string name) => new(GetFieldHandle(name, Env.Types.Short), name);
    public JIntField GetIntField(string name) => new(GetFieldHandle(name, Env.Types.Int), name);
    public JLongField GetLongField(string name) => new(GetFieldHandle(name, Env.Types.Long), name);
    public JFloatField GetFloatField(string name) => new(GetFieldHandle(name, Env.Types.Float), name);
    public JDoubleField GetDoubleField(string name) => new(GetFieldHandle(name, Env.Types.Double), name);
    public JEnumField<T> GetEnumField<T>(string name, JEnum<T> jenum) where T : struct, Enum => new(GetFieldHandle(name, jenum), name, jenum);

    public JStaticStringField GetStaticStringField(string name) => new(GetStaticFieldHandle(name, Env.Types.String), name, this);
    public JStaticObjectField GetStaticObjectField(string name, TypeInfo type) => new(GetStaticFieldHandle(name, type), name, type, this);
    public JStaticBoolField GetStaticBoolField(string name) => new(GetStaticFieldHandle(name, Env.Types.Bool), name, this);
    public JStaticByteField GetStaticByteField(string name) => new(GetStaticFieldHandle(name, Env.Types.Byte), name, this);
    public JStaticCharField GetStaticCharField(string name) => new(GetStaticFieldHandle(name, Env.Types.Char), name, this);
    public JStaticShortField GetStaticShortField(string name) => new(GetStaticFieldHandle(name, Env.Types.Short), name, this);
    public JStaticIntField GetStaticIntField(string name) => new(GetStaticFieldHandle(name, Env.Types.Int), name, this);
    public JStaticLongField GetStaticLongField(string name) => new(GetStaticFieldHandle(name, Env.Types.Long), name, this);
    public JStaticFloatField GetStaticFloatField(string name) => new(GetStaticFieldHandle(name, Env.Types.Float), name, this);
    public JStaticDoubleField GetStaticDoubleField(string name) => new(GetStaticFieldHandle(name, Env.Types.Double), name, this);
    public JStaticEnumField<T> GetStaticEnumField<T>(string name, JEnum<T> jenum) where T : struct, Enum => new(GetStaticFieldHandle(name, jenum), name, jenum, this);
    #endregion

    #region Method
    public LHandle GetMethodHandle(string name, TypeInfo type, params Arg[] args)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Method(type, args);
        using var sigCo = new CoMem(sig);

        return LHandle.Create(Native->GetMethodID(Address, nameCo.Ptr, sigCo.Ptr));
    }

    public GHandle GetMethodGHandle(string name, TypeInfo type, params Arg[] args)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Method(type, args);
        using var sigCo = new CoMem(sig);

        return GHandle.Create(Native->GetMethodID(Address, nameCo.Ptr, sigCo.Ptr));
    }

    public LHandle GetStaticMethodHandle(string name, TypeInfo type, params Arg[] args)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Method(type, args);
        using var sigCo = new CoMem(sig);

        return LHandle.Create(Native->GetStaticMethodID(Address, nameCo.Ptr, sigCo.Ptr));
    }

    public GHandle GetStaticMethodGHandle(string name, TypeInfo type, params Arg[] args)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Method(type, args);
        using var sigCo = new CoMem(sig);

        return GHandle.Create(Native->GetStaticMethodID(Address, nameCo.Ptr, sigCo.Ptr));
    }

    public JStringMethod GetStringMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.String, args), name, this, args);
    public JObjectMethod GetObjectMethod(string name, TypeInfo type, params Arg[] args) => new(GetMethodHandle(name, type, args), name, type, this, args);
    public JVoidMethod GetVoidMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Void, args), name, this, args);
    public JBoolMethod GetBoolMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Bool, args), name, this, args);
    public JByteMethod GetByteMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Byte, args), name, this, args);
    public JCharMethod GetCharMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Char, args), name, this, args);
    public JShortMethod GetShortMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Short, args), name, this, args);
    public JIntMethod GetIntMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Int, args), name, this, args);
    public JLongMethod GetLongMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Long, args), name, this, args);
    public JFloatMethod GetFloatMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Float, args), name, this, args);
    public JDoubleMethod GetDoubleMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Double, args), name, this, args);
    public JEnumMethod<T> GetEnumMethod<T>(string name, JEnum<T> jenum, params Arg[] args) where T : struct, Enum => new(GetMethodHandle(name, jenum, args), name, jenum, this, args);

    public JStaticStringMethod GetStaticbStringMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.String, args), name, this, args);
    public JStaticObjectMethod GetStaticObjectMethod(string name, TypeInfo type, params Arg[] args) => new(GetStaticMethodHandle(name, type, args), name, type, this, args);
    public JStaticVoidMethod GetStaticVoidMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Void, args), name, this, args);
    public JStaticBoolMethod GetStaticBoolMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Bool, args), name, this, args);
    public JStaticByteMethod GetStaticByteMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Byte, args), name, this, args);
    public JStaticCharMethod GetStaticCharMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Char, args), name, this, args);
    public JStaticShortMethod GetStaticShortMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Short, args), name, this, args);
    public JStaticIntMethod GetStaticIntMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Int, args), name, this, args);
    public JStaticLongMethod GetStaticLongMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Long, args), name, this, args);
    public JStaticFloatMethod GetStaticFloatMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Float, args), name, this, args);
    public JStaticDoubleMethod GetStaticDoubleMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Env.Types.Double, args), name, this, args);
    public JStaticEnumMethod<T> GetStaticEnumMethod<T>(string name, JEnum<T> jenum, params Arg[] args) where T : struct, Enum => new(GetStaticMethodHandle(name, jenum, args), name, jenum, this, args);
    #endregion

    public LJClass GetSuperclass() => new(LHandle.Create(Env.Native->GetSuperclass(Address)));
    public GJClass GetGSuperclass() => new(GHandle.Create(Env.Native->GetSuperclass(Address)));

    public bool AssignableFrom(JClass clazz) => Env.Native->IsAssignableFrom(Address, clazz);

    public RetCode RegisterNatives(params NativeMethod_[] methods)
    {
        fixed (NativeMethod_* ptr = methods)
            return Env.Native->RegisterNatives(Address, ptr, methods.Length);
    }

    public RetCode RegisterNatives(Env env, params NativeMethod[] methods)
    {
        fixed (NativeMethod_* ptr = methods.ToStructs())
            return env.Native->RegisterNatives(Address, ptr, methods.Length);
    }

    public RetCode UnregisterNatives() => Env.Native->UnregisterNatives(Address);

    public string ClassName => new java.lang.Class(this).NameNative;
}

public unsafe class LJClass(LHandle handle) : JClass(handle)
{
    public LJObject AsObject => LJObject.Create(Address);
}

public unsafe class GJClass(GHandle handle) : JClass(handle)
{
    public GJObject AsObject => GJObject.Create(Address);
}