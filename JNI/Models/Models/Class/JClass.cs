using JNI.Core.Enums;
using JNI.Core;
using JNI.Internal;
using JNI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JNI.Models.Handles;
using JNI.Models.Models;
using JNI.Models.Models.Ctor;
using JNI.Models.Models.Field;
using JNI.Models.Models.Method;
using JNI.Models.Models.Type;
using JNI.Models.Models.Object;
using Memory;
using System.Security.Claims;

namespace JNI.Models.Models.Class;

public unsafe abstract class JClass : HandleContainer
{
    public JClass(EnvHandle handle) : base(handle) { }

    public LJCtor GetCtor(params Arg[] args) => new LJCtor(GetVoidMethod("<init>", args));
    public GJCtor GetGCtor(params Arg[] args) => new GJCtor(GetVoidGMethod("<init>", args));

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
    public GJStaticShortField GetStaticShorGField(string name) => new(GetStaticFieldGHandle(name, Env.Types.Short), name, this);
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

    public LJStaticObjectMethod GetObjectStaticMethod(string name, TypeInfo type, params Arg[] args) => new(GetMethodHandle(name, type, args), name, type, this, args);
    public LJStaticVoidMethod GetVoidStaticMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Void, args), name, this, args);
    public LJStaticBoolMethod GetBoolStaticMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Bool, args), name, this, args);
    public LJStaticByteMethod GetByteStaticMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Byte, args), name, this, args);
    public LJStaticCharMethod GetCharStaticMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Char, args), name, this, args);
    public LJStaticShortMethod GetShortStaticMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Short, args), name, this, args);
    public LJStaticIntMethod GetIntStaticMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Int, args), name, this, args);
    public LJStaticLongMethod GetLongStaticMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Long, args), name, this, args);
    public LJStaticFloatMethod GetFloatStaticMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Float, args), name, this, args);
    public LJStaticDoubleMethod GetDoubleStaticMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Env.Types.Double, args), name, this, args);

    public GJStaticObjectMethod GetObjectGStaticMethod(string name, TypeInfo type, params Arg[] args) => new(GetMethodGHandle(name, type, args), name, type, this, args);
    public GJStaticVoidMethod GetVoidGStaticMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Void, args), name, this, args);
    public GJStaticBoolMethod GetBoolGStaticMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Bool, args), name, this, args);
    public GJStaticByteMethod GetByteGStaticMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Byte, args), name, this, args);
    public GJStaticCharMethod GetCharGStaticMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Char, args), name, this, args);
    public GJStaticShortMethod GetShortGStaticMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Short, args), name, this, args);
    public GJStaticIntMethod GetIntGStaticMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Int, args), name, this, args);
    public GJStaticLongMethod GetLongGStaticMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Long, args), name, this, args);
    public GJStaticFloatMethod GetFloatGStaticMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Float, args), name, this, args);
    public GJStaticDoubleMethod GetDoubleGStaticMethod(string name, params Arg[] args) => new(GetMethodGHandle(name, Env.Types.Double, args), name, this, args);
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